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
    public partial class frmPhieu_XuatMuonTraDetail : FormUI.MFormBusinessDetail
    {
        private DM_DonViRepository dM_DonViRepository;

        public frmPhieu_XuatMuonTraDetail()
        {
            InitializeComponent();
            // Note 14.6 to load from label click
            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<Phieu_XuatMuonTraRepository>(),
                    EntityName = "Phieu_XuatMuonTra",
                    Title = "Phiếu xuất sản phẩm"
                };
            }

            GrdDetails = new Dictionary<string, MTControl.MGridEditable>
            {
                {"Phieu_XuatMuonTra_CT",grdSanPham }
            };
            this.ControlTepDinhKem = ucTepDinhKem1;
            InitRep();
            InitLookup();

            InitGrid();

            ucImportMaVachSP.Grd = grdSanPham.GrdDetail;
            ucImportMaVachSP.FrmParent = this;
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
                    ucThamChieuPhieuNhapMoi.sTenBangCanCu = "Phieu_XuatMuonTra";
                    ucThamChieuPhieuNhapMoi.LoadData();
                    break;
            }
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
            // Don vi Xuat
            treesDM_DonVi_Id_DonViXuat.Properties.DisplayMember = "sTenDonvi";
            treesDM_DonVi_Id_DonViXuat.Properties.ValueMember = "Id";
            var treeList = treesDM_DonVi_Id_DonViXuat.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            treesDM_DonVi_Id_DonViXuat.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            treesDM_DonVi_Id_DonViXuat.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);

            var donviXuat = dM_DonViRepository.GetDonViConCap1VaDonViCungCap(MT.Library.SessionData.OrganizationUnitId);

            treesDM_DonVi_Id_DonViXuat.Properties.DataSource = donviXuat;
            treesDM_DonVi_Id_DonViXuat.AliasFormQuickAdd = "DM_DonVi";

            // Don vi nhan
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

            cbossKH_XuatMuonTra_Id_CanCu.Properties.DisplayMember = "sMa";
            cbossKH_XuatMuonTra_Id_CanCu.Properties.ValueMember = "Id";
            cbossKH_XuatMuonTra_Id_CanCu.AddColumn("sMa", "Số kế hoạch", 80);
            cbossKH_XuatMuonTra_Id_CanCu.AddColumn("dNgayKeHoach", "Ngày lập", 80);
            cbossKH_XuatMuonTra_Id_CanCu.AddColumn("sDM_DonVi_Id_DonViXayDungKH_Ten", "Đơn vị lập", 120);
            cbossKH_XuatMuonTra_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.KH_XuatMuonTraRepository>().GetData(typeof(MT.Data.BO.KH_XuatMuonTra),
                orderBy: "sSo DESC", viewName: "View_KH_XuatMuonTra_UNION_Phieu_NhapMuonTra");

            //cbossKH_XuatMuonTra_Id_CanCu.Properties.DisplayMember = "sMa";
            //cbossKH_XuatMuonTra_Id_CanCu.Properties.ValueMember = "Id";
            //cbossKH_XuatMuonTra_Id_CanCu.AddColumn("sMa", "Số kế hoạch", 80);
            //cbossKH_XuatMuonTra_Id_CanCu.AddColumn("dNgayKeHoach", "Ngày lập", 80);
            //cbossKH_XuatMuonTra_Id_CanCu.AddColumn("sDM_DonVi_Id_DonViXayDungKH_Ten", "Đơn vị lập", 120);
            ////cbossKH_XuatMuonTra_Id_CanCu.AddColumn("iThoiGianHieuLuc", "Thời gian hiệu lực", 120, true);
            //cbossKH_XuatMuonTra_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.KH_XuatMuonTraRepository>().GetData(typeof(MT.Data.BO.KH_XuatMuonTra),
            //    columns: "Id,sMa,dNgayKeHoach,sDM_DonVi_Id_DonViXayDungKH_Ten, sDM_DonVi_Id_DonViXuat, sDM_DonVi_Id_DonViNhap",
            //    where: $"iTrangThaiDuyet=1 AND iTrangThaiThucHienKHNM < {(int)MT.Data.iTrangThaiThucHienKHNM.DaHoanThanh} AND sDM_DonVi_Id_DonViXuat ='{MT.Library.SessionData.OrganizationUnitId}'",
            //    orderBy: "sSo DESC", viewName: "View_KH_XuatMuonTra");

            var dsCanBo = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                                columns: "Id,sMaCanBo,sTenCanBo", orderBy: "sMaCanBo");

            // Nguoi lap phieu
            cbosDM_CanBo_Id_NguoiLapPhieu.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiLapPhieu.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiLapPhieu.AddColumn("sTenCanBo", "Tên", 180, true);
            /*cbosDM_CanBo_Id_NguoiLapPhieu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id,sMaCanBo,sTenCanBo", orderBy: "sMaCanBo");*/
            cbosDM_CanBo_Id_NguoiLapPhieu.Properties.DataSource = dsCanBo;
            cbosDM_CanBo_Id_NguoiLapPhieu.AliasFormQuickAdd = "DM_CanBo";

            // Nguoi duyet
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiDuyet.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiDuyet.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = dsCanBo;
            /*cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
            //columns: "Id,sMaCanBo,sTenCanBo", where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' and (sDM_ChucVu_Id='A0AF0133-54AB-435D-823B-3DF1C10D72C8'or sDM_ChucVu_Id='903EB1D0-B73D-4FF2-AD69-8B81D1A2A22A')", orderBy: "sMaCanBo");
            columns: "Id,sMaCanBo,sTenCanBo", viewName: "View_DM_CanBo",
            where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' and iDictionaryKey IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong})",
            orderBy: "sMaCanBo");*/
            cbosDM_CanBo_Id_NguoiDuyet.AliasFormQuickAdd = "DM_CanBo";

            //// Nguoi giao
            cbosDM_CanBo_Id_NguoiGiao.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiGiao.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiGiao.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiGiao.Properties.DataSource = dsCanBo;
            /*cbosDM_CanBo_Id_NguoiGiao.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id,sMaCanBo,sTenCanBo",
                where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' and iDictionaryKey NOT IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong},{(int)MT.Data.iChucVu.CucTruong},{(int)MT.Data.iChucVu.PhoCucTruong})",
                orderBy: "sMaCanBo",
                viewName: "View_DM_CanBo");*/
            cbosDM_CanBo_Id_NguoiGiao.AliasFormQuickAdd = "DM_CanBo";

            // Nguoi nhan
            object sDM_Donvi_Id_nhan = treesDM_DonVi_Id_DonViNhap.GetValue();

            cbosDM_CanBo_Id_NguoiNhap.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiNhap.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiNhap.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = dsCanBo;
            /*if (sDM_Donvi_Id_nhan == null)
                cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id,sMaCanBo,sTenCanBo", orderBy: "sMaCanBo");
            else
                cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id,sMaCanBo,sTenCanBo",
                where: $"sDM_DonVi_Id='{sDM_Donvi_Id_nhan.ToString()}' and iDictionaryKey NOT IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong},{(int)MT.Data.iChucVu.CucTruong},{(int)MT.Data.iChucVu.PhoCucTruong})",
                orderBy: "sMaCanBo",
                viewName: "View_DM_CanBo");*/
            cbosDM_CanBo_Id_NguoiNhap.AliasFormQuickAdd = "DM_CanBo";

            // 14.6
            linkFormVoucher.VoucherId = null;
            linkFormVoucher.ControlVoucher = cbossKH_XuatMuonTra_Id_CanCu;
            linkFormVoucher.TableName = "KH_XuatMuonTra";

            cboEnumiLoaiTCXuat.EnumData = "iTCXuat";
        }

        /// <summary>
        /// Khởi tạo thông tin grid
        /// </summary>
        private void InitGrid()
        {
            var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham), "Id,sMaSanPham,sTenSanPham", orderBy: "SortOrder");

            var dm_DonViTinhs = DBContext.GetRep<MT.Data.Rep.DM_DonViTinhRepository>().GetData(typeof(MT.Data.BO.DM_DonViTinh), "Id,sTenDonViTinh", orderBy: "SortOrder");
            //Sản phẩm
            grdSanPham.GrdDetail.TableName = "Phieu_XuatMuonTra_CT";
            grdSanPham.GrdDetail.ViewName = "View_Phieu_XuatMuonTra_CT";
            grdSanPham.GrdDetail.KeyName = "Id";
            grdSanPham.GrdDetail.SetField = "phieu_XuatMuonTra_CTs";
            grdSanPham.GrdDetail.FirstView.OptionsNavigation.EnterMoveNextColumn = true;
            grdSanPham.GrdDetail.DisableFieldNames = @"sDM_SanPham_Id,sDM_ChungThuSo_Id,sDM_MangLienLac_Id,sDM_SanPham_Id_Ten,rThanhTien,sDM_DonViTinh_Id,rSoLuong,dHanBaoHanhDen"; // Note

            grdSanPham.GrdDetail.ValidEditValueChanging = grdSanPham_ValidEditValueChanging;
            grdSanPham.IsRequired = true;
            grdSanPham.InvalidText = "Danh sách sản phẩm không được bỏ trống";
            grdSanPham.GrdDetail.FuncCustomRecordBeforeAddRow = GridSanPham_FuncCustomRecordBeforeAddRow;
            // Mã vạch
            var col = grdSanPham.GrdDetail.AddColumnText("sMaVach", "Mã vạch", 150, maxLength: 50,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left, isRequired: true);

            MRepositoryTextEdit colsMaVach = (MRepositoryTextEdit)col.ColumnEdit;
            colsMaVach.CustomEventEnter = grdSanPham_ColsMaVach_CustomEventEnter;

            /*col = grdSanPham.GrdDetail.AddColumnText("sDM_SanPham_Id", "Mã sản phẩm", 120, isFixWidth: true,
              fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left,
              dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);

            MRepositoryItemLookUpEdit colsDM_SanPham_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_SanPham_Id.AddColumn("sMaSanPham", "Mã sản phẩm", 150);
            colsDM_SanPham_Id.AddColumn("sTenSanPham", "Tên sản phẩm", 180);
            colsDM_SanPham_Id.DataSource = dm_SanPhams;
            colsDM_SanPham_Id.DisplayMember = "sMaSanPham";
            colsDM_SanPham_Id.ValueMember = "Id";*/

            col = grdSanPham.GrdDetail.AddColumnText("sDM_SanPham_Id_Ten", "Tên sản phẩm", 250, isRequired: true);// ten

            // Mạng LL
            /*col = grdSanPham.GrdDetail.AddColumnText("sDM_MangLienLac_Id", "Mạng liên lạc", 150, isFixWidth: true,
               //fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left,
               dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: false);

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

            ///Chứng thư số
            col = grdSanPham.GrdDetail.AddColumnText("sDM_ChungThuSo_Id", "Mã CTS", toolTip: "Mã chứng thư số", 150,
              dataType: MTControl.DataTypeColumn.LookUpEdit);

            MRepositoryItemLookUpEdit colsDM_ChungThuSo_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_ChungThuSo_Id.DictionaryName = "DM_ChungThuSo";
            colsDM_ChungThuSo_Id.AddColumn("sMaCTS", "Mã CTS", 120);
            colsDM_ChungThuSo_Id.DataSource = DBContext.GetRep<MT.Data.Rep.DM_ChungThuSoRepository>()
                .GetData(typeof(MT.Data.BO.DM_ChungThuSo), "Id,sMaCTS", orderBy: "sMaCTS"); ;
            colsDM_ChungThuSo_Id.DisplayMember = "sMaCTS";
            colsDM_ChungThuSo_Id.ValueMember = "Id";

           /* grdSanPham.GrdDetail.AddColumnText("rSoLuong", "Số lượng", 80, dataType: MTControl.DataTypeColumn.SpinEdit);
            grdSanPham.GrdDetail.AddColumnText("rDonGia", "Đơn giá", 150, dataType: MTControl.DataTypeColumn.SpinEdit);
            grdSanPham.GrdDetail.AddColumnText("rThanhTien", "Thành tiền", 150, dataType: MTControl.DataTypeColumn.SpinEdit);*/

            var colsSerial = grdSanPham.GrdDetail.AddColumnText("sSerial", "Số Serial", 150);
            colsSerial = grdSanPham.GrdDetail.AddColumnText("sSTTSP", "STT Sản phẩm", 150,
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

            col = grdSanPham.GrdDetail.AddColumnText("sKH_XuatMuonTra_CT_Id", "sKH_XuatMuonTra_CT_Id", 0);
            col.Visible = false;
        }

        /// <summary>
        /// Bắt event enter trên ô mã vạch
        /// </summary>
        /// <param name="mRepositoryTextEdit">Đối tượng trên grid</param>
        /// <param name="mTextEdit"></param>
        /// <returns>true: Cho phép custom, ngược lại không</returns>
        private bool grdSanPham_ColsMaVach_CustomEventEnter(MRepositoryTextEdit mRepositoryTextEdit, MTextEdit mTextEdit)
        {
            try
            {
                // PHẢI CHECK XEM MÃ CÓ NẰM TRONG KẾ HOẠCH HAY PHIẾU NHẬP KHÔNGNNNNNNNNNNNNNNNN

                //0002(Mã NCC) 0004(Mã SP) 00007(series) 21(Năm)
                if (mTextEdit.EditValue != null)
                {
                    string sMaVach = mTextEdit.EditValue.ToString();
                    if (!MT.Library.Utility.ValidsMaVach(sMaVach))
                    {
                        MMessage.ShowWarning("Mã vạch không hợp lệ");
                        return true;
                    }
                    // Note
                    // Lọc như này thì sản phẩm có thể đang tồn tại trong Phiếu xuất khác nhưng chưa được check ở đây.
                    //List<MT.Data.BO.Phieu_XuatMuonTra_CT> phieu_XuatMuonTra_CTs = grdSanPham.GrdDetail.GetAllData<MT.Data.BO.Phieu_XuatMuonTra_CT>();

                    // Truong Added 14.6:
                    List<MT.Data.BO.Phieu_XuatMuonTra_CT> phieu_XuatMuonTra_CTs_current = grdSanPham.GrdDetail.GetAllData<MT.Data.BO.Phieu_XuatMuonTra_CT>();

                    Phieu_XuatMuonTra_CT phieu_XuatMuonTra_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_XuatMuonTra_CT>();
                    // 1. Kiểm tra nếu mã vạch đã có trên danh sách rồi thì không cho nhập, cảnh báo trùng
                    MT.Data.BO.Phieu_XuatMuonTra_CT findBysMaVach_current = phieu_XuatMuonTra_CTs_current.Find(m => m.sMaVach.Equals(sMaVach) && m.Id != phieu_XuatMuonTra_CT.Id);
                    if (findBysMaVach_current != null)
                    {
                        MMessage.ShowWarning($"Mã vạch <{sMaVach}> đã tồn tại trên danh sách");

                        return true;
                    }

                    // 2. Tiếp theo kiểm tra tồn kho
                    bool checkTonKho = CommonFnUI.CheckTonKhoPhieu(this.FormAction, sMaVach, grdSanPham.GrdDetail.GetDataChanges(), MT.Library.SessionData.OrganizationUnitId);

                    if (!checkTonKho)
                    {
                        return true;
                    }

                    //TonKhoViewModel tonKhoViewModel = GhiSoKho.GetTonKho(sMaVach, MT.Library.SessionData.OrganizationUnitId);
                    //if (tonKhoViewModel == null || tonKhoViewModel.rSoLuongTon == 0)
                    //{
                    //    MMessage.ShowWarning($"Mã vạch <{sMaVach}> trong kho đã hết");
                    //    return true;
                    //}
                    //if (tonKhoViewModel.rSoLuongTon < 0)
                    //{
                    //    MMessage.ShowWarning($"Mã vạch <{sMaVach}> số lượng xuất đã vượt quá số lượng nhập với số lượng là {Math.Abs(tonKhoViewModel.rSoLuongTon)}.");
                    //    return true;
                    //}
                    string sMaSP = sMaVach.Substring(4, 4);
                    string sSerial = sMaVach.Substring(8, 5) + "/";
                    sSerial += sMaVach.Substring(13, 2);

                    //Cập nhật thông tin chứng thư số
                    var lkMaVachCTS = DBContext.GetRep2<LK_MaVach_CTSRepository>().GetLK_MaVach_CTSByMaVach(sMaVach);
                    if (lkMaVachCTS != null)
                    {
                        phieu_XuatMuonTra_CT.sDM_ChungThuSo_Id = lkMaVachCTS.sDM_ChungThuSo_Id;
                    }

                    //Cập nhật thông tin MLL
                    var lkMaVachMLL = DBContext.GetRep2<LK_MaVach_MLLRepository>().GetLK_MaVach_MLLByMaVach(sMaVach);
                    if (lkMaVachMLL != null)
                    {
                        phieu_XuatMuonTra_CT.sDM_MangLienLac_Id = lkMaVachMLL.sDM_MangLienLac_Id;
                    }

                    Guid? sKH_XuatMuonTra_Id = null;
                    if (cbossKH_XuatMuonTra_Id_CanCu.EditValue != null)
                        sKH_XuatMuonTra_Id = Guid.Parse(cbossKH_XuatMuonTra_Id_CanCu.EditValue.ToString());

                    // Trường hợp xuất đi ban đầu
                    if (cboEnumiLoaiTCXuat.SelectedIndex == 0)
                    {
                        if (sKH_XuatMuonTra_Id.HasValue)
                        {
                            KH_XuatMuonTra_CT kH_XuatMuonTra_CT = DBContext.GetRep2<KH_XuatMuonTra_CTRepository>()
                                                              .GetKH_XuatMuonTra_CTBysKH_XuatMuonTra_IdAndsMaSP(sKH_XuatMuonTra_Id, sMaSP);
                            if (kH_XuatMuonTra_CT == null)
                            {
                                MMessage.ShowWarning($@"Kế hoạch xuất <{cbossKH_XuatMuonTra_Id_CanCu.Text}> không tồn tại sản phẩm <{sMaSP}>");
                                return true;
                            }

                            //3. Kiểm tra sản phẩm đã nhập đủ so với kế hoạch chưa, nếu đủ rồi thì không cho nhập nữa
                            List<MT.Data.BO.Phieu_XuatMuonTra_CT> phieu_XuatMuonTra_CTs_others = DBContext.GetRep2<Phieu_XuatMuonTra_CTRepository>().GetAllPhieuXuatCT(MT.Library.SessionData.OrganizationUnitId, 32, kH_XuatMuonTra_CT.Id);
                            decimal sl_others = phieu_XuatMuonTra_CTs_others
                                .Where(m => m.sDM_SanPham_Id.Equals(kH_XuatMuonTra_CT.sDM_SanPham_Id) && m.Id != phieu_XuatMuonTra_CT.Id)
                                .Sum(m => m.rSoLuong);

                            decimal sl_current = phieu_XuatMuonTra_CTs_current
                                .Where(m => m.sDM_SanPham_Id.Equals(kH_XuatMuonTra_CT.sDM_SanPham_Id) && m.Id != phieu_XuatMuonTra_CT.Id)
                                .Sum(m => m.rSoLuong);
                            if (sl_others + sl_current >= kH_XuatMuonTra_CT.rSoLuong)
                            {
                                MMessage.ShowWarning($@"Sản phẩm <{kH_XuatMuonTra_CT.sDM_SanPham_Id_Ten}> đã nhập đủ so với kế hoạch");
                                return true;
                            }

                            //Lấy chi tiết phụ kiện theo kế hoạch
                            List<MT.Data.BO.KH_XuatMuonTra_CT_PhuKien> kH_XuatMuonTra_CT_PhuKiens = DBContext.GetRep2<Phieu_XuatMuonTra_CT_PhuKienRepository>()
                                                                                                        .GetKH_XuatMuonTra_CT_PhuKiensBysKH_XuatMuonTra_CT_Id(kH_XuatMuonTra_CT.Id);
                            List<MT.Data.BO.Phieu_XuatMuonTra_CT_PhuKien> phieu_XuatMuonTra_CT_PhuKiens = new List<Phieu_XuatMuonTra_CT_PhuKien>();
                            if (kH_XuatMuonTra_CT_PhuKiens != null)
                            {
                                foreach (var item in kH_XuatMuonTra_CT_PhuKiens)
                                {
                                    phieu_XuatMuonTra_CT_PhuKiens.Add(new Phieu_XuatMuonTra_CT_PhuKien
                                    {
                                        Id = Guid.NewGuid(),
                                        sDM_SanPham_Id = item.sDM_SanPham_Id,
                                        sDM_SanPham_Id_Ten = item.sDM_SanPham_Id_Ten,
                                        sDM_PhuKien_Id = item.sDM_PhuKien_Id,
                                        sDM_PhuKien_Id_Ten = item.sDM_PhuKien_Id_Ten,
                                        sDM_DonViTinh_Id = item.sDM_DonViTinh_Id,
                                        rSoLuong = item.rSoLuong,
                                        rDonGia = item.rDonGia,
                                        rThanhTien = item.rDonGia * item.rSoLuong,
                                        SortOrder = item.SortOrder,
                                        MTEntityState = Enummation.MTEntityState.Add
                                    });
                                }
                            }
                            phieu_XuatMuonTra_CT.phieu_XuatMuonTra_CT_PhuKiens = phieu_XuatMuonTra_CT_PhuKiens;
                            phieu_XuatMuonTra_CT.sKH_XuatMuonTra_CT_Id = kH_XuatMuonTra_CT.Id;
                            phieu_XuatMuonTra_CT.sKH_XuatMuonTra_Id = sKH_XuatMuonTra_Id;
                            phieu_XuatMuonTra_CT.sDM_SanPham_Id = kH_XuatMuonTra_CT.sDM_SanPham_Id;
                            phieu_XuatMuonTra_CT.sDM_DonViTinh_Id = kH_XuatMuonTra_CT.sDM_DonViTinh_Id;
                            phieu_XuatMuonTra_CT.rDonGia = kH_XuatMuonTra_CT.rDonGia;
                            phieu_XuatMuonTra_CT.rThanhTien = kH_XuatMuonTra_CT.rDonGia;
                            phieu_XuatMuonTra_CT.sDM_SanPham_Id_Ten = kH_XuatMuonTra_CT.sDM_SanPham_Id_Ten;
                            //phieu_XuatMuonTra_CT.sDM_MangLienLac_Id = kH_XuatMuonTra_CT.sDM_MangLienLac_Id;
                            //phieu_XuatMuonTra_CT.sDM_MangLienLac_Id_Ten = kH_XuatMuonTra_CT.sDM_MangLienLac_Id_Ten;

                            /*phieu_XuatMuonTra_CT.iThoiGianBaoHanh = kH_XuatMuonTra_CT.iThoiGianBaoHanh;
                            phieu_XuatMuonTra_CT.iDonViThoiGianBaoHanh = kH_XuatMuonTra_CT.iDonViThoiGianBaoHanh;
                            phieu_XuatMuonTra_CT.dHanBaoHanhDen = kH_XuatMuonTra_CT.dHanBaoHanhDen;
                            phieu_XuatMuonTra_CT.iNamSX = kH_XuatMuonTra_CT.iNamSX;*/
                            phieu_XuatMuonTra_CT.sXuatXu = kH_XuatMuonTra_CT.sXuatXu;
                            phieu_XuatMuonTra_CT.sGhiChu = kH_XuatMuonTra_CT.sGhiChu;
                        }
                        else
                        {
                            var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham), where: $"sMaSanPham='{sMaSP}'");
                            if (dm_SanPhams?.Count > 0)
                            {
                                DM_SanPham dM_SanPham = (DM_SanPham)dm_SanPhams[0];
                                phieu_XuatMuonTra_CT.sDM_SanPham_Id = dM_SanPham.Id;
                                phieu_XuatMuonTra_CT.sDM_DonViTinh_Id = dM_SanPham.sDM_DonViTinh_Id_Cap1;
                                phieu_XuatMuonTra_CT.rDonGia = dM_SanPham.rDonGia_Cap1;
                                phieu_XuatMuonTra_CT.rThanhTien = dM_SanPham.rDonGia_Cap1;
                                phieu_XuatMuonTra_CT.sDM_SanPham_Id_Ten = dM_SanPham.sTenSanPham;
                                List<DM_PhuKien> dM_PhuKiens = ((DM_PhuKienRepository)DBContext.GetRep<MT.Data.Rep.DM_PhuKienRepository>()).GetPhuKiensBysDM_SanPham_Id(dM_SanPham.Id);
                                List<MT.Data.BO.Phieu_XuatMuonTra_CT_PhuKien> phieu_XuatMuonTra_CT_PhuKiens = new List<Phieu_XuatMuonTra_CT_PhuKien>();
                                foreach (var item in dM_PhuKiens)
                                {
                                    phieu_XuatMuonTra_CT_PhuKiens.Add(new Phieu_XuatMuonTra_CT_PhuKien
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
                                phieu_XuatMuonTra_CT.phieu_XuatMuonTra_CT_PhuKiens = phieu_XuatMuonTra_CT_PhuKiens;


                                phieu_XuatMuonTra_CT.sKH_XuatMuonTra_CT_Id = null;
                                phieu_XuatMuonTra_CT.sKH_XuatMuonTra_Id = null;
                            }
                        }

                        phieu_XuatMuonTra_CT.IsLoaded = true;
                        phieu_XuatMuonTra_CT.sSerial = sSerial;
                        phieu_XuatMuonTra_CT.sSTTSP = string.Empty;
                        phieu_XuatMuonTra_CT.rSoLuong = 1;
                    }
                    else // Trường hợp xuất trả về sau khi mượn
                    {
                        if (sKH_XuatMuonTra_Id.HasValue)
                        {
                            Phieu_NhapMuonTra_CT phieu_NhapMuonTra_CT = DBContext.GetRep2<Phieu_NhapMuonTra_CTRepository>()
                                                               .GetPhieu_NhapMuonTra_CTBysPhieu_NhapMuonTra_IdAndsMaSP(sKH_XuatMuonTra_Id, sMaSP);
                            if (phieu_NhapMuonTra_CT == null)
                            {
                                MMessage.ShowWarning($@"Phiếu nhập <{cbossKH_XuatMuonTra_Id_CanCu.Text}> không tồn tại sản phẩm <{sMaSP}>");
                                return true;
                            }

                            //Lấy chi tiết phụ kiện theo kế hoạch
                            List<MT.Data.BO.Phieu_NhapMuonTra_CT_PhuKien> phieu_NhapMuonTra_CT_PhuKiens = DBContext.GetRep2<Phieu_NhapMuonTra_CT_PhuKienRepository>()
                                                                                                        .GetPhieu_NhapMuonTra_CT_PhuKiensBysPhieu_NhapMuonTra_CT_Id(phieu_NhapMuonTra_CT.Id);
                            List<MT.Data.BO.Phieu_XuatMuonTra_CT_PhuKien> phieu_XuatMuonTra_CT_PhuKiens = new List<Phieu_XuatMuonTra_CT_PhuKien>();
                            if (phieu_NhapMuonTra_CT_PhuKiens != null)
                            {
                                foreach (var item in phieu_NhapMuonTra_CT_PhuKiens)
                                {
                                    phieu_XuatMuonTra_CT_PhuKiens.Add(new Phieu_XuatMuonTra_CT_PhuKien
                                    {
                                        Id = Guid.NewGuid(),
                                        sDM_SanPham_Id = item.sDM_SanPham_Id,
                                        sDM_SanPham_Id_Ten = item.sDM_SanPham_Id_Ten,
                                        sDM_PhuKien_Id = item.sDM_PhuKien_Id,
                                        sDM_PhuKien_Id_Ten = item.sDM_PhuKien_Id_Ten,
                                        sDM_DonViTinh_Id = item.sDM_DonViTinh_Id,
                                        rSoLuong = item.rSoLuong,
                                        rDonGia = item.rDonGia,
                                        rThanhTien = item.rDonGia * item.rSoLuong,
                                        SortOrder = item.SortOrder,
                                        MTEntityState = Enummation.MTEntityState.Add
                                    });
                                }
                            }

                            phieu_XuatMuonTra_CT.phieu_XuatMuonTra_CT_PhuKiens = phieu_XuatMuonTra_CT_PhuKiens;
                            phieu_XuatMuonTra_CT.sKH_XuatMuonTra_CT_Id = phieu_NhapMuonTra_CT.Id;
                            phieu_XuatMuonTra_CT.sKH_XuatMuonTra_Id = sKH_XuatMuonTra_Id;
                            phieu_XuatMuonTra_CT.sDM_SanPham_Id = phieu_NhapMuonTra_CT.sDM_SanPham_Id;
                            phieu_XuatMuonTra_CT.sDM_DonViTinh_Id = phieu_NhapMuonTra_CT.sDM_DonViTinh_Id;
                            phieu_XuatMuonTra_CT.rDonGia = phieu_NhapMuonTra_CT.rDonGia;
                            phieu_XuatMuonTra_CT.rThanhTien = phieu_NhapMuonTra_CT.rDonGia;
                            phieu_XuatMuonTra_CT.sDM_SanPham_Id_Ten = phieu_NhapMuonTra_CT.sDM_SanPham_Id_Ten;
                            //phieu_XuatMuonTra_CT.sDM_MangLienLac_Id = phieu_NhapMuonTra_CT.sDM_MangLienLac_Id;
                            //phieu_XuatMuonTra_CT.sDM_MangLienLac_Id_Ten = phieu_NhapMuonTra_CT.sDM_MangLienLac_Id_Ten;

                            /*phieu_XuatMuonTra_CT.iThoiGianBaoHanh = phieu_NhapMuonTra_CT.iThoiGianBaoHanh;
                            phieu_XuatMuonTra_CT.iDonViThoiGianBaoHanh = phieu_NhapMuonTra_CT.iDonViThoiGianBaoHanh;
                            phieu_XuatMuonTra_CT.dHanBaoHanhDen = phieu_NhapMuonTra_CT.dHanBaoHanhDen;
                            phieu_XuatMuonTra_CT.iNamSX = phieu_NhapMuonTra_CT.iNamSX;*/
                            phieu_XuatMuonTra_CT.sXuatXu = phieu_NhapMuonTra_CT.sXuatXu;
                            phieu_XuatMuonTra_CT.sGhiChu = phieu_NhapMuonTra_CT.sGhiChu;
                            phieu_XuatMuonTra_CT.sSTTSP = phieu_NhapMuonTra_CT.sSTTSP;
                        }
                        else
                        {
                            var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham), where: $"sMaSanPham='{sMaSP}'");
                            if (dm_SanPhams?.Count > 0)
                            {
                                DM_SanPham dM_SanPham = (DM_SanPham)dm_SanPhams[0];
                                phieu_XuatMuonTra_CT.sDM_SanPham_Id = dM_SanPham.Id;
                                phieu_XuatMuonTra_CT.sDM_DonViTinh_Id = dM_SanPham.sDM_DonViTinh_Id_Cap1;
                                phieu_XuatMuonTra_CT.rDonGia = dM_SanPham.rDonGia_Cap1;
                                phieu_XuatMuonTra_CT.rThanhTien = dM_SanPham.rDonGia_Cap1;
                                phieu_XuatMuonTra_CT.sDM_SanPham_Id_Ten = dM_SanPham.sTenSanPham;
                                List<DM_PhuKien> dM_PhuKiens = ((DM_PhuKienRepository)DBContext.GetRep<MT.Data.Rep.DM_PhuKienRepository>()).GetPhuKiensBysDM_SanPham_Id(dM_SanPham.Id);
                                List<MT.Data.BO.Phieu_XuatMuonTra_CT_PhuKien> phieu_XuatMuonTra_CT_PhuKiens = new List<Phieu_XuatMuonTra_CT_PhuKien>();
                                foreach (var item in dM_PhuKiens)
                                {
                                    phieu_XuatMuonTra_CT_PhuKiens.Add(new Phieu_XuatMuonTra_CT_PhuKien
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
                                phieu_XuatMuonTra_CT.phieu_XuatMuonTra_CT_PhuKiens = phieu_XuatMuonTra_CT_PhuKiens;
                               
                                phieu_XuatMuonTra_CT.sSTTSP = string.Empty;

                                phieu_XuatMuonTra_CT.sKH_XuatMuonTra_CT_Id = null;
                                phieu_XuatMuonTra_CT.sKH_XuatMuonTra_Id = null;
                            }
                        }

                        phieu_XuatMuonTra_CT.IsLoaded = true;
                        phieu_XuatMuonTra_CT.rSoLuong = 1;
                        phieu_XuatMuonTra_CT.sSerial = sSerial;
                    }

                    // Truong 2022
                    var dm_Phieu_NhapSanPhamMois = DBContext.GetRep<MT.Data.Rep.Phieu_NhapSanPhamMoi_CTRepository>().GetData(typeof(MT.Data.BO.Phieu_NhapSanPhamMoi_CT),
                        columns: "iThoiGianBaoHanh,iDonViThoiGianBaoHanh,iNamSX,dHanBaoHanhDen",
                        viewName: "View_Phieu_NhapSanPhamMoi_CT",
                        where: $"sMaVach='{sMaVach}'");
                    if (dm_Phieu_NhapSanPhamMois != null && dm_Phieu_NhapSanPhamMois.Count == 1)
                    {
                        Phieu_NhapSanPhamMoi_CT curPNM = (Phieu_NhapSanPhamMoi_CT)dm_Phieu_NhapSanPhamMois[0];
                        phieu_XuatMuonTra_CT.iThoiGianBaoHanh = curPNM.iThoiGianBaoHanh;
                        phieu_XuatMuonTra_CT.iDonViThoiGianBaoHanh = curPNM.iDonViThoiGianBaoHanh;
                        phieu_XuatMuonTra_CT.iNamSX = curPNM.iNamSX;
                        phieu_XuatMuonTra_CT.dHanBaoHanhDen = curPNM.dHanBaoHanhDen;
                    }
                    //Từ động thêm dòng tiếp theo
                    grdSanPham.GrdDetail.AddRow(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(SessionData.ERROR);
            }

            return true;
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
            /*if (cbossKH_XuatMuonTra_Id_CanCu.EditValue == null)
            {
                ActiveControl = cbossKH_XuatMuonTra_Id_CanCu;
                MMessage.ShowWarning("Bạn phải xác định phiếu nhập căn cứ theo kế hoạch nào.");
                return false;
            }*/

            if (gridColumn.FieldName == "sSTTSP" && e.NewValue != null && !object.Equals(e.OldValue, e.NewValue))
            {
                string[] arrSerial = e.NewValue.ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Phieu_XuatMuonTra_CT phieu_XuatMuonTra = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_XuatMuonTra_CT>();
                if (arrSerial.Length > 0 && (decimal)arrSerial.Length > phieu_XuatMuonTra.rSoLuong)
                {
                    e.NewValue = string.Empty;
                    MMessage.ShowWarning($"Bạn chỉ được phép chọn tối đa {(int)phieu_XuatMuonTra.rSoLuong} số serial");
                    return false;
                }
            }
            // truong
            /*if (gridColumn.FieldName == "sMaVach" && e.NewValue != null && !object.Equals(e.OldValue, e.NewValue))
            {
                SoKhoRepository soKhoRepository = DBContext.GetRep2<SoKhoRepository>();
                List<MT.Data.BO.SoKho> soKho = (List<SoKho>)soKhoRepository.GetLichSuXuatNhapSP(e.NewValue.ToString());
                // Kiểm tra tiếp xem mã vạch có tồn tại trong SoKho hay không
                MT.Data.BO.SoKho findInSoKho = soKho.Find(m => m.sMaVach.Equals(e.NewValue.ToString()) && (m.iLoaiPhieu.Equals(12) || m.iLoaiPhieu.Equals(33))); // 12: Phiếu nhập mới
                if (findInSoKho == null)
                {
                    e.NewValue = string.Empty;
                    MMessage.ShowWarning($"Mã vạch chưa tồn tại trong kho");
                    return false;
                }
            }*/

            return true;
        }

        /// <summary>
        /// Bắt hành động gán giá trị default cho cột grid
        /// </summary>
        /// <returns>=true cho addnewrow, ngược lại ko</returns>
        private bool GridSanPham_FuncCustomRecordBeforeAddRow(object newRecord, MGridControl mGridControl)
        {
            Phieu_XuatMuonTra_CT phieu_XuatMuonTra_CT = (Phieu_XuatMuonTra_CT)newRecord;
            if (phieu_XuatMuonTra_CT.sDM_SanPham_Id.HasValue
                && !phieu_XuatMuonTra_CT.sDM_SanPham_Id.Value.Equals(Guid.Empty))
            {
                if (cbossKH_XuatMuonTra_Id_CanCu.EditValue == null)
                {
                    ActiveControl = cbossKH_XuatMuonTra_Id_CanCu;
                    MMessage.ShowWarning("Bạn phải xác định phiếu xuất căn cứ theo kế hoạch nào.");
                    return false;
                }

                Guid sKH_XuatMuonTra_Id_CanCu = Guid.Parse(cbossKH_XuatMuonTra_Id_CanCu.EditValue.ToString());

                //Có sản phẩm thì lấy giá trị mặc định
                var kH_XuatMuonTra_CT = GetKH_XuatMuonTra_CTByIdAndsDM_SanPham_Id(sKH_XuatMuonTra_Id_CanCu,
                    phieu_XuatMuonTra_CT.sDM_SanPham_Id.Value, phieu_XuatMuonTra_CT);

                if (kH_XuatMuonTra_CT != null)
                {
                    phieu_XuatMuonTra_CT.sDM_SanPham_Id_Ten = kH_XuatMuonTra_CT.sDM_SanPham_Id_Ten;
                    phieu_XuatMuonTra_CT.sDM_DonViTinh_Id = kH_XuatMuonTra_CT.sDM_DonViTinh_Id;
                    phieu_XuatMuonTra_CT.rSoLuong = kH_XuatMuonTra_CT.rSoLuong;
                    phieu_XuatMuonTra_CT.rDonGia = kH_XuatMuonTra_CT.rDonGia;
                    phieu_XuatMuonTra_CT.rThanhTien = kH_XuatMuonTra_CT.rSoLuong * kH_XuatMuonTra_CT.rDonGia;

                    phieu_XuatMuonTra_CT.sSerial = string.Empty;
                    phieu_XuatMuonTra_CT.iThoiGianBaoHanh = 60;
                    phieu_XuatMuonTra_CT.iDonViThoiGianBaoHanh = (int)MT.Data.iDonViThoiGianHieuLuc.Ngay;
                    phieu_XuatMuonTra_CT.sCauHinhKyThuat = kH_XuatMuonTra_CT.sCauHinhKyThuat;
                    phieu_XuatMuonTra_CT.sXuatXu = kH_XuatMuonTra_CT.sXuatXu;
                    phieu_XuatMuonTra_CT.iNamSX = kH_XuatMuonTra_CT.iNamSX;
                    phieu_XuatMuonTra_CT.sKH_XuatMuonTra_CT_Id = kH_XuatMuonTra_CT.Id;
                    phieu_XuatMuonTra_CT.dHanBaoHanhDen = SysDateTime.Instance.Now().AddDays(60);
                }
            }
            return true;
        }

        /// <summary>
        /// Hàm lấy về chi tiết kế hoạch sản phẩm
        /// </summary>
        /// <param name="sKH_XuatMuonTra_Id_CanCu">Căn cứ kế hoạch</param>
        /// <param name="sDM_SanPham_Id">Id sản phẩm</param>
        /// <param name="phieu_XuatMuonTra_CT">Chi tiết sản phẩm nhập mới</param>
        /// <returns></returns>
        private KH_XuatMuonTra_CT GetKH_XuatMuonTra_CTByIdAndsDM_SanPham_Id(Guid sKH_XuatMuonTra_Id_CanCu, Guid sDM_SanPham_Id, Phieu_XuatMuonTra_CT phieu_XuatMuonTra_CT)
        {
            List<Phieu_XuatMuonTra_CT> phieu_XuatMuonTra_CTs = grdSanPham.GrdDetail.GetAllData<Phieu_XuatMuonTra_CT>();

            var H_XuatMuonTra_CT = DBContext.GetRep2<KH_XuatMuonTra_CTRepository>()
                .GetKH_XuatMuonTra_CTBysKH_XuatMuonTra_IdAndsDM_SanPham_Id(sKH_XuatMuonTra_Id_CanCu,
                sDM_SanPham_Id, phieu_XuatMuonTra_CT.sDM_DonViTinh_Id, phieu_XuatMuonTra_CT.Id);
            decimal rSoluong = 0;
            if (phieu_XuatMuonTra_CTs != null && phieu_XuatMuonTra_CTs.Count > 0)
            {
                rSoluong = phieu_XuatMuonTra_CTs.FindAll(m => m.sKH_XuatMuonTra_CT_Id == H_XuatMuonTra_CT.Id && m.Id != phieu_XuatMuonTra_CT.Id).Sum(m => m.rSoLuong);
            }
            if (H_XuatMuonTra_CT != null)
            {
                H_XuatMuonTra_CT.rSoLuong = H_XuatMuonTra_CT.rSoLuong - rSoluong;
                if (H_XuatMuonTra_CT.rSoLuong <= 0)
                {
                    H_XuatMuonTra_CT.rSoLuong = 0;
                }
                if (H_XuatMuonTra_CT.IsShowSoSerial && H_XuatMuonTra_CT.rSoLuong > H_XuatMuonTra_CT.iKichThuocDongGoi)
                {
                    H_XuatMuonTra_CT.rSoLuong = H_XuatMuonTra_CT.iKichThuocDongGoi;
                }
                H_XuatMuonTra_CT.rThanhTien = H_XuatMuonTra_CT.rSoLuong * H_XuatMuonTra_CT.rDonGia;
            }

            return H_XuatMuonTra_CT;
        }

        /// <summary>
        /// Click hiển thị form nhập chi tiết phụ kiện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColsActionPhuKien_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //Bắt bắt chọn sản phẩm roh thì mới cho nhập phụ kiện
            var phieu_XuatMuonTra_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_XuatMuonTra_CT>();
            if (phieu_XuatMuonTra_CT.sDM_SanPham_Id.HasValue && !phieu_XuatMuonTra_CT.sDM_SanPham_Id.Value.Equals(Guid.Empty))
            {
                //frmPhieu_XuatMuonTra_CT_PhuKienDetail frmPhieu_XuatMuonTra_CT_PhuKienDetail = new frmPhieu_XuatMuonTra_CT_PhuKienDetail(grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_XuatMuonTra_CT>());
                frmPhuKienDetail frmPhuKienDetail = new frmPhuKienDetail(phieu_XuatMuonTra_CT.sDM_SanPham_Id.Value,
                    "Phieu_XuatMuonTra_CT_PhuKien", "phieu_XuatMuonTra_CT_PhuKiens", phieu_XuatMuonTra_CT, this);
                frmPhuKienDetail.ShowDialog();
            }
            else
            {
                MMessage.ShowWarning("Bạn phải chọn sản phẩm trước khi nhập thông tin chi tiết phụ kiện");
            }
        }

        #endregion

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
            configReport.RepName = "Print_Phieu_XuatMuonTra_DetailRepository";
            //Định danh mẫu in trong bảng ReportData
            configReport.DictionaryKey = MT.Data.ReportDictionaryKey.RP_Print_Phieu_XuatMuonTraDetail;

            //Danh sách các cột trên table
            configExcel.ShowColumnsOrder = new HashSet<string>
            {
                "sSTT","sDM_SanPham_Id_Ten","sDM_DonViTinh_Id_Ten","rSoLuong",
                "sXuatXu","iNamSX","iThoiGianBaoHanh"
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
                List<MT.Data.BO.Phieu_XuatMuonTra_CT> phieu_XuatMuonTra_CTs = mGridEditable.GrdDetail.GetAllData<MT.Data.BO.Phieu_XuatMuonTra_CT>();

                foreach (var item in dataChanged)
                {
                    var castItem = (MT.Data.BO.Phieu_XuatMuonTra_CT)item;
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
                        && string.IsNullOrWhiteSpace(castItem.sSTTSP))
                    {
                        isValid = false;
                        mGridEditable.GrdDetail.FirstView.FocusedColumn = mGridEditable.GrdDetail.FirstView.Columns["sSTTSP"];
                        mGridEditable.GrdDetail.FirstView.FocusedRowHandle = castItem.RowHandle;
                        MMessage.ShowWarning($"Bạn phải chọn số serial cho sản phẩm <{castItem.sDM_SanPham_Id_Ten}>, đơn vị tính <{dM_DonViTinh.sTenDonViTinh}>");
                        break;
                    }

                    //3. Cột mã vạch không được trùng nhau
                    if (isValid && phieu_XuatMuonTra_CTs != null && phieu_XuatMuonTra_CTs.Count > 0)
                    {
                        //Kiểm tra mã vạch có bị trùng hay không
                        MT.Data.BO.Phieu_XuatMuonTra_CT findBysMaVach = phieu_XuatMuonTra_CTs.Find(m => m.sMaVach.Equals(castItem.sMaVach) && m.Id != castItem.Id);
                        if (findBysMaVach != null)
                        {
                            isValid = false;
                            mGridEditable.GrdDetail.FirstView.FocusedColumn = mGridEditable.GrdDetail.FirstView.Columns["sMaVach"];
                            mGridEditable.GrdDetail.FirstView.FocusedRowHandle = castItem.RowHandle;
                            MMessage.ShowWarning($"Mã vạch <{castItem.sMaVach}> của sản phẩm <{castItem.sDM_SanPham_Id_Ten}>, đơn vị tính <{dM_DonViTinh.sTenDonViTinh}> đã tồn tại");
                            break;
                        }
                       /* else
                        {
                            SoKhoRepository soKhoRepository = DBContext.GetRep2<SoKhoRepository>();
                            List<MT.Data.BO.SoKho> soKho = (List<SoKho>)soKhoRepository.GetLichSuXuatNhapSP(castItem.sMaVach);
                            // Kiểm tra tiếp xem mã vạch có tồn tại trong SoKho hay không
                            MT.Data.BO.SoKho findInSoKho = soKho.Find(m => m.sMaVach.Equals(castItem.sMaVach) && (m.iLoaiPhieu.Equals(12) || m.iLoaiPhieu.Equals(33))); // 12: Phiếu nhập mới|| Nhập mượn
                            if (findInSoKho == null)
                            {
                                isValid = false;
                                mGridEditable.GrdDetail.FirstView.FocusedColumn = mGridEditable.GrdDetail.FirstView.Columns["sMaVach"];
                                mGridEditable.GrdDetail.FirstView.FocusedRowHandle = castItem.RowHandle;
                                MMessage.ShowWarning($"Mã vạch <{castItem.sMaVach}> của sản phẩm <{castItem.sDM_SanPham_Id_Ten}>, đơn vị tính <{dM_DonViTinh.sTenDonViTinh}> không tồn tại trong kho");
                                break;
                            }
                        }*/
                    }
                }
            }
            return isValid;
        }

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
                case "Phieu_XuatMuonTra_CT":
                    // Noteeeeeeeee
                    if (e.Column.FieldName == "sSTTSP")
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
                                List<string> sSTTSPs = new List<string>();
                                for (int i = 1; i <= dM_SanPham.iKichThuocDongGoi; i++)
                                {
                                    sSTTSPs.Add(i.ToString());
                                }
                                mRepositoryItemChecked.DataSource = sSTTSPs;
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
                        //MT.Data.BO.Phieu_XuatMuonTra curMaster = (MT.Data.BO.Phieu_XuatMuonTra)this.CurrentData;
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
                case "Phieu_XuatMuonTra_CT":
                    Phieu_XuatMuonTra_CT phieu_XuatMuonTra_CT = mGridControl.GetRecordByRowSelected<Phieu_XuatMuonTra_CT>();
                    if (e.Column.FieldName == "sDM_SanPham_Id")
                    {
                        //gán mặc định đơn vị tính cấp 1 cho sản phẩm
                        if (mGridControl.FuncCustomRecordBeforeAddRow != null)
                        {
                            mGridControl.FuncCustomRecordBeforeAddRow(phieu_XuatMuonTra_CT, mGridControl);
                        }
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
                        phieu_XuatMuonTra_CT.rThanhTien = phieu_XuatMuonTra_CT.rSoLuong * phieu_XuatMuonTra_CT.rDonGia;
                        //phieu_XuatMuonTra_CT = mGridControl.GetRecordByRowSelected<Phieu_XuatMuonTra_CT>();
                        //mGridControl.FirstView.SetRowCellValue(e.RowHandle, "rThanhTien", phieu_XuatMuonTra_CT.rSoLuong * phieu_XuatMuonTra_CT.rDonGia);
                    }
                    if (e.Column.FieldName == "sSTTSP")
                    {
                        object objsSTTSP = e.Value;
                        if (objsSTTSP != null)
                        {
                            string[] arrSerial = objsSTTSP.ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (arrSerial.Length >= 1)
                            {
                                phieu_XuatMuonTra_CT.rSoLuong = arrSerial.Length;
                            }
                        }
                    }
                    var now = SysDateTime.Instance.Now();
                    if (e.Column.FieldName == "iThoiGianBaoHanh" || e.Column.FieldName == "iDonViThoiGianBaoHanh")
                    {
                        DateTime? dHanBaoHanhDen = null;
                        switch (phieu_XuatMuonTra_CT.iDonViThoiGianBaoHanh)
                        {
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Ngay:
                                dHanBaoHanhDen = now.AddDays(phieu_XuatMuonTra_CT.iThoiGianBaoHanh).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Thang:
                                dHanBaoHanhDen = now.AddMonths(phieu_XuatMuonTra_CT.iThoiGianBaoHanh).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Quy:
                                dHanBaoHanhDen =now.AddYears(phieu_XuatMuonTra_CT.iThoiGianBaoHanh * 3).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Nam:
                                dHanBaoHanhDen = now.AddYears(phieu_XuatMuonTra_CT.iThoiGianBaoHanh).AddDays(1);
                                break;
                        }
                        phieu_XuatMuonTra_CT.dHanBaoHanhDen = dHanBaoHanhDen;
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
                    cbossKH_XuatMuonTra_Id_CanCu.SetReadOnly(false);
                    break;

                default:
                    cbossKH_XuatMuonTra_Id_CanCu.SetReadOnly(true);
                    break;
            }

            cbosDM_CanBo_Id_NguoiLapPhieu.SetReadOnly(true);
        }

        /// <summary>
        /// Xử lý dữ liệu trước khi binding lên form
        /// </summary>
        /// <returns></returns>
        protected override BaseEntity PrepareDataBeforeBindDataForm()
        {
            var currentData = (Phieu_XuatMuonTra)base.PrepareDataBeforeBindDataForm();
            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:
                    currentData.dNgayPhieu_Xuat = SysDateTime.Instance.Now();
                    currentData.sDM_DonVi_Id_Xuat = MT.Library.SessionData.OrganizationUnitId;
                    currentData.sDM_CanBo_Id_NguoiLapPhieu = MT.Library.SessionData.UserId;
                    currentData.sDM_CanBo_Id_NguoiGiao = MT.Library.SessionData.UserId;
                    currentData.sKH_XuatMuonTra_Id_CanCu = null;
                    //currentData.iNhapVeKho = true;
                    break;
            }

            return currentData;
        }

        #endregion

        private void cbosDM_KeHoachXuat_EditValueChanged(object sender, EventArgs e)
        {
            switch (this.FormAction)//cbosDM_KeHoachXuat
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:
                    if (cboEnumiLoaiTCXuat.SelectedIndex == 0)
                    {
                        MT.Data.BO.KH_XuatMuonTra kH_XuatMuonTra = cbossKH_XuatMuonTra_Id_CanCu.GetRecordSelected<MT.Data.BO.KH_XuatMuonTra>();
                        if (kH_XuatMuonTra != null)
                        {
                            // Thiết lập giá trị mặc định cho đơn vị xuất
                            Guid maDVXuat = kH_XuatMuonTra.sDM_DonVi_Id_DonViXuat;
                            treesDM_DonVi_Id_DonViXuat.SetValue(maDVXuat);

                            // Thiết lập giá trị mặc định cho đơn vị nhập
                            Guid maDVNhap = kH_XuatMuonTra.sDM_DonVi_Id_DonViNhap;
                            treesDM_DonVi_Id_DonViNhap.SetValue(maDVNhap);
                            // Thiết lập lọc người nhận thuộc đơn vị nhận
                            // Nguoi nhan
                            object sDM_Donvi_Id_nhan = treesDM_DonVi_Id_DonViNhap.GetValue();
                            // cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                            //columns: "Id,sMaCanBo,sTenCanBo", where: $"sDM_DonVi_Id='{sDM_Donvi_Id_nhan.ToString()}'", orderBy: "sMaCanBo");
                            if (sDM_Donvi_Id_nhan != null)
                            {
                                cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                                   columns: "Id,sMaCanBo,sTenCanBo",
                                   where: $"sDM_DonVi_Id='{sDM_Donvi_Id_nhan.ToString()}' and iDictionaryKey NOT IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong},{(int)MT.Data.iChucVu.CucTruong},{(int)MT.Data.iChucVu.PhoCucTruong})",
                                   orderBy: "sMaCanBo",
                                   viewName: "View_DM_CanBo");
                                //var datas = DBContext.GetRep2<Phieu_XuatMuonTra_CTRepository>().GetKHXuatMuonTra_CTsByMasterId(kH_XuatMuonTra.Id);
                                // grdSanPham.GrdDetail.LoadData(datas);
                            }
                        }
                    }
                    else
                    {
                        MT.Data.BO.Phieu_NhapMuonTra phieu_NhapMuonTra = cbossKH_XuatMuonTra_Id_CanCu.GetRecordSelected<MT.Data.BO.Phieu_NhapMuonTra>();
                        if (phieu_NhapMuonTra != null)
                        {
                            // Thiết lập giá trị mặc định cho đơn vị xuất
                            Guid maDVXuat = phieu_NhapMuonTra.sDM_DonVi_Id_Xuat;
                            // Thiết lập giá trị mặc định cho đơn vị nhập
                            Guid maDVNhap = phieu_NhapMuonTra.sDM_DonVi_Id_Nhap;

                            treesDM_DonVi_Id_DonViNhap.SetValue(maDVXuat);
                            treesDM_DonVi_Id_DonViXuat.SetValue(maDVNhap);

                            // Nguoi nhan
                            object sDM_Donvi_Id_nhan = treesDM_DonVi_Id_DonViNhap.GetValue();

                            cbosDM_CanBo_Id_NguoiNhap.Properties.DisplayMember = "sTenCanBo";
                            cbosDM_CanBo_Id_NguoiNhap.Properties.ValueMember = "Id";
                            cbosDM_CanBo_Id_NguoiNhap.AddColumn("sTenCanBo", "Tên", 180, true);
                            if (sDM_Donvi_Id_nhan == null)
                                cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                                columns: "Id,sMaCanBo,sTenCanBo", orderBy: "sMaCanBo");
                            else
                                cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                                columns: "Id,sMaCanBo,sTenCanBo",
                                where: $"sDM_DonVi_Id='{sDM_Donvi_Id_nhan.ToString()}' and iDictionaryKey NOT IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong},{(int)MT.Data.iChucVu.CucTruong},{(int)MT.Data.iChucVu.PhoCucTruong})",
                                orderBy: "sMaCanBo",
                                viewName: "View_DM_CanBo");
                        }
                    }

                    break;
            }
        }

        // 14.6
        private void cbossKH_XuatMuonTra_Id_CanCu_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (cboEnumiLoaiTCXuat.SelectedIndex == 1)
            {
                cbossKH_XuatMuonTra_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.Phieu_NhapMuonTraRepository>().GetData(typeof(MT.Data.BO.Phieu_NhapMuonTra),
                columns: "Id,sMa,dNgayPhieu_Nhap,sDM_DonVi_Id_Xuat_Ten, sDM_DonVi_Id_Nhap, sDM_DonVi_Id_Xuat",
                where: $"sDM_DonVi_Id_Nhap ='{MT.Library.SessionData.OrganizationUnitId}' AND iTrangThaiThucHien < {(int)MT.Data.iTrangThaiThucHienKHNM.DaHoanThanh}",
                orderBy: "sSo DESC", viewName: "View_Phieu_NhapMuonTra");
                linkFormVoucher.VoucherId = null;
                linkFormVoucher.ControlVoucher = cbossKH_XuatMuonTra_Id_CanCu;
                linkFormVoucher.TableName = "Phieu_NhapMuonTra";
            }
            else
            {
                cbossKH_XuatMuonTra_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.KH_XuatMuonTraRepository>().GetData(typeof(MT.Data.BO.KH_XuatMuonTra),
                    columns: "Id,sMa,dNgayKeHoach,sDM_DonVi_Id_DonViXayDungKH_Ten,sDM_DonVi_Id_DonViXuat_Ten, sDM_DonVi_Id_DonViXuat, sDM_DonVi_Id_DonViNhap",
                    where: $"iTrangThaiDuyet=1 AND iTrangThaiThucHienKHNM < {(int)MT.Data.iTrangThaiThucHienKHNM.DaHoanThanh} AND sDM_DonVi_Id_DonViXuat ='{MT.Library.SessionData.OrganizationUnitId}'",
                    orderBy: "sSo DESC", viewName: "View_KH_XuatMuonTra");
                linkFormVoucher.VoucherId = null;
                linkFormVoucher.ControlVoucher = cbossKH_XuatMuonTra_Id_CanCu;
                linkFormVoucher.TableName = "KH_XuatMuonTra";
            }
        }

        // 14.6
        private void treesDM_DonVi_Id_DonViNhap_EditValueChanged(object sender, EventArgs e)
        {
            object sDM_Donvi_Id_nhan = treesDM_DonVi_Id_DonViNhap.GetValue();
            if (sDM_Donvi_Id_nhan == null)
                cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id,sMaCanBo,sTenCanBo", orderBy: "sMaCanBo");
            else
                cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id,sMaCanBo,sTenCanBo",
                where: $"sDM_DonVi_Id='{sDM_Donvi_Id_nhan.ToString()}' and iDictionaryKey NOT IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong},{(int)MT.Data.iChucVu.CucTruong},{(int)MT.Data.iChucVu.PhoCucTruong})",
                orderBy: "sMaCanBo",
                viewName: "View_DM_CanBo");
        }

        private void cboEnumiLoaiTCXuat_EditValueChanged(object sender, EventArgs e)
        {
            if (this.CurrentData == null)
            {
                return;
            }

            cbossKH_XuatMuonTra_Id_CanCu.CleadAllColumn();
            if (cboEnumiLoaiTCXuat.SelectedIndex == 1)
            {
                cbossKH_XuatMuonTra_Id_CanCu.Properties.DisplayMember = "sMa";
                cbossKH_XuatMuonTra_Id_CanCu.Properties.ValueMember = "Id";
                cbossKH_XuatMuonTra_Id_CanCu.AddColumn("sMa", "Số phiếu nhập", 120);
                cbossKH_XuatMuonTra_Id_CanCu.AddColumn("dNgayPhieu_Nhap", "Ngày mượn", 80);
                cbossKH_XuatMuonTra_Id_CanCu.AddColumn("sDM_DonVi_Id_Xuat_Ten", "Đơn vị cho mượn", 120);
                //cbossKH_XuatMuonTra_Id_CanCu.AddColumn("iThoiGianHieuLuc", "Thời gian hiệu lực", 120, true);
                cbossKH_XuatMuonTra_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.Phieu_NhapMuonTraRepository>().GetData(typeof(MT.Data.BO.Phieu_NhapMuonTra),
                    columns: "Id,sMa,dNgayPhieu_Nhap,sDM_DonVi_Id_Xuat_Ten, sDM_DonVi_Id_Nhap, sDM_DonVi_Id_Xuat",
                    where: $"sDM_DonVi_Id_Nhap ='{MT.Library.SessionData.OrganizationUnitId}' AND iTrangThaiThucHien < {(int)MT.Data.iTrangThaiThucHienKHNM.DaHoanThanh}",
                    orderBy: "sSo DESC", viewName: "View_Phieu_NhapMuonTra");
            }
            else
            {
                cbossKH_XuatMuonTra_Id_CanCu.Properties.DisplayMember = "sMa";
                cbossKH_XuatMuonTra_Id_CanCu.Properties.ValueMember = "Id";
                cbossKH_XuatMuonTra_Id_CanCu.AddColumn("sMa", "Số kế hoạch", 120);
                cbossKH_XuatMuonTra_Id_CanCu.AddColumn("dNgayKeHoach", "Ngày lập", 80);
                cbossKH_XuatMuonTra_Id_CanCu.AddColumn("sDM_DonVi_Id_DonViXuat_Ten", "Đơn vị xuất", 120);
                //cbossKH_XuatMuonTra_Id_CanCu.AddColumn("iThoiGianHieuLuc", "Thời gian hiệu lực", 120, true);
                cbossKH_XuatMuonTra_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.KH_XuatMuonTraRepository>().GetData(typeof(MT.Data.BO.KH_XuatMuonTra),
                    columns: "Id,sMa,dNgayKeHoach,sDM_DonVi_Id_DonViXayDungKH_Ten,sDM_DonVi_Id_DonViXuat_Ten, sDM_DonVi_Id_DonViXuat, sDM_DonVi_Id_DonViNhap",
                    where: $"iTrangThaiDuyet=1 AND iTrangThaiThucHienKHNM < {(int)MT.Data.iTrangThaiThucHienKHNM.DaHoanThanh} AND sDM_DonVi_Id_DonViXuat ='{MT.Library.SessionData.OrganizationUnitId}'",
                    orderBy: "sSo DESC", viewName: "View_KH_XuatMuonTra");
            }
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

        private void cbosDM_CanBo_Id_NguoiGiao_QueryPopUp(object sender, CancelEventArgs e)
        {
            cbosDM_CanBo_Id_NguoiGiao.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id,sMaCanBo,sTenCanBo",
                where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' and iDictionaryKey NOT IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong},{(int)MT.Data.iChucVu.CucTruong},{(int)MT.Data.iChucVu.PhoCucTruong})",
                orderBy: "sMaCanBo",
                viewName: "View_DM_CanBo");
        }

        private void cbosDM_CanBo_Id_NguoiNhap_QueryPopUp(object sender, CancelEventArgs e)
        {
            var sDM_DonVi_Id_Nhap = treesDM_DonVi_Id_DonViNhap.GetValue();
            if (sDM_DonVi_Id_Nhap == null)
                cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                                columns: "Id,sMaCanBo,sTenCanBo", orderBy: "sMaCanBo");
            else
                cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                                columns: "Id,sMaCanBo,sTenCanBo",
                                where: $"sDM_DonVi_Id='{sDM_DonVi_Id_Nhap.ToString()}' and iDictionaryKey NOT IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong},{(int)MT.Data.iChucVu.CucTruong},{(int)MT.Data.iChucVu.PhoCucTruong})",
                                orderBy: "sMaCanBo",
                                viewName: "View_DM_CanBo");
        }

        private void linkFormVoucher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cboEnumiLoaiTCXuat.GetValue().Equals((int)iTCXuat.XuatMuon))
            {
                linkFormVoucher.TableName = "KH_XuatMuonTra";
            }
            else if (cboEnumiLoaiTCXuat.GetValue().Equals((int)iTCXuat.XuatTra))
            {
                linkFormVoucher.TableName = "Phieu_NhapMuonTra";
            }
        }
    }
}