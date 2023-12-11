using MT.Data.Rep;
using MT.Library;
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

namespace FormUI
{
    public partial class frmDM_KhoDetail : FormUI.MFormDictionnaryDetail
    {
        public frmDM_KhoDetail()
        {
            InitializeComponent();
            ConfigFormDetail = new ConfigFormDetail
            {
                Rep = DBContext.GetRep<DM_KhoRepository>(),
                EntityName = "DM_Kho",
                Title = "Kho hàng"
            };
        }

        #region"Sub/Func"
        /// <summary>
        /// Khởi tạo các giá trị của lookup
        /// </summary>
        private void InitLookup()
        {
            treesDM_Donvi_Id.Properties.DisplayMember = "sTenDonvi";
            treesDM_Donvi_Id.Properties.ValueMember = "Id";
            treesDM_Donvi_Id.AddColumn("sMaDonvi", "Mã Đơn vị", 120);
            treesDM_Donvi_Id.AddColumn("sTenDonvi", "Tên Đơn vị", 180, true);
            treesDM_Donvi_Id.Properties.DataSource = ((DM_DonViRepository)DBContext.GetRep<MT.Data.Rep.DM_DonViRepository>()).GetDonViConCap1VaDonViCungCap(MT.Library.SessionData.OrganizationUnitId);
        }
        #endregion
        #region"Overrides"
       
        #endregion
        #region"Event"
        private void frmDM_KhoDetail_Load(object sender, EventArgs e)
        {
            InitLookup();
        }

        #endregion
    }
}
