using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class Phieu_XuatTHTH_CT_PhuKienRepository : MT.Data.Rep.BaseRepository<Phieu_XuatTHTH_CT_PhuKien>
    {
        #region "Constructor"

        public Phieu_XuatTHTH_CT_PhuKienRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion "Constructor"

        #region"Region"

        /// <summary>
        /// Lấy danh sách phụ kiện của sản phẩm
        /// </summary>
        /// <param name="sKH_XuatTHTH_CT_Id">Id Chi tiết kế hoạch</param>
        /// <returns>Danh sách phụ kiên</returns>
        public List<KH_XuatTHTH_CT_PhuKien> GetKH_XuatTHTH_CT_PhuKiensBysKH_XuatTHTH_CT_Id(Guid sKH_XuatTHTH_CT_Id)
        {
            string query = $@"SELECT CTPK.*,PK.sTenPhuKien as sDM_PhuKien_Id_Ten FROM KH_XuatTHTH_CT_PhuKien CTPK
                              JOIN DM_PhuKien PK ON CTPK.sDM_PhuKien_Id=PK.Id
                              WHERE sKH_XuatTHTH_CT_Id='{sKH_XuatTHTH_CT_Id}' ORDER BY SortOrder";
            /*string query = $@"SELECT * FROM View_KH_XuatTHTH_CT_PhuKien CTPK
                              WHERE sKH_XuatTHTH_CT_Id='{sKH_XuatTHTH_CT_Id}' ORDER BY SortOrder";*/

            return _unitOfWork.Query<KH_XuatTHTH_CT_PhuKien>(query);
        }

        /// <summary>
        /// Lấy danh sách phụ kiện của sản phẩm
        /// </summary>
        /// <param name="sPhieu_XuatTHTH_CT_Id">Id Chi tiết kế hoạch</param>
        /// <returns>Danh sách phụ kiên</returns>
        public List<Phieu_XuatTHTH_CT_PhuKien> GetPhieu_XuatTHTH_CT_PhuKiensBysPhieu_XuatTHTH_CT_Id(Guid sPhieu_XuatTHTH_CT_Id)
        {
            string query = $@"SELECT CTPK.*,PK.sTenPhuKien as sDM_PhuKien_Id_Ten FROM Phieu_XuatTHTH_CT_PhuKien CTPK
                              JOIN DM_PhuKien PK ON CTPK.sDM_PhuKien_Id=PK.Id
                              WHERE sPhieu_XuatTHTH_CT_Id='{sPhieu_XuatTHTH_CT_Id}' ORDER BY SortOrder";

            return _unitOfWork.Query<Phieu_XuatTHTH_CT_PhuKien>(query);
        }

        #endregion
    }
}