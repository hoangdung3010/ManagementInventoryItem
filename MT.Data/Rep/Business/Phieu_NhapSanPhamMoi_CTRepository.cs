using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class Phieu_NhapSanPhamMoi_CTRepository : MT.Data.Rep.BaseRepository<Phieu_NhapSanPhamMoi_CT>
    {
        #region "Constructor"
        public Phieu_NhapSanPhamMoi_CTRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion


        #region"Sub/Func"
        /// <summary>
        /// Kiểm tra mã vạch đã tồn tại trong hệ thống chưa
        /// </summary>
        /// <param name="sMaVach">Mã vạch</param>
        /// <returns>=true Tồn tại,ngược lại chưa</returns>
        public string GetMaPhieuNhapMoi(string sMaVach,object sPhieuId)
        {
            string query = $@"SELECT TOP 1 P.sMa FROM Phieu_NhapSanPhamMoi_CT AS CT JOIN Phieu_NhapSanPhamMoi AS P
                                ON CT.sPhieu_NhapSanPhamMoi_Id=P.Id 
                                WHERE sMaVach=@sMaVach AND (P.Id<>@Id OR @Id IS NULL OR @Id='{Guid.Empty}')";
            return _unitOfWork.ExecuteScalar<string>(query, new { sMaVach = sMaVach, Id= sPhieuId });
        }
        #endregion
    }
}
