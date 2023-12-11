using DevExpress.ClipboardSource.SpreadsheetML;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class frmPhieu_NhapBaoHanhSanPhamDetail : FormUI.MFormBusinessDetail
    {
        DM_DonViRepository dM_DonViRepository;
        public frmPhieu_NhapBaoHanhSanPhamDetail()
        {
            InitializeComponent();
            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<Phieu_NhapBaoHanhSanPhamRepository>(),
                    EntityName = "Phieu_NhapBaoHanhSanPham",
                    Title = "Phiếu nhập bảo hành"
                };
            }
            GrdDetails = new Dictionary<string, MTControl.MGridEditable>
            {
                {"Phieu_NhapBaoHanhSanPham_CT", grdSanPham }
            };
            this.ControlTepDinhKem = ucTepDinhKem1;
            InitRep();
            InitLookup();

            InitGrid();

            ucImportMaVachSP.Grd = grdSanPham.GrdDetail;
            ucImportMaVachSP.FrmParent = this;
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
            cbosPhieu_XuatBaoHanhSanPham_Id_CanCu.Properties.DisplayMember = "sMa";
            cbosPhieu_XuatBaoHanhSanPham_Id_CanCu.Properties.ValueMember = "Id";
            cbosPhieu_XuatBaoHanhSanPham_Id_CanCu.AddColumn("sMa", "Căn cứ số", 150);
            cbosPhieu_XuatBaoHanhSanPham_Id_CanCu.AddColumn("dNgayPhieu_Xuat", "Ngày lập", 150);
            cbosPhieu_XuatBaoHanhSanPham_Id_CanCu.AddColumn("sDM_DonVi_Id_Xuat_Ten", "Đơn vị xuất", 250);
            cbosPhieu_XuatBaoHanhSanPham_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.Phieu_XuatBaoHanhSanPhamRepository>().GetData(typeof(MT.Data.BO.Phieu_XuatBaoHanhSanPham),
                columns: "Id,sMa,dNgayPhieu_Xuat,sDM_DonVi_Id_Xuat,sDM_DonVi_Id_Xuat_Ten,sDM_DonVi_Id_Nhap,sDM_CanBo_Id_NguoiGiao,sDM_CanBo_Id_NguoiNhap",
                where: $"iTrangThaiDuyet=1 AND sDM_DonVi_Id_Nhap='{SessionData.OrganizationUnitId}'",
                orderBy: "sSo DESC", viewName: "View_Phieu_XuatBaoHanhSanPham");




            var donviXayDungKH = dM_DonViRepository.GetDonViConCap1VaDonViCungCap(MT.Library.SessionData.OrganizationUnitId);
            var donviVaNhaCC = dM_DonViRepository.GetDonViConCap1VaDonViCungCapVaNhaCungCap(MT.Library.SessionData.OrganizationUnitId, uuTienNhaCC: true);

            treesDM_DonVi_Id_Xuat.Properties.DisplayMember = "sTenDonvi";
            treesDM_DonVi_Id_Xuat.Properties.ValueMember = "Id";
            var treeListXuat = treesDM_DonVi_Id_Xuat.Properties.TreeList;
            treeListXuat.KeyFieldName = "Id";
            treeListXuat.ParentFieldName = "sParentId";
            treesDM_DonVi_Id_Xuat.AddColumn("sLoai", "Loại", 80);
            treesDM_DonVi_Id_Xuat.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            treesDM_DonVi_Id_Xuat.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            treesDM_DonVi_Id_Xuat.Properties.DataSource = donviVaNhaCC;
            treesDM_DonVi_Id_Xuat.AliasFormQuickAdd = "DM_DonVi";

            treesDM_DonVi_Id_Nhap.Properties.DisplayMember = "sTenDonvi";
            treesDM_DonVi_Id_Nhap.Properties.ValueMember = "Id";
            var treeListNhap = treesDM_DonVi_Id_Nhap.Properties.TreeList;
            treeListNhap.KeyFieldName = "Id";
            treeListNhap.ParentFieldName = "sParentId";
            treesDM_DonVi_Id_Nhap.AddColumn("sLoai", "Loại", 80);
            treesDM_DonVi_Id_Nhap.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            treesDM_DonVi_Id_Nhap.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            treesDM_DonVi_Id_Nhap.Properties.DataSource = donviVaNhaCC;
            treesDM_DonVi_Id_Nhap.AliasFormQuickAdd = "DM_DonVi";


            var dsCanBo = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                                 columns: "Id,sMaCanBo,sTenCanBo", orderBy: "sMaCanBo");

            cbosDM_CanBo_Id_NguoiGiao.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiGiao.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiGiao.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiGiao.Properties.DataSource = dsCanBo;
            cbosDM_CanBo_Id_NguoiGiao.AliasFormQuickAdd = "DM_CanBo";

            cbosDM_CanBo_Id_NguoiNhap.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiNhap.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiNhap.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = dsCanBo;
            cbosDM_CanBo_Id_NguoiNhap.AliasFormQuickAdd = "DM_CanBo";

            cbosDM_CanBo_Id_NguoiLapPhieu.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiLapPhieu.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiLapPhieu.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiLapPhieu.Properties.DataSource = dsCanBo;
            cbosDM_CanBo_Id_NguoiLapPhieu.AliasFormQuickAdd = "DM_CanBo";


            cbosDM_CanBo_Id_NguoiDuyet.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiDuyet.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiDuyet.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = dsCanBo;
            cbosDM_CanBo_Id_NguoiDuyet.AliasFormQuickAdd = "DM_CanBo";

            cboiLoai.EnumData = "iLoaiNhapBaoHanh";


            linkFormVoucher.ControlVoucher = cbosPhieu_XuatBaoHanhSanPham_Id_CanCu;
            linkFormVoucher.TableName = "Phieu_XuatBaoHanhSanPham";
        }

        /// <summary>
        /// Khởi tạo thông tin grid
        /// </summary>
        private void InitGrid()
        {
            var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham), "Id,sMaSanPham,sTenSanPham", orderBy: "SortOrder");

            var dm_DonViTinhs = DBContext.GetRep<MT.Data.Rep.DM_DonViTinhRepository>().GetData(typeof(MT.Data.BO.DM_DonViTinh), "Id,sTenDonViTinh", orderBy: "SortOrder");
            //Sản phẩm
            grdSanPham.GrdDetail.ViewName = "View_Phieu_NhapBaoHanhSanPham_CT";
            grdSanPham.GrdDetail.KeyName = "Id";
            grdSanPham.GrdDetail.SetField = "phieu_NhapBaoHanhSanPham_CTs";

            grdSanPham.GrdDetail.FirstView.OptionsNavigation.EnterMoveNextColumn = true;
            grdSanPham.GrdDetail.DisableFieldNames = @"sDM_SanPham_Id,sDM_ChungThuSo_Id,sDM_MangLienLac_Id,sDM_SanPham_Id_Ten,rThanhTien,sDM_DonViTinh_Id,rSoLuong,dHanBaoHanhDen,sSerial";
            grdSanPham.GrdDetail.ValidEditValueChanging = grdSanPham_ValidEditValueChanging;
            grdSanPham.IsRequired = true;
            grdSanPham.InvalidText = "Danh sách sản phẩm không được bỏ trống";

            var col = grdSanPham.GrdDetail.AddColumnText("sMaVach", "Mã vạch", 150, maxLength: 50,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left, isRequired: true);

            MRepositoryTextEdit colsMaVach = (MRepositoryTextEdit)col.ColumnEdit;
            colsMaVach.CustomEventEnter = grdSanPham_ColsMaVach_CustomEventEnter;

            col = grdSanPham.GrdDetail.AddColumnText("sDM_SanPham_Id_Ten", "Tên sản phẩm", 250, isRequired: true);

            // Mạng liên lạc
            col = grdSanPham.GrdDetail.AddColumnText("sDM_MangLienLac_Id", "Mạng liên lạc", 180, isFixWidth: true,
               //fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left,
               dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: false);

            MRepositoryItemLookUpEdit colsDM_MangLL_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_MangLL_Id.DictionaryName = "DM_MangLienLac";
            colsDM_MangLL_Id.AddColumn("sTenMangLienLac", "Tên mạng liên lạc", 180);
            colsDM_MangLL_Id.DataSource = DBContext.GetRep<MT.Data.Rep.DM_MangLienLacRepository>().GetData(typeof(MT.Data.BO.DM_MangLienLac), "Id,sTenMangLienLac", orderBy: "SortOrder"); ;
            colsDM_MangLL_Id.DisplayMember = "sTenMangLienLac";
            colsDM_MangLL_Id.ValueMember = "Id";

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

            // Nội dung bảo hành
            col = grdSanPham.GrdDetail.AddColumnText("sDM_NoiDungBaoHanh_Id", "Nội dung bảo hành", 220, isFixWidth: true,
               //fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left,
               dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);

            MRepositoryItemLookUpEdit colsDM_NDSC_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_NDSC_Id.DictionaryName = "DM_NoiDungBaoHanh";
            colsDM_NDSC_Id.AddColumn("sTenNoiDungBaoHanh", "Tên nội dung bảo hành", 200);
            colsDM_NDSC_Id.DataSource = DBContext.GetRep<MT.Data.Rep.DM_NoiDungBaoHanhRepository>().GetData(typeof(MT.Data.BO.DM_NoiDungBaoHanh), "Id,sTenNoiDungBaoHanh", orderBy: "SortOrder"); ;
            colsDM_NDSC_Id.DisplayMember = "sTenNoiDungBaoHanh";
            colsDM_NDSC_Id.ValueMember = "Id";


            col = grdSanPham.GrdDetail.AddColumnText("sDM_DonViTinh_Id", "Đơn vị tính", 120,
                dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);

            MRepositoryItemLookUpEdit colsDM_DonViTinh_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_DonViTinh_Id.AddColumn("sTenDonViTinh", "Tên đơn vị tính", 180);
            colsDM_DonViTinh_Id.DataSource = dm_DonViTinhs;
            colsDM_DonViTinh_Id.DisplayMember = "sTenDonViTinh";
            colsDM_DonViTinh_Id.ValueMember = "Id";


            //grdSanPham.GrdDetail.AddColumnText("rSoLuong", "Số lượng", 80, dataType: MTControl.DataTypeColumn.SpinEdit);


            //grdSanPham.GrdDetail.AddColumnText("rDonGia", "Đơn giá", 150, dataType: MTControl.DataTypeColumn.SpinEdit);
            //grdSanPham.GrdDetail.AddColumnText("rThanhTien", "Thành tiền", 150, dataType: MTControl.DataTypeColumn.SpinEdit);

            var colsSerial = grdSanPham.GrdDetail.AddColumnText("sSerial", "Số Serial", 150);
            grdSanPham.GrdDetail.AddColumnText("sSTTSP", "STT Sản phẩm", 150,
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

            col = grdSanPham.GrdDetail.AddColumnText("sPhieu_XuatBaoHanhSanPham_CT_Id", "sPhieu_XuatBaoHanhSanPham_CT_Id", 0);
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
            var now= SysDateTime.Instance.Now();
            if (cboiLoai.GetValue().Equals((int)iLoaiNhapBaoHanh.NhapBH)) // Căn cứ phiếu xuất ( xuất đi )
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

                    List<MT.Data.BO.Phieu_NhapBaoHanhSanPham_CT> phieu_NhapBaoHanhSanPham_CTs = grdSanPham.GrdDetail.GetAllData<MT.Data.BO.Phieu_NhapBaoHanhSanPham_CT>();
                    Phieu_NhapBaoHanhSanPham_CT phieu_NhapBaoHanhSanPham_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_NhapBaoHanhSanPham_CT>();
                    //Kiểm tra nếu mã vạch đã có trên danh sách rồi thì không cho nhập, cảnh báo trùng
                    if (phieu_NhapBaoHanhSanPham_CTs.Count > 1)
                    {
                        //Kiểm tra mã vạch có bị trùng hay không
                        MT.Data.BO.Phieu_NhapBaoHanhSanPham_CT findBysMaVach = phieu_NhapBaoHanhSanPham_CTs.Find(m => m.sMaVach.Equals(sMaVach) && m.Id != phieu_NhapBaoHanhSanPham_CT.Id);
                        if (findBysMaVach != null)
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
                        phieu_NhapBaoHanhSanPham_CT.sDM_ChungThuSo_Id = lkMaVachCTS.sDM_ChungThuSo_Id;
                    }

                    //Cập nhật thông tin MLL
                    var lkMaVachMLL = DBContext.GetRep2<LK_MaVach_MLLRepository>().GetLK_MaVach_MLLByMaVach(sMaVach);
                    if (lkMaVachMLL != null)
                    {
                        phieu_NhapBaoHanhSanPham_CT.sDM_MangLienLac_Id = lkMaVachMLL.sDM_MangLienLac_Id;
                    }


                    Guid? sPhieu_XuatBaoHanhSanPham_Id = null;
                    if (cbosPhieu_XuatBaoHanhSanPham_Id_CanCu.EditValue != null)
                    {
                        sPhieu_XuatBaoHanhSanPham_Id = Guid.Parse(cbosPhieu_XuatBaoHanhSanPham_Id_CanCu.EditValue.ToString());
                    }

                    if (sPhieu_XuatBaoHanhSanPham_Id.HasValue)
                    {


                        Phieu_XuatBaoHanhSanPham_CT phieu_XuatBaoHanhSanPham_CT = DBContext.GetRep2<Phieu_XuatBaoHanhSanPham_CTRepository>()
                                                                        .GetPhieu_XuatBaoHanhSanPham_CTsBysPhieu_XuatBaoHanhSanPham_IdAndsMaSP(sPhieu_XuatBaoHanhSanPham_Id.Value, sMaSP);

                        if (phieu_XuatBaoHanhSanPham_CT == null)
                        {
                            MMessage.ShowWarning($@"Phiếu xuất <{cbosPhieu_XuatBaoHanhSanPham_Id_CanCu.Text}> không tồn tại sản phẩm <{sMaSP}>");
                            return true;
                        }


                        //3. Kiểm tra sản phẩm đã nhập đủ so với kế hoạch chưa, nếu đủ rồi thì không cho nhập nữa
                        List<MT.Data.BO.Phieu_NhapBaoHanhSanPham_CT> phieu_NhapBaoHanhSanPham_CTs_others = DBContext.GetRep2<Phieu_NhapBaoHanhSanPham_CTRepository>().GetAllPhieuNhapCT(MT.Library.SessionData.OrganizationUnitId, (int)iLoaiPhieu.NhapBH, phieu_XuatBaoHanhSanPham_CT.Id);
                        decimal sl_others = phieu_NhapBaoHanhSanPham_CTs_others
                            .Where(m => m.sDM_SanPham_Id.Equals(phieu_XuatBaoHanhSanPham_CT.sDM_SanPham_Id) && m.Id != phieu_NhapBaoHanhSanPham_CT.Id)
                            .Sum(m => m.rSoLuong);

                        decimal sl_current = phieu_NhapBaoHanhSanPham_CTs
                            .Where(m => m.sDM_SanPham_Id.Equals(phieu_XuatBaoHanhSanPham_CT.sDM_SanPham_Id) && m.Id != phieu_NhapBaoHanhSanPham_CT.Id)
                            .Sum(m => m.rSoLuong);
                        if (sl_others + sl_current >= phieu_XuatBaoHanhSanPham_CT.rSoLuong)
                        {
                            MMessage.ShowWarning($@"Sản phẩm <{phieu_XuatBaoHanhSanPham_CT.sDM_SanPham_Id_Ten}> đã nhập đủ so với phiếu xuất");
                            return true;
                        }

                        //Lấy chi tiết phụ kiện theo kế hoạch
                        List<MT.Data.BO.Phieu_XuatBaoHanhSanPham_CT_PhuKien> phieu_XuatBaoHanhSanPham_CT_PhuKiens = DBContext.GetRep2<Phieu_XuatBaoHanhSanPham_CT_PhuKienRepository>()
                                                                                                    .GetPhieu_XuatBaoHanhSanPham_CT_PhuKiensBysPhieu_XuatBaoHanhSanPham_CT_Id(phieu_XuatBaoHanhSanPham_CT.Id);
                        List<MT.Data.BO.Phieu_NhapBaoHanhSanPham_CT_PhuKien> phieu_NhapBaoHanhSanPham_CT_PhuKiens = new List<Phieu_NhapBaoHanhSanPham_CT_PhuKien>();
                        if (phieu_XuatBaoHanhSanPham_CT_PhuKiens != null)
                        {
                            foreach (var item in phieu_XuatBaoHanhSanPham_CT_PhuKiens)
                            {
                                phieu_NhapBaoHanhSanPham_CT_PhuKiens.Add(new Phieu_NhapBaoHanhSanPham_CT_PhuKien
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
                                    sXuatXu = item.sXuatXu,
                                    SortOrder = item.SortOrder,
                                    MTEntityState = Enummation.MTEntityState.Add
                                });
                            }
                        }
                        phieu_NhapBaoHanhSanPham_CT.phieu_NhapBaoHanhSanPham_CT_PhuKiens = phieu_NhapBaoHanhSanPham_CT_PhuKiens;

                        phieu_NhapBaoHanhSanPham_CT.sDM_SanPham_Id = phieu_XuatBaoHanhSanPham_CT.sDM_SanPham_Id;
                        //phieu_NhapBaoHanhSanPham_CT.sDM_MangLienLac_Id = phieu_XuatBaoHanhSanPham_CT.sDM_MangLienLac_Id;
                        phieu_NhapBaoHanhSanPham_CT.sDM_TinhTrangHongHoc_Id = phieu_XuatBaoHanhSanPham_CT.sDM_TinhTrangHongHoc_Id;
                        phieu_NhapBaoHanhSanPham_CT.sDM_NoiDungBaoHanh_Id = phieu_XuatBaoHanhSanPham_CT.sDM_NoiDungBaoHanh_Id;
                        phieu_NhapBaoHanhSanPham_CT.rDonGia = phieu_XuatBaoHanhSanPham_CT.rDonGia;
                        phieu_NhapBaoHanhSanPham_CT.rThanhTien = phieu_XuatBaoHanhSanPham_CT.rDonGia;
                        phieu_NhapBaoHanhSanPham_CT.sDM_SanPham_Id_Ten = phieu_XuatBaoHanhSanPham_CT.sDM_SanPham_Id_Ten;
                        phieu_NhapBaoHanhSanPham_CT.sDM_DonViTinh_Id = phieu_XuatBaoHanhSanPham_CT.sDM_DonViTinh_Id;
                        phieu_NhapBaoHanhSanPham_CT.sXuatXu = phieu_XuatBaoHanhSanPham_CT.sXuatXu;


                        phieu_NhapBaoHanhSanPham_CT.sPhieu_XuatBaoHanhSanPham_Id = sPhieu_XuatBaoHanhSanPham_Id;
                        phieu_NhapBaoHanhSanPham_CT.sPhieu_XuatBaoHanhSanPham_CT_Id = phieu_XuatBaoHanhSanPham_CT.Id;


                        phieu_NhapBaoHanhSanPham_CT.sSTTSP = phieu_XuatBaoHanhSanPham_CT.sSTTSP;
                        phieu_NhapBaoHanhSanPham_CT.rSoLuong = 1;

                        phieu_NhapBaoHanhSanPham_CT.sCauHinhKyThuat = phieu_XuatBaoHanhSanPham_CT.sCauHinhKyThuat;
                        phieu_NhapBaoHanhSanPham_CT.iThoiGianBaoHanh = phieu_XuatBaoHanhSanPham_CT.iThoiGianBaoHanh;
                        phieu_NhapBaoHanhSanPham_CT.iDonViThoiGianBaoHanh = phieu_XuatBaoHanhSanPham_CT.iDonViThoiGianBaoHanh;
                        phieu_NhapBaoHanhSanPham_CT.iNamSX = phieu_XuatBaoHanhSanPham_CT.iNamSX;
                        phieu_NhapBaoHanhSanPham_CT.dHanBaoHanhDen = phieu_XuatBaoHanhSanPham_CT.dHanBaoHanhDen;
                    }
                    else
                    {
                        //. Không nhập theo px thì lấy sản phẩm theo Mã vạch
                        // Còn trường hợp lấy từ phiếu nhập e?
                        // ở đây nó có 2 chiều, chiều đi thì dựa vào kế hoạch xuất, chiều về phải dựa vào phiếu nhập
                        // đây là nhập nó dựa vào px chứ anh à ok
                        // Phiếu xuất em có sửa gì ko? phiếu xuất 
                        var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham), where: $"sMaSanPham='{sMaSP}'");
                        if (dm_SanPhams?.Count > 0)
                        {
                            DM_SanPham dM_SanPham = (DM_SanPham)dm_SanPhams[0];
                            phieu_NhapBaoHanhSanPham_CT.sDM_SanPham_Id = dM_SanPham.Id;
                            phieu_NhapBaoHanhSanPham_CT.sDM_DonViTinh_Id = dM_SanPham.sDM_DonViTinh_Id_Cap1;
                            phieu_NhapBaoHanhSanPham_CT.rDonGia = dM_SanPham.rDonGia_Cap1;
                            phieu_NhapBaoHanhSanPham_CT.rThanhTien = dM_SanPham.rDonGia_Cap1;
                            phieu_NhapBaoHanhSanPham_CT.sDM_SanPham_Id_Ten = dM_SanPham.sTenSanPham;
                            List<DM_PhuKien> dM_PhuKiens = ((DM_PhuKienRepository)DBContext.GetRep<MT.Data.Rep.DM_PhuKienRepository>()).GetPhuKiensBysDM_SanPham_Id(dM_SanPham.Id);
                            List<MT.Data.BO.Phieu_NhapBaoHanhSanPham_CT_PhuKien> phieu_NhapBaoHanhSanPham_CT_PhuKiens = new List<Phieu_NhapBaoHanhSanPham_CT_PhuKien>();
                            foreach (var item in dM_PhuKiens)
                            {
                                phieu_NhapBaoHanhSanPham_CT_PhuKiens.Add(new Phieu_NhapBaoHanhSanPham_CT_PhuKien
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
                            phieu_NhapBaoHanhSanPham_CT.phieu_NhapBaoHanhSanPham_CT_PhuKiens = phieu_NhapBaoHanhSanPham_CT_PhuKiens;

                            phieu_NhapBaoHanhSanPham_CT.rSoLuong = 1;

                            phieu_NhapBaoHanhSanPham_CT.sPhieu_XuatBaoHanhSanPham_Id = null;
                            phieu_NhapBaoHanhSanPham_CT.sPhieu_XuatBaoHanhSanPham_CT_Id = null;

                            phieu_NhapBaoHanhSanPham_CT.sSerial = string.Empty;
                            phieu_NhapBaoHanhSanPham_CT.sCauHinhKyThuat = string.Empty;
                            phieu_NhapBaoHanhSanPham_CT.iThoiGianBaoHanh = 60;
                            phieu_NhapBaoHanhSanPham_CT.iDonViThoiGianBaoHanh = (int)MT.Data.iDonViThoiGianHieuLuc.Ngay;
                            phieu_NhapBaoHanhSanPham_CT.iNamSX = now.Year;
                            phieu_NhapBaoHanhSanPham_CT.dHanBaoHanhDen = now.AddDays(60);
                        }
                    }
                    phieu_NhapBaoHanhSanPham_CT.IsLoaded = true;
                    phieu_NhapBaoHanhSanPham_CT.sSerial = sSerial;

                    // Truong 2022
                    var dm_Phieu_NhapSanPhamMois = DBContext.GetRep<MT.Data.Rep.Phieu_NhapSanPhamMoi_CTRepository>().GetData(typeof(MT.Data.BO.Phieu_NhapSanPhamMoi_CT),
                        columns: "iThoiGianBaoHanh,iDonViThoiGianBaoHanh,iNamSX,dHanBaoHanhDen",
                        viewName: "View_Phieu_NhapSanPhamMoi_CT",
                        where: $"sMaVach='{sMaVach}'");
                    if (dm_Phieu_NhapSanPhamMois != null && dm_Phieu_NhapSanPhamMois.Count == 1)
                    {
                        Phieu_NhapSanPhamMoi_CT curPNM = (Phieu_NhapSanPhamMoi_CT)dm_Phieu_NhapSanPhamMois[0];
                        phieu_NhapBaoHanhSanPham_CT.iThoiGianBaoHanh = curPNM.iThoiGianBaoHanh;
                        phieu_NhapBaoHanhSanPham_CT.iDonViThoiGianBaoHanh = curPNM.iDonViThoiGianBaoHanh;
                        phieu_NhapBaoHanhSanPham_CT.iNamSX = (int)curPNM.iNamSX;
                        phieu_NhapBaoHanhSanPham_CT.dHanBaoHanhDen = curPNM.dHanBaoHanhDen;
                    }
                    //Từ động thêm dòng tiếp theo
                    grdSanPham.GrdDetail.AddRow(false);
                }
            }
            else if (cboiLoai.GetValue().Equals((int)iLoaiNhapBaoHanh.NhapNhanVeSauBH)) // Căn cứ phiếu xuất ( xuất trả về )
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

                    List<MT.Data.BO.Phieu_NhapBaoHanhSanPham_CT> phieu_NhapBaoHanhSanPham_CTs = grdSanPham.GrdDetail.GetAllData<MT.Data.BO.Phieu_NhapBaoHanhSanPham_CT>();
                    Phieu_NhapBaoHanhSanPham_CT phieu_NhapBaoHanhSanPham_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_NhapBaoHanhSanPham_CT>();
                    //Kiểm tra nếu mã vạch đã có trên danh sách rồi thì không cho nhập, cảnh báo trùng
                    if (phieu_NhapBaoHanhSanPham_CTs.Count > 1)
                    {
                        //Kiểm tra mã vạch có bị trùng hay không
                        MT.Data.BO.Phieu_NhapBaoHanhSanPham_CT findBysMaVach = phieu_NhapBaoHanhSanPham_CTs.Find(m => m.sMaVach.Equals(sMaVach) && m.Id != phieu_NhapBaoHanhSanPham_CT.Id);
                        if (findBysMaVach != null)
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
                        phieu_NhapBaoHanhSanPham_CT.sDM_ChungThuSo_Id = lkMaVachCTS.sDM_ChungThuSo_Id;
                    }

                    //Cập nhật thông tin MLL
                    var lkMaVachMLL = DBContext.GetRep2<LK_MaVach_MLLRepository>().GetLK_MaVach_MLLByMaVach(sMaVach);
                    if (lkMaVachMLL != null)
                    {
                        phieu_NhapBaoHanhSanPham_CT.sDM_MangLienLac_Id = lkMaVachMLL.sDM_MangLienLac_Id;
                    }

                    Guid? sPhieu_XuatBaoHanhSanPham_Id = null;
                    if (cbosPhieu_XuatBaoHanhSanPham_Id_CanCu.EditValue != null)
                    {
                        sPhieu_XuatBaoHanhSanPham_Id = Guid.Parse(cbosPhieu_XuatBaoHanhSanPham_Id_CanCu.EditValue.ToString());
                    }

                    if (sPhieu_XuatBaoHanhSanPham_Id.HasValue)
                    {
                        //2. Kiểm tra phiếu xuất có theo đúng kế hoạch không
                        Phieu_XuatBaoHanhSanPham_CT phieu_XuatBaoHanhSanPham_CT = DBContext.GetRep2<Phieu_XuatBaoHanhSanPham_CTRepository>()
                                                                            .GetPhieu_XuatBaoHanhSanPham_CTsBysPhieu_XuatBaoHanhSanPham_IdAndsMaSP(sPhieu_XuatBaoHanhSanPham_Id.Value, sMaSP);
                        if (phieu_XuatBaoHanhSanPham_CT == null)
                        {
                            MMessage.ShowWarning($@"Phiếu xuất cài đặt <{cbosPhieu_XuatBaoHanhSanPham_Id_CanCu.Text}> không tồn tại sản phẩm <{sMaSP}>");
                            return true;
                        }

                        //3. Kiểm tra sản phẩm đã nhập đủ so với kế hoạch chưa, nếu đủ rồi thì không cho nhập nữa
                        List<MT.Data.BO.Phieu_NhapBaoHanhSanPham_CT> phieu_NhapBaoHanhSanPham_CTs_others = DBContext.GetRep2<Phieu_NhapBaoHanhSanPham_CTRepository>().GetAllPhieuNhapCT(MT.Library.SessionData.OrganizationUnitId, (int)iLoaiPhieu.NhapNhanVeSauBH, phieu_XuatBaoHanhSanPham_CT.Id);
                        decimal sl_others = phieu_NhapBaoHanhSanPham_CTs_others
                            .Where(m => m.sDM_SanPham_Id.Equals(phieu_XuatBaoHanhSanPham_CT.sDM_SanPham_Id) && m.Id != phieu_NhapBaoHanhSanPham_CT.Id)
                            .Sum(m => m.rSoLuong);

                        decimal sl_current = phieu_NhapBaoHanhSanPham_CTs
                            .Where(m => m.sDM_SanPham_Id.Equals(phieu_XuatBaoHanhSanPham_CT.sDM_SanPham_Id) && m.Id != phieu_NhapBaoHanhSanPham_CT.Id)
                            .Sum(m => m.rSoLuong);
                        if (sl_others + sl_current >= phieu_XuatBaoHanhSanPham_CT.rSoLuong)
                        {
                            MMessage.ShowWarning($@"Sản phẩm <{phieu_XuatBaoHanhSanPham_CT.sDM_SanPham_Id_Ten}> đã nhập đủ so với phiếu xuất");
                            return true;
                        }

                        //Lấy chi tiết phụ kiện theo PX BH
                        List<MT.Data.BO.Phieu_XuatBaoHanhSanPham_CT_PhuKien> phieu_XuatBaoHanhSanPham_CT_PhuKiens = DBContext.GetRep2<Phieu_XuatBaoHanhSanPham_CT_PhuKienRepository>()
                                                                                                    .GetPhieu_XuatBaoHanhSanPham_CT_PhuKiensBysPhieu_XuatBaoHanhSanPham_CT_Id(phieu_XuatBaoHanhSanPham_CT.Id);
                        List<MT.Data.BO.Phieu_NhapBaoHanhSanPham_CT_PhuKien> phieu_NhapBaoHanhSanPham_CT_PhuKiens = new List<Phieu_NhapBaoHanhSanPham_CT_PhuKien>();
                        if (phieu_XuatBaoHanhSanPham_CT_PhuKiens != null)
                        {
                            foreach (var item in phieu_XuatBaoHanhSanPham_CT_PhuKiens)
                            {
                                phieu_NhapBaoHanhSanPham_CT_PhuKiens.Add(new Phieu_NhapBaoHanhSanPham_CT_PhuKien
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
                                    sXuatXu = item.sXuatXu,
                                    SortOrder = item.SortOrder,
                                    MTEntityState = Enummation.MTEntityState.Add
                                });
                            }
                        }

                        phieu_NhapBaoHanhSanPham_CT.phieu_NhapBaoHanhSanPham_CT_PhuKiens = phieu_NhapBaoHanhSanPham_CT_PhuKiens;

                        phieu_NhapBaoHanhSanPham_CT.sXuatXu = phieu_XuatBaoHanhSanPham_CT.sXuatXu;
                        //phieu_NhapBaoHanhSanPham_CT.sDM_MangLienLac_Id = phieu_XuatBaoHanhSanPham_CT.sDM_MangLienLac_Id;
                        phieu_NhapBaoHanhSanPham_CT.sDM_TinhTrangHongHoc_Id = phieu_XuatBaoHanhSanPham_CT.sDM_TinhTrangHongHoc_Id;
                        phieu_NhapBaoHanhSanPham_CT.sDM_NoiDungBaoHanh_Id = phieu_XuatBaoHanhSanPham_CT.sDM_NoiDungBaoHanh_Id;
                        phieu_NhapBaoHanhSanPham_CT.sDM_SanPham_Id = phieu_XuatBaoHanhSanPham_CT.sDM_SanPham_Id;
                        phieu_NhapBaoHanhSanPham_CT.sDM_DonViTinh_Id = phieu_XuatBaoHanhSanPham_CT.sDM_DonViTinh_Id;
                        phieu_NhapBaoHanhSanPham_CT.rDonGia = phieu_XuatBaoHanhSanPham_CT.rDonGia;
                        phieu_NhapBaoHanhSanPham_CT.rThanhTien = phieu_XuatBaoHanhSanPham_CT.rDonGia;
                        phieu_NhapBaoHanhSanPham_CT.sDM_SanPham_Id_Ten = phieu_XuatBaoHanhSanPham_CT.sDM_SanPham_Id_Ten;

                        phieu_NhapBaoHanhSanPham_CT.sPhieu_XuatBaoHanhSanPham_Id = sPhieu_XuatBaoHanhSanPham_Id;
                        phieu_NhapBaoHanhSanPham_CT.sPhieu_XuatBaoHanhSanPham_CT_Id = phieu_XuatBaoHanhSanPham_CT.Id;

                        phieu_NhapBaoHanhSanPham_CT.sSTTSP = phieu_XuatBaoHanhSanPham_CT.sSTTSP;
                        phieu_NhapBaoHanhSanPham_CT.rSoLuong = 1;
                        phieu_NhapBaoHanhSanPham_CT.iThoiGianBaoHanh = phieu_XuatBaoHanhSanPham_CT.iThoiGianBaoHanh; ;
                        phieu_NhapBaoHanhSanPham_CT.iDonViThoiGianBaoHanh = phieu_XuatBaoHanhSanPham_CT.iDonViThoiGianBaoHanh;
                        phieu_NhapBaoHanhSanPham_CT.iNamSX = phieu_XuatBaoHanhSanPham_CT.iNamSX;
                        phieu_NhapBaoHanhSanPham_CT.dHanBaoHanhDen = phieu_XuatBaoHanhSanPham_CT.dHanBaoHanhDen;
                    }
                    else
                    {
                        //. Không nhập theo px thì lấy sản phẩm theo Mã vạch
                        // Còn trường hợp lấy từ phiếu nhập e?
                        // ở đây nó có 2 chiều, chiều đi thì dựa vào kế hoạch xuất, chiều về phải dựa vào phiếu nhập
                        // đây là nhập nó dựa vào px chứ anh à ok
                        // Phiếu xuất em có sửa gì ko? phiếu xuất 
                        var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham), where: $"sMaSanPham='{sMaSP}'");

                        if (dm_SanPhams?.Count > 0)
                        {
                            DM_SanPham dM_SanPham = (DM_SanPham)dm_SanPhams[0];
                            phieu_NhapBaoHanhSanPham_CT.sDM_SanPham_Id = dM_SanPham.Id;
                            phieu_NhapBaoHanhSanPham_CT.sDM_DonViTinh_Id = dM_SanPham.sDM_DonViTinh_Id_Cap1;
                            phieu_NhapBaoHanhSanPham_CT.rDonGia = dM_SanPham.rDonGia_Cap1;
                            phieu_NhapBaoHanhSanPham_CT.rThanhTien = dM_SanPham.rDonGia_Cap1;
                            phieu_NhapBaoHanhSanPham_CT.sDM_SanPham_Id_Ten = dM_SanPham.sTenSanPham;
                            List<DM_PhuKien> dM_PhuKiens = ((DM_PhuKienRepository)DBContext.GetRep<MT.Data.Rep.DM_PhuKienRepository>()).GetPhuKiensBysDM_SanPham_Id(dM_SanPham.Id);
                            List<MT.Data.BO.Phieu_NhapBaoHanhSanPham_CT_PhuKien> phieu_NhapBaoHanhSanPham_CT_PhuKiens = new List<Phieu_NhapBaoHanhSanPham_CT_PhuKien>();
                            foreach (var item in dM_PhuKiens)
                            {
                                phieu_NhapBaoHanhSanPham_CT_PhuKiens.Add(new Phieu_NhapBaoHanhSanPham_CT_PhuKien
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
                            phieu_NhapBaoHanhSanPham_CT.phieu_NhapBaoHanhSanPham_CT_PhuKiens = phieu_NhapBaoHanhSanPham_CT_PhuKiens;

                            phieu_NhapBaoHanhSanPham_CT.sPhieu_XuatBaoHanhSanPham_Id = null;
                            phieu_NhapBaoHanhSanPham_CT.sPhieu_XuatBaoHanhSanPham_CT_Id = null;

                            phieu_NhapBaoHanhSanPham_CT.rSoLuong = 1;
                            phieu_NhapBaoHanhSanPham_CT.iThoiGianBaoHanh = 60;
                            phieu_NhapBaoHanhSanPham_CT.sSerial = string.Empty;
                            phieu_NhapBaoHanhSanPham_CT.iThoiGianBaoHanh = 60;
                            phieu_NhapBaoHanhSanPham_CT.iDonViThoiGianBaoHanh = (int)MT.Data.iDonViThoiGianHieuLuc.Ngay;
                            phieu_NhapBaoHanhSanPham_CT.iNamSX = now.Year;
                            phieu_NhapBaoHanhSanPham_CT.dHanBaoHanhDen =now.AddDays(60);
                        }
                    }
                    phieu_NhapBaoHanhSanPham_CT.IsLoaded = true;
                    phieu_NhapBaoHanhSanPham_CT.sSerial = sSerial;

                    // Truong 2022
                    var dm_Phieu_NhapSanPhamMois = DBContext.GetRep<MT.Data.Rep.Phieu_NhapSanPhamMoi_CTRepository>().GetData(typeof(MT.Data.BO.Phieu_NhapSanPhamMoi_CT),
                        columns: "iThoiGianBaoHanh,iDonViThoiGianBaoHanh,iNamSX,dHanBaoHanhDen",
                        viewName: "View_Phieu_NhapSanPhamMoi_CT",
                        where: $"sMaVach='{sMaVach}'");
                    if (dm_Phieu_NhapSanPhamMois != null && dm_Phieu_NhapSanPhamMois.Count == 1)
                    {
                        Phieu_NhapSanPhamMoi_CT curPNM = (Phieu_NhapSanPhamMoi_CT)dm_Phieu_NhapSanPhamMois[0];
                        phieu_NhapBaoHanhSanPham_CT.iThoiGianBaoHanh = curPNM.iThoiGianBaoHanh;
                        phieu_NhapBaoHanhSanPham_CT.iDonViThoiGianBaoHanh = curPNM.iDonViThoiGianBaoHanh;
                        phieu_NhapBaoHanhSanPham_CT.iNamSX = (int)curPNM.iNamSX;
                        phieu_NhapBaoHanhSanPham_CT.dHanBaoHanhDen = curPNM.dHanBaoHanhDen;
                    }

                    //Từ động thêm dòng tiếp theo
                    grdSanPham.GrdDetail.AddRow(false);
                }
            }

            return true;
        }



        /// <summary>
        /// Validate giá trị trước khi gán cho grid
        /// </summary>
        /// <param name="gridColumn"></param>
        /// <param name="e"></param>
        /// <returns>=true cho gán,ngược lại ko cho gán</returns>
        private bool grdSanPham_ValidEditValueChanging(DevExpress.XtraGrid.Columns.GridColumn gridColumn, ChangingEventArgs e)
        {
            if (cboiLoai.GetValue().Equals((int)iLoaiNhapBaoHanh.NhapBH))
            {
                if (gridColumn.FieldName == "sSerial" && e.NewValue != null && !object.Equals(e.OldValue, e.NewValue))
                {
                    string[] arrSerial = e.NewValue.ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    Phieu_NhapBaoHanhSanPham_CT phieu_NhapSanPham = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_NhapBaoHanhSanPham_CT>();
                    if (arrSerial.Length > 0 && (decimal)arrSerial.Length > phieu_NhapSanPham.rSoLuong)
                    {
                        e.NewValue = string.Empty;
                        MMessage.ShowWarning($"Bạn chỉ được phép chọn tối đa {(int)phieu_NhapSanPham.rSoLuong} số serial");
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion
        #region"Event"

        /// <summary>
        /// Click hiển thị form nhập chi tiết phụ kiện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColsActionPhuKien_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //Bắt bắt chọn sản phẩm roh thì mới cho nhập phụ kiện
            var Phieu_NhapBaoHanhSanPham_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_NhapBaoHanhSanPham_CT>();
            if (Phieu_NhapBaoHanhSanPham_CT.sDM_SanPham_Id.HasValue && !Phieu_NhapBaoHanhSanPham_CT.sDM_SanPham_Id.Value.Equals(Guid.Empty))
            {
                frmPhuKienDetail frmPhuKienDetail = new frmPhuKienDetail(Phieu_NhapBaoHanhSanPham_CT.sDM_SanPham_Id.Value,
                    "Phieu_NhapBaoHanhSanPham_CT_PhuKien", "Phieu_NhapBaoHanhSanPham_CT_PhuKiens",
                    Phieu_NhapBaoHanhSanPham_CT, this, false, "KH_BaoHanhSanPham_CT_PhuKien");
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
                List<MT.Data.BO.Phieu_NhapBaoHanhSanPham_CT> Phieu_NhapBaoHanhSanPham_CTs = mGridEditable.GrdDetail.GetAllData<MT.Data.BO.Phieu_NhapBaoHanhSanPham_CT>();

                foreach (var item in dataChanged)
                {
                    var castItem = (MT.Data.BO.Phieu_NhapBaoHanhSanPham_CT)item;
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

                    //3. Cột mã vạch không được trùng nhau
                    if (isValid && Phieu_NhapBaoHanhSanPham_CTs != null && Phieu_NhapBaoHanhSanPham_CTs.Count > 0)
                    {
                        //Kiểm tra mã vạch có bị trùng hay không
                        MT.Data.BO.Phieu_NhapBaoHanhSanPham_CT findBysMaVach = Phieu_NhapBaoHanhSanPham_CTs.Find(m => m.sMaVach.Equals(castItem.sMaVach) && m.Id != castItem.Id);
                        if (findBysMaVach != null)
                        {
                            isValid = false;
                            mGridEditable.GrdDetail.FirstView.FocusedColumn = mGridEditable.GrdDetail.FirstView.Columns["sMaVach"];
                            mGridEditable.GrdDetail.FirstView.FocusedRowHandle = castItem.RowHandle;
                            MMessage.ShowWarning($"Mã vạch <{castItem.sMaVach}> của sản phẩm <{castItem.sDM_SanPham_Id_Ten}>, đơn vị tính <{dM_DonViTinh.sTenDonViTinh}> đã tồn tại");
                            break;
                        }
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
                case "Phieu_NhapBaoHanhSanPham_CT":
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
                case "Phieu_NhapBaoHanhSanPham_CT":
                    Phieu_NhapBaoHanhSanPham_CT Phieu_NhapBaoHanhSanPham_CT = mGridControl.GetRecordByRowSelected<Phieu_NhapBaoHanhSanPham_CT>();
                    if (e.Column.FieldName == "rSoLuong" || e.Column.FieldName == "rDonGia")
                    {
                        Phieu_NhapBaoHanhSanPham_CT.rThanhTien = Phieu_NhapBaoHanhSanPham_CT.rSoLuong * Phieu_NhapBaoHanhSanPham_CT.rDonGia;
                    }
                    if (e.Column.FieldName == "sSerial")
                    {
                        object objsSerial = e.Value;
                        if (objsSerial != null)
                        {
                            string[] arrSerial = objsSerial.ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (arrSerial.Length >= 1)
                            {
                                Phieu_NhapBaoHanhSanPham_CT.rSoLuong = arrSerial.Length;
                            }
                        }
                    }
                    var now = SysDateTime.Instance.Now();
                    if (e.Column.FieldName == "iThoiGianBaoHanh" || e.Column.FieldName == "iDonViThoiGianBaoHanh")
                    {
                        DateTime? dHanBaoHanhDen = null;
                        switch (Phieu_NhapBaoHanhSanPham_CT.iDonViThoiGianBaoHanh)
                        {
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Ngay:
                                dHanBaoHanhDen = now.AddDays(Phieu_NhapBaoHanhSanPham_CT.iThoiGianBaoHanh).AddDays(1);
                                break;
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Thang:
                                dHanBaoHanhDen = now.AddMonths(Phieu_NhapBaoHanhSanPham_CT.iThoiGianBaoHanh).AddDays(1);
                                break;
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Quy:
                                dHanBaoHanhDen = now.AddYears(Phieu_NhapBaoHanhSanPham_CT.iThoiGianBaoHanh * 3).AddDays(1);
                                break;
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Nam:
                                dHanBaoHanhDen =now.AddYears(Phieu_NhapBaoHanhSanPham_CT.iThoiGianBaoHanh).AddDays(1);
                                break;
                        }
                        Phieu_NhapBaoHanhSanPham_CT.dHanBaoHanhDen = dHanBaoHanhDen;
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
                    cbosPhieu_XuatBaoHanhSanPham_Id_CanCu.SetReadOnly(false);
                    break;
                default:
                    cbosPhieu_XuatBaoHanhSanPham_Id_CanCu.SetReadOnly(true);
                    break;
            }

            cbosDM_CanBo_Id_NguoiLapPhieu.SetReadOnly(true);
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
                    ucThamChieuPhieu.sObjectId = Guid.Parse(this.CurrentData.GetIdentity().ToString());
                    ucThamChieuPhieu.sTenBangCanCu = "Phieu_NhapBaoHanhSanPham";
                    ucThamChieuPhieu.LoadData();
                    break;
            }
        }


        /// <summary>
        /// Xử lý dữ liệu trước khi binding lên form
        /// </summary>
        /// <returns></returns>
        protected override BaseEntity PrepareDataBeforeBindDataForm()
        {
            var currentData = (Phieu_NhapBaoHanhSanPham)base.PrepareDataBeforeBindDataForm();

            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:
                    currentData.dNgayPhieu_Nhap = SysDateTime.Instance.Now();
                    currentData.sDM_DonVi_Id_Nhap = MT.Library.SessionData.OrganizationUnitId;
                    currentData.sDM_CanBo_Id_NguoiLapPhieu = MT.Library.SessionData.UserId;
                    currentData.sDM_CanBo_Id_NguoiNhap = MT.Library.SessionData.UserId;
                    currentData.iNhapVeKho = true;
                    if (this.FormAction == (int)MTControl.FormAction.Add)
                    {
                        currentData.sPhieu_XuatBaoHanhSanPham_Id_CanCu = null;
                    }
                    break;
            }
            return currentData;
        }

        /// <summary>
        /// Chọn Kế hoạch xuất thì gán lại các giá trị cho control bên cạnh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbosPhieu_XuatBaoHanhSanPham_Id_CanCu_EditValueChanged(object sender, EventArgs e)
        {
            if (cboiLoai.GetValue().Equals((int)iLoaiNhapBaoHanh.NhapBH))
            {
                MT.Data.BO.Phieu_XuatBaoHanhSanPham phieu_XuatBaoHanhSanPham = cbosPhieu_XuatBaoHanhSanPham_Id_CanCu.GetRecordSelected<MT.Data.BO.Phieu_XuatBaoHanhSanPham>();
                if (phieu_XuatBaoHanhSanPham != null)
                {
                    //treesDM_DonVi_Id_Xuat.SetReadOnly(true);
                    //treesDM_DonVi_Id_Nhap.SetReadOnly(true);
                    //cbosDM_CanBo_Id_NguoiGiao.SetReadOnly(true);
                    //cbosDM_CanBo_Id_NguoiNhap.SetReadOnly(true);
                    treesDM_DonVi_Id_Xuat.SetValue(phieu_XuatBaoHanhSanPham.sDM_DonVi_Id_Xuat);
                    treesDM_DonVi_Id_Nhap.SetValue(phieu_XuatBaoHanhSanPham.sDM_DonVi_Id_Nhap);
                    cbosDM_CanBo_Id_NguoiGiao.SetValue(phieu_XuatBaoHanhSanPham.sDM_CanBo_Id_NguoiGiao);
                    cbosDM_CanBo_Id_NguoiNhap.SetValue(phieu_XuatBaoHanhSanPham.sDM_CanBo_Id_NguoiNhap);
                }
            }
            else if (cboiLoai.GetValue().Equals((int)iLoaiNhapBaoHanh.NhapNhanVeSauBH))
            {
                MT.Data.BO.Phieu_XuatBaoHanhSanPham phieu_XuatBaoHanhSanPham = cbosPhieu_XuatBaoHanhSanPham_Id_CanCu.GetRecordSelected<MT.Data.BO.Phieu_XuatBaoHanhSanPham>();
                if (phieu_XuatBaoHanhSanPham != null)
                {
                    //treesDM_DonVi_Id_Xuat.SetReadOnly(true);
                    //treesDM_DonVi_Id_Nhap.SetReadOnly(true);
                    //cbosDM_CanBo_Id_NguoiGiao.SetReadOnly(true);
                    //cbosDM_CanBo_Id_NguoiNhap.SetReadOnly(true);
                    treesDM_DonVi_Id_Xuat.SetValue(phieu_XuatBaoHanhSanPham.sDM_DonVi_Id_Xuat);
                    treesDM_DonVi_Id_Nhap.SetValue(phieu_XuatBaoHanhSanPham.sDM_DonVi_Id_Nhap);
                    cbosDM_CanBo_Id_NguoiGiao.SetValue(phieu_XuatBaoHanhSanPham.sDM_CanBo_Id_NguoiGiao);
                    cbosDM_CanBo_Id_NguoiNhap.SetValue(phieu_XuatBaoHanhSanPham.sDM_CanBo_Id_NguoiNhap);
                }
            }
        }

        private void cbosPhieu_XuatBaoHanhSanPham_Id_CanCu_QueryPopUp(object sender, CancelEventArgs e)
        {
            int iLoai = -1;
            if (cboiLoai.GetValue().Equals((int)iLoaiNhapBaoHanh.NhapBH))
            {
                iLoai = (int)iLoaiXuatBaoHanh.XuatBH;
            }
            else if (cboiLoai.GetValue().Equals((int)iLoaiNhapBaoHanh.NhapNhanVeSauBH))
            {
                iLoai = (int)iLoaiXuatBaoHanh.XuatTraSauBH;
            }
            cbosPhieu_XuatBaoHanhSanPham_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.Phieu_XuatBaoHanhSanPhamRepository>().GetData(typeof(MT.Data.BO.Phieu_XuatBaoHanhSanPham),
                            columns: "Id,sMa,dNgayPhieu_Xuat,sDM_DonVi_Id_Xuat,sDM_DonVi_Id_Xuat_Ten,sDM_DonVi_Id_Nhap,sDM_CanBo_Id_NguoiGiao,sDM_CanBo_Id_NguoiNhap",
                            where: $"(iLoai={iLoai} OR {iLoai}<=-1)  AND iTrangThaiThucHien < {(int)MT.Data.iTrangThaiThucHienKHNM.DaHoanThanh} AND iTrangThaiDuyet=1 AND sDM_DonVi_Id_Nhap='{SessionData.OrganizationUnitId}'",
                            orderBy: "sSo DESC", viewName: "View_Phieu_XuatBaoHanhSanPham");
        }

        private void cbosDM_CanBo_Id_NguoiNhap_QueryPopUp(object sender, CancelEventArgs e)
        {
            var sDM_DonVi_Id_Nhap = treesDM_DonVi_Id_Nhap.GetValue();
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

        private void cbosDM_CanBo_Id_NguoiGiao_QueryPopUp(object sender, CancelEventArgs e)
        {
            var sDM_DonVi_Id_Xuat = treesDM_DonVi_Id_Xuat.GetValue();
            if (sDM_DonVi_Id_Xuat == null)
                cbosDM_CanBo_Id_NguoiGiao.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                                columns: "Id,sMaCanBo,sTenCanBo", orderBy: "sMaCanBo");
            else
                cbosDM_CanBo_Id_NguoiGiao.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                                columns: "Id,sMaCanBo,sTenCanBo",
                                where: $"sDM_DonVi_Id='{sDM_DonVi_Id_Xuat.ToString()}' and iDictionaryKey NOT IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong},{(int)MT.Data.iChucVu.CucTruong},{(int)MT.Data.iChucVu.PhoCucTruong})",
                                orderBy: "sMaCanBo",
                                viewName: "View_DM_CanBo");
        }

        private void cbosDM_CanBo_Id_NguoiDuyet_QueryPopUp(object sender, CancelEventArgs e)
        {
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                   columns: "Id,sTenCanBo", viewName: "View_DM_CanBo",
                   where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' AND iDictionaryKey IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong})", orderBy: "sTen");
        }

        private void treesDM_DonVi_Id_Xuat_EditValueChanged(object sender, EventArgs e)
        {
            if (treesDM_DonVi_Id_Xuat.IsModified)
            {
                cbosDM_CanBo_Id_NguoiGiao.EditValue = null;
            }
        }

        private void treesDM_DonVi_Id_Nhap_EditValueChanged(object sender, EventArgs e)
        {
            if (treesDM_DonVi_Id_Nhap.IsModified)
            {
                cbosDM_CanBo_Id_NguoiNhap.EditValue = null;
            }
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
            configReport.RepName = "Print_Phieu_NhapBaoHanhSanPham_DetailRepository";
            //Định danh mẫu in trong bảng ReportData
            configReport.DictionaryKey = MT.Data.ReportDictionaryKey.RP_Print_Phieu_NhapBaoHanhSanPhamDetail;

            //Danh sách các cột trên table
            configExcel.ShowColumnsOrder = new HashSet<string>
            {
                "sSTT","sDM_SanPham_Id_Ten",
                "sDM_DonViTinh_Id_Ten","rSoLuong",
                "sDM_TinhTrangHongHoc_Id_Ten","sDM_NoiDungBaoHanh_Id_Ten",
                "sXuatXu",
            };

        }

        #endregion


    }
}
