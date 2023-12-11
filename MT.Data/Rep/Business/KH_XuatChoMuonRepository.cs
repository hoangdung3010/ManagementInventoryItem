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
    public class KH_XuatChoMuonRepository : MT.Data.Rep.BaseRepository<KH_XuatChoMuon>
    {
        #region "Constructor"

        public KH_XuatChoMuonRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
            string query = $@"dbo.View_KH_XuatChoMuon";
            return query;
        }
        // 14.6
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<KH_XuatChoMuon> kH_XuatChoMuons, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.KH_XuatChoMuon SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", kH_XuatChoMuons.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in kH_XuatChoMuons)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "KH_XuatChoMuon");
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

            KH_XuatChoMuon kH_XuatChoMuon = (KH_XuatChoMuon)entity;

            kH_XuatChoMuon.sMa = $"{kH_XuatChoMuon.sSo}/{kH_XuatChoMuon.sChu}";

            if (kH_XuatChoMuon.kH_XuatChoMuon_CTs != null)
            {
                foreach (var item in kH_XuatChoMuon.kH_XuatChoMuon_CTs)
                {
                    KH_XuatChoMuon_CT kH_XuatChoMuon_CT = (KH_XuatChoMuon_CT)item;
                    if (kH_XuatChoMuon_CT.IsLoaded && kH_XuatChoMuon_CT.MTEntityState != Enummation.MTEntityState.Add)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = "DELETE FROM KH_XuatChoMuon_CT_PhuKien WHERE sKH_XuatChoMuon_CT_Id=@sKH_XuatChoMuon_CT_Id";

                        _unitOfWork.Execute(query, new { sKH_XuatChoMuon_CT_Id = kH_XuatChoMuon_CT.Id });
                    }
                }
            }
        }

        #endregion
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApprove(KH_XuatChoMuon kH_XuatChoMuon)
        {
            string query = $@"UPDATE dbo.KH_XuatChoMuon SET 
                             iTrangThaiDuyet={kH_XuatChoMuon.iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id='{kH_XuatChoMuon.Id}'";

            return _unitOfWork.Execute(query, new { sLyDoXetDuyet = kH_XuatChoMuon.sLyDoXetDuyet });
        }
    }
}