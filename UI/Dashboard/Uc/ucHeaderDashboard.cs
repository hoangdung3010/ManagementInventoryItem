using DevExpress.XtraSplashScreen;
using MT.Data.BO;
using MT.Library.UW;
using MTControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI.Dashboard
{
    public partial class ucHeaderDashboard : UserControl
    {
        private Dictionary<string, object> _dicParams = new Dictionary<string, object>();

        public Dictionary<string,object> Params
        {
            get
            {
                return _dicParams;
            }
            set
            {
                _dicParams = value;
            }
        }

        private int _dictionaryKey;

        /// <summary>
        /// Định danh của báo cáo
        /// </summary>
        public int DictionaryKey
        {
            get
            {
                return _dictionaryKey;
            }
            set
            {
                _dictionaryKey = value;
            }
        }

        private Action<object,Dictionary<string, object>> _whenLoadDataSuccess;

        /// <summary>
        /// Bắt event khi load dữ liệu thành công
        /// </summary>
        public Action<object, Dictionary<string,object>> WhenLoadDataSuccess
        {
            get
            {
                return _whenLoadDataSuccess;
            }
            set
            {
                _whenLoadDataSuccess = value;
            }
        }

        private Func<Dictionary<string, object>,string> _buildSubTitle;

        /// <summary>
        /// Bắt event khi load dữ liệu thành công
        /// </summary>
        public Func<Dictionary<string, object>,string> BuildSubTitle
        {
            get
            {
                return _buildSubTitle;
            }
            set
            {
                _buildSubTitle = value;
            }
        }

        private IOverlaySplashScreenHandle _overlaySplashScreenHandle = null;
        public ucHeaderDashboard()
        {
            InitializeComponent();
            lblSubTitle.ForeColor = Color.Black;
        }

        /// <summary>
        /// Gán title cho báo cáo
        /// </summary>
        /// <param name="title"></param>
        public void SetTitle(string title)
        {
            lblTitleDashboard.Invoke(new Action(() =>
            {
                lblTitleDashboard.Text = title;
            }));
        }

        /// <summary>
        /// Gán subtitle cho báo cáo(Param báo cáo)
        /// </summary>
        /// <param name="title"></param>
        public void SetSubTitle(string subTitle)
        {
            lblSubTitle.Text = subTitle;
        }

        #region"Event"
        /// <summary>
        /// Xử lý load dữ liệu cho báo cáo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorkerLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            string query = $"SELECT * FROM ConfigDashBoard where DictionaryKey={(int)this.DictionaryKey}";
            using (IUnitOfWork  unitOfWork=new UnitOfWork(MT.Library.SessionData.ConnectString))
            {
                var configDashBoard = unitOfWork.QueryFirstOrDefault<ConfigDashBoard>(query);
                if (configDashBoard == null)
                {
                    return;
                }
                SetTitle(configDashBoard.DashboardName);
                if (!string.IsNullOrWhiteSpace(configDashBoard.Store))
                {
                    e.Result = unitOfWork.QueryDataTable(configDashBoard.Store,
                        e.Argument as Dictionary<string, object>, CommandType.StoredProcedure);
                }
            }
        }

        /// <summary>
        /// Khi load dữ liệu thành công
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorkerLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (BuildSubTitle != null)
                {
                    string subtitle = BuildSubTitle(_dicParams);
                    SetSubTitle(subtitle);
                }
                if (_whenLoadDataSuccess != null)
                {
                    _whenLoadDataSuccess(e.Result,_dicParams);
                }
            }

            if (_overlaySplashScreenHandle != null)
            {
                CommonFnUI.CloseProgress(_overlaySplashScreenHandle);
            }
        }

        /// <summary>
        /// Làm mới danh sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!bgWorkerLoadData.IsBusy)
            {
                bgWorkerLoadData.RunWorkerAsync(_dicParams);
            }
        }

        private void ucHeaderDashboard_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region"Sub/Func"

        /// <summary>
        /// Gán tham số cho báo cáo
        /// </summary>
        /// <param name="dciParams">Thông tin tham số</param>
        public void SetParams(Dictionary<string, object> dicParams)
        {
            _dicParams = dicParams;
        }

        /// <summary>
        /// Load dữ liệu báo cáo
        /// </summary>
        /// <param name="dicParams">Tham số báo cáo</param>
        public void LoadData()
        {
            if (!bgWorkerLoadData.IsBusy)
            {
                _overlaySplashScreenHandle=CommonFnUI.ShowProgress(this);
                bgWorkerLoadData.RunWorkerAsync(_dicParams);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            //FormUI.Dashboard.Params
            string query = $"SELECT * FROM ConfigDashBoard where DictionaryKey={(int)this.DictionaryKey}";
            using (IUnitOfWork unitOfWork = new UnitOfWork(MT.Library.SessionData.ConnectString))
            {
                var configDashBoard = unitOfWork.QueryFirstOrDefault<ConfigDashBoard>(query);
                if (string.IsNullOrWhiteSpace(configDashBoard.UcParamName))
                {
                    MMessage.ShowWarning("Chưa khai báo form tham số");
                    return;
                }
                Type type = Type.GetType($"FormUI.Dashboard.Params.{configDashBoard.UcParamName},FormUI");
                if (type == null)
                {
                    throw new Exception($"{configDashBoard.UcParamName} not exists");
                }
                using (var frmParam = (FormUI.Dashboard.Params.MTParamBase)Activator.CreateInstance(type))
                {
                    frmParam.StartPosition = FormStartPosition.CenterScreen;
                    frmParam.UcHeaderDashboard = this;
                    frmParam.SetDefaultValue(this._dicParams);
                    frmParam.ShowDialog();
                    frmParam.Dispose();
                }
            }

        }
        #endregion


    }
}
