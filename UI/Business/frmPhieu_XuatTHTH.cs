using DevExpress.XtraGrid.Views.Grid;
using MT.Data.BO;
using MT.Data.Rep;
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
    public partial class frmPhieu_XuatTHTH : FormUI.MFormList
    {
        #region"Property"
        private DM_DonViRepository dM_DonViRepository;
        private bool isLoaded = false;
        #endregion

        #region"Contructor"

        public frmPhieu_XuatTHTH()
        {
            InitializeComponent();
            ConfigFormDetail = new ConfigFormDetail
            {
                Rep = DBContext.GetRep<Phieu_XuatTHTHRepository>(),
                FormName = "frmPhieu_XuatTHTHDetail",
                Grid = gridMaster,
                MToolbarList = mToolbarList1,
                EntityName = "Phieu_XuatTHTH",
                Title = "Phiếu xuất thu hồi, tiêu hủy sản phẩm"
            };
            // 14.6
            mToolbarList1.ButtonNames = new MButtonName[]
           {
                new MButtonName{CommandName=MCommandName.AddNew},
                new MButtonName{CommandName=MCommandName.Duplicate},
                new MButtonName{CommandName=MCommandName.View},
                new MButtonName{CommandName=MCommandName.Edit},
                new MButtonName{CommandName=MCommandName.Delete},
                new MButtonName{CommandName=MCommandName.Approve,BeginGroup=true},
                new MButtonName{CommandName=MCommandName.Reject},
                new MButtonName{CommandName=MCommandName.Print,BeginGroup=true},
                new MButtonName{CommandName=MCommandName.Excel,BeginGroup=true},
                new MButtonName{CommandName=MCommandName.Refresh,BeginGroup=true},
                new MButtonName{CommandName=MCommandName.Help,BeginGroup=true}
           };
            GrdDetails = new Dictionary<string, MTControl.MGridControl>
            {
                {"Phieu_XuatTHTH_CT",grdSanPham }
            };

            this.ControlTepDinhKem = ucTepDinhKem1;
            InitRep();

            InitLookup(); // Truong

            InitGrid();

            InitControl();
        }

        #endregion

        /// <summary>
        /// Khởi tạo giá trị combo
        /// </summary>
        private void InitLookup()
        {
        }

        #region"Sub/Func"

        private void InitControl()
        {
            cboEnumiLoaiTCXuat.ItemEnum.Add(-1, "Tất cả");
            cboEnumiLoaiTCXuat.DefaultValueEnum = -1;
            cboEnumiLoaiTCXuat.EnumData = "iTCXuatTH";
            isLoaded = true;

            drKyBaoCao.SetDefaultValue(MT.Library.Enummation.Period.NamNay);

            drKyBaoCao.Period_Changed = new EventHandler(LoadMasterData);

            /*var datas = dM_DonViRepository.GetDonViConCap1VaDonViCungCap(MT.Library.SessionData.OrganizationUnitId);
            treesDM_DonVi_Id_DonViXuat.Properties.DisplayMember = "sTenDonvi";
            treesDM_DonVi_Id_DonViXuat.Properties.ValueMember = "Id";
            var treeList = treesDM_DonVi_Id_DonViXuat.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            treesDM_DonVi_Id_DonViXuat.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            treesDM_DonVi_Id_DonViXuat.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            treesDM_DonVi_Id_DonViXuat.Properties.DataSource = datas;*/
        }

        /// <summary>
        /// Khởi tạo các cột trên grid
        /// </summary>
        /// Create by: dvthang:07.03.2017
        private void InitGrid()
        {
            var grd = this.gridMaster.GetMGridControl();
            grd.TableName = "Phieu_XuatTHTH";
            grd.ViewName = ((Phieu_XuatTHTHRepository)ConfigFormDetail.Rep).GetViewPaging();

            grd.CustomModelFields = "sDM_CanBo_Id_NguoiDuyet,sDM_CanBo_Id_NguoiLapPhieu";  // 14.6
            grd.SetMutiSelectRows(true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect); // 14.6

            this.gridMaster.KeyName = "Id";
            grd.IsShowFilter = true;
            this.gridMaster.AddColumnText("sMa", "Số phiếu", "Số phiếu xuất", 120, isFixWidth: true, fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            //this.gridMaster.AddColumnText("soKHX", "Số kế hoạch xuất", "Số kế hoạch xuất", 120, isFixWidth: true, fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            //this.gridMaster.AddColumnText("sMaPhieu_XuatTHTH", "Mã phiếu xuất","Mã phiếu xuất", 180,isFixWidth:true,fixedStyle:DevExpress.XtraGrid.Columns.FixedStyle.Left);
            this.gridMaster.AddColumnText("dNgayPhieu_Xuat", "Ngày phiếu", 100);
            //this.gridMaster.AddColumnText("sKH_XuatTHTH_Id_CanCu", "Kế hoạch xuất", 150,fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            var colMaster = this.gridMaster.AddColumnText("sDM_DonVi_Id_Xuat_Ten", "Đơn vị xuất", 150);
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.TreeLookUpEdit, DisplayText = "sTenDonVi", TableName = "DM_DonVi" };
            //this.gridMaster.AddColumnText("sDM_Kho_Id_Xuat", "Kho xuất", "Kho xuất", 150);
            colMaster = this.gridMaster.AddColumnText("sDM_DonVi_Id_Nhap_Ten", "Đơn vị nhập", "Đơn vị nhập", 150);
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.TreeLookUpEdit, DisplayText = "sTenDonVi", TableName = "DM_DonVi" };
            //this.gridMaster.AddColumnText("sDM_Kho_Id_Nhan", "Kho nhận","Kho nhận", 150);

            //this.gridMaster.AddColumnText("sDM_CanBo_Id_NguoiGiao_Ten", "Người giao", "Người giao", 150);
            colMaster = this.gridMaster.AddColumnText("sDM_CanBo_Id_NguoiNhap_Ten", "Người nhập", "Người nhập", 150);
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.LookUpEdit, DisplayText = "sTenCanBo", TableName = "DM_CanBo" };
            colMaster = this.gridMaster.AddColumnText("sDM_CanBo_Id_NguoiLapPhieu_Ten", "Người lập phiếu", "Người lập phiếu", 150);
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.LookUpEdit, DisplayText = "sTenCanBo", TableName = "DM_CanBo" };
            colMaster = this.gridMaster.AddColumnText("sDM_CanBo_Id_NguoiDuyet_Ten", "Người duyệt", "Người duyệt", 150);
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.LookUpEdit, DisplayText = "sTenCanBo", TableName = "DM_CanBo" };
            // 14.6
            this.gridMaster.AddColumnText("dNgayDuyet", "Ngày duyệt", 80);
            this.gridMaster.AddColumnText("sLyDoXetDuyet", "Lý do duyệt/từ chối", 180);

            this.gridMaster.AddColumnText("sGhiChu", "Ghi chú", 200);

            // 14.6
            colMaster = this.gridMaster.AddColumnText("iTrangThaiDuyet", "Trạng thái duyệt", 100,
               fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);
            colMaster.EnumName = "iTrangThaiDuyetKHNM";
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.ComboBox };

            colMaster = this.gridMaster.AddColumnText("iTrangThaiThucHienKHNM", "Trạng thái thực hiện", 100,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);
            colMaster.EnumName = "iTrangThaiThucHienKHNM";
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.ComboBox };

            //Sản phẩm
            grdSanPham.TableName = "Phieu_XuatTHTH_CT";
            grdSanPham.ViewName = "View_Phieu_XuatTHTH_CT";
            grdSanPham.KeyName = "Id";
            grdSanPham.FirstView.OptionsNavigation.EnterMoveNextColumn = true;

            grdSanPham.FirstView.FocusedRowChanged -= grdSanPham_FirstView_FocusedRowChanged;
            grdSanPham.FirstView.FocusedRowChanged += grdSanPham_FirstView_FocusedRowChanged;

            var col = grdSanPham.AddColumnText("sMaVach", "Mã vạch", 100, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);

            col = grdSanPham.AddColumnText("sDM_SanPham_Id_Ma", "Mã sản phẩm", 100, isFixWidth: true,
              fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);

            col = grdSanPham.AddColumnText("sDM_MangLienLac_Id_Ten", "Tên mạng liên lạc", 150);

            col = grdSanPham.AddColumnText("sDM_SanPham_Id_Ten", "Tên sản phẩm", 180);

            col = grdSanPham.AddColumnText("sDM_DonViTinh_Id_Ten", "Đơn vị tính", 100);

            col = grdSanPham.AddColumnText("sSerial", "Số serial", 100);

            grdSanPham.AddColumnText("rSoLuong", "Số lượng", 100);
            grdSanPham.AddColumnText("rDonGia", "Đơn giá", 120);
            grdSanPham.AddColumnText("rThanhTien", "Thành tiền", 120);
            grdSanPham.AddColumnText("sCauHinhKyThuat", "Cấu hình kỹ thuật", 150);
            grdSanPham.AddColumnText("sXuatXu", "Xuất xứ", 150);
            grdSanPham.AddColumnText("iNamSX", "Năm sản xuất", 80);
            grdSanPham.AddColumnText("iThoiGianBaoHanh", "Thời gian BH", toolTip: "Thời gian bảo hành", 80);
            col = grdSanPham.AddColumnText("iDonViThoiGianBaoHanh", "Đơn vị t.gian BH", toolTip: "Đơn vị thời gian bảo hành", 80);
            col.EnumName = "iDonViThoiGianBaoHanh";
            grdSanPham.AddColumnText("dHanBaoHanhDen", "Hạn bảo hành", 80);
            grdSanPham.AddColumnText("sGhiChu", "Ghi chú", 200);

            //PhuKien

            grdPhuKienDetail.TableName = "Phieu_XuatTHTH_CT_PhuKien";
            grdPhuKienDetail.ViewName = "View_Phieu_XuatTHTH_CT_PhuKien";
            grdPhuKienDetail.KeyName = "Id";
            var colPhuKien = grdPhuKienDetail.AddColumnText("sDM_PhuKien_Id_Ten", "Tên phụ kiện", 180, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);

            colPhuKien = grdPhuKienDetail.AddColumnText("sDM_DonViTinh_Id_Ten", "Đơn vị tính", 150);

            grdPhuKienDetail.AddColumnText("rSoLuong", "Số lượng", 150);
            grdPhuKienDetail.AddColumnText("rDonGia", "Đơn giá", 150);
            grdPhuKienDetail.AddColumnText("rThanhTien", "Thành tiền", 150);
            grdPhuKienDetail.AddColumnText("sXuatXu", "Xuất xứ", 150);
            grdPhuKienDetail.AddColumnText("sGhiChu", "Ghi chú", 200);
        }

        /// <summary>
        /// Khởi tạo đối tượng kết nối db
        /// </summary>
        private void InitRep()
        {
            dM_DonViRepository = (DM_DonViRepository)DBContext.GetRep<MT.Data.Rep.DM_DonViRepository>();
        }

        #endregion

        #region"Overrides"
        protected override void GridMasterCustomRowCellStyle(MGridView view, RowCellStyleEventArgs e)
        {
            base.GridMasterCustomRowCellStyle(view, e);
            if (!view.IsFilterRow(e.RowHandle) && e.RowHandle >= 0)
            {
                object val = view.GetRowCellValue(e.RowHandle, view.Columns["iTrangThaiDuyet"]);
                if (val == null)
                {
                    return;
                }
                switch ((int)val)
                {
                    case (int)MT.Data.iTrangThaiDuyetKHNM.ChoDuyet:
                        e.Appearance.BackColor = MT.Data.SysVariables.MauChoDuyet;
                        e.Appearance.BackColor2 = MT.Data.SysVariables.MauChoDuyet;
                        e.Appearance.ForeColor = Color.White;
                        break;
                    case (int)MT.Data.iTrangThaiDuyetKHNM.DongYDuyet:
                        e.Appearance.BackColor = MT.Data.SysVariables.MauDaDuyet;
                        e.Appearance.BackColor2 = MT.Data.SysVariables.MauDaDuyet;
                        e.Appearance.ForeColor = Color.FromArgb(0, 123, 255);
                        e.Appearance.Font = new System.Drawing.Font(e.Appearance.Font, FontStyle.Bold);
                        break;
                    case (int)MT.Data.iTrangThaiDuyetKHNM.TuChoiDuyet:
                        e.Appearance.BackColor = MT.Data.SysVariables.MauTuChoi;
                        e.Appearance.BackColor2 = MT.Data.SysVariables.MauTuChoi;
                        e.Appearance.ForeColor = Color.White;
                        break;
                }
            }
        }
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
            configReport.RepName = "Print_Phieu_XuatTHTH_DetailRepository";
            //Định danh mẫu in trong bảng ReportData
            configReport.DictionaryKey = MT.Data.ReportDictionaryKey.RP_Print_Phieu_XuatTHTHDetail;

            //Danh sách các cột trên table
            configExcel.ShowColumnsOrder = new HashSet<string>
            {
                "sSTT","sDM_SanPham_Id_Ten","sDM_DonViTinh_Id_Ten","rSoLuong",
                "sXuatXu","iNamSX","iThoiGianBaoHanh"
            };
        }

        // Note 14.6
        /// <summary>
        /// Kiểm tra xem người dùng có quyền thực hiện chức năng duyệt và từ chối duyệt không
        /// </summary>
        /// <returns>=true cho phép thực hiện hành động, ngược lại thì không</returns>
        private bool CheckPermissionAproveOrReject(MT.Data.iTrangThaiDuyetPNM iTrangThaiDuyetKHNM)
        {
            var datas = gridMaster.GetListRecordByRowsSelected<MT.Data.BO.Phieu_XuatTHTH>();

            if (datas == null || datas.Count == 0)
            {
                MMessage.ShowWarning("Bạn phải chọn ít nhất 1 phiếu xuất sản phẩm.");
                return false;
            }
            string msg = "Phê duyệt";
            if (iTrangThaiDuyetKHNM == MT.Data.iTrangThaiDuyetPNM.TuChoiDuyet)
            {
                msg = "Từ chối";
            }

            foreach (var item in datas)
            {
                //Kiểm tra người duyệt chính là người đăng nhập thì mới được duyệt
                if (!item.sDM_CanBo_Id_NguoiDuyet.HasValue || MT.Library.SessionData.UserId != item.sDM_CanBo_Id_NguoiDuyet.Value)
                {
                    MMessage.ShowWarning($"Bạn không có quyền {msg} với phiếu xuất sản phẩm <{item.sMa}>.");
                    return false;
                }

                //Nếu phiếu đã phát sinh phiếu nhập thì không cho phế duyệt hoặc từ chối
                //Nếu phiếu sản phẩm đã phát sinh phiếu nhập thì không cho sửa
                List<string> pHXuatSP_sMas = DBContext.GetRep2<Phieu_XuatTHTHRepository>().GetPhieuNhapsByPhX(item.Id);
                if (pHXuatSP_sMas.Count > 0)
                {
                    MMessage.ShowWarning($"Bạn không được phép {msg}. Do phiếu sản phẩm <{item.sMa}> đã phát sinh các phiếu xuất <{string.Join(", ", pHXuatSP_sMas)}>.");
                    return false;
                }
            }

            return true;
        }

        // NOTEEEEEEEEEEEEEEEEEEEEEEEEEEEE
        // 14.6
        /// <summary>
        /// Ẩn hiện các button trên toolbar
        /// </summary>
        /// <param name="mToolbar"></param>
        protected override void CustomSetEnableButtonOnToolbar(MToolbarList mToolbar, MBindingSource mBindingSource)
        {
            base.CustomSetEnableButtonOnToolbar(mToolbar, mBindingSource);

            var chucVu = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                columns: "Id",
                where: $"Id='{MT.Library.SessionData.UserId}' and iDictionaryKey NOT IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong})",
                viewName: "View_DM_CanBo");

            if (mBindingSource == null || mBindingSource.Count == 0 || chucVu.Count > 0)
            {
                SetEnableButtonOnToolbar(MCommandName.Approve, false);
                SetEnableButtonOnToolbar(MCommandName.Reject, false);
            }
            else
            {
                SetEnableButtonOnToolbar(MCommandName.Approve, true);
                SetEnableButtonOnToolbar(MCommandName.Reject, true);
            }
        }

        /// <summary>
        /// Bắt event trên thanh toolbar
        /// </summary>
        /// <param name="tag"></param>
        protected override void ProcessItemClick(int tag, object sender)
        {
            base.ProcessItemClick(tag, sender);
            switch (tag)
            {
                // 14.6
                case (int)MCommandName.Approve:

                    if (CheckPermissionAproveOrReject(MT.Data.iTrangThaiDuyetPNM.DongYDuyet))
                    {
                        var datasApprove = gridMaster.GetListRecordByRowsSelected<MT.Data.BO.Phieu_XuatTHTH>();
                        if (datasApprove.Any(m => m.iTrangThaiDuyet == (int)MT.Data.iTrangThaiDuyetPNM.DongYDuyet))
                        {
                            string strMaApproves = string.Join(", ", datasApprove.FindAll(m => m.iTrangThaiDuyet == (int)MT.Data.iTrangThaiDuyetPNM.DongYDuyet).Select(m => m.sMa));
                            MMessage.ShowWarning($"Các phiếu xuất <{strMaApproves}> đã được duyệt. Bạn vui lòng chọn phiếu khác.");
                            return;
                        }

                        var frmPhieu_XuatTHTH_PheDuyet = new frmPhieu_XuatTHTH_PheDuyet(this, MT.Data.iTrangThaiDuyetPNM.DongYDuyet, datasApprove);
                        frmPhieu_XuatTHTH_PheDuyet.ShowDialog();
                        frmPhieu_XuatTHTH_PheDuyet.Dispose();
                    }
                    break;

                case (int)MCommandName.Reject:
                    if (CheckPermissionAproveOrReject(MT.Data.iTrangThaiDuyetPNM.TuChoiDuyet))
                    {
                        var datasReject = gridMaster.GetListRecordByRowsSelected<MT.Data.BO.Phieu_XuatTHTH>();
                        if (datasReject.Any(m => m.iTrangThaiDuyet == (int)MT.Data.iTrangThaiDuyetPNM.TuChoiDuyet))
                        {
                            string strMaRejects = string.Join(", ", datasReject.FindAll(m => m.iTrangThaiDuyet == (int)MT.Data.iTrangThaiDuyetPNM.TuChoiDuyet).Select(m => m.sMa));
                            MMessage.ShowWarning($"Các phiếu xuất <{strMaRejects}> đã bị từ chối. Bạn vui lòng chọn phiếu khác.");
                            return;
                        }
                        var frmPhieu_XuatTHTH_TuChoi = new frmPhieu_XuatTHTH_PheDuyet(this, MT.Data.iTrangThaiDuyetPNM.TuChoiDuyet, datasReject);
                        frmPhieu_XuatTHTH_TuChoi.ShowDialog();
                        frmPhieu_XuatTHTH_TuChoi.Dispose();
                    }
                    break;
            }
        }

        /// <summary>
        /// Sau khi load chi tiết sản phẩm xong thì mặc định load đến detail phụ kiện
        /// </summary>
        /// <param name="gridControl"></param>
        /// <param name="data"></param>
        protected override void CustomLoadFinishDetailByMaster(MGridControl gridControl, IList data)
        {
            base.CustomLoadFinishDetailByMaster(gridControl, data);

            if (gridControl.TableName == "Phieu_XuatTHTH_CT")
            {
                object masterId = gridControl.FirstView.GetFocusedRowCellValue("Id");
                if (!backgroundWorkerPhuKien.IsBusy)
                {
                    grdPhuKienDetail.FirstView.ShowLoadingPanel();
                    backgroundWorkerPhuKien.RunWorkerAsync(masterId);
                }
            }
        }

        /// <summary>
        /// Hàm thực hiện load thông tin master
        /// </summary>
        private void LoadMasterData(object sender, EventArgs e)
        {
            try
            {
                if (!drKyBaoCao.FromDate.HasValue)
                {
                    MMessage.ShowWarning("Từ ngày không được bỏ trống");
                    return;
                }
                if (!drKyBaoCao.ToDate.HasValue)
                {
                    MMessage.ShowWarning("Đến ngày không được bỏ trống");
                    return;
                }

                if (drKyBaoCao.ToDate.Value < drKyBaoCao.FromDate.Value)
                {
                    MMessage.ShowWarning("Từ ngày không được nhỏ hơn Đến ngày.");
                    return;
                }

                /*if (treesDM_DonVi_Id_DonViXuat.EditValue == null)
                {
                    MMessage.ShowWarning("Thông tin đơn vị không được bỏ trống.");
                    return;
                }*/

                PagingList.SetWhere($@" dNgayPhieu_Xuat BETWEEN '{drKyBaoCao.FromDate.Value.StartDate()}'
                                    AND '{drKyBaoCao.ToDate.Value.EndDate()}'
                                    AND (iTCXuat={cboEnumiLoaiTCXuat.GetValue()} OR {cboEnumiLoaiTCXuat.GetValue()}<=-1) ");
                RefreshData();
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
        }

        #endregion

        #region"Event"

        private void frmPhieu_XuatTHTH_Load(object sender, EventArgs e)
        {
            //treesDM_DonVi_Id_DonViXuat.EditValue = MT.Library.SessionData.OrganizationUnitId;
            LoadMasterData(sender, e);
        }

        /// <summary>
        /// Bắt event focus vào chi tiết sản phẩm thì load lên danh sách phụ kiện tương ứng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdSanPham_FirstView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            MGridView gridVIew = (sender as MGridView);
            string primaryKeyName = grdSanPham.KeyName;
            if (string.IsNullOrWhiteSpace(primaryKeyName))
            {
                primaryKeyName = "Id";
            }
            object masterId = gridVIew.GetFocusedRowCellValue(primaryKeyName);
            if (!backgroundWorkerPhuKien.IsBusy)
            {
                grdPhuKienDetail.FirstView.ShowLoadingPanel();
                backgroundWorkerPhuKien.RunWorkerAsync(masterId);
            }
        }

        /// <summary>
        /// Lấy dữ liệu chi tiết phụ kiện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerPhuKien_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = DBContext.GetRep<Phieu_XuatTHTH_CTRepository>().GetDetailsByMasterID2("View_Phieu_XuatTHTH_CT_PhuKien",
                        "Phieu_XuatTHTH_CT_PhuKien", e.Argument);
            }
            finally
            {
                grdPhuKienDetail.Invoke(new Action(() =>
                {
                    grdPhuKienDetail.FirstView.HideLoadingPanel();
                }));
            }
        }

        /// <summary>
        /// Bind dữ liệu lên grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerPhuKien_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                grdPhuKienDetail.DataSource = e.Result;
            }
            else
            {
                MMessage.ShowError(e.Error.Message);
            }
        }

        /// <summary>
        /// Nhấn nút tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMasterData(sender, e);
        }

        /// <summary>
        /// Thay đổi tree đơn vị
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treesDM_DonVi_Id_DonViXayDungKH_EditValueChanged(object sender, EventArgs e)
        {
            LoadMasterData(sender, e);
        }

        #endregion

        private void cboEnumiLoaiTCXuat_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void cboEnumiLoaiTCXuat_EditValueChanged_1(object sender, EventArgs e)
        {
            if (isLoaded)
                LoadMasterData(sender, e);
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            LoadMasterData(sender, e);
        }
    }
}