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
    public class KH_XuatSanPhamRepository : MT.Data.Rep.BaseRepository<KH_XuatSanPham>
    {
        #region "Constructor"
        public KH_XuatSanPhamRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
            string query = $@"dbo.View_KH_XuatSanPham";
            return query;
        }
        #endregion
        #region"Overrides"

        /// <summary>
        /// trước khi lưu thực hiện xóa hết các phụ kiện đi
        /// </summary>
        /// <param name="entity"></param>
        protected override void PreSaveData(BaseEntity entity)
        {
            base.PreSaveData(entity);

            KH_XuatSanPham kH_XuatSanPham = (KH_XuatSanPham)entity;

            kH_XuatSanPham.sMa = $"{kH_XuatSanPham.sSo}/{kH_XuatSanPham.sChu}";

            if (kH_XuatSanPham.kH_XuatSanPham_CTs != null)
            {
                foreach (var item in kH_XuatSanPham.kH_XuatSanPham_CTs)
                {
                    KH_XuatSanPham_CT kH_XuatSanPham_CT = (KH_XuatSanPham_CT)item;
                    if (kH_XuatSanPham_CT.IsLoaded && kH_XuatSanPham_CT.MTEntityState != Enummation.MTEntityState.Add)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = "DELETE FROM KH_XuatSanPham_CT_PhuKien WHERE sKH_XuatSanPham_CT_Id=@sKH_XuatSanPham_CT_Id";

                        _unitOfWork.Execute(query, new { sKH_XuatSanPham_CT_Id = kH_XuatSanPham_CT.Id });
                    }
                }
            }
        }
        // Note 14.6
        /// <summary>
        /// Kiểm tra đã tồn tại phiếu nhập mới từ kế hoạch nhập mới 
        /// </summary>
        /// <returns>=true Tồn tại, ngược lại chưa tồn tại</returns>
        public List<string> GetKeHoachXuatsByKHBD(Guid id)
        {
            string query = $@"SELECT sMa from [dbo].[KH_XuatSanPham] where sKH_BaoDam_Id='{id}' ORDER BY sSo";
            return _unitOfWork.Query<string>(query);
        }

        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApprove(KH_XuatSanPham kH_XuatSanPham)
        {
            string query = $@"UPDATE dbo.KH_XuatSanPham SET 
                             iTrangThaiDuyet={kH_XuatSanPham.iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id='{kH_XuatSanPham.Id}'";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = kH_XuatSanPham.sLyDoXetDuyet });
            ManagementData.Instance.SaveChangedData(kH_XuatSanPham.Id, "KH_XuatSanPham");

            return result;
        }


        // 14.6
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<KH_XuatSanPham> kH_XuatSanPham, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.KH_XuatSanPham SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", kH_XuatSanPham.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in kH_XuatSanPham)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "KH_XuatSanPham");
            }

            return result;
        }
        #endregion
    }
}
