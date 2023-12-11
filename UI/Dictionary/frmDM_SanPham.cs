using MT.Data;
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
    public partial class frmDM_SanPham : FormUI.MFormList
    {
        #region"Property"
        #endregion

        #region"Contructor"
        public frmDM_SanPham()
        {
            InitializeComponent();
            mToolbarList1.ButtonNames = new MButtonName[]
           {
                new MButtonName{CommandName=MCommandName.AddNew},
                new MButtonName{CommandName=MCommandName.Duplicate},
                new MButtonName{CommandName=MCommandName.View},
                new MButtonName{CommandName=MCommandName.Edit},
                new MButtonName{CommandName=MCommandName.Delete},
                new MButtonName{CommandName=MCommandName.Import,BeginGroup=true},
                new MButtonName{CommandName=MCommandName.Excel,BeginGroup=true},
                new MButtonName{CommandName=MCommandName.Refresh,BeginGroup=true},
                new MButtonName{CommandName=MCommandName.Help,BeginGroup=true}
           };

            InitGrid();

            ConfigFormDetail = new ConfigFormDetail
            {
                Rep = DBContext.GetRep<DM_SanPhamRepository>(),
                FormName = "frmDM_SanPhamDetail",
                Grid = gridMaster,
                MToolbarList = mToolbarList1,
                EntityName = "DM_SanPham",
                Title = "Sản phẩm"
            };

        }
        #endregion

        #region"Sub/Func"
        /// <summary>
        /// Khởi tạo các cột trên grid
        /// </summary>
        /// Create by: dvthang:07.03.2017
        private void InitGrid()
        {
            var grd = this.gridMaster.GetMGridControl();
            grd.TableName = "DM_SanPham";
            grd.ViewName = "View_DM_SanPham";
            grd.SetMutiSelectRows(true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect);
            this.gridMaster.KeyName = "Id";
            this.gridMaster.AddColumnText("sMaSanPham", "Mã sản phẩm", 100, isFixWidth: true);
            this.gridMaster.AddColumnText("sTenSanPham", "Tên sản phẩm", 200);
            this.gridMaster.AddColumnText("sDM_NhomSanPham_Id_Ten", "Nhóm sản phẩm", 200);
            this.gridMaster.AddColumnText("bKepChi", "Kẹp chì", 100, enumName: "bKepChi");
            this.gridMaster.AddColumnText("sDM_DonViTinh_Id_Cap1_Ten", "Đơn vị tính cấp 1", 100);
            this.gridMaster.AddColumnText("rDonGia_Cap1", "Đơn giá cấp 1", 100);
            this.gridMaster.AddColumnText("iKichThuocDongGoi", "Tỷ lệ quy đổi", 80);
            this.gridMaster.AddColumnText("sDM_DonViTinh_Id_Cap2_Ten", "Đơn vị tính cấp 2", 100);
            this.gridMaster.AddColumnText("rDonGia_Cap2", "Đơn giá cấp 2", 100);
            this.gridMaster.AddColumnText("sCauHinhKyThuat", "Cấu hình kỹ thuật", 200);
            this.gridMaster.AddColumnText("sXuatXu", "Xuất xứ", 200);
            this.gridMaster.AddColumnText("rSoNamSuDung", "Số năm sử dụng", 100);
            this.gridMaster.AddColumnText("sGhiChu", "Ghi chú", 200);
        }
        #endregion

        #region"Overrides"
        /// <summary>
        /// Ẩn hiện các nút trên Toolbar
        /// </summary>
        /// <param name="mToolbar"></param>
        /// <param name="mBindingSource"></param>
        protected override void CustomSetEnableButtonOnToolbar(MToolbarList mToolbar, MBindingSource mBindingSource)
        {
            base.CustomSetEnableButtonOnToolbar(mToolbar, mBindingSource);
            SetEnableButtonOnToolbar(MCommandName.Import, true);
        }
        protected override void ProcessItemClick(int tag, object sender)
        {
            base.ProcessItemClick(tag, sender);
            switch (tag)
            {
                case (int)MTControl.MCommandName.Import:
                    using (frmImportData frmImportData = new frmImportData())
                    {
                        frmImportData.ImportDataType = ImportDataType.DM_SanPham;
                        frmImportData.ShowDialog();
                    }
                    break;
            }
        }
        #endregion

        #region"Event"
        private void frmDM_DonVi_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        #endregion


    }
}
