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
    public partial class frmPhieu_NhapSanPhamDetail : FormUI.MFormBusinessDetail
    {
        private DM_DonViRepository dM_DonViRepository;

        public frmPhieu_NhapSanPhamDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<Phieu_NhapSanPhamRepository>(),
                    EntityName = "Phieu_NhapSanPham",
                    Title = "Phiếu nhập sản phẩm"
                };
            }
            GrdDetails = new Dictionary<string, MTControl.MGridEditable>
            {
                {"Phieu_NhapSanPham_CT",grdSanPham }
            };
            //ControlTepDinhKem = ucTepDinhKemDetail;
            this.ControlTepDinhKem = ucTepDinhKem1;
            InitRep();
            InitLookup();

            InitGrid();

            ucImportMaVachSP.Grd = grdSanPham.GrdDetail;
            ucImportMaVachSP.FrmParent = this;
        }

        #region"Sub/Func"

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
                    ucThamChieuPhieuNhapMoi.sTenBangCanCu = "Phieu_NhapSanPham";
                    ucThamChieuPhieuNhapMoi.LoadData();
                    break;
            }
        }

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

            // Phieu xuat
            //cbossPhieu_XuatSanPham_Id_CanCu.Properties.DisplayMember = "sMa";
            //cbossPhieu_XuatSanPham_Id_CanCu.Properties.ValueMember = "Id";
            //cbossPhieu_XuatSanPham_Id_CanCu.AddColumn("sMa", "Số phiếu xuất", 180, true);
            //cbossPhieu_XuatSanPham_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.Phieu_XuatSanPhamRepository>().GetData(typeof(MT.Data.BO.Phieu_XuatSanPham),
            //    columns: "Id,sMa", orderBy: "sMa");
            cbossPhieu_XuatSanPham_Id_CanCu.Properties.DisplayMember = "sMa";
            cbossPhieu_XuatSanPham_Id_CanCu.Properties.ValueMember = "Id";
            cbossPhieu_XuatSanPham_Id_CanCu.AddColumn("sMa", "Số phiếu xuất", 120);
            cbossPhieu_XuatSanPham_Id_CanCu.AddColumn("dNgayPhieu_Xuat", "Ngày lập", 80);
            cbossPhieu_XuatSanPham_Id_CanCu.AddColumn("sDM_DonVi_Id_Xuat_Ten", "Đơn vị lập", 120);
            //cbossKH_XuatSanPham_Id_CanCu.AddColumn("iThoiGianHieuLuc", "Thời gian hiệu lực", 120, true);
            cbossPhieu_XuatSanPham_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.Phieu_XuatSanPhamRepository>().GetData(typeof(MT.Data.BO.Phieu_XuatSanPham),
                columns: "Id,sMa,dNgayPhieu_Xuat,sDM_DonVi_Id_Xuat_Ten, sDM_DonVi_Id_Xuat, sDM_DonVi_Id_Nhap,sDM_CanBo_Id_NguoiGiao, sDM_CanBo_Id_NguoiNhap",
                orderBy: "sSo DESC",
                viewName: "View_Phieu_XuatSanPham",
                where: $"sDM_DonVi_Id_Nhap ='{MT.Library.SessionData.OrganizationUnitId}'"
                );

            var dsCanBo = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                   columns: "Id,sMaCanBo,sTenCanBo", orderBy: "sMaCanBo");

            // Nguoi lap phieu
            cbosDM_CanBo_Id_NguoiLapPhieu.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiLapPhieu.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiLapPhieu.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiLapPhieu.Properties.DataSource = dsCanBo;
            cbosDM_CanBo_Id_NguoiLapPhieu.AliasFormQuickAdd = "DM_CanBo";

            // Nguoi duyet
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiDuyet.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiDuyet.AddColumn("sTenCanBo", "Tên", 180, true);
            /*cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id,sMaCanBo,sTenCanBo", viewName: "View_DM_CanBo",
                where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' and iDictionaryKey IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong})",
                orderBy: "sMaCanBo");*/
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = dsCanBo;
            cbosDM_CanBo_Id_NguoiDuyet.AliasFormQuickAdd = "DM_CanBo";

            // Nguoi giao
            cbosDM_CanBo_Id_NguoiGiao.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiGiao.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiGiao.AddColumn("sTenCanBo", "Tên", 180, true);
            /*cbosDM_CanBo_Id_NguoiGiao.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id,sMaCanBo,sTenCanBo", orderBy: "sMaCanBo");*/
            cbosDM_CanBo_Id_NguoiGiao.Properties.DataSource = dsCanBo;
            cbosDM_CanBo_Id_NguoiGiao.AliasFormQuickAdd = "DM_CanBo";

            // Nguoi nhap
            cbosDM_CanBo_Id_NguoiNhap.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiNhap.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiNhap.AddColumn("sTenCanBo", "Tên", 180, true);
            //cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
            //    columns: "Id,sMaCanBo,sTenCanBo", orderBy: "sMaCanBo");
            /* cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                            columns: "Id,sMaCanBo,sTenCanBo",
                            where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' and iDictionaryKey NOT IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong},{(int)MT.Data.iChucVu.CucTruong},{(int)MT.Data.iChucVu.PhoCucTruong})",
                            orderBy: "sMaCanBo",
                            viewName: "View_DM_CanBo");*/
            cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = dsCanBo;
            cbosDM_CanBo_Id_NguoiNhap.AliasFormQuickAdd = "DM_CanBo";
            // 14.6
            linkFormVoucher.VoucherId = null;
            linkFormVoucher.ControlVoucher = cbossPhieu_XuatSanPham_Id_CanCu;
            linkFormVoucher.TableName = "Phieu_XuatSanPham";
        }

        /// <summary>
        /// Khởi tạo thông tin grid
        /// </summary>
        private void InitGrid()
        {
            var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham), "Id,sMaSanPham,sTenSanPham", orderBy: "SortOrder");

            var dm_DonViTinhs = DBContext.GetRep<MT.Data.Rep.DM_DonViTinhRepository>().GetData(typeof(MT.Data.BO.DM_DonViTinh), "Id,sTenDonViTinh", orderBy: "SortOrder");
            //Sản phẩm
            grdSanPham.GrdDetail.TableName = "Phieu_NhapSanPham_CT";
            grdSanPham.GrdDetail.ViewName = "View_Phieu_NhapSanPham_CT";
            grdSanPham.GrdDetail.KeyName = "Id";
            grdSanPham.GrdDetail.SetField = "phieu_NhapSanPham_CTs";
            grdSanPham.GrdDetail.FirstView.OptionsNavigation.EnterMoveNextColumn = true;
            grdSanPham.GrdDetail.DisableFieldNames = @"sDM_SanPham_Id_Ten,sDM_ChungThuSo_Id,sDM_MangLienLac_Id,rThanhTien,sDM_DonViTinh_Id,rSoLuong,dHanBaoHanhDen"; // Note
            grdSanPham.GrdDetail.ValidEditValueChanging = grdSanPham_ValidEditValueChanging;
            grdSanPham.IsRequired = true;
            grdSanPham.InvalidText = "Danh sách sản phẩm không được bỏ trống";
            grdSanPham.GrdDetail.FuncCustomRecordBeforeAddRow = GridSanPham_FuncCustomRecordBeforeAddRow; ;

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

            col = grdSanPham.GrdDetail.AddColumnText("sDM_SanPham_Id_Ten", "Tên sản phẩm", 250, isRequired: true);

            // Mạng LL
            col = grdSanPham.GrdDetail.AddColumnText("sDM_MangLienLac_Id", "Mạng liên lạc", 150, isFixWidth: true,
               //fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left,
               dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: false);

            MRepositoryItemLookUpEdit colsDM_MangLL_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_MangLL_Id.DictionaryName = "DM_MangLienLac";
            //colsDM_MangLL_Id.AddColumn("sMaMangLienLac", "Mã mạng liên lạc", 120);
            colsDM_MangLL_Id.AddColumn("sTenMangLienLac", "Tên mạng liên lạc", 180);
            colsDM_MangLL_Id.DataSource = DBContext.GetRep<MT.Data.Rep.DM_MangLienLacRepository>().GetData(typeof(MT.Data.BO.DM_MangLienLac), "Id,sTenMangLienLac", orderBy: "SortOrder");
            colsDM_MangLL_Id.DisplayMember = "sTenMangLienLac";
            colsDM_MangLL_Id.ValueMember = "Id";

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

            grdSanPham.GrdDetail.AddColumnText("rSoLuong", "Số lượng", 80, dataType: MTControl.DataTypeColumn.SpinEdit);

            grdSanPham.GrdDetail.AddColumnText("rDonGia", "Đơn giá", 150, dataType: MTControl.DataTypeColumn.SpinEdit);
            grdSanPham.GrdDetail.AddColumnText("rThanhTien", "Thành tiền", 150, dataType: MTControl.DataTypeColumn.SpinEdit);

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

            col = grdSanPham.GrdDetail.AddColumnText("sPhieu_XuatSanPham_CT_Id", "sPhieu_XuatSanPham_CT_Id", 0);
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
                //0002(Mã NCC) 0004(Mã SP) 00007(series) 21(Năm)
                if (mTextEdit.EditValue != null)
                {
                    string sMaVach = mTextEdit.EditValue.ToString();
                    if (!MT.Library.Utility.ValidsMaVach(sMaVach))
                    {
                        MMessage.ShowWarning("Mã vạch không hợp lệ");
                        return true;
                    }

                    //List<MT.Data.BO.Phieu_NhapSanPham_CT> phieu_NhapSanPham_CTs = grdSanPham.GrdDetail.GetAllData<MT.Data.BO.Phieu_NhapSanPham_CT>();
                    // Truong Added 14.6:
                    List<MT.Data.BO.Phieu_NhapSanPham_CT> phieu_NhapSanPham_CTs_others = DBContext.GetRep2<Phieu_NhapSanPham_CTRepository>().GetAllPhieuNhapCT(MT.Library.SessionData.OrganizationUnitId);
                    List<MT.Data.BO.Phieu_NhapSanPham_CT> phieu_NhapSanPham_CTs_current = grdSanPham.GrdDetail.GetAllData<MT.Data.BO.Phieu_NhapSanPham_CT>();

                    Phieu_NhapSanPham_CT phieu_NhapSanPham_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_NhapSanPham_CT>();
                    //Kiểm tra nếu mã vạch đã có trên danh sách rồi thì không cho nhập, cảnh báo trùng
                    if (phieu_NhapSanPham_CTs_others.Count > 1)
                    {
                        //Kiểm tra mã vạch có bị trùng hay không
                        MT.Data.BO.Phieu_NhapSanPham_CT findBysMaVach_others = phieu_NhapSanPham_CTs_others.Find(m => m.sMaVach.Equals(sMaVach) && m.Id != phieu_NhapSanPham_CT.Id);
                        MT.Data.BO.Phieu_NhapSanPham_CT findBysMaVach_current = phieu_NhapSanPham_CTs_current.Find(m => m.sMaVach.Equals(sMaVach) && m.Id != phieu_NhapSanPham_CT.Id);
                        if (findBysMaVach_others != null || findBysMaVach_current != null)
                        {
                            MMessage.ShowWarning($"Mã vạch <{sMaVach}> đã tồn tại trên danh sách");

                            return true;
                        }
                    }

                    var convertMaVachToObject = CommonFnUI.ConvertsMaVachToObject(sMaVach);
                    string sMaNCC = convertMaVachToObject.sNhaCungCap;
                    string sMaSP = convertMaVachToObject.sMaSanPham;
                    string sSerial = convertMaVachToObject.sSoSeries + "/";
                    sSerial += convertMaVachToObject.sNam;
                    int iNamSX = int.Parse($"20{convertMaVachToObject.sNam}");

                    //Cập nhật thông tin chứng thư số
                    var lkMaVachCTS = DBContext.GetRep2<LK_MaVach_CTSRepository>().GetLK_MaVach_CTSByMaVach(sMaVach);
                    if (lkMaVachCTS != null)
                    {
                        phieu_NhapSanPham_CT.sDM_ChungThuSo_Id = lkMaVachCTS.sDM_ChungThuSo_Id;
                    }

                    //Cập nhật thông tin MLL
                    var lkMaVachMLL = DBContext.GetRep2<LK_MaVach_MLLRepository>().GetLK_MaVach_MLLByMaVach(sMaVach);
                    if (lkMaVachMLL != null)
                    {
                        phieu_NhapSanPham_CT.sDM_MangLienLac_Id = lkMaVachMLL.sDM_MangLienLac_Id;
                    }

                    Guid? sPhieuXuatSanPham_Id = null;
                    if (cbossPhieu_XuatSanPham_Id_CanCu.EditValue != null)
                        sPhieuXuatSanPham_Id = Guid.Parse(cbossPhieu_XuatSanPham_Id_CanCu.EditValue.ToString());
                    if (sPhieuXuatSanPham_Id.HasValue)
                    {
                        Phieu_XuatSanPham_CT phieu_XuatSanPham_CT = DBContext.GetRep2<Phieu_XuatSanPham_CTRepository>()
                                                                    .GetPhieu_XuatSanPham_CTBysPhieu_XuatSanPham_CT_IdAndsMaSP(sPhieuXuatSanPham_Id, sMaVach);

                        if (phieu_XuatSanPham_CT == null)
                        {
                            MMessage.ShowWarning($@"Phiếu xuất <{cbossPhieu_XuatSanPham_Id_CanCu.Text}> không tồn tại sản phẩm có mã vạch <{sMaVach}>");
                            return true;
                        }

                        // 14.6
                        //Kiểm tra sản phẩm đã nhập đủ so với kế hoạch chưa, nếu đủ roh thì không cho nhập nữa
                        // NOTEEEEEEE:
                        // ĐIỂM KHÁC Ở ĐÂY so với Phiếu xuất - Kế hoạch xuất là Cặp Phiếu nhập - Phiếu xuất đều có mã vạch và SanPhamID có thể trùng nhau nên không dùng được
                        decimal sl_others = phieu_NhapSanPham_CTs_others
                            .Where(m => m.sMaVach.Equals(phieu_XuatSanPham_CT.sMaVach) && m.Id != phieu_NhapSanPham_CT.Id)
                            .Sum(m => m.rSoLuong);
                        decimal sl_current = phieu_NhapSanPham_CTs_current
                            .Where(m => m.sMaVach.Equals(phieu_XuatSanPham_CT.sMaVach) && m.Id != phieu_NhapSanPham_CT.Id)
                            .Sum(m => m.rSoLuong);

                        if (sl_others + sl_current >= phieu_XuatSanPham_CT.rSoLuong)
                        {
                            MMessage.ShowWarning($@"Sản phẩm <{phieu_XuatSanPham_CT.sDM_SanPham_Id_Ten}> đã nhập đủ so với phiếu xuất");
                            return true;
                        }
                        //Lấy chi tiết phụ kiện theo phiếu xuất
                        List<MT.Data.BO.Phieu_XuatSanPham_CT_PhuKien> phieu_XuatSanPham_CT_PhuKiens = DBContext.GetRep2<Phieu_XuatSanPham_CT_PhuKienRepository>()
                                                                                                    .GetPhieu_XuatSanPham_CT_PhuKiensBysPhieu_XuatSanPham_CT_Id(phieu_XuatSanPham_CT.Id);
                        List<MT.Data.BO.Phieu_NhapSanPham_CT_PhuKien> phieu_NhapSanPham_CT_PhuKiens = new List<Phieu_NhapSanPham_CT_PhuKien>();
                        if (phieu_XuatSanPham_CT_PhuKiens != null)
                        {
                            foreach (var item in phieu_XuatSanPham_CT_PhuKiens)
                            {
                                phieu_NhapSanPham_CT_PhuKiens.Add(new Phieu_NhapSanPham_CT_PhuKien
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
                        phieu_NhapSanPham_CT.phieu_NhapSanPham_CT_PhuKiens = phieu_NhapSanPham_CT_PhuKiens;

                        phieu_NhapSanPham_CT.sPhieu_XuatSanPham_CT_Id = phieu_XuatSanPham_CT.Id;
                        phieu_NhapSanPham_CT.sPhieu_XuatSanPham_Id = sPhieuXuatSanPham_Id; // Note 14.6

                        phieu_NhapSanPham_CT.sDM_SanPham_Id = phieu_XuatSanPham_CT.sDM_SanPham_Id;
                        phieu_NhapSanPham_CT.sDM_DonViTinh_Id = phieu_XuatSanPham_CT.sDM_DonViTinh_Id;
                        phieu_NhapSanPham_CT.rDonGia = phieu_XuatSanPham_CT.rDonGia;
                        phieu_NhapSanPham_CT.rThanhTien = phieu_XuatSanPham_CT.rDonGia;
                        phieu_NhapSanPham_CT.sDM_SanPham_Id_Ten = phieu_XuatSanPham_CT.sDM_SanPham_Id_Ten;
                        //phieu_NhapSanPham_CT.sDM_MangLienLac_Id = phieu_XuatSanPham_CT.sDM_MangLienLac_Id;
                        //phieu_NhapSanPham_CT.sDM_MangLienLac_Id_Ten = phieu_XuatSanPham_CT.sDM_MangLienLac_Id_Ten;

                        /*phieu_NhapSanPham_CT.iThoiGianBaoHanh = phieu_XuatSanPham_CT.iThoiGianBaoHanh;
                        phieu_NhapSanPham_CT.iDonViThoiGianBaoHanh = phieu_XuatSanPham_CT.iDonViThoiGianBaoHanh;
                        phieu_NhapSanPham_CT.dHanBaoHanhDen = phieu_XuatSanPham_CT.dHanBaoHanhDen;
                        phieu_NhapSanPham_CT.iNamSX = phieu_XuatSanPham_CT.iNamSX;*/
                        phieu_NhapSanPham_CT.sXuatXu = phieu_XuatSanPham_CT.sXuatXu;
                        phieu_NhapSanPham_CT.sGhiChu = phieu_XuatSanPham_CT.sGhiChu;
                        phieu_NhapSanPham_CT.sSTTSP = phieu_XuatSanPham_CT.sSTTSP;
                    }
                    else
                    {
                        var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham), where: $"sMaSanPham='{sMaSP}'");
                        if (dm_SanPhams?.Count > 0)
                        {
                            DM_SanPham dM_SanPham = (DM_SanPham)dm_SanPhams[0];
                            phieu_NhapSanPham_CT.sDM_SanPham_Id = dM_SanPham.Id;
                            phieu_NhapSanPham_CT.sDM_DonViTinh_Id = dM_SanPham.sDM_DonViTinh_Id_Cap1;
                            phieu_NhapSanPham_CT.rDonGia = dM_SanPham.rDonGia_Cap1;
                            phieu_NhapSanPham_CT.rThanhTien = dM_SanPham.rDonGia_Cap1;
                            phieu_NhapSanPham_CT.sDM_SanPham_Id_Ten = dM_SanPham.sTenSanPham;
                            List<DM_PhuKien> dM_PhuKiens = ((DM_PhuKienRepository)DBContext.GetRep<MT.Data.Rep.DM_PhuKienRepository>()).GetPhuKiensBysDM_SanPham_Id(dM_SanPham.Id);
                            List<MT.Data.BO.Phieu_NhapSanPham_CT_PhuKien> phieu_NhapSanPham_CT_PhuKiens = new List<Phieu_NhapSanPham_CT_PhuKien>();
                            foreach (var item in dM_PhuKiens)
                            {
                                phieu_NhapSanPham_CT_PhuKiens.Add(new Phieu_NhapSanPham_CT_PhuKien
                                {
                                    Id = Guid.NewGuid(),
                                    sDM_SanPham_Id = item.sDM_SanPham_Id,
                                    sDM_SanPham_Id_Ten = item.sDM_SanPham_Id_Ten,
                                    sDM_PhuKien_Id = item.Id,
                                    sDM_PhuKien_Id_Ten = item.sTenPhuKien,
                                    sDM_DonViTinh_Id = item.sDM_DonViTinh_Id,
                                    rSoLuong = 1,
                                    rDonGia = item.rDonGia,
                                    rThanhTien = item.rDonGia,
                                    SortOrder = item.SortOrder,
                                    MTEntityState = Enummation.MTEntityState.Add
                                });
                            }
                            phieu_NhapSanPham_CT.phieu_NhapSanPham_CT_PhuKiens = phieu_NhapSanPham_CT_PhuKiens;
                            
                            phieu_NhapSanPham_CT.sSTTSP = string.Empty;

                            phieu_NhapSanPham_CT.sPhieu_XuatSanPham_CT_Id = null;
                            phieu_NhapSanPham_CT.sPhieu_XuatSanPham_Id = null; // Note 14.6
                        }
                    }

                    phieu_NhapSanPham_CT.IsLoaded = true;
                    phieu_NhapSanPham_CT.rSoLuong = 1;
                    phieu_NhapSanPham_CT.sSerial = sSerial;

                    // Truong 2022
                    var dm_Phieu_NhapSanPhamMois = DBContext.GetRep<MT.Data.Rep.Phieu_NhapSanPhamMoi_CTRepository>().GetData(typeof(MT.Data.BO.Phieu_NhapSanPhamMoi_CT),
                        columns: "iThoiGianBaoHanh,iDonViThoiGianBaoHanh,iNamSX,dHanBaoHanhDen",
                        viewName: "View_Phieu_NhapSanPhamMoi_CT",
                        where: $"sMaVach='{sMaVach}'");
                    if (dm_Phieu_NhapSanPhamMois != null && dm_Phieu_NhapSanPhamMois.Count == 1)
                    {
                        Phieu_NhapSanPhamMoi_CT curPNM = (Phieu_NhapSanPhamMoi_CT)dm_Phieu_NhapSanPhamMois[0];
                        phieu_NhapSanPham_CT.iThoiGianBaoHanh = curPNM.iThoiGianBaoHanh;
                        phieu_NhapSanPham_CT.iDonViThoiGianBaoHanh = curPNM.iDonViThoiGianBaoHanh;
                        phieu_NhapSanPham_CT.iNamSX = curPNM.iNamSX;
                        phieu_NhapSanPham_CT.dHanBaoHanhDen = curPNM.dHanBaoHanhDen;
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
        /// Click hiển thị form nhập chi tiết phụ kiện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColsActionPhuKien_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //Bắt bắt chọn sản phẩm roh thì mới cho nhập phụ kiện
            var phieu_NhapSanPham_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_NhapSanPham_CT>();
            if (phieu_NhapSanPham_CT.sDM_SanPham_Id.HasValue && !phieu_NhapSanPham_CT.sDM_SanPham_Id.Value.Equals(Guid.Empty))
            {
                //frmPhieu_NhapSanPham_CT_PhuKienDetail frmPhieu_NhapSanPham_CT_PhuKienDetail = new frmPhieu_NhapSanPham_CT_PhuKienDetail(grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_NhapSanPham_CT>());
                frmPhuKienDetail frmPhuKienDetail = new frmPhuKienDetail(phieu_NhapSanPham_CT.sDM_SanPham_Id.Value,
                    "Phieu_NhapSanPham_CT_PhuKien", "phieu_NhapSanPham_CT_PhuKiens", phieu_NhapSanPham_CT, this);
                frmPhuKienDetail.ShowDialog();
            }
            else
            {
                MMessage.ShowWarning("Bạn phải chọn sản phẩm trước khi nhập thông tin chi tiết phụ kiện");
            }
        }

        #endregion

        /// <summary>
        /// Thiết lập các tham số trước khi in
        /// </summary>
        /// <param name="configExcel"></param>
        /// <param name="configReport"></param>
        protected override void SetConfigBeforePrint(MT.Data.BO.ConfigExcel configExcel, ConfigReport configReport)
        {
            base.SetConfigBeforePrint(configExcel, configReport);
            //Đối tượng xử lý nghiệp vụ IN
            configReport.RepName = "Print_Phieu_NhapSanPham_DetailRepository";
            //Định danh mẫu in trong bảng ReportData
            configReport.DictionaryKey = MT.Data.ReportDictionaryKey.RP_Print_Phieu_NhapSanPhamDetail;

            //Danh sách các cột trên table
            configExcel.ShowColumnsOrder = new HashSet<string>
            {
               "sSTT","sDM_SanPham_Id_Ten","sDM_DonViTinh_Id_Ten","rSoLuong","rDonGia","rThanhTien",
                "sXuatXu","iNamSX","iThoiGianBaoHanh"
            };
        }

        /// <summary>
        /// Validate giá trị trước khi gán cho grid
        /// </summary>
        /// <param name="gridColumn"></param>
        /// <param name="e"></param>
        /// <returns>=true cho gán,ngược lại ko cho gán</returns>
        private bool grdSanPham_ValidEditValueChanging(DevExpress.XtraGrid.Columns.GridColumn gridColumn, ChangingEventArgs e)
        {
            /*if (cbossPhieu_XuatSanPham_Id_CanCu.EditValue == null)
            {
                ActiveControl = cbossPhieu_XuatSanPham_Id_CanCu;
                MMessage.ShowWarning("Bạn phải xác định phiếu nhập căn cứ theo kế hoạch nào.");
                return false;
            }*/

            if (gridColumn.FieldName == "sSTTSP" && e.NewValue != null && !object.Equals(e.OldValue, e.NewValue))
            {
                string[] arrSerial = e.NewValue.ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Phieu_NhapSanPham_CT phieu_NhapSanPham = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_NhapSanPham_CT>();
                if (arrSerial.Length > 0 && (decimal)arrSerial.Length > phieu_NhapSanPham.rSoLuong)
                {
                    e.NewValue = string.Empty;
                    MMessage.ShowWarning($"Bạn chỉ được phép chọn tối đa {(int)phieu_NhapSanPham.rSoLuong} số serial");
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
            Phieu_NhapSanPham_CT phieu_NhapSanPham_CT = (Phieu_NhapSanPham_CT)newRecord;
            if (phieu_NhapSanPham_CT.sDM_SanPham_Id.HasValue
                && !phieu_NhapSanPham_CT.sDM_SanPham_Id.Value.Equals(Guid.Empty))
            {
                if (cbossPhieu_XuatSanPham_Id_CanCu.EditValue == null)
                {
                    ActiveControl = cbossPhieu_XuatSanPham_Id_CanCu;
                    MMessage.ShowWarning("Bạn phải xác định phiếu xuất căn cứ theo kế hoạch nào.");
                    return false;
                }
            }
            return true;
        }

        #region"Overrides"

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
                List<MT.Data.BO.Phieu_NhapSanPham_CT> phieu_NhapSanPham_CTs = mGridEditable.GrdDetail.GetAllData<MT.Data.BO.Phieu_NhapSanPham_CT>();

                foreach (var item in dataChanged)
                {
                    var castItem = (MT.Data.BO.Phieu_NhapSanPham_CT)item;
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
                    if (isValid && phieu_NhapSanPham_CTs != null && phieu_NhapSanPham_CTs.Count > 0)
                    {
                        //Kiểm tra mã vạch có bị trùng hay không
                        MT.Data.BO.Phieu_NhapSanPham_CT findBysMaVach = phieu_NhapSanPham_CTs.Find(m => m.sMaVach.Equals(castItem.sMaVach) && m.Id != castItem.Id);
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
                            MT.Data.BO.SoKho findInSoKho = soKho.Find(m => m.iLoaiPhieu.Equals(22)); // 12: Phiếu xuất
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
                case "Phieu_NhapSanPham_CT":
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
                        Phieu_XuatSanPham_CTRepository ph_XuatSanPham_CTRepository = DBContext.GetRep2<Phieu_XuatSanPham_CTRepository>();
                        object sPH_XuatSanPham_Id_CanCu = cbossPhieu_XuatSanPham_Id_CanCu.EditValue;
                        MRepositoryItemLookUpEdit repositoryItemLookUpEdit = (MRepositoryItemLookUpEdit)repository;
                        if (sPH_XuatSanPham_Id_CanCu != null)
                        {
                            repositoryItemLookUpEdit.DataSource = ph_XuatSanPham_CTRepository
                                                                    .GetPhieu_XuatSanPham_CTsBysPhieu_XuatSanPham_Id(Guid.Parse(sPH_XuatSanPham_Id_CanCu.ToString()));
                        }
                        else
                        {
                            repositoryItemLookUpEdit.DataSource = null;
                        }
                    }
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
                        //MT.Data.BO.Phieu_NhapSanPham curMaster = (MT.Data.BO.Phieu_NhapSanPham)this.CurrentData;
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
                case "Phieu_NhapSanPham_CT":
                    // Noteeeeeeeee
                    Phieu_NhapSanPham_CT phieu_NhapSanPham_CT = mGridControl.GetRecordByRowSelected<Phieu_NhapSanPham_CT>();
                    if (e.Column.FieldName == "sDM_SanPham_Id")
                    {
                        //gán mặc định đơn vị tính cấp 1 cho sản phẩm
                        if (mGridControl.FuncCustomRecordBeforeAddRow != null)
                        {
                            mGridControl.FuncCustomRecordBeforeAddRow(phieu_NhapSanPham_CT, mGridControl);
                        }
                    }
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
                        phieu_NhapSanPham_CT.rThanhTien = phieu_NhapSanPham_CT.rSoLuong * phieu_NhapSanPham_CT.rDonGia;
                    }
                    if (e.Column.FieldName == "sSTTSP")
                    {
                        object objsSerial = e.Value;
                        if (objsSerial != null)
                        {
                            string[] arrSerial = objsSerial.ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (arrSerial.Length >= 1)
                            {
                                phieu_NhapSanPham_CT.rSoLuong = arrSerial.Length;
                            }
                        }
                    }
                    var now = SysDateTime.Instance.Now();
                    if (e.Column.FieldName == "iThoiGianBaoHanh" || e.Column.FieldName == "iDonViThoiGianBaoHanh")
                    {
                        DateTime? dHanBaoHanhDen = null;
                        switch (phieu_NhapSanPham_CT.iDonViThoiGianBaoHanh)
                        {
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Ngay:
                                dHanBaoHanhDen =now.AddDays(phieu_NhapSanPham_CT.iThoiGianBaoHanh).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Thang:
                                dHanBaoHanhDen = now.AddMonths(phieu_NhapSanPham_CT.iThoiGianBaoHanh).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Quy:
                                dHanBaoHanhDen = now.AddYears(phieu_NhapSanPham_CT.iThoiGianBaoHanh * 3).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Nam:
                                dHanBaoHanhDen = now.AddYears(phieu_NhapSanPham_CT.iThoiGianBaoHanh).AddDays(1);
                                break;
                        }
                        phieu_NhapSanPham_CT.dHanBaoHanhDen = dHanBaoHanhDen;
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
                    cbossPhieu_XuatSanPham_Id_CanCu.SetReadOnly(false);
                    break;

                default:
                    cbossPhieu_XuatSanPham_Id_CanCu.SetReadOnly(true);
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
            var currentData = (Phieu_NhapSanPham)base.PrepareDataBeforeBindDataForm();
            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:
                    currentData.dNgayPhieu_Nhap = SysDateTime.Instance.Now();
                    currentData.sDM_DonVi_Id_Nhap = MT.Library.SessionData.OrganizationUnitId;
                    currentData.sDM_CanBo_Id_NguoiLapPhieu = MT.Library.SessionData.UserId;
                    currentData.sDM_CanBo_Id_NguoiNhap = MT.Library.SessionData.UserId;
                    currentData.iNhapVeKho = true;
                    currentData.sPhieu_XuatSanPham_Id_CanCu = null;
                    break;
            }

            return currentData;
        }

        #endregion

        private void cbossPhieu_NhapSanPham_Id_CanCu_EditValueChanged(object sender, EventArgs e)
        {
            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:
                    MT.Data.BO.Phieu_XuatSanPham pH_XuatSanPham = cbossPhieu_XuatSanPham_Id_CanCu.GetRecordSelected<MT.Data.BO.Phieu_XuatSanPham>();
                    if (pH_XuatSanPham != null)
                    {
                        // Thiết lập giá trị mặc định cho đơn vị xuất
                        Guid maDVXuat = pH_XuatSanPham.sDM_DonVi_Id_Xuat;
                        treesDM_DonVi_Id_DonViXuat.SetValue(maDVXuat);

                        // Thiết lập giá trị mặc định cho đơn vị nhập
                        Guid maDVNhap = pH_XuatSanPham.sDM_DonVi_Id_Nhap;
                        treesDM_DonVi_Id_DonViNhap.SetValue(maDVNhap);
                        // Thiết lập lọc người nhận thuộc đơn vị nhận

                        // Nguoi giao

                        object sDM_Donvi_Id_giao = treesDM_DonVi_Id_DonViXuat.GetValue();
                        cbosDM_CanBo_Id_NguoiGiao.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                           columns: "Id,sMaCanBo,sTenCanBo",
                           where: $"sDM_DonVi_Id='{sDM_Donvi_Id_giao.ToString()}' and iDictionaryKey NOT IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong},{(int)MT.Data.iChucVu.CucTruong},{(int)MT.Data.iChucVu.PhoCucTruong})",
                           orderBy: "sMaCanBo",
                           viewName: "View_DM_CanBo");
                        cbosDM_CanBo_Id_NguoiGiao.SetValue(pH_XuatSanPham.sDM_CanBo_Id_NguoiGiao);

                        // Nguoi nhập
                        cbosDM_CanBo_Id_NguoiNhap.SetValue(pH_XuatSanPham.sDM_CanBo_Id_NguoiNhap);

                        //var datas = DBContext.GetRep2<Phieu_NhapSanPham_CTRepository>().GetPhieu_XuatSanPham_CTsByMasterId(pH_XuatSanPham.Id);
                        //grdSanPham.GrdDetail.LoadData(datas);
                    }
                    break;
            }
        }

        private void cbossPhieu_XuatSanPham_Id_CanCu_QueryPopUp(object sender, CancelEventArgs e)
        {
            cbossPhieu_XuatSanPham_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.Phieu_XuatSanPhamRepository>().GetData(typeof(MT.Data.BO.Phieu_XuatSanPham),
               columns: "Id,sMa,dNgayPhieu_Xuat,sDM_DonVi_Id_Xuat_Ten, sDM_DonVi_Id_Xuat, sDM_DonVi_Id_Nhap,sDM_CanBo_Id_NguoiGiao, sDM_CanBo_Id_NguoiNhap",
               where: $"iTrangThaiDuyet=1 AND iTrangThaiThucHienKHNM < {(int)MT.Data.iTrangThaiThucHienKHNM.DaHoanThanh} AND sDM_DonVi_Id_Nhap ='{MT.Library.SessionData.OrganizationUnitId}'",
               orderBy: "sSo DESC", viewName: "View_Phieu_XuatSanPham");
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

        private void cbosDM_CanBo_Id_NguoiDuyet_QueryPopUp(object sender, CancelEventArgs e)
        {
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
            //columns: "Id,sMaCanBo,sTenCanBo", where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' and (sDM_ChucVu_Id='A0AF0133-54AB-435D-823B-3DF1C10D72C8'or sDM_ChucVu_Id='903EB1D0-B73D-4FF2-AD69-8B81D1A2A22A')", orderBy: "sMaCanBo");
            columns: "Id,sMaCanBo,sTenCanBo",
            viewName: "View_DM_CanBo",
            where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' and iDictionaryKey IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong})",
            orderBy: "sMaCanBo");
        }
    }
}