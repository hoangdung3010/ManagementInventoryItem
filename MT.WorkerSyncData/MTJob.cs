using MT.SyncData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MT.WorkerSyncData
{
    public class MTJob
    {
        private Timer _timerExport = null;

        private bool _isExportRunSuccess = false;

        private Timer _timeImport;

        private bool _isImportRunSuccess = false;

        /// <summary>
        /// Bắt đầu chạy
        /// </summary>
        public void Start()
        {
            try
            {
                bool isExport = MT.Library.Utility.GetAppSettings<bool>("IsExport", true);

                MT.Library.Log.LogHelper.Debug($"Start service:IsExport={isExport}");

                if (isExport)
                {
                    SetTimeExportData();
                }
                else
                {
                    SetTimeImportData();
                }
                MT.Library.Log.LogHelper.Debug("Start success");
            }
            catch (Exception ex)
            {
               MT.Library.Log.LogHelper.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Thiết lập thời gian export data
        /// </summary>
        private void SetTimeExportData()
        {
            try
            {
                _timerExport = new Timer();
                //Mặc đinh 30 phút chạy 1 lần
                 long interval = MT.Library.Utility.GetAppSettings<int>("Export:Interval", 1800000);
                _timerExport.Interval = interval;
                _timerExport.Enabled = true;
                _timerExport.AutoReset = false;
                _timerExport.Elapsed += Timer_Elapsed_Export;

                MT.Library.Log.LogHelper.Debug("ExportData run at:" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
            }
            catch (Exception ex)
            {
                MT.Library.Log.LogHelper.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Thiết lập thời gian import data
        /// </summary>
        private void SetTimeImportData()
        {
            try
            {
                _timeImport = new Timer();
                //Mặc đinh 30 phút chạy 1 lần
                 long interval = MT.Library.Utility.GetAppSettings<int>("Import:Interval", 1800000);
                _timeImport.Interval = interval;
                _timeImport.Enabled = true;
                _timeImport.AutoReset = false;
                _timeImport.Elapsed += Timer_Elapsed_Import;

                MT.Library.Log.LogHelper.Debug("ImportData run at:" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));

            }
            catch (Exception ex)
            {
                MT.Library.Log.LogHelper.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Dừng service
        /// </summary>
        public void Stop()
        {
            if (_timerExport != null)
            {
                _timerExport.Stop();
                _timerExport = null;
            }

            if (_timeImport != null)
            {
                _timeImport.Stop();
                _timeImport = null;
            }

            MT.Library.Log.LogHelper.Debug("Stop success");
        }

        /// <summary>
        /// Thực hiện export dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed_Export(object sender, ElapsedEventArgs e)
        {
            
            try
            {
                var organizationUnitId= MT.Library.Utility.GetAppSettings<Guid>("OrganizationUnitId",Guid.Empty);

                MT.Library.Log.LogHelper.Debug($"Start exportdata đơn vị {organizationUnitId} at {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}");

                string connectionString = MT.Library.Utility.GetConnectionString();
                string msgError = string.Empty;

                ExportData.Instance.Execute(connectionString,organizationUnitId,ref msgError);

                if (!string.IsNullOrWhiteSpace(msgError))
                {
                    MT.Library.Log.LogHelper.Debug($"Exportdata error:" +msgError);
                }
                else
                {
                    MT.Library.Log.LogHelper.Debug($"Exportdata success: {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}");
                }

                _isExportRunSuccess = true;
            }
            catch (Exception ex)
            {
                MT.Library.Log.LogHelper.Error(ex, ex.Message);
                _isExportRunSuccess = true;
            }
            finally
            {
                if (_isExportRunSuccess)
                {
                    if (_timerExport != null)
                    {
                        _timerExport.Stop();
                        _timerExport = null;
                    }
                    SetTimeExportData();
                }
            }

        }

        /// <summary>
        /// Thực hiện import dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed_Import(object sender, ElapsedEventArgs e)
        {
           
            try
            {
                var organizationUnitId = MT.Library.Utility.GetAppSettings<Guid>("OrganizationUnitId", Guid.Empty);

                MT.Library.Log.LogHelper.Debug($"Start importdata đơn vị {organizationUnitId} at {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}");

                string msgError = string.Empty;
                string connectionString = MT.Library.Utility.GetConnectionString();
                ImportData.Instance.Execute(connectionString, organizationUnitId, ref msgError);

                if (!string.IsNullOrWhiteSpace(msgError))
                {
                    MT.Library.Log.LogHelper.Debug($"Import error:" + msgError);
                }
                else
                {
                    MT.Library.Log.LogHelper.Debug($"Import success: {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}");
                }

                _isImportRunSuccess = true;
            }
            catch (Exception ex)
            {
                MT.Library.Log.LogHelper.Error(ex, ex.Message);
                _isImportRunSuccess = true;
            }
            finally
            {
                if (_isImportRunSuccess)
                {
                    if (_timeImport != null)
                    {
                        _timeImport.Stop();
                        _timeImport = null;
                    }
                    SetTimeImportData();
                }
            }

        }

    }
}
