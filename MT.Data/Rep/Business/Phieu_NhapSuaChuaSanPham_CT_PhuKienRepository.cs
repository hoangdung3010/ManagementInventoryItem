using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class Phieu_NhapSuaChuaSanPham_CT_PhuKienRepository : MT.Data.Rep.BaseRepository<Phieu_NhapSuaChuaSanPham_CT_PhuKien>
    {
        #region "Constructor"
        public Phieu_NhapSuaChuaSanPham_CT_PhuKienRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"
        /// <summary>
        /// Lấy danh sách phụ kiện của sản phẩm
        /// </summary>
        /// <param name="sKH_NhapSuaChuaSanPham_CT_Id">Id Chi tiết kế hoạch</param>
        /// <returns>Danh sách phụ kiên</returns>
        public List<KH_SuaChuaSanPham_CT_PhuKien> GetKH_NhapSuaChuaSanPham_CT_PhuKiensBysKH_NhapSuaChuaSanPham_CT_Id(Guid sKH_NhapSuaChuaSanPham_CT_Id)
        {
            string query = $@"SELECT CTPK.*,PK.sTenPhuKien as sDM_PhuKien_Id_Ten FROM KH_NhapSuaChuaSanPham_CT_PhuKien CTPK
                              JOIN DM_PhuKien PK ON CTPK.sDM_PhuKien_Id=PK.Id
                              WHERE sKH_SuaChuaSanPham_CT_Id='{sKH_NhapSuaChuaSanPham_CT_Id}' ORDER BY SortOrder";

            return _unitOfWork.Query<KH_SuaChuaSanPham_CT_PhuKien>(query);
        }
        /// <summary>
        /// Lấy danh sách phụ kiện của sản phẩm
        /// </summary>
        /// <param name="sPhieu_NhapSuaChuaSanPham_CT_Id">Id Chi tiết kế hoạch</param>
        /// <returns>Danh sách phụ kiên</returns>
        public List<Phieu_NhapSuaChuaSanPham_CT_PhuKien> GetPhieu_NhapSuaChuaSanPham_CT_PhuKiensBysPhieu_NhapSuaChuaSanPham_CT_Id(Guid sPhieu_NhapSuaChuaSanPham_CT_Id)
        {
            string query = $@"SELECT CTPK.*
                                        ,PK.sTenPhuKien as sDM_PhuKien_Id_Ten 
                                FROM View_Phieu_NhapSuaChuaSanPham_CT_PhuKien CTPK
                              JOIN DM_PhuKien PK ON CTPK.sDM_PhuKien_Id=PK.Id
                              WHERE sPhieu_NhapSuaChuaSanPham_CT_Id='{sPhieu_NhapSuaChuaSanPham_CT_Id}' ORDER BY SortOrder";

            return _unitOfWork.Query<Phieu_NhapSuaChuaSanPham_CT_PhuKien>(query);
        }
        #endregion
    }
}
