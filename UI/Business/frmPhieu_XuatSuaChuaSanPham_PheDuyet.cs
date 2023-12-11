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
    public partial class frmPhieu_XuatSuaChuaSanPham_PheDuyet : FormUI.FormUIBase
    {
        IList phieu_XuatSuaChuaSanPhams;

        int iTrangThaiDuyet;

        Action callback;
        public frmPhieu_XuatSuaChuaSanPham_PheDuyet(Action callback, int iTrangThaiDuyet,
            IList phieu_XuatSuaChuaSanPhams)
        {
            InitializeComponent();
            this.phieu_XuatSuaChuaSanPhams = phieu_XuatSuaChuaSanPhams;
            this.iTrangThaiDuyet = iTrangThaiDuyet;
            cboiTrangThaiDuyet.EnumData = "iTrangThaiDuyetPXSC";
            cboiTrangThaiDuyet.SetValue((int)this.iTrangThaiDuyet);
            cboiTrangThaiDuyet.SetReadOnly(true);
            this.callback = callback;
            if (this.phieu_XuatSuaChuaSanPhams.Count == 1)
            {
                txtsLyDoDuyet.EditValue = this.phieu_XuatSuaChuaSanPhams[0].GetValue<string>("sLyDoXetDuyet");
            }

            if (iTrangThaiDuyet == (int)MT.Data.iTrangThaiDuyetPXSC.DongYDuyet)
            {
                lblTitleFormDetail.Text = "Phê duyệt phiếu";
            }
            else
            {
                lblTitleFormDetail.Text = "Từ chối phiếu xuất";
            }


            InitGrid();
        }
        /// <summary>
        /// Khởi tạo các cột trên grid
        /// </summary>
        /// Create by: dvthang:07.03.2017
        private void InitGrid()
        {

            grdPhieuXuatSuaChua.IsHideActionAdd = true;
            var grd = grdPhieuXuatSuaChua.GrdDetail;
            grd.IsEditable = false;

            grd.TableName = "Phieu_XuatSuaChuaSanPham";
            grd.ViewName = "View_Phieu_XuatSuaChuaSanPham";

            grd.AddColumnText("sMa", "Số phiếu", "Số phiếu", 120, isFixWidth: true,
                    fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            grd.AddColumnText("sMa_KH", "Căn cứ số", "Căn cứ số", 120, isFixWidth: true);
            grd.AddColumnText("dNgayPhieu_Xuat", "Ngày lập phiếu", 100, isFixWidth: true);
            grd.AddColumnText("sDM_CanBo_Id_NguoiLapPhieu_Ten", "Người lập phiếu", 200);
            grd.AddColumnText("sDM_DonVi_Id_Xuat_Ten", "Đơn vị xuất", 250);
            grd.AddColumnText("sDM_DonVi_Id_Nhap_Ten", "Đơn vị nhận", 250);

            grd.AddColumnText("sGhiChu", "Ghi chú", 280);

            grd.AddColumnText("iLoai", "Tính chất xuất", 150,enumName: "iLoaiXuatSuaChua",fixedStyle:DevExpress.XtraGrid.Columns.FixedStyle.Right);

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
                Phieu_XuatSuaChuaSanPhamRepository kH_SuaChuaSanPhamRepository = DBContext.GetRep2<Phieu_XuatSuaChuaSanPhamRepository>();

                List<MT.Data.BO.Phieu_XuatSuaChuaSanPham> kH_SuaChuaSanPhams = grdPhieuXuatSuaChua.GrdDetail.GetAllData<MT.Data.BO.Phieu_XuatSuaChuaSanPham>();
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

        private void frmPhieu_XuatSuaChuaSanPham_PheDuyet_Shown(object sender, EventArgs e)
        {
            grdPhieuXuatSuaChua.GrdDetail.LoadData(this.phieu_XuatSuaChuaSanPhams);
        }
        #endregion

    }
}
