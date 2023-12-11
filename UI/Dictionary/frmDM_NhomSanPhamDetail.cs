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
    public partial class frmDM_NhomSanPhamDetail : FormUI.MFormDictionnaryDetail
    {
        public frmDM_NhomSanPhamDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<DM_NhomSanPhamRepository>(),
                    EntityName = "DM_NhomSanPham",
                    Title = "Nhóm sản phẩm"
                };
            }
            InitLookup();
        }

        #region"Sub/Func"
        private void InitLookup()
        {
            treesParentId.Properties.DisplayMember = "sTenNhomSanPham";
            treesParentId.Properties.ValueMember = "Id";
            var treeList = treesParentId.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            treesParentId.AddColumn("sTenNhomSanPham", "Tên nhóm sản phẩm", 180, true);
            treesParentId.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_NhomSanPhamRepository>().GetData(typeof(MT.Data.BO.DM_NhomSanPham),
                columns: "Id,sParentId,sTenNhomSanPham", orderBy: "SortOrder");
            treesParentId.AliasFormQuickAdd = "DM_NhomSanPham";

        }
        #endregion
        #region "Overrides"
        protected override void SaveSucess(bool isSaveNew)
        {
            base.SaveSucess(isSaveNew);
            if (isSaveNew)
            {
                InitLookup();
            }
        }
        protected override void SetViewModeControlByFromAction()
        {
            base.SetViewModeControlByFromAction();
        }
        #endregion
        #region"Event"
        private void frmDM_NhomSanPhamDetail_Load(object sender, EventArgs e)
        {
        }

        #endregion
    }
}
