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
    public class Phieu_XuatBaoHanhSanPham_CTRepository : MT.Data.Rep.BaseRepository<Phieu_XuatBaoHanhSanPham_CT>// NOTE CHUA SUA Phieu_XuatBaoHanhSanPham_CTRepository
    {
        #region "Constructor"
        public Phieu_XuatBaoHanhSanPham_CTRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"
        /// <summary>
        /// Lấy chi tiết sản phẩm theo kế hoạch nhập mới
        /// </summary>
        /// <param name="sMaSP">Mã sản phẩm</param>
        /// <returns></returns>
        public Phieu_XuatBaoHanhSanPham_CT GetPhieu_XuatBaoHanhSanPham_CTsBysPhieu_XuatBaoHanhSanPham_IdAndsMaSP(Guid sPhieu_XuatBaoHanhSanPham_Id, string sMaSP)
        {
            string query = $@"SELECT PX_CT.*
                                    ,SP.sMaSanPham
                                    ,SP.sTenSanPham as sDM_SanPham_Id_Ten
                            FROM dbo.View_Phieu_XuatBaoHanhSanPham_CT  PX_CT
                            JOIN dbo.DM_SanPham SP ON PX_CT.sDM_SanPham_Id=SP.Id
                            WHERE PX_CT.sPhieu_XuatBaoHanhSanPham_Id='{sPhieu_XuatBaoHanhSanPham_Id}' AND SP.sMaSanPham=@sMaSanPham";

            return _unitOfWork.QueryFirstOrDefault<Phieu_XuatBaoHanhSanPham_CT>(query, new { sMaSanPham = sMaSP });
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
            string query = $@"SELECT TOP 1 P.sMa FROM Phieu_XuatBaoHanhSanPham_CT AS CT JOIN Phieu_XuatBaoHanhSanPham AS P
                                ON CT.sPhieu_XuatBaoHanhSanPham_Id=P.Id WHERE sMaVach=@sMaVach 
                                AND P.sDM_DonVi_Id_Xuat = '{MT.Library.SessionData.OrganizationUnitId}'
                                AND P.iLoai=@iLoai";
            return _unitOfWork.ExecuteScalar<string>(query, new { sMaVach = sMaVach, iLoai = (int)iLoaiPhieu.XuatSCĐi });
        }

        /// <summary>
        /// Kiểm tra mã vạch đã tồn tại trong hệ thống chưa
        /// </summary>
        /// <param name="sMaVach">Mã vạch</param>
        /// <returns>=true Tồn tại,ngược lại chưa</returns>
        public string GetMaPhieuXuatMoi_XuatTraVe(string sMaVach)
        {
            string query = $@"SELECT TOP 1 P.sMa FROM Phieu_XuatBaoHanhSanPham_CT AS CT JOIN Phieu_XuatBaoHanhSanPham AS P
                                ON CT.sPhieu_XuatBaoHanhSanPham_Id=P.Id WHERE sMaVach=@sMaVach 
                                AND P.sDM_DonVi_Id_Xuat = '{MT.Library.SessionData.OrganizationUnitId}'
                                AND P.iLoai=@iLoai";
            return _unitOfWork.ExecuteScalar<string>(query, new { sMaVach = sMaVach, iLoai = (int)iLoaiPhieu.XuatSCTraVeSauSC });
        }

        public List<Phieu_XuatBaoHanhSanPham_CT> GetAllPhieuXuatCT(Guid maDVXuat, int tcXuat, Guid maKHX)
        {
            string query = $@"SELECT * FROM Phieu_XuatBaoHanhSanPham_CT AS ct 
                                INNER JOIN Phieu_XuatBaoHanhSanPham AS px ON ct.sPhieu_XuatBaoHanhSanPham_Id = px.id 
                                WHERE  px.sDM_DonVi_Id_Xuat ='{maDVXuat}' 
                                AND px.iLoai= {tcXuat} 
                                AND px.sKH_BaoHanhSanPham_Id_CanCu='{maKHX}'";

            return _unitOfWork.Query<Phieu_XuatBaoHanhSanPham_CT>(query);
        }
        #endregion
    }
}
