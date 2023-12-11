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
    public class LK_MaVach_CTSRepository : MT.Data.Rep.BaseRepository<LK_MaVach_CTS>
    {
        #region "Constructor"

        public LK_MaVach_CTSRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion "Constructor"

        /// <summary>
        /// Lấy về chứng thư số theo mã vạch
        /// </summary>
        /// <param name="sMaVach">Mã vạch</param>
        public LK_MaVach_CTS GetLK_MaVach_CTSByMaVach(string sMaVach)
        {
            string query =$"select * from LK_MaVach_CTS where sMaVach=@sMaVach";
            return _unitOfWork.QueryFirstOrDefault<LK_MaVach_CTS>(query,new { sMaVach= sMaVach });
        }
    }
}