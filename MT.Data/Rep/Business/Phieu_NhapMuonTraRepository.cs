﻿using MT.Data.BO;
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
    public class Phieu_NhapMuonTraRepository : MT.Data.Rep.BaseRepository<Phieu_NhapMuonTra>
    {
        #region "Constructor"
        public Phieu_NhapMuonTraRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
            string query = $@"dbo.View_Phieu_NhapMuonTra";
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

            Phieu_NhapMuonTra phieu_NhapMuonTra = (Phieu_NhapMuonTra)entity;

            phieu_NhapMuonTra.sMa = $"{phieu_NhapMuonTra.sSo}/{phieu_NhapMuonTra.sChu}";

            if (phieu_NhapMuonTra.phieu_NhapMuonTra_CTs != null)
            {
                foreach (var item in phieu_NhapMuonTra.phieu_NhapMuonTra_CTs)
                {
                    Phieu_NhapMuonTra_CT phieu_NhapMuonTra_CT = (Phieu_NhapMuonTra_CT)item;
                    if (phieu_NhapMuonTra_CT.IsLoaded && phieu_NhapMuonTra_CT.MTEntityState != Enummation.MTEntityState.Add)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = "DELETE FROM Phieu_NhapMuonTra_CT_PhuKien WHERE sPhieu_NhapMuonTra_CT_Id=@sPhieu_NhapMuonTra_CT_Id";

                        _unitOfWork.Execute(query, new { sPhieu_NhapMuonTra_CT_Id = phieu_NhapMuonTra_CT.Id });
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
        //    string query = $@"SELECT sMa from [dbo].[Phieu_XuatSanPham] where sPhieu_NhapMuonTra_Id_CanCu='{id}' ORDER BY sSo";
        //    return _unitOfWork.Query<string>(query);
        //}

        // 14.6
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<Phieu_NhapMuonTra> ph_NhapMuonTra, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.Phieu_NhapMuonTra SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", ph_NhapMuonTra.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in ph_NhapMuonTra)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "Phieu_NhapMuonTra");
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
            string query = $@"UPDATE  dbo.Phieu_NhapMuonTra SET rThanhTien=(SELECT sum(rThanhTien) FROM dbo.Phieu_NhapMuonTra_CT WHERE sPhieu_NhapMuonTra_Id=@Id)
                            WHERE Id=@Id";

            _unitOfWork.Execute(query, new { Id = entity.GetIdentity() });
        }
    }
}
