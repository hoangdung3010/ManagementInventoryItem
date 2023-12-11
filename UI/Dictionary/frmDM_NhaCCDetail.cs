using MT.Data.Rep;
using MT.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class frmDM_NhaCCDetail : FormUI.MFormDictionnaryDetail
    {
        public frmDM_NhaCCDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<DM_NhaCCRepository>(),
                    EntityName = "DM_NhaCC",
                    Title = "Nhà cung cấp"
                };
            }
        }

        #region"Sub/Func"
        protected override void SaveSucess(bool isSaveNew)
        {
            base.SaveSucess(isSaveNew);
            if (isSaveNew)
            {
                InitLookup();
            }
        }

        /// <summary>
        /// Khởi tạo các giá trị của lookup
        /// </summary>
        private void InitLookup()
        {
        }
        #endregion
        #region"Event"
        private void frmDM_DonViDetail_Load(object sender, EventArgs e)
        {
            InitLookup();
        }

        #endregion
    }
}
