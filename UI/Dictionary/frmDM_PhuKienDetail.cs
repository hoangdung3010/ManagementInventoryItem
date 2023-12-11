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
    public partial class frmDM_PhuKienDetail : FormUI.MFormDictionnaryDetail
    {
        public frmDM_PhuKienDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<DM_PhuKienRepository>(),
                    EntityName = "DM_PhuKien",
                    Title = "Phụ kiện"
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
            mLookUpSanPham.Properties.DisplayMember = "sTenSanPham";
            mLookUpSanPham.Properties.ValueMember = "Id";
            mLookUpSanPham.AddColumn("sMaSanPham", "Mã sản phẩm", 120);
            mLookUpSanPham.AddColumn("sTenSanPham", "Tên sản phẩm", 180, true);
            mLookUpSanPham.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham),
                columns: "Id,sMaSanPham,sTenSanPham", orderBy: "sTenSanPham");
            mLookUpSanPham.AliasFormQuickAdd = "DM_SanPham";

            mLookUpDonViTinh.Properties.DisplayMember = "sTenDonViTinh";
            mLookUpDonViTinh.Properties.ValueMember = "Id";
            mLookUpDonViTinh.AddColumn("sTenDonViTinh", "Tên đơn vị tính", 180, true);
            mLookUpDonViTinh.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_DonViTinhRepository>().GetData(typeof(MT.Data.BO.DM_DonViTinh),
                columns: "Id,sTenDonViTinh", orderBy: "sTenDonViTinh");
            mLookUpDonViTinh.AliasFormQuickAdd = "DM_DonViTinh";
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
