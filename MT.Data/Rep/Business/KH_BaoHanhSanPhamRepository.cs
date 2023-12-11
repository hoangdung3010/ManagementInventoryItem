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
    public class KH_BaoHanhSanPhamRepository : MT.Data.Rep.BaseRepository<KH_BaoHanhSanPham>
    {
        #region "Constructor"
        public KH_BaoHanhSanPhamRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public string GetViewPaging()
        {
            return $@"dbo.View_KH_BaoHanhSanPham";
        }
        #endregion

        #region"Region"

        #endregion

        #region "Overrides"
        protected override void PreSaveData(BaseEntity entity)
        {
            base.PreSaveData(entity);
            KH_BaoHanhSanPham master = (KH_BaoHanhSanPham)entity;
            master.sMa = $"{master.sSo}/{master.sChu}";

            if (master.kH_BaoHanhSanPham_CTs != null)
            {
                foreach (var item in master.kH_BaoHanhSanPham_CTs)
                {
                    KH_BaoHanhSanPham_CT kH_BaoHanhSanPham_CT = (KH_BaoHanhSanPham_CT)item;
                    if (kH_BaoHanhSanPham_CT.IsLoaded && kH_BaoHanhSanPham_CT.MTEntityState != Enummation.MTEntityState.Add)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = "DELETE FROM KH_BaoHanhSanPham_CT_PhuKien WHERE sKH_BaoHanhSanPham_CT_Id=@sKH_BaoHanhSanPham_CT_Id";

                        _unitOfWork.Execute(query, new { sKH_BaoHanhSanPham_CT_Id = kH_BaoHanhSanPham_CT.Id });
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
        public bool SaveApproveOrReject(List<KH_BaoHanhSanPham> kH_BaoHanhSanPhams, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.KH_BaoHanhSanPham SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", kH_BaoHanhSanPhams.Select(m => $"'{m.Id}'"))})";

            var result= _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in kH_BaoHanhSanPhams)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "KH_BaoHanhSanPham");
            }
            return result;
        }

        /// <summary>
        /// Kiểm tra đã tồn tại phiếu xuất sửa chữa mới từ kế hoạch sửa chữa
        /// </summary>
        /// <returns>=true Tồn tại, ngược lại chưa tồn tại</returns>
        public List<string> GetPhieuXuatBaoHanhsByKH(Guid id)
        {
            string query = $@"SELECT sMa from [dbo].[Phieu_XuatBaoHanhSanPham] where sKH_BaoHanhSanPham_Id_CanCu='{id}' ORDER BY sSo";
            return _unitOfWork.Query<string>(query);
        }
        #endregion
    }
}
