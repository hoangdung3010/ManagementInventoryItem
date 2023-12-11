using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class DM_SanPhamRepository : MT.Data.Rep.BaseRepository<DM_SanPham>
    {
        #region "Constructor"
        public DM_SanPhamRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"
        /// <summary>
        /// Lấy về danh sách đơn vị tính của sản phẩm
        /// </summary>
        /// <param name="id">ID của sản phẩm</param>
        /// <returns>Danh sách đơn vị tính</returns>
        public List<DM_DonViTinh> GetDonViTinhCuaSanPham(Guid id)
        {
            string query = $@"SELECT 
                                    sDM_DonViTinh_Id_Cap1
                                    ,DVT1.sTenDonViTinh AS sDM_DonViTinh_Id_Cap1_Ten
                                    ,sDM_DonViTinh_Id_Cap2
                                    ,DVT2.sTenDonViTinh as sDM_DonViTinh_Id_Cap2_Ten
                            FROM dbo.DM_SanPham sp 
                            LEFT JOIN dbo.DM_DonViTinh DVT1 ON DVT1.Id=sp.sDM_DonViTinh_Id_Cap1
                            LEFT JOIN dbo.DM_DonViTinh DVT2 ON DVT2.Id=sp.sDM_DonViTinh_Id_Cap2 
                            WHERE sp.Id='{id}'";

            DM_SanPham dM_SanPham = _unitOfWork.QueryFirstOrDefault<DM_SanPham>(query);

            List<DM_DonViTinh> dM_DonViTinhs = new List<DM_DonViTinh>();

            if (dM_SanPham != null && dM_SanPham.sDM_DonViTinh_Id_Cap1.HasValue)
            {
                dM_DonViTinhs.Add(new DM_DonViTinh { Id = dM_SanPham.sDM_DonViTinh_Id_Cap1.Value, sTenDonViTinh = dM_SanPham.sDM_DonViTinh_Id_Cap1_Ten });
            }
            if (dM_SanPham != null && dM_SanPham.sDM_DonViTinh_Id_Cap2.HasValue)
            {
                dM_DonViTinhs.Add(new DM_DonViTinh { Id = dM_SanPham.sDM_DonViTinh_Id_Cap2.Value, sTenDonViTinh = dM_SanPham.sDM_DonViTinh_Id_Cap2_Ten });
            }
            return dM_DonViTinhs;
        }


        /// <summary>
        /// Lấy chi tiết thông tin SP theo mã SP
        /// </summary>
        /// <param name="sMaSP"></param>
        /// <returns></returns>
        public DM_SanPham GetByMaSP(string sMaSP)
        {
            string query = $@"SELECT 
                                    sDM_DonViTinh_Id_Cap1
                                    ,DVT1.sTenDonViTinh AS sDM_DonViTinh_Id_Cap1_Ten
                                    ,sDM_DonViTinh_Id_Cap2
                                    ,DVT2.sTenDonViTinh as sDM_DonViTinh_Id_Cap2_Ten
                                    ,sp.Id,sp.rDonGia_Cap1,sp.sTenSanPham
                            FROM dbo.DM_SanPham sp 
                            LEFT JOIN dbo.DM_DonViTinh DVT1 ON DVT1.Id=sp.sDM_DonViTinh_Id_Cap1
                            LEFT JOIN dbo.DM_DonViTinh DVT2 ON DVT2.Id=sp.sDM_DonViTinh_Id_Cap2 
                            WHERE sp.sMaSanPham=@sMaSanPham";

            DM_SanPham dM_SanPham = _unitOfWork.QueryFirstOrDefault<DM_SanPham>(query,new { sMaSanPham = sMaSP });

            return dM_SanPham;
        }

        #endregion
    }
}
