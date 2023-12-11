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
    public partial class frmPhieu_NhapSanPham_PheDuyet : FormUI.FormUIBase
    {
        IList ph_NhapSanPhams;

        int iTrangThaiDuyetKHNM;

        Action callback;
        public frmPhieu_NhapSanPham_PheDuyet(Action callback, int iTrangThaiDuyetKHNM,
            IList ph_NhapSanPhams)
        {
            InitializeComponent();
            this.ph_NhapSanPhams = ph_NhapSanPhams;
            this.iTrangThaiDuyetKHNM = iTrangThaiDuyetKHNM;
            cboiTrangThaiDuyet.EnumData = "iTrangThaiDuyetKHNM";
            cboiTrangThaiDuyet.SetValue((int)this.iTrangThaiDuyetKHNM);
            cboiTrangThaiDuyet.SetReadOnly(true);
            this.callback = callback;
            if (this.ph_NhapSanPhams.Count == 1)
            {
                txtsLyDoDuyet.EditValue = this.ph_NhapSanPhams[0].GetValue<string>("sLyDoXetDuyet");
            }

            if (iTrangThaiDuyetKHNM == (int)MT.Data.iTrangThaiDuyetPNM.DongYDuyet)
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
            grdKeHoachNhapMoi.IsHideActionAdd = true;
            var grd = grdKeHoachNhapMoi.GrdDetail;

            grd.TableName = "Phieu_NhapSanPham";
            grd.ViewName = "View_Phieu_NhapSanPham";
            grd.CustomModelFields = "iDonViThoiGianHieuLuc";
            grd.AddColumnText("sMa", "Số Phiếu", "Số phiếu", 120, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            grd.AddColumnText("sDM_DonVi_Id_Xuat_Ten", "Đơn vị xuất", "Đơn vị xuất", 180);
            grd.AddColumnText("sDM_DonVi_Id_Nhap_Ten", "Đơn vị nhập", "Đơn vị nhập", 180);
            grd.AddColumnText("sDM_CanBo_Id_NguoiLapPhieu_Ten", "Người lập", "Người lập", 150);
            grd.AddColumnText("dNgayPhieu_Nhap", "Ngày lập", 100);
            grd.AddColumnText("sDM_CanBo_Id_NguoiDuyet_Ten", "Người duyệt", 250);
            grd.AddColumnText("sGhiChu", "Ghi chú", 280);
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
                Phieu_NhapSanPhamRepository ph_NhapSanPhamRepository = DBContext.GetRep2<Phieu_NhapSanPhamRepository>();

                List<MT.Data.BO.Phieu_NhapSanPham> ph_NhapSanPhams = grdKeHoachNhapMoi.GrdDetail.GetAllData<MT.Data.BO.Phieu_NhapSanPham>();
                if (ph_NhapSanPhams == null || ph_NhapSanPhams.Count == 0)
                {
                    MMessage.ShowWarning("Bạn phải chọn ít nhất 1 phiếu");
                    return;
                }
                ph_NhapSanPhamRepository.SaveApproveOrReject(ph_NhapSanPhams,
                    (int)this.iTrangThaiDuyetKHNM, Convert.ToString(txtsLyDoDuyet.EditValue));
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

        private void frmPhieu_NhapSanPham_PheDuyet_Load(object sender, EventArgs e)
        {
            grdKeHoachNhapMoi.GrdDetail.LoadData(this.ph_NhapSanPhams);
        }
        #endregion


    }
}
