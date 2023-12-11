using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.BO;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MT.Data.Rep
{
    public class Phieu_XuatCaiDatSanPham_CT_PhuKienRepository : MT.Data.Rep.BaseRepository<Phieu_XuatCaiDatSanPham_CT_PhuKien>
    {
        #region "Constructor"
        public Phieu_XuatCaiDatSanPham_CT_PhuKienRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"
        /// <summary>
        /// Lấy danh sách phụ kiện của sản phẩm
        /// </summary>
        /// <param name="sKH_CaiDatSanPham_CT_Id">Id Chi tiết PX</param>
        /// <returns>Danh sách phụ kiên</returns>
        public List<Phieu_XuatCaiDatSanPham_CT_PhuKien> GetPhieu_XuatCaiDatSanPham_CT_PhuKiensByKH_CaiDatSanPham_CT_Id(Guid sPhieu_XuatCaiDatSanPham_CT_Id)
        {
            string query = $@"SELECT CTPK.*,PK.sTenPhuKien as sDM_PhuKien_Id_Ten FROM Phieu_XuatCaiDatSanPham_CT_PhuKien CTPK
                              JOIN DM_PhuKien PK ON CTPK.sDM_PhuKien_Id=PK.Id
                              WHERE sPhieu_XuatCaiDatSanPham_CT_Id='{sPhieu_XuatCaiDatSanPham_CT_Id}' ORDER BY SortOrder";

            return _unitOfWork.Query<Phieu_XuatCaiDatSanPham_CT_PhuKien>(query);
        }

        #endregion

        #region"Overrides"

        #endregion
    }
}
