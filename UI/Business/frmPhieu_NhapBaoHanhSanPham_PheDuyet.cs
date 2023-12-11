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
    public partial class frmPhieu_NhapBaoHanhSanPham_PheDuyet : FormUI.FormUIBase
    {
        IList phieu_NhapBaoHanhSanPhams;

        int iTrangThaiDuyet;

        Action callback;
        public frmPhieu_NhapBaoHanhSanPham_PheDuyet(Action callback, int iTrangThaiDuyet,
            List<MT.Data.BO.Phieu_NhapBaoHanhSanPham> phieu_NhapBaoHanhSanPhams)
        {
            InitializeComponent();
            this.phieu_NhapBaoHanhSanPhams = phieu_NhapBaoHanhSanPhams;
            this.iTrangThaiDuyet = iTrangThaiDuyet;
            cboiTrangThaiDuyet.EnumData = "iTrangThaiDuyetPNBH";
            cboiTrangThaiDuyet.SetValue((int)this.iTrangThaiDuyet);
            cboiTrangThaiDuyet.SetReadOnly(true);
            this.callback = callback;
            if (this.phieu_NhapBaoHanhSanPhams.Count == 1)
            {
                txtsLyDoDuyet.EditValue = this.phieu_NhapBaoHanhSanPhams[0].GetValue<string>("sLyDoXetDuyet");
            }

            if (iTrangThaiDuyet == (int)MT.Data.iTrangThaiDuyetPNBH.DongYDuyet)
            {
                lblTitleFormDetail.Text = "Phê duyệt phiếu";
            }
            else
            {
                lblTitleFormDetail.Text = "Từ chối phiếu";
            }


            InitGrid();
        }
        /// <summary>
        /// Khởi tạo các cột trên grid
        /// </summary>
        /// Create by: dvthang:07.03.2017
        private void InitGrid()
        {
            grdPhieuNhapBaoHanh.IsHideActionAdd = true;
            var grd = grdPhieuNhapBaoHanh.GrdDetail;
            grd.IsEditable = false;

            grd.TableName = "Phieu_NhapBaoHanhSanPham";
            grd.ViewName = "View_Phieu_NhapBaoHanhSanPham";
            grd.CustomModelFields = "iLoai";

            grd.AddColumnText("sMa", "Số PN", "Số phiếu", 120, isFixWidth: true,
                    fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            grd.AddColumnText("sMa_PX", "Căn cứ số", "", 120, isFixWidth: true,
                    fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            grd.AddColumnText("dNgayPhieu_Nhap", "Ngày lập phiếu", 100, isFixWidth: true,
                    fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            grd.AddColumnText("sDM_CanBo_Id_NguoiLapPhieu_Ten", "Người lập phiếu", 200);
            grd.AddColumnText("sDM_DonVi_Id_Xuat_Ten", "Đơn vị xuất", 250);
            grd.AddColumnText("sDM_DonVi_Id_Nhap_Ten", "Đơn vị nhận", 250);

            grd.AddColumnText("sGhiChu", "Ghi chú", 280);

            var col = grd.AddColumnText("iLoai", "Tính chất nhập", 150,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);
            col.EnumName = "iLoaiNhapBaoHanh";

            grd.SetMutiSelectRows(true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect);
        }

        #region"Event"
        /// <summary>
        /// Lưu thông tin phê duyệt kế hoạch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Phieu_NhapBaoHanhSanPhamRepository kH_BaoHanhSanPhamRepository = DBContext.GetRep2<Phieu_NhapBaoHanhSanPhamRepository>();

                List<MT.Data.BO.Phieu_NhapBaoHanhSanPham> kH_BaoHanhSanPhams = grdPhieuNhapBaoHanh.GrdDetail.GetAllData<MT.Data.BO.Phieu_NhapBaoHanhSanPham>();
                if (kH_BaoHanhSanPhams == null || kH_BaoHanhSanPhams.Count == 0)
                {
                    MMessage.ShowWarning("Bạn phải chọn ít nhất 1 phiếu");
                    return;
                }
                kH_BaoHanhSanPhamRepository.SaveApproveOrReject(kH_BaoHanhSanPhams,
                    (int)this.iTrangThaiDuyet, Convert.ToString(txtsLyDoDuyet.EditValue));
                MTControl.MMessage.ShowInfor("Lưu thành công");
                if (this.callback != null)
                {
                    this.callback();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                CommonFnUI.ShowError(ex, "Phê duyệt phiếu");
            }
        }

        /// <summary>
        /// Đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhieu_NhapBaoHanhSanPham_PheDuyet_Shown(object sender, EventArgs e)
        {
            grdPhieuNhapBaoHanh.GrdDetail.LoadData(this.phieu_NhapBaoHanhSanPhams);
        }
        #endregion


    }
}
