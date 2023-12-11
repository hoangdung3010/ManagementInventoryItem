using DevExpress.DataAccess.DataFederation;
using DevExpress.XtraEditors.Repository;
using FormUI.Args;
using MT.Data.BO;
using MT.Data.Rep;
using MT.Data.ViewModels;
using MT.Library.Extensions;
using MT.Library.UW;
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
    public partial class frmGeneratorMaVach : FormUI.FormUIBase
    {
        List<SinhMaVach> sinhMaVaches = new List<SinhMaVach>();
        public frmGeneratorMaVach()
        {
            InitializeComponent();

            InitForm();
        }

        private void InitForm()
        {
            grdMaVach.AddColumnText("sMaVach", "Mã vạch", "Mã vạch", 180, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            grdMaVach.AddColumnText("sMaNhaCungCap","Mã NCC", "Mã nhà cung cấp", 80);
            grdMaVach.AddColumnText("sTenNhaCungCap", "Tên nhà cung cấp", 200);
            grdMaVach.AddColumnText("sMaSanPham","Mã SP", "Mã sản phẩm", 80);
            grdMaVach.AddColumnText("sTenSanPham", "Tên sản phẩm", 200);
            grdMaVach.AddColumnText("iNamSX", "Năm sản xuất", 100);
        }

        private void InitDefaultValue()
        {
            var now = SysDateTime.Instance.Now();
            string value=2 >= now.ToString().Length ? now.Year.ToString() : now.Year.ToString().Substring(now.Year.ToString().Length - 2);
            txtNamSX.EditValue = value;
            txtSoBatDau.EditValue = "00001";

            cboNCC.AddColumn("sMaNCC", "Mã nhà cung cấp", 150);
            cboNCC.AddColumn("sTenNCC", "Tên nhà cung cấp", 200);
            cboNCC.Properties.DisplayMember = "sMaNCC";
            cboNCC.Properties.ValueMember = "sMaNCC";
            cboNCC.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_NhaCCRepository>()
                .GetData(typeof(MT.Data.BO.DM_NhaCC), "sMaNCC,sTenNCC", orderBy: "sMaNCC");

            cboSP.AddColumn("sMaSanPham", "Mã sản phẩm", 150);
            cboSP.AddColumn("sTenSanPham", "Tên sản phẩm", 200);
            cboSP.Properties.DisplayMember = "sMaSanPham";
            cboSP.Properties.ValueMember = "sMaSanPham";
            cboSP.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>()
                .GetData(typeof(MT.Data.BO.DM_SanPham), "sMaSanPham,sTenSanPham", orderBy: "sMaSanPham"); 

        }

        private void frmGeneratorMaVach_Load(object sender, EventArgs e)
        {
            InitDefaultValue();
        }

        /// <summary>
        /// Thực hiện sinh mã vạch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerator_Click(object sender, EventArgs e)
        {
            ArgCfgSinhMaVach argCfgSinhMaVach = new ArgCfgSinhMaVach();

            /*
            * Mã vạch gồm 15 số (Nguồn(1) -->Nhà cung cấp (1)--> Mã nhóm trang bị (2) --> Mã sản phẩm (4) --> Số series (5) -->năm sx (2))
            */

            //1. Nguồn(1)
            if (txtNguon.EditValue == null 
                || txtNguon.EditValue.ToString().Trim().Length != 1
                || !int.TryParse(txtNguon.EditValue.ToString().Trim(), out var iNguon))
            {
                MMessage.ShowWarning("Nguồn không hợp lệ. Nguồn phải là số và chỉ có 1 chữ số");
                ActiveControl = txtNguon;
                return;
            }
            argCfgSinhMaVach.iNguon = iNguon;

            //2. Nhà cung cấp (1)
            if (cboNCC.EditValue == null
                || cboNCC.EditValue.ToString().Trim().Length != 1
                || !int.TryParse(cboNCC.EditValue.ToString().Trim(), out var iNhaCungCap))
            {
                MMessage.ShowWarning("Nhà cung cấp không hợp lệ. Nhà cung cấp phải là số và chỉ có 1 chữ số");
                ActiveControl = cboNCC;
                return;
            }
            argCfgSinhMaVach.iNhaCungCap = iNhaCungCap;

            string sTenNhaCungCap = ((List<MT.Data.BO.DM_NhaCC>)DBContext.GetRep<MT.Data.Rep.DM_NhaCCRepository>()
                .GetData(typeof(MT.Data.BO.DM_NhaCC), "sTenNCC", where: $"sMaNCC='{iNhaCungCap}'")).FirstOrDefault()?.sTenNCC;
            argCfgSinhMaVach.sTenNhaCungCap = sTenNhaCungCap;

            //2. Mã nhóm trang bị (2)
            if (txtMaNhomTrangThietBi.EditValue == null
                || txtMaNhomTrangThietBi.EditValue.ToString().Trim().Length != 2
                || !int.TryParse(txtMaNhomTrangThietBi.EditValue.ToString().Trim(), out var iMaNhomTrangThietBi))
            {
                MMessage.ShowWarning("Mã nhóm trang thiết bị không hợp lệ. Mã nhóm trang thiết bị phải là số và chỉ có 2 chữ số");
                ActiveControl = txtMaNhomTrangThietBi;
                return;
            }
            argCfgSinhMaVach.sMaNhomTrangThietBi = iMaNhomTrangThietBi.ToString().PadLeft(2,'0');

            //Mã sản phẩm (4)
            if (cboSP.EditValue == null
                || cboSP.EditValue.ToString().Trim().Length != 4
                || !int.TryParse(cboSP.EditValue.ToString().Trim(), out var iMaSanPham))
            {
                MMessage.ShowWarning("Mã sản phẩm không hợp lệ. Mã sản phẩm phải là số và chỉ có 4 chữ số");
                ActiveControl = cboSP;
                return;
            }
            argCfgSinhMaVach.sMaSanPham = iMaSanPham.ToString().PadLeft(4, '0');

            string sTenNhaSP = ((List<MT.Data.BO.DM_SanPham>)DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>()
                .GetData(typeof(MT.Data.BO.DM_SanPham), "sTenSanPham", where: $"sMaSanPham='{argCfgSinhMaVach.sMaSanPham}'")).FirstOrDefault()?.sTenSanPham;
            argCfgSinhMaVach.sTenSanPham = sTenNhaSP;

            //Số series bắt đầu(5)
            if (txtSoBatDau.EditValue == null
                || txtSoBatDau.EditValue.ToString().Trim().Length != 5
                || !int.TryParse(txtSoBatDau.EditValue.ToString().Trim(), out var iSoBatDau))
            {
                MMessage.ShowWarning("Số serial bắt đầu không hợp lệ. Số serial bắt đầu là số và chỉ có 5 chữ số");
                ActiveControl = txtSoBatDau;
                return;
            }
            argCfgSinhMaVach.sSoBatDau = iSoBatDau.ToString().PadLeft(5, '0');


            //Số series kết thúc(5)
            if (txtSoKetThuc.EditValue == null
                || txtSoKetThuc.EditValue.ToString().Trim().Length != 5
                || !int.TryParse(txtSoKetThuc.EditValue.ToString().Trim(), out var iSoKetThuc))
            {
                MMessage.ShowWarning("Số serial kết thúc không hợp lệ. Số serial kết thúc là số và chỉ có 5 chữ số");
                ActiveControl = txtSoKetThuc;
                return;
            }
            argCfgSinhMaVach.sSoKetThuc = iSoKetThuc.ToString().PadLeft(5, '0');
            if (iSoKetThuc< iSoBatDau)
            {
                MMessage.ShowWarning("Số serial kết thúc không được nhỏ hơn số bắt đầu");
                ActiveControl = txtSoKetThuc;
                return;
            }

            if (txtNamSX.EditValue == null
              || txtNamSX.EditValue.ToString().Trim().Length != 2
              || !int.TryParse(txtNamSX.EditValue.ToString().Trim(), out var iNamSX))
            {
                MMessage.ShowWarning("Năm sản xuất không hợp lệ. Chỉ lấy 2 số cuối của năm sản xuất");
                ActiveControl = txtNamSX;
                return;
            }

            argCfgSinhMaVach.sNam = iNamSX.ToString().PadLeft(2, '0');

            if (!bgWorkerSinhMaVach.IsBusy)
            {
                bgWorkerSinhMaVach.RunWorkerAsync(argCfgSinhMaVach);
            }
        }

        private void bgWorkerSinhMaVach_DoWork(object sender, DoWorkEventArgs e)
        {
            ArgCfgSinhMaVach argCfgSinhMaVach = e.Argument as ArgCfgSinhMaVach;
            sinhMaVaches = new List<SinhMaVach>();

            int iSoBatDau = int.Parse(argCfgSinhMaVach.sSoBatDau);

            int iSoKetThuc = int.Parse(argCfgSinhMaVach.sSoKetThuc);

            for (int i = iSoBatDau; i <= iSoKetThuc; i++)
            {
                string sSerial = $"{i}".PadLeft(5, '0');
                string sNamSX = argCfgSinhMaVach.sNam;
                string sMaVach = $"{argCfgSinhMaVach.iNguon}{argCfgSinhMaVach.iNhaCungCap}{argCfgSinhMaVach.sMaNhomTrangThietBi}{argCfgSinhMaVach.sMaSanPham}{sSerial}{sNamSX}";
                sinhMaVaches.Add(new SinhMaVach
                {
                    sMaVach = sMaVach,
                    sMaNhaCungCap = argCfgSinhMaVach.iNhaCungCap.ToString(),
                    sTenNhaCungCap=argCfgSinhMaVach.sTenNhaCungCap,
                    sMaSanPham = argCfgSinhMaVach.sMaSanPham,
                    sTenSanPham=argCfgSinhMaVach.sTenSanPham,
                    iNamSX = int.Parse($"20{sNamSX}")
                }); ;
            }

            e.Result = sinhMaVaches;
        }

        private void bgWorkerSinhMaVach_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                grdMaVach.DataSource = e.Result;

            }
            else
            {
                grdMaVach.DataSource = null;
                MMessage.ShowError("Sinh mã vạch thất bại");
            }
            
        }

        private void bgExport_DoWork(object sender, DoWorkEventArgs e)
        {

            var dt = sinhMaVaches.ToDataTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            //todo
            using (IUnitOfWork unitOfWork = new MT.Library.UW.UnitOfWork(MT.Library.SessionData.ConnectString))
            {
                //0. Create Rep
                var rep = MT.Data.FactoryReport.Create(unitOfWork, $"SinhMaVachCaoRepository");
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

                foreach (MGridColumn item in grdMaVach.FirstView.Columns)
                {
                    if (!item.Visible)
                    {
                        continue;
                    }
                    hsCols.Add(item.FieldName);

                    var header = new HeaderTable { DataIndex = item.FieldName, HeaderText = item.Caption, Width = item.Width };
                    headerTables.Add(header);
                    if (item.ColumnEdit != null && item.ColumnEdit is RepositoryItemMemoEdit)
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

        private void bgExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            if (sinhMaVaches == null || sinhMaVaches.Count==0)
            {
                MMessage.ShowWarning("Không tồn tại mã vạch nào trên danh sách. Vui lòng thiết lập lại cấu hình sinh mã vạch");
                return;
            }

            if (!bgExport.IsBusy)
            {
                bgExport.RunWorkerAsync();
            }
        }
    }
}
