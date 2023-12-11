using MT.Data.BO;
using MT.Data.ExchangeData;
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
    public class KH_CaiDatSanPhamRepository : MT.Data.Rep.BaseRepository<KH_CaiDatSanPham>
    {
        #region "Constructor"
        public KH_CaiDatSanPhamRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
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

            KH_CaiDatSanPham kh_CaiDatSanPham = (KH_CaiDatSanPham)entity;

            if (kh_CaiDatSanPham.MTEntityState == Enummation.MTEntityState.Add
                && kh_CaiDatSanPham.iTrangThaiDuyet == (int)MT.Data.iTrangThaiDuyetKHCĐSP.DongYDuyet)
            {
                //Trường hợp thêm mới và duyệt luôn
                kh_CaiDatSanPham.dNgayDuyet = SysDateTime.Instance.Now();
            }

            kh_CaiDatSanPham.sMa = $"{kh_CaiDatSanPham.sSo}/{kh_CaiDatSanPham.sChu}";

            if (kh_CaiDatSanPham.khCaiDatSanPham_CTs != null)
            {
                foreach (var item in kh_CaiDatSanPham.khCaiDatSanPham_CTs)
                {
                    KH_CaiDatSanPham_CT KH_CaiDatSanPham_CT = (KH_CaiDatSanPham_CT)item;
                    if (KH_CaiDatSanPham_CT.IsLoaded && KH_CaiDatSanPham_CT.MTEntityState != Enummation.MTEntityState.Add)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = "DELETE FROM KH_CaiDatSanPham_CT_PhuKien WHERE sKH_CaiDatSanPham_CT_Id=@sKH_CaiDatSanPham_CT_Id";

                        _unitOfWork.Execute(query, new { sKH_CaiDatSanPham_CT_Id = KH_CaiDatSanPham_CT.Id });
                    }
                }

            }
        }

        #endregion

        #region"Sub/Func"
        /// <summary>
        /// Kiểm tra đã tồn tại phiếu nhập mới từ kế hoạch nhập mới 
        /// </summary>
        /// <returns>=true Tồn tại, ngược lại chưa tồn tại</returns>
        public List<string> GetPhieuXuatCaiDatsByKHCD(Guid id)
        {
            string query = $@"SELECT sMa from [dbo].[Phieu_XuatCaiDatSanPham] where sKH_CaiDatSanPham_Id_CanCu='{id}' ORDER BY sSo";
            return _unitOfWork.Query<string>(query);
        }
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<KH_CaiDatSanPham> KH_CaiDatSanPhams, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.KH_CaiDatSanPham SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", KH_CaiDatSanPhams.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in KH_CaiDatSanPhams)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "KH_CaiDatSanPham");
            }

            return result;
        }

        #endregion
    }
}
