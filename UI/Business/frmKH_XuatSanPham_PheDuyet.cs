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
    public partial class frmKH_XuatSanPham_PheDuyet : FormUI.FormUIBase
    {
        IList kH_XuatSanPhams;

        int iTrangThaiDuyetKHNM;

        Action callback;
        public frmKH_XuatSanPham_PheDuyet(Action callback, int  iTrangThaiDuyetKHNM, 
            List<MT.Data.BO.KH_XuatSanPham> kH_XuatSanPhams)
        {
            InitializeComponent();
            this.kH_XuatSanPhams = kH_XuatSanPhams;
            this.iTrangThaiDuyetKHNM = iTrangThaiDuyetKHNM;
            cboiTrangThaiDuyet.EnumData = "iTrangThaiDuyetKHNM";
            cboiTrangThaiDuyet.SetValue((int)this.iTrangThaiDuyetKHNM);
            cboiTrangThaiDuyet.SetReadOnly(true);
            this.callback = callback;
            if (this.kH_XuatSanPhams.Count == 1)
            {
                txtsLyDoDuyet.EditValue = this.kH_XuatSanPhams[0].GetValue<string>("sLyDoXetDuyet");
            }

            if (iTrangThaiDuyetKHNM == (int)MT.Data.iTrangThaiDuyetPNM.DongYDuyet)
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
           
            grd.TableName = "KH_XuatSanPham";
            grd.ViewName = "View_KH_XuatSanPham";
            grd.CustomModelFields = "iDonViThoiGianHieuLuc";
            grd.AddColumnText("sMa", "Số KH", "Số kế hoạch", 120, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            grd.AddColumnText("sDM_DonVi_Id_DonViXayDungKH_Ten", "Đơn vị lập", "Đơn vị lập", 180, isFixWidth: true);
            grd.AddColumnText("sDM_CanBo_Id_NguoiLapKH_Ten", "Người lập", "Người lập", 150);
            grd.AddColumnText("dNgayKeHoach", "Ngày lập", 100);
            //grd.AddColumnText("sSoHopDong", "Số hợp đồng", 100);
            //grd.AddColumnText("dNgayHopDong", "Ngày hợp đồng", 100);
            grd.AddColumnText("iThoiGianHieuLuc", "Thời gian hiệu lực", 80);
            grd.AddColumnText("sDM_DonVi_Id_DonViXuat_Ten", "Đơn vị xuất", 250);
            grd.AddColumnText("sDM_DonVi_Id_DonViNhap_Ten", "Đơn vị nhập", 250);
            grd.AddColumnText("sDM_CanBo_Id_ThuTruongDonVi_Ten", "Thủ trưởng đơn vị", 250);
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
                KH_XuatSanPhamRepository kH_XuatSanPhamRepository = DBContext.GetRep2<KH_XuatSanPhamRepository>();

                List<MT.Data.BO.KH_XuatSanPham> kH_XuatSanPhams = grdKeHoachNhapMoi.GrdDetail.GetAllData<MT.Data.BO.KH_XuatSanPham>();
                if(kH_XuatSanPhams==null || kH_XuatSanPhams.Count == 0)
                {
                    MMessage.ShowWarning("Bạn phải chọn ít nhất 1 kế hoạch");
                    return;
                }
                kH_XuatSanPhamRepository.SaveApproveOrReject(kH_XuatSanPhams,
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

        private void frmKH_XuatSanPham_PheDuyet_Load(object sender, EventArgs e)
        {
            grdKeHoachNhapMoi.GrdDetail.LoadData(this.kH_XuatSanPhams);
        }
        #endregion


    }
}
