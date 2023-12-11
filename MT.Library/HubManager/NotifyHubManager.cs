using Microsoft.AspNet.SignalR.Client;
using MT.Library;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;

namespace MT.Library
{
    public class NotifyHubManager
    {
        private string _url;

        private string _device;

        private string _uid;

        private string _appName;
        public HubConnection Connection { get; set; }
        public IHubProxy Proxy { get; set; }

        public NotifyHubManager(string url, string device, string uid, string appName)
        {
            _url = url;
            _device = device;
            _uid = uid;
            _appName = appName;

            InitConnect();
        }

        /// <summary>
        /// Khởi tạo connection đến hub
        /// </summary>
        /// <returns></returns>
        private void InitConnect()
        {
            try
            {
                MT.Library.Log.LogHelper.Trace($"InitConnect:Url={_url},Device={_device},Uid={_uid},appName={_appName}");
                Connection = new HubConnection(_url, new System.Collections.Generic.Dictionary<string, string>
                {
                    {"uid",MT.Library.Utility.Base64Encode(MT.Library.Utility.Encrypt(_uid)) },
                    {"appName",_appName }
                });
                Connection.Headers.Add("Device", _device);
                Proxy = Connection.CreateHubProxy("notifyHub");
                Connection.StateChanged += Connection_StateChanged;
            }
            catch (Exception ex)
            {
                MT.Library.Log.LogHelper.Error(ex, $"Message:{ex.Message},StackTrace: {ex.StackTrace}");
            }
        }
        /// <summary>
        /// Trạng thái connection
        /// </summary>
        /// <param name="obj"></param>
        private void Connection_StateChanged(StateChange obj)
        {
            if (obj.NewState == ConnectionState.Connected)
            {
                MT.Library.Log.LogHelper.Trace($"InitConnect_NewState={ConnectionState.Connected.ToString()}");
            }
        }

        /// <summary>
        /// Đăng ký event nhận thông báo
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="action"></param>
        public void RegisterEvent(string eventName, Action<EmitData> action)
        {
            Proxy.On<EmitData>(eventName, (message) =>
            {
                action.Invoke(message);
            });

        }

        public async Task Start()
        {
            await Connection.Start();
        }

        public void Stop()
        {
            Connection.Stop();
        }

        /// <summary>
        /// Gửi thông báo đến các thiết bị đăng đăng ký nhận thông báo
        /// </summary>
        /// <param name="emitData">Dữ liệu bắn về các thiết bị</param>
        /// <param name="whos">Danh sách các thiết bị gửi về</param>
        /// Created by: dvthang: 21.12.2020
        public async Task AsyncSendMessage(EmitData emitData, params string[] whos)
        {
            try
            {
                if (whos == null || whos.Length == 0)
                {
                    await Proxy.Invoke("notifyAll", emitData);
                }
                else
                {
                    await Proxy.Invoke("notify", emitData, whos);
                }
            }
            catch (Exception ex)
            {

                MT.Library.Log.LogHelper.Error(ex, $"Message:{ex.Message},StackTrace: {ex.StackTrace}");
            }
        }


        /// <summary>
        /// Gửi thông báo đến các thiết bị đăng đăng ký nhận thông báo
        /// </summary>
        /// <param name="emitData">Dữ liệu bắn về các thiết bị</param>
        /// <param name="whos">Danh sách các thiết bị gửi về</param>
        /// Created by: dvthang: 21.12.2020
        public void SendMessage(EmitData emitData, params string[] whos)
        {
            try
            {
                Task.Run(async () =>
                {
                    if (whos == null || whos.Length == 0)
                    {
                        await Proxy.Invoke("notifyAll", emitData);
                    }
                    else
                    {
                        await Proxy.Invoke("notify", emitData, whos);
                    }
                });

            }
            catch (Exception ex)
            {

                MT.Library.Log.LogHelper.Error(ex, $"Message:{ex.Message},StackTrace: {ex.StackTrace}");
            }
        }
    }
}