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
    public class KH_XuatMuonTraRepository : MT.Data.Rep.BaseRepository<KH_XuatMuonTra>
    {
        #region "Constructor"

        public KH_XuatMuonTraRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
            string query = $@"dbo.View_KH_XuatMuonTra";
            return query;
        }
        // 14.6
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<KH_XuatMuonTra> kH_XuatMuonTras, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.KH_XuatMuonTra SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", kH_XuatMuonTras.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in kH_XuatMuonTras)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "KH_XuatMuonTra");
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

            KH_XuatMuonTra kH_XuatMuonTra = (KH_XuatMuonTra)entity;

            kH_XuatMuonTra.sMa = $"{kH_XuatMuonTra.sSo}/{kH_XuatMuonTra.sChu}";

            if (kH_XuatMuonTra.kH_XuatMuonTra_CTs != null)
            {
                foreach (var item in kH_XuatMuonTra.kH_XuatMuonTra_CTs)
                {
                    KH_XuatMuonTra_CT kH_XuatMuonTra_CT = (KH_XuatMuonTra_CT)item;
                    if (kH_XuatMuonTra_CT.IsLoaded && kH_XuatMuonTra_CT.MTEntityState != Enummation.MTEntityState.Add)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = "DELETE FROM KH_XuatMuonTra_CT_PhuKien WHERE sKH_XuatMuonTra_CT_Id=@sKH_XuatMuonTra_CT_Id";

                        _unitOfWork.Execute(query, new { sKH_XuatMuonTra_CT_Id = kH_XuatMuonTra_CT.Id });
                    }
                }
            }
        }

        #endregion
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApprove(KH_XuatMuonTra kH_XuatMuonTra)
        {
            string query = $@"UPDATE dbo.KH_XuatMuonTra SET 
                             iTrangThaiDuyet={kH_XuatMuonTra.iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id='{kH_XuatMuonTra.Id}'";

            return _unitOfWork.Execute(query, new { sLyDoXetDuyet = kH_XuatMuonTra.sLyDoXetDuyet });
        }
    }
}