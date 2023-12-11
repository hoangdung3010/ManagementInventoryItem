using MT.Data.Rep;
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
    public partial class frmDM_NhomSanPham : FormUI.MFormList
    {
        #region"Property"
        #endregion

        #region"Contructor"
        public frmDM_NhomSanPham()
        {
            InitializeComponent();

            InitTree();

            ConfigFormDetail = new ConfigFormDetail
            {
                Rep = DBContext.GetRep<DM_NhomSanPhamRepository>(),
                FormName = "frmDM_NhomSanPhamDetail",
                Tree = treePaging,
                MToolbarList=mToolbarList1,
                EntityName= "DM_NhomSanPham",
                Title = "Nhóm sản phẩm"
            };
            mToolbarList1.ButtonNames = new MButtonName[]
           {
                new MButtonName{CommandName=MCommandName.AddNew},
                new MButtonName{CommandName=MCommandName.Duplicate},
                new MButtonName{CommandName=MCommandName.View},
                new MButtonName{CommandName=MCommandName.Edit},
                new MButtonName{CommandName=MCommandName.Delete},               
                new MButtonName{CommandName=MCommandName.Refresh,BeginGroup=true},
                new MButtonName{CommandName=MCommandName.Help,BeginGroup=true}
           };
        }
        #endregion

        #region"Sub/Func"
        /// <summary>
        /// Khởi tạo các cột trên tree
        /// </summary>
        /// Create by: dvthang:07.03.2017
        private void InitTree()
        {
            MTreeView tv = this.treePaging.GetMTreeControl();
            //
            tv.OptionsView.ShowAutoFilterRow = true;
            tv.OptionsBehavior.ReadOnly = true;
            tv.OptionsBehavior.EnableFiltering = true;
            tv.Nodes.Clear();
            tv.KeyName = "Id";
            tv.TableName = "DM_NhomSanPham";
            tv.ParentFieldName = "sParentId";
            tv.KeyFieldName = "Id";
            tv.ViewName = "View_DM_NhomSanPham";
            var colMaDonVi = this.treePaging.AddColumnText("sTenNhomSanPham", "Tên nhóm sản phẩm", 500, isFixWidth: true, fixedStyle: DevExpress.XtraTreeList.Columns.FixedStyle.Left);
            this.treePaging.AddColumnText("sGhiChu", "Ghi chú", 250);
        }
        #endregion

        #region"Overrides"
        #endregion

        #region"Event"
        private void frmDM_DonVi_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        #endregion


    }
}
