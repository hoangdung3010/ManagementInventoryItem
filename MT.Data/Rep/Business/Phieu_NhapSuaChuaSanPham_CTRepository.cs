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
    public class Phieu_NhapSuaChuaSanPham_CTRepository : MT.Data.Rep.BaseRepository<Phieu_NhapSuaChuaSanPham_CT>// NOTE CHUA SUA Phieu_NhapSuaChuaSanPham_CTRepository
    {
        #region "Constructor"
        public Phieu_NhapSuaChuaSanPham_CTRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion
        /// <summary>
        /// Lấy chi tiết kế hoạch xuất sản phẩm
        /// </summary>
        /// <param name="sDM_SanPham_Id">ID của sản phẩm</param>
        /// <returns></returns>
        public Phieu_NhapSuaChuaSanPham_CT GetPhieu_NhapSuaChuaSanPham_CTBysPhieu_NhapSuaChuaSanPham_IdAndsDM_SanPham_Id(Guid sPhieu_NhapSuaChuaSanPham_Id,
            Guid sDM_SanPham_Id, Guid? sDM_DonViTinh_Id, Guid? sPhieu_NhapSuaChuaSanPham_CT_Id = null)
        {
            string query = $@"select PX_CT.Id, PX_CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten, 
                                PX_CT.rSoLuong - ISNULL(PNM_CT.rSoLuong,0) as rSoLuong,
                                ISNULL(PX_CT.iThoiGianBaoHanh,60) as iThoiGianBaoHanh,ISNULL(PX_CT.iDonViThoiGianBaoHanh,1) as iDonViThoiGianBaoHanh,
                                PX_CT.rDonGia,PX_CT.sGhiChu,PX_CT.sDM_DonViTinh_Id,
                                case when SP.sDM_DonViTinh_Id_Cap2 IS NOT NULL AND  PX_CT.sDM_DonViTinh_Id=SP.sDM_DonViTinh_Id_Cap2 
                                AND SP.iKichThuocDongGoi>0 then 1 
                                else 0 end as IsShowSoSerial,SP.iKichThuocDongGoi
                                from [dbo].Phieu_NhapSuaChuaSanPham_CT PX_CT 
                                JOIN dbo.DM_SanPham SP ON PX_CT.sDM_SanPham_Id=SP.ID
                                LEFT JOIN  (SELECT sPhieu_NhapSuaChuaSanPham_CT_Id,sum(rSoLuong) as rSoLuong FROM 
								[dbo].[Phieu_NhapSuaChuaSanPham_CT]	group by sPhieu_NhapSuaChuaSanPham_CT_Id) as PNM_CT ON PX_CT.Id=PNM_CT.sPhieu_NhapSuaChuaSanPham_CT_Id
                            WHERE PX_CT.sPhieu_NhapSuaChuaSanPham_Id='{sPhieu_NhapSuaChuaSanPham_Id}'  
                            AND PX_CT.sDM_SanPham_Id='{sDM_SanPham_Id}'";
            if (sPhieu_NhapSuaChuaSanPham_CT_Id.HasValue)
            {
                query += $" AND PX_CT.Id!='{sPhieu_NhapSuaChuaSanPham_CT_Id}'";
            }
            if (sDM_DonViTinh_Id.HasValue)
            {
                query += $" AND PX_CT.sDM_DonViTinh_Id='{sDM_DonViTinh_Id}'";
            }
            return _unitOfWork.QueryFirstOrDefault<Phieu_NhapSuaChuaSanPham_CT>(query);
        }
        #region"Region"
        /// <summary>
        /// Lấy chi tiết sản phẩm gán với kế hoạch nhập mới
        /// </summary>
        /// <param name="masterId">Id của kế hoạch nhập mới</param>
        /// <returns>Danh sách chi tiết kế hoạch</returns>
        public IList GetKHXuatSuaChuaSanPham_CTsByMasterId(Guid masterId)
        {
            string query = $@"select NewId() as Id,
	            KHXSP_CT.Id as sKH_XuatSuaChuaSanPham_CT_Id, 
	            KHXSP_CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten, 
                case when SP.sDM_DonViTinh_Id_Cap2 IS NOT NULL AND  KHXSP_CT.sDM_DonViTinh_Id=SP.sDM_DonViTinh_Id_Cap2 AND SP.iKichThuocDongGoi>0 AND SP.iKichThuocDongGoi<KHXSP_CT.rSoLuong - ISNULL(PX_CT.rSoLuong,0) 
	            then SP.iKichThuocDongGoi
                else KHXSP_CT.rSoLuong - ISNULL(PX_CT.rSoLuong,0) end as rSoLuong,
                case when SP.sDM_DonViTinh_Id_Cap2 IS NOT NULL AND  KHXSP_CT.sDM_DonViTinh_Id=SP.sDM_DonViTinh_Id_Cap2 
                AND SP.iKichThuocDongGoi>0 AND SP.iKichThuocDongGoi<KHXSP_CT.rSoLuong - ISNULL(PX_CT.rSoLuong,0) then SP.iKichThuocDongGoi
                else KHXSP_CT.rSoLuong - ISNULL(PX_CT.rSoLuong,0) end * KHXSP_CT.rDonGia as  rThanhTien,
                ISNULL(KHXSP_CT.iThoiGianBaoHanh,60) as iThoiGianBaoHanh,ISNULL(KHXSP_CT.iDonViThoiGianBaoHanh,1) as iDonViThoiGianBaoHanh,
                KHXSP_CT.rDonGia,KHXSP_CT.sGhiChu,KHXSP_CT.sDM_DonViTinh_Id,DATEADD(Day,60,getdate()) as dHanBaoHanhDen
                                
	            from [dbo].KH_XuatSuaChuaSanPham_CT KHXSP_CT 
                JOIN dbo.DM_SanPham SP ON KHXSP_CT.sDM_SanPham_Id=SP.ID
                LEFT JOIN  (SELECT sKH_XuatSuaChuaSanPham_CT_Id,sum(rSoLuong) as rSoLuong FROM 
	            [dbo].[Phieu_NhapSuaChuaSanPham_CT]	group by sKH_XuatSuaChuaSanPham_CT_Id) AS PX_CT 
                ON KHXSP_CT.Id=PX_CT.sKH_XuatSuaChuaSanPham_CT_Id
                WHERE KHXSP_CT.sKH_XuatSuaChuaSanPham_Id='{masterId}' 
                AND KHXSP_CT.rSoLuong - ISNULL(PX_CT.rSoLuong,0) >0
                ORDER BY KHXSP_CT.SortOrder";
            List<Phieu_NhapSuaChuaSanPham_CT> phieuXuatSuaChuaSanPham_CTs = _unitOfWork.Query<Phieu_NhapSuaChuaSanPham_CT>(query);
            if (phieuXuatSuaChuaSanPham_CTs != null)
            {
                foreach (var item in phieuXuatSuaChuaSanPham_CTs)
                {
                    item.MTEntityState = Enummation.MTEntityState.Add;
                }
            }

            return phieuXuatSuaChuaSanPham_CTs;
        }

        /// <summary>
        /// Lấy chi tiết sản phẩm theo phiếu xuất
        /// </summary>
        /// <param name="sPhieu_NhapSuaChuaSanPham_Id">ID của phiếu xuất</param>
        /// <returns></returns>
        public List<DM_SanPham> GetPhieu_NhapSuaChuaSanPham_CTsBysPhieu_NhapSuaChuaSanPham_Id(Guid sPhieu_NhapSuaChuaSanPham_Id)
        {
            string query = $@"SELECT SP.Id,SP.sMaSanPham,SP.sTenSanPham FROM dbo.Phieu_NhapSuaChuaSanPham_CT  Phieu_CT
                              JOIN dbo.DM_SanPham SP ON Phieu_CT.sDM_SanPham_Id=SP.Id
                              WHERE sPhieu_NhapSuaChuaSanPham_Id='{sPhieu_NhapSuaChuaSanPham_Id}' ORDER BY Phieu_CT.SortOrder ";

            return _unitOfWork.Query<DM_SanPham>(query);
        }


        /// <summary>
        /// Lấy chi tiết sản phẩm theo phiếu nhập vào SC
        /// </summary>
        /// <param name="sMaSP">Mã sản phẩm</param>
        /// <returns></returns>
        public Phieu_NhapSuaChuaSanPham_CT GetPhieu_NhapSuaChuaSanPham_CTsBysPhieu_NhapSuaChuaSanPham_IdAndsMaSP(Guid sPhieu_NhapSuaChuaSanPham_Id, string sMaSP)
        {
            string query = $@"SELECT KH_CT.*
                                    ,SP.sMaSanPham
                                    ,SP.sTenSanPham as sDM_SanPham_Id_Ten
                            FROM dbo.View_Phieu_NhapSuaChuaSanPham_CT  KH_CT
                            JOIN dbo.DM_SanPham SP ON KH_CT.sDM_SanPham_Id=SP.Id
                            WHERE KH_CT.sPhieu_NhapSuaChuaSanPham_Id='{sPhieu_NhapSuaChuaSanPham_Id}' AND SP.sMaSanPham=@sMaSanPham";

            return _unitOfWork.QueryFirstOrDefault<Phieu_NhapSuaChuaSanPham_CT>(query, new { sMaSanPham = sMaSP });
        }

        /// <summary>
        /// Lấy chi tiết sản phẩm theo kế hoạch nhập mới
        /// </summary>
        /// <param name="sMaVach">Mã sản phẩm</param>
        /// <returns></returns>
        /// 
        // Note 14.6
        public Phieu_NhapSuaChuaSanPham_CT GetPhieu_NhapSuaChuaSanPham_CTBysPhieu_NhapSuaChuaSanPham_CT_IdAndsMaSP(Guid sPhieu_NhapSuaChuaSanPham_Id, string sMaVach)
        {
            string query = $@"SELECT KH_CT.Id ,SP.sMaSanPham,SP.sTenSanPham as sDM_SanPham_Id_Ten,KH_CT.rSoLuong,KH_CT.rDonGia,KH_CT.sDM_DonViTinh_Id,KH_CT.sDM_SanPham_Id, KH_CT.sMaVach
                                FROM dbo.Phieu_NhapSuaChuaSanPham_CT KH_CT
                              JOIN dbo.DM_SanPham SP ON KH_CT.sDM_SanPham_Id = SP.Id
                              WHERE KH_CT.sPhieu_NhapSuaChuaSanPham_Id = '{sPhieu_NhapSuaChuaSanPham_Id}' AND KH_CT.sMaVach= @sMaVach";


            return _unitOfWork.QueryFirstOrDefault<Phieu_NhapSuaChuaSanPham_CT>(query, new { sMaVach = sMaVach });
        }
        // Truong 14.6
        public List<Phieu_NhapSuaChuaSanPham_CT> GetAllPhieuNhapCT(Guid maDVNhap, int tcXuat, Guid maKHX) // sPhieu_XuatSuaChuaSanPham_Id
        {
            string query = $@"SELECT * 
                                FROM Phieu_NhapSuaChuaSanPham_CT AS ct 
                                inner join Phieu_NhapSuaChuaSanPham AS px on ct.sPhieu_NhapSuaChuaSanPham_Id = px.id 
                                WHERE  px.sDM_DonVi_Id_Nhap ='{maDVNhap}' 
                                and px.iLoai={tcXuat} 
                                and px.sPhieu_XuatSuaChuaSanPham_Id_CanCu='{maKHX.ToString()}'";

            return _unitOfWork.Query<Phieu_NhapSuaChuaSanPham_CT>(query);
        }

        #endregion
        #region"Sub/Func"
        /// <summary>
        /// Kiểm tra mã vạch đã tồn tại trong hệ thống chưa
        /// </summary>
        /// <param name="sMaVach">Mã vạch</param>
        /// <returns>=true Tồn tại,ngược lại chưa</returns>
        public string GetMaPhieuXuatMoi_XuatDi(string sMaVach)
        {
            string query = $@"SELECT TOP 1 P.sMa FROM Phieu_NhapSuaChuaSanPham_CT AS CT JOIN Phieu_NhapSuaChuaSanPham AS P
                                ON CT.sPhieu_NhapSuaChuaSanPham_Id=P.Id WHERE sMaVach=@sMaVach AND P.iLoai=@iLoai";
            return _unitOfWork.ExecuteScalar<string>(query, new { sMaVach = sMaVach, iLoai = (int)iLoaiPhieu.XuatSCĐi });
        }

        /// <summary>
        /// Kiểm tra mã vạch đã tồn tại trong hệ thống chưa
        /// </summary>
        /// <param name="sMaVach">Mã vạch</param>
        /// <returns>=true Tồn tại,ngược lại chưa</returns>
        public string GetMaPhieuXuatMoi_XuatTraVe(string sMaVach)
        {
            string query = $@"SELECT TOP 1 P.sMa FROM Phieu_NhapSuaChuaSanPham_CT AS CT JOIN Phieu_NhapSuaChuaSanPham AS P
                                ON CT.sPhieu_NhapSuaChuaSanPham_Id=P.Id WHERE sMaVach=@sMaVach AND P.iLoai=@iLoai";
            return _unitOfWork.ExecuteScalar<string>(query, new { sMaVach = sMaVach, iLoai = (int)iLoaiPhieu.XuatSCTraVeSauSC });
        }
        #endregion
    }
}
