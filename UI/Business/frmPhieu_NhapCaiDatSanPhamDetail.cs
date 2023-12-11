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
    public partial class frmPhieu_NhapCaiDatSanPhamDetail : FormUI.MFormBusinessDetail
    {
        DM_DonViRepository dM_DonViRepository;
        public frmPhieu_NhapCaiDatSanPhamDetail()
        {
            InitializeComponent();
            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<Phieu_NhapCaiDatSanPhamRepository>(),
                    EntityName = "Phieu_NhapCaiDatSanPham",
                    Title = "Phiếu nhập cài đặt sản phẩm"
                };
            }
            GrdDetails = new Dictionary<string, MTControl.MGridEditable>
            {
                {"Phieu_NhapCaiDatSanPham_CT",grdSanPham }
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


            cbosPhieu_XuatSanPham_Id_CanCu.Properties.DisplayMember = "sMa";
            cbosPhieu_XuatSanPham_Id_CanCu.Properties.ValueMember = "Id";
            cbosPhieu_XuatSanPham_Id_CanCu.AddColumn("sMa", "Căn cứ số", 150);
            cbosPhieu_XuatSanPham_Id_CanCu.AddColumn("dNgayPhieu_Xuat", "Ngày lập", 150);
            cbosPhieu_XuatSanPham_Id_CanCu.AddColumn("sDM_DonVi_Id_Xuat_Ten", "Đơn vị xuất", 250);
            cbosPhieu_XuatSanPham_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.Phieu_XuatCaiDatSanPhamRepository>().GetData(typeof(MT.Data.BO.Phieu_XuatCaiDatSanPham),
                columns: "Id,sMa,dNgayPhieu_Xuat,sDM_DonVi_Id_Xuat_Ten,sDM_CanBo_Id_NguoiGiao_Ten,sDM_DonVi_Id_Nhap_Ten,sDM_CanBo_Id_NguoiNhap_Ten",
                where: "iTrangThaiDuyet=1",
                orderBy: "sSo DESC", viewName: "View_Phieu_XuatCaiDatSanPham");


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

            linkFormVoucher.ControlVoucher = cbosPhieu_XuatSanPham_Id_CanCu;
            linkFormVoucher.TableName = "Phieu_XuatCaiDatSanPham";
            cboEnumiLoaiTCXuat.EnumData = "iTCNhapCĐ";
        }

        /// <summary>
        /// Khởi tạo thông tin grid
        /// </summary>
        private void InitGrid()
        {
            var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham), "Id,sMaSanPham,sTenSanPham", orderBy: "SortOrder");

            var dm_DonViTinhs = DBContext.GetRep<MT.Data.Rep.DM_DonViTinhRepository>().GetData(typeof(MT.Data.BO.DM_DonViTinh), "Id,sTenDonViTinh", orderBy: "SortOrder");
            //Sản phẩm
            grdSanPham.GrdDetail.ViewName = "View_Phieu_NhapCaiDatSanPham_CT";
            grdSanPham.GrdDetail.KeyName = "Id";
            grdSanPham.GrdDetail.SetField = "phieuNhapCaiDatSanPham_CTs";
            grdSanPham.GrdDetail.FirstView.OptionsNavigation.EnterMoveNextColumn = true;
            grdSanPham.GrdDetail.DisableFieldNames = @"sDM_SanPham_Id_Ten,sDM_ChungThuSo_Id,sDM_MangLienLac_Id,dHanBaoHanhDen,sSerial";
            grdSanPham.GrdDetail.ValidEditValueChanging = grdSanPham_ValidEditValueChanging;
            grdSanPham.IsRequired = true;
            grdSanPham.InvalidText = "Danh sách sản phẩm không được bỏ trống";
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
            colsDM_SanPham_Id.DictionaryName = "DM_SanPham";

            col = grdSanPham.GrdDetail.AddColumnText("sDM_SanPham_Id_Ten", "Tên sản phẩm", 250, isRequired: true);

            col = grdSanPham.GrdDetail.AddColumnText("sDM_DonViTinh_Id", "Đơn vị tính", 120,
                dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);

            MRepositoryItemLookUpEdit colsDM_DonViTinh_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_DonViTinh_Id.AddColumn("sTenDonViTinh", "Tên đơn vị tính", 180);
            colsDM_DonViTinh_Id.DataSource = dm_DonViTinhs;
            colsDM_DonViTinh_Id.DisplayMember = "sTenDonViTinh";
            colsDM_DonViTinh_Id.ValueMember = "Id";
            colsDM_DonViTinh_Id.DictionaryName = "DM_DonViTinh";

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
                var now = SysDateTime.Instance.Now();
                string sMaVach = mTextEdit.EditValue.ToString();
                if (!MT.Library.Utility.ValidsMaVach(sMaVach))
                {
                    MMessage.ShowWarning("Mã vạch không hợp lệ");
                    return true;
                }

                List<MT.Data.BO.Phieu_NhapCaiDatSanPham_CT> phieu_NhapCaiDatSanPham_CTs = grdSanPham.GrdDetail.GetAllData<MT.Data.BO.Phieu_NhapCaiDatSanPham_CT>();
                Phieu_NhapCaiDatSanPham_CT phieu_NhapCaiDatSanPham_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_NhapCaiDatSanPham_CT>();
                // 1. Kiểm tra nếu mã vạch đã có trên danh sách rồi thì không cho xuất, cảnh báo trùng
                if (phieu_NhapCaiDatSanPham_CTs?.Count > 1)
                {
                    //Kiểm tra mã vạch có bị trùng hay không
                    MT.Data.BO.Phieu_NhapCaiDatSanPham_CT findBysMaVach = phieu_NhapCaiDatSanPham_CTs
                        .Find(m => m.sMaVach.Equals(sMaVach) && m.Id != phieu_NhapCaiDatSanPham_CT.Id);
                    if (findBysMaVach != null)
                    {
                        MMessage.ShowWarning($"Mã vạch <{sMaVach}> đã tồn tại trên danh sách");

                        return true;
                    }
                }


                string sMaSP = sMaVach.Substring(4, 4);
                string sSerial = sMaVach.Substring(8, 5) + "/";
                sSerial += sMaVach.Substring(13, 2);

                //Cập nhật thông tin chứng thư số
                var lkMaVachCTS = DBContext.GetRep2<LK_MaVach_CTSRepository>().GetLK_MaVach_CTSByMaVach(sMaVach);
                if (lkMaVachCTS != null)
                {
                    phieu_NhapCaiDatSanPham_CT.sDM_ChungThuSo_Id = lkMaVachCTS.sDM_ChungThuSo_Id;
                }

                //Cập nhật thông tin MLL
                var lkMaVachMLL = DBContext.GetRep2<LK_MaVach_MLLRepository>().GetLK_MaVach_MLLByMaVach(sMaVach);
                if (lkMaVachMLL != null)
                {
                    phieu_NhapCaiDatSanPham_CT.sDM_MangLienLac_Id = lkMaVachMLL.sDM_MangLienLac_Id;
                }

                Guid? sPhieu_XuatCaiDatSanPham_Id = null;
                if (cbosPhieu_XuatSanPham_Id_CanCu.EditValue != null)
                {
                    sPhieu_XuatCaiDatSanPham_Id = Guid.Parse(cbosPhieu_XuatSanPham_Id_CanCu.EditValue.ToString());
                }

                if (sPhieu_XuatCaiDatSanPham_Id.HasValue)
                {
                    //2. Kiểm tra phiếu xuất có theo đúng kế hoạch không
                    Phieu_XuatCaiDatSanPham_CT phieu_XuatCaiDatSanPhamCT = DBContext.GetRep2<Phieu_XuatCaiDatSanPham_CTRepository>()
                                                                        .GetPhieu_XuatCaiDatSanPham_CTByPhieuXuatIdAndsMaSP(sPhieu_XuatCaiDatSanPham_Id.Value, sMaSP);
                    if (phieu_XuatCaiDatSanPhamCT == null)
                    {
                        MMessage.ShowWarning($@"Phiếu xuất cài đặt <{cbosPhieu_XuatSanPham_Id_CanCu.Text}> không tồn tại sản phẩm <{sMaSP}>");
                        return true;
                    }

                    // 4. Kiểm tra sản phẩm đã nhập đủ so với kế hoạch chưa, nếu đủ rồi thì không cho nhập nữa
                    List<MT.Data.BO.Phieu_NhapCaiDatSanPham_CT> phieu_NhapCaiDatSanPham_CTs_others = DBContext.GetRep2<Phieu_NhapCaiDatSanPham_CTRepository>()
                        .GetAllPhieuNhapCT(MT.Library.SessionData.OrganizationUnitId, (int)cboEnumiLoaiTCXuat.GetValue(), phieu_XuatCaiDatSanPhamCT.Id);
                    decimal sl_others = phieu_NhapCaiDatSanPham_CTs_others
                        .Where(m => m.sDM_SanPham_Id.Equals(phieu_XuatCaiDatSanPhamCT.sDM_SanPham_Id) && m.Id != phieu_XuatCaiDatSanPhamCT.Id)
                        .Sum(m => m.rSoLuong);

                    decimal sl_current = phieu_NhapCaiDatSanPham_CTs_others
                        .Where(m => m.sDM_SanPham_Id.Equals(phieu_XuatCaiDatSanPhamCT.sDM_SanPham_Id) && m.Id != phieu_XuatCaiDatSanPhamCT.Id)
                        .Sum(m => m.rSoLuong);

                    if (sl_others + sl_current >= phieu_XuatCaiDatSanPhamCT.rSoLuong)
                    {
                        MMessage.ShowWarning($@"Sản phẩm <{phieu_XuatCaiDatSanPhamCT.sDM_SanPham_Id_Ten}> đã nhập đủ so với phiếu xuất");
                        return true;
                    }

                    //Lấy chi tiết phụ kiện theo PX CĐ
                    List<MT.Data.BO.Phieu_XuatCaiDatSanPham_CT_PhuKien> phieu_XuatCaiDatSanPham_CT_PhuKiens = DBContext.GetRep2<Phieu_XuatCaiDatSanPham_CT_PhuKienRepository>()
                                                                                                .GetPhieu_XuatCaiDatSanPham_CT_PhuKiensByKH_CaiDatSanPham_CT_Id(phieu_XuatCaiDatSanPhamCT.Id);
                    List<MT.Data.BO.Phieu_NhapCaiDatSanPham_CT_PhuKien> phieu_NhapCaiDatSanPham_CT_PhuKiens = new List<Phieu_NhapCaiDatSanPham_CT_PhuKien>();
                    if (phieu_XuatCaiDatSanPham_CT_PhuKiens != null)
                    {
                        foreach (var item in phieu_XuatCaiDatSanPham_CT_PhuKiens)
                        {
                            phieu_NhapCaiDatSanPham_CT_PhuKiens.Add(new Phieu_NhapCaiDatSanPham_CT_PhuKien
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

                    phieu_NhapCaiDatSanPham_CT.phieuNhapCaiDatSanPham_CT_PhuKiens = phieu_NhapCaiDatSanPham_CT_PhuKiens;

                    phieu_NhapCaiDatSanPham_CT.sPhieu_XuatCaiDatSanPham_Id = sPhieu_XuatCaiDatSanPham_Id;
                    phieu_NhapCaiDatSanPham_CT.sPhieu_XuatCaiDatSanPham_CT_Id = phieu_XuatCaiDatSanPhamCT.Id;

                    phieu_NhapCaiDatSanPham_CT.sDM_SanPham_Id = phieu_XuatCaiDatSanPhamCT.sDM_SanPham_Id;
                    phieu_NhapCaiDatSanPham_CT.sDM_DonViTinh_Id = phieu_XuatCaiDatSanPhamCT.sDM_DonViTinh_Id;
                    phieu_NhapCaiDatSanPham_CT.rDonGia = phieu_XuatCaiDatSanPhamCT.rDonGia;
                    phieu_NhapCaiDatSanPham_CT.rThanhTien = phieu_XuatCaiDatSanPhamCT.rDonGia;
                    phieu_NhapCaiDatSanPham_CT.sDM_SanPham_Id_Ten = phieu_XuatCaiDatSanPhamCT.sDM_SanPham_Id_Ten;
                    phieu_NhapCaiDatSanPham_CT.rSoLuong = 1;

                    //phieu_NhapCaiDatSanPham_CT.sDM_MangLienLac_Id = phieu_XuatCaiDatSanPhamCT.sDM_MangLienLac_Id;
                    //phieu_NhapCaiDatSanPham_CT.sDM_MangLienLac_Id_Ten = phieu_XuatCaiDatSanPhamCT.sDM_MangLienLac_Id_Ten;
                    phieu_NhapCaiDatSanPham_CT.sDM_NoiDungCaiDat_Id = phieu_XuatCaiDatSanPhamCT.sDM_NoiDungCaiDat_Id;
                    phieu_NhapCaiDatSanPham_CT.sDM_NoiDungCaiDat_Id_Ten = phieu_XuatCaiDatSanPhamCT.sDM_NoiDungCaiDat_Id_Ten;

                    phieu_NhapCaiDatSanPham_CT.sSTTSP = phieu_XuatCaiDatSanPhamCT.sSTTSP;
                    phieu_NhapCaiDatSanPham_CT.iThoiGianBaoHanh = phieu_XuatCaiDatSanPhamCT.iThoiGianBaoHanh;
                    phieu_NhapCaiDatSanPham_CT.iDonViThoiGianBaoHanh = phieu_XuatCaiDatSanPhamCT.iDonViThoiGianBaoHanh;
                    phieu_NhapCaiDatSanPham_CT.iNamSX = phieu_XuatCaiDatSanPhamCT.iNamSX;
                    phieu_NhapCaiDatSanPham_CT.dHanBaoHanhDen = phieu_XuatCaiDatSanPhamCT.dHanBaoHanhDen;

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
                        phieu_NhapCaiDatSanPham_CT.sDM_SanPham_Id = dM_SanPham.Id;
                        phieu_NhapCaiDatSanPham_CT.sDM_DonViTinh_Id = dM_SanPham.sDM_DonViTinh_Id_Cap1;
                        phieu_NhapCaiDatSanPham_CT.rDonGia = dM_SanPham.rDonGia_Cap1;
                        phieu_NhapCaiDatSanPham_CT.rThanhTien = dM_SanPham.rDonGia_Cap1;
                        phieu_NhapCaiDatSanPham_CT.sDM_SanPham_Id_Ten = dM_SanPham.sTenSanPham;
                        List<DM_PhuKien> dM_PhuKiens = ((DM_PhuKienRepository)DBContext.GetRep<MT.Data.Rep.DM_PhuKienRepository>()).GetPhuKiensBysDM_SanPham_Id(dM_SanPham.Id);
                        List<MT.Data.BO.Phieu_NhapCaiDatSanPham_CT_PhuKien> phieu_NhapCaiDatSanPham_CT_PhuKiens = new List<Phieu_NhapCaiDatSanPham_CT_PhuKien>();
                        foreach (var item in dM_PhuKiens)
                        {
                            phieu_NhapCaiDatSanPham_CT_PhuKiens.Add(new Phieu_NhapCaiDatSanPham_CT_PhuKien
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
                        phieu_NhapCaiDatSanPham_CT.phieuNhapCaiDatSanPham_CT_PhuKiens = phieu_NhapCaiDatSanPham_CT_PhuKiens;

                        phieu_NhapCaiDatSanPham_CT.sPhieu_XuatCaiDatSanPham_Id = null;
                        phieu_NhapCaiDatSanPham_CT.sPhieu_XuatCaiDatSanPham_CT_Id = null;

                        //phieu_NhapCaiDatSanPham_CT.sDM_MangLienLac_Id = null;
                        //phieu_NhapCaiDatSanPham_CT.sDM_MangLienLac_Id_Ten = null;
                        phieu_NhapCaiDatSanPham_CT.sDM_NoiDungCaiDat_Id = null;
                        phieu_NhapCaiDatSanPham_CT.sDM_NoiDungCaiDat_Id_Ten = null;

                        phieu_NhapCaiDatSanPham_CT.rSoLuong = 1;
                        phieu_NhapCaiDatSanPham_CT.iThoiGianBaoHanh = 60;
                        phieu_NhapCaiDatSanPham_CT.sSerial = string.Empty;
                        phieu_NhapCaiDatSanPham_CT.iThoiGianBaoHanh = 60;
                        phieu_NhapCaiDatSanPham_CT.iDonViThoiGianBaoHanh = (int)MT.Data.iDonViThoiGianHieuLuc.Ngay;
                        phieu_NhapCaiDatSanPham_CT.iNamSX =now.Year;
                        phieu_NhapCaiDatSanPham_CT.dHanBaoHanhDen =now.AddDays(60);

                    }
                }
                phieu_NhapCaiDatSanPham_CT.IsLoaded = true;
                phieu_NhapCaiDatSanPham_CT.sSerial = sSerial;

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
            if (gridColumn.FieldName == "sSerial" && e.NewValue != null && !object.Equals(e.OldValue, e.NewValue))
            {
                string[] arrSerial = e.NewValue.ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Phieu_NhapCaiDatSanPham_CT phieu_NhapSanPham = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_NhapCaiDatSanPham_CT>();
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
            var phieu_NhapCaiDatSanPham_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_NhapCaiDatSanPham_CT>();
            if (phieu_NhapCaiDatSanPham_CT.sDM_SanPham_Id.HasValue && !phieu_NhapCaiDatSanPham_CT.sDM_SanPham_Id.Value.Equals(Guid.Empty))
            {
                frmPhuKienDetail frmPhuKienDetail = new frmPhuKienDetail(phieu_NhapCaiDatSanPham_CT.sDM_SanPham_Id.Value,
                    "Phieu_NhapCaiDatSanPham_CT_PhuKien", "phieuNhapCaiDatSanPham_CT_PhuKiens",
                    phieu_NhapCaiDatSanPham_CT, this, false, "Phieu_XuatCaiDatSanPham_CT_PhuKien");
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
                List<MT.Data.BO.Phieu_NhapCaiDatSanPham_CT> phieu_NhapCaiDatSanPham_CTs = mGridEditable.GrdDetail.GetAllData<MT.Data.BO.Phieu_NhapCaiDatSanPham_CT>();

                foreach (var item in dataChanged)
                {
                    var castItem = (MT.Data.BO.Phieu_NhapCaiDatSanPham_CT)item;
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
                    if (isValid && phieu_NhapCaiDatSanPham_CTs != null && phieu_NhapCaiDatSanPham_CTs.Count > 0)
                    {
                        //Kiểm tra mã vạch có bị trùng hay không
                        MT.Data.BO.Phieu_NhapCaiDatSanPham_CT findBysMaVach = phieu_NhapCaiDatSanPham_CTs.Find(m => m.sMaVach.Equals(castItem.sMaVach) && m.Id != castItem.Id);
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
                case "Phieu_NhapCaiDatSanPham_CT":
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
                case "Phieu_NhapCaiDatSanPham_CT":
                    Phieu_NhapCaiDatSanPham_CT phieu_NhapCaiDatSanPham_CT = mGridControl.GetRecordByRowSelected<Phieu_NhapCaiDatSanPham_CT>();
                    if (e.Column.FieldName == "rSoLuong" || e.Column.FieldName == "rDonGia")
                    {
                        phieu_NhapCaiDatSanPham_CT.rThanhTien = phieu_NhapCaiDatSanPham_CT.rSoLuong * phieu_NhapCaiDatSanPham_CT.rDonGia;
                    }
                    if (e.Column.FieldName == "sSerial")
                    {
                        object objsSerial = e.Value;
                        if (objsSerial != null)
                        {
                            string[] arrSerial = objsSerial.ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (arrSerial.Length >= 1)
                            {
                                phieu_NhapCaiDatSanPham_CT.rSoLuong = arrSerial.Length;
                            }
                        }
                    }

                    var now = SysDateTime.Instance.Now();
                    if (e.Column.FieldName == "iThoiGianBaoHanh" || e.Column.FieldName == "iDonViThoiGianBaoHanh")
                    {
                        DateTime? dHanBaoHanhDen = null;
                        switch (phieu_NhapCaiDatSanPham_CT.iDonViThoiGianBaoHanh)
                        {
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Ngay:
                                dHanBaoHanhDen = now.AddDays(phieu_NhapCaiDatSanPham_CT.iThoiGianBaoHanh).AddDays(1);
                                break;
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Thang:
                                dHanBaoHanhDen = now.AddMonths(phieu_NhapCaiDatSanPham_CT.iThoiGianBaoHanh).AddDays(1);
                                break;
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Quy:
                                dHanBaoHanhDen =now.AddYears(phieu_NhapCaiDatSanPham_CT.iThoiGianBaoHanh * 3).AddDays(1);
                                break;
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Nam:
                                dHanBaoHanhDen =now.AddYears(phieu_NhapCaiDatSanPham_CT.iThoiGianBaoHanh).AddDays(1);
                                break;
                        }
                        phieu_NhapCaiDatSanPham_CT.dHanBaoHanhDen = dHanBaoHanhDen;
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
                    cbosPhieu_XuatSanPham_Id_CanCu.SetReadOnly(false);
                    break;
                default:
                    cbosPhieu_XuatSanPham_Id_CanCu.SetReadOnly(true);
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
                    ucThamChieuPhieu.sTenBangCanCu = "Phieu_NhapCaiDatSanPham";
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
            var currentData = (Phieu_NhapCaiDatSanPham)base.PrepareDataBeforeBindDataForm();

            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:
                    currentData.sPhieu_XuatSanPham_Id_CanCu = null;
                    currentData.dNgayPhieu_Nhap = SysDateTime.Instance.Now();
                    currentData.sDM_DonVi_Id_Nhap = MT.Library.SessionData.OrganizationUnitId;
                    currentData.sDM_CanBo_Id_NguoiNhap = MT.Library.SessionData.UserId;
                    currentData.sDM_CanBo_Id_NguoiLapPhieu = MT.Library.SessionData.UserId;
                    currentData.iNhapVeKho = true;
                    break;
            }
            return currentData;
        }

        private void cbosPhieu_XuatCaiDatSanPham_CanCu_QueryPopUp(object sender, CancelEventArgs e)
        {
            int iLoai = -1;
            if (cboEnumiLoaiTCXuat.GetValue().Equals((int)iLoaiPhieu.NhapVaoCĐ))
            {
                iLoai = (int)iLoaiPhieu.XuatĐiCĐ;
            }
            else if (cboEnumiLoaiTCXuat.GetValue().Equals((int)iLoaiPhieu.NhapNhanVeSauCĐ))
            {
                iLoai = (int)iLoaiPhieu.XuatTraSauCĐ;
            }
            cbosPhieu_XuatSanPham_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.Phieu_XuatCaiDatSanPhamRepository>().GetData(typeof(MT.Data.BO.Phieu_XuatCaiDatSanPham),
                 columns: "Id,sMa,dNgayPhieu_Xuat,sDM_DonVi_Id_Xuat_Ten, sDM_DonVi_Id_Xuat, sDM_DonVi_Id_Nhap,sDM_CanBo_Id_NguoiGiao, sDM_CanBo_Id_NguoiNhap",
                 where: $"(iLoai={iLoai} OR {iLoai}<=-1) AND iTrangThaiThucHien < {(int)MT.Data.iTrangThaiThucHienKHNM.DaHoanThanh} AND iTrangThaiDuyet=1 AND sDM_DonVi_Id_Nhap ='{MT.Library.SessionData.OrganizationUnitId}'",
                 orderBy: "sSo DESC",
                 viewName: "View_Phieu_XuatCaiDatSanPham");
        }


        private void cbosPhieu_XuatCaiDatSanPham_CanCu_EditValueChanged(object sender, EventArgs e)
        {
            switch (this.FormAction)//cbosDM_KeHoachXuat
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:
                    MT.Data.BO.Phieu_XuatCaiDatSanPham pH_XuatCaiDatSanPham = cbosPhieu_XuatSanPham_Id_CanCu.GetRecordSelected<MT.Data.BO.Phieu_XuatCaiDatSanPham>();
                    if (pH_XuatCaiDatSanPham != null)
                    {
                        // Thiết lập giá trị mặc định cho đơn vị xuất
                        Guid maDVXuat = pH_XuatCaiDatSanPham.sDM_DonVi_Id_Xuat;
                        treesDM_DonVi_Id_Xuat.SetValue(maDVXuat);

                        // Thiết lập giá trị mặc định cho đơn vị nhập
                        Guid maDVNhap = pH_XuatCaiDatSanPham.sDM_DonVi_Id_Nhap;
                        treesDM_DonVi_Id_Nhap.SetValue(maDVNhap);
                        // Thiết lập lọc người nhận thuộc đơn vị nhận

                        // Nguoi giao

                        object sDM_Donvi_Id_giao = treesDM_DonVi_Id_Xuat.GetValue();
                        cbosDM_CanBo_Id_NguoiGiao.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                           columns: "Id,sMaCanBo,sTenCanBo",
                           where: $"sDM_DonVi_Id='{sDM_Donvi_Id_giao.ToString()}' and iDictionaryKey NOT IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong},{(int)MT.Data.iChucVu.CucTruong},{(int)MT.Data.iChucVu.PhoCucTruong})",
                           orderBy: "sMaCanBo",
                           viewName: "View_DM_CanBo");
                        cbosDM_CanBo_Id_NguoiGiao.SetValue(pH_XuatCaiDatSanPham.sDM_CanBo_Id_NguoiGiao);

                        // Nguoi nhập
                        cbosDM_CanBo_Id_NguoiNhap.SetValue(pH_XuatCaiDatSanPham.sDM_CanBo_Id_NguoiNhap);

                        //var datas = DBContext.GetRep2<Phieu_NhapCaiDatSanPham_CTRepository>().GetPhieu_XuatMuonTra_CTsByMasterId(pH_XuatMuonTra.Id);
                        //grdSanPham.GrdDetail.LoadData(datas);
                    }
                    //if (cboEnumiLoaiTCXuat.SelectedIndex == 0)
                    //Tạm thời force luôn vào case đầu tiên
                    //if (true)
                    //{
                    //    MT.Data.BO.Phieu_XuatCaiDatSanPham phieu_XuatCaiDatSan = cbosPhieu_XuatSanPham_Id_CanCu.GetRecordSelected<MT.Data.BO.Phieu_XuatCaiDatSanPham>();
                    //    if (phieu_XuatCaiDatSan != null)
                    //    {
                    //        // Thiết lập giá trị mặc định cho đơn vị xuất
                    //        cbosDM_DonVi_Id_Xuat.SetValue(phieu_XuatCaiDatSan.sDM_DonVi_Id_Xuat);

                    //        // Thiết lập giá trị mặc định cho đơn vị nhập
                    //        cbosDM_DonVi_Id_Nhap.SetValue(phieu_XuatCaiDatSan.sDM_DonVi_Id_Nhap);
                    //        // Thiết lập lọc người nhận thuộc đơn vị nhận
                    //        // Nguoi nhan
                    //        object sDM_Donvi_Id_nhan = cbosDM_DonVi_Id_Nhap.GetValue();
                    //        if (sDM_Donvi_Id_nhan != null)
                    //        {
                    //            cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                    //               columns: "Id,sMaCanBo,sTenCanBo",
                    //               where: $"sDM_DonVi_Id='{sDM_Donvi_Id_nhan.ToString()}' and iDictionaryKey NOT IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong},{(int)MT.Data.iChucVu.CucTruong},{(int)MT.Data.iChucVu.PhoCucTruong})",
                    //               orderBy: "sMaCanBo",
                    //               viewName: "View_DM_CanBo");
                    //        }
                    //    }

                    //}
                    //else
                    //{
                    //    MT.Data.BO.Phieu_NhapCaiDatSanPham phieu_NhapCaiDat = cbosPhieu_XuatSanPham_Id_CanCu.GetRecordSelected<MT.Data.BO.Phieu_NhapCaiDatSanPham>();
                    //    if (phieu_NhapCaiDat != null)
                    //    {
                    //        // Thiết lập giá trị mặc định cho đơn vị xuất
                    //        // Thiết lập giá trị mặc định cho đơn vị nhập
                    //        cbosDM_DonVi_Id_Nhap.SetValue(phieu_NhapCaiDat.sDM_DonVi_Id_Xuat);
                    //        cbosDM_DonVi_Id_Xuat.SetValue(phieu_NhapCaiDat.sDM_DonVi_Id_Nhap);

                    //        // Nguoi nhan
                    //        object sDM_Donvi_Id_nhan = cbosDM_DonVi_Id_Nhap.GetValue();

                    //        cbosDM_CanBo_Id_NguoiNhap.Properties.DisplayMember = "sTenCanBo";
                    //        cbosDM_CanBo_Id_NguoiNhap.Properties.ValueMember = "Id";
                    //        cbosDM_CanBo_Id_NguoiNhap.AddColumn("sTenCanBo", "Tên", 180, true);
                    //        if (sDM_Donvi_Id_nhan == null)
                    //        {
                    //            cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                    //            columns: "Id,sMaCanBo,sTenCanBo", orderBy: "sMaCanBo");
                    //        }
                    //        else
                    //        {
                    //            cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                    //           columns: "Id,sMaCanBo,sTenCanBo",
                    //           where: $"sDM_DonVi_Id='{sDM_Donvi_Id_nhan.ToString()}' and iDictionaryKey NOT IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong},{(int)MT.Data.iChucVu.CucTruong},{(int)MT.Data.iChucVu.PhoCucTruong})",
                    //           orderBy: "sMaCanBo",
                    //           viewName: "View_DM_CanBo");
                    //        }
                    //    }

                    //}
                    break;
            }
        }


        private void cboEnumiLoaiTCXuat_EditValueChanged(object sender, EventArgs e)
        {
            /*if (cboEnumiLoaiTCXuat.SelectedIndex == 1)
            {
                cbosKH_CaiDatSanPham_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.Phieu_NhapCaiDatSanPhamRepository>().GetData(typeof(MT.Data.BO.Phieu_NhapCaiDatSanPham),
                columns: "Id,sMa,dNgayPhieu_Nhap,sDM_DonVi_Id_Xuat_Ten, sDM_DonVi_Id_Nhap, sDM_DonVi_Id_Xuat",
                where: $"sDM_DonVi_Id_Nhap ='{MT.Library.SessionData.OrganizationUnitId}'",
                orderBy: "sSo DESC", viewName: "View_Phieu_NhapCaiDatSanPham");

                linkFormVoucher.ControlVoucher = cbosKH_CaiDatSanPham_Id_CanCu;
                linkFormVoucher.TableName = "Phieu_NhapCaiDatSanPham";
            }
            else
            {
                cbosKH_CaiDatSanPham_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.KH_CaiDatSanPhamRepository>().GetData(typeof(MT.Data.BO.KH_CaiDatSanPham),
                columns: "Id,sMa,dNgayKeHoach,sDM_DonVi_Id_DonViXayDungKH_Ten,iThoiGianHieuLuc,sDM_DonVi_Id_DonViNhap,sDM_DonVi_Id_DonViXuat",
                where: $"iTrangThaiDuyet=1 AND iTrangThaiThucHienKHCD < {(int)MT.Data.iTrangThaiThucHienKHNM.DaHoanThanh} AND sDM_DonVi_Id_DonViXuat='{MT.Library.SessionData.OrganizationUnitId}'",
                orderBy: "sSo DESC", viewName: "View_KH_CaiDatSanPham");
                linkFormVoucher.ControlVoucher = cbosKH_CaiDatSanPham_Id_CanCu;
                linkFormVoucher.TableName = "Phieu_XuatCaiDatSanPham";
            }*/
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
            configReport.RepName = "Print_Phieu_NhapCaiDatSanPham_DetailRepository";
            //Định danh mẫu in trong bảng ReportData
            configReport.DictionaryKey = MT.Data.ReportDictionaryKey.RP_Print_Phieu_NhapCaiDatSanPhamDetail;

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
