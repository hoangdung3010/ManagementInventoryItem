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
    public partial class frmPhieu_NhapSuaChuaSanPham_PheDuyet : FormUI.FormUIBase
    {
        IList phieu_NhapSuaChuaSanPhams;

        int iTrangThaiDuyet;

        Action callback;
        public frmPhieu_NhapSuaChuaSanPham_PheDuyet(Action callback, int iTrangThaiDuyet,
            IList phieu_NhapSuaChuaSanPhams)
        {
            InitializeComponent();
            this.phieu_NhapSuaChuaSanPhams = phieu_NhapSuaChuaSanPhams;
            this.iTrangThaiDuyet = iTrangThaiDuyet;
            cboiTrangThaiDuyet.EnumData = "iTrangThaiDuyetPNSC";
            cboiTrangThaiDuyet.SetValue((int)this.iTrangThaiDuyet);
            cboiTrangThaiDuyet.SetReadOnly(true);
            this.callback = callback;
            if (this.phieu_NhapSuaChuaSanPhams.Count == 1)
            {
                txtsLyDoDuyet.EditValue = this.phieu_NhapSuaChuaSanPhams[0].GetValue<string>("sLyDoXetDuyet");
            }

            if (iTrangThaiDuyet == (int)MT.Data.iTrangThaiDuyetPNSC.DongYDuyet)
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
            grdPhieuNhapSuaChua.IsHideActionAdd = true;
            var grd = grdPhieuNhapSuaChua.GrdDetail;
            grd.IsEditable = false;

            grd.TableName = "Phieu_NhapSuaChuaSanPham";
            grd.ViewName = "View_Phieu_NhapSuaChuaSanPham";

            grd.AddColumnText("sMa", "Số phiếu", "Số phiếu", 120, isFixWidth: true,
                    fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            grd.AddColumnText("sMa_PX", "Căn cứ số", "Căn cứ số", 120, isFixWidth: true,
                    fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            grd.AddColumnText("dNgayPhieu_Nhap", "Ngày lập phiếu", 100, isFixWidth: true,
                    fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            grd.AddColumnText("sDM_CanBo_Id_NguoiLapPhieu_Ten", "Người lập phiếu", 200);
            grd.AddColumnText("sDM_DonVi_Id_Xuat_Ten", "Đơn vị xuất", 250);
            grd.AddColumnText("sDM_DonVi_Id_Nhap_Ten", "Đơn vị nhận ", 250);

            grd.AddColumnText("sGhiChu", "Ghi chú", 280);

            var col = grd.AddColumnText("iLoai", "Tính chất nhập", 150,
              fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);
            col.EnumName = "iLoaiNhapSuaChua";

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
                Phieu_NhapSuaChuaSanPhamRepository kH_SuaChuaSanPhamRepository = DBContext.GetRep2<Phieu_NhapSuaChuaSanPhamRepository>();

                List<MT.Data.BO.Phieu_NhapSuaChuaSanPham> kH_SuaChuaSanPhams = grdPhieuNhapSuaChua.GrdDetail.GetAllData<MT.Data.BO.Phieu_NhapSuaChuaSanPham>();
                if (kH_SuaChuaSanPhams == null || kH_SuaChuaSanPhams.Count == 0)
                {
                    MMessage.ShowWarning("Bạn phải chọn ít nhất 1 phiếu");
                    return;
                }
                kH_SuaChuaSanPhamRepository.SaveApproveOrReject(kH_SuaChuaSanPhams,
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

        private void frmPhieu_NhapSuaChuaSanPham_PheDuyet_Shown(object sender, EventArgs e)
        {
            grdPhieuNhapSuaChua.GrdDetail.LoadData(this.phieu_NhapSuaChuaSanPhams);
        }
        #endregion


    }
}
