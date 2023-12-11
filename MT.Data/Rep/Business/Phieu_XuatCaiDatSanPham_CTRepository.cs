using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.BO;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MT.Data.Rep
{
    public class Phieu_XuatCaiDatSanPham_CTRepository : MT.Data.Rep.BaseRepository<Phieu_XuatCaiDatSanPham_CT>
    {
        #region "Constructor"
        public Phieu_XuatCaiDatSanPham_CTRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"
        /// <summary>
        /// Kiểm tra xem sản phẩm có nằm trong kế hoạch xuất cài đặt ko
        /// </summary>
        /// <param name="sKH_CaiDatSanPham_Id_CanCu">Id của kế hoạch</param>
        /// <param name="sMaSP">Mã sản phẩm</param>
        /// <returns></returns>
        public Phieu_XuatCaiDatSanPham_CT GetPhieu_XuatCaiDatSanPham_CTByPhieuXuatIdAndsMaSP(Guid sPhieu_XuatCaiDatSanPham_Id, string sMaSP)
        {
            string query = $@"SELECT CT.*,SP.sTenSanPham as sDM_SanPham_Id_Ten FROM Phieu_XuatCaiDatSanPham_CT  CT
                            JOIN dbo.DM_SanPham SP ON CT.sDM_SanPham_Id=SP.Id
                            WHERE CT.sPhieu_XuatCaiDatSanPham_Id='{sPhieu_XuatCaiDatSanPham_Id}' 
                            AND SP.sMaSanPham=@sMaSanPham";
            return _unitOfWork.QueryFirstOrDefault<Phieu_XuatCaiDatSanPham_CT>(query, new { sMaSanPham = sMaSP });
        }
        // Truong 14.6
        public List<Phieu_XuatCaiDatSanPham_CT> GetAllPhieuXuatCT(Guid maDVXuat, int tcXuat, Guid maKHX) // sPhieu_XuatCaiDatSanPham_Id
        {
            string query = $@"SELECT * FROM Phieu_XuatCaiDatSanPham_CT AS ct inner join Phieu_XuatCaiDatSanPham AS px on ct.sPhieu_XuatCaiDatSanPham_Id = px.id WHERE  px.sDM_DonVi_Id_Xuat ='{maDVXuat}' and px.iLoai=" + tcXuat + " and px.sKH_CaiDatSanPham_Id_CanCu='" + maKHX + "'";

            return _unitOfWork.Query<Phieu_XuatCaiDatSanPham_CT>(query);
        }

        public Phieu_XuatCaiDatSanPham_CT GetPhieu_XuatCaiDatSanPham_CTBysPhieu_XuatCaiDatSanPham_CT_IdAndsMaSP(Guid sPhieu_XuatCaiDatSanPham_Id, string sMaVach)
        {
            string query = $@"SELECT KH_CT.Id ,SP.sMaSanPham,SP.sTenSanPham as sDM_SanPham_Id_Ten,KH_CT.rSoLuong,KH_CT.rDonGia,KH_CT.sDM_DonViTinh_Id,KH_CT.sDM_SanPham_Id, KH_CT.sMaVach
                                FROM dbo.Phieu_XuatCaiDatSanPham_CT KH_CT
                              JOIN dbo.DM_SanPham SP ON KH_CT.sDM_SanPham_Id = SP.Id
                              WHERE KH_CT.sPhieu_XuatCaiDatSanPham_Id = '{sPhieu_XuatCaiDatSanPham_Id}' AND KH_CT.sMaVach= @sMaVach";


            return _unitOfWork.QueryFirstOrDefault<Phieu_XuatCaiDatSanPham_CT>(query, new { sMaVach = sMaVach });
        }
        #endregion
    }
}
