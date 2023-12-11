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
    public class Phieu_NhapTHTHRepository : MT.Data.Rep.BaseRepository<Phieu_NhapTHTH>
    {
        #region "Constructor"
        public Phieu_NhapTHTHRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Sub/Func"
        /// <summary>
        /// Lấy về view của màn hình KH nhập sản phẩm mới
        /// </summary>
        /// <returns></returns>
        public string GetViewPaging()
        {
            string query = $@"dbo.View_Phieu_NhapTHTH";
            return query;
        }
        #endregion

        /// <summary>
        /// trước khi lưu thực hiện xóa hết các phụ kiện đi
        /// </summary>
        /// <param name="entity"></param>
        protected override void PreSaveData(BaseEntity entity)
        {
            base.PreSaveData(entity);

            Phieu_NhapTHTH phieu_NhapTHTH = (Phieu_NhapTHTH)entity;

            phieu_NhapTHTH.sMa = $"{phieu_NhapTHTH.sSo}/{phieu_NhapTHTH.sChu}";

            if (phieu_NhapTHTH.phieu_NhapTHTH_CTs != null)
            {
                foreach (var item in phieu_NhapTHTH.phieu_NhapTHTH_CTs)
                {
                    Phieu_NhapTHTH_CT phieu_NhapTHTH_CT = (Phieu_NhapTHTH_CT)item;
                    if (phieu_NhapTHTH_CT.IsLoaded && phieu_NhapTHTH_CT.MTEntityState != Enummation.MTEntityState.Add)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = "DELETE FROM Phieu_NhapTHTH_CT_PhuKien WHERE sPhieu_NhapTHTH_CT_Id=@sPhieu_NhapTHTH_CT_Id";

                        _unitOfWork.Execute(query, new { sPhieu_NhapTHTH_CT_Id = phieu_NhapTHTH_CT.Id });
                    }
                }
            }
        }
        // Note 14.6
        /// <summary>
        /// PHIẾU NHẬP SẼ ĐƯỢC SỬ DỤNG BỞI KẾ HOẠCH HAY PHIẾU XUẤT NÀO? 
        /// </summary>
        /// <returns>=true Tồn tại, ngược lại chưa tồn tại</returns>
        //public List<string> GetPhieuXuatsByPhN(Guid id)
        //{
        //    string query = $@"SELECT sMa from [dbo].[Phieu_XuatSanPham] where sPhieu_NhapTHTH_Id_CanCu='{id}' ORDER BY sSo";
        //    return _unitOfWork.Query<string>(query);
        //}

        // 14.6
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<Phieu_NhapTHTH> ph_NhapTHTH, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.Phieu_NhapTHTH SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", ph_NhapTHTH.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in ph_NhapTHTH)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "Phieu_NhapTHTH");
            }

            return result;
        }

        /// <summary>
        /// Cập nhật dư thừa thành tiền lên master
        /// </summary>
        /// <param name="entity"></param>
        protected override void AfterSave(BaseEntity entity)
        {
            base.AfterSave(entity);
            string query = $@"UPDATE  dbo.Phieu_NhapTHTH SET rThanhTien=(SELECT sum(rThanhTien) FROM dbo.Phieu_NhapTHTH_CT WHERE sPhieu_NhapTHTH_Id=@Id)
                            WHERE Id=@Id";

            _unitOfWork.Execute(query, new { Id = entity.GetIdentity() });
        }
    }
}
