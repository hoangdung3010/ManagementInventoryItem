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
    public partial class frmPhieu_XuatCaiDatSanPhamDetail : FormUI.MFormBusinessDetail
    {
        DM_DonViRepository dM_DonViRepository;
        public frmPhieu_XuatCaiDatSanPhamDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<Phieu_XuatCaiDatSanPhamRepository>(),
                    EntityName = "Phieu_XuatCaiDatSanPham",
                    Title = "Phiếu xuất cài đặt sản phẩm"
                };
            }
            GrdDetails = new Dictionary<string, MTControl.MGridEditable>
            {
                {"Phieu_XuatCaiDatSanPham_CT",grdSanPham }
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
            treesDM_DonVi_Id_Nhap.Properties.DisplayMember = "sTenDonvi";
            treesDM_DonVi_Id_Nhap.Properties.ValueMember = "Id";
            var treeList = treesDM_DonVi_Id_Nhap.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            treesDM_DonVi_Id_Nhap.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            treesDM_DonVi_Id_Nhap.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);

            var donviXayDungKH = dM_DonViRepository.GetDonViConCap1VaDonViCungCap(MT.Library.SessionData.OrganizationUnitId);

            treesDM_DonVi_Id_Nhap.Properties.DataSource = donviXayDungKH;


            treesDM_DonVi_Id_Xuat.Properties.DisplayMember = "sTenDonvi";
            treesDM_DonVi_Id_Xuat.Properties.ValueMember = "Id";
            var treeListXuat = treesDM_DonVi_Id_Xuat.Properties.TreeList;
            treeListXuat.KeyFieldName = "Id";
            treeListXuat.ParentFieldName = "sParentId";
            treesDM_DonVi_Id_Xuat.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            treesDM_DonVi_Id_Xuat.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            treesDM_DonVi_Id_Xuat.Properties.DataSource = donviXayDungKH;


            cbosKH_CaiDatSanPham_Id_CanCu.Properties.DisplayMember = "sMa";
            cbosKH_CaiDatSanPham_Id_CanCu.Properties.ValueMember = "Id";
            cbosKH_CaiDatSanPham_Id_CanCu.AddColumn("sMa", "Căn cứ số", 150);
            cbosKH_CaiDatSanPham_Id_CanCu.AddColumn("dNgayKeHoach", "Ngày lập", 180);

            cbosKH_CaiDatSanPham_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.KH_CaiDatSanPhamRepository>().GetData(typeof(MT.Data.BO.KH_CaiDatSanPham),
                orderBy: "sSo DESC", viewName: "View_KH_CaiDatSanPham_UNION_Phieu_XuatCaiDatSanPham");


            var dsCanBo = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                                 columns: "Id,sMaCanBo,sTenCanBo", orderBy: "sMaCanBo");

            cbosDM_CanBo_Id_NguoiNhap.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiNhap.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiNhap.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = dsCanBo;

            cbosDM_CanBo_Id_NguoiLapPhieu.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiLapPhieu.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiLapPhieu.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiLapPhieu.Properties.DataSource = dsCanBo;


            cbosDM_CanBo_Id_NguoiDuyet.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiDuyet.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiDuyet.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = dsCanBo;

            cbosDM_CanBo_Id_NguoiGiao.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiGiao.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiGiao.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiGiao.Properties.DataSource = dsCanBo;

            linkFormVoucher.ControlVoucher = cbosKH_CaiDatSanPham_Id_CanCu;
            linkFormVoucher.TableName = "KH_CaiDatSanPham";
            cboEnumiLoaiTCXuat.EnumData = "iTCXuatCĐ";
        }

        /// <summary>
        /// Khởi tạo thông tin grid
        /// </summary>
        private void InitGrid()
        {
            //Sản phẩm
            grdSanPham.GrdDetail.ViewName = "View_Phieu_XuatCaiDatSanPham_CT";
            grdSanPham.GrdDetail.KeyName = "Id";
            grdSanPham.GrdDetail.SetField = "phieu_XuatCaiDatSanPham_CTs";
            grdSanPham.GrdDetail.FirstView.OptionsNavigation.EnterMoveNextColumn = true;
            grdSanPham.GrdDetail.DisableFieldNames = @"sDM_SanPham_Id,sDM_SanPham_Id_Ten,rThanhTien,sDM_DonViTinh_Id,rSoLuong,dHanBaoHanhDen,sSerial";
            grdSanPham.GrdDetail.ValidEditValueChanging = grdSanPham_ValidEditValueChanging; // sDM_ChungThuSo_Id,sDM_MangLienLac_Id,
            grdSanPham.IsRequired = true;
            grdSanPham.InvalidText = "Danh sách sản phẩm không được bỏ trống";

            AddColumnsToGrid();
        }

        private void AddColumnsToGrid()
        {
            var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham), "Id,sMaSanPham,sTenSanPham", orderBy: "SortOrder");

            var dm_DonViTinhs = DBContext.GetRep<MT.Data.Rep.DM_DonViTinhRepository>().GetData(typeof(MT.Data.BO.DM_DonViTinh), "Id,sTenDonViTinh", orderBy: "SortOrder");

            var col = grdSanPham.GrdDetail.AddColumnText("sMaVach", "Mã vạch", 150, maxLength: 50,
                 fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left, isRequired: true);

            MRepositoryTextEdit colsMaVach = (MRepositoryTextEdit)col.ColumnEdit;
            colsMaVach.CustomEventEnter = grdSanPham_ColsMaVach_CustomEventEnter;

            col = grdSanPham.GrdDetail.AddColumnText("sDM_SanPham_Id", "Mã sản phẩm", 120, isFixWidth: true,
               fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left,
               dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);


            MRepositoryItemLookUpEdit colsDM_SanPham_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_SanPham_Id.AddColumn("sMaSanPham", "Mã sản phẩm", 150);
            colsDM_SanPham_Id.AddColumn("sTenSanPham", "Tên sản phẩm", 180);
            colsDM_SanPham_Id.DataSource = dm_SanPhams;
            colsDM_SanPham_Id.DisplayMember = "sMaSanPham";
            colsDM_SanPham_Id.ValueMember = "Id";

            col = grdSanPham.GrdDetail.AddColumnText("sDM_SanPham_Id_Ten", "Tên sản phẩm", 250, isRequired: true);

            col = grdSanPham.GrdDetail.AddColumnText("sDM_DonViTinh_Id", "Đơn vị tính", 120,
                dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);

            MRepositoryItemLookUpEdit colsDM_DonViTinh_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_DonViTinh_Id.AddColumn("sTenDonViTinh", "Tên đơn vị tính", 180);
            colsDM_DonViTinh_Id.DataSource = dm_DonViTinhs;
            colsDM_DonViTinh_Id.DisplayMember = "sTenDonViTinh";
            colsDM_DonViTinh_Id.ValueMember = "Id";

            //// Mạng LL
            col = grdSanPham.GrdDetail.AddColumnText("sDM_MangLienLac_Id", "Mạng liên lạc", 150,
               dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: false);

            MRepositoryItemLookUpEdit colsDM_MangLL_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_MangLL_Id.DictionaryName = "DM_MangLienLac";
            //colsDM_MangLL_Id.AddColumn("sMaMangLienLac", "Mã mạng liên lạc", 120);
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

            //// Nội dung cài đặt
            col = grdSanPham.GrdDetail.AddColumnText("sDM_NoiDungCaiDat_Id", "Nội dung CĐ", toolTip: "Nội dung cài đặt", 150,
               dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);

            MRepositoryItemLookUpEdit colsDM_NoiDungCaiDat_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_NoiDungCaiDat_Id.DictionaryName = "DM_NoiDungCaiDat";
            colsDM_NoiDungCaiDat_Id.AddColumn("sTenNoiDungCaiDat", "Nội dung cài đặt", 180);
            colsDM_NoiDungCaiDat_Id.DataSource = DBContext.GetRep<MT.Data.Rep.DM_NoiDungCaiDatRepository>()
                .GetData(typeof(MT.Data.BO.DM_NoiDungCaiDat), "Id,sTenNoiDungCaiDat", orderBy: "SortOrder"); ;
            colsDM_NoiDungCaiDat_Id.DisplayMember = "sTenNoiDungCaiDat";
            colsDM_NoiDungCaiDat_Id.ValueMember = "Id";



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
        }

        private void RemoveDisableField(String fieldName)
        {
            List<string> fields = grdSanPham.GrdDetail.DisableFieldNames.Split(',').ToList();
            fields.RemoveAll(field => field.Equals(fieldName));
            grdSanPham.GrdDetail.DisableFieldNames = String.Join(",", fields);
        }
        private void AddDisableField(String fieldName)
        {
            List<string> fields = grdSanPham.GrdDetail.DisableFieldNames.Split(',').ToList();
            fields.RemoveAll(field => field.Equals(fieldName));
            fields.Add(fieldName);
            grdSanPham.GrdDetail.DisableFieldNames = String.Join(",", fields);
        }

        /// <summary>
        /// Bắt event enter trên ô mã vạch
        /// </summary>
        /// <param name="mRepositoryTextEdit">Đối tượng trên grid</param>
        /// <param name="mTextEdit"></param>
        /// <returns>true: Cho phép custom, ngược lại không</returns>
        private bool grdSanPham_ColsMaVach_CustomEventEnter(MRepositoryTextEdit mRepositoryTextEdit, MTextEdit mTextEdit)
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

                List<MT.Data.BO.Phieu_XuatCaiDatSanPham_CT> phieu_XuatCaiDatSanPham_CTs = grdSanPham.GrdDetail.GetAllData<MT.Data.BO.Phieu_XuatCaiDatSanPham_CT>();
                Phieu_XuatCaiDatSanPham_CT phieu_XuatCaiDatSanPham_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_XuatCaiDatSanPham_CT>();

                // 1. Kiểm tra mã vạch có nằm trong kho không
                bool checkTonKho = CommonFnUI.CheckTonKhoPhieu(this.FormAction, sMaVach, grdSanPham.GrdDetail.GetDataChanges(), MT.Library.SessionData.OrganizationUnitId);

                if (!checkTonKho)
                {
                    return true;
                }

                // 2. Kiểm tra nếu mã vạch đã có trên danh sách rồi thì không cho xuất, cảnh báo trùng
                if (phieu_XuatCaiDatSanPham_CTs?.Count > 1)
                {
                    //Kiểm tra mã vạch có bị trùng hay không
                    MT.Data.BO.Phieu_XuatCaiDatSanPham_CT findBysMaVach = phieu_XuatCaiDatSanPham_CTs
                        .Find(m => m.sMaVach.Equals(sMaVach) && m.Id != phieu_XuatCaiDatSanPham_CT.Id);
                    if (findBysMaVach != null)
                    {
                        MMessage.ShowWarning($"Mã vạch <{sMaVach}> đã tồn tại trên danh sách");

                        return true;
                    }
                }
                var now = SysDateTime.Instance.Now();
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
                    phieu_XuatCaiDatSanPham_CT.sDM_ChungThuSo_Id = lkMaVachCTS.sDM_ChungThuSo_Id;
                }
                //Cập nhật thông tin MLL
                var lkMaVachMLL = DBContext.GetRep2<LK_MaVach_MLLRepository>().GetLK_MaVach_MLLByMaVach(sMaVach);
                if (lkMaVachMLL != null)
                {
                    phieu_XuatCaiDatSanPham_CT.sDM_MangLienLac_Id = lkMaVachMLL.sDM_MangLienLac_Id;
                }

                //Cập nhật thông tin Nội dung cài đặt
                var lkNoiDungCaiDat = DBContext.GetRep2<LK_MaVach_TinhTrangHongHocRepository>().GetTinhTrangCaiDat_ByMaVach(sMaVach, (int)cboEnumiLoaiTCXuat.GetValue());
                if (lkNoiDungCaiDat != null)
                {
                    phieu_XuatCaiDatSanPham_CT.sDM_NoiDungCaiDat_Id = lkNoiDungCaiDat.sDM_NoiDungCaiDat_Id;
                    phieu_XuatCaiDatSanPham_CT.sTinhTrangCaiDat = lkNoiDungCaiDat.sTinhTrangCaiDat;
                }
                // Trường hợp xuất đi ban đầu
                if (cboEnumiLoaiTCXuat.SelectedIndex == 0) // Căn cứ kế hoạch
                {

                    Guid? sKH_CaiDatSanPham_Id_CanCu = null;
                    if (cbosKH_CaiDatSanPham_Id_CanCu.EditValue != null)
                    {
                        sKH_CaiDatSanPham_Id_CanCu = Guid.Parse(cbosKH_CaiDatSanPham_Id_CanCu.EditValue.ToString());
                    }
                    if (sKH_CaiDatSanPham_Id_CanCu.HasValue)
                    {
                        // 3. Kiểm tra mã vạch có nằm trong kế hoạch hay không                

                        KH_CaiDatSanPham_CT kH_CaiDatSanPham_CT = DBContext.GetRep2<KH_CaiDatSanPham_CTRepository>()
                                                                            .GetKH_CaiDatSanPham_CTsBysKH_CaiDatSanPham_Id_CanCuAndsMaSP(sKH_CaiDatSanPham_Id_CanCu.Value, sMaSP);
                        if (kH_CaiDatSanPham_CT == null)
                        {
                            MMessage.ShowWarning($@"Kế xuất cài đặt <{cbosKH_CaiDatSanPham_Id_CanCu.Text}> không tồn tại sản phẩm <{sMaSP}>");
                            return true;
                        }

                        // 4. Kiểm tra sản phẩm đã nhập đủ so với kế hoạch chưa, nếu đủ rồi thì không cho nhập nữa
                        List<MT.Data.BO.Phieu_XuatCaiDatSanPham_CT> phieu_XuatCaiDatSanPham_CTs_others = DBContext.GetRep2<Phieu_XuatCaiDatSanPham_CTRepository>().GetAllPhieuXuatCT(MT.Library.SessionData.OrganizationUnitId, (int)iLoaiPhieu.XuatĐiCĐ, kH_CaiDatSanPham_CT.Id);
                        decimal sl_others = phieu_XuatCaiDatSanPham_CTs_others
                            .Where(m => m.sDM_SanPham_Id.Equals(kH_CaiDatSanPham_CT.sDM_SanPham_Id) && m.Id != phieu_XuatCaiDatSanPham_CT.Id)
                            .Sum(m => m.rSoLuong);

                        decimal sl_current = phieu_XuatCaiDatSanPham_CTs
                            .Where(m => m.sDM_SanPham_Id.Equals(kH_CaiDatSanPham_CT.sDM_SanPham_Id) && m.Id != phieu_XuatCaiDatSanPham_CT.Id)
                            .Sum(m => m.rSoLuong);

                        if (sl_others + sl_current >= kH_CaiDatSanPham_CT.rSoLuong)
                        {
                            MMessage.ShowWarning($@"Sản phẩm <{kH_CaiDatSanPham_CT.sDM_SanPham_Id_Ten}> đã nhập đủ so với kế hoạch");
                            return true;
                        }

                        //Lấy chi tiết phụ kiện theo kế hoạch
                        List<MT.Data.BO.KH_CaiDatSanPham_CT_PhuKien> kH_NhapSanPhamMoi_CT_PhuKiens = DBContext.GetRep2<KH_CaiDatSanPham_CT_PhuKienRepository>()
                                                                                                    .GetKH_CaiDatSanPham_CT_PhuKiensByKH_CaiDatSanPham_CT_Id(kH_CaiDatSanPham_CT.Id);

                        List<MT.Data.BO.Phieu_XuatCaiDatSanPham_CT_PhuKien> phieu_XuatCaiDatSanPham_CT_PhuKiens = new List<Phieu_XuatCaiDatSanPham_CT_PhuKien>();
                        if (kH_NhapSanPhamMoi_CT_PhuKiens != null)
                        {
                            foreach (var item in kH_NhapSanPhamMoi_CT_PhuKiens)
                            {
                                phieu_XuatCaiDatSanPham_CT_PhuKiens.Add(new Phieu_XuatCaiDatSanPham_CT_PhuKien
                                {
                                    Id = Guid.NewGuid(),
                                    sDM_SanPham_Id = item.sDM_SanPham_Id,
                                    sDM_SanPham_Id_Ten = item.sDM_SanPham_Id_Ten,
                                    sDM_PhuKien_Id = item.sDM_PhuKien_Id,
                                    sDM_PhuKien_Id_Ten = item.sDM_PhuKien_Id_Ten,
                                    sDM_DonViTinh_Id = item.sDM_DonViTinh_Id,
                                    rSoLuong = item.rSoLuong,
                                    rDonGia = item.rDonGia,
                                    rThanhTien = item.rSoLuong * item.rDonGia,
                                    SortOrder = item.SortOrder,
                                    MTEntityState = Enummation.MTEntityState.Add
                                });
                            }
                        }
                        phieu_XuatCaiDatSanPham_CT.phieuXuatCaiDatSanPham_CT_PhuKiens = phieu_XuatCaiDatSanPham_CT_PhuKiens;

                        phieu_XuatCaiDatSanPham_CT.sDM_SanPham_Id = kH_CaiDatSanPham_CT.sDM_SanPham_Id;
                        phieu_XuatCaiDatSanPham_CT.sDM_DonViTinh_Id = kH_CaiDatSanPham_CT.sDM_DonViTinh_Id;
                        phieu_XuatCaiDatSanPham_CT.rDonGia = kH_CaiDatSanPham_CT.rDonGia;
                        phieu_XuatCaiDatSanPham_CT.rSoLuong = 1;
                        phieu_XuatCaiDatSanPham_CT.rThanhTien = kH_CaiDatSanPham_CT.rDonGia;
                        phieu_XuatCaiDatSanPham_CT.sDM_SanPham_Id_Ten = kH_CaiDatSanPham_CT.sDM_SanPham_Id_Ten;



                        //phieu_XuatCaiDatSanPham_CT.sDM_MangLienLac_Id = kH_CaiDatSanPham_CT.sDM_MangLienLac_Id;
                        // phieu_XuatCaiDatSanPham_CT.sDM_MangLienLac_Id_Ten = kH_CaiDatSanPham_CT.sDM_MangLienLac_Id_Ten;
                        phieu_XuatCaiDatSanPham_CT.sDM_NoiDungCaiDat_Id = kH_CaiDatSanPham_CT.sDM_NoiDungCaiDat_Id;
                        phieu_XuatCaiDatSanPham_CT.sDM_NoiDungCaiDat_Id_Ten = kH_CaiDatSanPham_CT.sDM_NoiDungCaiDat_Id_Ten;


                        phieu_XuatCaiDatSanPham_CT.sKH_CaiDatSanPham_Id = sKH_CaiDatSanPham_Id_CanCu;
                        phieu_XuatCaiDatSanPham_CT.sKH_CaiDatSanPham_CT_Id = kH_CaiDatSanPham_CT.Id;


                        phieu_XuatCaiDatSanPham_CT.iThoiGianBaoHanh = 60;
                        phieu_XuatCaiDatSanPham_CT.iDonViThoiGianBaoHanh = (int)MT.Data.iDonViThoiGianHieuLuc.Ngay;
                        phieu_XuatCaiDatSanPham_CT.iNamSX = now.Year;
                        phieu_XuatCaiDatSanPham_CT.dHanBaoHanhDen = now.AddDays(60);
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
                            phieu_XuatCaiDatSanPham_CT.sDM_SanPham_Id = dM_SanPham.Id;
                            phieu_XuatCaiDatSanPham_CT.sDM_DonViTinh_Id = dM_SanPham.sDM_DonViTinh_Id_Cap1;
                            phieu_XuatCaiDatSanPham_CT.rDonGia = dM_SanPham.rDonGia_Cap1;
                            phieu_XuatCaiDatSanPham_CT.rThanhTien = dM_SanPham.rDonGia_Cap1;
                            phieu_XuatCaiDatSanPham_CT.sDM_SanPham_Id_Ten = dM_SanPham.sTenSanPham;
                            List<DM_PhuKien> dM_PhuKiens = ((DM_PhuKienRepository)DBContext.GetRep<MT.Data.Rep.DM_PhuKienRepository>()).GetPhuKiensBysDM_SanPham_Id(dM_SanPham.Id);
                            List<MT.Data.BO.Phieu_XuatCaiDatSanPham_CT_PhuKien> phieu_XuatCaiDatSanPham_CT_PhuKiens = new List<Phieu_XuatCaiDatSanPham_CT_PhuKien>();
                            foreach (var item in dM_PhuKiens)
                            {
                                phieu_XuatCaiDatSanPham_CT_PhuKiens.Add(new Phieu_XuatCaiDatSanPham_CT_PhuKien
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
                            phieu_XuatCaiDatSanPham_CT.phieuXuatCaiDatSanPham_CT_PhuKiens = phieu_XuatCaiDatSanPham_CT_PhuKiens;
                            phieu_XuatCaiDatSanPham_CT.rSoLuong = 1;

                            phieu_XuatCaiDatSanPham_CT.sKH_CaiDatSanPham_Id = null;
                            phieu_XuatCaiDatSanPham_CT.sKH_CaiDatSanPham_CT_Id = null;


                            //phieu_XuatCaiDatSanPham_CT.sDM_MangLienLac_Id = null;
                            //phieu_XuatCaiDatSanPham_CT.sDM_MangLienLac_Id_Ten = null;
                            phieu_XuatCaiDatSanPham_CT.sDM_NoiDungCaiDat_Id = null;
                            phieu_XuatCaiDatSanPham_CT.sDM_NoiDungCaiDat_Id_Ten = null;


                            phieu_XuatCaiDatSanPham_CT.iThoiGianBaoHanh = 60;
                            phieu_XuatCaiDatSanPham_CT.sSerial = string.Empty;
                            phieu_XuatCaiDatSanPham_CT.iDonViThoiGianBaoHanh = (int)MT.Data.iDonViThoiGianHieuLuc.Ngay;
                            phieu_XuatCaiDatSanPham_CT.iNamSX = now.Year;
                            phieu_XuatCaiDatSanPham_CT.dHanBaoHanhDen =now.AddDays(60);
                        }
                    }

                    phieu_XuatCaiDatSanPham_CT.IsLoaded = true;
                    phieu_XuatCaiDatSanPham_CT.sSerial = sSerial;
                    phieu_XuatCaiDatSanPham_CT.sSTTSP = String.Empty;



                }
                else // Căn cứ phiếu nhập
                {
                    Guid? sKH_CaiDatSanPham_Id_CanCu = null;
                    if (cbosKH_CaiDatSanPham_Id_CanCu.EditValue != null)
                    {
                        sKH_CaiDatSanPham_Id_CanCu = Guid.Parse(cbosKH_CaiDatSanPham_Id_CanCu.EditValue.ToString());
                    }
                    if (sKH_CaiDatSanPham_Id_CanCu.HasValue)
                    {


                        Phieu_NhapCaiDatSanPham_CT phieu_NhapCaiDatSanPham_CT = DBContext.GetRep2<Phieu_NhapCaiDatSanPham_CTRepository>()
                                                                            .GetPhieu_NhapCaiDatSanPham_CTBysPhieu_NhapCaiDatSanPham_IdAndsMaSP(sKH_CaiDatSanPham_Id_CanCu.Value, sMaSP);
                        if (phieu_NhapCaiDatSanPham_CT == null)
                        {
                            MMessage.ShowWarning($@"Phiếu nhập cài đặt <{cbosKH_CaiDatSanPham_Id_CanCu.Text}> không tồn tại sản phẩm <{sMaSP}>");
                            return true;
                        }

                        ////3. Kiểm tra sản phẩm đã nhập đủ so với kế hoạch chưa, nếu đủ rồi thì không cho nhập nữa
                        //List<MT.Data.BO.Phieu_XuatCaiDatSanPham_CT> phieu_NhapCaiDatSanPham_CTs_others = DBContext.GetRep2<Phieu_XuatCaiDatSanPham_CTRepository>().GetAllPhieuXuatCT(MT.Library.SessionData.OrganizationUnitId, (int)iLoaiPhieu.XuatTraSauCĐ, phieu_NhapCaiDatSanPham_CT.Id);
                        //decimal sl_others = phieu_NhapCaiDatSanPham_CTs_others
                        //    .Where(m => m.sDM_SanPham_Id.Equals(phieu_NhapCaiDatSanPham_CT.sDM_SanPham_Id) && m.Id != phieu_XuatCaiDatSanPham_CT.Id)
                        //    .Sum(m => m.rSoLuong);

                        //decimal sl_current = phieu_XuatCaiDatSanPham_CTs
                        //    .Where(m => m.sDM_SanPham_Id.Equals(phieu_NhapCaiDatSanPham_CT.sDM_SanPham_Id) && m.Id != phieu_XuatCaiDatSanPham_CT.Id)
                        //    .Sum(m => m.rSoLuong);
                        //if (sl_others + sl_current >= phieu_NhapCaiDatSanPham_CT.rSoLuong)
                        //{
                        //    MMessage.ShowWarning($@"Sản phẩm <{phieu_NhapCaiDatSanPham_CT.sDM_SanPham_Id_Ten}> đã nhập đủ so với phiếu nhập vào");
                        //    return true;
                        //}



                        //Lấy chi tiết phụ kiện theo kế hoạch
                        List<MT.Data.BO.Phieu_NhapCaiDatSanPham_CT_PhuKien> phieu_NhapCaiDatSanPham_CT_PhuKiens = DBContext.GetRep2<Phieu_NhapCaiDatSanPham_CT_PhuKienRepository>()
                                                                                                    .GetPhieu_NhapCaiDatSanPham_CT_PhuKiensBysPhieu_NhapCaiDatSanPham_CT_Id(phieu_NhapCaiDatSanPham_CT.Id);
                        List<MT.Data.BO.Phieu_XuatCaiDatSanPham_CT_PhuKien> phieu_XuatCaiDatSanPham_CT_PhuKiens = new List<Phieu_XuatCaiDatSanPham_CT_PhuKien>();
                        if (phieu_NhapCaiDatSanPham_CT_PhuKiens != null)
                        {
                            foreach (var item in phieu_NhapCaiDatSanPham_CT_PhuKiens)
                            {
                                phieu_XuatCaiDatSanPham_CT_PhuKiens.Add(new Phieu_XuatCaiDatSanPham_CT_PhuKien
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
                        phieu_XuatCaiDatSanPham_CT.phieuXuatCaiDatSanPham_CT_PhuKiens = phieu_XuatCaiDatSanPham_CT_PhuKiens;
                        phieu_XuatCaiDatSanPham_CT.sDM_SanPham_Id = phieu_NhapCaiDatSanPham_CT.sDM_SanPham_Id;
                        phieu_XuatCaiDatSanPham_CT.sDM_DonViTinh_Id = phieu_NhapCaiDatSanPham_CT.sDM_DonViTinh_Id;
                        phieu_XuatCaiDatSanPham_CT.rDonGia = phieu_NhapCaiDatSanPham_CT.rDonGia;
                        phieu_XuatCaiDatSanPham_CT.rSoLuong = 1;
                        phieu_XuatCaiDatSanPham_CT.rThanhTien = phieu_NhapCaiDatSanPham_CT.rDonGia;
                        phieu_XuatCaiDatSanPham_CT.sDM_SanPham_Id_Ten = phieu_NhapCaiDatSanPham_CT.sDM_SanPham_Id_Ten;


                        //phieu_XuatCaiDatSanPham_CT.sDM_MangLienLac_Id = phieu_NhapCaiDatSanPham_CT.sDM_MangLienLac_Id;
                        //phieu_XuatCaiDatSanPham_CT.sDM_MangLienLac_Id_Ten = phieu_NhapCaiDatSanPham_CT.sDM_MangLienLac_Id_Ten;
                        phieu_XuatCaiDatSanPham_CT.sDM_NoiDungCaiDat_Id = phieu_NhapCaiDatSanPham_CT.sDM_NoiDungCaiDat_Id;
                        phieu_XuatCaiDatSanPham_CT.sDM_NoiDungCaiDat_Id_Ten = phieu_NhapCaiDatSanPham_CT.sDM_NoiDungCaiDat_Id_Ten;

                        phieu_XuatCaiDatSanPham_CT.sKH_CaiDatSanPham_Id = sKH_CaiDatSanPham_Id_CanCu;
                        phieu_XuatCaiDatSanPham_CT.sKH_CaiDatSanPham_CT_Id = phieu_NhapCaiDatSanPham_CT.Id;

                        phieu_NhapCaiDatSanPham_CT.sSTTSP = phieu_NhapCaiDatSanPham_CT.sSTTSP;

                        phieu_XuatCaiDatSanPham_CT.iThoiGianBaoHanh = 60;
                        phieu_XuatCaiDatSanPham_CT.iDonViThoiGianBaoHanh = (int)MT.Data.iDonViThoiGianHieuLuc.Ngay;
                        phieu_XuatCaiDatSanPham_CT.iNamSX = now.Year;
                        phieu_XuatCaiDatSanPham_CT.dHanBaoHanhDen =now.AddDays(60);
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
                            phieu_XuatCaiDatSanPham_CT.sDM_SanPham_Id = dM_SanPham.Id;
                            phieu_XuatCaiDatSanPham_CT.sDM_DonViTinh_Id = dM_SanPham.sDM_DonViTinh_Id_Cap1;
                            phieu_XuatCaiDatSanPham_CT.rDonGia = dM_SanPham.rDonGia_Cap1;
                            phieu_XuatCaiDatSanPham_CT.rThanhTien = dM_SanPham.rDonGia_Cap1;
                            phieu_XuatCaiDatSanPham_CT.sDM_SanPham_Id_Ten = dM_SanPham.sTenSanPham;
                            List<DM_PhuKien> dM_PhuKiens = ((DM_PhuKienRepository)DBContext.GetRep<MT.Data.Rep.DM_PhuKienRepository>()).GetPhuKiensBysDM_SanPham_Id(dM_SanPham.Id);
                            List<MT.Data.BO.Phieu_XuatCaiDatSanPham_CT_PhuKien> phieu_XuatCaiDatSanPham_CT_PhuKiens = new List<Phieu_XuatCaiDatSanPham_CT_PhuKien>();
                            foreach (var item in dM_PhuKiens)
                            {
                                phieu_XuatCaiDatSanPham_CT_PhuKiens.Add(new Phieu_XuatCaiDatSanPham_CT_PhuKien
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
                            phieu_XuatCaiDatSanPham_CT.phieuXuatCaiDatSanPham_CT_PhuKiens = phieu_XuatCaiDatSanPham_CT_PhuKiens;
                            phieu_XuatCaiDatSanPham_CT.rSoLuong = 1;

                            phieu_XuatCaiDatSanPham_CT.sKH_CaiDatSanPham_Id = null;
                            phieu_XuatCaiDatSanPham_CT.sKH_CaiDatSanPham_CT_Id = null;


                            //phieu_XuatCaiDatSanPham_CT.sDM_MangLienLac_Id = null;
                            //phieu_XuatCaiDatSanPham_CT.sDM_MangLienLac_Id_Ten = null;
                            phieu_XuatCaiDatSanPham_CT.sDM_NoiDungCaiDat_Id = null;
                            phieu_XuatCaiDatSanPham_CT.sDM_NoiDungCaiDat_Id_Ten = null;

                            phieu_XuatCaiDatSanPham_CT.iThoiGianBaoHanh = 60;
                            phieu_XuatCaiDatSanPham_CT.sSerial = string.Empty;
                            phieu_XuatCaiDatSanPham_CT.iThoiGianBaoHanh = 60;
                            phieu_XuatCaiDatSanPham_CT.iDonViThoiGianBaoHanh = (int)MT.Data.iDonViThoiGianHieuLuc.Ngay;
                            phieu_XuatCaiDatSanPham_CT.iNamSX = now.Year;
                            phieu_XuatCaiDatSanPham_CT.dHanBaoHanhDen = now.AddDays(60);
                            phieu_XuatCaiDatSanPham_CT.sSTTSP = String.Empty;

                        }
                    }
                    phieu_XuatCaiDatSanPham_CT.IsLoaded = true;
                    phieu_XuatCaiDatSanPham_CT.sSerial = sSerial;


                }

                // Truong 2022
                var dm_Phieu_NhapSanPhamMois = DBContext.GetRep<MT.Data.Rep.Phieu_NhapSanPhamMoi_CTRepository>().GetData(typeof(MT.Data.BO.Phieu_NhapSanPhamMoi_CT),
                    columns: "iThoiGianBaoHanh,iDonViThoiGianBaoHanh,iNamSX,dHanBaoHanhDen",
                    viewName: "View_Phieu_NhapSanPhamMoi_CT",
                    where: $"sMaVach='{sMaVach}'");
                if (dm_Phieu_NhapSanPhamMois != null && dm_Phieu_NhapSanPhamMois.Count == 1)
                {
                    Phieu_NhapSanPhamMoi_CT curPNM = (Phieu_NhapSanPhamMoi_CT)dm_Phieu_NhapSanPhamMois[0];
                    phieu_XuatCaiDatSanPham_CT.iThoiGianBaoHanh = curPNM.iThoiGianBaoHanh;
                    phieu_XuatCaiDatSanPham_CT.iDonViThoiGianBaoHanh = curPNM.iDonViThoiGianBaoHanh;
                    phieu_XuatCaiDatSanPham_CT.iNamSX = (int)curPNM.iNamSX;
                    phieu_XuatCaiDatSanPham_CT.dHanBaoHanhDen = curPNM.dHanBaoHanhDen;
                }
                //Từ động thêm dòng tiếp theo
                grdSanPham.GrdDetail.AddRow(false);
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
            if (gridColumn.FieldName == "sDM_ChungThuSo_Id"
                && int.Parse(cboEnumiLoaiTCXuat.GetValue().ToString()) == (int)MT.Data.iTCXuatCĐ.XuatCĐĐi
                && !object.Equals(e.OldValue, e.NewValue))
            {
                e.NewValue = e.OldValue;
                MMessage.ShowWarning($"Phiếu xuất đi cài đặt không được phép chọn chứng thư số.");
                return false;
            }
            if (gridColumn.FieldName == "sSerial" && e.NewValue != null && !object.Equals(e.OldValue, e.NewValue))
            {
                string[] arrSerial = e.NewValue.ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Phieu_XuatCaiDatSanPham_CT phieu_NhapSanPham = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_XuatCaiDatSanPham_CT>();
                if (arrSerial.Length > 0 && (decimal)arrSerial.Length > phieu_NhapSanPham.rSoLuong)
                {
                    e.NewValue = string.Empty;
                    MMessage.ShowWarning($"Bạn chỉ được phép chọn tối đa {(int)phieu_NhapSanPham.rSoLuong} số serial");
                    return false;
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
            var phieu_XuatCaiDatSanPham_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_XuatCaiDatSanPham_CT>();
            if (phieu_XuatCaiDatSanPham_CT.sDM_SanPham_Id.HasValue && !phieu_XuatCaiDatSanPham_CT.sDM_SanPham_Id.Value.Equals(Guid.Empty))
            {
                frmPhuKienDetail frmPhuKienDetail = new frmPhuKienDetail(phieu_XuatCaiDatSanPham_CT.sDM_SanPham_Id.Value,
                    "Phieu_XuatCaiDatSanPham_CT_PhuKien", "phieuNhapCaiDatSanPham_CT_PhuKiens",
                    phieu_XuatCaiDatSanPham_CT, this, false, "KH_CaiDatSanPham_CT_PhuKien");
                frmPhuKienDetail.ShowDialog();
            }
            else
            {
                MMessage.ShowWarning("Bạn phải chọn sản phẩm trước khi nhập thông tin chi tiết phụ kiện");
            }
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
        private void cbosDM_CanBo_Id_NguoiDuyet_QueryPopUp(object sender, CancelEventArgs e)
        {
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                    columns: "Id,sTenCanBo", viewName: "View_DM_CanBo",
                    where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' AND iDictionaryKey IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong})", orderBy: "sTen");
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
                List<MT.Data.BO.Phieu_XuatCaiDatSanPham_CT> phieu_XuatCaiDatSanPham_CTs = mGridEditable.GrdDetail.GetAllData<MT.Data.BO.Phieu_XuatCaiDatSanPham_CT>();

                foreach (var item in dataChanged)
                {
                    var castItem = (MT.Data.BO.Phieu_XuatCaiDatSanPham_CT)item;
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
                    if (isValid && phieu_XuatCaiDatSanPham_CTs != null && phieu_XuatCaiDatSanPham_CTs.Count > 0)
                    {
                        //Kiểm tra mã vạch có bị trùng hay không
                        MT.Data.BO.Phieu_XuatCaiDatSanPham_CT findBysMaVach = phieu_XuatCaiDatSanPham_CTs.Find(m => m.sMaVach.Equals(castItem.sMaVach) && m.Id != castItem.Id);
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
                case "Phieu_XuatCaiDatSanPham_CT":
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
                case "Phieu_XuatCaiDatSanPham_CT":
                    Phieu_XuatCaiDatSanPham_CT phieu_XuatCaiDatSanPham_CT = mGridControl.GetRecordByRowSelected<Phieu_XuatCaiDatSanPham_CT>();
                    if (e.Column.FieldName == "rSoLuong" || e.Column.FieldName == "rDonGia")
                    {
                        phieu_XuatCaiDatSanPham_CT.rThanhTien = phieu_XuatCaiDatSanPham_CT.rSoLuong * phieu_XuatCaiDatSanPham_CT.rDonGia;
                    }
                    if (e.Column.FieldName == "sSerial")
                    {
                        object objsSerial = e.Value;
                        if (objsSerial != null)
                        {
                            string[] arrSerial = objsSerial.ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (arrSerial.Length >= 1)
                            {
                                phieu_XuatCaiDatSanPham_CT.rSoLuong = arrSerial.Length;
                            }
                        }
                    }
                    var now = SysDateTime.Instance.Now();
                    if (e.Column.FieldName == "iThoiGianBaoHanh" || e.Column.FieldName == "iDonViThoiGianBaoHanh")
                    {
                        DateTime? dHanBaoHanhDen = null;
                        switch (phieu_XuatCaiDatSanPham_CT.iDonViThoiGianBaoHanh)
                        {
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Ngay:
                                dHanBaoHanhDen = now.AddDays(phieu_XuatCaiDatSanPham_CT.iThoiGianBaoHanh).AddDays(1);
                                break;
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Thang:
                                dHanBaoHanhDen = now.AddMonths(phieu_XuatCaiDatSanPham_CT.iThoiGianBaoHanh).AddDays(1);
                                break;
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Quy:
                                dHanBaoHanhDen = now.AddYears(phieu_XuatCaiDatSanPham_CT.iThoiGianBaoHanh * 3).AddDays(1);
                                break;
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Nam:
                                dHanBaoHanhDen = now.AddYears(phieu_XuatCaiDatSanPham_CT.iThoiGianBaoHanh).AddDays(1);
                                break;
                        }
                        phieu_XuatCaiDatSanPham_CT.dHanBaoHanhDen = dHanBaoHanhDen;
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
                    cbosKH_CaiDatSanPham_Id_CanCu.SetReadOnly(false);
                    break;
                case (int)MTControl.FormAction.Edit:
                    cboEnumiLoaiTCXuat.SetReadOnly(true);
                    break;
                default:
                    cbosKH_CaiDatSanPham_Id_CanCu.SetReadOnly(true);
                    break;
            }

            //treesDM_DonVi_Id_Xuat.SetReadOnly(true);
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
                    ucThamChieuPhieu.sTenBangCanCu = "Phieu_XuatCaiDatSanPham";
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
            var currentData = (Phieu_XuatCaiDatSanPham)base.PrepareDataBeforeBindDataForm();

            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:
                    currentData.sKH_CaiDatSanPham_Id_CanCu = null;
                    currentData.dNgayPhieu_Xuat = SysDateTime.Instance.Now();
                    currentData.sDM_DonVi_Id_Xuat = MT.Library.SessionData.OrganizationUnitId;
                    currentData.sDM_CanBo_Id_NguoiGiao = MT.Library.SessionData.UserId;
                    currentData.sDM_CanBo_Id_NguoiLapPhieu = MT.Library.SessionData.UserId;
                    break;
            }
            return currentData;
        }

        private void cbossKH_CaiDat_Id_CanCu_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (cboEnumiLoaiTCXuat.SelectedIndex == 1)
            {
                cbosKH_CaiDatSanPham_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.Phieu_NhapCaiDatSanPhamRepository>().GetData(typeof(MT.Data.BO.Phieu_NhapCaiDatSanPham),
                    columns: "Id,sMa,dNgayPhieu_Nhap,sDM_DonVi_Id_Xuat_Ten, sDM_DonVi_Id_Nhap, sDM_DonVi_Id_Xuat",
                    where: $"iTrangThaiDuyet=1 AND iTrangThaiThucHien < {(int)MT.Data.iTrangThaiThucHienKHNM.DaHoanThanh} AND sDM_DonVi_Id_Nhap ='{MT.Library.SessionData.OrganizationUnitId}'",
                    orderBy: "sSo DESC", viewName: "View_Phieu_NhapCaiDatSanPham");

                linkFormVoucher.VoucherId = null;
                linkFormVoucher.ControlVoucher = cbosKH_CaiDatSanPham_Id_CanCu;
                linkFormVoucher.TableName = "Phieu_NhapCaiDatSanPham";
            }
            else
            {
                cbosKH_CaiDatSanPham_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.KH_CaiDatSanPhamRepository>().GetData(typeof(MT.Data.BO.KH_CaiDatSanPham),
                    columns: "Id,sMa,dNgayKeHoach,sDM_DonVi_Id_DonViXayDungKH_Ten,sDM_DonVi_Id_DonViXuat_Ten, sDM_DonVi_Id_DonViXuat, sDM_DonVi_Id_DonViNhap",
                    where: $"iTrangThaiDuyet=1 AND iTrangThaiThucHienKHCD < {(int)MT.Data.iTrangThaiThucHienKHNM.DaHoanThanh} AND sDM_DonVi_Id_DonViXuat ='{MT.Library.SessionData.OrganizationUnitId}'",
                    orderBy: "sSo DESC", viewName: "View_KH_CaiDatSanPham");

                linkFormVoucher.VoucherId = null;
                linkFormVoucher.ControlVoucher = cbosKH_CaiDatSanPham_Id_CanCu;
                linkFormVoucher.TableName = "KH_CaiDatSanPham";
            }

        }


        private void cbosKH_CaiDatSanPham_Id_CanCu_EditValueChanged(object sender, EventArgs e)
        {
            switch (this.FormAction)//cbosDM_KeHoachXuat
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:
                    //if (cboEnumiLoaiTCXuat.SelectedIndex == 0)
                    //Tạm thời force luôn vào case đầu tiên
                    if (cboEnumiLoaiTCXuat.SelectedIndex == 0)
                    {
                        MT.Data.BO.KH_CaiDatSanPham kH_CaiDatSanPham = cbosKH_CaiDatSanPham_Id_CanCu.GetRecordSelected<MT.Data.BO.KH_CaiDatSanPham>();
                        if (kH_CaiDatSanPham != null)
                        {
                            // Thiết lập giá trị mặc định cho đơn vị xuất
                            Guid maDVXuat = kH_CaiDatSanPham.sDM_DonVi_Id_DonViXuat;
                            treesDM_DonVi_Id_Xuat.SetValue(maDVXuat);

                            // Thiết lập giá trị mặc định cho đơn vị nhập
                            Guid maDVNhap = kH_CaiDatSanPham.sDM_DonVi_Id_DonViNhap;
                            treesDM_DonVi_Id_Nhap.SetValue(maDVNhap);
                            // Thiết lập lọc người nhận thuộc đơn vị nhận
                            // Nguoi nhan
                            object sDM_Donvi_Id_nhan = treesDM_DonVi_Id_Nhap.GetValue();
                            if (sDM_Donvi_Id_nhan != null)
                            {
                                cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                                   columns: "Id,sMaCanBo,sTenCanBo",
                                   where: $"sDM_DonVi_Id='{sDM_Donvi_Id_nhan.ToString()}' and iDictionaryKey NOT IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong},{(int)MT.Data.iChucVu.CucTruong},{(int)MT.Data.iChucVu.PhoCucTruong})",
                                   orderBy: "sMaCanBo",
                                   viewName: "View_DM_CanBo");
                            }
                        }

                    }
                    else
                    {
                        MT.Data.BO.Phieu_NhapCaiDatSanPham phieu_NhapCaiDatSanPham = cbosKH_CaiDatSanPham_Id_CanCu.GetRecordSelected<MT.Data.BO.Phieu_NhapCaiDatSanPham>();
                        if (phieu_NhapCaiDatSanPham != null)
                        {
                            // Thiết lập giá trị mặc định cho đơn vị xuất
                            Guid maDVXuat = phieu_NhapCaiDatSanPham.sDM_DonVi_Id_Xuat;
                            // Thiết lập giá trị mặc định cho đơn vị nhập
                            Guid maDVNhap = phieu_NhapCaiDatSanPham.sDM_DonVi_Id_Nhap;

                            treesDM_DonVi_Id_Nhap.SetValue(maDVXuat);
                            treesDM_DonVi_Id_Xuat.SetValue(maDVNhap);

                            // Nguoi nhan
                            object sDM_Donvi_Id_nhan = treesDM_DonVi_Id_Nhap.GetValue();

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


        private void cboEnumiLoaiTCXuat_EditValueChanged(object sender, EventArgs e)
        {
            if (this.CurrentData == null)
            {
                //return;
            }
            cbosKH_CaiDatSanPham_Id_CanCu.CleadAllColumn();
            if (cboEnumiLoaiTCXuat.SelectedIndex == 1) // Căn cứ phiếu nhập
            {
                //grdSanPham.GrdDetail.DisableFieldNames = @"sDM_SanPham_Id,sDM_SanPham_Id_Ten,rThanhTien,sDM_DonViTinh_Id,rSoLuong,dHanBaoHanhDen,sSerial";
                cbosKH_CaiDatSanPham_Id_CanCu.Properties.DisplayMember = "sMa";
                cbosKH_CaiDatSanPham_Id_CanCu.Properties.ValueMember = "Id";
                cbosKH_CaiDatSanPham_Id_CanCu.AddColumn("sMa", "Số phiếu nhập", 150);
                cbosKH_CaiDatSanPham_Id_CanCu.AddColumn("dNgayPhieu_Nhap", "Ngày nhập", 120);
                cbosKH_CaiDatSanPham_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.Phieu_NhapCaiDatSanPhamRepository>().GetData(typeof(MT.Data.BO.Phieu_NhapCaiDatSanPham),
                    columns: "Id,sMa,dNgayPhieu_Nhap,sDM_DonVi_Id_Xuat_Ten, sDM_DonVi_Id_Nhap, sDM_DonVi_Id_Xuat",
                    where: $"sDM_DonVi_Id_Nhap ='{MT.Library.SessionData.OrganizationUnitId}'",
                    orderBy: "sSo DESC", viewName: "View_Phieu_NhapCaiDatSanPham");
            }
            else // Căn cứ kế hoạch
            {
                //grdSanPham.GrdDetail.DisableFieldNames = @"sDM_SanPham_Id,sDM_ChungThuSo_Id,sDM_MangLienLac_Id,sDM_SanPham_Id_Ten,rThanhTien,sDM_DonViTinh_Id,rSoLuong,dHanBaoHanhDen,sSerial";
                cbosKH_CaiDatSanPham_Id_CanCu.Properties.DisplayMember = "sMa";
                cbosKH_CaiDatSanPham_Id_CanCu.Properties.ValueMember = "Id";
                cbosKH_CaiDatSanPham_Id_CanCu.AddColumn("sMa", "Số kế hoạch", 150);
                cbosKH_CaiDatSanPham_Id_CanCu.AddColumn("dNgayKeHoach", "Ngày lập", 120);
                //cbosKH_CaiDatSanPham_Id_CanCu.AddColumn("iThoiGianHieuLuc", "Thời gian hiệu lực", 120, true);
                cbosKH_CaiDatSanPham_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.KH_CaiDatSanPhamRepository>().GetData(typeof(MT.Data.BO.KH_CaiDatSanPham),
                    columns: "Id,sMa,dNgayKeHoach,sDM_DonVi_Id_DonViXayDungKH_Ten,sDM_DonVi_Id_DonViXuat_Ten, sDM_DonVi_Id_DonViXuat, sDM_DonVi_Id_DonViNhap",
                    where: $"iTrangThaiDuyet=1 AND iTrangThaiThucHienKHCD < {(int)MT.Data.iTrangThaiThucHienKHNM.DaHoanThanh} AND sDM_DonVi_Id_DonViXuat ='{MT.Library.SessionData.OrganizationUnitId}'",
                    orderBy: "sSo DESC", viewName: "View_KH_CaiDatSanPham");
            }
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
        private void linkFormVoucher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cboEnumiLoaiTCXuat.GetValue().Equals((int)iLoaiPhieu.XuatĐiCĐ))
            {
                linkFormVoucher.TableName = "KH_CaiDatSanPham";
            }
            else if (cboEnumiLoaiTCXuat.GetValue().Equals((int)iLoaiPhieu.XuatTraSauCĐ))
            {
                linkFormVoucher.TableName = "Phieu_NhapCaiDatSanPham";
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
            configReport.RepName = "Print_Phieu_XuatCaiDatSanPham_DetailRepository";
            //Định danh mẫu in trong bảng ReportData
            configReport.DictionaryKey = MT.Data.ReportDictionaryKey.RP_Print_Phieu_XuatCaiDatSanPhamDetail;

            //Danh sách các cột trên table
            configExcel.ShowColumnsOrder = new HashSet<string>
            {
                "sSTT","sDM_SanPham_Id_Ten",
                "sDM_DonViTinh_Id_Ten","rSoLuong",
                "sDM_NoiDungCaiDat_Id_Ten",
                "sXuatXu",
            };

        }



        #endregion

    }
}
