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
    public class Phieu_NhapCaiDatSanPham_CTRepository : MT.Data.Rep.BaseRepository<Phieu_NhapCaiDatSanPham_CT>
    {
        #region "Constructor"
        public Phieu_NhapCaiDatSanPham_CTRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"
        public List<Phieu_NhapCaiDatSanPham_CT> GetAllPhieuNhapCT(Guid maDVNhap, int tcXuat, Guid maKHX) // sPhieu_XuatCaiDatSanPham_Id
        {
            string query = $@"SELECT * 
                                FROM Phieu_NhapCaiDatSanPham_CT AS ct 
                                inner join Phieu_NhapCaiDatSanPham AS px on ct.sPhieu_NhapCaiDatSanPham_Id = px.id 
                                WHERE  px.sDM_DonVi_Id_Nhap ='{maDVNhap}' 
                                and px.iLoai={tcXuat} 
                                and px.sPhieu_XuatSanPham_Id_CanCu='{maKHX.ToString()}'";

            return _unitOfWork.Query<Phieu_NhapCaiDatSanPham_CT>(query);
        }
        #endregion

        #region"Overrides"
        /// <summary>
        /// Lấy chi tiết sản phẩm theo kế hoạch xuất
        /// </summary>
        /// <param name="sMaSP">Mã sản phẩm</param>
        /// <returns></returns>

        public Phieu_NhapCaiDatSanPham_CT GetPhieu_NhapCaiDatSanPham_CTBysPhieu_NhapCaiDatSanPham_IdAndsMaSP(Guid sPhieu_NhapCaiDatSanPham_Id, string sMaSP)
        {
            // Note 14.6
            string query = $@"SELECT 
                                KH_CT.Id 
                                ,SP.sMaSanPham
                                ,SP.sTenSanPham as sDM_SanPham_Id_Ten
                                ,KH_CT.rSoLuong,KH_CT.rDonGia
                                ,KH_CT.sDM_DonViTinh_Id,KH_CT.sDM_SanPham_Id 
                                ,KH_CT.sDM_MangLienLac_Id
								,mll.sTenMangLienLac AS sDM_MangLienLac_Id_Ten
                                ,KH_CT.sDM_NoiDungCaiDat_Id
								,ndcd.sTenNoiDungCaiDat AS sDM_NoiDungCaiDat_Id_Ten
                                FROM dbo.Phieu_NhapCaiDatSanPham_CT  KH_CT
                              LEFT JOIN dbo.DM_SanPham SP ON KH_CT.sDM_SanPham_Id=SP.Id
                              LEFT JOIN DM_MangLienLac mll ON mll.Id = KH_CT.sDM_MangLienLac_Id
                              LEFT JOIN DM_NoiDungCaiDat ndcd ON ndcd.Id = KH_CT.sDM_NoiDungCaiDat_Id
                              WHERE KH_CT.sPhieu_NhapCaiDatSanPham_Id='{sPhieu_NhapCaiDatSanPham_Id}' AND SP.sMaSanPham=@sMaSanPham";

            return _unitOfWork.QueryFirstOrDefault<Phieu_NhapCaiDatSanPham_CT>(query, new { sMaSanPham = sMaSP });
        }
        #endregion
    }
}
