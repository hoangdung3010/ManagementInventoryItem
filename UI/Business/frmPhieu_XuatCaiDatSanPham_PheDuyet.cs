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
    public partial class frmPhieu_XuatCaiDatSanPham_PheDuyet : FormUI.FormUIBase
    {
        IList phieu_XuatCaiDatSanPhams;

        int iTrangThai;

        Action callback;
        public frmPhieu_XuatCaiDatSanPham_PheDuyet(Action callback, int iTrangThai, 
            IList phieu_XuatCaiDatSanPhams)
        {
            InitializeComponent();
            this.phieu_XuatCaiDatSanPhams = phieu_XuatCaiDatSanPhams;
            this.iTrangThai = iTrangThai;
            cboiTrangThaiDuyet.EnumData = "iTrangThaiDuyetKHNM";
            cboiTrangThaiDuyet.SetValue((int)this.iTrangThai);
            cboiTrangThaiDuyet.SetReadOnly(true);
            this.callback = callback;
            if (this.phieu_XuatCaiDatSanPhams.Count == 1)
            {
                txtsLyDoDuyet.EditValue = this.phieu_XuatCaiDatSanPhams[0].GetValue<string>("sLyDoXetDuyet");
            }

            if (iTrangThai == (int)MT.Data.iTrangThaiDuyetPXCĐSP.DongYDuyet)
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
            grdPhieuXuatCD.IsHideActionAdd = true;
            var grd = grdPhieuXuatCD.GrdDetail;
            grd.IsEditable = false;

            grd.TableName = "Phieu_XuatCaiDatSanPham";
            grd.ViewName = "View_Phieu_XuatCaiDatSanPham";
            grd.AddColumnText("sMa", "Số phiếu", "Số phiếu", 120, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            grd.AddColumnText("dNgayPhieu_Xuat", "Ngày xuất", 100);
            grd.AddColumnText("sMa_KH", "Căn cứ số", "Căn cứ số", 120);
            grd.AddColumnText("sDM_DonVi_Id_Xuat_Ten", "Đơn vị nhập", "Đơn vị xuất", 180);
            grd.AddColumnText("sDM_DonVi_Id_Nhap_Ten", "Đơn vị nhập", "Đơn vị nhập", 180);
            grd.AddColumnText("sDM_CanBo_Id_NguoiLapPhieu_Ten", "Người lập", 150);
            grd.AddColumnText("sDM_CanBo_Id_NguoiGiao_Ten", "Người giao", 150);
            grd.AddColumnText("sDM_CanBo_Id_NguoiNhap_Ten", "Người nhập", 150);
            grd.AddColumnText("sGhiChu", "Ghi chú", 200);

            var colMaster = grd.AddColumnText("iLoai", "Tính chất xuất", 150,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);
            colMaster.EnumName = "iTCXuatCĐ";

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
                Phieu_XuatCaiDatSanPhamRepository phieu_XuatCaiDatSanPhamRep = DBContext.GetRep2<Phieu_XuatCaiDatSanPhamRepository>();

                List<MT.Data.BO.Phieu_XuatCaiDatSanPham> phieu_XuatCaiDatSanPhams = grdPhieuXuatCD.GrdDetail.GetAllData<MT.Data.BO.Phieu_XuatCaiDatSanPham>();
                if(phieu_XuatCaiDatSanPhams == null || phieu_XuatCaiDatSanPhams.Count == 0)
                {
                    MMessage.ShowWarning("Bạn phải chọn ít nhất 1 phiếu");
                    return;
                }
                phieu_XuatCaiDatSanPhamRep.SaveApproveOrReject(phieu_XuatCaiDatSanPhams,
                    (int)this.iTrangThai,Convert.ToString(txtsLyDoDuyet.EditValue));
                MTControl.MMessage.ShowInfor("Lưu thành công");
                if (this.callback != null)
                {
                    this.callback();
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

        private void frmPhieu_XuatCaiDatSanPham_PheDuyet_Shown(object sender, EventArgs e)
        {
            grdPhieuXuatCD.GrdDetail.LoadData(this.phieu_XuatCaiDatSanPhams);
        }
        #endregion


    }
}
