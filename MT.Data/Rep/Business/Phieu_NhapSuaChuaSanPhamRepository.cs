using MT.Data.BO;
using MT.Data.ExchangeData;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MT.Data.Rep
{
    public class Phieu_NhapSuaChuaSanPhamRepository : MT.Data.Rep.BaseRepository<Phieu_NhapSuaChuaSanPham>
    {
        #region "Constructor"
        public Phieu_NhapSuaChuaSanPhamRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion


        #region"Region"
        /// <summary>
        /// Lấy về view của màn hình KH nhập sản phẩm mới
        /// </summary>
        /// <returns></returns>
        public string GetViewPaging()
        {
            string query = $@"dbo.View_Phieu_NhapSuaChuaSanPham";
            return query;
        }
        #endregion


        #region "Overrides"
        /// <summary>
        /// trước khi lưu thực hiện 
        /// </summary>
        /// <param name="entity"></param>
        protected override void PreSaveData(BaseEntity entity)
        {
            base.PreSaveData(entity);

            Phieu_NhapSuaChuaSanPham phieu_NhapSuaChuaSanPham = (Phieu_NhapSuaChuaSanPham)entity;

            phieu_NhapSuaChuaSanPham.sMa = $"{phieu_NhapSuaChuaSanPham.sSo}/{phieu_NhapSuaChuaSanPham.sChu}";

            if (phieu_NhapSuaChuaSanPham.sPhieu_XuatSuaChuaSanPham_Id_CanCu.HasValue)
            {
                Phieu_XuatSuaChuaSanPham phieu_XuatSuaChuaSanPham = GetDataByID<Phieu_XuatSuaChuaSanPham>("Phieu_XuatSuaChuaSanPham",
                    phieu_NhapSuaChuaSanPham.sPhieu_XuatSuaChuaSanPham_Id_CanCu, "sMa,sSo,sChu");

                if (phieu_XuatSuaChuaSanPham != null)
                {
                    phieu_NhapSuaChuaSanPham.sMa_PX = phieu_XuatSuaChuaSanPham.sMa;
                    phieu_NhapSuaChuaSanPham.sSo_PX = phieu_XuatSuaChuaSanPham.sSo;
                    phieu_NhapSuaChuaSanPham.sChu_PX = phieu_XuatSuaChuaSanPham.sChu;
                }
            }
        }

        protected override void AfterSave(BaseEntity entity)
        {
            base.AfterSave(entity);
            string query = $@"UPDATE dbo.Phieu_NhapSuaChuaSanPham
                                SET rThanhTien=(SELECT SUM(rThanhTien) 
                                                FROM dbo.Phieu_NhapSuaChuaSanPham_CT
                                                WHERE sPhieu_NhapSuaChuaSanPham_Id=@Id)
                                WHERE Id=@Id";

            _unitOfWork.Execute(query, new { Id = entity.GetIdentity() });
        }
        #endregion


        #region Sub/Func
        //// Note 14.6
        ///// <summary>
        ///// Kiểm tra đã tồn tại phiếu xuất từ kế hoạch xuất 
        ///// </summary>
        ///// <returns>=true Tồn tại, ngược lại chưa tồn tại</returns>
        //public List<string> GetPhieuNhapsByPhX(Guid id)
        //{
        //    string query = $@"SELECT sMa from [dbo].[Phieu_NhapSuaChuaSanPham] where sPhieu_NhapSuaChuaSanPham_Id_CanCu='{id}' ORDER BY sSo";
        //    return _unitOfWork.Query<string>(query);
        //}

        // 14.6
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<Phieu_NhapSuaChuaSanPham> ph_NhapSuaChuaSanPham, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.Phieu_NhapSuaChuaSanPham SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", ph_NhapSuaChuaSanPham.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in ph_NhapSuaChuaSanPham)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "Phieu_NhapSuaChuaSanPham");
            }

            return result;
        }
        #endregion
    }
}
