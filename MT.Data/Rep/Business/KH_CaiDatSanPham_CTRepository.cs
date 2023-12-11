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
    public class KH_CaiDatSanPham_CTRepository : MT.Data.Rep.BaseRepository<KH_CaiDatSanPham_CT>
    {
        #region "Constructor"
        public KH_CaiDatSanPham_CTRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"
        /// <summary>
        /// Kiểm tra xem sản phẩm có nằm trong kế hoạch xuất cài đặt ko
        /// </summary>
        /// <param name="sKH_CaiDatSanPham_Id_CanCu">Id của kế hoạch</param>
        /// <param name="sMaSP">Mã sản phẩm</param>
        /// <returns></returns>
       public KH_CaiDatSanPham_CT GetKH_CaiDatSanPham_CTsBysKH_CaiDatSanPham_Id_CanCuAndsMaSP(Guid sKH_CaiDatSanPham_Id_CanCu,string sMaSP)
        {
            string query = $@"SELECT CT.*,SP.sTenSanPham as sDM_SanPham_Id_Ten FROM KH_CaiDatSanPham_CT  CT
                            JOIN dbo.DM_SanPham SP ON CT.sDM_SanPham_Id=SP.Id
                            WHERE CT.sKH_CaiDatSanPham_Id='{sKH_CaiDatSanPham_Id_CanCu}' 
                            AND SP.sMaSanPham=@sMaSanPham";
            return _unitOfWork.QueryFirstOrDefault< KH_CaiDatSanPham_CT>(query, new { sMaSanPham= sMaSP });
        }

        
        #endregion

        #region"Overrides"

        #endregion
    }
}
