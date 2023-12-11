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
    public partial class frmPhieu_XuatMuonTra_PheDuyet : FormUI.FormUIBase
    {
        IList ph_XuatMuonTras;

        int iTrangThaiDuyetKHNM;

        Action callback;
        public frmPhieu_XuatMuonTra_PheDuyet(Action callback, int iTrangThaiDuyetKHNM, 
            IList ph_XuatMuonTras)
        {
            InitializeComponent();
            this.ph_XuatMuonTras = ph_XuatMuonTras;
            this.iTrangThaiDuyetKHNM = iTrangThaiDuyetKHNM;
            cboiTrangThaiDuyet.EnumData = "iTrangThaiDuyetKHNM";
            cboiTrangThaiDuyet.SetValue((int)this.iTrangThaiDuyetKHNM);
            cboiTrangThaiDuyet.SetReadOnly(true);
            this.callback = callback;
            if (this.ph_XuatMuonTras.Count == 1)
            {
                txtsLyDoDuyet.EditValue = this.ph_XuatMuonTras[0].GetValue<string>("sLyDoXetDuyet");
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
           
            grd.TableName = "Phieu_XuatMuonTra";
            grd.ViewName = "View_Phieu_XuatMuonTra";
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
                Phieu_XuatMuonTraRepository ph_XuatMuonTraRepository = DBContext.GetRep2<Phieu_XuatMuonTraRepository>();

                List<MT.Data.BO.Phieu_XuatMuonTra> ph_XuatMuonTras = grdKeHoachNhapMoi.GrdDetail.GetAllData<MT.Data.BO.Phieu_XuatMuonTra>();
                if(ph_XuatMuonTras==null || ph_XuatMuonTras.Count == 0)
                {
                    MMessage.ShowWarning("Bạn phải chọn ít nhất 1 phiếu");
                    return;
                }
                ph_XuatMuonTraRepository.SaveApproveOrReject(ph_XuatMuonTras,
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
                CommonFnUI.ShowError(ex,"Phê duyệt phiếu");
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

        private void frmPhieu_XuatMuonTra_PheDuyet_Load(object sender, EventArgs e)
        {
            grdKeHoachNhapMoi.GrdDetail.LoadData(this.ph_XuatMuonTras);
        }
        #endregion


    }
}
