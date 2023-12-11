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
    public partial class frmDM_SanPhamDetail : FormUI.MFormDictionnaryDetail
    {
        public frmDM_SanPhamDetail()
        {
            InitializeComponent();

            InitLookup();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<DM_SanPhamRepository>(),
                    FormName = "frmDM_SanPhamDetail",
                    EntityName = "DM_SanPham",
                    Title = "Sản phẩm"
                };
            }
        }

        #region"Sub/Func"

        /// <summary>
        /// Khởi tạo giá trị combo
        /// </summary>
        private void InitLookup()
        {
            
            lookupNhomSanPham.Properties.DisplayMember = "sTenNhomSanPham";
            lookupNhomSanPham.Properties.ValueMember = "Id";
            lookupNhomSanPham.AddColumn("sTenNhomSanPham", "Tên nhóm", 180, true);
            lookupNhomSanPham.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_NhomSanPhamRepository>().GetData(typeof(MT.Data.BO.DM_NhomSanPham),
                columns: "Id,sTenNhomSanPham", orderBy: "sTenNhomSanPham");
            lookupNhomSanPham.AliasFormQuickAdd = "DM_NhomSanPham";

            var units= DBContext.GetRep<MT.Data.Rep.DM_DonViTinhRepository>().GetData(typeof(MT.Data.BO.DM_DonViTinh),
                columns: "Id,sTenDonViTinh", orderBy: "sTenDonViTinh");


            lookupsDM_DonViTinh_Id_Cap1.Properties.DisplayMember = "sTenDonViTinh";
            lookupsDM_DonViTinh_Id_Cap1.Properties.ValueMember = "Id";
            lookupsDM_DonViTinh_Id_Cap1.AddColumn("sTenDonViTinh", "Tên đơn vị tính", 180, true);
            lookupsDM_DonViTinh_Id_Cap1.Properties.DataSource = units;

            lookupsDM_DonViTinh_Id_Cap1.AliasFormQuickAdd = "DM_DonViTinh";

            lookupsDM_DonViTinh_Id_Cap2.Properties.DisplayMember = "sTenDonViTinh";
            lookupsDM_DonViTinh_Id_Cap2.Properties.ValueMember = "Id";
            lookupsDM_DonViTinh_Id_Cap2.AddColumn("sTenDonViTinh", "Tên đơn vị tính", 180, true);
            lookupsDM_DonViTinh_Id_Cap2.Properties.DataSource = units;

            lookupsDM_DonViTinh_Id_Cap2.AliasFormQuickAdd = "DM_DonViTinh";
        }
        #endregion
        #region"Event"
        private void frmDM_SanPhamDetail_Load(object sender, EventArgs e)
        {
        }

        #endregion
    }
}
