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
    public partial class frmKH_CaiDatSanPham_PheDuyet : FormUI.FormUIBase
    {
        IList khCaiDatSanPhams;

        int iTrangThaiDuyetKHCĐSP;

        Action callback;
        public frmKH_CaiDatSanPham_PheDuyet(Action callback, int iTrangThaiDuyetKHCĐSP, 
            List<MT.Data.BO.KH_CaiDatSanPham> KH_CaiDatSanPhams)
        {
            InitializeComponent();
            this.khCaiDatSanPhams = KH_CaiDatSanPhams;
            this.iTrangThaiDuyetKHCĐSP = iTrangThaiDuyetKHCĐSP;
            cboiTrangThaiDuyet.EnumData = "iTrangThaiDuyetKHCĐSP";
            cboiTrangThaiDuyet.SetValue((int)this.iTrangThaiDuyetKHCĐSP);
            cboiTrangThaiDuyet.SetReadOnly(true);
            this.callback = callback;
            if (this.khCaiDatSanPhams.Count == 1)
            {
                txtsLyDoDuyet.EditValue = this.khCaiDatSanPhams[0].GetValue<string>("sLyDoXetDuyet");
            }

            if (iTrangThaiDuyetKHCĐSP == (int)MT.Data.iTrangThaiDuyetKHCĐSP.DongYDuyet)
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
            grdKeHoachNhapMoi.IsHideActionAdd = true;
            var grd = grdKeHoachNhapMoi.GrdDetail;
            grd.IsEditable = false;
           
            grd.TableName = "KH_CaiDatSanPham";
            grd.ViewName = "View_KH_CaiDatSanPham";
            grd.CustomModelFields = "iDonViThoiGianHieuLuc";
            grd.AddColumnText("sMa", "Số KH", "Số kế hoạch", 120, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            grd.AddColumnText("dNgayKeHoach", "Ngày lập", 80,isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);

            grd.AddColumnText("sDM_DonVi_Id_DonViXayDungKH_Ten", "Đơn vị lập", "Đơn vị lập", 180);
            grd.AddColumnText("sDM_CanBo_Id_NguoiLapKH_Ten", "Người lập", "Người lập", 150);
            grd.AddColumnText("sDM_DonVi_Id_DonViXuat_Ten", "Đơn vị xuất", 180);
            grd.AddColumnText("sDM_DonVi_Id_DonViNhap_Ten", "Đơn vị nhập", 180);
            grd.AddColumnText("sDM_CanBo_Id_ThuTruongDonVi_Ten", "Thủ trưởng đơn vị", 180);
            grd.AddColumnText("iThoiGianHieuLuc", "Thời gian hiệu lực", 80);
            var col = grd.AddColumnText("iDonViThoiGianHieuLuc", "Đơn vị t.gian hiệu lực", 80);
            col.EnumName = "iDonViThoiGianHieuLuc";
            grd.AddColumnText("sGhiChu", "Ghi chú", 200);

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
                KH_CaiDatSanPhamRepository KH_CaiDatSanPhamRepository = DBContext.GetRep2<KH_CaiDatSanPhamRepository>();

                List<MT.Data.BO.KH_CaiDatSanPham> khCaiDatSanPhams = grdKeHoachNhapMoi.GrdDetail.GetAllData<MT.Data.BO.KH_CaiDatSanPham>();
                if(khCaiDatSanPhams == null || khCaiDatSanPhams.Count == 0)
                {
                    MMessage.ShowWarning("Bạn phải chọn ít nhất 1 kế hoạch");
                    return;
                }
                KH_CaiDatSanPhamRepository.SaveApproveOrReject(khCaiDatSanPhams,
                    (int)this.iTrangThaiDuyetKHCĐSP,Convert.ToString(txtsLyDoDuyet.EditValue));
                MTControl.MMessage.ShowInfor("Lưu thành công");
                if (this.callback != null)
                {
                    this.callback();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                CommonFnUI.ShowError(ex,"Phê duyệt kế hoạch");
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

        private void frmKH_CaiDatSanPham_PheDuyet_Shown(object sender, EventArgs e)
        {
            grdKeHoachNhapMoi.GrdDetail.LoadData(this.khCaiDatSanPhams);
        }
        #endregion


    }
}
