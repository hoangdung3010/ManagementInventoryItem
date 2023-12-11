using MT.Data.Rep;
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
using MT.Library;
using MT.Library.Extensions;

namespace FormUI
{
    public partial class frmPhieu_NhapSanPhamMoi_PheDuyet : FormUI.FormUIBase
    {
        IList phieu_NhapSanPhamMois;

        MT.Data.iTrangThaiDuyetPNM iTrangThaiDuyetKHNM;
        Action callBack;
        public frmPhieu_NhapSanPhamMoi_PheDuyet(Action callBack, int iTrangThaiDuyetKHNM, 
            IList phieu_NhapSanPhamMois)
        {
            InitializeComponent();
            this.phieu_NhapSanPhamMois = phieu_NhapSanPhamMois;
            this.iTrangThaiDuyetKHNM = (MT.Data.iTrangThaiDuyetPNM)iTrangThaiDuyetKHNM;
            cboiTrangThaiDuyet.EnumData = "iTrangThaiDuyetKHNM";
            cboiTrangThaiDuyet.SetValue((int)this.iTrangThaiDuyetKHNM);
            cboiTrangThaiDuyet.SetReadOnly(true);
            this.callBack = callBack;
            if (this.phieu_NhapSanPhamMois.Count == 1)
            {
                txtsLyDoDuyet.EditValue = this.phieu_NhapSanPhamMois[0].GetValue<string>("sLyDoXetDuyet");
            }

            if (iTrangThaiDuyetKHNM == (int)MT.Data.iTrangThaiDuyetPNM.DongYDuyet)
            {
                lblTitleFormDetail.Text = "Phê duyệt phiếu";
            }
            else
            {
                lblTitleFormDetail.Text = "Từ chối phiếu";
            }
            

            InitGrid();
        }
        /// <summary>
        /// Khởi tạo các cột trên grid
        /// </summary>
        /// Create by: dvthang:07.03.2017
        private void InitGrid()
        {
            grdPhieuNhapMoi.IsHideActionAdd = true;
            var grd = grdPhieuNhapMoi.GrdDetail;
            grd.TableName = "Phieu_NhapSanPhamMoi";
            grd.ViewName = "View_Phieu_NhapSanPhamMoi";
            grd.AddColumnText("sMa", "Số phiếu", "Số phiếu", 120, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            grd.AddColumnText("dNgayPhieu_NhapSanPhamMoi", "Ngày phiếu", 100);
            grd.AddColumnText("sMa_KH", "Số KH", "Số kế hoạch", 120);
            grd.AddColumnText("sDM_DonVi_Id_Nhap_Ten", "Đơn vị nhập", "Đơn vị nhập", 180);
            grd.AddColumnText("sDM_CanBo_Id_NguoiNhap_Ten", "Người nhập", "Người nhập", 150);
            grd.AddColumnText("sDM_CanBo_Id_NguoiLapPhieu_Ten", "Người lập", 150);
            grd.AddColumnText("sDM_CanBo_Id_NguoiDuyet_Ten", "Người duyệt", "Người duyệt", 180);
            var col=grd.AddColumnText("iNhapVeKho", "Hình thức nhập", "Hình thức nhập", 180);
            col.EnumName = "iNhapVeKho";
            grd.AddColumnText("sGhiChu", "Ghi chú", 200);
            grd.AddColumnText("rThanhTien", "Tổng tiền", 150, fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);
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
                Phieu_NhapSanPhamMoiRepository phieu_NhapSanPhamMoiRepository = DBContext.GetRep2<Phieu_NhapSanPhamMoiRepository>();

                List<MT.Data.BO.Phieu_NhapSanPhamMoi> phieu_NhapSanPhamMois = grdPhieuNhapMoi.GrdDetail.GetAllData<MT.Data.BO.Phieu_NhapSanPhamMoi>();
                if(phieu_NhapSanPhamMois == null || phieu_NhapSanPhamMois.Count == 0)
                {
                    MMessage.ShowWarning("Bạn phải chọn ít nhất 1 phiếu");
                    return;
                }
                phieu_NhapSanPhamMoiRepository.SaveApproveOrReject(phieu_NhapSanPhamMois,
                    (int)this.iTrangThaiDuyetKHNM,Convert.ToString(txtsLyDoDuyet.EditValue));
                MTControl.MMessage.ShowInfor("Lưu thành công");
                if (callBack!=null)
                {
                    callBack();
                }
               
                this.Close();
            }
            catch (Exception ex)
            {
                CommonFnUI.ShowError(ex,"Phê duyệt phiếu");
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

        private void frmPhieu_NhapSanPhamMoi_PheDuyet_Load(object sender, EventArgs e)
        {
            grdPhieuNhapMoi.GrdDetail.LoadData(this.phieu_NhapSanPhamMois);
        }
        #endregion


    }
}
