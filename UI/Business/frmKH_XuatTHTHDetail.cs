using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using MT.Data;
using MT.Data.BO;
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
    public partial class frmKH_XuatTHTHDetail : FormUI.MFormBusinessDetail
    {
        private DM_DonViRepository dM_DonViRepository;

        public frmKH_XuatTHTHDetail()
        {
            InitializeComponent();
            // Note 14.6 to load from label click
            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<KH_XuatTHTHRepository>(),
                    EntityName = "KH_XuatTHTH",
                    Title = "Kế hoạch xuất thu hồi"
                };
            }

            GrdDetails = new Dictionary<string, MTControl.MGridEditable>
            {
                {"KH_XuatTHTH_CT",grdSanPham }
            };
            this.ControlTepDinhKem = ucTepDinhKem1;
            InitRep();
            InitLookup();
            InitGrid();
        }

        #region"Sub/Func"

        /// <summary>
        /// Khởi tạo đối tượng kết nối db
        /// </summary>
        private void InitRep()
        {
            dM_DonViRepository = (DM_DonViRepository)DBContext.GetRep<MT.Data.Rep.DM_DonViRepository>();
        }

        /// <summary>
        /// Khởi tạo giá trị combo
        /// </summary>
        private void InitLookup()
        {
            treesDM_DonVi_Id_DonViXayDungKH.Properties.DisplayMember = "sTenDonvi";
            treesDM_DonVi_Id_DonViXayDungKH.Properties.ValueMember = "Id";
            var treeList = treesDM_DonVi_Id_DonViXayDungKH.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            treesDM_DonVi_Id_DonViXayDungKH.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            treesDM_DonVi_Id_DonViXayDungKH.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);

            var donviXayDungKH = dM_DonViRepository.GetDonViConCap1VaDonViCungCap(MT.Library.SessionData.OrganizationUnitId);

            treesDM_DonVi_Id_DonViXayDungKH.Properties.DataSource = donviXayDungKH;
            treesDM_DonVi_Id_DonViXayDungKH.AliasFormQuickAdd = "DM_DonVi";

            var dsCanBo = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                  columns: "Id,sMaCanBo,sTenCanBo", orderBy: "sMaCanBo");

            // Nguoi Lap KH
            cbosDM_CanBo_Id_NguoiLapKH.Properties.DisplayMember = "sTenCanBo"; // NOTE
            cbosDM_CanBo_Id_NguoiLapKH.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiLapKH.AddColumn("sTenCanBo", "Tên", 180, true);
            /*cbosDM_CanBo_Id_NguoiLapKH.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id,sMaCanBo,sTenCanBo", where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}'", orderBy: "sMaCanBo"); // NOTE*/
            cbosDM_CanBo_Id_NguoiLapKH.Properties.DataSource = dsCanBo;

            cbosDM_CanBo_Id_NguoiLapKH.AliasFormQuickAdd = "DM_CanBo";// NOTE

            // Nguoi duyet
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiDuyet.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiDuyet.AddColumn("sTenCanBo", "Tên", 180, true);
            /*cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id,sMaCanBo,sTenCanBo", where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' and (sDM_ChucVu_Id='A0AF0133-54AB-435D-823B-3DF1C10D72C8'or sDM_ChucVu_Id='903EB1D0-B73D-4FF2-AD69-8B81D1A2A22A')", orderBy: "sMaCanBo");*/
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = dsCanBo;
            cbosDM_CanBo_Id_NguoiDuyet.AliasFormQuickAdd = "DM_CanBo";// NOTE

            // Thu truong don vi
            cbosDM_CanBo_Id_ThuTruongDonVi.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_ThuTruongDonVi.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_ThuTruongDonVi.AddColumn("sTenCanBo", "Tên", 180, true);
            /*cbosDM_CanBo_Id_ThuTruongDonVi.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id,sMaCanBo,sTenCanBo", where: $"Id= (select Id from DM_CanBo where sDM_DonVi_Id in (select sParentId from DM_DonVi where Id='{MT.Library.SessionData.OrganizationUnitId}'))", orderBy: "sMaCanBo");*/
            cbosDM_CanBo_Id_ThuTruongDonVi.Properties.DataSource = dsCanBo;
            cbosDM_CanBo_Id_ThuTruongDonVi.AliasFormQuickAdd = "DM_CanBo"; // NOTE

            // Don vi Xuat
            treesDM_DonVi_Id_DonViXuat.Properties.DisplayMember = "sTenDonvi";
            treesDM_DonVi_Id_DonViXuat.Properties.ValueMember = "Id";
            treeList = treesDM_DonVi_Id_DonViXuat.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            treesDM_DonVi_Id_DonViXuat.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            treesDM_DonVi_Id_DonViXuat.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);

            var donviXuat = dM_DonViRepository.GetDonViConCap1VaDonViCungCap(MT.Library.SessionData.OrganizationUnitId);

            treesDM_DonVi_Id_DonViXuat.Properties.DataSource = donviXuat;
            treesDM_DonVi_Id_DonViXuat.AliasFormQuickAdd = "DM_DonVi";

            // Don vi nhap
            treesDM_DonVi_Id_DonViNhap.Properties.DisplayMember = "sTenDonvi";
            treesDM_DonVi_Id_DonViNhap.Properties.ValueMember = "Id";
            treeList = treesDM_DonVi_Id_DonViNhap.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            treesDM_DonVi_Id_DonViNhap.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            treesDM_DonVi_Id_DonViNhap.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);

            var donviNhap = dM_DonViRepository.GetDonViConCap1VaDonViCungCap(MT.Library.SessionData.OrganizationUnitId);

            treesDM_DonVi_Id_DonViNhap.Properties.DataSource = donviNhap;
            treesDM_DonVi_Id_DonViNhap.AliasFormQuickAdd = "DM_DonVi";

            cboEnumiDonViThoiGianHieuLuc.EnumData = "iDonViThoiGianHieuLuc";
            //cboEnumiLoaiKeHoach.EnumData = "iLoaiKH";
            //cboiTrangThaiDuyet.EnumData = "iTrangThaiDuyetKHNM";
        }

        /// <summary>
        /// Khởi tạo thông tin grid
        ///// </summary>
        private void InitGrid()
        {
            // Note giờ phải check tồn kho chứ không lấy chung chung
            //List<MT.Data.BO.DM_SanPham> dm_SanPhams = (List<DM_SanPham>)GhiSoKho.GetSanPhamTonTrongKho(MT.Library.SessionData.OrganizationUnitId);
            //if (dm_SanPhams == null || dm_SanPhams.Count <= 0)
            //{
            //    MMessage.ShowWarning($"Không còn sản phẩm nào trong kho");
            //}
            var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham),
                 "Id,sMaSanPham,sTenSanPham,sDM_NhomSanPham_Id_Ten", viewName: "View_DM_SanPham", orderBy: "sDM_NhomSanPham_Id_Ten,sMaSanPham");

            var dm_DonViTinhs = DBContext.GetRep<MT.Data.Rep.DM_DonViTinhRepository>().GetData(typeof(MT.Data.BO.DM_DonViTinh), "Id,sTenDonViTinh", orderBy: "SortOrder");
            //var dm_DonViTinhs = DBContext.GetRep<MT.Data.Rep.DM_DonViTinhRepository>().GetData(typeof(MT.Data.BO.DM_DonViTinh), "Id,sTenDonViTinh", orderBy: "SortOrder");
            //Sản phẩm
            grdSanPham.GrdDetail.TableName = "KH_XuatTHTH_CT";
            grdSanPham.GrdDetail.ViewName = "View_KH_XuatTHTH_CT";
            grdSanPham.GrdDetail.KeyName = "Id";
            grdSanPham.GrdDetail.SetField = "kH_XuatTHTH_CTs";
            grdSanPham.GrdDetail.FirstView.OptionsNavigation.EnterMoveNextColumn = true;
            grdSanPham.GrdDetail.DisableFieldNames = @"sDM_SanPham_Id_Ten,rThanhTien,dHanBaoHanhDen";

            grdSanPham.GrdDetail.ValidEditValueChanging = grdSanPham_ValidEditValueChanging;
            grdSanPham.IsRequired = true;
            grdSanPham.InvalidText = "Danh sách sản phẩm không được bỏ trống";
            //grdSanPham.GrdDetail.FuncCustomRecordBeforeAddRow = GridSanPham_FuncCustomRecordBeforeAddRow;

            // Tên sản phẩm
            var col = grdSanPham.GrdDetail.AddColumnText("sDM_SanPham_Id", "Tên sản phẩm", 250, isFixWidth: true,
               fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left,
               dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);
            MRepositoryItemLookUpEdit colsDM_SanPham_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_SanPham_Id.DictionaryName = "DM_SanPham";
            colsDM_SanPham_Id.AddColumn("sMaSanPham", "Mã sản phẩm", 120);
            colsDM_SanPham_Id.AddColumn("sTenSanPham", "Tên sản phẩm", 180);
            colsDM_SanPham_Id.AddColumn("sDM_NhomSanPham_Id_Ten", "Nhóm sản phẩm", 180);
            colsDM_SanPham_Id.DataSource = dm_SanPhams;
            colsDM_SanPham_Id.DisplayMember = "sTenSanPham";
            colsDM_SanPham_Id.ValueMember = "Id";
            colsDM_SanPham_Id.BestFitMode = BestFitMode.BestFitResizePopup;

            //// Mạng LL
            col = grdSanPham.GrdDetail.AddColumnText("sDM_MangLienLac_Id", "Mạng liên lạc", 150, isFixWidth: true,
               //fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left,
               dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);

            MRepositoryItemLookUpEdit colsDM_MangLL_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_MangLL_Id.DictionaryName = "DM_MangLienLac";
            //colsDM_MangLL_Id.AddColumn("sMaMangLienLac", "Mã mạng liên lạc", 120);
            colsDM_MangLL_Id.AddColumn("sTenMangLienLac", "Tên mạng liên lạc", 180);
            colsDM_MangLL_Id.DataSource = DBContext.GetRep<MT.Data.Rep.DM_MangLienLacRepository>().GetData(typeof(MT.Data.BO.DM_MangLienLac), "Id,sTenMangLienLac", orderBy: "SortOrder"); ;
            colsDM_MangLL_Id.DisplayMember = "sTenMangLienLac";
            colsDM_MangLL_Id.ValueMember = "Id";

            // Đơn vị tính
            col = grdSanPham.GrdDetail.AddColumnText("sDM_DonViTinh_Id", "Đơn vị tính", 150, dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);

            MRepositoryItemLookUpEdit colsDM_DonViTinh_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_DonViTinh_Id.DictionaryName = "DM_DonViTinh";
            colsDM_DonViTinh_Id.AddColumn("sTenDonViTinh", "Tên đơn vị tính", 180);
            colsDM_DonViTinh_Id.DataSource = dm_DonViTinhs;
            colsDM_DonViTinh_Id.DisplayMember = "sTenDonViTinh";
            colsDM_DonViTinh_Id.ValueMember = "Id";

            //var colsSerial = grdSanPham.GrdDetail.AddColumnText("sSerial", "Số Serial", 150,
            //    dataType: MTControl.DataTypeColumn.CheckedComboBox);

            //grdSanPham.GrdDetail.AddColumnText("sCauHinhKyThuat", "Cấu hình kỹ thuật", 180, maxLength: 255);

            //grdSanPham.GrdDetail.AddColumnText("sXuatXu", "Xuất xứ", 180, maxLength: 255);

            //grdSanPham.GrdDetail.AddColumnText("iNamSX", "Năm sản xuất", 80, dataType: DataTypeColumn.SpinEdit);

            //grdSanPham.GrdDetail.AddColumnText("iThoiGianBaoHanh", "T.gian BH", toolTip: "Thời gian bảo hành", 80,
            //    dataType: DataTypeColumn.SpinEdit, isRequired: true);

            //var coliDonViThoiGianBaoHanh = grdSanPham.GrdDetail.AddColumnText("iDonViThoiGianBaoHanh",
            //    "Đơn vị t.gian BH", toolTip: "Đơn vị thời gian bảo hành", 80, dataType: DataTypeColumn.ComboBox, isRequired: true);
            //MRepositoryComboBox mRepositoryComboBox = (MRepositoryComboBox)coliDonViThoiGianBaoHanh.ColumnEdit;
            //mRepositoryComboBox.EnumData = "iDonViThoiGianHieuLuc";

            //grdSanPham.GrdDetail.AddColumnText("dHanBaoHanhDen", "Hạn bảo hành", 100, dataType: DataTypeColumn.DateEdit, isRequired: true);

            //grdSanPham.GrdDetail.AddColumnText("sGhiChu", "Ghi chú", 250, maxLength: 255);

            grdSanPham.GrdDetail.AddColumnText("rSoLuong", "Số lượng", 150, dataType: MTControl.DataTypeColumn.SpinEdit);
            grdSanPham.GrdDetail.AddColumnText("rDonGia", "Đơn giá", 150, dataType: MTControl.DataTypeColumn.SpinEdit);
            grdSanPham.GrdDetail.AddColumnText("rThanhTien", "Thành tiền", 150, dataType: MTControl.DataTypeColumn.SpinEdit);
            grdSanPham.GrdDetail.AddColumnText("sXuatXu", "Xuất xứ", 150, maxLength: 255);
            grdSanPham.GrdDetail.AddColumnText("sGhiChu", "Ghi chú", 200, maxLength: 255);

            col = grdSanPham.GrdDetail.AddColumnText("Id", "Hành động", 100, dataType: MTControl.DataTypeColumn.Button,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);

            MRepositoryItemButtonEdit colsAction = (MRepositoryItemButtonEdit)col.ColumnEdit;
            colsAction.TextEditStyle = TextEditStyles.HideTextEditor;
            colsAction.Buttons.Clear();
            var editorButton = new EditorButton(ButtonPredefines.Glyph, "Phụ kiện", 80, true, true, false, null);
            editorButton.Appearance.ForeColor = Color.White;
            editorButton.AppearanceHovered.ForeColor = Color.Black;
            editorButton.AppearancePressed.ForeColor = Color.Black;
            colsAction.Buttons.Add(editorButton);
            colsAction.ButtonClick += ColsActionPhuKien_ButtonClick;
        }

        #endregion
        #region"Event"

        private void frmDM_SanPhamDetail_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Validate giá trị trước khi gán cho grid
        /// </summary>
        /// <param name="gridColumn"></param>
        /// <param name="e"></param>
        /// <returns>=true cho gán,ngược lại ko cho gán</returns>
        private bool grdSanPham_ValidEditValueChanging(DevExpress.XtraGrid.Columns.GridColumn gridColumn, ChangingEventArgs e)
        {
            if (gridColumn.FieldName == "sSerial" && e.NewValue != null && !object.Equals(e.OldValue, e.NewValue))
            {
                string[] arrSerial = e.NewValue.ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                KH_XuatTHTH_CT kH_XuatTHTH = grdSanPham.GrdDetail.GetRecordByRowSelected<KH_XuatTHTH_CT>();
                if (arrSerial.Length > 0 && (decimal)arrSerial.Length > kH_XuatTHTH.rSoLuong)
                {
                    e.NewValue = string.Empty;
                    MMessage.ShowWarning($"Bạn chỉ được phép chọn tối đa {(int)kH_XuatTHTH.rSoLuong} số serial");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Click hiển thị form nhập chi tiết phụ kiện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColsActionPhuKien_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            // NOTEEEEEEEEEEEEEEEE
            //Bắt bắt chọn sản phẩm roh thì mới cho nhập phụ kiện
            var kH_XuatTHTH_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<KH_XuatTHTH_CT>();
            if (kH_XuatTHTH_CT.sDM_SanPham_Id.HasValue && !kH_XuatTHTH_CT.sDM_SanPham_Id.Value.Equals(Guid.Empty))
            {
                frmPhuKienDetail frmPhuKienDetail = new frmPhuKienDetail(kH_XuatTHTH_CT.sDM_SanPham_Id.Value,
                     "KH_XuatTHTH_CT_PhuKien", "kH_XuatTHTH_CT_PhuKiens", kH_XuatTHTH_CT, this);
                frmPhuKienDetail.ShowDialog();
            }
            else
            {
                MMessage.ShowWarning("Bạn phải chọn sản phẩm trước khi nhập thông tin chi tiết phụ kiện");
            }
        }

        #endregion

        #region"Overrides"

        // NOTEEEEEEEEEEEEEEEEEEEEEEEEEEEE
        /// <summary>
        /// Thiết lập các tham số trước khi in
        /// </summary>
        /// <param name="configExcel"></param>
        /// <param name="configReport"></param>
        protected override void SetConfigBeforePrint(MT.Data.BO.ConfigExcel configExcel, ConfigReport configReport)
        {
            base.SetConfigBeforePrint(configExcel, configReport);
            //Đối tượng xử lý nghiệp vụ IN
            configReport.RepName = "Print_KH_XuatTHTH_DetailRepository";
            //Định danh mẫu in trong bảng ReportData
            configReport.DictionaryKey = MT.Data.ReportDictionaryKey.RP_Print_KHXuatTHTH_Detail;

            //Danh sách các cột trên table
            configExcel.ShowColumnsOrder = new HashSet<string>
            {
                "sSTT","sDM_SanPham_Id_Ten","sDM_DonViTinh_Id_Ten","rSoLuong",
                "sXuatXu","iThoiGianBaoHanh"
            };
        }

        /// <summary>
        /// Valid dữ liệu trước khi lưu
        /// </summary>
        /// <param name="mGridEditable"></param>
        /// <param name="dataChanged"></param>
        /// <returns></returns>
        protected override bool IsValidateDataChangedGridDetail(MGridEditable mGridEditable, System.Collections.IList dataChanged)
        {
            var isValid = base.IsValidateDataChangedGridDetail(mGridEditable, dataChanged);
            if (isValid && dataChanged != null)
            {
                List<MT.Data.BO.KH_XuatTHTH_CT> kH_XuatTHTH_CTs = mGridEditable.GrdDetail.GetAllData<MT.Data.BO.KH_XuatTHTH_CT>();

                foreach (var item in dataChanged)
                {
                    var castItem = (MT.Data.BO.KH_XuatTHTH_CT)item;
                    // Truong 2022
                    KH_XuatTHTH_CT findBysID = kH_XuatTHTH_CTs.Find(m => m.sDM_SanPham_Id.Equals(castItem.sDM_SanPham_Id) && m.Id != castItem.Id);
                    if (findBysID != null)
                    {
                        MMessage.ShowWarning($"Sản phẩm <{castItem.sDM_SanPham_Id_Ten}> đang bị lặp nhiều lần, cần gộp chung lại!");
                        isValid = false;
                        break;
                    }
                    // end Truong2022
                    DM_DonViTinh dM_DonViTinh = DBContext.GetRep2<DM_DonViTinhRepository>()
                                                        .GetDataByID<DM_DonViTinh>("DM_DonViTinh", castItem.sDM_DonViTinh_Id, "sTenDonViTinh");

                    //1.Cột số lượng và đơn giá, thời gian bảo hành phải luôn lớn >0
                    if (isValid && castItem.rSoLuong <= 0)
                    {
                        isValid = false;
                        mGridEditable.GrdDetail.FirstView.FocusedColumn = mGridEditable.GrdDetail.FirstView.Columns["rSoLuong"];
                        mGridEditable.GrdDetail.FirstView.FocusedRowHandle = castItem.RowHandle;
                        MMessage.ShowWarning($"Sản phẩm <{castItem.sDM_SanPham_Id_Ten}>, đơn vị tính <{dM_DonViTinh.sTenDonViTinh}> số lượng nhập phải luôn lớn hơn 0");
                        break;
                    }

                    if (isValid && castItem.rDonGia <= 0)
                    {
                        isValid = false;
                        mGridEditable.GrdDetail.FirstView.FocusedColumn = mGridEditable.GrdDetail.FirstView.Columns["rDonGia"];
                        mGridEditable.GrdDetail.FirstView.FocusedRowHandle = castItem.RowHandle;
                        MMessage.ShowWarning($"Sản phẩm <{castItem.sDM_SanPham_Id_Ten}>, đơn vị tính <{dM_DonViTinh.sTenDonViTinh}> đơn giá nhập phải luôn lớn hơn 0");
                        break;
                    }
                    //2. Với SP có đơn vị tính cấp 2 thì bắt buộc phải chọn số serial
                    //var dM_SanPham = DBContext.GetRep2<DM_SanPhamRepository>().GetDataByID<DM_SanPham>("DM_SanPham", castItem.sDM_SanPham_Id, "sDM_DonViTinh_Id_Cap1,sDM_DonViTinh_Id_Cap2,iKichThuocDongGoi");
                    //if (isValid && dM_SanPham != null
                    //    && dM_SanPham.sDM_DonViTinh_Id_Cap2.HasValue
                    //    && object.Equals(castItem.sDM_DonViTinh_Id, dM_SanPham.sDM_DonViTinh_Id_Cap2.Value)
                    //    && dM_SanPham.iKichThuocDongGoi > 0
                    //    && string.IsNullOrWhiteSpace(castItem.sSerial))
                    //{
                    //    isValid = false;
                    //    mGridEditable.GrdDetail.FirstView.FocusedColumn = mGridEditable.GrdDetail.FirstView.Columns["sSerial"];
                    //    mGridEditable.GrdDetail.FirstView.FocusedRowHandle = castItem.RowHandle;
                    //    MMessage.ShowWarning($"Bạn phải chọn số serial cho sản phẩm <{castItem.sDM_SanPham_Id_Ten}>, đơn vị tính <{dM_DonViTinh.sTenDonViTinh}>");
                    //    break;
                    //}

                    ////3. Cột mã vạch không được trùng nhau
                    //if (isValid && kH_XuatSanPham_CTs != null && kH_XuatSanPham_CTs.Count > 0)
                    //{
                    //    //Kiểm tra mã vạch có bị trùng hay không
                    //    MT.Data.BO.KH_XuatSanPham_CT findBysMaVach = kH_XuatSanPham_CTs.Find(m => m.sMaVach.Equals(castItem.sMaVach) && m.Id != castItem.Id);
                    //    if (findBysMaVach != null)
                    //    {
                    //        isValid = false;
                    //        mGridEditable.GrdDetail.FirstView.FocusedColumn = mGridEditable.GrdDetail.FirstView.Columns["sMaVach"];
                    //        mGridEditable.GrdDetail.FirstView.FocusedRowHandle = castItem.RowHandle;
                    //        MMessage.ShowWarning($"Mã vạch <{castItem.sMaVach}> của sản phẩm <{castItem.sDM_SanPham_Id_Ten}>, đơn vị tính <{dM_DonViTinh.sTenDonViTinh}> đã tồn tại");
                    //        break;
                    //    }
                    //}
                }
            }
            return isValid;
        }

        /// <summary>
        /// Custom lại cell của grid
        /// </summary>
        /// <param name="mGridControl"></param>
        /// <param name="e"></param>
        protected override void CustomRowCellGridDetail(MGridControl mGridControl, RepositoryItem repository, CustomRowCellEditEventArgs e)
        {
            base.CustomRowCellGridDetail(mGridControl, repository, e);
            switch (mGridControl.TableName)
            {
                case "KH_XuatTHTH_CT":
                    if (e.Column.FieldName == "sSerial")
                    {
                        //gán mặc định đơn vị tính cấp 1 cho sản phẩm
                        DM_SanPhamRepository dM_SanPhamRepository = DBContext.GetRep2<DM_SanPhamRepository>();
                        DM_SanPham dM_SanPham = null;
                        object sDM_SanPham_Id = mGridControl.FirstView.GetRowCellValue(e.RowHandle, "sDM_SanPham_Id");
                        object sDM_DonViTinh_Id = mGridControl.FirstView.GetRowCellValue(e.RowHandle, "sDM_DonViTinh_Id");
                        decimal rSoLuong = (decimal)mGridControl.FirstView.GetRowCellValue(e.RowHandle, "rSoLuong");
                        dM_SanPham = dM_SanPhamRepository.GetDataByID<DM_SanPham>("DM_SanPham", sDM_SanPham_Id, "sDM_DonViTinh_Id_Cap1,sDM_DonViTinh_Id_Cap2,iKichThuocDongGoi");
                        MRepositoryItemCheckedComboBox mRepositoryItemChecked = (MRepositoryItemCheckedComboBox)repository;

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
                    }
                    if (e.Column.FieldName == "sDM_SanPham_Id")
                    {
                        MRepositoryItemLookUpEdit repositoryItemLookUpEdit = (MRepositoryItemLookUpEdit)repository;
                        object sDM_Donvi_Id = treesDM_DonVi_Id_DonViXuat.GetValue();// this.CurrentData.GetValue("sDM_DonVi_Id_DonViXuat");
                        List<MT.Data.BO.DM_SanPham> dm_SanPhams = (List<DM_SanPham>)GhiSoKho.GetSanPhamTonTrongKho((Guid)sDM_Donvi_Id);
                        if (dm_SanPhams == null || dm_SanPhams.Count <= 0)
                        {
                            MMessage.ShowWarning($"Không còn sản phẩm nào trong kho");
                            repositoryItemLookUpEdit.DataSource = null;
                        }
                        else
                        {
                            repositoryItemLookUpEdit.DataSource = dm_SanPhams;
                        }
                    }
                    // Noteeeeeeeee
                    //if (e.Column.FieldName == "sDM_DonViTinh_Id")
                    //{
                    //    var sDMSanPhamId = mGridControl.FirstView.GetRowCellValue(e.RowHandle, "sDM_SanPham_Id");
                    //    MRepositoryItemLookUpEdit mRepositoryItemLookUp = (MRepositoryItemLookUpEdit)repository;
                    //    if (sDMSanPhamId != null)
                    //    {
                    //        mRepositoryItemLookUp.DataSource = DBContext.GetRep2<DM_SanPhamRepository>().GetDonViTinhCuaSanPham(Guid.Parse(sDMSanPhamId.ToString()));
                    //    }
                    //    else
                    //    {
                    //        mRepositoryItemLookUp.DataSource = null;
                    //    }
                    //}
                    if (e.Column.FieldName == "sDM_Kho_Id_Nhap")
                    {
                        object sDM_Donvi_Id = mGridControl.FirstView.GetRowCellValue(e.RowHandle, "sDM_DonVi_Id_DonViNhap");
                        MRepositoryItemLookUpEdit mRepositoryItemLookUpEdit = (MRepositoryItemLookUpEdit)repository;
                        string where = string.Empty;
                        if (sDM_Donvi_Id != null && !sDM_Donvi_Id.ToString().Equals(Guid.Empty.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            mRepositoryItemLookUpEdit.DataSource = DBContext.GetRep<MT.Data.Rep.DM_DonViRepository>().GetData(typeof(MT.Data.BO.DM_Kho),
                           "Id,sTenKho", where: $"sDM_Donvi_Id='{sDM_Donvi_Id}'");
                        }
                        else
                        {
                            mRepositoryItemLookUpEdit.DataSource = null;
                        }
                    }
                    if (e.Column.FieldName == "sDM_Kho_Id_Xuat")
                    {
                        //MT.Data.BO.KH_XuatTHTH curMaster = (MT.Data.BO.KH_XuatTHTH)this.CurrentData;
                        object sDM_Donvi_Id = treesDM_DonVi_Id_DonViXuat.GetValue();// this.CurrentData.GetValue("sDM_DonVi_Id_DonViXuat");
                        //object sDM_Donvi_Id = mGridControl.FirstView.GetRowCellValue(e.RowHandle, "sDM_DonVi_Id_DonViXuat");
                        MRepositoryItemLookUpEdit mRepositoryItemLookUpEdit = (MRepositoryItemLookUpEdit)repository;
                        string where = string.Empty;
                        if (sDM_Donvi_Id != null && !sDM_Donvi_Id.ToString().Equals(Guid.Empty.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            mRepositoryItemLookUpEdit.DataSource = DBContext.GetRep<MT.Data.Rep.DM_DonViRepository>().GetData(typeof(MT.Data.BO.DM_Kho),
                           "Id,sTenKho", where: $"sDM_Donvi_Id='{sDM_Donvi_Id}'");
                        }
                        else
                        {
                            mRepositoryItemLookUpEdit.DataSource = null;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Thực hiện bắt event tính tổng tiền trên grid chi tiết  TT=rDonGia*SL
        /// </summary>
        /// <param name="mGridControl"></param>
        /// <param name="e"></param>
        protected override void CustomRowCellValueChangedGridDetail(MGridControl mGridControl, CellValueChangedEventArgs e)
        {
            base.CustomRowCellValueChangedGridDetail(mGridControl, e);

            switch (mGridControl.TableName)
            {
                case "KH_XuatTHTH_CT":
                    KH_XuatTHTH_CT kH_XuatTHTH_CT = mGridControl.GetRecordByRowSelected<KH_XuatTHTH_CT>();
                    if (e.Column.FieldName == "sDM_SanPham_Id")
                    {
                        // Truong2022
                        List<MT.Data.BO.KH_XuatTHTH_CT> kH_XuatTHTH_CTs = grdSanPham.GrdDetail.GetAllData<MT.Data.BO.KH_XuatTHTH_CT>();
                        KH_XuatTHTH_CT findBysID = kH_XuatTHTH_CTs.Find(m => m.sDM_SanPham_Id.Equals(kH_XuatTHTH_CT.sDM_SanPham_Id) && m.Id != kH_XuatTHTH_CT.Id);
                        if (findBysID != null)
                        {
                            MMessage.ShowWarning($"Sản phẩm <{findBysID.sDM_SanPham_Id_Ten}> đã tồn tại");
                        }
                        // end Truong2022

                        //gán mặc định đơn vị tính cấp 1 cho sản phẩm
                        DM_SanPhamRepository dM_SanPhamRepository = DBContext.GetRep2<DM_SanPhamRepository>();
                        DM_SanPham dM_SanPham = null;
                        if (e.Value != null)
                        {
                            dM_SanPham = dM_SanPhamRepository.GetDataByID<DM_SanPham>("DM_SanPham", e.Value, "sDM_DonViTinh_Id_Cap1,rDonGia_Cap1");
                        }
                        if (dM_SanPham != null)
                        {
                            kH_XuatTHTH_CT.sDM_DonViTinh_Id = dM_SanPham.sDM_DonViTinh_Id_Cap1;
                            kH_XuatTHTH_CT.rSoLuong = 1;
                            kH_XuatTHTH_CT.rDonGia = dM_SanPham.rDonGia_Cap1;
                            kH_XuatTHTH_CT.rThanhTien = dM_SanPham.rDonGia_Cap1;
                            //Gán mặc định phụ kiện theo sản phẩm
                            if (!kH_XuatTHTH_CT.IsLoaded && kH_XuatTHTH_CT.MTEntityState == Enummation.MTEntityState.Add)
                            {
                                var phukiensCuaSanPham = (List<DM_PhuKien>)DBContext.GetRep2<DM_PhuKienRepository>()
                                                                .GetData(typeof(DM_PhuKien), "Id,sDM_SanPham_Id,sDM_DonViTinh_Id,rSoLuong,rDonGia"
                                                                , where: $"sDM_SanPham_Id='{kH_XuatTHTH_CT.sDM_SanPham_Id.Value}'"
                                                                , orderBy: "SortOrder");
                                List<KH_XuatTHTH_CT_PhuKien> phukienCuaKeHoachNhapMoi = new List<KH_XuatTHTH_CT_PhuKien>();
                                if (phukiensCuaSanPham != null)
                                {
                                    foreach (var item in phukiensCuaSanPham)
                                    {
                                        phukienCuaKeHoachNhapMoi.Add(new KH_XuatTHTH_CT_PhuKien
                                        {
                                            Id = Guid.NewGuid(),
                                            rSoLuongPhuKienTren1SP = item.rSoLuong,
                                            rSoLuong = kH_XuatTHTH_CT.rSoLuong * item.rSoLuong,
                                            MTEntityState = Enummation.MTEntityState.Add,
                                            sDM_DonViTinh_Id = item.sDM_DonViTinh_Id,
                                            sDM_PhuKien_Id = item.Id,
                                            rDonGia = item.rDonGia,
                                            rThanhTien = kH_XuatTHTH_CT.rSoLuong * item.rSoLuong * item.rDonGia,
                                            sDM_SanPham_Id = item.sDM_SanPham_Id
                                        });
                                    }
                                }
                                kH_XuatTHTH_CT.kH_XuatTHTH_CT_PhuKiens = phukienCuaKeHoachNhapMoi;
                            }
                        }

                        mGridControl.FirstView.SetRowCellValue(e.RowHandle, "sDM_DonViTinh_Id", dM_SanPham.sDM_DonViTinh_Id_Cap1);

                        mGridControl.FirstView.SetRowCellValue(e.RowHandle, "rSoLuong", 1);

                        mGridControl.FirstView.SetRowCellValue(e.RowHandle, "rDonGia", dM_SanPham.rDonGia_Cap1);

                        //gán mặc định đơn vị tính cấp 1 cho sản phẩm
                        if (mGridControl.FuncCustomRecordBeforeAddRow != null)
                        {
                            mGridControl.FuncCustomRecordBeforeAddRow(kH_XuatTHTH_CT, mGridControl);
                        }
                    }
                    if (e.Column.FieldName == "sDM_DonViTinh_Id")
                    {
                        if (e.Value != null)
                        {
                            DM_SanPhamRepository dM_SanPhamRepository = DBContext.GetRep2<DM_SanPhamRepository>();
                            DM_SanPham dM_SanPham = null;
                            //Nếu chọn đơn vị tính cấp 2 thì lấy giá của đơn vị tính cấp 2
                            dM_SanPham = dM_SanPhamRepository.GetDataByID<DM_SanPham>("DM_SanPham",
                                mGridControl.FirstView.GetRowCellValue(e.RowHandle, "sDM_SanPham_Id"),
                                "sDM_DonViTinh_Id_Cap1,sDM_DonViTinh_Id_Cap2,rDonGia_Cap1,rDonGia_Cap2");

                            if (dM_SanPham != null)
                            {
                                if (Guid.Parse(e.Value.ToString()) == dM_SanPham.sDM_DonViTinh_Id_Cap1.Value)
                                {
                                    mGridControl.FirstView.SetRowCellValue(e.RowHandle, "rDonGia", dM_SanPham.rDonGia_Cap1);
                                }
                                else if (dM_SanPham.sDM_DonViTinh_Id_Cap2.HasValue && Guid.Parse(e.Value.ToString()) == dM_SanPham.sDM_DonViTinh_Id_Cap2.Value)
                                {
                                    mGridControl.FirstView.SetRowCellValue(e.RowHandle, "rDonGia", dM_SanPham.rDonGia_Cap2);
                                }
                            }
                        }
                    }
                    if (e.Column.FieldName == "rSoLuong" || e.Column.FieldName == "rDonGia")
                    {
                        kH_XuatTHTH_CT.rThanhTien = kH_XuatTHTH_CT.rSoLuong * kH_XuatTHTH_CT.rDonGia;
                    }
                    if (e.Column.FieldName == "sSerial")
                    {
                        object objsSerial = e.Value;
                        if (objsSerial != null)
                        {
                            string[] arrSerial = objsSerial.ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (arrSerial.Length >= 1)
                            {
                                kH_XuatTHTH_CT.rSoLuong = arrSerial.Length;
                            }
                        }
                    }
                    var now = SysDateTime.Instance.Now();
                    if (e.Column.FieldName == "iThoiGianBaoHanh" || e.Column.FieldName == "iDonViThoiGianBaoHanh")
                    {
                        DateTime? dHanBaoHanhDen = null;
                        switch (kH_XuatTHTH_CT.iDonViThoiGianBaoHanh)
                        {
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Ngay:
                                dHanBaoHanhDen = now.AddDays(kH_XuatTHTH_CT.iThoiGianBaoHanh).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Thang:
                                dHanBaoHanhDen = now.AddMonths(kH_XuatTHTH_CT.iThoiGianBaoHanh).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Quy:
                                dHanBaoHanhDen = now.AddYears(kH_XuatTHTH_CT.iThoiGianBaoHanh * 3).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Nam:
                                dHanBaoHanhDen = now.AddYears(kH_XuatTHTH_CT.iThoiGianBaoHanh).AddDays(1);
                                break;
                        }
                        kH_XuatTHTH_CT.dHanBaoHanhDen = dHanBaoHanhDen;
                    }

                    // Noteeeeeeeee
                    //if (e.Column.FieldName == "sDM_SanPham_Id")
                    //{
                    //    //gán mặc định đơn vị tính cấp 1 cho sản phẩm
                    //    DM_SanPhamRepository dM_SanPhamRepository = DBContext.GetRep2<DM_SanPhamRepository>();
                    //    DM_SanPham dM_SanPham = null;
                    //    if (e.Value != null)
                    //    {
                    //        dM_SanPham = dM_SanPhamRepository.GetDataByID<DM_SanPham>("DM_SanPham", e.Value, "sDM_DonViTinh_Id_Cap1,rDonGia_Cap1");
                    //    }
                    //    if (dM_SanPham != null)
                    //    {
                    //        mGridControl.FirstView.SetRowCellValue(e.RowHandle, "sDM_DonViTinh_Id", dM_SanPham.sDM_DonViTinh_Id_Cap1);

                    //        mGridControl.FirstView.SetRowCellValue(e.RowHandle, "rSoLuong", 1);

                    //        mGridControl.FirstView.SetRowCellValue(e.RowHandle, "rDonGia", dM_SanPham.rDonGia_Cap1);
                    //    }
                    //}

                    //if (e.Column.FieldName == "rSoLuong" || e.Column.FieldName == "rDonGia")
                    //{
                    //    var kH_XuatTHTH_CT = mGridControl.GetRecordByRowSelected<KH_XuatTHTH_CT>();
                    //    mGridControl.FirstView.SetRowCellValue(e.RowHandle, "rThanhTien", kH_XuatTHTH_CT.rSoLuong * kH_XuatTHTH_CT.rDonGia);
                    //}

                    break;
            }
        }

        /// <summary>
        /// Thực hiện thiết lập mode control theo action
        /// </summary>
        protected override void SetViewModeControlByFromAction()
        {
            base.SetViewModeControlByFromAction();

            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:
                    //txtsLyDoDuyet.SetReadOnly(true);
                    treesDM_DonVi_Id_DonViXayDungKH.SetReadOnly(false);
                    break;

                default:
                    treesDM_DonVi_Id_DonViXayDungKH.SetReadOnly(true);
                    break;
            }
            cbosDM_CanBo_Id_NguoiLapKH.SetReadOnly(true);
        }

        /// <summary>
        /// Xử lý dữ liệu trước khi binding lên form
        /// </summary>
        /// <returns></returns>
        protected override BaseEntity PrepareDataBeforeBindDataForm()
        {
            var currentData = (KH_XuatTHTH)base.PrepareDataBeforeBindDataForm();

            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:
                    currentData.iThoiGianHieuLuc = 60;
                    currentData.dNgayKeHoach = SysDateTime.Instance.Now();
                    //currentData.iLoaiKH = (int)iLoaiKH.ct;
                    currentData.iDonViThoiGianHieuLuc = (int)iDonViThoiGianHieuLuc.Ngay;
                    currentData.sDM_DonVi_Id_DonViXayDungKH = MT.Library.SessionData.OrganizationUnitId;
                    currentData.sDM_DonVi_Id_DonViXuat = MT.Library.SessionData.OrganizationUnitId;
                    currentData.sDM_CanBo_Id_NguoiLapKH = MT.Library.SessionData.UserId;
                    break;
            }
            return currentData;
        }

        #endregion

        private void cboiTrangThaiDuyet_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (this.FormAction != (int)MTControl.FormAction.View)
            {
                int vVal = (int)cboiTrangThaiDuyet.GetValue();
                switch (vVal)
                {
                    case (int)MT.Data.iTrangThaiDuyetPNM.ChoDuyet:
                        txtsLyDoDuyet.SetReadOnly(true);
                        break;

                    case (int)MT.Data.iTrangThaiDuyetPNM.DongYDuyet:
                        txtsLyDoDuyet.SetReadOnly(false);
                        break;

                    case (int)MT.Data.iTrangThaiDuyetPNM.TuChoiDuyet:
                        txtsLyDoDuyet.SetReadOnly(false);
                        break;
                }
            }*/
        }

        /// <summary>
        /// Sau khi binding giá trị xong thì xử lý tiếp
        /// </summary>
        protected override void BindingDataIntoFormSucces()
        {
            base.BindingDataIntoFormSucces();

            //Lấy danh sách tham chiếu
            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.Edit:
                case (int)MTControl.FormAction.View:
                    ucThamChieuPhieuNhapMoi.sObjectId = Guid.Parse(this.CurrentData.GetIdentity().ToString());
                    ucThamChieuPhieuNhapMoi.sTenBangCanCu = "KH_XuatTHTH";
                    ucThamChieuPhieuNhapMoi.LoadData();
                    break;
            }
        }

        private void treesDM_DonVi_Id_DonViXuat_QueryPopUp(object sender, CancelEventArgs e)
        {
        }

        private void cbosDM_CanBo_Id_NguoiDuyet_QueryPopUp(object sender, CancelEventArgs e)
        {
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
           //columns: "Id,sMaCanBo,sTenCanBo", where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' and (sDM_ChucVu_Id='A0AF0133-54AB-435D-823B-3DF1C10D72C8'or sDM_ChucVu_Id='903EB1D0-B73D-4FF2-AD69-8B81D1A2A22A')", orderBy: "sMaCanBo");
           columns: "Id,sMaCanBo,sTenCanBo",
           viewName: "View_DM_CanBo",
           where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' and iDictionaryKey IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong})",
           orderBy: "sMaCanBo");
        }

        private void cbosDM_CanBo_Id_ThuTruongDonVi_QueryPopUp(object sender, CancelEventArgs e)
        {
            /*cbosDM_CanBo_Id_ThuTruongDonVi.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                   columns: "Id,sMaCanBo,sTenCanBo", where: $"Id= (select Id from DM_CanBo where sDM_DonVi_Id in (select sParentId from DM_DonVi where Id='{MT.Library.SessionData.OrganizationUnitId}'))",
                   orderBy: "sMaCanBo");*/

            string chucVu = $" AND iDictionaryKey IN({ (int)MT.Data.iChucVu.TruongPhong},{ (int)MT.Data.iChucVu.PhoTruongPhong},{ (int)MT.Data.iChucVu.PhoCucTruong},{ (int)MT.Data.iChucVu.CucTruong})";
            cbosDM_CanBo_Id_ThuTruongDonVi.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                    columns: "Id,sMaCanBo,sTenCanBo",
                    where: $"Id in (select Id from View_DM_CanBo where sDM_DonVi_Id in (select sParentId from DM_DonVi where Id='{MT.Library.SessionData.OrganizationUnitId}') {chucVu})", orderBy: "sMaCanBo");
        }
    }
}