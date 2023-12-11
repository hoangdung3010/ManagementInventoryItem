using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class Phieu_XuatSanPham_CT_PhuKienRepository : MT.Data.Rep.BaseRepository<Phieu_XuatSanPham_CT_PhuKien>
    {
        #region "Constructor"
        public Phieu_XuatSanPham_CT_PhuKienRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"
        /// <summary>
        /// Lấy danh sách phụ kiện của sản phẩm
        /// </summary>
        /// <param name="sKH_XuatSanPham_CT_Id">Id Chi tiết kế hoạch</param>
        /// <returns>Danh sách phụ kiên</returns>
        public List<KH_XuatSanPham_CT_PhuKien> GetKH_XuatSanPham_CT_PhuKiensBysKH_XuatSanPham_CT_Id(Guid sKH_XuatSanPham_CT_Id)
        {
            string query = $@"SELECT CTPK.*,PK.sTenPhuKien as sDM_PhuKien_Id_Ten FROM KH_XuatSanPham_CT_PhuKien CTPK
                              JOIN DM_PhuKien PK ON CTPK.sDM_PhuKien_Id=PK.Id
                              WHERE sKH_XuatSanPham_CT_Id='{sKH_XuatSanPham_CT_Id}' ORDER BY SortOrder";

            return _unitOfWork.Query<KH_XuatSanPham_CT_PhuKien>(query);
        }
        /// <summary>
        /// Lấy danh sách phụ kiện của sản phẩm
        /// </summary>
        /// <param name="sPhieu_XuatSanPham_CT_Id">Id Chi tiết kế hoạch</param>
        /// <returns>Danh sách phụ kiên</returns>
        public List<Phieu_XuatSanPham_CT_PhuKien> GetPhieu_XuatSanPham_CT_PhuKiensBysPhieu_XuatSanPham_CT_Id(Guid sPhieu_XuatSanPham_CT_Id)
        {
            string query = $@"SELECT CTPK.*,PK.sTenPhuKien as sDM_PhuKien_Id_Ten FROM Phieu_XuatSanPham_CT_PhuKien CTPK
                              JOIN DM_PhuKien PK ON CTPK.sDM_PhuKien_Id=PK.Id
                              WHERE sPhieu_XuatSanPham_CT_Id='{sPhieu_XuatSanPham_CT_Id}' ORDER BY SortOrder";

            return _unitOfWork.Query<Phieu_XuatSanPham_CT_PhuKien>(query);
        }
        #endregion
    }
}
