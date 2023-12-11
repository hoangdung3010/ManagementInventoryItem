using MT.Data;
using MT.Data.BO;
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
    public partial class frmTraCuuTonKho : FormUI.FormUIBase
    {
        TypeAssistant assistant;
        public frmTraCuuTonKho()
        {
            InitializeComponent();
            InitLookup();
            InitGrid();
        }

        /// <summary>
        /// Khởi tạo dữ liệu cho các trường lookup
        /// </summary>
        private void InitLookup()
        {
            treesDM_DonVi_Id_DonVi.Properties.DisplayMember = "sTenDonvi";
            treesDM_DonVi_Id_DonVi.Properties.ValueMember = "Id";
            var treeList = treesDM_DonVi_Id_DonVi.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            treesDM_DonVi_Id_DonVi.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            treesDM_DonVi_Id_DonVi.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            treesDM_DonVi_Id_DonVi.Properties.NullText = "Tất cả";
            treesDM_DonVi_Id_DonVi.Properties.NullValuePrompt = "Tất cả";

            var donvis= (List<DM_DonVi>)DBContext.GetRep2<DM_DonViRepository>().GetData(typeof(DM_DonVi), viewName: "View_DM_DonVi", orderBy: "sMaDonvi");
            treesDM_DonVi_Id_DonVi.Properties.DataSource = donvis;

            var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham), "Id,sMaSanPham,sTenSanPham,sDM_NhomSanPham_Id_Ten", orderBy: "sMaSanPham", viewName: "View_DM_SanPham");
            cbosSanPham.Properties.DisplayMember = "sTenSanPham";
            cbosSanPham.Properties.ValueMember = "Id";
            cbosSanPham.Properties.NullText = "Tất cả";
            cbosSanPham.Properties.NullValuePrompt = "Tất cả";
            cbosSanPham.Properties.DataSource = dm_SanPhams;
        }

        /// <summary>
        /// Khởi tạo các cột trên grid
        /// </summary>
        /// Create by: dvthang:07.03.2017
        private void InitGrid()
        {
            
            grd.FirstView.OptionsView.AllowCellMerge = true;
            var col =grd.AddColumnText("sDM_SanPham_Ma", "Mã sản phẩm", "Mã sản phẩm", 120, isFixWidth: true,
               fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            col=grd.AddColumnText("sDM_SanPham_Id_Ten", "Tên sản phẩm", "Tên sản phẩm", 250, isFixWidth: true,
               fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            col = grd.AddColumnText("sMaVach", "Mã vạch", "Mã vạch", 120);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            col = grd.AddColumnText("sDM_DonViTinh_Id_Ten", "Đơn vị tính", "Đơn vị tính", 60);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            col=grd.AddColumnText("sDM_DonVi_Id_Ten", "Đơn vị", 250);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            col=grd.AddColumnText("rSoLuongTon", "Số tồn", 100, fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);
            col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            col = grd.AddColumnText("rSoLuongTongTon", "Tổng số tồn", 100, fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);

            grd.FirstView.CellMerge += FirstView_CellMerge;
        }

        private void FirstView_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            MGridView view = sender as MGridView;
            if (view == null) return;
            if (e.Column.FieldName == "rSoLuongTongTon")
            {
                string sp1 = view.GetRowCellDisplayText(e.RowHandle1, "sDM_SanPham_Id_Ten");
                string sp2 = view.GetRowCellDisplayText(e.RowHandle2, "sDM_SanPham_Id_Ten");
                string tTon1 = view.GetRowCellDisplayText(e.RowHandle1, "rSoLuongTongTon");
                string tTon2 = view.GetRowCellDisplayText(e.RowHandle2, "rSoLuongTongTon");
                e.Merge = (sp1 == sp2 && tTon1== tTon2);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Thực hiện load dữ liệu
        /// </summary>
        private void LoadData()
        {
            string sMaVach = txtMaVach.Text;
            if (!string.IsNullOrWhiteSpace(sMaVach) && MT.Library.Utility.CheckForSQLInjection(sMaVach))
            {
                MMessage.ShowError($"Mã vạch <{sMaVach}> không được chưa các ký tự đặc biệt");
                return;
            }

            if (!bgLoadGrid.IsBusy)
            {
                ArgumentTraCuuTonKho argumentTraCuuTonKho = new ArgumentTraCuuTonKho()
                {
                    IsExistssMaVachPositive=chkConTon.Checked,
                    IsExistsAtStock=chkTaiKho.Checked,
                    IsExistsRealInStock= chkMaVachThucTeTrongKho.Checked
                };
                if (treesDM_DonVi_Id_DonVi.EditValue != null && treesDM_DonVi_Id_DonVi.EditValue.ToString() != "")
                {
                    argumentTraCuuTonKho.OrganizationUnitId = Guid.Parse(treesDM_DonVi_Id_DonVi.EditValue.ToString());
                }
                if (cbosSanPham.EditValue != null && cbosSanPham.EditValue.ToString()!="")
                {
                    argumentTraCuuTonKho.sDM_SanPham_Ids = new List<Guid>();
                    var spIds = cbosSanPham.EditValue.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    argumentTraCuuTonKho.sDM_SanPham_Ids = spIds.Select(m => Guid.Parse(m)).ToList();
                }
                argumentTraCuuTonKho.sMaVach = sMaVach.Trim();
                bgLoadGrid.RunWorkerAsync(argumentTraCuuTonKho);
            }
        }
        #region"Event"
       
        /// <summary>
        /// Đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTraCuuTonKho_Load(object sender, EventArgs e)
        {
           
            grd.FirstView.OptionsBehavior.Editable = false;
            grd.FirstView.OptionsSelection.EnableAppearanceFocusedCell = true;
            grd.FirstView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.CellFocus;
            grd.SetMutiSelectRows(false, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect);
            treesDM_DonVi_Id_DonVi.EditValue = MT.Library.SessionData.OrganizationUnitId;
            chkMaVachThucTeTrongKho.Checked = false;
            LoadData();
        }

        private void bgLoadGrid_DoWork(object sender, DoWorkEventArgs e)
        {
            ArgumentTraCuuTonKho argumentTraCuuTonKho = e.Argument as ArgumentTraCuuTonKho;
            e.Result = GhiSoKho.GetChiTietTonKho(argumentTraCuuTonKho.sMaVach, 
                argumentTraCuuTonKho.OrganizationUnitId, 
                argumentTraCuuTonKho.sDM_SanPham_Ids,
                argumentTraCuuTonKho.IsExistssMaVachPositive, 
                argumentTraCuuTonKho.IsExistsAtStock,
                argumentTraCuuTonKho.IsExistsRealInStock);
        }

        private void bgLoadGrid_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                grd.DataSource = e.Result;
            }
            else
            {
                MMessage.ShowError(e.Error.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
      
        private void txtMaVach_EditValueChanged(object sender, EventArgs e)
        {
            assistant = new TypeAssistant(1000);
            assistant.Idled += assistant_Idled;
            assistant.TextChanged();
        }

        private void assistant_Idled(object sender, EventArgs e)
        {
            this.Invoke(
             new MethodInvoker(() =>
             {
                 LoadData();
             }));
        }

        private void cbosSanPham_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void treesDM_DonVi_Id_DonVi_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void chkConTon_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void chkTaiKho_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void chkMaVachThucTeTrongKho_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void cbosSanPham_EditValueChanged_1(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion


    }
}
