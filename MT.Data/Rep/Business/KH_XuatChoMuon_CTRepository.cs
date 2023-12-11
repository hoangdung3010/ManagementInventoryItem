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
    public class KH_XuatChoMuon_CTRepository : MT.Data.Rep.BaseRepository<KH_XuatChoMuon_CT>
    {
        #region "Constructor"

        public KH_XuatChoMuon_CTRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        /// <summary>
        /// Lấy chi tiết kế hoạch xuất sản phẩm
        /// </summary>
        /// <param name="sDM_SanPham_Id">ID của sản phẩm</param>
        /// <returns></returns>
        public KH_XuatChoMuon_CT GetKH_XuatChoMuon_CTBysKH_XuatChoMuon_IdAndsDM_SanPham_Id(Guid sKH_XuatChoMuon_Id,
            Guid sDM_SanPham_Id, Guid? sDM_DonViTinh_Id, Guid? sKH_XuatChoMuon_CT_Id = null)
        {
            string query = $@"select KHBD_CT.Id, KHBD_CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten, 
                                KHBD_CT.rSoLuong - ISNULL(KHX_CT.rSoLuong,0) as rSoLuong,
                                ISNULL(KHBD_CT.iThoiGianBaoHanh,60) as iThoiGianBaoHanh,ISNULL(KHBD_CT.iDonViThoiGianBaoHanh,1) as iDonViThoiGianBaoHanh,
                                KHBD_CT.rDonGia,KHBD_CT.sGhiChu,KHBD_CT.sDM_DonViTinh_Id,
                                case when SP.sDM_DonViTinh_Id_Cap2 IS NOT NULL AND  KHBD_CT.sDM_DonViTinh_Id=SP.sDM_DonViTinh_Id_Cap2 
                                AND SP.iKichThuocDongGoi>0 then 1 
                                else 0 end as IsShowSoSerial,SP.iKichThuocDongGoi
                                from [dbo].KH_XuatChoMuon_CT KHBD_CT 
                                JOIN dbo.DM_SanPham SP ON KHBD_CT.sDM_SanPham_Id=SP.ID
                                LEFT JOIN  (SELECT sKH_XuatChoMuon_CT_Id,sum(rSoLuong) as rSoLuong FROM 
								[dbo].[KH_XuatSanPham_CT]	group by sKH_XuatChoMuon_CT_Id) as KHX_CT ON KHBD_CT.Id=KHX_CT.sKH_XuatChoMuon_CT_Id
                            WHERE KHBD_CT.sKH_XuatChoMuon_Id='{sKH_XuatChoMuon_Id}'  
                            AND KHBD_CT.sDM_SanPham_Id='{sDM_SanPham_Id}'";
            if (sKH_XuatChoMuon_CT_Id.HasValue)
            {
                query += $" AND KHBD_CT.Id!='{sKH_XuatChoMuon_CT_Id}'";
            }
            if (sDM_DonViTinh_Id.HasValue)
            {
                query += $" AND KHBD_CT.sDM_DonViTinh_Id='{sDM_DonViTinh_Id}'";
            }
            return _unitOfWork.QueryFirstOrDefault<KH_XuatChoMuon_CT>(query);
        }

        public KH_XuatChoMuon_CT GetKH_XuatChoMuon_CTBysKH_XuatChoMuon_Id(Guid sKH_XuatChoMuon_Id)
        {
            string query = $@"select KHBD_CT.Id, KHBD_CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten, 
                                KHBD_CT.rSoLuong - ISNULL(KHX_CT.rSoLuong,0) as rSoLuong,
                                ISNULL(KHBD_CT.iThoiGianBaoHanh,60) as iThoiGianBaoHanh,ISNULL(KHBD_CT.iDonViThoiGianBaoHanh,1) as iDonViThoiGianBaoHanh,
                                KHBD_CT.rDonGia,KHBD_CT.sGhiChu,KHBD_CT.sDM_DonViTinh_Id,
                                case when SP.sDM_DonViTinh_Id_Cap2 IS NOT NULL AND  KHBD_CT.sDM_DonViTinh_Id=SP.sDM_DonViTinh_Id_Cap2 
                                AND SP.iKichThuocDongGoi>0 then 1 
                                else 0 end as IsShowSoSerial,SP.iKichThuocDongGoi
                                from [dbo].KH_XuatChoMuon_CT KHBD_CT 
                                JOIN dbo.DM_SanPham SP ON KHBD_CT.sDM_SanPham_Id=SP.ID
                                LEFT JOIN  (SELECT sKH_XuatChoMuon_CT_Id,sum(rSoLuong) as rSoLuong FROM 
								[dbo].[KH_XuatSanPham_CT]	group by sKH_XuatChoMuon_CT_Id) as KHX_CT ON KHBD_CT.Id=KHX_CT.sKH_XuatChoMuon_CT_Id
                            WHERE KHBD_CT.sKH_XuatChoMuon_Id='{sKH_XuatChoMuon_Id}'";
           
           
            return _unitOfWork.QueryFirstOrDefault<KH_XuatChoMuon_CT>(query);
        }
        /// <summary>
        /// Lấy chi tiết sản phẩm theo kế hoạch nhập mới
        /// </summary>
        /// <param name="sSPID">Mã sản phẩm</param>
        /// <returns></returns>
        public KH_XuatChoMuon_CT GetKH_XuatChoMuon_CTsBysKH_XuatChoMuon_IdAndsIDSP(Guid sKH_XuatChoMuon_Id, string sSPID)
        {
            string query = $@"SELECT KH_CT.Id ,KH_CT.rSoLuong,KH_CT.rDonGia,KH_CT.sDM_DonViTinh_Id,KH_CT.sDM_SanPham_Id 
                              FROM dbo.KH_XuatChoMuon_CT  KH_CT
                              WHERE KH_CT.sKH_XuatChoMuon_Id='{sKH_XuatChoMuon_Id}' AND KH_CT.sDM_SanPham_Id='{sSPID}'";

            return _unitOfWork.QueryFirstOrDefault<KH_XuatChoMuon_CT>(query, new { sDM_SanPham_Id = "'"+sSPID+"'" });
        }

        #endregion "Constructor"
        /// <summary>
        /// Lấy chi tiết sản phẩm gán với kế hoạch nhập mới
        /// </summary>
        /// <param name="masterId">Id của kế hoạch nhập mới</param>
        /// <returns>Danh sách chi tiết kế hoạch</returns>
        public IList GetKHXuatChoMuon_CTsByMasterId(Guid masterId)
        {
            string query = $@"select NewId() as Id,
            KHXBD_CT.Id as sKH_XuatChoMuon_CT_Id, 
            KHXBD_CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten, 
            case when SP.sDM_DonViTinh_Id_Cap2 IS NOT NULL AND  KHXBD_CT.sDM_DonViTinh_Id=SP.sDM_DonViTinh_Id_Cap2 AND SP.iKichThuocDongGoi>0 AND SP.iKichThuocDongGoi<KHXBD_CT.rSoLuong - ISNULL(KHX_CT.rSoLuong,0) 
            then SP.iKichThuocDongGoi
            else KHXBD_CT.rSoLuong - ISNULL(KHX_CT.rSoLuong,0) end as rSoLuong,
            case when SP.sDM_DonViTinh_Id_Cap2 IS NOT NULL AND  KHXBD_CT.sDM_DonViTinh_Id=SP.sDM_DonViTinh_Id_Cap2 
            AND SP.iKichThuocDongGoi>0 AND SP.iKichThuocDongGoi<KHXBD_CT.rSoLuong - ISNULL(KHX_CT.rSoLuong,0) then SP.iKichThuocDongGoi
            else KHXBD_CT.rSoLuong - ISNULL(KHX_CT.rSoLuong,0) end * KHXBD_CT.rDonGia as  rThanhTien,
            ISNULL(KHXBD_CT.iThoiGianBaoHanh,60) as iThoiGianBaoHanh,ISNULL(KHXBD_CT.iDonViThoiGianBaoHanh,1) as iDonViThoiGianBaoHanh,
            KHXBD_CT.rDonGia,KHXBD_CT.sGhiChu,KHXBD_CT.sDM_DonViTinh_Id,DATEADD(Day,60,getdate()) as dHanBaoHanhDen
                                
            from [dbo].KH_XuatChoMuon_CT KHXBD_CT 
            JOIN dbo.DM_SanPham SP ON KHXBD_CT.sDM_SanPham_Id=SP.ID
            LEFT JOIN  (SELECT sKH_XuatChoMuon_CT_Id,sum(rSoLuong) as rSoLuong FROM 
            [dbo].[KH_XuatSanPham_CT]	group by sKH_XuatChoMuon_CT_Id) AS KHX_CT 
            ON KHXBD_CT.Id=KHX_CT.sKH_XuatChoMuon_CT_Id
            WHERE KHXBD_CT.sKH_XuatChoMuon_Id='{masterId}' 
            AND KHXBD_CT.rSoLuong - ISNULL(KHX_CT.rSoLuong,0) >0     
            ORDER BY KHXBD_CT.SortOrder";
            List<KH_XuatSanPham_CT> kHXuatSanPham_CTs = _unitOfWork.Query<KH_XuatSanPham_CT>(query);
            if (kHXuatSanPham_CTs != null)
            {
                foreach (var item in kHXuatSanPham_CTs)
                {
                    item.MTEntityState = Enummation.MTEntityState.Add;
                }
            }

            return kHXuatSanPham_CTs;
        }

        /// <summary>
        /// Lấy chi tiết sản phẩm gán với kế hoạch nhập mới
        /// </summary>
        /// <param name="masterId">Id của kế hoạch nhập mới</param>
        /// <returns>Danh sách chi tiết kế hoạch</returns>
        public IList<DM_DonVi> GetListDonViNhanInKeHoachChoMuonID(Guid KHBDId)
        {
            string query = $@"select dmDV.Id,dmDV.sMaDonvi, dmDV.sTenDonvi
            from [dbo].KH_XuatChoMuon_CT KHXBD_CT 
            INNER JOIN  DM_DonVi AS dmDV 
            ON KHXBD_CT.sDM_DonVi_Id_DonViNhap=dmDV.ID
            WHERE KHXBD_CT.sKH_XuatChoMuon_Id='{KHBDId}' 
            group by dmDV.Id,dmDV.sMaDonvi, dmDV.sTenDonvi
            ORDER BY dmDV.sTenDonvi";
            List<DM_DonVi> dmDonVi = _unitOfWork.Query<DM_DonVi>(query);
            
            return dmDonVi;
        }
        /// <summary>
        /// Lấy chi tiết sản phẩm gán với kế hoạch nhập mới
        /// </summary>
        /// <param name="masterId">Id của kế hoạch nhập mới</param>
        /// <returns>Danh sách chi tiết kế hoạch</returns>
        public IList GetKHXuatChoMuon_CTsByMasterIdAndDonviNhap(Guid masterId, Guid donviNhapId)
        {
            string query = $@"select NewId() as Id,
            KHXBD_CT.Id as sKH_XuatChoMuon_CT_Id, 
            KHXBD_CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten, 
            case when SP.sDM_DonViTinh_Id_Cap2 IS NOT NULL AND  KHXBD_CT.sDM_DonViTinh_Id=SP.sDM_DonViTinh_Id_Cap2 AND SP.iKichThuocDongGoi>0 AND SP.iKichThuocDongGoi<KHXBD_CT.rSoLuong - ISNULL(KHX_CT.rSoLuong,0) 
            then SP.iKichThuocDongGoi
            else KHXBD_CT.rSoLuong - ISNULL(KHX_CT.rSoLuong,0) end as rSoLuong,
            case when SP.sDM_DonViTinh_Id_Cap2 IS NOT NULL AND  KHXBD_CT.sDM_DonViTinh_Id=SP.sDM_DonViTinh_Id_Cap2 
            AND SP.iKichThuocDongGoi>0 AND SP.iKichThuocDongGoi<KHXBD_CT.rSoLuong - ISNULL(KHX_CT.rSoLuong,0) then SP.iKichThuocDongGoi
            else KHXBD_CT.rSoLuong - ISNULL(KHX_CT.rSoLuong,0) end * KHXBD_CT.rDonGia as  rThanhTien,
            ISNULL(KHXBD_CT.iThoiGianBaoHanh,60) as iThoiGianBaoHanh,ISNULL(KHXBD_CT.iDonViThoiGianBaoHanh,1) as iDonViThoiGianBaoHanh,
            KHXBD_CT.rDonGia,KHXBD_CT.sGhiChu,KHXBD_CT.sDM_DonViTinh_Id,DATEADD(Day,60,getdate()) as dHanBaoHanhDen,1 as MTEntityState
                                
            from [dbo].KH_XuatChoMuon_CT KHXBD_CT 
            JOIN dbo.DM_SanPham SP ON KHXBD_CT.sDM_SanPham_Id=SP.ID
            LEFT JOIN  (SELECT sKH_XuatChoMuon_CT_Id,sum(rSoLuong) as rSoLuong FROM 
            [dbo].[KH_XuatSanPham_CT]	group by sKH_XuatChoMuon_CT_Id) AS KHX_CT 
            ON KHXBD_CT.Id=KHX_CT.sKH_XuatChoMuon_CT_Id
            WHERE KHXBD_CT.sKH_XuatChoMuon_Id='{masterId}' 
            AND KHXBD_CT.rSoLuong - ISNULL(KHX_CT.rSoLuong,0) >0     
            AND KHXBD_CT.sDM_DonVi_Id_DonViNhap='{donviNhapId}'
            ORDER BY KHXBD_CT.SortOrder";
            List<KH_XuatSanPham_CT> kHXuatSanPham_CTs = _unitOfWork.Query<KH_XuatSanPham_CT>(query);

            return kHXuatSanPham_CTs;
        }
        #region"Region"
        /// <summary>
        /// Lấy chi tiết sản phẩm theo kế hoạch xuất
        /// </summary>
        /// <param name="sKH_XuatChoMuon_Id">ID của kế hoạch nhập mới</param>
        /// <returns></returns>
        public List<DM_SanPham> GetKH_XuaChoMuon_CTsBysKH_XuatChoMuon_Id(Guid sKH_XuatChoMuon_Id)
        {
            string query = $@"SELECT SP.Id,SP.sMaSanPham,SP.sTenSanPham FROM dbo.KH_XuatChoMuon_CT  KHBD_CT
                              JOIN dbo.DM_SanPham SP ON KHBD_CT.sDM_SanPham_Id=SP.Id
                              WHERE sKH_XuatChoMuon_Id='{sKH_XuatChoMuon_Id}' ORDER BY KHBD_CT.SortOrder ";

            return _unitOfWork.Query<DM_SanPham>(query);
        }
        #endregion
    }
}