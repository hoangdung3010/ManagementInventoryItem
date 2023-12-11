using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class KH_NhapSanPhamMoi_CTRepository : MT.Data.Rep.BaseRepository<KH_NhapSanPhamMoi_CT>
    {
        #region "Constructor"
        public KH_NhapSanPhamMoi_CTRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"

        /// <summary>
        /// Lấy chi tiết sản phẩm theo kế hoạch nhập mới
        /// </summary>
        /// <param name="sMaSP">Mã sản phẩm</param>
        /// <returns></returns>
        public KH_NhapSanPhamMoi_CT GetKH_NhapSanPhamMoi_CTsBysKH_NhapSanPhamMoi_IdAndsMaSP(Guid sKH_NhapSanPhamMoi_Id,  string  sMaSP)
        {
            string query = $@"SELECT KH_CT.Id ,SP.sMaSanPham,SP.sTenSanPham as sDM_SanPham_Id_Ten,KH_CT.rSoLuong,KH_CT.rDonGia,KH_CT.sDM_DonViTinh_Id,KH_CT.sDM_SanPham_Id FROM dbo.KH_NhapSanPhamMoi_CT  KH_CT
                              JOIN dbo.DM_SanPham SP ON KH_CT.sDM_SanPham_Id=SP.Id
                              WHERE KH_CT.sKH_NhapSanPhamMoi_Id='{sKH_NhapSanPhamMoi_Id}' AND SP.sMaSanPham=@sMaSanPham";

            return _unitOfWork.QueryFirstOrDefault<KH_NhapSanPhamMoi_CT>(query, new { sMaSanPham= sMaSP});
        }

       
        #endregion
    }
}
