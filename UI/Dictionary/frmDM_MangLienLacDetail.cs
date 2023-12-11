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
    public partial class frmDM_MangLienLacDetail : FormUI.MFormDictionnaryDetail
    {
        public frmDM_MangLienLacDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<DM_MangLienLacRepository>(),
                    EntityName = "DM_MangLienLac",
                    Title = "Mạng liên lạc"
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
            mLookUpThamSoMatMa.Properties.DisplayMember = "sTenThamSoMatMa";
            mLookUpThamSoMatMa.Properties.ValueMember = "Id";
            mLookUpThamSoMatMa.AddColumn("sMaThamSoMatMa", "Mã tham số mật mã", 120);
            mLookUpThamSoMatMa.AddColumn("sTenThamSoMatMa", "Tên tham số mật mã", 180, true);
            mLookUpThamSoMatMa.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_ThamSoMatMaRepository>().GetData(typeof(MT.Data.BO.DM_ThamSoMatMa),
                columns: "Id,sMaThamSoMatMa,sTenThamSoMatMa", orderBy: "sTenThamSoMatMa");
            mLookUpThamSoMatMa.AliasFormQuickAdd = "DM_ThamSoMatMa";
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
