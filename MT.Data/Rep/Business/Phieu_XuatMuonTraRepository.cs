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
    public class Phieu_XuatMuonTraRepository : MT.Data.Rep.BaseRepository<Phieu_XuatMuonTra>
    {
        #region "Constructor"
        public Phieu_XuatMuonTraRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
            string query = $@"dbo.View_Phieu_XuatMuonTra";
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

            Phieu_XuatMuonTra phieu_XuatMuonTra = (Phieu_XuatMuonTra)entity;

            phieu_XuatMuonTra.sMa = $"{phieu_XuatMuonTra.sSo}/{phieu_XuatMuonTra.sChu}";

            if (phieu_XuatMuonTra.phieu_XuatMuonTra_CTs != null)
            {
                foreach (var item in phieu_XuatMuonTra.phieu_XuatMuonTra_CTs)
                {
                    Phieu_XuatMuonTra_CT phieu_XuatMuonTra_CT = (Phieu_XuatMuonTra_CT)item;
                    if (phieu_XuatMuonTra_CT.IsLoaded && phieu_XuatMuonTra_CT.MTEntityState != Enummation.MTEntityState.Add)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = "DELETE FROM Phieu_XuatMuonTra_CT_PhuKien WHERE sPhieu_XuatMuonTra_CT_Id=@sPhieu_XuatMuonTra_CT_Id";

                        _unitOfWork.Execute(query, new { sPhieu_XuatMuonTra_CT_Id = phieu_XuatMuonTra_CT.Id });
                    }
                }
            }
        }

        // Note 14.6
        /// <summary>
        /// Kiểm tra đã tồn tại phiếu xuất từ kế hoạch xuất 
        /// </summary>
        /// <returns>=true Tồn tại, ngược lại chưa tồn tại</returns>
        public List<string> GetPhieuNhapsByPhX(Guid id)
        {
            string query = $@"SELECT sMa from [dbo].[Phieu_NhapMuonTra] where sPhieu_XuatMuonTra_Id_CanCu='{id}' ORDER BY sSo";
            return _unitOfWork.Query<string>(query);
        }

        // 14.6
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<Phieu_XuatMuonTra> ph_XuatMuonTra, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.Phieu_XuatMuonTra SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", ph_XuatMuonTra.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in ph_XuatMuonTra)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "Phieu_XuatMuonTra");
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
            string query = $@"UPDATE  dbo.Phieu_XuatMuonTra SET rThanhTien=(SELECT sum(rThanhTien) FROM dbo.Phieu_XuatMuonTra_CT WHERE sPhieu_XuatMuonTra_Id=@Id)
                            WHERE Id=@Id";

            _unitOfWork.Execute(query, new { Id = entity.GetIdentity() });
        }
    }
}
