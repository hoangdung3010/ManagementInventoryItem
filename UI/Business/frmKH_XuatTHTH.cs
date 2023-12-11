using DevExpress.XtraGrid.Views.Base;
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
    public partial class frmKH_XuatTHTH : FormUI.MFormList
    {
        #region"Property"
        private DM_DonViRepository dM_DonViRepository;
        #endregion

        #region"Contructor"

        public frmKH_XuatTHTH()
        {
            InitializeComponent();
            ConfigFormDetail = new ConfigFormDetail
            {
                Rep = DBContext.GetRep<KH_XuatTHTHRepository>(),
                FormName = "frmKH_XuatTHTHDetail",
                Grid = gridMaster,
                MToolbarList = mToolbarList1,
                EntityName = "KH_XuatTHTH",
                Title = "Kế hoạch Xuất thu hồi"
            };
            // NOTEEEEEEEEEE
            // Note 14.6
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
                {"KH_XuatTHTH_CT",grdSanPham }
            };
            this.ControlTepDinhKem = ucTepDinhKem1;
            InitRep();

            InitGrid();

            InitControl();
        }

        #endregion

        #region"Sub/Func"

        private void InitControl()
        {
            drKyBaoCao.SetDefaultValue(MT.Library.Enummation.Period.NamNay);

            drKyBaoCao.Period_Changed = new EventHandler(LoadMasterData);

            /* var datas = dM_DonViRepository.GetDonViConCap1VaDonViCungCap(MT.Library.SessionData.OrganizationUnitId);
             treesDM_DonVi_Id_DonViXayDungKH.Properties.DisplayMember = "sTenDonvi";
             treesDM_DonVi_Id_DonViXayDungKH.Properties.ValueMember = "Id";
             var treeList = treesDM_DonVi_Id_DonViXayDungKH.Properties.TreeList;
             treeList.KeyFieldName = "Id";
             treeList.ParentFieldName = "sParentId";
             treesDM_DonVi_Id_DonViXayDungKH.AddColumn("sMaDonvi", "Mã đơn vị", 120);
             treesDM_DonVi_Id_DonViXayDungKH.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
             treesDM_DonVi_Id_DonViXayDungKH.Properties.DataSource = datas;*/
        }

        /// <summary>
        /// Khởi tạo các cột trên grid
        /// </summary>
        /// Create by: dvthang:07.03.2017
        private void InitGrid()
        {
            var grd = this.gridMaster.GetMGridControl();
            grd.TableName = "KH_XuatTHTH";
            grd.ViewName = ((KH_XuatTHTHRepository)ConfigFormDetail.Rep).GetViewPaging();
            grd.CustomModelFields = "iDonViThoiGianHieuLuc,sDM_CanBo_Id_NguoiDuyet,sDM_CanBo_Id_NguoiLapKH";  // 14.6
            grd.SetMutiSelectRows(true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect); // 14.6

            this.gridMaster.KeyName = "Id";
            grd.IsShowFilter = true;
            this.gridMaster.AddColumnText("sMa", "Số KH", "Số kế hoạch", 120, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);

            //this.gridMaster.AddColumnText("sSoKeHoach", "Số kế hoạch", "Số kế hoạch", 180, isFixWidth: true, fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            this.gridMaster.AddColumnText("dNgayKeHoach", "Ngày kế hoạch", 100);

            var colMaster = this.gridMaster.AddColumnText("sDM_DonVi_Id_DonViXayDungKH_Ten", "Đơn vị xây dựng kế hoạch", 150);
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.TreeLookUpEdit, DisplayText = "sTenDonVi", TableName = "DM_DonVi" };

            colMaster = this.gridMaster.AddColumnText("sDM_DonVi_Id_DonViXuat_Ten", "Đơn vị xuất", "Đơn vị xuất", 150);
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.TreeLookUpEdit, DisplayText = "sTenDonVi", TableName = "DM_DonVi" };

            this.gridMaster.AddColumnText("iThoiGianHieuLuc", "Thời gian hiệu lực", 150);
            colMaster = this.gridMaster.AddColumnText("sDM_CanBo_Id_NguoiLapKH_Ten", "Người lập KH", "Người lập kế hoạch", 150);
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.LookUpEdit, DisplayText = "sTenCanBo", TableName = "DM_CanBo" };
            colMaster = this.gridMaster.AddColumnText("sDM_CanBo_Id_NguoiDuyet_Ten", "Người duyệt", "Người duyệt", 150);
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.LookUpEdit, DisplayText = "sTenCanBo", TableName = "DM_CanBo" };
            // Note
            this.gridMaster.AddColumnText("dNgayDuyet", "Ngày duyệt", 80);
            this.gridMaster.AddColumnText("sLyDoXetDuyet", "Lý do duyệt/từ chối", 180);

            colMaster = this.gridMaster.AddColumnText("sDM_CanBo_Id_ThuTruongDonVi_Ten", "Thủ trưởng đơn vị", "Thủ trưởng đơn vị", 180);
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.LookUpEdit, DisplayText = "sTenCanBo", TableName = "DM_CanBo" };

            this.gridMaster.AddColumnText("sGhiChu", "Ghi chú", 200);

            //  Note
            colMaster = this.gridMaster.AddColumnText("iTrangThaiDuyet", "Trạng thái duyệt", 100,
               fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);
            colMaster.EnumName = "iTrangThaiDuyetKHNM";
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.ComboBox };
            // 14.6
            colMaster = this.gridMaster.AddColumnText("iTrangThaiThucHienKHNM", "Trạng thái thực hiện", 100,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);
            colMaster.EnumName = "iTrangThaiThucHienKHNM";
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.ComboBox };

            //Sản phẩm
            grdSanPham.TableName = "KH_XuatTHTH_CT";
            grdSanPham.ViewName = "View_KH_XuatTHTH_CT";
            grdSanPham.KeyName = "Id";
            grdSanPham.FirstView.OptionsNavigation.EnterMoveNextColumn = true;

            grdSanPham.FirstView.FocusedRowChanged -= grdSanPham_FirstView_FocusedRowChanged;
            grdSanPham.FirstView.FocusedRowChanged += grdSanPham_FirstView_FocusedRowChanged;

            var col = grdSanPham.AddColumnText("sDM_SanPham_Id_Ten", "Tên sản phẩm", 200, isFixWidth: true,
               fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);

            col = grdSanPham.AddColumnText("sSoHopDong", "Số HĐ", 180, isFixWidth: true);
            //col = grdSanPham.AddColumnText("sDM_Kho_Id_Xuat_Ten", "Kho xuất", 180, isFixWidth: true);
            col = grdSanPham.AddColumnText("sDM_DonVi_Id_DonViNhap_Ten", "Đơn vị nhận", 180, isFixWidth: true);
            col = grdSanPham.AddColumnText("sDM_HangMucTHTH_Id_Ten", "Loại hạng mục", 180, isFixWidth: true);
            //col = grdSanPham.AddColumnText("sDM_Kho_Id_Nhap_Ten", "Kho nhập", 150, isFixWidth: true);
            col = grdSanPham.AddColumnText("sDM_DonViTinh_Id_Ten", "Đơn vị tính", 150);

            grdSanPham.AddColumnText("rSoLuong", "Số lượng", 150);

            //col = grdSanPham.AddColumnText("sDM_MangLienLac_Id_Ten", "Tên mạng liên lạc", 150);
            grdSanPham.AddColumnText("rDonGia", "Đơn giá", 150);
            grdSanPham.AddColumnText("rThanhTien", "Thành tiền", 150);
            grdSanPham.AddColumnText("sXuatXu", "Xuất xứ", 150);
            grdSanPham.AddColumnText("sGhiChu", "Ghi chú", 200);

            //PhuKien

            grdPhuKienDetail.TableName = "KH_XuatTHTH_CT_PhuKien";
            grdPhuKienDetail.ViewName = "View_KH_XuatTHTH_CT_PhuKien";
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

        // Note 14.6
        /// <summary>
        /// Kiểm tra xem người dùng có quyền thực hiện chức năng duyệt và từ chối duyệt không
        /// </summary>
        /// <returns>=true cho phép thực hiện hành động, ngược lại thì không</returns>
        private bool CheckPermissionAproveOrReject(MT.Data.iTrangThaiDuyetPNM iTrangThaiDuyetKHNM)
        {
            var datas = gridMaster.GetListRecordByRowsSelected<MT.Data.BO.KH_XuatTHTH>();

            if (datas == null || datas.Count == 0)
            {
                MMessage.ShowWarning("Bạn phải chọn ít nhất 1 kế hoạch Xuất thu hồi.");
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
                    MMessage.ShowWarning($"Bạn không có quyền {msg} với kế hoạch Xuất thu hồi <{item.sMa}>.");
                    return false;
                }

                //Nếu Kế hoạch đã phát sinh phiếu nhập thì không cho phế duyệt hoặc từ chối
                //Nếu kế hoạch Xuất thu hồi đã phát sinh kế hoạch xuất thì không cho sửa
                List<string> kHXuatSP_sMas = DBContext.GetRep2<KH_XuatSanPhamRepository>().GetKeHoachXuatsByKHBD(item.Id);
                if (kHXuatSP_sMas.Count > 0)
                {
                    MMessage.ShowWarning($"Bạn không được phép {msg}. Do kế hoạch Xuất thu hồi <{item.sMa}> đã phát sinh các kế hoạch xuất <{string.Join(", ", kHXuatSP_sMas)}>.");
                    return false;
                }
            }

            return true;
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
                //case (int)MCommandName.Approve:
                //    var data = gridMaster.GetRecordByRowSelected<MT.Data.BO.KH_XuatTHTH>();
                //    frmKH_XuatTHTH_PheDuyet frmKH_XuatTHTH_PheDuyet = new frmKH_XuatTHTH_PheDuyet(data);
                //    frmKH_XuatTHTH_PheDuyet.ShowDialog();
                //    frmKH_XuatTHTH_PheDuyet.Dispose();
                //    break;

                // 14.6
                case (int)MCommandName.Approve:

                    if (CheckPermissionAproveOrReject(MT.Data.iTrangThaiDuyetPNM.DongYDuyet))
                    {
                        var datasApprove = gridMaster.GetListRecordByRowsSelected<MT.Data.BO.KH_XuatTHTH>();
                        if (datasApprove.Any(m => m.iTrangThaiDuyet == (int)MT.Data.iTrangThaiDuyetPNM.DongYDuyet))
                        {
                            string strMaApproves = string.Join(", ", datasApprove.FindAll(m => m.iTrangThaiDuyet == (int)MT.Data.iTrangThaiDuyetPNM.DongYDuyet).Select(m => m.sMa));
                            MMessage.ShowWarning($"Các kế hoạch Xuất thu hồi <{strMaApproves}> đã được duyệt. Bạn vui lòng chọn kế hoạch khác.");
                            return;
                        }

                        var frmKH_XuatTHTH_PheDuyet = new frmKH_XuatTHTH_PheDuyet(this.RefreshData, (int)MT.Data.iTrangThaiDuyetPNM.DongYDuyet, datasApprove);
                        frmKH_XuatTHTH_PheDuyet.ShowDialog();
                        frmKH_XuatTHTH_PheDuyet.Dispose();
                    }
                    break;

                case (int)MCommandName.Reject:
                    if (CheckPermissionAproveOrReject(MT.Data.iTrangThaiDuyetPNM.TuChoiDuyet))
                    {
                        var datasReject = gridMaster.GetListRecordByRowsSelected<MT.Data.BO.KH_XuatTHTH>();
                        if (datasReject.Any(m => m.iTrangThaiDuyet == (int)MT.Data.iTrangThaiDuyetPNM.TuChoiDuyet))
                        {
                            string strMaRejects = string.Join(", ", datasReject.FindAll(m => m.iTrangThaiDuyet == (int)MT.Data.iTrangThaiDuyetPNM.TuChoiDuyet).Select(m => m.sMa));
                            MMessage.ShowWarning($"Các kế hoạch Xuất thu hồi <{strMaRejects}> đã bị từ chối. Bạn vui lòng chọn kế hoạch khác.");
                            return;
                        }
                        var frmKH_XuatTHTH_TuChoi = new frmKH_XuatTHTH_PheDuyet(this.RefreshData, (int)MT.Data.iTrangThaiDuyetPNM.TuChoiDuyet, datasReject);
                        frmKH_XuatTHTH_TuChoi.ShowDialog();
                        frmKH_XuatTHTH_TuChoi.Dispose();
                    }
                    break;
            }
        }

        /// <summary>
        /// Custom lại giá trị hiển thị trên cell của grid
        /// </summary>
        /// <param name="view"></param>
        /// <param name="e"></param>
        protected override void GridMasterCustomDrawCell(MGridView view, RowCellCustomDrawEventArgs e)
        {
            base.GridMasterCustomDrawCell(view, e);
            if (e.Column.FieldName == "iLoaiKH")
            {
                var iLoaiKH = view.GetRowCellValue(e.RowHandle, "iLoaiKH");
                switch (iLoaiKH)
                {
                    case (int)MT.Data.iLoaiKH.ct:
                        e.DisplayText = $"{e.CellValue} ( TBMM-Nguồn CT )";
                        break;

                    case (int)MT.Data.iLoaiKH.tx:
                        e.DisplayText = $"{e.CellValue} ( TBMM-Nguồn TX )";
                        break;

                    case (int)MT.Data.iLoaiKH.tlmm:
                        e.DisplayText = $"{e.CellValue} ( Tài Liệu KTMM )";
                        break;

                    case (int)MT.Data.iLoaiKH.khac:
                        e.DisplayText = $"{e.CellValue} ( Khác )";
                        break;

                    default:
                        e.DisplayText = $"{e.CellValue} ( TBMM-Nguồn CT )";
                        break;
                }
            }
            else if (e.Column.FieldName == "iThoiGianHieuLuc")
            {
                var iDonViThoiGianHieuLuc = view.GetRowCellValue(e.RowHandle, "iDonViThoiGianHieuLuc");
                switch (iDonViThoiGianHieuLuc)
                {
                    case (int)MT.Data.iDonViThoiGianHieuLuc.Thang:
                        e.DisplayText = $"{e.CellValue} ( Tháng )";
                        break;

                    case (int)MT.Data.iDonViThoiGianHieuLuc.Nam:
                        e.DisplayText = $"{e.CellValue} ( Năm )";
                        break;

                    default:
                        e.DisplayText = $"{e.CellValue} ( Ngày )";
                        break;
                }
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

            if (gridControl.TableName == "KH_XuatTHTH_CT")
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

                /*if (treesDM_DonVi_Id_DonViXayDungKH.EditValue == null)
                {
                    MMessage.ShowWarning("Thông tin đơn vị không được bỏ trống.");
                    return;
                }*/

                PagingList.SetWhere($@" dNgayKeHoach BETWEEN '{drKyBaoCao.FromDate.Value.StartDate()}'
                                    AND '{drKyBaoCao.ToDate.Value.EndDate()}'");
                RefreshData();
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
        }

        #endregion

        #region"Event"

        private void frmKH_XuatTHTH_Load(object sender, EventArgs e)
        {
            //treesDM_DonVi_Id_DonViXayDungKH.EditValue = MT.Library.SessionData.OrganizationUnitId;
            //donvin.EditValue = MT.Library.SessionData.OrganizationUnitId;
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
                e.Result = DBContext.GetRep<KH_XuatTHTH_CTRepository>().GetDetailsByMasterID2("View_KH_XuatTHTH_CT_PhuKien",
                        "KH_XuatTHTH_CT_PhuKien", e.Argument);
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

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            LoadMasterData(sender, e);
        }
    }
}