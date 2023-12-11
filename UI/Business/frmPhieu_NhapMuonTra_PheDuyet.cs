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
    public partial class frmPhieu_NhapMuonTra_PheDuyet : FormUI.FormUIBase
    {
        IList ph_NhapMuonTras;

        int iTrangThaiDuyetKHNM;

        Action callback;
        public frmPhieu_NhapMuonTra_PheDuyet(Action callback, int iTrangThaiDuyetKHNM, 
            IList ph_NhapMuonTras)
        {
            InitializeComponent();
            this.ph_NhapMuonTras = ph_NhapMuonTras;
            this.iTrangThaiDuyetKHNM = iTrangThaiDuyetKHNM;
            cboiTrangThaiDuyet.EnumData = "iTrangThaiDuyetKHNM";
            cboiTrangThaiDuyet.SetValue((int)this.iTrangThaiDuyetKHNM);
            cboiTrangThaiDuyet.SetReadOnly(true);
            this.callback = callback;
            if (this.ph_NhapMuonTras.Count == 1)
            {
                txtsLyDoDuyet.EditValue = this.ph_NhapMuonTras[0].GetValue<string>("sLyDoXetDuyet");
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
           
            grd.TableName = "Phieu_NhapMuonTra";
            grd.ViewName = "View_Phieu_NhapMuonTra";
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
                Phieu_NhapMuonTraRepository ph_NhapMuonTraRepository = DBContext.GetRep2<Phieu_NhapMuonTraRepository>();

                List<MT.Data.BO.Phieu_NhapMuonTra> ph_NhapMuonTras = grdKeHoachNhapMoi.GrdDetail.GetAllData<MT.Data.BO.Phieu_NhapMuonTra>();
                if(ph_NhapMuonTras==null || ph_NhapMuonTras.Count == 0)
                {
                    MMessage.ShowWarning("Bạn phải chọn ít nhất 1 phiếu");
                    return;
                }
                ph_NhapMuonTraRepository.SaveApproveOrReject(ph_NhapMuonTras,
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

        private void frmPhieu_NhapMuonTra_PheDuyet_Load(object sender, EventArgs e)
        {
            grdKeHoachNhapMoi.GrdDetail.LoadData(this.ph_NhapMuonTras);
        }
        #endregion


    }
}
