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
    public class Phieu_NhapBaoHanhSanPhamRepository : MT.Data.Rep.BaseRepository<Phieu_NhapBaoHanhSanPham>
    {
        #region "Constructor"
        public Phieu_NhapBaoHanhSanPhamRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
            string query = $@"dbo.View_Phieu_NhapBaoHanhSanPham";
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

            Phieu_NhapBaoHanhSanPham phieu_NhapBaoHanhSanPham = (Phieu_NhapBaoHanhSanPham)entity;

            phieu_NhapBaoHanhSanPham.sMa = $"{phieu_NhapBaoHanhSanPham.sSo}/{phieu_NhapBaoHanhSanPham.sChu}";

            if (phieu_NhapBaoHanhSanPham.sPhieu_XuatBaoHanhSanPham_Id_CanCu.HasValue)
            {
                Phieu_XuatBaoHanhSanPham phieu_XuatBaoHanhSanPham = GetDataByID<Phieu_XuatBaoHanhSanPham>("Phieu_XuatBaoHanhSanPham",
                    phieu_NhapBaoHanhSanPham.sPhieu_XuatBaoHanhSanPham_Id_CanCu, "sMa,sSo,sChu");

                if (phieu_XuatBaoHanhSanPham != null)
                {
                    phieu_NhapBaoHanhSanPham.sMa_PX = phieu_XuatBaoHanhSanPham.sMa;
                    phieu_NhapBaoHanhSanPham.sSo_PX = phieu_XuatBaoHanhSanPham.sSo;
                    phieu_NhapBaoHanhSanPham.sChu_PX = phieu_XuatBaoHanhSanPham.sChu;
                }
            }
        }

        protected override void AfterSave(BaseEntity entity)
        {
            base.AfterSave(entity);
            string query = $@"UPDATE dbo.Phieu_NhapBaoHanhSanPham
                                SET rThanhTien=(SELECT SUM(rThanhTien) 
                                                FROM dbo.Phieu_NhapBaoHanhSanPham_CT
                                                WHERE sPhieu_NhapBaoHanhSanPham_Id=@Id)
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
        //    string query = $@"SELECT sMa from [dbo].[Phieu_NhapBaoHanhSanPham] where sPhieu_NhapBaoHanhSanPham_Id_CanCu='{id}' ORDER BY sSo";
        //    return _unitOfWork.Query<string>(query);
        //}

        // 14.6
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<Phieu_NhapBaoHanhSanPham> ph_NhapBaoHanhSanPham, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.Phieu_NhapBaoHanhSanPham SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", ph_NhapBaoHanhSanPham.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in ph_NhapBaoHanhSanPham)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "Phieu_NhapBaoHanhSanPham");
            }

            return result;
        }
        #endregion
    }
}
