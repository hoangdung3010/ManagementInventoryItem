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
    public class Phieu_NhapCaiDatSanPham_CT_PhuKienRepository : MT.Data.Rep.BaseRepository<Phieu_NhapCaiDatSanPham_CT_PhuKien>
    {
        #region "Constructor"
        public Phieu_NhapCaiDatSanPham_CT_PhuKienRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"

        #endregion

        #region"Overrides"
        /// <summary>
        /// Lấy danh sách phụ kiện của sản phẩm
        /// </summary>
        /// <param name="sPhieu_NhapCaiDatSanPham_CT_Id">Id Chi tiết kế hoạch</param>
        /// <returns>Danh sách phụ kiên</returns>
        public List<Phieu_NhapCaiDatSanPham_CT_PhuKien> GetPhieu_NhapCaiDatSanPham_CT_PhuKiensBysPhieu_NhapCaiDatSanPham_CT_Id(Guid sPhieu_NhapCaiDatSanPham_CT_Id)
        {
            string query = $@"SELECT CTPK.*,PK.sTenPhuKien as sDM_PhuKien_Id_Ten FROM Phieu_NhapCaiDatSanPham_CT_PhuKien CTPK
                              JOIN DM_PhuKien PK ON CTPK.sDM_PhuKien_Id=PK.Id
                              WHERE sPhieu_NhapCaiDatSanPham_CT_Id='{sPhieu_NhapCaiDatSanPham_CT_Id}' ORDER BY SortOrder";

            return _unitOfWork.Query<Phieu_NhapCaiDatSanPham_CT_PhuKien>(query);
        }
        #endregion
    }
}
