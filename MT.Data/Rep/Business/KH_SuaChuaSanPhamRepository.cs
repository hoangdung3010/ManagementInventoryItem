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
    public class KH_SuaChuaSanPhamRepository : MT.Data.Rep.BaseRepository<KH_SuaChuaSanPham>
    {
        #region "Constructor"
        public KH_SuaChuaSanPhamRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public string GetViewPaging()
        {
            return $@"dbo.View_KH_SuaChuaSanPham";
        }
        #endregion

        #region"Region"

        #endregion

        #region "Overrides"
        protected override void PreSaveData(BaseEntity entity)
        {
            base.PreSaveData(entity);
            KH_SuaChuaSanPham master = (KH_SuaChuaSanPham)entity;
            master.sMa = $"{master.sSo}/{master.sChu}";

            if (master.kH_SuaChuaSanPham_CTs != null)
            {
                foreach (var item in master.kH_SuaChuaSanPham_CTs)
                {
                    KH_SuaChuaSanPham_CT kH_SuaChuaSanPham_CT = (KH_SuaChuaSanPham_CT)item;
                    if (kH_SuaChuaSanPham_CT.IsLoaded && kH_SuaChuaSanPham_CT.MTEntityState != Enummation.MTEntityState.Add)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = "DELETE FROM KH_SuaChuaSanPham_CT_PhuKien WHERE sKH_SuaChuaSanPham_CT_Id=@sKH_SuaChuaSanPham_CT_Id";

                        _unitOfWork.Execute(query, new { sKH_SuaChuaSanPham_CT_Id = kH_SuaChuaSanPham_CT.Id });
                    }
                }

            }
        }
        #endregion

        #region Sub/Func
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<KH_SuaChuaSanPham> kH_SuaChuaSanPhams, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.KH_SuaChuaSanPham SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", kH_SuaChuaSanPhams.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in kH_SuaChuaSanPhams)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "KH_SuaChuaSanPham");
            }

            return result;
        }

        /// <summary>
        /// Kiểm tra đã tồn tại phiếu xuất sửa chữa mới từ kế hoạch sửa chữa
        /// </summary>
        /// <returns>=true Tồn tại, ngược lại chưa tồn tại</returns>
        public List<string> GetPhieuXuatSuaChuasByKH(Guid id)
        {
            string query = $@"SELECT sMa from [dbo].[Phieu_XuatSuaChuaSanPham] where sKH_SuaChuaSanPham_Id_CanCu='{id}' ORDER BY sSo";
            return _unitOfWork.Query<string>(query);
        }
        #endregion
    }
}
