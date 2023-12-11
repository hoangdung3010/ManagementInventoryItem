using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class KH_SuaChuaSanPham_CTRepository : MT.Data.Rep.BaseRepository<KH_SuaChuaSanPham_CT>
    {
        #region "Constructor"
        public KH_SuaChuaSanPham_CTRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"
        /// <summary>
        /// Lấy chi tiết sản phẩm theo kế hoạch nhập mới
        /// </summary>
        /// <param name="sMaSP">Mã sản phẩm</param>
        /// <returns></returns>
        public KH_SuaChuaSanPham_CT GetKH_SuaChuaSanPham_CTsBysKH_SuaChuaSanPham_IdAndsMaSP(Guid sKH_SuaChuaSanPham_Id, string sMaSP)
        {
            string query = $@"SELECT KH_CT.*
                                    ,SP.sMaSanPham
                                    ,SP.sTenSanPham as sDM_SanPham_Id_Ten
                            FROM dbo.View_KH_SuaChuaSanPham_CT  KH_CT
                            JOIN dbo.DM_SanPham SP ON KH_CT.sDM_SanPham_Id=SP.Id
                            WHERE KH_CT.sKH_SuaChuaSanPham_Id='{sKH_SuaChuaSanPham_Id}' AND SP.sMaSanPham=@sMaSanPham";

            return _unitOfWork.QueryFirstOrDefault<KH_SuaChuaSanPham_CT>(query, new { sMaSanPham = sMaSP });
        }
        #endregion
    }
}
