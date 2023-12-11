using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class Phieu_XuatBaoHanhSanPham_CT_PhuKienRepository : MT.Data.Rep.BaseRepository<Phieu_XuatBaoHanhSanPham_CT_PhuKien>
    {
        #region "Constructor"
        public Phieu_XuatBaoHanhSanPham_CT_PhuKienRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"
        /// <summary>
        /// Lấy danh sách phụ kiện của sản phẩm
        /// </summary>
        /// <param name="sKH_XuatBaoHanhSanPham_CT_Id">Id Chi tiết kế hoạch</param>
        /// <returns>Danh sách phụ kiên</returns>
        public List<KH_BaoHanhSanPham_CT_PhuKien> GetKH_XuatBaoHanhSanPham_CT_PhuKiensBysKH_XuatBaoHanhSanPham_CT_Id(Guid sKH_XuatBaoHanhSanPham_CT_Id)
        {
            string query = $@"SELECT CTPK.*,PK.sTenPhuKien as sDM_PhuKien_Id_Ten FROM KH_XuatBaoHanhSanPham_CT_PhuKien CTPK
                              JOIN DM_PhuKien PK ON CTPK.sDM_PhuKien_Id=PK.Id
                              WHERE sKH_BaoHanhSanPham_CT_Id='{sKH_XuatBaoHanhSanPham_CT_Id}' ORDER BY SortOrder";

            return _unitOfWork.Query<KH_BaoHanhSanPham_CT_PhuKien>(query);
        }
        /// <summary>
        /// Lấy danh sách phụ kiện của sản phẩm
        /// </summary>
        /// <param name="sPhieu_XuatBaoHanhSanPham_CT_Id">Id Chi tiết kế hoạch</param>
        /// <returns>Danh sách phụ kiên</returns>
        public List<Phieu_XuatBaoHanhSanPham_CT_PhuKien> GetPhieu_XuatBaoHanhSanPham_CT_PhuKiensBysPhieu_XuatBaoHanhSanPham_CT_Id(Guid sPhieu_XuatBaoHanhSanPham_CT_Id)
        {
            string query = $@"SELECT CTPK.*,PK.sTenPhuKien as sDM_PhuKien_Id_Ten FROM Phieu_XuatBaoHanhSanPham_CT_PhuKien CTPK
                              JOIN DM_PhuKien PK ON CTPK.sDM_PhuKien_Id=PK.Id
                              WHERE sPhieu_XuatBaoHanhSanPham_CT_Id='{sPhieu_XuatBaoHanhSanPham_CT_Id}' ORDER BY SortOrder";

            return _unitOfWork.Query<Phieu_XuatBaoHanhSanPham_CT_PhuKien>(query);
        }
        #endregion
    }
}
