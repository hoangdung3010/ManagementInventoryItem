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
    public class SoKhoRepository : MT.Data.Rep.BaseRepository<SoKho>
    {
        #region "Constructor"
        public SoKhoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Sub/Func"
        /// <summary>
        /// Truy vết sản phẩm
        /// </summary>
        /// <param name="sMaVach">Mã vạch sản phẩm</param>
        /// <returns>Danh sách nhập/xuất sản phẩm</returns>
        public IList GetLichSuXuatNhapSP(string sMaVach)
        {
            string query = @"select * from dbo.SoKho where sMaVach=@sMaVach
                            ORDER BY dModifiedDate DESC";

            return _unitOfWork.Query<SoKho>(query, new { sMaVach = sMaVach });
        }


        /// <summary>
        /// Truy vết sản phẩm
        /// </summary>
        /// <param name="sMaVach">Mã vạch sản phẩm</param>
        /// <returns>Danh sách nhập/xuất sản phẩm</returns>
        public DataSet TimKiemSanPhamNangCao(ArgumentTimKiemHangHoaNangCao argumentTimKiemHangHoaNangCao)
        {
            List<string> sWhere = new List<string>();
            if (!string.IsNullOrWhiteSpace(argumentTimKiemHangHoaNangCao.sMaSanPham))
            {
                sWhere.Add($"sDM_SanPham_Ma LIKE N'%' + LTRIM(RTRIM(N'{argumentTimKiemHangHoaNangCao.sMaSanPham}')) + '%'");
            }
            if (!string.IsNullOrWhiteSpace(argumentTimKiemHangHoaNangCao.sMaVach))
            {
                sWhere.Add($"sMaVach LIKE N'%' + LTRIM(RTRIM('{argumentTimKiemHangHoaNangCao.sMaVach}')) + '%'");
            }
            if (!string.IsNullOrWhiteSpace(argumentTimKiemHangHoaNangCao.sXuatXu))
            {
                sWhere.Add($"sXuatXu LIKE N'%' + LTRIM(RTRIM(N'{argumentTimKiemHangHoaNangCao.sXuatXu}')) + '%'");
            }
            if (argumentTimKiemHangHoaNangCao.sDM_SanPham_Id.HasValue)
            {
                sWhere.Add($"sDM_SanPham_Id ='{argumentTimKiemHangHoaNangCao.sDM_SanPham_Id.Value}'");
            }
            if (argumentTimKiemHangHoaNangCao.sDM_MangLienLac_Id.HasValue)
            {
                sWhere.Add($"sDM_MangLienLac_Id ='{argumentTimKiemHangHoaNangCao.sDM_MangLienLac_Id.Value}'");
            }
            if (argumentTimKiemHangHoaNangCao.iNamSX.HasValue)
            {
                sWhere.Add($"iNamSX ={argumentTimKiemHangHoaNangCao.iNamSX}");
            }
            if (argumentTimKiemHangHoaNangCao.sDM_DonVi_Id_Xuat.HasValue)
            {
                sWhere.Add($"sDM_DonVi_Id_Xuat ='{argumentTimKiemHangHoaNangCao.sDM_DonVi_Id_Xuat.Value}'");
            }
            if (!string.IsNullOrWhiteSpace(argumentTimKiemHangHoaNangCao.sGhiChu))
            {
                sWhere.Add($"sGhiChu LIKE N'%' + LTRIM(RTRIM(N'{argumentTimKiemHangHoaNangCao.sGhiChu}')) + '%'");
            }
            string strWhere = string.Join(" AND ", sWhere);

            return _unitOfWork.QueryDataSet("Proc_TimKiemHangHoaNangCao", 
                new Dictionary<string, object>
                {
                    { "sWhere",strWhere },
                    { "iTrangThai", argumentTimKiemHangHoaNangCao .iTrangThai },
                    { "sDM_DonVi_Id_Nhap",argumentTimKiemHangHoaNangCao.sDM_DonVi_Id_Nhap }
                },commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Truy vết sản phẩm
        /// </summary>
        /// <param name="sMaVach">Mã vạch sản phẩm</param>
        /// <returns>Danh sách nhập/xuất sản phẩm</returns>
        public List<SoKho> GetTonDauKy(Guid orgId)
        {
            return _unitOfWork.Query<SoKho>("Proc_GetTonDauKy",
                new Dictionary<string, object>
                {
                    { "sDM_DonVi_Id_Nhap",orgId }
                }, commandType: CommandType.StoredProcedure);
        }


        /// <summary>
        /// Tìm xem mã vạch có tồn tại trên phiếu nhập mới nào không
        /// </summary>
        /// <param name="sMaVach">Mã vạch sản phẩm</param>
        public SoKho FindSoKhoBysMaVachAndPhieuNhapMoi(string sMaVach)
        {
            string query = "SELECT sMa FROM dbo.SoKho WHERE sMaVach=@sMaVach AND iLoaiPhieu=12";
            return _unitOfWork.QueryFirstOrDefault<SoKho>(query,
                new Dictionary<string, object>
                {
                    { "sMaVach",sMaVach }
                });
        }
        #endregion

    }
}
