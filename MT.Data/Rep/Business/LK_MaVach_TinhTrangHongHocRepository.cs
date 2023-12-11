using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MT.Data.Rep
{
    public class LK_MaVach_TinhTrangHongHocRepository : MT.Data.Rep.BaseRepository<LK_MaVach_TinhTrangHongHoc>
    {
        #region "Constructor"

        public LK_MaVach_TinhTrangHongHocRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion "Constructor"

        /// <summary>
        /// Lấy về nội dung cài đặt theo mã vạch
        /// </summary>
        /// <param name="sMaVach">Mã vạch</param>
        public LK_MaVach_TinhTrangHongHoc GetTinhTrangCaiDat_ByMaVach(String sMaVach, int iLoai)
        {
            string query = $@"SELECT TOP 1   
                                        phct.sDM_NoiDungCaiDat_Id
                                        ,phct.sTinhTrangCaiDat
                                FROM Phieu_NhapCaiDatSanPham_CT phct
                                INNER JOIN Phieu_NhapCaiDatSanPham ph ON phct.sPhieu_NhapCaiDatSanPham_Id = ph.Id
                                WHERE phct.sMaVach =  @sMaVach
                                AND sDM_DonVi_Id_Nhap = '{MT.Library.SessionData.OrganizationUnitId}'
                                AND iLoai =  {iLoai}
                                ORDER BY phct.dCreatedDate DESC";
            return _unitOfWork.QueryFirstOrDefault<LK_MaVach_TinhTrangHongHoc>(query, new { sMaVach = sMaVach });
        }

        /// <summary>
        /// Lấy về tình trạng hỏng hóc theo mã vạch
        /// </summary>
        /// <param name="sMaVach">Mã vạch</param>

        public LK_MaVach_TinhTrangHongHoc GetTinhTrangSuaChua_ByMaVach(String sMaVach, int iLoai)
        {
            string query = $@"SELECT TOP 1   
                                        phct.sDM_NoiDungSuaChua_Id
                                        ,phct.sDM_TinhTrangHongHoc_Id  
                                FROM Phieu_NhapSuaChuaSanPham_CT phct
                                INNER JOIN Phieu_NhapSuaChuaSanPham ph ON phct.sPhieu_NhapSuaChuaSanPham_Id = ph.Id
                                WHERE phct.sMaVach =  @sMaVach
                                AND sDM_DonVi_Id_Nhap = '{MT.Library.SessionData.OrganizationUnitId}'
                                AND iLoai =  {iLoai}
                                ORDER BY phct.dCreatedDate DESC";
            return _unitOfWork.QueryFirstOrDefault<LK_MaVach_TinhTrangHongHoc>(query, new { sMaVach = sMaVach });
        }
        /// <summary>
        /// Lấy về tình trạng hỏng hóc theo mã vạch
        /// </summary>
        /// <param name="sMaVach">Mã vạch</param>
        public LK_MaVach_TinhTrangHongHoc GetTinhTrangBaoHanh_ByMaVach(String sMaVach, int iLoai)
        {
            string query = $@"SELECT TOP 1   
                                        phct.sDM_NoiDungBaoHanh_Id
                                        ,phct.sDM_TinhTrangHongHoc_Id  
                                FROM Phieu_NhapBaoHanhSanPham_CT phct
                                INNER JOIN Phieu_NhapBaoHanhSanPham ph ON phct.sPhieu_NhapBaoHanhSanPham_Id = ph.Id
                                WHERE phct.sMaVach =  @sMaVach
                                AND sDM_DonVi_Id_Nhap = '{MT.Library.SessionData.OrganizationUnitId}'
                                AND iLoai =  {iLoai}
                                ORDER BY phct.dCreatedDate DESC";
            return _unitOfWork.QueryFirstOrDefault<LK_MaVach_TinhTrangHongHoc>(query, new { sMaVach = sMaVach });
        }
    }
}