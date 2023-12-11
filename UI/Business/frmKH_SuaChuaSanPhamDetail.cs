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
    public partial class frmKH_SuaChuaSanPhamDetail : FormUI.MFormBusinessDetail
    {
        DM_DonViRepository dM_DonViRepository;
        public frmKH_SuaChuaSanPhamDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<KH_SuaChuaSanPhamRepository>(),
                    EntityName = "KH_SuaChuaSanPham",
                    Title = "Kế hoạch sửa chữa sản phẩm"
                };
            }

            this.ControlTepDinhKem = ucTepDinhKem1;

            GrdDetails = new Dictionary<string, MTControl.MGridEditable>
            {
                {"KH_SuaChuaSanPham_CT",grdSanPham }
            };

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

            // Đơn vị xây dựng KH
            treesDM_DonVi_Id_DonViXayDungKH.Properties.DisplayMember = "sTenDonvi";
            treesDM_DonVi_Id_DonViXayDungKH.Properties.ValueMember = "Id";
            var treeList = treesDM_DonVi_Id_DonViXayDungKH.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            treesDM_DonVi_Id_DonViXayDungKH.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            treesDM_DonVi_Id_DonViXayDungKH.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);

            var donviXayDungKH = dM_DonViRepository.GetDonViConCap1VaDonViCungCap(MT.Library.SessionData.OrganizationUnitId);

            treesDM_DonVi_Id_DonViXayDungKH.Properties.DataSource = donviXayDungKH;


            // Đơn vị xuất
            treesDM_DonVi_Id_DonViXuat.Properties.DisplayMember = "sTenDonvi";
            treesDM_DonVi_Id_DonViXuat.Properties.ValueMember = "Id";
            var treeListDonViXuat = treesDM_DonVi_Id_DonViXuat.Properties.TreeList;
            treeListDonViXuat.KeyFieldName = "Id";
            treeListDonViXuat.ParentFieldName = "sParentId";
            treesDM_DonVi_Id_DonViXuat.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            treesDM_DonVi_Id_DonViXuat.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            treesDM_DonVi_Id_DonViXuat.Properties.DataSource = donviXayDungKH;
            treesDM_DonVi_Id_DonViXuat.AliasFormQuickAdd = "DM_DonVi";

            // Đơn vị nhập
            var donviNhapSuaChua = dM_DonViRepository.GetDonViConCap1VaDonViCungCapVaNhaCungCap(MT.Library.SessionData.OrganizationUnitId, uuTienNhaCC: false);
            treesDM_DonVi_Id_DonViNhap.Properties.DisplayMember = "sTenDonvi";
            treesDM_DonVi_Id_DonViNhap.Properties.ValueMember = "Id";
            var treeListDonViNhap = treesDM_DonVi_Id_DonViNhap.Properties.TreeList;
            treeListDonViNhap.KeyFieldName = "Id";
            treeListDonViNhap.ParentFieldName = "sParentId";
            treesDM_DonVi_Id_DonViNhap.AddColumn("sLoai", "Loại", 80);
            treesDM_DonVi_Id_DonViNhap.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            treesDM_DonVi_Id_DonViNhap.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            treesDM_DonVi_Id_DonViNhap.Properties.DataSource = donviNhapSuaChua;
            treesDM_DonVi_Id_DonViNhap.AliasFormQuickAdd = "DM_DonVi";



            var dsCanBo = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                                 columns: "Id,sMaCanBo,sTenCanBo", orderBy: "sMaCanBo");
            // Người lập KH
            cbosDM_CanBo_Id_NguoiLapKH.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiLapKH.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiLapKH.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiLapKH.Properties.DataSource = dsCanBo;

            // Người duyệt
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiDuyet.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiDuyet.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = dsCanBo;

            cbosDM_CanBo_Id_NguoiDuyet.AliasFormQuickAdd = "DM_CanBo";

            // Thủ trưởng đơn vị
            cbosDM_CanBo_Id_ThuTruongDonVi.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_ThuTruongDonVi.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_ThuTruongDonVi.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_ThuTruongDonVi.Properties.DataSource = dsCanBo;

            cbosDM_CanBo_Id_ThuTruongDonVi.AliasFormQuickAdd = "DM_CanBo";

            // Đơn vị thời gian hiệu lực
            cboEnumiDonViThoiGianHieuLuc.EnumData = "iDonViThoiGianHieuLuc";

        }

        /// <summary>
        /// Khởi tạo thông tin grid
        /// </summary>
        private void InitGrid()
        {
            var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham), "Id,sMaSanPham,sTenSanPham,sDM_NhomSanPham_Id_Ten", orderBy: "sDM_NhomSanPham_Id_Ten,sMaSanPham", viewName: "View_DM_SanPham");
            //var dm_SanPhams = GhiSoKho.GetSanPhamTonTrongKho(SessionData.OrganizationUnitId);
            var dm_DonViTinhs = DBContext.GetRep<MT.Data.Rep.DM_DonViTinhRepository>().GetData(typeof(MT.Data.BO.DM_DonViTinh), "Id,sTenDonViTinh", orderBy: "SortOrder");

            grdSanPham.GrdDetail.TableName = "KH_SuaChuaSanPham_CT";
            grdSanPham.GrdDetail.KeyName = "Id";
            grdSanPham.GrdDetail.SetField = "kH_SuaChuaSanPham_CTs";
            grdSanPham.GrdDetail.FirstView.OptionsNavigation.EnterMoveNextColumn = true;
            grdSanPham.GrdDetail.DisableFieldNames = "rThanhTien";


            // Sản phẩm
            grdSanPham.IsRequired = true;
            grdSanPham.InvalidText = "Danh sách sản phẩm không được bỏ trống";
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
            // Tình trạng hỏng hóc
            col = grdSanPham.GrdDetail.AddColumnText("sDM_TinhTrangHongHoc_Id", "Tình trạng hỏng hóc", 220, isFixWidth: true,
               //fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left,
               dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);

            MRepositoryItemLookUpEdit colsDM_TTHH_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_TTHH_Id.DictionaryName = "DM_TinhTrangHongHoc";
            colsDM_TTHH_Id.AddColumn("sTenTinhTrangHongHoc", "Tên tình trạng hỏng hóc", 200);
            colsDM_TTHH_Id.DataSource = DBContext.GetRep<MT.Data.Rep.DM_TinhTrangHongHocRepository>().GetData(typeof(MT.Data.BO.DM_TinhTrangHongHoc), "Id,sTenTinhTrangHongHoc", orderBy: "SortOrder"); ;
            colsDM_TTHH_Id.DisplayMember = "sTenTinhTrangHongHoc";
            colsDM_TTHH_Id.ValueMember = "Id";

            // Nội dung sửa chữa
            col = grdSanPham.GrdDetail.AddColumnText("sDM_NoiDungSuaChua_Id", "Nội dung sửa chữa", 220, isFixWidth: true,
               //fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left,
               dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);

            MRepositoryItemLookUpEdit colsDM_NDSC_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_NDSC_Id.DictionaryName = "DM_NoiDungSuaChua";
            colsDM_NDSC_Id.AddColumn("sTenNoiDungSuaChua", "Tên nội dung sửa chữa", 200);
            colsDM_NDSC_Id.DataSource = DBContext.GetRep<MT.Data.Rep.DM_NoiDungSuaChuaRepository>().GetData(typeof(MT.Data.BO.DM_NoiDungSuaChua), "Id,sTenNoiDungSuaChua", orderBy: "SortOrder"); ;
            colsDM_NDSC_Id.DisplayMember = "sTenNoiDungSuaChua";
            colsDM_NDSC_Id.ValueMember = "Id";


            // Đơn vị tính
            col = grdSanPham.GrdDetail.AddColumnText("sDM_DonViTinh_Id", "Đơn vị tính", 150, dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);

            MRepositoryItemLookUpEdit colsDM_DonViTinh_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_DonViTinh_Id.DictionaryName = "DM_DonViTinh";
            colsDM_DonViTinh_Id.AddColumn("sTenDonViTinh", "Tên đơn vị tính", 180);
            colsDM_DonViTinh_Id.DataSource = dm_DonViTinhs;
            colsDM_DonViTinh_Id.DisplayMember = "sTenDonViTinh";
            colsDM_DonViTinh_Id.ValueMember = "Id";

            grdSanPham.GrdDetail.AddColumnText("rSoLuong", "Số lượng", 150, dataType: MTControl.DataTypeColumn.SpinEdit);
            grdSanPham.GrdDetail.AddColumnText("rDonGia", "Đơn giá", 150, dataType: MTControl.DataTypeColumn.SpinEdit);
            grdSanPham.GrdDetail.AddColumnText("rThanhTien", "Thành tiền", 150, dataType: MTControl.DataTypeColumn.SpinEdit);
            grdSanPham.GrdDetail.AddColumnText("sXuatXu", "Xuất xứ", 200, maxLength: 255);
            grdSanPham.GrdDetail.AddColumnText("sGhiChu", "Ghi chú", 250, maxLength: 255);

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
        /// Click hiển thị form nhập chi tiết phụ kiện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColsActionPhuKien_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //Bắt bắt chọn sản phẩm roh thì mới cho nhập phụ kiện
            var kh_SuaChuaSanPham_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<KH_SuaChuaSanPham_CT>();
            if (kh_SuaChuaSanPham_CT.sDM_SanPham_Id.HasValue && !kh_SuaChuaSanPham_CT.sDM_SanPham_Id.Value.Equals(Guid.Empty))
            {
                frmPhuKienDetail frmPhuKienDetail = new frmPhuKienDetail(kh_SuaChuaSanPham_CT.sDM_SanPham_Id.Value,
                    "KH_SuaChuaSanPham_CT_PhuKien", "kH_SuaChuaSanPham_CT_PhuKiens", kh_SuaChuaSanPham_CT, this);
                frmPhuKienDetail.ShowDialog();
            }
            else
            {
                MMessage.ShowWarning("Bạn phải chọn sản phẩm trước khi nhập thông tin chi tiết phụ kiện");
            }
        }

        #endregion

        #region"Overrides"



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
                case "KH_SuaChuaSanPham_CT":
                    if (e.Column.FieldName == "sDM_DonViTinh_Id")
                    {
                        var sDMSanPhamId = mGridControl.FirstView.GetRowCellValue(e.RowHandle, "sDM_SanPham_Id");
                        MRepositoryItemLookUpEdit mRepositoryItemLookUp = (MRepositoryItemLookUpEdit)repository;
                        if (sDMSanPhamId != null)
                        {
                            mRepositoryItemLookUp.DataSource = DBContext.GetRep2<DM_SanPhamRepository>().GetDonViTinhCuaSanPham(Guid.Parse(sDMSanPhamId.ToString()));
                        }
                        else
                        {
                            mRepositoryItemLookUp.DataSource = null;
                        }
                    }
                    if (e.Column.FieldName == "sDM_SanPham_Id")
                    {
                        MRepositoryItemLookUpEdit repositoryItemLookUpEdit = (MRepositoryItemLookUpEdit)repository;
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(treesDM_DonVi_Id_DonViXuat.GetValue())))
                        {
                            Guid sDM_Donvi_Id = Guid.Parse(Convert.ToString(treesDM_DonVi_Id_DonViXuat.GetValue()));// this.CurrentData.GetValue("sDM_DonVi_Id_DonViXuat");
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
                        else
                        {
                            MMessage.ShowWarning($"Bạn phải chọn Đơn vị xuất trước");
                        }
                    }
                    break;
            }
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
                List<MT.Data.BO.KH_SuaChuaSanPham_CT> kH_SuaChuaSanPham_CTs = mGridEditable.GrdDetail.GetAllData<MT.Data.BO.KH_SuaChuaSanPham_CT>();

                foreach (var item in dataChanged)
                {
                    var castItem = (MT.Data.BO.KH_SuaChuaSanPham_CT)item;
                    // Truong 2022
                    KH_SuaChuaSanPham_CT findBysID = kH_SuaChuaSanPham_CTs.Find(m => m.sDM_SanPham_Id.Equals(castItem.sDM_SanPham_Id) && m.Id != castItem.Id);
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
                }
            }
            return isValid;
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
                case "KH_SuaChuaSanPham_CT":
                    KH_SuaChuaSanPham_CT kH_SuaChuaSanPham_CT = mGridControl.GetRecordByRowSelected<KH_SuaChuaSanPham_CT>();
                    if (e.Column.FieldName == "sDM_SanPham_Id")
                    {
                        // Truong2022
                        List<MT.Data.BO.KH_SuaChuaSanPham_CT> kH_SuaChuaSanPham_CTs = grdSanPham.GrdDetail.GetAllData<MT.Data.BO.KH_SuaChuaSanPham_CT>();
                        KH_SuaChuaSanPham_CT findBysID = kH_SuaChuaSanPham_CTs.Find(m => m.sDM_SanPham_Id.Equals(kH_SuaChuaSanPham_CT.sDM_SanPham_Id) && m.Id != kH_SuaChuaSanPham_CT.Id);
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
                            dM_SanPham = dM_SanPhamRepository.GetDataByID<DM_SanPham>("DM_SanPham", e.Value, "sDM_DonViTinh_Id_Cap1,rDonGia_Cap1,sXuatXu");
                        }
                        if (dM_SanPham != null)
                        {

                            if (dM_SanPham != null)
                            {

                                kH_SuaChuaSanPham_CT.sDM_DonViTinh_Id = dM_SanPham.sDM_DonViTinh_Id_Cap1;
                                kH_SuaChuaSanPham_CT.rSoLuong = 1;
                                kH_SuaChuaSanPham_CT.rDonGia = dM_SanPham.rDonGia_Cap1;
                                kH_SuaChuaSanPham_CT.rThanhTien = dM_SanPham.rDonGia_Cap1;
                                //Gán mặc định phụ kiện theo sản phẩm
                                if (!kH_SuaChuaSanPham_CT.IsLoaded && kH_SuaChuaSanPham_CT.MTEntityState == Enummation.MTEntityState.Add)
                                {

                                    var phuKiensCuaSanPham = (List<DM_PhuKien>)DBContext.GetRep2<DM_PhuKienRepository>()
                                                                    .GetData(typeof(DM_PhuKien), "Id,sDM_SanPham_Id,sDM_DonViTinh_Id,rSoLuong,rDonGia,sXuatXu"
                                                                    , where: $"sDM_SanPham_Id='{kH_SuaChuaSanPham_CT.sDM_SanPham_Id.Value}'"
                                                                    , orderBy: "SortOrder");
                                    List<KH_SuaChuaSanPham_CT_PhuKien> kH_SuaChuaSanPham_CT_PhuKiens = new List<KH_SuaChuaSanPham_CT_PhuKien>();
                                    if (phuKiensCuaSanPham != null)
                                    {
                                        foreach (var item in phuKiensCuaSanPham)
                                        {
                                            kH_SuaChuaSanPham_CT_PhuKiens.Add(new KH_SuaChuaSanPham_CT_PhuKien
                                            {
                                                Id = Guid.NewGuid(),
                                                rSoLuongPhuKienTren1SP = item.rSoLuong,
                                                rSoLuong = kH_SuaChuaSanPham_CT.rSoLuong * item.rSoLuong,
                                                MTEntityState = Enummation.MTEntityState.Add,
                                                sDM_DonViTinh_Id = item.sDM_DonViTinh_Id,
                                                sDM_PhuKien_Id = item.Id,
                                                rDonGia = item.rDonGia,
                                                rThanhTien = kH_SuaChuaSanPham_CT.rSoLuong * item.rSoLuong * item.rDonGia,
                                                sXuatXu = item.sXuatXu,
                                                sDM_SanPham_Id = item.sDM_SanPham_Id
                                            });
                                        }
                                    }
                                    kH_SuaChuaSanPham_CT.kH_SuaChuaSanPham_CT_PhuKiens = kH_SuaChuaSanPham_CT_PhuKiens;
                                }
                            }

                            mGridControl.FirstView.SetRowCellValue(e.RowHandle, "sDM_DonViTinh_Id", dM_SanPham.sDM_DonViTinh_Id_Cap1);

                            mGridControl.FirstView.SetRowCellValue(e.RowHandle, "rSoLuong", 1);

                            mGridControl.FirstView.SetRowCellValue(e.RowHandle, "rDonGia", dM_SanPham.rDonGia_Cap1);
                            mGridControl.FirstView.SetRowCellValue(e.RowHandle, "sXuatXu", dM_SanPham.sXuatXu);
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
                        mGridControl.FirstView.SetRowCellValue(e.RowHandle, "rThanhTien", kH_SuaChuaSanPham_CT.rSoLuong * kH_SuaChuaSanPham_CT.rDonGia);
                    }
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
                    treesDM_DonVi_Id_DonViXayDungKH.SetReadOnly(false);
                    break;
                default:
                    treesDM_DonVi_Id_DonViXayDungKH.SetReadOnly(true);
                    break;
            }

            cbosDM_CanBo_Id_NguoiLapKH.SetReadOnly(true);
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
                    ucThamChieu.sObjectId = Guid.Parse(this.CurrentData.GetIdentity().ToString());
                    ucThamChieu.sTenBangCanCu = "KH_SuaChuaSanPham";
                    ucThamChieu.LoadData();
                    break;
            }
        }

        /// <summary>
        /// Xử lý dữ liệu trước khi binding lên form
        /// </summary>
        /// <returns></returns>
        protected override BaseEntity PrepareDataBeforeBindDataForm()
        {
            var currentData = (KH_SuaChuaSanPham)base.PrepareDataBeforeBindDataForm();

            if (currentData.MTEntityState == Enummation.MTEntityState.Add)
            {
                currentData.dNgayKeHoach = SysDateTime.Instance.Now();
                currentData.sDM_DonVi_Id_DonViXayDungKH = MT.Library.SessionData.OrganizationUnitId;
                currentData.sDM_DonVi_Id_DonViXuat = MT.Library.SessionData.OrganizationUnitId;
                currentData.iThoiGianHieuLuc = 60;
                currentData.iDonViThoiGianHieuLuc = (int)iDonViThoiGianHieuLuc.Ngay;
                currentData.sDM_CanBo_Id_NguoiLapKH = MT.Library.SessionData.UserId;

            }

            switch (currentData.MTEntityState)
            {
                case Enummation.MTEntityState.Add:
                case Enummation.MTEntityState.Duplicate:
                    currentData.iTrangThaiDuyet = (int)iTrangThaiDuyetKHNM.ChoDuyet;
                    currentData.sLyDoXetDuyet = string.Empty;
                    break;
            }

            return currentData;
        }


        /// <summary>
        /// Thiết lập các tham số trước khi in
        /// </summary>
        /// <param name="configExcel"></param>
        /// <param name="configReport"></param>
        protected override void SetConfigBeforePrint(ConfigExcel configExcel, ConfigReport configReport)
        {
            base.SetConfigBeforePrint(configExcel, configReport);
            //Đối tượng xử lý nghiệp vụ IN
            configReport.RepName = "Print_KH_SuaChuaSanPham_DetailRepository";
            //Định danh mẫu in trong bảng ReportData
            configReport.DictionaryKey = MT.Data.ReportDictionaryKey.RP_Print_KH_SuaChuaSanPhamDetail;

            //Danh sách các cột trên table
            configExcel.ShowColumnsOrder = new HashSet<string>
            {
                "sSTT","sDM_SanPham_Id_Ten",
                "sDM_DonViTinh_Id_Ten","rSoLuong",
                "sDM_TinhTrangHongHoc_Id_Ten","sDM_NoiDungSuaChua_Id_Ten",
                "sXuatXu",
            };

        }

        private void cbosDM_CanBo_Id_NguoiDuyet_QueryPopUp(object sender, CancelEventArgs e)
        {
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id,sTenCanBo", viewName: "View_DM_CanBo",
                where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' AND iDictionaryKey IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong})", orderBy: "sTen");
        }

        private void cbosDM_CanBo_Id_ThuTruongDonVi_QueryPopUp(object sender, CancelEventArgs e)
        {
            /*cbosDM_CanBo_Id_ThuTruongDonVi.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id,sMaCanBo,sTenCanBo", where: $"Id in (select Id from DM_CanBo where sDM_DonVi_Id in (select sParentId from DM_DonVi where Id='{MT.Library.SessionData.OrganizationUnitId}'))", orderBy: "sMaCanBo");*/

            // Truong 2022
            string chucVu = $" AND iDictionaryKey IN({ (int)MT.Data.iChucVu.TruongPhong},{ (int)MT.Data.iChucVu.PhoTruongPhong},{ (int)MT.Data.iChucVu.PhoCucTruong},{ (int)MT.Data.iChucVu.CucTruong})";
            cbosDM_CanBo_Id_ThuTruongDonVi.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                    columns: "Id,sMaCanBo,sTenCanBo",
                    where: $"Id in (select Id from View_DM_CanBo where sDM_DonVi_Id in (select sParentId from DM_DonVi where Id='{MT.Library.SessionData.OrganizationUnitId}') {chucVu})", orderBy: "sMaCanBo");
        }
        #endregion

        #region Sub/Func


        #endregion


    }
}
