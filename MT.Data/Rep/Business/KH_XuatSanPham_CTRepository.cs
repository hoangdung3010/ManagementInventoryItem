using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class KH_XuatSanPham_CTRepository : MT.Data.Rep.BaseRepository<KH_XuatSanPham_CT>
    {
        #region "Constructor"

        public KH_XuatSanPham_CTRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion "Constructor"

        /// <summary>
        /// Lấy chi tiết kế hoạch xuất sản phẩm
        /// </summary>
        /// <param name="sDM_SanPham_Id">ID của sản phẩm</param>
        /// <returns></returns>
        public KH_XuatSanPham_CT GetKH_XuatSanPham_CTBysKH_XuatSanPham_IdAndsDM_SanPham_Id(Guid sKH_XuatSanPham_Id,
            Guid sDM_SanPham_Id, Guid? sDM_DonViTinh_Id, Guid? sKH_XuatSanPham_CT_Id = null)
        {
            string query = $@"select KHX_CT.Id, KHX_CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten,
                                KHX_CT.rSoLuong - ISNULL(PNM_CT.rSoLuong,0) as rSoLuong,
                                ISNULL(KHX_CT.iThoiGianBaoHanh,60) as iThoiGianBaoHanh,ISNULL(KHX_CT.iDonViThoiGianBaoHanh,1) as iDonViThoiGianBaoHanh,
                                KHX_CT.rDonGia,KHX_CT.sGhiChu,KHX_CT.sDM_DonViTinh_Id,
                                case when SP.sDM_DonViTinh_Id_Cap2 IS NOT NULL AND  KHX_CT.sDM_DonViTinh_Id=SP.sDM_DonViTinh_Id_Cap2
                                AND SP.iKichThuocDongGoi>0 then 1
                                else 0 end as IsShowSoSerial,SP.iKichThuocDongGoi
                                from [dbo].KH_XuatSanPham_CT KHX_CT
                                JOIN dbo.DM_SanPham SP ON KHX_CT.sDM_SanPham_Id=SP.ID
                                LEFT JOIN  (SELECT sKH_XuatSanPham_CT_Id,sum(rSoLuong) as rSoLuong FROM
								[dbo].[Phieu_XuatSanPham_CT]	group by sKH_XuatSanPham_CT_Id) as PNM_CT ON KHX_CT.Id=PNM_CT.sKH_XuatSanPham_CT_Id
                            WHERE KHX_CT.sKH_XuatSanPham_Id='{sKH_XuatSanPham_Id}'
                            AND KHX_CT.sDM_SanPham_Id='{sDM_SanPham_Id}'";
            if (sKH_XuatSanPham_CT_Id.HasValue)
            {
                query += $" AND KHX_CT.Id!='{sKH_XuatSanPham_CT_Id}'";
            }
            if (sDM_DonViTinh_Id.HasValue)
            {
                query += $" AND KHX_CT.sDM_DonViTinh_Id='{sDM_DonViTinh_Id}'";
            }
            return _unitOfWork.QueryFirstOrDefault<KH_XuatSanPham_CT>(query);
        }

        #region"Region"

        /// <summary>
        /// Lấy chi tiết sản phẩm theo kế hoạch xuất
        /// </summary>
        /// <param name="sKH_XuatSanPham_Id">ID của kế hoạch nhập mới</param>
        /// <returns></returns>
        public List<DM_SanPham> GetKH_XuatSanPham_CTsBysKH_XuatSanPham_Id(Guid sKH_XuatSanPham_Id)
        {
            string query = $@"SELECT SP.Id,SP.sMaSanPham,SP.sTenSanPham FROM dbo.KH_XuatSanPham_CT  KH_CT
                              JOIN dbo.DM_SanPham SP ON KH_CT.sDM_SanPham_Id=SP.Id
                              WHERE sKH_XuatSanPham_Id='{sKH_XuatSanPham_Id}' ORDER BY KH_CT.SortOrder ";

            return _unitOfWork.Query<DM_SanPham>(query);
        }

        /// <summary>
        /// Lấy chi tiết sản phẩm theo kế hoạch nhập mới
        /// </summary>
        /// <param name="sMaSP">Mã sản phẩm</param>
        /// <returns></returns>

        public KH_XuatSanPham_CT GetKH_XuatSanPham_CTBysKH_XuatSanPham_IdAndsMaSP(Guid? sKH_XuatSanPham_Id, string sMaSP)
        {
            // Note 14.6
            /*string query = $@"SELECT KH_CT.Id ,SP.sMaSanPham,SP.sTenSanPham as sDM_SanPham_Id_Ten,KH_CT.rSoLuong,KH_CT.rDonGia,KH_CT.sDM_DonViTinh_Id,KH_CT.sDM_SanPham_Id
                                FROM dbo.KH_XuatSanPham_CT  KH_CT
                              JOIN dbo.DM_SanPham SP ON KH_CT.sDM_SanPham_Id=SP.Id
                              WHERE KH_CT.sKH_XuatSanPham_Id='{sKH_XuatSanPham_Id}' AND SP.sMaSanPham=@sMaSanPham";*/
            string query = $@"SELECT *
                                FROM dbo.View_KH_XuatSanPham_CT  KH_CT
                              JOIN dbo.DM_SanPham SP ON KH_CT.sDM_SanPham_Id=SP.Id
                              WHERE KH_CT.sKH_XuatSanPham_Id='{sKH_XuatSanPham_Id}' AND SP.sMaSanPham=@sMaSanPham";

            return _unitOfWork.QueryFirstOrDefault<KH_XuatSanPham_CT>(query, new { sMaSanPham = sMaSP });
        }

        #endregion
    }
}