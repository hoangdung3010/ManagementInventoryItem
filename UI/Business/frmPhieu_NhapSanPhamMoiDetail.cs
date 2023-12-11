using DevExpress.DataProcessing;
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
    public partial class frmPhieu_NhapSanPhamMoiDetail : FormUI.MFormBusinessDetail
    {
        private DM_DonViRepository dM_DonViRepository;

        public frmPhieu_NhapSanPhamMoiDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<Phieu_NhapSanPhamMoiRepository>(),
                    EntityName = "Phieu_NhapSanPhamMoi",
                    Title = "Phiếu nhập sản phẩm mới"
                };
            }

            GrdDetails = new Dictionary<string, MTControl.MGridEditable>
            {
                {"Phieu_NhapSanPhamMoi_CT",grdSanPham }
            };

            ControlTepDinhKem = ucTepDinhKemDetail;

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
            cbosDM_DonVi_Id_Nhap.Properties.DisplayMember = "sTenDonvi";
            cbosDM_DonVi_Id_Nhap.Properties.ValueMember = "Id";
            var treeList = cbosDM_DonVi_Id_Nhap.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            cbosDM_DonVi_Id_Nhap.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            cbosDM_DonVi_Id_Nhap.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);

            var donviXayDungKH = dM_DonViRepository.GetDonViConCap1VaDonViCungCap(MT.Library.SessionData.OrganizationUnitId);

            cbosDM_DonVi_Id_Nhap.Properties.DataSource = donviXayDungKH;
            cbosDM_DonVi_Id_Nhap.AliasFormQuickAdd = "DM_DonVi";

            cbossKH_NhapSanPhamMoi_Id_CanCu.Properties.DisplayMember = "sMa";
            cbossKH_NhapSanPhamMoi_Id_CanCu.Properties.ValueMember = "Id";
            cbossKH_NhapSanPhamMoi_Id_CanCu.AddColumn("sMa", "Số kế hoạch", 120);
            cbossKH_NhapSanPhamMoi_Id_CanCu.AddColumn("dNgayLap", "Ngày lập", 80);
            cbossKH_NhapSanPhamMoi_Id_CanCu.AddColumn("sDM_DonVi_Id_DonViXayDungKH_Ten", "Đơn vị lập", 120);
            cbossKH_NhapSanPhamMoi_Id_CanCu.AddColumn("sSoHopDong", "Số hợp đồng", 100);
            cbossKH_NhapSanPhamMoi_Id_CanCu.AddColumn("dNgayHopDong", "Ngày hợp đồng", 100);
            cbossKH_NhapSanPhamMoi_Id_CanCu.AddColumn("iThoiGianHieuLuc", "Thời gian hiệu lực", 120, true);
            cbossKH_NhapSanPhamMoi_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.KH_NhapSanPhamMoiRepository>().GetData(typeof(MT.Data.BO.KH_NhapSanPhamMoi),
                columns: "Id,sMa,dNgayLap,sDM_DonVi_Id_DonViXayDungKH_Ten,sSoHopDong,dNgayHopDong,iThoiGianHieuLuc,sDM_NhaCC_Id",
                where: "iTrangThaiDuyet=1",
                orderBy: "sSo DESC", viewName: "View_KH_NhapSanPhamMoi");

            var dm_CanBos= DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id,sTenCanBo", orderBy: "sTen");

            cbosDM_CanBo_Id_NguoiNhap.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiNhap.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiNhap.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource = dm_CanBos;

            cbosDM_CanBo_Id_NguoiLapPhieu.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiLapPhieu.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiLapPhieu.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiLapPhieu.Properties.DataSource = dm_CanBos;

            cbosDM_CanBo_Id_NguoiDuyet.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiDuyet.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiDuyet.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = dm_CanBos;
            cbosDM_NhaCC_Id.Properties.DisplayMember = "sTenNCC";
            cbosDM_NhaCC_Id.Properties.ValueMember = "Id";
            cbosDM_NhaCC_Id.AddColumn("sMaNCC", "Mã nhà cung cấp", 150);
            cbosDM_NhaCC_Id.AddColumn("sTenNCC", "Tên nhà cung cấp", 180, true);
            cbosDM_NhaCC_Id.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_NhaCCRepository>().GetData(typeof(MT.Data.BO.DM_NhaCC),
                columns: "Id,sMaNCC,sTenNCC", orderBy: "sMaNCC,sTenNCC");
            cbosDM_NhaCC_Id.AliasFormQuickAdd = "DM_NhaCC";

            linkFormVoucher.ControlVoucher = cbossKH_NhapSanPhamMoi_Id_CanCu;
            linkFormVoucher.TableName = "KH_NhapSanPhamMoi";
        }

        /// <summary>
        /// Khởi tạo thông tin grid
        /// </summary>
        private void InitGrid()
        {
            var dm_DonViTinhs = DBContext.GetRep<MT.Data.Rep.DM_DonViTinhRepository>().GetData(typeof(MT.Data.BO.DM_DonViTinh), "Id,sTenDonViTinh", orderBy: "SortOrder");
            //Sản phẩm
            grdSanPham.GrdDetail.ViewName = "View_Phieu_NhapSanPhamMoi_CT";
            grdSanPham.GrdDetail.KeyName = "Id";
            grdSanPham.GrdDetail.SetField = "phieu_NhapSanPhamMoi_CT";
            grdSanPham.GrdDetail.FirstView.OptionsNavigation.EnterMoveNextColumn = true;
            grdSanPham.GrdDetail.DisableFieldNames = @"sDM_SanPham_Id_Ten,rThanhTien,sDM_DonViTinh_Id,rSoLuong,dHanBaoHanhDen,sSerial";
            grdSanPham.GrdDetail.ValidEditValueChanging = grdSanPham_ValidEditValueChanging;
            grdSanPham.IsRequired = true;
            grdSanPham.InvalidText = "Danh sách sản phẩm không được bỏ trống";
            grdSanPham.GrdDetail.FuncCustomRecordBeforeAddRow = GridSanPham_FuncCustomRecordBeforeAddRow;
            var col = grdSanPham.GrdDetail.AddColumnText("sMaVach", "Mã vạch", 150, maxLength: 50,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left, isRequired: true);

            MRepositoryTextEdit colsMaVach = (MRepositoryTextEdit)col.ColumnEdit;
            colsMaVach.CustomEventEnter = grdSanPham_ColsMaVach_CustomEventEnter;

            col = grdSanPham.GrdDetail.AddColumnText("sDM_SanPham_Id_Ten", "Tên sản phẩm", 250, isRequired: true);

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

            grdSanPham.GrdDetail.AddColumnText("sSerial", "Số Serial", 150);
            grdSanPham.GrdDetail.AddColumnText("sSTTSP", "STT Sản phẩm", 120,
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

            col = grdSanPham.GrdDetail.AddColumnText("sKH_NhapSanPhamMoi_CT_Id", "sKH_NhapSanPhamMoi_CT_Id", 0);
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
            //0002(Mã NCC) 0004(Mã SP) 00007(series) 21(Năm)
            try
            {
                if (mTextEdit.EditValue != null)
                {
                    string sMaVach = mTextEdit.EditValue.ToString();
                    if (!MT.Library.Utility.ValidsMaVach(sMaVach))
                    {
                        MMessage.ShowWarning("Mã vạch không hợp lệ");
                        return false;
                    }

                    List<MT.Data.BO.Phieu_NhapSanPhamMoi_CT> phieu_NhapSanPhamMoi_CTs = grdSanPham.GrdDetail.GetAllData<MT.Data.BO.Phieu_NhapSanPhamMoi_CT>();
                    Phieu_NhapSanPhamMoi_CT phieu_NhapSanPhamMoi_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_NhapSanPhamMoi_CT>();
                    //Kiểm tra nếu mã vạch đã có trên danh sách rồi thì không cho nhập, cảnh báo trùng
                    if (phieu_NhapSanPhamMoi_CTs.Count > 1)
                    {
                        //Kiểm tra mã vạch có bị trùng hay không
                        MT.Data.BO.Phieu_NhapSanPhamMoi_CT findBysMaVach = phieu_NhapSanPhamMoi_CTs.Find(m => m.sMaVach!=null && m.sMaVach.Equals(sMaVach) && m.Id != phieu_NhapSanPhamMoi_CT.Id);
                        if (findBysMaVach != null)
                        {
                            MMessage.ShowWarning($"Mã vạch <{sMaVach}> đã tồn tại trên danh sách");

                            return false;
                        }
                    }

                    //Kiểm tra mã vạch đã tồn tại trong hệ thống chưa
                    string sMaPhieu = DBContext.GetRep2<Phieu_NhapSanPhamMoi_CTRepository>().GetMaPhieuNhapMoi(sMaVach, this.FormId);
                    if (!string.IsNullOrWhiteSpace(sMaPhieu))
                    {
                        MMessage.ShowWarning($"Mã vạch <{sMaVach}> đã tồn tại trên phiếu nhập mới <{sMaPhieu}>");
                        return false;
                    }
                    var convertMaVachToObject = CommonFnUI.ConvertsMaVachToObject(sMaVach);
                    string sMaNCC = convertMaVachToObject.sNhaCungCap;
                    string sMaSP = convertMaVachToObject.sMaSanPham;
                    string sSerial = convertMaVachToObject.sSoSeries + "/";
                    sSerial += convertMaVachToObject.sNam;
                    int iNamSX = int.Parse($"20{convertMaVachToObject.sNam}");

                    //Kiểm mã vạch nhập mới phải thuộc nhà cung cấp trên phiếu
                    if (cbosDM_NhaCC_Id.EditValue == null)
                    {
                        ActiveControl = cbosDM_NhaCC_Id;
                        MMessage.ShowWarning("Bạn không được bỏ trống thông tin nhà cung cấp.");
                        return false;
                    }

                  
                    Guid.TryParse(Convert.ToString(cbossKH_NhapSanPhamMoi_Id_CanCu.EditValue), out var sKH_NhapSanPhamMoi_Id);

                    KH_NhapSanPhamMoi_CT kH_NhapSanPhamMoi_CT = new KH_NhapSanPhamMoi_CT();
                    if (sKH_NhapSanPhamMoi_Id != Guid.Empty)
                    {
                        kH_NhapSanPhamMoi_CT = DBContext.GetRep2<KH_NhapSanPhamMoi_CTRepository>()
                                                                        .GetKH_NhapSanPhamMoi_CTsBysKH_NhapSanPhamMoi_IdAndsMaSP(sKH_NhapSanPhamMoi_Id, sMaSP);

                        if (kH_NhapSanPhamMoi_CT == null)
                        {
                            MMessage.ShowWarning($@"Kế hoạch nhập mới <{cbossKH_NhapSanPhamMoi_Id_CanCu.Text}> không tồn tại sản phẩm <{sMaSP}>");
                            return false;
                        }

                    }
                    else
                    {
                        //lấy thông tin sản phẩm trong danh mục
                        var dm_SP=  DBContext.GetRep2<DM_SanPhamRepository>().GetByMaSP(sMaSP);
                        if (dm_SP != null)
                        {
                            kH_NhapSanPhamMoi_CT.sDM_DonViTinh_Id = dm_SP.sDM_DonViTinh_Id_Cap1;
                            kH_NhapSanPhamMoi_CT.sDM_SanPham_Id = dm_SP.Id;
                            kH_NhapSanPhamMoi_CT.sDM_SanPham_Id_Ten = dm_SP.sTenSanPham;
                            kH_NhapSanPhamMoi_CT.rDonGia = dm_SP.rDonGia_Cap1;
                            kH_NhapSanPhamMoi_CT.rThanhTien = dm_SP.rDonGia_Cap1;
                            kH_NhapSanPhamMoi_CT.rSoLuong = 1;
                        }

                    }

                    //Kiểm tra sản phẩm đã nhập đủ so với kế hoạch chưa, nếu đủ roh thì không cho nhập nữa
                    if (kH_NhapSanPhamMoi_CT!=null && kH_NhapSanPhamMoi_CT.Id!=Guid.Empty &&
                         phieu_NhapSanPhamMoi_CTs
                        .Where(m => m.sDM_SanPham_Id.Equals(kH_NhapSanPhamMoi_CT.sDM_SanPham_Id) && m.Id != phieu_NhapSanPhamMoi_CT.Id)
                        .Sum(m => m.rSoLuong) >= kH_NhapSanPhamMoi_CT.rSoLuong)
                    {
                        MMessage.ShowWarning($@"Sản phẩm <{kH_NhapSanPhamMoi_CT.sDM_SanPham_Id_Ten}> đã nhập đủ so với kế hoạch");
                        return false;
                    }

                    //Lấy chi tiết phụ kiện theo kế hoạch
                    List<MT.Data.BO.KH_NhapSanPhamMoi_CT_PhuKien> kH_NhapSanPhamMoi_CT_PhuKiens = DBContext.GetRep2<KH_NhapSanPhamMoi_CT_PhuKienRepository>()
                                                                                                .GetKH_NhapSanPhamMoi_CT_PhuKiensBysKH_NhapSanPhamMoi_CT_Id(kH_NhapSanPhamMoi_CT.Id);
                    List<MT.Data.BO.Phieu_NhapSanPhamMoi_CT_PhuKien> phieu_NhapSanPhamMoi_CT_PhuKiens = new List<Phieu_NhapSanPhamMoi_CT_PhuKien>();
                    if (kH_NhapSanPhamMoi_CT_PhuKiens != null)
                    {
                        foreach (var item in kH_NhapSanPhamMoi_CT_PhuKiens)
                        {
                            phieu_NhapSanPhamMoi_CT_PhuKiens.Add(new Phieu_NhapSanPhamMoi_CT_PhuKien
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
                    phieu_NhapSanPhamMoi_CT.IsLoaded = true;
                    phieu_NhapSanPhamMoi_CT.sSerial = sSerial;
                    phieu_NhapSanPhamMoi_CT.sSTTSP = string.Empty;
                    phieu_NhapSanPhamMoi_CT.phieu_NhapSanPhamMoi_CT_PhuKiens = phieu_NhapSanPhamMoi_CT_PhuKiens;

                    phieu_NhapSanPhamMoi_CT.sKH_NhapSanPhamMoi_CT_Id = kH_NhapSanPhamMoi_CT.Id;
                    phieu_NhapSanPhamMoi_CT.sKH_NhapSanPhamMoi_Id = sKH_NhapSanPhamMoi_Id;
                    phieu_NhapSanPhamMoi_CT.rSoLuong = 1;
                    phieu_NhapSanPhamMoi_CT.sDM_SanPham_Id = kH_NhapSanPhamMoi_CT.sDM_SanPham_Id;
                    phieu_NhapSanPhamMoi_CT.sDM_DonViTinh_Id = kH_NhapSanPhamMoi_CT.sDM_DonViTinh_Id;
                    phieu_NhapSanPhamMoi_CT.rDonGia = kH_NhapSanPhamMoi_CT.rDonGia;
                    phieu_NhapSanPhamMoi_CT.rThanhTien = kH_NhapSanPhamMoi_CT.rDonGia;
                    phieu_NhapSanPhamMoi_CT.iThoiGianBaoHanh = 60;
                    phieu_NhapSanPhamMoi_CT.sDM_SanPham_Id_Ten = kH_NhapSanPhamMoi_CT.sDM_SanPham_Id_Ten;                  
                    phieu_NhapSanPhamMoi_CT.iDonViThoiGianBaoHanh = (int)MT.Data.iDonViThoiGianHieuLuc.Ngay;
                    phieu_NhapSanPhamMoi_CT.iNamSX = iNamSX;
                    phieu_NhapSanPhamMoi_CT.dHanBaoHanhDen = SysDateTime.Instance.Now().AddDays(60);

                    //Từ động thêm dòng tiếp theo
                    grdSanPham.GrdDetail.AddRow(false);
                }
            }
            catch (Exception ex)
            {
                CommonFnUI.HandleException(ex);
                return false;
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
            if (cbossKH_NhapSanPhamMoi_Id_CanCu.EditValue == null)
            {
                ActiveControl = cbossKH_NhapSanPhamMoi_Id_CanCu;
                MMessage.ShowWarning("Bạn phải xác định phiếu nhập căn cứ theo kế hoạch nào.");
                return false;
            }

            if (cbosDM_NhaCC_Id.EditValue == null)
            {
                ActiveControl = cbosDM_NhaCC_Id;
                MMessage.ShowWarning("Bạn không được bỏ trống thông tin nhà cung cấp.");
                return false;
            }
            if (gridColumn.FieldName == "sSTTSP" && e.NewValue != null && !object.Equals(e.OldValue, e.NewValue))
            {
                string[] arrSerial = e.NewValue.ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Phieu_NhapSanPhamMoi_CT phieu_NhapSanPham = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_NhapSanPhamMoi_CT>();
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
            Phieu_NhapSanPhamMoi_CT phieu_NhapSanPhamMoi_CT = (Phieu_NhapSanPhamMoi_CT)newRecord;
            if (phieu_NhapSanPhamMoi_CT.sDM_SanPham_Id.HasValue
                && !phieu_NhapSanPhamMoi_CT.sDM_SanPham_Id.Value.Equals(Guid.Empty))
            {
                if (cbossKH_NhapSanPhamMoi_Id_CanCu.EditValue == null)
                {
                    ActiveControl = cbossKH_NhapSanPhamMoi_Id_CanCu;
                    MMessage.ShowWarning("Bạn phải xác định phiếu nhập căn cứ theo kế hoạch nào.");
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
            var phieu_NhapSanPhamMoi_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<Phieu_NhapSanPhamMoi_CT>();
            if (phieu_NhapSanPhamMoi_CT.sDM_SanPham_Id.HasValue && !phieu_NhapSanPhamMoi_CT.sDM_SanPham_Id.Value.Equals(Guid.Empty))
            {
                frmPhuKienDetail frmPhuKienDetail = new frmPhuKienDetail(phieu_NhapSanPhamMoi_CT.sDM_SanPham_Id.Value,
                    "Phieu_NhapSanPhamMoi_CT_PhuKien", "phieu_NhapSanPhamMoi_CT_PhuKiens",
                    phieu_NhapSanPhamMoi_CT, this, false, "KH_NhapSanPhamMoi_CT_PhuKien");
                frmPhuKienDetail.ShowDialog();
            }
            else
            {
                MMessage.ShowWarning("Bạn phải chọn sản phẩm trước khi nhập thông tin chi tiết phụ kiện");
            }
        }

        private void cbosDM_CanBo_Id_NguoiDuyet_QueryPopUp(object sender, CancelEventArgs e)
        {
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource= DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id,sTenCanBo", viewName: "View_DM_CanBo",
                where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' AND iDictionaryKey IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong})", orderBy: "sTen");

        }

        private void cbosDM_CanBo_Id_NguoiNhap_QueryPopUp(object sender, CancelEventArgs e)
        {
            cbosDM_CanBo_Id_NguoiNhap.Properties.DataSource= DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id,sTenCanBo",where: $"sDM_DonVi_Id='{cbosDM_DonVi_Id_Nhap.EditValue}'", orderBy: "sTen");
        }

        private void cbosDM_CanBo_Id_NguoiLapPhieu_QueryPopUp(object sender, CancelEventArgs e)
        {
            cbosDM_CanBo_Id_NguoiLapPhieu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
               columns: "Id,sTenCanBo", viewName: "View_DM_CanBo",
               where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}'", orderBy: "sTen");
            
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            CommonFnUI.ImportMaVach(this,grdSanPham.GrdDetail);
        }
        #endregion

        #region"Overrides"

        /// <summary>
        /// Thiết lập các tham số trước khi in
        /// </summary>
        /// <param name="configExcel"></param>
        /// <param name="configReport"></param>
        protected override void SetConfigBeforePrint(ConfigExcel configExcel, ConfigReport configReport)
        {
            base.SetConfigBeforePrint(configExcel, configReport);
            //Đối tượng xử lý nghiệp vụ IN
            configReport.RepName = "Print_Phieu_NhapSanPhamMoi_DetailRepository";
            //Định danh mẫu in trong bảng ReportData
            configReport.DictionaryKey = MT.Data.ReportDictionaryKey.RP_Print_Phieu_NhapSanPhamMoi;

            //Danh sách các cột trên table
            configExcel.ShowColumnsOrder = new HashSet<string>
            {
                "sSTT","sDM_SanPham_Id_Ten","sDM_DonViTinh_Id_Ten","rSoLuong","rDonGia","rThanhTien",
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
            List<MT.Data.BO.Phieu_NhapSanPhamMoi_CT> phieu_NhapSanPhamMoi_CTs = mGridEditable.GrdDetail.GetAllData<MT.Data.BO.Phieu_NhapSanPhamMoi_CT>();
            if (isValid && dataChanged != null)
            {
                foreach (var item in dataChanged)
                {
                    var castItem = (MT.Data.BO.Phieu_NhapSanPhamMoi_CT)item;
                    //1.Cột số lượng và đơn giá, thời gian bảo hành phải luôn lớn >0
                    if (isValid && castItem.rSoLuong <= 0)
                    {
                        isValid = false;
                        mGridEditable.GrdDetail.FirstView.FocusedColumn = mGridEditable.GrdDetail.FirstView.Columns["rSoLuong"];
                        mGridEditable.GrdDetail.FirstView.FocusedRowHandle = castItem.RowHandle;
                        MMessage.ShowWarning($"Sản phẩm <{castItem.sDM_SanPham_Id_Ten}> số lượng nhập phải luôn lớn hơn 0");
                        break;
                    }

                    if (isValid && castItem.rDonGia <= 0)
                    {
                        isValid = false;
                        mGridEditable.GrdDetail.FirstView.FocusedColumn = mGridEditable.GrdDetail.FirstView.Columns["rDonGia"];
                        mGridEditable.GrdDetail.FirstView.FocusedRowHandle = castItem.RowHandle;
                        MMessage.ShowWarning($"Sản phẩm <{castItem.sDM_SanPham_Id_Ten}> đơn giá nhập phải luôn lớn hơn 0");
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
                        MMessage.ShowWarning($"Bạn phải chọn số serial cho sản phẩm <{castItem.sDM_SanPham_Id_Ten}>");
                        break;
                    }

                    //3. Cột mã vạch không được trùng nhau
                    if (isValid && phieu_NhapSanPhamMoi_CTs != null && phieu_NhapSanPhamMoi_CTs.Count > 0)
                    {
                        //Kiểm tra mã vạch có bị trùng hay không
                        MT.Data.BO.Phieu_NhapSanPhamMoi_CT findBysMaVach = phieu_NhapSanPhamMoi_CTs.Find(m => m.sMaVach.Equals(castItem.sMaVach) && m.Id != castItem.Id);
                        if (findBysMaVach != null)
                        {
                            isValid = false;
                            mGridEditable.GrdDetail.FirstView.FocusedColumn = mGridEditable.GrdDetail.FirstView.Columns["sMaVach"];
                            mGridEditable.GrdDetail.FirstView.FocusedRowHandle = castItem.RowHandle;
                            MMessage.ShowWarning($"Mã vạch <{castItem.sMaVach}> của sản phẩm <{castItem.sDM_SanPham_Id_Ten}> đã tồn tại");
                            break;
                        }
                    }
                }
            }

            if (isValid && phieu_NhapSanPhamMoi_CTs?.Count>0)
            {
                if (cbosDM_NhaCC_Id.EditValue == null)
                {
                    isValid = false;
                    MMessage.ShowWarning("Bạn không được bỏ trống thông tin nhà cung cấp.");
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
                case "Phieu_NhapSanPhamMoi_CT":
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
                case "Phieu_NhapSanPhamMoi_CT":
                    Phieu_NhapSanPhamMoi_CT phieu_NhapSanPhamMoi_CT = mGridControl.GetRecordByRowSelected<Phieu_NhapSanPhamMoi_CT>();
                    if (e.Column.FieldName == "rSoLuong" || e.Column.FieldName == "rDonGia")
                    {
                        phieu_NhapSanPhamMoi_CT.rThanhTien = phieu_NhapSanPhamMoi_CT.rSoLuong * phieu_NhapSanPhamMoi_CT.rDonGia;
                    }
                    if (e.Column.FieldName == "sSTTSP")
                    {
                        object objsSerial = e.Value;
                        if (objsSerial != null)
                        {
                            string[] arrSerial = objsSerial.ToString().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (arrSerial.Length >= 1)
                            {
                                phieu_NhapSanPhamMoi_CT.rSoLuong = arrSerial.Length;
                            }
                        }
                    }
                    var now = SysDateTime.Instance.Now();
                    if (e.Column.FieldName == "iThoiGianBaoHanh" || e.Column.FieldName == "iDonViThoiGianBaoHanh")
                    {
                        DateTime? dHanBaoHanhDen = null;
                        switch (phieu_NhapSanPhamMoi_CT.iDonViThoiGianBaoHanh)
                        {
                            case (int)MT.Data.iDonViThoiGianHieuLuc.Ngay:
                                dHanBaoHanhDen = now.AddDays(phieu_NhapSanPhamMoi_CT.iThoiGianBaoHanh).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Thang:
                                dHanBaoHanhDen = now.AddMonths(phieu_NhapSanPhamMoi_CT.iThoiGianBaoHanh).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Quy:
                                dHanBaoHanhDen =now.AddYears(phieu_NhapSanPhamMoi_CT.iThoiGianBaoHanh * 3).AddDays(1);
                                break;

                            case (int)MT.Data.iDonViThoiGianHieuLuc.Nam:
                                dHanBaoHanhDen = now.AddYears(phieu_NhapSanPhamMoi_CT.iThoiGianBaoHanh).AddDays(1);
                                break;
                        }
                        phieu_NhapSanPhamMoi_CT.dHanBaoHanhDen = dHanBaoHanhDen;
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
                    cbossKH_NhapSanPhamMoi_Id_CanCu.SetReadOnly(false);
                    break;

                default:
                    cbossKH_NhapSanPhamMoi_Id_CanCu.SetReadOnly(true);
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
            var currentData = (Phieu_NhapSanPhamMoi)base.PrepareDataBeforeBindDataForm();

            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:
                    currentData.dNgayPhieu_NhapSanPhamMoi = SysDateTime.Instance.Now();
                    currentData.sDM_DonVi_Id_Nhap = MT.Library.SessionData.OrganizationUnitId;
                    currentData.sDM_CanBo_Id_NguoiLapPhieu = MT.Library.SessionData.UserId;
                    currentData.sDM_CanBo_Id_NguoiNhap = MT.Library.SessionData.UserId;
                    currentData.iNhapVeKho = true;
                    currentData.sKH_NhapSanPhamMoi_Id_CanCu = null;
                    break;
            }
            return currentData;
        }

        /// <summary>
        /// Chọn Kế hoạch xuất thì gán lại các giá trị cho control bên cạnh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbosKH_NhapSanPhamMoi_Id_CanCu_EditValueChanged(object sender, EventArgs e)
        {
            var record = cbossKH_NhapSanPhamMoi_Id_CanCu.GetRecordSelected<KH_NhapSanPhamMoi>();
            if (record != null)
            {
                cbosDM_NhaCC_Id.EditValue = record.sDM_NhaCC_Id;
            }
            else
            {
                cbosDM_NhaCC_Id.EditValue = null;
            }
        }

        private void cbossKH_NhapSanPhamMoi_Id_CanCu_QueryPopUp(object sender, CancelEventArgs e)
        {
            cbossKH_NhapSanPhamMoi_Id_CanCu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.KH_NhapSanPhamMoiRepository>().GetData(typeof(MT.Data.BO.KH_NhapSanPhamMoi),
               columns: "Id,sMa,dNgayLap,sDM_DonVi_Id_DonViXayDungKH_Ten,sSoHopDong,dNgayHopDong,iThoiGianHieuLuc,sDM_NhaCC_Id",
               where: $"iTrangThaiDuyet=1 AND iTrangThaiThucHienKHNM < {(int)MT.Data.iTrangThaiThucHienKHNM.DaHoanThanh} AND sDM_DonVi_Id_DonViNhap='{MT.Library.SessionData.OrganizationUnitId}'",
               orderBy: "sSo DESC", viewName: "View_KH_NhapSanPhamMoi");
        }




        #endregion

    }
}