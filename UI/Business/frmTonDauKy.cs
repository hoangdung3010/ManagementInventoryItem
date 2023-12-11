using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using MT.Data;
using MT.Data.BO;
using MT.Data.Rep;
using MT.Library.BO;
using MT.Library.Extensions;
using MTControl;
using System;
using System.Collections;
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
    public partial class frmTonDauKy : FormUI.FormUIBase
    {
        public frmTonDauKy()
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

            var donvis= (List<DM_DonVi>)DBContext.GetRep2<DM_DonViRepository>().GetData(typeof(DM_DonVi), viewName: "View_DM_DonVi", orderBy: "sMaDonvi");
            treesDM_DonVi_Id_DonVi.Properties.DataSource = donvis;
        }

        /// <summary>
        /// Khởi tạo các cột trên grid
        /// </summary>
        /// Create by: dvthang:07.03.2017
        private void InitGrid()
        {
            grd.IsRequired = true;
            grd.GrdDetail.KeyName = "Id";
            grd.GrdDetail.TableName = "SoKho";
            grd.GrdDetail.FirstView.OptionsNavigation.EnterMoveNextColumn = true;
            grd.GrdDetail.DisableFieldNames = @"sDM_SanPham_Id,sDM_SanPham_Id_Ten,iNamSX,rSoLuong_Nhap,dHanBaoHanhDen,sSerial";
            grd.GrdDetail.CustomRowCellEditing = new EventHandler<DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs>(gridControlCustomRowCellEdit);
            grd.GrdDetail.FirstView.CellValueChanged -= FirstView_CellValueChanged;
            grd.GrdDetail.FirstView.CellValueChanged += FirstView_CellValueChanged;
            grd.GrdDetail.FuncCustomRecordBeforeAddRow = grd_FuncCustomRecordBeforeAddRow;
            var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham), "Id,sMaSanPham,sTenSanPham", orderBy: "SortOrder");

            var dm_DonViTinhs = DBContext.GetRep<MT.Data.Rep.DM_DonViTinhRepository>().GetData(typeof(MT.Data.BO.DM_DonViTinh), "Id,sTenDonViTinh", orderBy: "SortOrder");

            var col = grd.GrdDetail.AddColumnText("sMaVach", "Mã vạch", 130, maxLength: 50,
                 fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left, isRequired: true);

            MRepositoryTextEdit colsMaVach = (MRepositoryTextEdit)col.ColumnEdit;
            colsMaVach.CustomEventEnter = grd_ColsMaVach_CustomEventEnter;

            col = grd.GrdDetail.AddColumnText("sDM_SanPham_Id", "Mã sản phẩm", 120, isFixWidth: true,
               fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left,
               dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);


            MRepositoryItemLookUpEdit colsDM_SanPham_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_SanPham_Id.AddColumn("sMaSanPham", "Mã sản phẩm", 120);
            colsDM_SanPham_Id.AddColumn("sTenSanPham", "Tên sản phẩm", 180);
            colsDM_SanPham_Id.DataSource = dm_SanPhams;
            colsDM_SanPham_Id.DisplayMember = "sMaSanPham";
            colsDM_SanPham_Id.ValueMember = "Id";

            col = grd.GrdDetail.AddColumnText("sDM_SanPham_Id_Ten", "Tên sản phẩm", 200, isRequired: true);

            col = grd.GrdDetail.AddColumnText("sDM_DonViTinh_Id", "Đơn vị tính", 100,
                dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);

            MRepositoryItemLookUpEdit colsDM_DonViTinh_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_DonViTinh_Id.AddColumn("sTenDonViTinh", "Tên đơn vị tính", 180);
            colsDM_DonViTinh_Id.DataSource = dm_DonViTinhs;
            colsDM_DonViTinh_Id.DisplayMember = "sTenDonViTinh";
            colsDM_DonViTinh_Id.ValueMember = "Id";

            grd.GrdDetail.AddColumnText("rSoLuong_Nhap", "Số lượng", 80, dataType: MTControl.DataTypeColumn.SpinEdit);

            grd.GrdDetail.AddColumnText("rThanhTien_Nhap", "Giá trị tồn", 120, dataType: MTControl.DataTypeColumn.SpinEdit);

            //// Mạng LL
            col = grd.GrdDetail.AddColumnText("sDM_MangLienLac_Id", "Mạng liên lạc", 150,
               dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: false);

            MRepositoryItemLookUpEdit colsDM_MangLL_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_MangLL_Id.DictionaryName = "DM_MangLienLac";
            colsDM_MangLL_Id.AddColumn("sTenMangLienLac", "Tên mạng liên lạc", 180);
            colsDM_MangLL_Id.DataSource = DBContext.GetRep<MT.Data.Rep.DM_MangLienLacRepository>().GetData(typeof(MT.Data.BO.DM_MangLienLac), "Id,sTenMangLienLac", orderBy: "SortOrder"); ;
            colsDM_MangLL_Id.DisplayMember = "sTenMangLienLac";
            colsDM_MangLL_Id.ValueMember = "Id";

            ///Chứng thư số
            col = grd.GrdDetail.AddColumnText("sDM_ChungThuSo_Id", "Mã CTS", toolTip: "Mã chứng thư số", 150,
              dataType: MTControl.DataTypeColumn.LookUpEdit);

            MRepositoryItemLookUpEdit colsDM_ChungThuSo_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_ChungThuSo_Id.DictionaryName = "DM_ChungThuSo";
            colsDM_ChungThuSo_Id.AddColumn("sMaCTS", "Mã CTS", 120);
            colsDM_ChungThuSo_Id.DataSource = DBContext.GetRep<MT.Data.Rep.DM_ChungThuSoRepository>()
                .GetData(typeof(MT.Data.BO.DM_ChungThuSo), "Id,sMaCTS", orderBy: "sMaCTS"); ;
            colsDM_ChungThuSo_Id.DisplayMember = "sMaCTS";
            colsDM_ChungThuSo_Id.ValueMember = "Id";

            var colsSerial = grd.GrdDetail.AddColumnText("sSerial", "Số Serial", 150);
            grd.GrdDetail.AddColumnText("sSTTSP", "STT Sản phẩm", 100,
                dataType: MTControl.DataTypeColumn.CheckedComboBox);

            grd.GrdDetail.AddColumnText("sCauHinhKyThuat", "Cấu hình kỹ thuật", 180, maxLength: 255);

            grd.GrdDetail.AddColumnText("sXuatXu", "Xuất xứ", 180, maxLength: 255);

            grd.GrdDetail.AddColumnText("iNamSX", "Năm sản xuất", 80, dataType: DataTypeColumn.SpinEdit);

            grd.GrdDetail.AddColumnText("iThoiGianBaoHanh", "T.gian BH", toolTip: "Thời gian bảo hành", 80,
               dataType: DataTypeColumn.SpinEdit, isRequired: true);

            var coliDonViThoiGianBaoHanh = grd.GrdDetail.AddColumnText("iDonViThoiGianBaoHanh",
                "Đơn vị t.gian BH", toolTip: "Đơn vị thời gian bảo hành", 80, dataType: DataTypeColumn.ComboBox, isRequired: true);
            MRepositoryComboBox mRepositoryComboBox = (MRepositoryComboBox)coliDonViThoiGianBaoHanh.ColumnEdit;
            mRepositoryComboBox.EnumData = "iDonViThoiGianHieuLuc";

            grd.GrdDetail.AddColumnText("dHanBaoHanhDen", "Hạn bảo hành", 100, dataType: DataTypeColumn.DateEdit, isRequired: true);

            grd.GrdDetail.AddColumnText("sGhiChu", "Ghi chú", 250, maxLength: 255);

            var coliNhapVeKho=grd.GrdDetail.AddColumnText("iNhapVeKho", "Hình thức nhập", "Hình thức nhập", 120, dataType: DataTypeColumn.ComboBox, isRequired: true, fixedStyle:DevExpress.XtraGrid.Columns.FixedStyle.Right);
            MRepositoryComboBox mRepositoryNhapVeKho = (MRepositoryComboBox)coliNhapVeKho.ColumnEdit;
            mRepositoryNhapVeKho.EnumData = "iNhapVeKho";
        }

        /// <summary>
        /// Bắt event enter trên ô mã vạch
        /// </summary>
        /// <param name="mRepositoryTextEdit">Đối tượng trên grid</param>
        /// <param name="mTextEdit"></param>
        /// <returns>true: Cho phép custom, ngược lại không</returns>
        private bool grd_ColsMaVach_CustomEventEnter(MRepositoryTextEdit mRepositoryTextEdit, MTextEdit mTextEdit)
        {
            //0002(Mã NCC) 0004(Mã SP) 00007(series) 21(Năm)
            if (mTextEdit.EditValue != null)
            {
                try
                {
                    string sMaVach = mTextEdit.EditValue.ToString();
                    if (!MT.Library.Utility.ValidsMaVach(sMaVach))
                    {
                        MMessage.ShowWarning("Mã vạch không hợp lệ");
                        return true;
                    }
                    SoKho soKho = grd.GrdDetail.GetRecordByRowSelected<SoKho>();
                    //Kiểm tra mã vạch có bị nhập trùng không
                    List<SoKho> soKhos = grd.GrdDetail.GetAllData<SoKho>();
                    if(soKhos.Find(s=>s.Id!=soKho.Id && s.sMaVach== sMaVach)!=null)
                    {
                        MMessage.ShowWarning($"Mã vạch <{sMaVach}> đã tồn tại trên danh sách.");
                        return true;
                    }

                    //Kiểm tra nếu mã vạch đã tồn tại bên phiếu nhập mới thì không cho nhập
                    SoKho skTrongPNhapMoi = DBContext.GetRep2<SoKhoRepository>().FindSoKhoBysMaVachAndPhieuNhapMoi(sMaVach);

                    if (skTrongPNhapMoi != null && !string.IsNullOrWhiteSpace(skTrongPNhapMoi.sMa))
                    {
                        MMessage.ShowWarning($"Mã vạch <{sMaVach}> đã tồn tại trên phiếu nhập mới <{skTrongPNhapMoi.sMa}>.");
                        return true;
                    }

                    var convertMaVachToObject = CommonFnUI.ConvertsMaVachToObject(sMaVach);
                    string sMaNCC = convertMaVachToObject.sNhaCungCap;
                    string sMaSP = convertMaVachToObject.sMaSanPham;
                    string sSerial = convertMaVachToObject.sSoSeries + "/";
                    sSerial += convertMaVachToObject.sNam;
                    int iNamSX = int.Parse($"20{convertMaVachToObject.sNam}");

                    soKho.sSerial = sSerial;
                    soKho.sSTTSP = string.Empty;

                    IList dM_SanPhams = DBContext.GetRep2<DM_SanPhamRepository>().GetData(typeof(DM_SanPham),
                        columns: "Id,sDM_DonViTinh_Id_Cap1,sTenSanPham,sMaSanPham",
                        where: $"sMaSanPham='{sMaSP}'", viewName: "View_DM_SanPham");
                    if (dM_SanPhams != null && dM_SanPhams.Count > 0)
                    {
                        DM_SanPham dM_SanPham = (DM_SanPham)dM_SanPhams[0];
                        soKho.sDM_SanPham_Id = dM_SanPham.Id;
                        soKho.sDM_SanPham_Ma = dM_SanPham.sMaSanPham;
                        soKho.sDM_DonViTinh_Id = dM_SanPham.sDM_DonViTinh_Id_Cap1;
                        soKho.sDM_SanPham_Id_Ten = dM_SanPham.sTenSanPham;
                    }
                    
                    soKho.rDonGia_Nhap = 1;
                    soKho.rDonGia_Nhap = 0;
                    soKho.iThoiGianBaoHanh = 60;
                    soKho.iDonViThoiGianBaoHanh = (int)MT.Data.iDonViThoiGianHieuLuc.Ngay;
                    soKho.iNamSX = iNamSX;
                    soKho.dHanBaoHanhDen = SysDateTime.Instance.Now().AddDays(60);

                    //Từ động thêm dòng tiếp theo
                    grd.GrdDetail.AddRow(false);
                }
                catch (Exception ex)
                {
                    CommonFnUI.HandleException(ex);
                }
            }

            return true;
        }

        /// <summary>
        /// Thực hiện load dữ liệu
        /// </summary>
        private void LoadData()
        {
            if (treesDM_DonVi_Id_DonVi.EditValue != null)
            {
                Guid orgId = Guid.Parse(treesDM_DonVi_Id_DonVi.EditValue.ToString());
                if (!bgLoadGrid.IsBusy)
                {
                    bgLoadGrid.RunWorkerAsync(orgId);
                }
            }
           
        }
        #region"Event"
       
        private void frmTonDauKy_Load(object sender, EventArgs e)
        {
            treesDM_DonVi_Id_DonVi.EditValue = MT.Library.SessionData.OrganizationUnitId;
            LoadData();
        }

        private void bgLoadGrid_DoWork(object sender, DoWorkEventArgs e)
        {
            Guid orgId =Guid.Parse(e.Argument.ToString());
            e.Result= DBContext.GetRep2<SoKhoRepository>().GetTonDauKy(orgId);
        }

        private void bgLoadGrid_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                IList datas = e.Result as IList;
                grd.GrdDetail.LoadData(datas);
                if (grd.GrdDetail.FirstView.DataRowCount == 0)
                {
                    grd.GrdDetail.AddRow();
                }
            }
            else
            {
                MMessage.ShowError(e.Error.Message);
            }
        }

        private void treesDM_DonVi_Id_DonVi_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Bắt hành động gán giá trị default cho cột grid
        /// </summary>
        /// <returns>=true cho addnewrow, ngược lại ko</returns>
        private bool grd_FuncCustomRecordBeforeAddRow(object newRecord, MGridControl mGridControl)
        {
            if (treesDM_DonVi_Id_DonVi.EditValue == null)
            {
                ActiveControl = treesDM_DonVi_Id_DonVi;
                MMessage.ShowWarning("Bạn phải chọn đơn vị nhập.");
                return false;
            }
            newRecord.SetValue("rSoLuong_Nhap", 1);
            newRecord.SetValue("iDonViThoiGianBaoHanh", 1);
            
            return true;
        }

        /// <summary>
        /// Bắt event cell của grid thay đổi giá trị
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            MGridView mGridView = (sender as MGridView);
            var grd = (MGridControl)mGridView.GridControl;
            if (!mGridView.RaiseEventCellValueChanged)
            {
                SoKho soKho = grd.GetRecordByRowSelected<SoKho>();
                switch (e.Column.FieldName)
                {
                    case "sSTTSP":
                        object objsSerial = e.Value;
                        if (objsSerial != null)
                        {
                            string[] arrSerial = objsSerial.ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (arrSerial.Length >= 1)
                            {
                                soKho.rSoLuong_Nhap = arrSerial.Length;
                            }
                        }
                        break;
                    case "iThoiGianBaoHanh":
                    case "iDonViThoiGianBaoHanh":
                        DateTime? dHanBaoHanhDen = null;
                        var now = SysDateTime.Instance.Now();
                        switch (soKho.iDonViThoiGianBaoHanh)
                        {
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Ngay:
                                dHanBaoHanhDen = now.AddDays(soKho.iThoiGianBaoHanh).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Thang:
                                dHanBaoHanhDen = now.AddMonths(soKho.iThoiGianBaoHanh).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Quy:
                                dHanBaoHanhDen = now.AddYears(soKho.iThoiGianBaoHanh * 3).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Nam:
                                dHanBaoHanhDen =now.AddYears(soKho.iThoiGianBaoHanh).AddDays(1);
                                break;
                        }
                        soKho.dHanBaoHanhDen = dHanBaoHanhDen;
                        break;
                }
            }
        }

        /// <summary>
        /// Bắt event cellediting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControlCustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            RepositoryItem repositoryItem = sender as RepositoryItem;
            if (repositoryItem.Tag!=null)
            {
                var grdControl = repositoryItem.Tag as MGridControl;
                switch (e.Column.FieldName)
                {
                    case "sSTTSP":
                        //gán mặc định đơn vị tính cấp 1 cho sản phẩm
                        DM_SanPhamRepository dM_SanPhamRepository = DBContext.GetRep2<DM_SanPhamRepository>();
                        DM_SanPham dM_SanPham = null;
                        object sDM_SanPham_Id = grdControl.FirstView.GetRowCellValue(e.RowHandle, "sDM_SanPham_Id");
                        object sDM_DonViTinh_Id = grdControl.FirstView.GetRowCellValue(e.RowHandle, "sDM_DonViTinh_Id");
                        decimal rSoLuong = 0;
                        var cellValueSoLuong = grdControl.FirstView.GetRowCellValue(e.RowHandle, "rSoLuong");
                        if (cellValueSoLuong != null)
                        {
                            decimal.TryParse(cellValueSoLuong.ToString(), out rSoLuong);
                        }
                        dM_SanPham = dM_SanPhamRepository.GetDataByID<DM_SanPham>("DM_SanPham", sDM_SanPham_Id, "sDM_DonViTinh_Id_Cap1,sDM_DonViTinh_Id_Cap2,iKichThuocDongGoi");
                        MRepositoryItemCheckedComboBox mRepositoryItemChecked = (MRepositoryItemCheckedComboBox)repositoryItem;

                        //Nếu có đơn vị tính cấp 2 và đơn vị tính bên kế hoạch nhập mới bằng chính đơn vị tính cấp 2 thì cho chọn số serial
                        if (rSoLuong > 0
                            && dM_SanPham != null
                            && dM_SanPham.sDM_DonViTinh_Id_Cap2.HasValue
                            && object.Equals(sDM_DonViTinh_Id, dM_SanPham.sDM_DonViTinh_Id_Cap2.Value)
                            && dM_SanPham.iKichThuocDongGoi > 0
                            )
                        {
                            string where = string.Empty;
                            if (sDM_SanPham_Id != null && !sDM_SanPham_Id.ToString().Equals(Guid.Empty.ToString(), StringComparison.OrdinalIgnoreCase))
                            {
                                List<string> sSerials = new List<string>();
                                for (int i = 1; i <= dM_SanPham.iKichThuocDongGoi; i++)
                                {
                                    sSerials.Add(i.ToString());
                                }
                                mRepositoryItemChecked.DataSource = sSerials;
                            }
                        }
                        else
                        {
                            mRepositoryItemChecked.DataSource = null;
                            mRepositoryItemChecked.Items.Clear();
                            mRepositoryItemChecked.ClearDataAdapter();
                        }
                        mRepositoryItemChecked.RefreshDataSource();
                        break;
                    case "sDM_DonViTinh_Id":
                        var sDMSanPhamId = grdControl.FirstView.GetRowCellValue(e.RowHandle, "sDM_SanPham_Id");
                        MRepositoryItemLookUpEdit mRepositoryItemLookUp = (MRepositoryItemLookUpEdit)repositoryItem;
                        if (sDMSanPhamId != null)
                        {
                            mRepositoryItemLookUp.DataSource = DBContext.GetRep2<DM_SanPhamRepository>().GetDonViTinhCuaSanPham(Guid.Parse(sDMSanPhamId.ToString()));
                        }
                        else
                        {
                            mRepositoryItemLookUp.DataSource = null;
                        }
                        break;
                }
             
            }
        }
        private void frmTonDauKy_Shown(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Ẩn mask khi có lỗi xảy ra
        /// </summary>
        /// Create by: dvthang:04.10.2017
        private void HideMask()
        {
            SplashScreenManager.CloseForm(false);
        }
        /// <summary>
        /// Hàm thực hiện lưu số tồn đầu kỳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (treesDM_DonVi_Id_DonVi.EditValue == null)
                {
                    ActiveControl = treesDM_DonVi_Id_DonVi;
                    MMessage.ShowWarning("Bạn phải chọn đơn vị nhập.");
                    return;
                }

                var dataChanged = grd.GrdDetail.GetDataChanges();

                if(dataChanged==null || dataChanged.Count == 0)
                {
                    MMessage.ShowWarning("Số tồn đầu kỳ chưa có phát sinh thay đổi dữ liệu.");
                    return;
                }

                if (dataChanged.Count > 0)
                {
                    if (!CommonFnUI.IsValidateDataChangedGridDetail(grd, dataChanged))
                    {
                        return;
                    }
                }

                //Kiểm tra mã vạch có bị nhập trung không
                List<SoKho> soKhos = grd.GrdDetail.GetAllData<SoKho>();
                var findsMaVachDuplicate = from r in soKhos
                         orderby r.sMaVach
                         group r by r.sMaVach into grp
                         select new { sMaVach = grp.Key, C = grp.Count() };
                if (findsMaVachDuplicate?.Count() > 0)
                {
                    foreach (var item in findsMaVachDuplicate)
                    {
                        if (item.C > 1)
                        {
                            var record = soKhos.Find(m => m.sMaVach == item.sMaVach);
                            grd.GrdDetail.SetFocusCell("sMaVach", record.RowHandle);
                            MMessage.ShowWarning($"Mã vạch <{item.sMaVach}> đã xuất hiện nhiều hơn 1 lần trên danh sách.");
                            return;
                        }
                    }
                }
                //Kiểm tra mã vạch có tồn tại trên phiếu nhập mới không
                foreach (var item in dataChanged)
                {
                    SoKho sk = item as SoKho;
                    SoKho skTrongPNhapMoi = DBContext.GetRep2<SoKhoRepository>().FindSoKhoBysMaVachAndPhieuNhapMoi(sk.sMaVach);

                    if (skTrongPNhapMoi != null && !string.IsNullOrWhiteSpace(skTrongPNhapMoi.sMa))
                    {
                        MMessage.ShowWarning($"Mã vạch <{sk.sMaVach}> đã tồn tại trên phiếu nhập mới <{skTrongPNhapMoi.sMa}>.");
                        return;
                    }
                }

                SplashScreenManager.ShowForm(this, typeof(WaitFormCustom), true, true, false);

                //Cập nhập sortorder
                for (int i = 0; i < soKhos.Count; i++)
                {
                    soKhos[i].SortOrder = i + 1;
                }
                
                bool isValid = true;
                foreach (var item in dataChanged)
                {
                    SoKho sk = item as SoKho;
                    if(sk.MTEntityState != MT.Library.Enummation.MTEntityState.Delete)
                    {
                        if (sk.sDM_MangLienLac_Id.HasValue)
                        {
                            DM_MangLienLac dM_MangLienLac = DBContext.GetRep2<DM_MangLienLacRepository>()
                                .GetDataByID<DM_MangLienLac>("DM_MangLienLac", sk.sDM_MangLienLac_Id.Value, "sTenMangLienLac");
                            if (dM_MangLienLac != null)
                            {
                                sk.sDM_MangLienLac_Id_Ten = dM_MangLienLac.sTenMangLienLac;
                            }
                        }

                        if (sk.sDM_DonViTinh_Id.HasValue)
                        {
                            DM_DonViTinh dM_DonViTinh = DBContext.GetRep2<DM_DonViTinhRepository>()
                                .GetDataByID<DM_DonViTinh>("DM_DonViTinh", sk.sDM_DonViTinh_Id.Value, "sTenDonViTinh");
                            if (dM_DonViTinh != null)
                            {
                                sk.sDM_DonViTinh_Id_Ten = dM_DonViTinh.sTenDonViTinh;
                            }
                        }
                        if (sk.sDM_ChungThuSo_Id.HasValue)
                        {
                            DM_ChungThuSo dM_ChungThuSo = DBContext.GetRep2<DM_ChungThuSoRepository>()
                                .GetDataByID<DM_ChungThuSo>("DM_ChungThuSo", sk.sDM_ChungThuSo_Id.Value, "sMaCTS");
                            if (dM_ChungThuSo != null)
                            {
                                sk.sDM_ChungThuSo_Id_Ten = dM_ChungThuSo.sMaCTS;
                            }
                        }
                       
                    }

                    sk.iLoaiPhieu = 1;
                    sk.sMa = "TDK";
                    sk.dNgayPhieu = new DateTime(1753,1,1);
                    sk.sDM_DonVi_Id = Guid.Parse(treesDM_DonVi_Id_DonVi.EditValue.ToString());
                    sk.sDM_DonVi_Id_Ten =treesDM_DonVi_Id_DonVi.Text;
                    sk.sMd5Id = Guid.Parse($"{sk.sDM_DonVi_Id.Value}{sk.sDM_SanPham_Id.Value}{sk.sDM_DonViTinh_Id.Value}".CreateMD5());
                    ResultData resultData = DBContext.GetRep2<SoKhoRepository>().SaveData(sk);
                    if (!resultData.Success)
                    {
                        isValid = false;
                        MMessage.ShowWarning($"Mã vạch <{sk.sMaVach}> đã bị lỗi");
                        break;
                    }
                    else
                    {
                        sk.MTEntityState = MT.Library.Enummation.MTEntityState.Edit;
                    }
                }

                if (isValid)
                {
                    MMessage.ShowInfor("Lưu thành công");
                }
            }
            catch (Exception ex)
            {
                HideMask();
                CommonFnUI.HandleException(ex);
            }
            finally
            {
                HideMask();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (frmImportData frmImportData = new frmImportData())
            {
                frmImportData.ImportDataType = ImportDataType.SoKho;
                frmImportData.ShowDialog();
            }
        }
        #endregion


    }
}
