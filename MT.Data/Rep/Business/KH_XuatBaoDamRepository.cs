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
    public class KH_XuatBaoDamRepository : MT.Data.Rep.BaseRepository<KH_XuatBaoDam>
    {
        #region "Constructor"

        public KH_XuatBaoDamRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
            string query = $@"dbo.View_KH_XuatBaoDam";
            return query;
        }
        // 14.6
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<KH_XuatBaoDam> kH_XuatBaoDams, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.KH_XuatBaoDam SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", kH_XuatBaoDams.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in kH_XuatBaoDams)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "KH_XuatBaoDam");
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

            KH_XuatBaoDam kH_XuatBaoDam = (KH_XuatBaoDam)entity;

            kH_XuatBaoDam.sMa = $"{kH_XuatBaoDam.sSo}/{kH_XuatBaoDam.sChu}";

            if (kH_XuatBaoDam.kH_XuatBaoDam_CTs != null)
            {
                foreach (var item in kH_XuatBaoDam.kH_XuatBaoDam_CTs)
                {
                    KH_XuatBaoDam_CT kH_XuatBaoDam_CT = (KH_XuatBaoDam_CT)item;
                    if (kH_XuatBaoDam_CT.IsLoaded && kH_XuatBaoDam_CT.MTEntityState != Enummation.MTEntityState.Add)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = "DELETE FROM KH_XuatBaoDam_CT_PhuKien WHERE sKH_XuatBaoDam_CT_Id=@sKH_XuatBaoDam_CT_Id";

                        _unitOfWork.Execute(query, new { sKH_XuatBaoDam_CT_Id = kH_XuatBaoDam_CT.Id });
                    }
                }
            }
        }

        #endregion
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApprove(KH_XuatBaoDam kH_XuatBaoDam)
        {
            string query = $@"UPDATE dbo.KH_XuatBaoDam SET 
                             iTrangThaiDuyet={kH_XuatBaoDam.iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id='{kH_XuatBaoDam.Id}'";

            return _unitOfWork.Execute(query, new { sLyDoXetDuyet = kH_XuatBaoDam.sLyDoXetDuyet });
        }
    }
}