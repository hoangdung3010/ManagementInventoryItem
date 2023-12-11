﻿using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmPhieu_NhapCaiDatSanPham : FormUI.MFormList
    {
        #region"Property"
        private DM_DonViRepository dM_DonViRepository;
        private bool isControlInitCompleted = false;
        #endregion

        #region"Contructor"

        public frmPhieu_NhapCaiDatSanPham()
        {
            InitializeComponent();
            ConfigFormDetail = new ConfigFormDetail
            {
                Rep = DBContext.GetRep<Phieu_NhapCaiDatSanPhamRepository>(),
                FormName = "frmPhieu_NhapCaiDatSanPhamDetail",
                Grid = gridMaster,
                MToolbarList = mToolbarList1,
                EntityName = "Phieu_NhapCaiDatSanPham",
                Title = "Phiếu nhập cài đặt sản phẩm"
            };

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
                {"Phieu_NhapCaiDatSanPham_CT",grdSanPham }
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
            cboTCNhap.ItemEnum.Add(-1, "Tất cả");
            cboTCNhap.DefaultValueEnum = -1;
            drKyBaoCao.SetDefaultValue(MT.Library.Enummation.Period.NamNay);

            drKyBaoCao.Period_Changed = new EventHandler(LoadMasterData);

            cboTCNhap.EnumData = "iTCNhapCĐ";

            isControlInitCompleted = true;
        }

        /// <summary>
        /// Khởi tạo các cột trên grid
        /// </summary>
        /// Create by: dvthang:07.03.2017
        private void InitGrid()
        {
            var grd = this.gridMaster.GetMGridControl();
            grd.TableName = "Phieu_NhapCaiDatSanPham";
            grd.SetMutiSelectRows(true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect);
            grd.ViewName = ((Phieu_NhapCaiDatSanPhamRepository)ConfigFormDetail.Rep).GetViewPaging();
            this.gridMaster.KeyName = "Id";
            grd.Sumary = "rThanhTien";
            grd.IsShowFilter = true;
            grd.CustomModelFields = "sDM_CanBo_Id_NguoiDuyet";
            var colMaster = this.gridMaster.AddColumnText("sMa", "Số phiếu", "Số phiếu", 120, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            this.gridMaster.AddColumnText("sMa_PX", "Căn cứ số", "Căn cứ số", 120);
            this.gridMaster.AddColumnText("dNgayPhieu_Nhap", "Ngày lập phiếu", 100, dataType: DataTypeColumn.DateEdit);

            colMaster = this.gridMaster.AddColumnText("sDM_DonVi_Id_Nhap_Ten", "Đơn vị nhập", "Đơn vị nhập", 180);
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.TreeLookUpEdit, DisplayText = "sTenDonVi", TableName = "DM_DonVi" };

            colMaster = this.gridMaster.AddColumnText("sDM_DonVi_Id_Xuat_Ten", "Đơn vị xuất", "Đơn vị xuất", 180);
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.TreeLookUpEdit, DisplayText = "sTenDonVi", TableName = "DM_DonVi" };

            colMaster = this.gridMaster.AddColumnText("sDM_CanBo_Id_NguoiLapPhieu_Ten", "Người lập", 150);
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.LookUpEdit, DisplayText = "sTenCanBo", TableName = "DM_CanBo", };

            colMaster = this.gridMaster.AddColumnText("sDM_CanBo_Id_NguoiGiao_Ten", "Người giao", 150);
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.LookUpEdit, DisplayText = "sTenCanBo", TableName = "DM_CanBo", };

            colMaster = this.gridMaster.AddColumnText("sDM_CanBo_Id_NguoiNhap_Ten", "Người nhập", 150);
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.LookUpEdit, DisplayText = "sTenCanBo", TableName = "DM_CanBo", };

            colMaster = this.gridMaster.AddColumnText("sDM_CanBo_Id_NguoiDuyet_Ten", "Người duyệt", "Người duyệt", 180);
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.LookUpEdit, DisplayText = "sTenCanBo", TableName = "DM_CanBo", };

            this.gridMaster.AddColumnText("dNgayDuyet", "Ngày duyệt", 80, dataType: DataTypeColumn.DateEdit);
            this.gridMaster.AddColumnText("sLyDoXetDuyet", "Lý do duyệt/từ chối", 180);
            this.gridMaster.AddColumnText("sGhiChu", "Ghi chú", 200);
            //colMaster = this.gridMaster.AddColumnText("rThanhTien", "Tổng tiền", 150, fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);
            //colMaster.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;

            colMaster = this.gridMaster.AddColumnText("iTrangThaiDuyet", "Trạng thái duyệt", 100,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);
            colMaster.EnumName = "iTrangThaiDuyetPXCĐSP";
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.ComboBox };

            colMaster = this.gridMaster.AddColumnText("iLoai", "Tính chất nhập", 150,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);
            colMaster.EnumName = "iTCNhapCĐ";
            colMaster.FilterEditor = new ConfigFilterEditor { DataType = DataTypeColumn.ComboBox };


            //Sản phẩm
            grdSanPham.TableName = "Phieu_NhapCaiDatSanPham_CT";
            grdSanPham.ViewName = "View_Phieu_NhapCaiDatSanPham_CT";
            grdSanPham.KeyName = "Id";
            grdSanPham.FirstView.OptionsNavigation.EnterMoveNextColumn = true;

            grdSanPham.FirstView.FocusedRowChanged -= grdSanPham_FirstView_FocusedRowChanged;
            grdSanPham.FirstView.FocusedRowChanged += grdSanPham_FirstView_FocusedRowChanged;

            var col = grdSanPham.AddColumnText("sMaVach", "Mã vạch", 100, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);

            col = grdSanPham.AddColumnText("sDM_SanPham_Id_Ma", "Mã sản phẩm", 100, isFixWidth: true,
              fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);

            col = grdSanPham.AddColumnText("sDM_SanPham_Id_Ten", "Tên sản phẩm", 180);

            col = grdSanPham.AddColumnText("sDM_DonViTinh_Id_Ten", "Đơn vị tính", 100);

            col = grdSanPham.AddColumnText("sDM_MangLienLac_Id_Ten", "Mạng liên lạc", 150);
            col = grdSanPham.AddColumnText("sDM_NoiDungCaiDat_Id_Ten", "Nội dung CĐ", toolTip: "Nội dung cài đặt", 150);

            col = grdSanPham.AddColumnText("sSerial", "Số serial", 100);
            col = grdSanPham.AddColumnText("sSTTSP", "STT sản phẩm", 100);

            //grdSanPham.AddColumnText("rSoLuong", "Số lượng", 100);
            //grdSanPham.AddColumnText("rDonGia", "Đơn giá", 120);
            //grdSanPham.AddColumnText("rThanhTien", "Thành tiền", 120);
            grdSanPham.AddColumnText("sCauHinhKyThuat", "Cấu hình kỹ thuật", 150);
            grdSanPham.AddColumnText("sXuatXu", "Xuất xứ", 150);
            grdSanPham.AddColumnText("iNamSX", "Năm sản xuất", 80);
            grdSanPham.AddColumnText("iThoiGianBaoHanh", "Thời gian BH", toolTip: "Thời gian bảo hành", 80);
            col = grdSanPham.AddColumnText("iDonViThoiGianBaoHanh", "Đơn vị t.gian BH", toolTip: "Đơn vị thời gian bảo hành", 80);
            col.EnumName = "iDonViThoiGianBaoHanh";
            grdSanPham.AddColumnText("dHanBaoHanhDen", "Hạn bảo hành", 80);
            grdSanPham.AddColumnText("sGhiChu", "Ghi chú", 200);

            //PhuKien

            grdPhuKienDetail.TableName = "Phieu_NhapCaiDatSanPham_CT_PhuKien";
            grdPhuKienDetail.TableName = "View_Phieu_NhapCaiDatSanPham_CT_PhuKien";
            grdPhuKienDetail.KeyName = "Id";
            var colPhuKien = grdPhuKienDetail.AddColumnText("sDM_PhuKien_Id_Ten", "Tên phụ kiện", 180, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);

            colPhuKien = grdPhuKienDetail.AddColumnText("sDM_DonViTinh_Id_Ten", "Đơn vị tính", 150);

            //grdPhuKienDetail.AddColumnText("rSoLuong", "Số lượng", 150);
            //grdPhuKienDetail.AddColumnText("rDonGia", "Đơn giá", 150);
            //grdPhuKienDetail.AddColumnText("rThanhTien", "Thành tiền", 150);
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

        /// <summary>
        /// Kiểm tra xem người dùng có quyền thực hiện chức năng duyệt và từ chối duyệt không
        /// </summary>
        /// <returns>=true cho phép thực hiện hành động, ngược lại thì không</returns>
        private bool CheckPermissionAproveOrReject(MT.Data.iTrangThaiDuyetPXCĐSP iTrangThai)
        {
            var datas = gridMaster.GetListRecordByRowsSelected<MT.Data.BO.Phieu_NhapCaiDatSanPham>();

            if (datas == null || datas.Count == 0)
            {
                MMessage.ShowWarning("Bạn phải chọn ít nhất 1 phiếu xuất.");
                return false;
            }
            string msg = "Phê duyệt";
            if (iTrangThai == MT.Data.iTrangThaiDuyetPXCĐSP.TuChoiDuyet)
            {
                msg = "Từ chối";
            }

            foreach (var item in datas)
            {
                //Kiểm tra người duyệt chính là người đăng nhập thì mới được duyệt
                if (!item.sDM_CanBo_Id_NguoiDuyet.HasValue || MT.Library.SessionData.UserId != item.sDM_CanBo_Id_NguoiDuyet.Value)
                {
                    MMessage.ShowWarning($"Bạn không có quyền {msg} với phiếu xuất <{item.sMa}>.");
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
        /// <summary>
        /// Ẩn hiện các button trên toolbar
        /// </summary>
        /// <param name="mToolbar"></param>
        protected override void CustomSetEnableButtonOnToolbar(MToolbarList mToolbar, MBindingSource mBindingSource)
        {
            base.CustomSetEnableButtonOnToolbar(mToolbar, mBindingSource);

            var chucVus = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
             columns: "Id",
             where: $"Id='{MT.Library.SessionData.UserId}' and iDictionaryKey NOT IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong})",
             viewName: "View_DM_CanBo");

            if (mBindingSource == null || mBindingSource.Count == 0 || (chucVus != null && chucVus.Count > 0))
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
        /// Bắt event trên toolbar click
        /// </summary>
        /// <param name="tag"></param>
        protected override void ProcessItemClick(int tag, object sender)
        {
            base.ProcessItemClick(tag, sender);
            switch (tag)
            {
                case (int)MCommandName.Approve:

                    if (CheckPermissionAproveOrReject(MT.Data.iTrangThaiDuyetPXCĐSP.DongYDuyet))
                    {
                        var datasApprove = gridMaster.GetListRecordByRowsSelected<MT.Data.BO.Phieu_NhapCaiDatSanPham>();
                        if (datasApprove.Any(m => m.iTrangThaiDuyet == (int)MT.Data.iTrangThaiDuyetPXCĐSP.DongYDuyet))
                        {
                            string strMaApproves = string.Join(", ", datasApprove.FindAll(m => m.iTrangThaiDuyet == (int)MT.Data.iTrangThaiDuyetPXCĐSP.DongYDuyet).Select(m => m.sMa));
                            MMessage.ShowWarning($"Các kế hoạch nhập mới <{strMaApproves}> đã được duyệt. Bạn vui lòng chọn kế hoạch khác.");
                            return;
                        }

                        var frmPhieuNhapSanPhamMoi_PheDuyet = new frmPhieu_NhapCaiDatSanPham_PheDuyet(this.RefreshData, (int)MT.Data.iTrangThaiDuyetPXCĐSP.DongYDuyet, datasApprove);
                        frmPhieuNhapSanPhamMoi_PheDuyet.ShowDialog();
                        frmPhieuNhapSanPhamMoi_PheDuyet.Dispose();
                    }
                    break;

                case (int)MCommandName.Reject:
                    if (CheckPermissionAproveOrReject(MT.Data.iTrangThaiDuyetPXCĐSP.TuChoiDuyet))
                    {
                        var datasReject = gridMaster.GetListRecordByRowsSelected<MT.Data.BO.Phieu_NhapCaiDatSanPham>();
                        if (datasReject.Any(m => m.iTrangThaiDuyet == (int)MT.Data.iTrangThaiDuyetPNM.TuChoiDuyet))
                        {
                            string strMaRejects = string.Join(", ", datasReject.FindAll(m => m.iTrangThaiDuyet == (int)MT.Data.iTrangThaiDuyetPNM.TuChoiDuyet).Select(m => m.sMa));
                            MMessage.ShowWarning($"Các phiếu nhập mới <{strMaRejects}> đã bị từ chối. Bạn vui lòng chọn phiếu nhập khác.");
                            return;
                        }
                        var frmKH_NhapSanPhamMoi_TuChoi = new frmPhieu_NhapCaiDatSanPham_PheDuyet(this.RefreshData, (int)MT.Data.iTrangThaiDuyetPXCĐSP.TuChoiDuyet, datasReject);
                        frmKH_NhapSanPhamMoi_TuChoi.ShowDialog();
                        frmKH_NhapSanPhamMoi_TuChoi.Dispose();
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

            if (gridControl.TableName == "Phieu_NhapCaiDatSanPham_CT")
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

                PagingList.SetWhere($@" dNgayPhieu_Nhap BETWEEN '{drKyBaoCao.FromDate.Value.StartDate()}'
                                    AND '{drKyBaoCao.ToDate.Value.EndDate()}'
                                    AND (iLoai={cboTCNhap.GetValue()} OR {cboTCNhap.GetValue()}<=-1) ");
                RefreshData();
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
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

        #region"Event"

        private void frmPhieu_NhapCaiDatSanPham_Load(object sender, EventArgs e)
        {
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
                e.Result = DBContext.GetRep<Phieu_NhapCaiDatSanPham_CTRepository>().GetDetailsByMasterID2("View_Phieu_NhapCaiDatSanPham_CT_PhuKien",
                        "Phieu_NhapCaiDatSanPham_CT_PhuKien", e.Argument);
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

        private void cboTCXuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isControlInitCompleted)
                LoadMasterData(sender, e);
        }

        #endregion
    }
}