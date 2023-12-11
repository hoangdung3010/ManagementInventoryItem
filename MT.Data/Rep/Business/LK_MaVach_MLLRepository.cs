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
    public class LK_MaVach_MLLRepository : MT.Data.Rep.BaseRepository<LK_MaVach_MLL>
    {
        #region "Constructor"

        public LK_MaVach_MLLRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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

        /// <summary>
        /// Lấy về MLL theo mã vạch
        /// </summary>
        /// <param name="sMaVach">Mã vạch</param>
        public LK_MaVach_MLL GetLK_MaVach_MLLByMaVach(string sMaVach)
        {
            string query = $"select * from LK_MaVach_MLL where sMaVach=@sMaVach";
            return _unitOfWork.QueryFirstOrDefault<LK_MaVach_MLL>(query, new { sMaVach = sMaVach });
        }
    }
}