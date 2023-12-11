using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class KH_BaoHanhSanPham_CTRepository : MT.Data.Rep.BaseRepository<KH_BaoHanhSanPham_CT>
    {
        #region "Constructor"
        public KH_BaoHanhSanPham_CTRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"
        /// <summary>
        /// Lấy chi tiết sản phẩm theo kế hoạch nhập mới
        /// </summary>
        /// <param name="sMaSP">Mã sản phẩm</param>
        /// <returns></returns>
        public KH_BaoHanhSanPham_CT GetKH_BaoHanhSanPham_CTsBysKH_BaoHanhSanPham_IdAndsMaSP(Guid sKH_BaoHanhSanPham_Id, string sMaSP)
        {
            string query = $@"SELECT KH_CT.*
                                    ,SP.sMaSanPham
                                    ,SP.sTenSanPham as sDM_SanPham_Id_Ten
                            FROM dbo.View_KH_BaoHanhSanPham_CT  KH_CT
                            JOIN dbo.DM_SanPham SP ON KH_CT.sDM_SanPham_Id=SP.Id
                            WHERE KH_CT.sKH_BaoHanhSanPham_Id='{sKH_BaoHanhSanPham_Id}' AND SP.sMaSanPham=@sMaSanPham";

            return _unitOfWork.QueryFirstOrDefault<KH_BaoHanhSanPham_CT>(query, new { sMaSanPham = sMaSP });
        }
        #endregion
    }
}
