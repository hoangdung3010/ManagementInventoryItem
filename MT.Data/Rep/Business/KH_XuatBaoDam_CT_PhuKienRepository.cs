﻿using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class KH_XuatBaoDam_CT_PhuKienRepository : MT.Data.Rep.BaseRepository<KH_XuatBaoDam_CT_PhuKien>
    {
        #region "Constructor"
        public KH_XuatBaoDam_CT_PhuKienRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"
        /// <summary>
        /// Lấy danh sách phụ kiện của sản phẩm
        /// </summary>
        /// <param name="sKH_NhapSanPhamMoi_CT_Id">Id Chi tiết kế hoạch</param>
        /// <returns>Danh sách phụ kiên</returns>
        public List<KH_XuatBaoDam_CT_PhuKien> GetKH_XuatBaoDam_CT_PhuKiensBysKH_XuatBaoDam_CT_Id(Guid sKH_XuatBaoDam_CT_Id)
        {
            string query = $@"SELECT CTPK.*,PK.sTenPhuKien as sDM_PhuKien_Id_Ten FROM KH_XuatBaoDam_CT_PhuKien CTPK
                              JOIN DM_PhuKien PK ON CTPK.sDM_PhuKien_Id=PK.Id
                              WHERE sKH_XuatBaoDam_CT_Id='{sKH_XuatBaoDam_CT_Id}' ORDER BY SortOrder";

            return _unitOfWork.Query<KH_XuatBaoDam_CT_PhuKien>(query);
        }
        #endregion
    }
}
