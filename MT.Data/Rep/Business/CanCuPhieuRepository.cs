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
    public class CanCuPhieuRepository : MT.Data.Rep.BaseRepository<CanCuPhieu>
    {
        #region "Constructor"

        public CanCuPhieuRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion "Constructor"

        /// <summary>
        /// Lấy về danh sách phiếu được tham chiếu
        /// </summary>
        /// <param name="id">Id của căn cứ</param>
        public List<CanCuPhieu> GetThamChieuDenPhieu(Guid id)
        {
            string query =$"select * from CanCuPhieu where sCanCuId='{id}'";

            return _unitOfWork.Query<CanCuPhieu>(query);
        }
    }
}