using MT.Data.BO;
using MT.Data.ExchangeData;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MT.Data.Rep
{
    public class KH_XuatTHTHRepository : MT.Data.Rep.BaseRepository<KH_XuatTHTH>
    {
        #region "Constructor"

        public KH_XuatTHTHRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion "Constructor"

        #region"Region"

        /// <summary>
        /// Lấy về view của màn hình KH nhập sản phẩm mới
        /// </summary>
        /// <returns></returns>
        public string GetViewPaging()
        {
            string query = $@"dbo.View_KH_XuatTHTH";
            return query;
        }
        // 14.6
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<KH_XuatTHTH> kH_XuatTHTHs, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.KH_XuatTHTH SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", kH_XuatTHTHs.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in kH_XuatTHTHs)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "KH_XuatTHTH");
            }

            return result;
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

            KH_XuatTHTH kH_XuatTHTH = (KH_XuatTHTH)entity;

            kH_XuatTHTH.sMa = $"{kH_XuatTHTH.sSo}/{kH_XuatTHTH.sChu}";

            if (kH_XuatTHTH.kH_XuatTHTH_CTs != null)
            {
                foreach (var item in kH_XuatTHTH.kH_XuatTHTH_CTs)
                {
                    KH_XuatTHTH_CT kH_XuatTHTH_CT = (KH_XuatTHTH_CT)item;
                    if (kH_XuatTHTH_CT.IsLoaded && kH_XuatTHTH_CT.MTEntityState != Enummation.MTEntityState.Add)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = "DELETE FROM KH_XuatTHTH_CT_PhuKien WHERE sKH_XuatTHTH_CT_Id=@sKH_XuatTHTH_CT_Id";

                        _unitOfWork.Execute(query, new { sKH_XuatTHTH_CT_Id = kH_XuatTHTH_CT.Id });
                    }
                }
            }
        }

        #endregion
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApprove(KH_XuatTHTH kH_XuatTHTH)
        {
            string query = $@"UPDATE dbo.KH_XuatTHTH SET 
                             iTrangThaiDuyet={kH_XuatTHTH.iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id='{kH_XuatTHTH.Id}'";

            return _unitOfWork.Execute(query, new { sLyDoXetDuyet = kH_XuatTHTH.sLyDoXetDuyet });
        }
    }
}