using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class Phieu_NhapSanPham_CTRepository : MT.Data.Rep.BaseRepository<Phieu_NhapSanPham_CT>
    {
        #region "Constructor"
        public Phieu_NhapSanPham_CTRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"
        /// <summary>
        /// Lấy chi tiết sản phẩm gán với kế hoạch nhập mới
        /// </summary>
        /// <param name="masterId">Id của kế hoạch nhập mới</param>
        /// <returns>Danh sách chi tiết kế hoạch</returns>
        public IList GetPhieu_XuatSanPham_CTsByMasterId(Guid masterId)
        {
            string query = $@"select NewId() as Id,PX_CT.Id as sPhieu_XuatSanPham_CT_Id, PX_CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten, 
            case when SP.sDM_DonViTinh_Id_Cap2 IS NOT NULL AND  PX_CT.sDM_DonViTinh_Id=SP.sDM_DonViTinh_Id_Cap2 
            AND SP.iKichThuocDongGoi>0 AND SP.iKichThuocDongGoi<PX_CT.rSoLuong - ISNULL(PN_CT.rSoLuong,0) then SP.iKichThuocDongGoi
            else PX_CT.rSoLuong - ISNULL(PN_CT.rSoLuong,0) end as rSoLuong,
            case when SP.sDM_DonViTinh_Id_Cap2 IS NOT NULL AND  PX_CT.sDM_DonViTinh_Id=SP.sDM_DonViTinh_Id_Cap2 
            AND SP.iKichThuocDongGoi>0 AND SP.iKichThuocDongGoi<PX_CT.rSoLuong - ISNULL(PN_CT.rSoLuong,0) then SP.iKichThuocDongGoi
            else PX_CT.rSoLuong - ISNULL(PN_CT.rSoLuong,0) end * PX_CT.rDonGia as  rThanhTien,
            ISNULL(PX_CT.iThoiGianBaoHanh,60) as iThoiGianBaoHanh,ISNULL(PX_CT.iDonViThoiGianBaoHanh,1) as iDonViThoiGianBaoHanh,
            PX_CT.rDonGia,PX_CT.sGhiChu,PX_CT.sDM_DonViTinh_Id,DATEADD(Day,60,getdate()) as dHanBaoHanhDen

            from [dbo].Phieu_XuatSanPham_CT AS PX_CT 
            JOIN dbo.DM_SanPham SP ON PX_CT.sDM_SanPham_Id=SP.ID
            LEFT JOIN  (SELECT sPhieu_XuatSanPham_CT_Id,sum(rSoLuong) as rSoLuong FROM 
            [dbo].[Phieu_NhapSanPham_CT]	group by sPhieu_XuatSanPham_CT_Id) AS PN_CT 
            ON PX_CT.Id=PN_CT.sPhieu_XuatSanPham_CT_Id
            WHERE PX_CT.sPhieu_XuatSanPham_Id='{masterId}' 
            AND PX_CT.rSoLuong - ISNULL(PN_CT.rSoLuong,0) >0
            ORDER BY PX_CT.SortOrder";
            List<Phieu_NhapSanPham_CT> phieu_NhapSanPham_CTs = _unitOfWork.Query<Phieu_NhapSanPham_CT>(query);
            if (phieu_NhapSanPham_CTs != null)
            {
                foreach (var item in phieu_NhapSanPham_CTs)
                {
                    item.MTEntityState = Enummation.MTEntityState.Add;
                }
            }

            return phieu_NhapSanPham_CTs;
        }
        // Truong 14.6
        public List<Phieu_NhapSanPham_CT> GetAllPhieuNhapCT(Guid maDVXuat)
        {
            string query = $@"SELECT * FROM Phieu_NhapSanPham_CT AS ct inner join Phieu_NhapSanPham AS pn on ct.sPhieu_NhapSanPham_Id = pn.id WHERE  pn.sDM_DonVi_Id_Nhap ='{maDVXuat}'";

            return _unitOfWork.Query<Phieu_NhapSanPham_CT>(query);
        }
        #endregion
    }
}
