using DevExpress.XtraEditors.Repository;
using MT.Data;
using MT.Data.BO;
using MT.Data.Rep;
using MT.Data.ViewModels;
using MT.Library.UW;
using MTControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class frmAdvancedSearch : FormUI.FormUIBase
    {
        TypeAssistant assistant;

        #region"Constructor"
        public frmAdvancedSearch()
        {
            InitializeComponent();
           
            InitGrid();

        }

        #endregion

        #region"Sub/Func"
        private void InitForm()
        {
            //San Pham
            var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham),
               "Id,sMaSanPham,sTenSanPham,sDM_NhomSanPham_Id_Ten", viewName: "View_DM_SanPham", orderBy: "sDM_NhomSanPham_Id_Ten,sMaSanPham");

            cboTenSanPham.Properties.DisplayMember = "sTenSanPham";
            cboTenSanPham.Properties.ValueMember = "Id";
            cboTenSanPham.AddColumn("sMaSanPham", "Mã sản phẩm", 120);
            cboTenSanPham.AddColumn("sTenSanPham", "Tên sản phẩm", 180);
            cboTenSanPham.AddColumn("sDM_NhomSanPham_Id_Ten", "Nhóm sản phẩm", 180);
            cboTenSanPham.Properties.DataSource = dm_SanPhams;
            cboTenSanPham.Properties.NullText = "Tất cả";
            //Mang Lien Lac
            cboMangLienLac.AddColumn("sTenMangLienLac", "Tên mạng liên lạc", 180);
            cboMangLienLac.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_MangLienLacRepository>().GetData(typeof(MT.Data.BO.DM_MangLienLac), "Id,sTenMangLienLac", orderBy: "SortOrder"); ;
            cboMangLienLac.Properties.DisplayMember = "sTenMangLienLac";
            cboMangLienLac.Properties.ValueMember = "Id";
            cboMangLienLac.Properties.NullText = "Tất cả";
            //Trang Thai
            
            cboTrangThai.EnumData = "TrangThaiTimKiemSanPham";
            cboTrangThai.Properties.Items.Insert(0, new DisplayEnum { Value = 0, Text = "Tất cả" });
            cboTrangThai.SelectedIndex = 0;
            var donvi = DBContext.GetRep2<DM_DonViRepository>().GetDonViConCap1VaDonViCungCapVaNhaCungCap(MT.Library.SessionData.OrganizationUnitId, uuTienNhaCC: false);

            //Đon vị sử dụng
            cboTreeDonViSuDung.Properties.DisplayMember = "sTenDonvi";
            cboTreeDonViSuDung.Properties.ValueMember = "Id";
            cboTreeDonViSuDung.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            cboTreeDonViSuDung.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            cboTreeDonViSuDung.Properties.DataSource = donvi;
            var treeDonViSuDung = cboTreeDonViSuDung.Properties.TreeList;
            treeDonViSuDung.KeyFieldName = "Id";
            treeDonViSuDung.ParentFieldName = "sParentId";

            spinNamSX.EditValue =null;
        }
        /// <summary>
        /// Khởi tạo các cột trên grid
        /// </summary>
        /// Create by: dvthang:07.03.2017
        private void InitGrid()
        {
            var grd = this.grdMaster;
            grd.IsShowFilter = true;
            grd.FirstView.OptionsView.RowAutoHeight = true;
            var col=this.grdMaster.AddColumnText("sMaVach", "Mã vạch", "Mã vạch", 150, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            this.grdMaster.AddColumnText("sMaSanPham", "Mã sản phẩm", "Mã sản phẩm", 120, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            this.grdMaster.AddColumnText("sTenSanPham", "Tên sản phẩm", "Tên sản phẩm", 250);
            this.grdMaster.AddColumnText("sDM_MangLienLac_Id_Ten", "Mạng liên lạc", "Mạng liên lạc", 250);
            this.grdMaster.AddColumnText("sDM_DonViTinh_Id_Ten", "Đơn vị tính", 80);
            col=this.grdMaster.AddColumnText("sDM_DonVi_Id_Nhap_Ten_PX", "Đơn vị được cấp sử dụng", 250);
            col.ColumnEdit = new RepositoryItemMemoEdit()
            {
                WordWrap = true,
                AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True
            };
            col=this.grdMaster.AddColumnText("sDM_DonVi_Id_Nhap_Ten_CuoiCung", "Vị trí của sản phẩm", 250);
            col.ColumnEdit = new RepositoryItemMemoEdit()
            {
                WordWrap = true,
                AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True
            };
            this.grdMaster.AddColumnText("iTrangThai_Ten", "Trạng thái", 180);
            this.grdMaster.AddColumnText("iNamSX", "Năm sản xuất", 80);
            this.grdMaster.AddColumnText("sXuatXu", "Xuất xứ", 250);
            col =this.grdMaster.AddColumnText("sGhiChu", "Ghi chú", 360);
        }

       
        /// <summary>
        /// Tìm vết của hàng hóa
        /// </summary>
        private void FindData()
        {
            string sMaVach = txtsMaVach.Text;
            if (!string.IsNullOrWhiteSpace(sMaVach) && MT.Library.Utility.CheckForSQLInjection(sMaVach))
            {
                MMessage.ShowError($"Mã vạch <{sMaVach}> không được chưa các ký tự đặc biệt");
                return;
            }
            string sMaSanPham =Convert.ToString(txtMaSanPham.EditValue);
            if (!string.IsNullOrWhiteSpace(sMaSanPham) && MT.Library.Utility.CheckForSQLInjection(sMaSanPham))
            {
                MMessage.ShowError($"Mã sản phẩm <{sMaSanPham}> không được chưa các ký tự đặc biệt");
                return;
            }

            string xuatXu = Convert.ToString(txtXuatXu.EditValue);
            if (!string.IsNullOrWhiteSpace(xuatXu) && MT.Library.Utility.CheckForSQLInjection(xuatXu))
            {
                MMessage.ShowError($"Xuất xứ <{xuatXu}> không được chưa các ký tự đặc biệt");
                return;
            }

            string sGhiChu = Convert.ToString(txtGhiChu.EditValue);
            if (!string.IsNullOrWhiteSpace(sGhiChu) && MT.Library.Utility.CheckForSQLInjection(sGhiChu))
            {
                MMessage.ShowError($"Ghi chú <{sGhiChu}> không được chưa các ký tự đặc biệt");
                return;
            }

            if (!bgTimKiem.IsBusy)
            {
                var arg = new ArgumentTimKiemHangHoaNangCao
                {
                    sMaSanPham =Convert.ToString(txtMaSanPham.EditValue)
                };
               
                if (cboTenSanPham.EditValue != null)
                {
                    arg.sDM_SanPham_Id = Guid.Parse(cboTenSanPham.EditValue.ToString());
                }
                if (cboMangLienLac.EditValue != null)
                {
                    arg.sDM_MangLienLac_Id = Guid.Parse(cboMangLienLac.EditValue.ToString());
                }
                if (spinNamSX.EditValue != null && !string.IsNullOrWhiteSpace(spinNamSX.Text))
                {
                    arg.iNamSX = int.Parse(spinNamSX.EditValue.ToString());
                }
                if (txtXuatXu.EditValue!=null)
                {
                    arg.sXuatXu = MT.Library.Utility.AddChar(txtXuatXu.EditValue.ToString().Trim());
                }

                if (txtsMaVach.EditValue!=null)
                {
                    arg.sMaVach =MT.Library.Utility.AddChar(txtsMaVach.EditValue.ToString().Trim());
                }
                if (cboTrangThai.GetValue()!=null)
                {
                    arg.iTrangThai = (int)cboTrangThai.GetValue();
                }
                if (cboTreeDonViSuDung.EditValue != null)
                {
                    arg.sDM_DonVi_Id_Nhap = Guid.Parse(cboTreeDonViSuDung.EditValue.ToString());
                }
                if (txtGhiChu.EditValue != null)
                {
                    arg.sGhiChu = txtGhiChu.EditValue.ToString();
                }
                grdMaster.FirstView.ShowLoadingPanel();
                bgTimKiem.RunWorkerAsync(arg);
            }

        }
        #endregion

        #region"Event"
        /// <summary>
        /// Nhầm tìm kiếm lọc theo mã vạch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindData();
        }

        private void txtsMaVach_EditValueChanged(object sender, EventArgs e)
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
                 FindData();
             }));
        }

        private void frmAdvancedSearch_Load(object sender, EventArgs e)
        {
            InitForm();

            FindData();
        }

        private void txtsMaVach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindData();
            }
        }


        private void bgTimKiem_DoWork(object sender, DoWorkEventArgs e)
        {
            var p = e.Argument as ArgumentTimKiemHangHoaNangCao;
            DataSet ds= DBContext.GetRep2<SoKhoRepository>().TimKiemSanPhamNangCao(p);
            e.Result = ds?.Tables.Count > 0 ? ds.Tables[0] : null;
        }

        private void bgTimKiem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            grdMaster.FirstView.HideLoadingPanel();
            grdMaster.DataSource = e.Result;
            if (e.Error != null)
            {
                CommonFnUI.HandleException(e.Error);
            }
        }

        private void bgExportData_DoWork(object sender, DoWorkEventArgs e)
        {
            var p = e.Argument as ArgumentTimKiemHangHoaNangCao;
            DataSet ds = DBContext.GetRep2<SoKhoRepository>().TimKiemSanPhamNangCao(p);
            //todo
            using (IUnitOfWork unitOfWork = new MT.Library.UW.UnitOfWork(MT.Library.SessionData.ConnectString))
            {
                //0. Create Rep
                var rep = MT.Data.FactoryReport.Create(unitOfWork, $"TimKiemHangHoaNangCaoRepository");
                //1. Tạo header excel                
                var configExcel = new ConfigExcel();
                //2. Lưu dữ liệu vào excel

                if (!System.IO.Directory.Exists("Temp"))
                {
                    System.IO.Directory.CreateDirectory("Temp");
                }
                string pathFileName = $@"Temp\{SysDateTime.Instance.Now().ToString("ddMMyyyyhhmmss")}.xls";

                List<HeaderTable> headerTables = new List<HeaderTable>();
                HashSet<string> hsCols = new HashSet<string>();

                foreach (MGridColumn item in grdMaster.FirstView.Columns)
                {
                    if (!item.Visible)
                    {
                        continue;
                    }
                    hsCols.Add(item.FieldName);
                    var header = new HeaderTable { DataIndex = item.FieldName, HeaderText = item.Caption, Width = item.Width };
                    headerTables.Add(header);
                    if(item.ColumnEdit!=null && item.ColumnEdit is RepositoryItemMemoEdit)
                    {
                        header.IsHtmlDraw = true;
                    }

                }
                configExcel.HeaderTables = headerTables;
                configExcel.HeaderPositionIndex = 1;
                configExcel.IsFixedHeight = false;
                //Gán lại thứ tự các cột
                configExcel.ShowColumnsOrder = hsCols;
                rep.CreateExcel(pathFileName);
                var excelFile = rep.CreateReport(configExcel, pathFileName, ds);

                excelFile.Save(pathFileName);

                e.Result = pathFileName;
            }
        }

        private void bgExportData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            string path;
            if (result == DialogResult.OK)
            {
                path = folderDlg.SelectedPath;

                string downloadPath = System.IO.Path.Combine(path, $"{DateTime.Now.ToString("ddMMyyyyHHmmss")}.xls");
                System.IO.File.Copy(e.Result.ToString(), downloadPath, true);

                //3. Open file excel
                MTLib.Utility.OpenFile(e.Result.ToString());

            }

        }

     

        private void btnExport_Click(object sender, EventArgs e)
        {
            string sMaVach = txtsMaVach.Text;
            if (!string.IsNullOrWhiteSpace(sMaVach) && MT.Library.Utility.CheckForSQLInjection(sMaVach))
            {
                MMessage.ShowError($"Mã vạch <{sMaVach}> không được chưa các ký tự đặc biệt");
                return;
            }
            string sMaSanPham = Convert.ToString(txtMaSanPham.EditValue);
            if (!string.IsNullOrWhiteSpace(sMaSanPham) && MT.Library.Utility.CheckForSQLInjection(sMaSanPham))
            {
                MMessage.ShowError($"Mã sản phẩm <{sMaSanPham}> không được chưa các ký tự đặc biệt");
                return;
            }

            string xuatXu = Convert.ToString(txtXuatXu.EditValue);
            if (!string.IsNullOrWhiteSpace(xuatXu) && MT.Library.Utility.CheckForSQLInjection(xuatXu))
            {
                MMessage.ShowError($"Xuất xứ <{xuatXu}> không được chưa các ký tự đặc biệt");
                return;
            }

            string sGhiChu = Convert.ToString(txtGhiChu.EditValue);
            if (!string.IsNullOrWhiteSpace(sGhiChu) && MT.Library.Utility.CheckForSQLInjection(sGhiChu))
            {
                MMessage.ShowError($"Ghi chú <{sGhiChu}> không được chưa các ký tự đặc biệt");
                return;
            }

            if (!bgExportData.IsBusy)
            {
                var arg = new ArgumentTimKiemHangHoaNangCao
                {
                    sMaSanPham = Convert.ToString(txtMaSanPham.EditValue)
                };

                if (cboTenSanPham.EditValue != null)
                {
                    arg.sDM_SanPham_Id = Guid.Parse(cboTenSanPham.EditValue.ToString());
                }
                if (cboMangLienLac.EditValue != null)
                {
                    arg.sDM_MangLienLac_Id = Guid.Parse(cboMangLienLac.EditValue.ToString());
                }
                if (spinNamSX.EditValue != null && !string.IsNullOrWhiteSpace(spinNamSX.Text))
                {
                    arg.iNamSX = int.Parse(spinNamSX.EditValue.ToString());
                }
                if (txtXuatXu.EditValue != null)
                {
                    arg.sXuatXu = MT.Library.Utility.AddChar(txtXuatXu.EditValue.ToString().Trim());
                }

                if (txtsMaVach.EditValue != null)
                {
                    arg.sMaVach = MT.Library.Utility.AddChar(txtsMaVach.EditValue.ToString().Trim());
                }
                if (cboTrangThai.GetValue() != null)
                {
                    arg.iTrangThai = (int)cboTrangThai.GetValue();
                }
                if (cboTreeDonViSuDung.EditValue != null)
                {
                    arg.sDM_DonVi_Id_Nhap = Guid.Parse(cboTreeDonViSuDung.EditValue.ToString());
                }
                if (txtGhiChu.EditValue != null)
                {
                    arg.sGhiChu = txtGhiChu.EditValue.ToString();
                }
                bgExportData.RunWorkerAsync(arg);
            }
        }
        #endregion


    }
}
