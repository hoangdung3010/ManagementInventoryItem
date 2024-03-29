﻿using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class Phieu_NhapMuonTra_CTRepository : MT.Data.Rep.BaseRepository<Phieu_NhapMuonTra_CT>
    {
        #region "Constructor"

        public Phieu_NhapMuonTra_CTRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion "Constructor"

        #region"Region"

        /// <summary>
        /// Lấy chi tiết sản phẩm gán với kế hoạch nhập mới
        /// </summary>
        /// <param name="masterId">Id của kế hoạch nhập mới</param>
        /// <returns>Danh sách chi tiết kế hoạch</returns>
        public IList GetPhieu_XuatMuonTra_CTsByMasterId(Guid masterId)
        {
            string query = $@"select NewId() as Id,PX_CT.Id as sPhieu_XuatMuonTra_CT_Id, PX_CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten,
            case when SP.sDM_DonViTinh_Id_Cap2 IS NOT NULL AND  PX_CT.sDM_DonViTinh_Id=SP.sDM_DonViTinh_Id_Cap2
            AND SP.iKichThuocDongGoi>0 AND SP.iKichThuocDongGoi<PX_CT.rSoLuong - ISNULL(PN_CT.rSoLuong,0) then SP.iKichThuocDongGoi
            else PX_CT.rSoLuong - ISNULL(PN_CT.rSoLuong,0) end as rSoLuong,
            case when SP.sDM_DonViTinh_Id_Cap2 IS NOT NULL AND  PX_CT.sDM_DonViTinh_Id=SP.sDM_DonViTinh_Id_Cap2
            AND SP.iKichThuocDongGoi>0 AND SP.iKichThuocDongGoi<PX_CT.rSoLuong - ISNULL(PN_CT.rSoLuong,0) then SP.iKichThuocDongGoi
            else PX_CT.rSoLuong - ISNULL(PN_CT.rSoLuong,0) end * PX_CT.rDonGia as  rThanhTien,
            ISNULL(PX_CT.iThoiGianBaoHanh,60) as iThoiGianBaoHanh,ISNULL(PX_CT.iDonViThoiGianBaoHanh,1) as iDonViThoiGianBaoHanh,
            PX_CT.rDonGia,PX_CT.sGhiChu,PX_CT.sDM_DonViTinh_Id,DATEADD(Day,60,getdate()) as dHanBaoHanhDen

            from [dbo].Phieu_XuatMuonTra_CT AS PX_CT
            JOIN dbo.DM_SanPham SP ON PX_CT.sDM_SanPham_Id=SP.ID
            LEFT JOIN  (SELECT sPhieu_XuatMuonTra_CT_Id,sum(rSoLuong) as rSoLuong FROM
            [dbo].[Phieu_NhapMuonTra_CT]	group by sPhieu_XuatMuonTra_CT_Id) AS PN_CT
            ON PX_CT.Id=PN_CT.sPhieu_XuatMuonTra_CT_Id
            WHERE PX_CT.sPhieu_XuatMuonTra_Id='{masterId}'
            AND PX_CT.rSoLuong - ISNULL(PN_CT.rSoLuong,0) >0
            ORDER BY PX_CT.SortOrder";
            List<Phieu_NhapMuonTra_CT> phieu_NhapMuonTra_CTs = _unitOfWork.Query<Phieu_NhapMuonTra_CT>(query);
            if (phieu_NhapMuonTra_CTs != null)
            {
                foreach (var item in phieu_NhapMuonTra_CTs)
                {
                    item.MTEntityState = Enummation.MTEntityState.Add;
                }
            }

            return phieu_NhapMuonTra_CTs;
        }

        // Truong 14.6
        public List<Phieu_NhapMuonTra_CT> GetAllPhieuNhapCT(Guid maDVXuat, int tcNhap)
        {
            string query = $@"SELECT * FROM Phieu_NhapMuonTra_CT AS ct inner join Phieu_NhapMuonTra AS pn on ct.sPhieu_NhapMuonTra_Id = pn.id WHERE  pn.sDM_DonVi_Id_Nhap ='{maDVXuat}' and pn.iTCNhap=" + tcNhap;

            return _unitOfWork.Query<Phieu_NhapMuonTra_CT>(query);
        }

        #endregion

        /// <summary>
        /// Lấy chi tiết sản phẩm theo kế hoạch xuất
        /// </summary>
        /// <param name="sMaSP">Mã sản phẩm</param>
        /// <returns></returns>

        public Phieu_NhapMuonTra_CT GetPhieu_NhapMuonTra_CTBysPhieu_NhapMuonTra_IdAndsMaSP(Guid? sPhieu_NhapMuonTra_Id, string sMaSP)
        {
            // Note 14.6
            /* string query = $@"SELECT KH_CT.Id ,SP.sMaSanPham,SP.sTenSanPham as sDM_SanPham_Id_Ten,KH_CT.rSoLuong,KH_CT.rDonGia,KH_CT.sDM_DonViTinh_Id,KH_CT.sDM_SanPham_Id
                                 FROM dbo.Phieu_NhapMuonTra_CT  KH_CT
                               JOIN dbo.DM_SanPham SP ON KH_CT.sDM_SanPham_Id=SP.Id
                               WHERE KH_CT.sPhieu_NhapMuonTra_Id='{sPhieu_NhapMuonTra_Id}' AND SP.sMaSanPham=@sMaSanPham";*/
            string query = $@"SELECT *
                                FROM dbo.View_Phieu_NhapMuonTra_CT  KH_CT
                              JOIN dbo.DM_SanPham SP ON KH_CT.sDM_SanPham_Id=SP.Id
                              WHERE KH_CT.sPhieu_NhapMuonTra_Id='{sPhieu_NhapMuonTra_Id}' AND SP.sMaSanPham=@sMaSanPham";

            return _unitOfWork.QueryFirstOrDefault<Phieu_NhapMuonTra_CT>(query, new { sMaSanPham = sMaSP });
        }
    }
}