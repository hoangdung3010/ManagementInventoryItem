using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class DM_PhuKienRepository : MT.Data.Rep.BaseRepository<DM_PhuKien>
    {
        #region "Constructor"
        public DM_PhuKienRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"
        public List<DM_PhuKien> GetPhuKiensBysDM_SanPham_Id(Guid Id)
        {
            string query = $@"SELECT * FROM View_DM_PhuKien WHERE sDM_SanPham_Id = @Id ORDER BY SortOrder";

            List<DM_PhuKien> dM_PhuKiens = _unitOfWork.Query<DM_PhuKien>(query, new { Id = Id });
            return dM_PhuKiens;
        }

        #endregion
    }
}
