using MT.Data.Rep;
using MTControl;
using System;
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
    public partial class frmPhieu_XuatTHTH_PheDuyet : FormUI.FormUIBase
    {
        List<MT.Data.BO.Phieu_XuatTHTH> ph_XuatTHTHs;

        MT.Data.iTrangThaiDuyetPNM iTrangThaiDuyetKHNM;

        MFormList frmParent;
        public frmPhieu_XuatTHTH_PheDuyet(MFormList frmParent, MT.Data.iTrangThaiDuyetPNM iTrangThaiDuyetKHNM,
            List<MT.Data.BO.Phieu_XuatTHTH> ph_XuatTHTHs)
        {
            InitializeComponent();
            this.ph_XuatTHTHs = ph_XuatTHTHs;
            this.iTrangThaiDuyetKHNM = iTrangThaiDuyetKHNM;
            cboiTrangThaiDuyet.EnumData = "iTrangThaiDuyetKHNM";
            cboiTrangThaiDuyet.SetValue((int)this.iTrangThaiDuyetKHNM);
            cboiTrangThaiDuyet.SetReadOnly(true);
            this.frmParent = frmParent;
            if (this.ph_XuatTHTHs.Count == 1)
            {
                txtsLyDoDuyet.EditValue = this.ph_XuatTHTHs.FirstOrDefault().sLyDoXetDuyet;
            }

            if (iTrangThaiDuyetKHNM == MT.Data.iTrangThaiDuyetPNM.DongYDuyet)
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

            grd.TableName = "Phieu_XuatTHTH";
            grd.ViewName = "View_Phieu_XuatTHTH";
            grd.CustomModelFields = "iDonViThoiGianHieuLuc";
            grd.AddColumnText("sMa", "Số Phiếu", "Số phiếu", 120, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            grd.AddColumnText("sDM_DonVi_Id_Xuat_Ten", "Đơn vị xuất", "Đơn vị xuất", 180);
            grd.AddColumnText("sDM_DonVi_Id_Nhap_Ten", "Đơn vị nhập", "Đơn vị nhập", 180);
            grd.AddColumnText("sDM_CanBo_Id_NguoiLapPhieu_Ten", "Người lập", "Người lập", 150);
            grd.AddColumnText("dNgayPhieu_Xuat", "Ngày lập", 100);
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
                Phieu_XuatTHTHRepository ph_XuatTHTHRepository = DBContext.GetRep2<Phieu_XuatTHTHRepository>();

                List<MT.Data.BO.Phieu_XuatTHTH> ph_XuatTHTHs = grdKeHoachNhapMoi.GrdDetail.GetAllData<MT.Data.BO.Phieu_XuatTHTH>();
                if (ph_XuatTHTHs == null || ph_XuatTHTHs.Count == 0)
                {
                    MMessage.ShowWarning("Bạn phải chọn ít nhất 1 phiếu");
                    return;
                }
                ph_XuatTHTHRepository.SaveApproveOrReject(ph_XuatTHTHs,
                    (int)this.iTrangThaiDuyetKHNM, Convert.ToString(txtsLyDoDuyet.EditValue));
                MTControl.MMessage.ShowInfor("Lưu thành công");
                this.frmParent.RefreshData();
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

        private void frmPhieu_XuatTHTH_PheDuyet_Load(object sender, EventArgs e)
        {
            grdKeHoachNhapMoi.GrdDetail.LoadData(this.ph_XuatTHTHs);
        }
        #endregion


    }
}
