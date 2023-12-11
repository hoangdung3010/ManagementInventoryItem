using MT.Data.BO;
using MT.Data.ExchangeData;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.BO;
using MT.Library.UW;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MT.Data.Rep
{
    public class Phieu_XuatTHTHRepository : MT.Data.Rep.BaseRepository<Phieu_XuatTHTH>
    {
        #region "Constructor"
        public Phieu_XuatTHTHRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
            string query = $@"dbo.View_Phieu_XuatTHTH";
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

            Phieu_XuatTHTH phieu_XuatTHTH = (Phieu_XuatTHTH)entity;

            phieu_XuatTHTH.sMa = $"{phieu_XuatTHTH.sSo}/{phieu_XuatTHTH.sChu}";

            if (phieu_XuatTHTH.phieu_XuatTHTH_CTs != null)
            {
                foreach (var item in phieu_XuatTHTH.phieu_XuatTHTH_CTs)
                {
                    Phieu_XuatTHTH_CT phieu_XuatTHTH_CT = (Phieu_XuatTHTH_CT)item;
                    if (phieu_XuatTHTH_CT.IsLoaded && phieu_XuatTHTH_CT.MTEntityState != Enummation.MTEntityState.Add)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = "DELETE FROM Phieu_XuatTHTH_CT_PhuKien WHERE sPhieu_XuatTHTH_CT_Id=@sPhieu_XuatTHTH_CT_Id";

                        _unitOfWork.Execute(query, new { sPhieu_XuatTHTH_CT_Id = phieu_XuatTHTH_CT.Id });
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
            string query = $@"SELECT sMa from [dbo].[Phieu_NhapTHTH] where sPhieu_XuatTHTH_Id_CanCu='{id}' ORDER BY sSo";
            return _unitOfWork.Query<string>(query);
        }

        // 14.6
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<Phieu_XuatTHTH> ph_XuatTHTH, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.Phieu_XuatTHTH SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", ph_XuatTHTH.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in ph_XuatTHTH)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "Phieu_XuatTHTH");
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
            string query = $@"UPDATE  dbo.Phieu_XuatTHTH SET rThanhTien=(SELECT sum(rThanhTien) FROM dbo.Phieu_XuatTHTH_CT WHERE sPhieu_XuatTHTH_Id=@Id)
                            WHERE Id=@Id";

            _unitOfWork.Execute(query, new { Id = entity.GetIdentity() });
        }
        public bool KiemTraKepChi(int iTCXuat, IList phieu_XuatTHTH_CTs, out string tensp )
        {
            tensp = "";
            if (iTCXuat == (int)iTCXuatTH.XuatHuy && phieu_XuatTHTH_CTs != null)
            {
                DM_DonVi dv = _unitOfWork.QueryFirstOrDefault<DM_DonVi>("Select iDictionary from DM_DonVi where Id= @Id", new { Id = MT.Library.SessionData.OrganizationUnitId });
                if (dv.iDictionary != 1)
                {
                    foreach (var item in phieu_XuatTHTH_CTs)
                    {
                        Phieu_XuatTHTH_CT phieu_XuatTHTH_CT = (Phieu_XuatTHTH_CT)item;
                        if (phieu_XuatTHTH_CT.MTEntityState != Enummation.MTEntityState.Delete)
                        {
                            //thực hiện xóa hết phụ kiện của sản phẩm đi
                            string query = "SELECT Id,sTenSanPham, bKepChi FROM DM_SanPham WHERE Id=@Id";

                            DM_SanPham sp = _unitOfWork.QueryFirstOrDefault<DM_SanPham>(query, new { Id = phieu_XuatTHTH_CT.sDM_SanPham_Id });
                            tensp = sp.sTenSanPham;
                            if (sp.bKepChi)
                            {
                                return false;
                            }

                        }
                    }
                }

            }
            return true;
        }
        protected override void ValidateBeforeSave(BaseEntity entity, ResultData resultData)
        {
            base.ValidateBeforeSave(entity, resultData);
            Phieu_XuatTHTH phieu_XuatTHTH = (Phieu_XuatTHTH)entity;
            string tenSp = "";
            if (!KiemTraKepChi(phieu_XuatTHTH.iTCXuat, phieu_XuatTHTH.phieu_XuatTHTH_CTs, out tenSp))
            {
                resultData.Success = false;
                resultData.UserMsg = "Sản phẩm " + tenSp + " là sản phẩm kẹp chì. Bạn không được phép tiêu hủy";
                return;
            }    
        }
    }
}
