using FormUI.Base;
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

namespace FormUI.Dashboard.Params
{
    public partial class MTParamBase : MXTraForm
    {
        #region"Declare"
        private Dictionary<string, IEditControl> _dicControls;

        public Dictionary<string, IEditControl> DicControls
        {
            get { return _dicControls; }
            set { _dicControls = value; }
        }

        private MDxValidationProvider ValidationProvider = null;

        public Control RootControl { get; set; }

        public ucHeaderDashboard UcHeaderDashboard { get; set; }

        public Dictionary<string, object> DefaultParams
        {
            get;set;
        }
        #endregion

        #region"Constructor"
        public MTParamBase()
        {
            InitializeComponent();
            Init();
        }
        public MTParamBase(ucHeaderDashboard ucHeaderDashboard)
        {
            InitializeComponent();
            UcHeaderDashboard = ucHeaderDashboard;
            
        }
        #endregion

        #region"Init"
        private void Init()
        {
            _dicControls = new Dictionary<string, IEditControl>();
            ValidationProvider = new MDxValidationProvider();
            //Lấy toàn bộ các control nhập liệu trên form
            _dicControls = CommonFnUI.GetAllControls(RootControl==null?this: RootControl, new Dictionary<string, IEditControl>());
            CommonFnUI.InitValidateControl(ValidationProvider, _dicControls);
            //Clear validate lỗi trên form
            CommonFnUI.ClearValidateForm(this.ValidationProvider);
        }

        /// <summary>
        /// Thiết lập tham số mặc định cho báo cáo
        /// </summary>
        /// <param name="dicParams">Tham số mặc định</param>
        public void SetDefaultValue(Dictionary<string,object> defaultParams)
        {
            DefaultParams = defaultParams;
        }
        #endregion

        #region"Event"
        /// <summary>
        /// Sự kiện đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Sự kiện nhấn áp dụng trên form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            bool isValid = CommonFnUI.IsValidAll(ValidationProvider, _dicControls);
            if (isValid)
            {
                Dictionary<string, object> dicData = new Dictionary<string, object>();
                if (_dicControls != null)
                {
                    foreach (var c in _dicControls)
                    {
                        CommonFnUI.BinddingValueIntoDictionary(ref dicData, c.Value);
                    }
                }
                UcHeaderDashboard.SetParams(dicData);
                UcHeaderDashboard.LoadData();
                this.Close();

            }
        }

        /// <summary>
        /// Load value mặc định
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MTParamBase_Load(object sender, EventArgs e)
        {
            Init();

            if (DefaultParams != null)
            {
                CommonFnUI.BinddingValueIntoControl(DefaultParams, _dicControls);
            }
        }
        #endregion


    }
}
