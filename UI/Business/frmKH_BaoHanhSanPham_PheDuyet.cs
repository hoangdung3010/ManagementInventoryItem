using DevExpress.XtraGrid.Views.Base;
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
    public partial class frmKH_BaoHanhSanPham_PheDuyet : FormUI.FormUIBase
    {
        IList kH_BaoHanhSanPhams;

        int iTrangThaiDuyetKH;

        Action callback;
        public frmKH_BaoHanhSanPham_PheDuyet(Action callback, int iTrangThaiDuyetKH,
            IList kH_BaoHanhSanPhams)
        {
            InitializeComponent();
            this.kH_BaoHanhSanPhams = kH_BaoHanhSanPhams;
            this.iTrangThaiDuyetKH = iTrangThaiDuyetKH;
            cboiTrangThaiDuyet.EnumData = "iTrangThaiDuyetKHNM";
            cboiTrangThaiDuyet.SetValue((int)this.iTrangThaiDuyetKH);
            cboiTrangThaiDuyet.SetReadOnly(true);
            this.callback = callback;
            if (this.kH_BaoHanhSanPhams.Count == 1)
            {
                txtsLyDoDuyet.EditValue = this.kH_BaoHanhSanPhams[0].GetValue<string>("sLyDoXetDuyet");
            }

            if (iTrangThaiDuyetKH == (int)MT.Data.iTrangThaiDuyetKHNM.DongYDuyet)
            {
                lblTitleFormDetail.Text = "Phê duyệt kế hoạch";
            }
            else
            {
                lblTitleFormDetail.Text = "Từ chối kế hoạch";
            }


            InitGrid();
        }
        /// <summary>
        /// Khởi tạo các cột trên grid
        /// </summary>
        /// Create by: dvthang:07.03.2017
        private void InitGrid()
        {
            grdKeHoachBaoHanh.IsHideActionAdd = true;
            var grd = grdKeHoachBaoHanh.GrdDetail;
            grd.IsEditable = false;

            grd.TableName = "KH_BaoHanhSanPham";
            grd.ViewName = "View_KH_BaoHanhSanPham";

            grd.CustomModelFields = "iDonViThoiGianHieuLuc";
            grd.AddColumnText("sMa", "Số KH", "Số kế hoạch", 120, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            grd.AddColumnText("dNgayKeHoach", "Ngày lập", 100, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            grd.AddColumnText("sDM_DonVi_Id_DonViXayDungKH_Ten", "Đơn vị lập", 250);
            grd.AddColumnText("sDM_CanBo_Id_NguoiLapKH_Ten", "Người lập", 200);
            grd.AddColumnText("sDM_DonVi_Id_DonViXuat_Ten", "Đơn vị xuất", 250);
            grd.AddColumnText("sDM_DonVi_Id_DonViNhap_Ten", "Đơn vị nhận", 250);
            grd.AddColumnText("sDM_CanBo_Id_ThuTruongDonVi_Ten", "Thủ trưởng đơn vị", 200);
            grd.AddColumnText("iThoiGianHieuLuc", "Thời gian hiệu lực", 80);
            var col = grd.AddColumnText("iDonViThoiGianHieuLuc", "Đơn vị t.gian hiệu lực", 80);
            col.EnumName = "iDonViThoiGianHieuLuc";
            grd.AddColumnText("sGhiChu", "Ghi chú", 280);

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
                KH_BaoHanhSanPhamRepository kH_BaoHanhSanPhamRepository = DBContext.GetRep2<KH_BaoHanhSanPhamRepository>();

                List<MT.Data.BO.KH_BaoHanhSanPham> kH_BaoHanhSanPhams = grdKeHoachBaoHanh.GrdDetail.GetAllData<MT.Data.BO.KH_BaoHanhSanPham>();
                if (kH_BaoHanhSanPhams == null || kH_BaoHanhSanPhams.Count == 0)
                {
                    MMessage.ShowWarning("Bạn phải chọn ít nhất 1 kế hoạch");
                    return;
                }
                kH_BaoHanhSanPhamRepository.SaveApproveOrReject(kH_BaoHanhSanPhams,
                    (int)this.iTrangThaiDuyetKH, Convert.ToString(txtsLyDoDuyet.EditValue));
                MTControl.MMessage.ShowInfor("Lưu thành công");
                if (this.callback != null)
                {
                    this.callback();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                CommonFnUI.ShowError(ex, "Phê duyệt kế hoạch");
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

        private void frmKH_BaoHanhSanPham_PheDuyet_Shown(object sender, EventArgs e)
        {
            grdKeHoachBaoHanh.GrdDetail.LoadData(this.kH_BaoHanhSanPhams);
        }
        #endregion


    }
}
