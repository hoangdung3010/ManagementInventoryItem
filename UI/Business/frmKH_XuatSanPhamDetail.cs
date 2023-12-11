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
    public partial class frmKH_XuatSanPhamDetail : FormUI.MFormBusinessDetail
    {
        private DM_DonViRepository dM_DonViRepository;

        public frmKH_XuatSanPhamDetail()
        {
            InitializeComponent();

            // Note 14.6 to load from label click
            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<KH_XuatSanPhamRepository>(),
                    EntityName = "KH_XuatSanPham",
                    Title = "Kế hoạch xuất sản phẩm"
                };
            }

            GrdDetails = new Dictionary<string, MTControl.MGridEditable>
            {
                {"KH_XuatSanPham_CT",grdSanPham }
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

            // Ke hoach tong the
            cbossKH_XuatBaoDam_Id_CanCu.Properties.DisplayMember = "sMa";
            cbossKH_XuatBaoDam_Id_CanCu.Properties.ValueMember = "Id";
            cbossKH_XuatBaoDam_Id_CanCu.AddColumn("sMa", "Số kế hoạch bảo đảm", 120);
            cbossKH_XuatBaoDam_Id_CanCu.AddColumn("dNgayKeHoach", "Ngày lập", 80);
            cbossKH_XuatBaoDam_Id_CanCu.AddColumn("sDM_DonVi_Id_DonViXuat_Ten", "Đơn vị xuất", 120);
            //cbossKH_XuatSanPham_Id_CanCu.AddColumn("iThoiGianHieuLuc", "Thời gian hiệu lực", 120, true);
            /*cbossKH_XuatBaoDam_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.KH_XuatBaoDamRepository>().GetData(typeof(MT.Data.BO.KH_XuatBaoDam),
                columns: "Id,sMa,dNgayKeHoach,sDM_DonVi_Id_DonViXuat_Ten, sDM_DonVi_Id_DonViXuat",
                where: $"iTrangThaiDuyet=1 AND sDM_DonVi_Id_DonViXayDungKH ='{MT.Library.SessionData.OrganizationUnitId}'",
                orderBy: "sSo DESC", viewName: "View_KH_XuatBaoDam");*/

            cbossKH_XuatBaoDam_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.KH_XuatBaoDamRepository>().GetData(typeof(MT.Data.BO.KH_XuatBaoDam),
                orderBy: "sSo DESC", viewName: "View_KH_XuatBaoDam_UNION_View_Phieu_XuatSanPham");

            //cbossKH_XuatBaoDam_Id_CanCu.Properties.DisplayMember = "sMa";
            //cbossKH_XuatBaoDam_Id_CanCu.Properties.ValueMember = "Id";
            //cbossKH_XuatBaoDam_Id_CanCu.AddColumn("sMa", "Số kế hoạch Bảo đảm", 180, true);
            //cbossKH_XuatBaoDam_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.KH_XuatBaoDamRepository>().GetData(typeof(MT.Data.BO.KH_XuatBaoDam),
            //    columns: "Id,sMa", orderBy: "sMa");

            var dsCanBo = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                                 columns: "Id,sMaCanBo,sTenCanBo", orderBy: "sMaCanBo");

            // Nguoi Lap Kh
            cbosDM_CanBo_Id_NguoiLapKH.Properties.DisplayMember = "sTenCanBo";
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
            /* cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
              //columns: "Id,sMaCanBo,sTenCanBo", where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' and (sDM_ChucVu_Id='A0AF0133-54AB-435D-823B-3DF1C10D72C8'or sDM_ChucVu_Id='903EB1D0-B73D-4FF2-AD69-8B81D1A2A22A')", orderBy: "sMaCanBo");*/
            /* columns: "Id,sMaCanBo,sTenCanBo", viewName: "View_DM_CanBo",
              where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' AND iDictionaryKey IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong})",
              orderBy: "sMaCanBo");*/
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = dsCanBo;
            cbosDM_CanBo_Id_NguoiDuyet.AliasFormQuickAdd = "DM_CanBo";// NOTE

            // Thu truong don vi
            cbosDM_CanBo_Id_ThuTruongDonVi.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_ThuTruongDonVi.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_ThuTruongDonVi.AddColumn("sTenCanBo", "Tên", 180, true);
            /*cbosDM_CanBo_Id_ThuTruongDonVi.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
             //columns: "Id,sMaCanBo,sTenCanBo", where: $"Id= (select Id from DM_CanBo where sDM_DonVi_Id in (select sParentId from DM_DonVi where Id='{MT.Library.SessionData.OrganizationUnitId}'))", orderBy: "sMaCanBo");
             columns: "Id,sMaCanBo,sTenCanBo",
                where: $"iDictionaryKey IN({(int)MT.Data.iChucVu.CucTruong},{(int)MT.Data.iChucVu.PhoCucTruong},{(int)MT.Data.iChucVu.PhoGiamDoc})",
                orderBy: "sMaCanBo",
                viewName: "View_DM_CanBo");*/
            cbosDM_CanBo_Id_ThuTruongDonVi.Properties.DataSource = dsCanBo;
            cbosDM_CanBo_Id_ThuTruongDonVi.AliasFormQuickAdd = "DM_CanBo";// NOTE

            // Don vi Xuat
            treesDM_DonVi_Id_DonViXuat.Properties.DisplayMember = "sTenDonvi";
            treesDM_DonVi_Id_DonViXuat.Properties.ValueMember = "Id";
            treeList = treesDM_DonVi_Id_DonViXuat.Properties.TreeList;
            treeList.ParentFieldName = "sParentId";
            treeList.KeyFieldName = "Id";
            treesDM_DonVi_Id_DonViXuat.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            treesDM_DonVi_Id_DonViXuat.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);

            var donviXuat = dM_DonViRepository.GetDonViConCap1VaDonViCungCap(MT.Library.SessionData.OrganizationUnitId);

            treesDM_DonVi_Id_DonViXuat.Properties.DataSource = donviXuat;
            treesDM_DonVi_Id_DonViXuat.AliasFormQuickAdd = "DM_DonVi";

            // Đơn vị nhập
            treesDM_DonVi_Id_DonViNhap.Properties.DisplayMember = "sTenDonvi";
            treesDM_DonVi_Id_DonViNhap.Properties.ValueMember = "Id";
            treeList = treesDM_DonVi_Id_DonViNhap.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            treesDM_DonVi_Id_DonViNhap.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            treesDM_DonVi_Id_DonViNhap.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);

            var donviNhan = dM_DonViRepository.GetDonViConCap1VaDonViCungCap(MT.Library.SessionData.OrganizationUnitId);

            treesDM_DonVi_Id_DonViNhap.Properties.DataSource = donviNhan;
            treesDM_DonVi_Id_DonViNhap.AliasFormQuickAdd = "DM_DonVi";

            cboEnumiDonViThoiGianHieuLuc.EnumData = "iDonViThoiGianHieuLuc";
            //cboEnumiL.EnumData = "iDonViThoiGianHieuLuc";
            // 14.6
            linkFormVoucher.VoucherId = null;
            linkFormVoucher.ControlVoucher = cbossKH_XuatBaoDam_Id_CanCu;
            linkFormVoucher.TableName = "KH_XuatBaoDam";
        }

        /// <summary>
        /// Khởi tạo thông tin grid
        /// </summary>
        private void InitGrid()
        {
            var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham),
              "Id,sMaSanPham,sTenSanPham,sDM_NhomSanPham_Id_Ten", viewName: "View_DM_SanPham", orderBy: "sDM_NhomSanPham_Id_Ten,sMaSanPham");

            var dm_DonViTinhs = DBContext.GetRep<MT.Data.Rep.DM_DonViTinhRepository>().GetData(typeof(MT.Data.BO.DM_DonViTinh), "Id,sTenDonViTinh", orderBy: "SortOrder");
            //Sản phẩm
            grdSanPham.GrdDetail.TableName = "KH_XuatSanPham_CT";
            grdSanPham.GrdDetail.ViewName = "View_KH_XuatSanPham_CT";
            grdSanPham.GrdDetail.KeyName = "Id";
            grdSanPham.GrdDetail.SetField = "kH_XuatSanPham_CTs";
            grdSanPham.GrdDetail.FirstView.OptionsNavigation.EnterMoveNextColumn = true;
            grdSanPham.GrdDetail.DisableFieldNames = @"sDM_HangMucBaoDam_Id_Ten,rThanhTien,dHanBaoHanhDen";

            grdSanPham.GrdDetail.ValidEditValueChanging = grdSanPham_ValidEditValueChanging;
            grdSanPham.IsRequired = true;
            grdSanPham.InvalidText = "Danh sách sản phẩm không được bỏ trống";
            grdSanPham.GrdDetail.FuncCustomRecordBeforeAddRow = GridSanPham_FuncCustomRecordBeforeAddRow;

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

            col = grdSanPham.GrdDetail.AddColumnText("sDM_HangMucBaoDam_Id_Ten", "Loại Hạng mục bảo đảm", 250, isRequired: true);// ten

            // Mạng LL
            // 2021
            /*col = grdSanPham.GrdDetail.AddColumnText("sDM_MangLienLac_Id", "Mạng liên lạc", 150, isFixWidth: true,
               //fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left,
               dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);

            MRepositoryItemLookUpEdit colsDM_MangLL_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_MangLL_Id.DictionaryName = "DM_MangLienLac";
            //colsDM_MangLL_Id.AddColumn("sMaMangLienLac", "Mã mạng liên lạc", 120);
            colsDM_MangLL_Id.AddColumn("sTenMangLienLac", "Tên mạng liên lạc", 180);
            colsDM_MangLL_Id.DataSource = DBContext.GetRep<MT.Data.Rep.DM_MangLienLacRepository>().GetData(typeof(MT.Data.BO.DM_MangLienLac), "Id,sTenMangLienLac", orderBy: "SortOrder");
            colsDM_MangLL_Id.DisplayMember = "sTenMangLienLac";
            colsDM_MangLL_Id.ValueMember = "Id";*/

            col = grdSanPham.GrdDetail.AddColumnText("sDM_DonViTinh_Id", "Đơn vị tính", 120,
                dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);

            MRepositoryItemLookUpEdit colsDM_DonViTinh_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_DonViTinh_Id.AddColumn("sTenDonViTinh", "Tên đơn vị tính", 180);
            colsDM_DonViTinh_Id.DataSource = dm_DonViTinhs;
            colsDM_DonViTinh_Id.DisplayMember = "sTenDonViTinh";
            colsDM_DonViTinh_Id.ValueMember = "Id";

            grdSanPham.GrdDetail.AddColumnText("rSoLuong", "Số lượng", 80, dataType: MTControl.DataTypeColumn.SpinEdit);

            grdSanPham.GrdDetail.AddColumnText("rDonGia", "Đơn giá", 150, dataType: MTControl.DataTypeColumn.SpinEdit);
            grdSanPham.GrdDetail.AddColumnText("rThanhTien", "Thành tiền", 150, dataType: MTControl.DataTypeColumn.SpinEdit);

            var colsSerial = grdSanPham.GrdDetail.AddColumnText("sSerial", "Số Serial", 150,
                dataType: MTControl.DataTypeColumn.CheckedComboBox);

            grdSanPham.GrdDetail.AddColumnText("sCauHinhKyThuat", "Cấu hình kỹ thuật", 180, maxLength: 255);

            grdSanPham.GrdDetail.AddColumnText("sXuatXu", "Xuất xứ", 180, maxLength: 255);

            grdSanPham.GrdDetail.AddColumnText("iNamSX", "Năm sản xuất", 80, dataType: DataTypeColumn.SpinEdit);

            grdSanPham.GrdDetail.AddColumnText("iThoiGianBaoHanh", "T.gian BH", toolTip: "Thời gian bảo hành", 80,
                dataType: DataTypeColumn.SpinEdit, isRequired: true);

            var coliDonViThoiGianBaoHanh = grdSanPham.GrdDetail.AddColumnText("iDonViThoiGianBaoHanh",
                "Đơn vị t.gian BH", toolTip: "Đơn vị thời gian bảo hành", 80, dataType: DataTypeColumn.ComboBox, isRequired: true);
            MRepositoryComboBox mRepositoryComboBox = (MRepositoryComboBox)coliDonViThoiGianBaoHanh.ColumnEdit;
            mRepositoryComboBox.EnumData = "iDonViThoiGianHieuLuc";

            grdSanPham.GrdDetail.AddColumnText("dHanBaoHanhDen", "Hạn bảo hành", 100, dataType: DataTypeColumn.DateEdit, isRequired: true);

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

            //col = grdSanPham.GrdDetail.AddColumnText("sKH_XuatBaoDam_CT_Id", "sKH_XuatBaoDam_CT_Id", 0);
            //col.Visible = false;
        }

        #endregion
        #region"Event"

        /// <summary>
        /// Validate giá trị trước khi gán cho grid
        /// </summary>
        /// <param name="gridColumn"></param>
        /// <param name="e"></param>
        /// <returns>=true cho gán,ngược lại ko cho gán</returns>
        private bool grdSanPham_ValidEditValueChanging(DevExpress.XtraGrid.Columns.GridColumn gridColumn, ChangingEventArgs e)
        {
            if (cbossKH_XuatBaoDam_Id_CanCu.EditValue != null)
            {
                Guid IDKHBD = Guid.Empty;
                object sKH_XuatBaoDam_Id_CanCu = cbossKH_XuatBaoDam_Id_CanCu.EditValue;
                if (sKH_XuatBaoDam_Id_CanCu != null)
                {
                    IDKHBD = Guid.Parse(cbossKH_XuatBaoDam_Id_CanCu.EditValue.ToString());
                }
                KH_XuatBaoDam_CTRepository kH_XuatBaoDam_CTRepository = DBContext.GetRep2<KH_XuatBaoDam_CTRepository>();
                if ((gridColumn.FieldName == "sDM_SanPham_Id") && !object.Equals(e.OldValue, e.NewValue)) //sDM_SanPham_Id
                {
                    KH_XuatSanPham_CT kH_XuatSanPham = grdSanPham.GrdDetail.GetRecordByRowSelected<KH_XuatSanPham_CT>();
                    KH_XuatBaoDam_CT h_XuatBaoDam_CT = kH_XuatBaoDam_CTRepository
                        .GetKH_XuatBaoDam_CTBysKH_XuatBaoDam_IdAndsDM_SanPham_Id(IDKHBD,
                        Guid.Parse(e.NewValue.ToString()), kH_XuatSanPham.sDM_DonViTinh_Id, dvNhapID: Guid.Parse(treesDM_DonVi_Id_DonViNhap.EditValue.ToString()));

                    if (h_XuatBaoDam_CT == null)
                    {
                        e.NewValue = e.OldValue;
                        MMessage.ShowWarning($"Sản phẩm <{kH_XuatSanPham.sDM_SanPham_Id_Ten}> đã nhập đủ so với kế hoạch <{cbossKH_XuatBaoDam_Id_CanCu.Text}>");
                        return false;
                    }

                    if (h_XuatBaoDam_CT.rSoLuong <= 0)
                    {
                        e.NewValue = e.OldValue;
                        MMessage.ShowWarning($"Sản phẩm <{h_XuatBaoDam_CT.sDM_SanPham_Id_Ten}> đã nhập đủ so với kế hoạch <{cbossKH_XuatBaoDam_Id_CanCu.Text}>");
                        return false;
                    }

                    List<KH_XuatSanPham_CT> kH_XuatSanPham_CTs = grdSanPham.GrdDetail.GetAllData<KH_XuatSanPham_CT>();
                    if (kH_XuatSanPham_CTs != null)
                    {
                        decimal rSoluong = kH_XuatSanPham_CTs.FindAll(m => m.sKH_XuatBaoDam_CT_Id == h_XuatBaoDam_CT.Id).Sum(m => m.rSoLuong);
                        if (h_XuatBaoDam_CT.rSoLuong - rSoluong <= 0)
                        {
                            e.NewValue = e.OldValue;
                            MMessage.ShowWarning($"Sản phẩm <{h_XuatBaoDam_CT.sDM_SanPham_Id_Ten}> đã nhập đủ so với kế hoạch <{cbossKH_XuatBaoDam_Id_CanCu.Text}>");
                            return false;
                        }
                    }
                }
                

                }


            if (gridColumn.FieldName == "sSerial" && e.NewValue != null && !object.Equals(e.OldValue, e.NewValue))
            {
                string[] arrSerial = e.NewValue.ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                KH_XuatSanPham_CT kH_XuatSanPham = grdSanPham.GrdDetail.GetRecordByRowSelected<KH_XuatSanPham_CT>();
                if (arrSerial.Length > 0 && (decimal)arrSerial.Length > kH_XuatSanPham.rSoLuong)
                {
                    e.NewValue = string.Empty;
                    MMessage.ShowWarning($"Bạn chỉ được phép chọn tối đa {(int)kH_XuatSanPham.rSoLuong} số serial");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Bắt hành động gán giá trị default cho cột grid
        /// </summary>
        /// <returns>=true cho addnewrow, ngược lại ko</returns>
        private bool GridSanPham_FuncCustomRecordBeforeAddRow(object newRecord, MGridControl mGridControl)
        {
            //KH_XuatSanPham_CT kH_XuatSanPham_CT2 = grdSanPham.GrdDetail.GetRecordByRowSelected<KH_XuatSanPham_CT>();
            var now = SysDateTime.Instance.Now();
            KH_XuatSanPham_CT kH_XuatSanPham_CT = (KH_XuatSanPham_CT)newRecord;
            if (kH_XuatSanPham_CT.sDM_SanPham_Id.HasValue
                && !kH_XuatSanPham_CT.sDM_SanPham_Id.Value.Equals(Guid.Empty))
            {
                /* if (cbossKH_XuatBaoDam_Id_CanCu.EditValue != null)
                 {
                     ActiveControl = cbossKH_XuatBaoDam_Id_CanCu;
                     MMessage.ShowWarning("Bạn phải xác định phiếu xuất căn cứ theo kế hoạch nào.");
                     return false;
                 }*/
                Guid? sKH_XuatBaoDam_Id = null;
                if (cbossKH_XuatBaoDam_Id_CanCu.EditValue != null)
                {
                    sKH_XuatBaoDam_Id = Guid.Parse(cbossKH_XuatBaoDam_Id_CanCu.EditValue.ToString());
                }
                if (sKH_XuatBaoDam_Id.HasValue)
                {
                    Guid sKH_XuatSanPham_Id_CanCu = Guid.Parse(cbossKH_XuatBaoDam_Id_CanCu.EditValue.ToString());

                    //Có sản phẩm thì lấy giá trị mặc định
                    var kh_XuatBaoDam_CT = GetKH_XuatBaoDam_CTByIdAndsDM_SanPham_Id(sKH_XuatSanPham_Id_CanCu, kH_XuatSanPham_CT.sDM_SanPham_Id.Value, kH_XuatSanPham_CT);

                    //Lấy chi tiết phụ kiện theo kế hoạch
                    List<MT.Data.BO.KH_XuatBaoDam_CT_PhuKien> kH_XuatBaoDam_CT_PhuKiens = DBContext.GetRep2<KH_XuatBaoDam_CT_PhuKienRepository>()
                                                                                                .GetKH_XuatBaoDam_CT_PhuKiensBysKH_XuatBaoDam_CT_Id(kh_XuatBaoDam_CT.Id);
                    List<MT.Data.BO.KH_XuatSanPham_CT_PhuKien> kH_XuatSanPham_CT_PhuKiens = new List<KH_XuatSanPham_CT_PhuKien>();
                    if (kH_XuatBaoDam_CT_PhuKiens != null)
                    {
                        foreach (var item in kH_XuatBaoDam_CT_PhuKiens)
                        {
                            kH_XuatSanPham_CT_PhuKiens.Add(new KH_XuatSanPham_CT_PhuKien
                            {
                                Id = Guid.NewGuid(),
                                sDM_SanPham_Id = item.sDM_SanPham_Id,
                                sDM_SanPham_Id_Ten = item.sDM_SanPham_Id_Ten,
                                sDM_PhuKien_Id = item.sDM_PhuKien_Id,
                                sDM_PhuKien_Id_Ten = item.sDM_PhuKien_Id_Ten,
                                sDM_DonViTinh_Id = item.sDM_DonViTinh_Id,
                                rSoLuong = 1,
                                rDonGia = item.rDonGia,
                                rThanhTien = item.rThanhTien,
                                SortOrder = item.SortOrder,
                                MTEntityState = Enummation.MTEntityState.Add
                            });
                        }
                    }
                    //KH_XuatSanPham_CT kH_XuatSanPham_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<KH_XuatSanPham_CT>();
                    //phieu_XuatBaoDam_CT.IsLoaded = true;
                    //phieu_XuatBaoDam_CT.phieu_XuatBaoDam_CT_PhuKiens = phieu_XuatBaoDam_CT_PhuKiens;
                    //Guid sKH_XuatBaoDam_Id = Guid.Parse(cbossKH_XuatBaoDam_Id_CanCu.EditValue.ToString());
                    if (kh_XuatBaoDam_CT != null)
                    {
                        kH_XuatSanPham_CT.IsLoaded = true;
                        kH_XuatSanPham_CT.kH_XuatSanPham_CT_PhuKiens = kH_XuatSanPham_CT_PhuKiens;
                        kH_XuatSanPham_CT.sKH_XuatBaoDam_CT_Id = kh_XuatBaoDam_CT.Id;
                        kH_XuatSanPham_CT.sKH_XuatBaoDam_Id = sKH_XuatBaoDam_Id;

                        kH_XuatSanPham_CT.sDM_SanPham_Id_Ten = kh_XuatBaoDam_CT.sDM_SanPham_Id_Ten;
                        kH_XuatSanPham_CT.sDM_DonViTinh_Id = kh_XuatBaoDam_CT.sDM_DonViTinh_Id;
                        kH_XuatSanPham_CT.rSoLuong = kh_XuatBaoDam_CT.rSoLuong;
                        kH_XuatSanPham_CT.rDonGia = kh_XuatBaoDam_CT.rDonGia;
                        kH_XuatSanPham_CT.rThanhTien = kh_XuatBaoDam_CT.rSoLuong * kh_XuatBaoDam_CT.rDonGia;

                        kH_XuatSanPham_CT.sSerial = string.Empty;
                        kH_XuatSanPham_CT.iThoiGianBaoHanh = 60;
                        kH_XuatSanPham_CT.iDonViThoiGianBaoHanh = (int)MT.Data.iDonViThoiGianHieuLuc.Ngay;
                        kH_XuatSanPham_CT.sCauHinhKyThuat = kh_XuatBaoDam_CT.sCauHinhKyThuat;
                        kH_XuatSanPham_CT.sXuatXu = kh_XuatBaoDam_CT.sXuatXu;
                        kH_XuatSanPham_CT.iNamSX = kh_XuatBaoDam_CT.iNamSX;
                        kH_XuatSanPham_CT.sKH_XuatBaoDam_CT_Id = kh_XuatBaoDam_CT.Id;
                        kH_XuatSanPham_CT.dHanBaoHanhDen =now.AddDays(60);

                    }
                }
                else
                {
                    var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham), where: $"Id='{kH_XuatSanPham_CT.sDM_SanPham_Id}'");
                    if (dm_SanPhams?.Count > 0)
                    {
                        DM_SanPham dM_SanPham = (DM_SanPham)dm_SanPhams[0];
                        kH_XuatSanPham_CT.sDM_SanPham_Id = dM_SanPham.Id;
                        kH_XuatSanPham_CT.sDM_DonViTinh_Id = dM_SanPham.sDM_DonViTinh_Id_Cap1;
                        kH_XuatSanPham_CT.rDonGia = dM_SanPham.rDonGia_Cap1;
                        kH_XuatSanPham_CT.rThanhTien = dM_SanPham.rDonGia_Cap1;
                        kH_XuatSanPham_CT.sDM_SanPham_Id_Ten = dM_SanPham.sTenSanPham;
                        List<DM_PhuKien> dM_PhuKiens = ((DM_PhuKienRepository)DBContext.GetRep<MT.Data.Rep.DM_PhuKienRepository>()).GetPhuKiensBysDM_SanPham_Id(dM_SanPham.Id);
                        List<MT.Data.BO.KH_XuatSanPham_CT_PhuKien> kH_XuatSanPham_CT_PhuKien = new List<KH_XuatSanPham_CT_PhuKien>();
                        foreach (var item in dM_PhuKiens)
                        {
                            kH_XuatSanPham_CT_PhuKien.Add(new KH_XuatSanPham_CT_PhuKien
                            {
                                Id = Guid.NewGuid(),
                                sDM_SanPham_Id = item.sDM_SanPham_Id,
                                sDM_SanPham_Id_Ten = item.sDM_SanPham_Id_Ten,
                                sDM_PhuKien_Id = item.Id,
                                sDM_PhuKien_Id_Ten = item.sTenPhuKien,
                                sDM_DonViTinh_Id = item.sDM_DonViTinh_Id,
                                rSoLuong = item.rSoLuong,
                                rDonGia = item.rDonGia,
                                rThanhTien = item.rDonGia * item.rSoLuong,
                                SortOrder = item.SortOrder,
                                MTEntityState = Enummation.MTEntityState.Add
                            });
                        }
                        kH_XuatSanPham_CT.kH_XuatSanPham_CT_PhuKiens = kH_XuatSanPham_CT_PhuKien;
                        kH_XuatSanPham_CT.iThoiGianBaoHanh = 60;
                        kH_XuatSanPham_CT.iDonViThoiGianBaoHanh = (int)MT.Data.iDonViThoiGianHieuLuc.Ngay;
                        kH_XuatSanPham_CT.iNamSX = now.Year;
                        kH_XuatSanPham_CT.dHanBaoHanhDen =now.AddDays(60);

                        kH_XuatSanPham_CT.IsLoaded = true;
                        kH_XuatSanPham_CT.rSoLuong = 1;
                        kH_XuatSanPham_CT.sSTTSP = string.Empty;
                    }
                }

            }
            return true;
        }

        /// <summary>
        /// Hàm lấy về chi tiết kế hoạch bảo đảm
        /// </summary>
        /// <param name="sKH_XuatSanPham_Id_CanCu">Căn cứ kế hoạch</param>
        /// <param name="sDM_SanPham_Id">Id sản phẩm</param>
        /// <param name="kH_XuatSanPham_CT">Chi tiết sản phẩm nhập mới</param>
        /// <returns></returns>
        private KH_XuatBaoDam_CT GetKH_XuatBaoDam_CTByIdAndsDM_SanPham_Id(Guid sKH_XuatSanPham_Id_CanCu, Guid sDM_SanPham_Id, KH_XuatSanPham_CT kH_XuatSanPham_CT)
        {
            List<KH_XuatSanPham_CT> kH_XuatSanPham_CTs = grdSanPham.GrdDetail.GetAllData<KH_XuatSanPham_CT>();
            
            var h_XuatBaoDam_CT = DBContext.GetRep2<KH_XuatBaoDam_CTRepository>()
                .GetKH_XuatBaoDam_CTBysKH_XuatBaoDam_IdAndsDM_SanPham_Id(sKH_XuatSanPham_Id_CanCu,
                sDM_SanPham_Id, kH_XuatSanPham_CT.sDM_DonViTinh_Id, kH_XuatSanPham_CT.Id, dvNhapID: Guid.Parse(treesDM_DonVi_Id_DonViNhap.EditValue.ToString()));
            decimal rSoluong = 0;
            if (kH_XuatSanPham_CTs != null && kH_XuatSanPham_CTs.Count > 0)
            {
                rSoluong = kH_XuatSanPham_CTs.FindAll(m => m.sKH_XuatBaoDam_CT_Id == h_XuatBaoDam_CT.Id && m.Id != kH_XuatSanPham_CT.Id).Sum(m => m.rSoLuong);
            }
            if (h_XuatBaoDam_CT != null)
            {
                h_XuatBaoDam_CT.rSoLuong = h_XuatBaoDam_CT.rSoLuong - rSoluong;
                if (h_XuatBaoDam_CT.rSoLuong <= 0)
                {
                    h_XuatBaoDam_CT.rSoLuong = 0;
                }
                if (h_XuatBaoDam_CT.IsShowSoSerial && h_XuatBaoDam_CT.rSoLuong > h_XuatBaoDam_CT.iKichThuocDongGoi)
                {
                    h_XuatBaoDam_CT.rSoLuong = h_XuatBaoDam_CT.iKichThuocDongGoi;
                }
                h_XuatBaoDam_CT.rThanhTien = h_XuatBaoDam_CT.rSoLuong * h_XuatBaoDam_CT.rDonGia;
            }

            return h_XuatBaoDam_CT;
        }

        private KH_XuatBaoDam_CT GetKH_XuatBaoDam_CTById(Guid sKH_XuatSanPham_Id_CanCu)
        {
            List<KH_XuatSanPham_CT> kH_XuatSanPham_CTs = grdSanPham.GrdDetail.GetAllData<KH_XuatSanPham_CT>();

            var h_XuatBaoDam_CT = DBContext.GetRep2<KH_XuatBaoDam_CTRepository>()
                .GetKH_XuatBaoDam_CTBysKH_XuatBaoDam_Id(sKH_XuatSanPham_Id_CanCu);
            decimal rSoluong = 0;
            if (kH_XuatSanPham_CTs != null && kH_XuatSanPham_CTs.Count > 0)
            {
                rSoluong = kH_XuatSanPham_CTs.FindAll(m => m.sKH_XuatBaoDam_CT_Id == h_XuatBaoDam_CT.Id).Sum(m => m.rSoLuong);
            }
            if (h_XuatBaoDam_CT != null)
            {
                h_XuatBaoDam_CT.rSoLuong = h_XuatBaoDam_CT.rSoLuong - rSoluong;
                if (h_XuatBaoDam_CT.rSoLuong <= 0)
                {
                    h_XuatBaoDam_CT.rSoLuong = 0;
                }
                if (h_XuatBaoDam_CT.IsShowSoSerial && h_XuatBaoDam_CT.rSoLuong > h_XuatBaoDam_CT.iKichThuocDongGoi)
                {
                    h_XuatBaoDam_CT.rSoLuong = h_XuatBaoDam_CT.iKichThuocDongGoi;
                }
                h_XuatBaoDam_CT.rThanhTien = h_XuatBaoDam_CT.rSoLuong * h_XuatBaoDam_CT.rDonGia;
            }

            return h_XuatBaoDam_CT;
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
                    ucThamChieuPhieuNhapMoi.sTenBangCanCu = "KH_XuatSanPham";
                    ucThamChieuPhieuNhapMoi.LoadData();
                    break;
            }
        }

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
            // NOTEEEEEEEEEEEEEE
            //Bắt bắt chọn sản phẩm roh thì mới cho nhập phụ kiện
            var kH_XuatSanPham_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<KH_XuatSanPham_CT>();
            if (kH_XuatSanPham_CT.sDM_SanPham_Id.HasValue && !kH_XuatSanPham_CT.sDM_SanPham_Id.Value.Equals(Guid.Empty))
            {
                frmPhuKienDetail frmPhuKienDetail = new frmPhuKienDetail(kH_XuatSanPham_CT.sDM_SanPham_Id.Value,
                   "KH_XuatSanPham_CT_PhuKien", "kH_XuatSanPham_CT_PhuKiens",
                   kH_XuatSanPham_CT, this, true, "KH_XuatBaoDam_CT_PhuKien");
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
        /// Thiết lập các tham số trước khi in
        /// </summary>
        /// <param name="configExcel"></param>
        /// <param name="configReport"></param>
        protected override void SetConfigBeforePrint(MT.Data.BO.ConfigExcel configExcel, ConfigReport configReport)
        {
            base.SetConfigBeforePrint(configExcel, configReport);
            //Đối tượng xử lý nghiệp vụ IN
            configReport.RepName = "Print_KH_XuatSanPham_DetailRepository";
            //Định danh mẫu in trong bảng ReportData
            configReport.DictionaryKey = MT.Data.ReportDictionaryKey.RP_Print_KH_XuatSanPhamDetail;

            //Danh sách các cột trên table
            configExcel.ShowColumnsOrder = new HashSet<string>
            {
                "sSTT","sDM_SanPham_Id_Ten","sDM_DonViTinh_Id_Ten","rSoLuong","sXuatXu","iThoiGianBaoHanh"
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
                Guid IDKHBD = Guid.Empty;
                object sKH_XuatBaoDam_Id_CanCu = cbossKH_XuatBaoDam_Id_CanCu.EditValue;
                if (sKH_XuatBaoDam_Id_CanCu != null)
                {
                    IDKHBD = Guid.Parse(cbossKH_XuatBaoDam_Id_CanCu.EditValue.ToString());
                }

                List<MT.Data.BO.KH_XuatSanPham_CT> kH_XuatSanPham_CTs = mGridEditable.GrdDetail.GetAllData<MT.Data.BO.KH_XuatSanPham_CT>();
                // Truong 2022
                KH_XuatBaoDam_CTRepository kH_XuatBaoDam_CTRepository = DBContext.GetRep2<KH_XuatBaoDam_CTRepository>();
                KH_XuatSanPham_CT kH_XuatSanPham = grdSanPham.GrdDetail.GetRecordByRowSelected<KH_XuatSanPham_CT>();
                KH_XuatBaoDam_CT h_XuatBaoDam_CT = kH_XuatBaoDam_CTRepository
                    .GetKH_XuatBaoDam_CTBysKH_XuatBaoDam_IdAndsDM_SanPham_Id(IDKHBD,
                    Guid.Parse(kH_XuatSanPham.sDM_SanPham_Id.ToString()), kH_XuatSanPham.sDM_DonViTinh_Id, dvNhapID:Guid.Parse(treesDM_DonVi_Id_DonViNhap.EditValue.ToString()));

                if (sKH_XuatBaoDam_Id_CanCu != null && kH_XuatSanPham_CTs != null)
                {
                    decimal rSoluong = kH_XuatSanPham_CTs.FindAll(m => m.sKH_XuatBaoDam_CT_Id == h_XuatBaoDam_CT.Id).Sum(m => m.rSoLuong);
                    if (h_XuatBaoDam_CT.rSoLuong - rSoluong < 0)
                    {
                        MMessage.ShowWarning($"Sản phẩm <{h_XuatBaoDam_CT.sDM_SanPham_Id_Ten}> đã nhập vượt quá so với kế hoạch bảo đảm <{cbossKH_XuatBaoDam_Id_CanCu.Text}>");
                        isValid = false;
                    }
                }

                foreach (var item in dataChanged)
                {
                    var castItem = (MT.Data.BO.KH_XuatSanPham_CT)item;
                    // Truong 2022
                    KH_XuatSanPham_CT findBysID = kH_XuatSanPham_CTs.Find(m => m.sDM_SanPham_Id.Equals(castItem.sDM_SanPham_Id) && m.Id != castItem.Id);
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
                    var dM_SanPham = DBContext.GetRep2<DM_SanPhamRepository>().GetDataByID<DM_SanPham>("DM_SanPham", castItem.sDM_SanPham_Id, "sDM_DonViTinh_Id_Cap1,sDM_DonViTinh_Id_Cap2,iKichThuocDongGoi");
                    if (isValid && dM_SanPham != null
                        && dM_SanPham.sDM_DonViTinh_Id_Cap2.HasValue
                        && object.Equals(castItem.sDM_DonViTinh_Id, dM_SanPham.sDM_DonViTinh_Id_Cap2.Value)
                        && dM_SanPham.iKichThuocDongGoi > 0
                        && string.IsNullOrWhiteSpace(castItem.sSerial))
                    {
                        isValid = false;
                        mGridEditable.GrdDetail.FirstView.FocusedColumn = mGridEditable.GrdDetail.FirstView.Columns["sSerial"];
                        mGridEditable.GrdDetail.FirstView.FocusedRowHandle = castItem.RowHandle;
                        MMessage.ShowWarning($"Bạn phải chọn số serial cho sản phẩm <{castItem.sDM_SanPham_Id_Ten}>, đơn vị tính <{dM_DonViTinh.sTenDonViTinh}>");
                        break;
                    }

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
                case "KH_XuatSanPham_CT":
                    // Noteeeeeeeee
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
                        //gán mặc định đơn vị tính cấp 1 cho sản phẩm
                        KH_XuatBaoDam_CTRepository kh_XuatSanPham_CTRepository = DBContext.GetRep2<KH_XuatBaoDam_CTRepository>();
                        object sKH_XuatBaoDam_Id_CanCu = cbossKH_XuatBaoDam_Id_CanCu.EditValue;
                        MRepositoryItemLookUpEdit repositoryItemLookUpEdit = (MRepositoryItemLookUpEdit)repository;
                        if (sKH_XuatBaoDam_Id_CanCu != null)
                        {
                            repositoryItemLookUpEdit.DataSource = kh_XuatSanPham_CTRepository
                                                                    .GetKH_XuaBaoDam_CTsBysKH_XuatBaoDam_Id(Guid.Parse(sKH_XuatBaoDam_Id_CanCu.ToString()));
                        }
                        else
                        {
                            // repositoryItemLookUpEdit.DataSource = null;
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
                        //MT.Data.BO.KH_XuatSanPham curMaster = (MT.Data.BO.KH_XuatSanPham)this.CurrentData;
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
                case "KH_XuatSanPham_CT":
                    // Noteeeeeeeee
                    KH_XuatSanPham_CT kH_XuatSanPham_CT = mGridControl.GetRecordByRowSelected<KH_XuatSanPham_CT>();
                    if (e.Column.FieldName == "sDM_SanPham_Id")
                    {
                        // Truong2022
                        List<MT.Data.BO.KH_XuatSanPham_CT> kH_XuatSanPham_CTs = grdSanPham.GrdDetail.GetAllData<MT.Data.BO.KH_XuatSanPham_CT>();
                        KH_XuatSanPham_CT findBysID = kH_XuatSanPham_CTs.Find(m => m.sDM_SanPham_Id.Equals(kH_XuatSanPham_CT.sDM_SanPham_Id) && m.Id != kH_XuatSanPham_CT.Id);
                        if (findBysID != null)
                        {
                            MMessage.ShowWarning($"Sản phẩm <{findBysID.sDM_SanPham_Id_Ten}> đã tồn tại");
                        }
                        // end Truong2022

                        //gán mặc định đơn vị tính cấp 1 cho sản phẩm
                        if (mGridControl.FuncCustomRecordBeforeAddRow != null)
                        {
                            mGridControl.FuncCustomRecordBeforeAddRow(kH_XuatSanPham_CT, mGridControl);
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
                                kH_XuatSanPham_CT.sDM_DonViTinh_Id = dM_SanPham.sDM_DonViTinh_Id_Cap1;
                                kH_XuatSanPham_CT.rSoLuong = 1;
                                kH_XuatSanPham_CT.rDonGia = dM_SanPham.rDonGia_Cap1;
                                kH_XuatSanPham_CT.rThanhTien = dM_SanPham.rDonGia_Cap1;
                                //Gán mặc định phụ kiện theo sản phẩm
                                if (!kH_XuatSanPham_CT.IsLoaded && kH_XuatSanPham_CT.MTEntityState == Enummation.MTEntityState.Add)
                                {
                                    var phukiensCuaSanPham = (List<DM_PhuKien>)DBContext.GetRep2<DM_PhuKienRepository>()
                                                                    .GetData(typeof(DM_PhuKien), "Id,sDM_SanPham_Id,sDM_DonViTinh_Id,rSoLuong,rDonGia"
                                                                    , where: $"sDM_SanPham_Id='{kH_XuatSanPham_CT.sDM_SanPham_Id.Value}'"
                                                                    , orderBy: "SortOrder");
                                    List<KH_XuatSanPham_CT_PhuKien> phukienCuaKeHoachXuat = new List<KH_XuatSanPham_CT_PhuKien>();
                                    if (phukiensCuaSanPham != null)
                                    {
                                        foreach (var item in phukiensCuaSanPham)
                                        {
                                            phukienCuaKeHoachXuat.Add(new KH_XuatSanPham_CT_PhuKien
                                            {
                                                Id = Guid.NewGuid(),
                                                rSoLuongPhuKienTren1SP = item.rSoLuong,
                                                rSoLuong = kH_XuatSanPham_CT.rSoLuong * item.rSoLuong,
                                                MTEntityState = Enummation.MTEntityState.Add,
                                                sDM_DonViTinh_Id = item.sDM_DonViTinh_Id,
                                                sDM_PhuKien_Id = item.Id,
                                                rDonGia = item.rDonGia,
                                                rThanhTien = kH_XuatSanPham_CT.rSoLuong * item.rSoLuong * item.rDonGia,
                                                sDM_SanPham_Id = item.sDM_SanPham_Id
                                            });
                                        }
                                    }
                                    kH_XuatSanPham_CT.kH_XuatSanPham_CT_PhuKiens = phukienCuaKeHoachXuat;
                                }

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
                        object sKH_XuatBaoDam_Id_CanCu = cbossKH_XuatBaoDam_Id_CanCu.EditValue;
                        Guid IDKHBD = Guid.Empty;
                        if (sKH_XuatBaoDam_Id_CanCu != null)
                        {
                            IDKHBD=Guid.Parse(cbossKH_XuatBaoDam_Id_CanCu.EditValue.ToString());
                        }
                        kH_XuatSanPham_CT.rThanhTien = kH_XuatSanPham_CT.rSoLuong * kH_XuatSanPham_CT.rDonGia;
                        //var kH_XuatSanPham_CT = mGridControl.GetRecordByRowSelected<KH_XuatSanPham_CT>();
                        // mGridControl.FirstView.SetRowCellValue(e.RowHandle, "rThanhTien", kH_XuatSanPham_CT.rSoLuong * kH_XuatSanPham_CT.rDonGia);
                        KH_XuatBaoDam_CTRepository kH_XuatBaoDam_CTRepository = DBContext.GetRep2<KH_XuatBaoDam_CTRepository>();
                        KH_XuatSanPham_CT kH_XuatSanPham = grdSanPham.GrdDetail.GetRecordByRowSelected<KH_XuatSanPham_CT>();
                        KH_XuatBaoDam_CT h_XuatBaoDam_CT = kH_XuatBaoDam_CTRepository
                            .GetKH_XuatBaoDam_CTBysKH_XuatBaoDam_IdAndsDM_SanPham_Id(IDKHBD,
                            Guid.Parse(kH_XuatSanPham.sDM_SanPham_Id.ToString()), kH_XuatSanPham.sDM_DonViTinh_Id, dvNhapID: Guid.Parse(treesDM_DonVi_Id_DonViNhap.EditValue.ToString()));


                        List<KH_XuatSanPham_CT> kH_XuatSanPham_CTs = grdSanPham.GrdDetail.GetAllData<KH_XuatSanPham_CT>();
                        if (kH_XuatSanPham_CTs != null)
                        {
                            decimal rSoluong = kH_XuatSanPham_CTs.FindAll(m => m.sKH_XuatBaoDam_CT_Id == h_XuatBaoDam_CT.Id).Sum(m => m.rSoLuong);
                            if (h_XuatBaoDam_CT.rSoLuong - rSoluong < 0)
                            {
                                MMessage.ShowWarning($"Sản phẩm <{h_XuatBaoDam_CT.sDM_SanPham_Id_Ten}> đã nhập vượt quá so với kế hoạch bảo đảm <{cbossKH_XuatBaoDam_Id_CanCu.Text}>");
                            }
                        }
                    }
                    if (e.Column.FieldName == "sSerial")
                    {
                        object objsSerial = e.Value;
                        if (objsSerial != null)
                        {
                            string[] arrSerial = objsSerial.ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (arrSerial.Length >= 1)
                            {
                                kH_XuatSanPham_CT.rSoLuong = arrSerial.Length;
                            }
                        }
                    }

                    var now = SysDateTime.Instance.Now();
                    if (e.Column.FieldName == "iThoiGianBaoHanh" || e.Column.FieldName == "iDonViThoiGianBaoHanh")
                    {
                        DateTime? dHanBaoHanhDen = null;
                        switch (kH_XuatSanPham_CT.iDonViThoiGianBaoHanh)
                        {
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Ngay:
                                dHanBaoHanhDen = now.AddDays(kH_XuatSanPham_CT.iThoiGianBaoHanh).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Thang:
                                dHanBaoHanhDen = now.AddMonths(kH_XuatSanPham_CT.iThoiGianBaoHanh).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Quy:
                                dHanBaoHanhDen = now.AddYears(kH_XuatSanPham_CT.iThoiGianBaoHanh * 3).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Nam:
                                dHanBaoHanhDen = now.AddYears(kH_XuatSanPham_CT.iThoiGianBaoHanh).AddDays(1);
                                break;

                            default:
                                dHanBaoHanhDen = now.AddDays(kH_XuatSanPham_CT.iThoiGianBaoHanh).AddDays(1);
                                break;
                        }
                        kH_XuatSanPham_CT.dHanBaoHanhDen = dHanBaoHanhDen;
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
                    cbossKH_XuatBaoDam_Id_CanCu.SetReadOnly(false);
                    break;

                default:
                    cbossKH_XuatBaoDam_Id_CanCu.SetReadOnly(true);
                    break;
            }

            treesDM_DonVi_Id_DonViXayDungKH.SetReadOnly(true);
        }

        /// <summary>
        /// Xử lý dữ liệu trước khi binding lên form
        /// </summary>
        /// <returns></returns>
        protected override BaseEntity PrepareDataBeforeBindDataForm()
        {
            var currentData = (KH_XuatSanPham)base.PrepareDataBeforeBindDataForm();
            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:
                    currentData.dNgayKeHoach = SysDateTime.Instance.Now();
                    currentData.sDM_DonVi_Id_DonViXayDungKH = MT.Library.SessionData.OrganizationUnitId;
                    currentData.sDM_CanBo_Id_NguoiLapKH = MT.Library.SessionData.UserId;
                    currentData.iThoiGianHieuLuc = 60;
                    currentData.iDonViThoiGianHieuLuc = (int)iDonViThoiGianHieuLuc.Ngay;
                    //currentData.iNhapVeKho = true;
                    break;
            }

            return currentData;
        }

        #endregion

        private void cbossKH_XuatBaoDam_Id_CanCu_EditValueChanged(object sender, EventArgs e)
        {
            switch (this.FormAction)//cbosDM_KeHoachXuat
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:
                    MT.Data.BO.KH_XuatBaoDam kH_XuatBaoDam = cbossKH_XuatBaoDam_Id_CanCu.GetRecordSelected<MT.Data.BO.KH_XuatBaoDam>();
                    if (kH_XuatBaoDam != null)
                    {
                        // Thiết lập giá trị mặc định cho đơn vị xuất
                        Guid maDVXuat = kH_XuatBaoDam.sDM_DonVi_Id_DonViXuat;
                        treesDM_DonVi_Id_DonViXuat.SetValue(maDVXuat);

                        // Thiết lập giá trị mặc định cho đơn vị nhập
                        var datas1 = DBContext.GetRep2<KH_XuatBaoDam_CTRepository>().GetListDonViNhanInKeHoachBaoDamID(kH_XuatBaoDam.Id);
                        treesDM_DonVi_Id_DonViNhap.Properties.DataSource = datas1;
                        //GetListDonViNhanInKeHoachBaoDamID
                        //var datas = DBContext.GetRep2<KH_XuatBaoDam_CTRepository>().GetKHXuatBaoDam_CTsByMasterId(kH_XuatBaoDam.Id);

                        //grdSanPham.GrdDetail.LoadData(datas);
                    }
                    else // Truong 2022
                    {
                        var donviNhan = dM_DonViRepository.GetDonViConCap1VaDonViCungCap(MT.Library.SessionData.OrganizationUnitId);
                        treesDM_DonVi_Id_DonViNhap.Properties.DataSource = donviNhan;
                    }
                    treesDM_DonVi_Id_DonViNhap.EditValue = null;
                    break;
            }
        }

        // 14.6
        public void UpdateAutoPhuKien(string sSPID, KH_XuatSanPham_CT kH_XuatSanPham_CT)
        {
            Guid sKH_XuatBaoDam_Id = Guid.Parse(cbossKH_XuatBaoDam_Id_CanCu.EditValue.ToString());

            KH_XuatBaoDam_CT kH_XuatBaoDam_CT = DBContext.GetRep2<KH_XuatBaoDam_CTRepository>().GetKH_XuatBaoDam_CTsBysKH_XuatBaoDam_IdAndsIDSP(sKH_XuatBaoDam_Id, sSPID);

            if (kH_XuatBaoDam_CT != null)
            {
                //Lấy chi tiết phụ kiện theo kế hoạch
                List<MT.Data.BO.KH_XuatBaoDam_CT_PhuKien> kH_XuatBaoDam_CT_PhuKiens = DBContext.GetRep2<KH_XuatBaoDam_CT_PhuKienRepository>()
                                                                                            .GetKH_XuatBaoDam_CT_PhuKiensBysKH_XuatBaoDam_CT_Id(kH_XuatBaoDam_CT.Id);
                List<MT.Data.BO.KH_XuatSanPham_CT_PhuKien> kH_XuatSanPham_CT_PhuKiens = new List<KH_XuatSanPham_CT_PhuKien>();
                if (kH_XuatBaoDam_CT_PhuKiens != null)
                {
                    foreach (var item in kH_XuatBaoDam_CT_PhuKiens)
                    {
                        kH_XuatSanPham_CT_PhuKiens.Add(new KH_XuatSanPham_CT_PhuKien
                        {
                            Id = Guid.NewGuid(),
                            sDM_SanPham_Id = item.sDM_SanPham_Id,
                            sDM_SanPham_Id_Ten = item.sDM_SanPham_Id_Ten,
                            sDM_PhuKien_Id = item.sDM_PhuKien_Id,
                            sDM_PhuKien_Id_Ten = item.sDM_PhuKien_Id_Ten,
                            sDM_DonViTinh_Id = item.sDM_DonViTinh_Id,
                            rSoLuong = 1,
                            rDonGia = item.rDonGia,
                            rThanhTien = item.rDonGia,
                            SortOrder = item.SortOrder,
                            MTEntityState = Enummation.MTEntityState.Add
                        });
                    }
                }
                kH_XuatSanPham_CT.IsLoaded = true;
                kH_XuatSanPham_CT.kH_XuatSanPham_CT_PhuKiens = kH_XuatSanPham_CT_PhuKiens;
                kH_XuatSanPham_CT.sKH_XuatBaoDam_CT_Id = kH_XuatBaoDam_CT.Id;
                kH_XuatSanPham_CT.sKH_XuatBaoDam_Id = sKH_XuatBaoDam_Id;
            }
        }

        private void treesDM_DonVi_Id_DonViNhap_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                MT.Data.BO.DM_DonVi dvNhan = treesDM_DonVi_Id_DonViNhap.GetRecordSelected<MT.Data.BO.DM_DonVi>();
                MT.Data.BO.KH_XuatBaoDam kH_XuatBaoDam = cbossKH_XuatBaoDam_Id_CanCu.GetRecordSelected<MT.Data.BO.KH_XuatBaoDam>();
                if (dvNhan != null && kH_XuatBaoDam != null)
                {
                    var datas = DBContext.GetRep2<KH_XuatBaoDam_CTRepository>().GetKHXuatBaoDam_CTsByMasterIdAndDonviNhapNEW(kH_XuatBaoDam.Id, dvNhan.Id);

                    grdSanPham.GrdDetail.LoadData(datas);
                }
                // 14.6 Truong thu load Phu kien
                List<MT.Data.BO.KH_XuatSanPham_CT> kH_XuatSanPham_CTs = grdSanPham.GrdDetail.GetAllData<MT.Data.BO.KH_XuatSanPham_CT>();
                if (cbossKH_XuatBaoDam_Id_CanCu.EditValue != null)
                {
                    foreach (var item in kH_XuatSanPham_CTs)
                    {
                        if(item!= null && item.sDM_SanPham_Id.ToString()!= "")
                            UpdateAutoPhuKien(Guid.Parse(item.sDM_SanPham_Id.ToString()).ToString(), item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(SessionData.ERROR);
            }
        }

        // 14.6
        private void cbossKH_XuatBaoDam_Id_CanCu_QueryPopUp(object sender, CancelEventArgs e)
        {
            cbossKH_XuatBaoDam_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.KH_XuatBaoDamRepository>().GetData(typeof(MT.Data.BO.KH_XuatBaoDam),
               columns: "Id,sMa,dNgayKeHoach,sDM_DonVi_Id_DonViXuat_Ten, sDM_DonVi_Id_DonViXuat",
               where: $"iTrangThaiDuyet=1 AND iTrangThaiThucHienKHNM < {(int)MT.Data.iTrangThaiThucHienKHNM.DaHoanThanh} AND sDM_DonVi_Id_DonViXayDungKH ='{MT.Library.SessionData.OrganizationUnitId}'",
               orderBy: "sSo DESC", viewName: "View_KH_XuatBaoDam");
        }

        private void cbosDM_CanBo_Id_NguoiDuyet_QueryPopUp(object sender, CancelEventArgs e)
        {
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
               columns: "Id,sTenCanBo",
               viewName: "View_DM_CanBo",
               where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' AND iDictionaryKey IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong})",
               orderBy: "sTen");
        }

        private void cbosDM_CanBo_Id_ThuTruongDonVi_QueryPopUp(object sender, CancelEventArgs e)
        {
            // Truong 2022
            string chucVu= $" AND iDictionaryKey IN({ (int)MT.Data.iChucVu.TruongPhong},{ (int)MT.Data.iChucVu.PhoTruongPhong},{ (int)MT.Data.iChucVu.PhoCucTruong},{ (int)MT.Data.iChucVu.CucTruong})";
            cbosDM_CanBo_Id_ThuTruongDonVi.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                    columns: "Id,sMaCanBo,sTenCanBo",
                    where: $"Id in (select Id from View_DM_CanBo where sDM_DonVi_Id in (select sParentId from DM_DonVi where Id='{MT.Library.SessionData.OrganizationUnitId}') {chucVu})", orderBy: "sMaCanBo");
        }
    }
}