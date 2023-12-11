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
    public class Phieu_XuatSanPhamRepository : MT.Data.Rep.BaseRepository<Phieu_XuatSanPham>
    {
        #region "Constructor"

        public Phieu_XuatSanPhamRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
            string query = $@"dbo.View_Phieu_XuatSanPham";
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

            Phieu_XuatSanPham phieu_XuatSanPham = (Phieu_XuatSanPham)entity;

            phieu_XuatSanPham.sMa = $"{phieu_XuatSanPham.sSo}/{phieu_XuatSanPham.sChu}";

            if (phieu_XuatSanPham.phieu_XuatSanPham_CTs != null)
            {
                foreach (var item in phieu_XuatSanPham.phieu_XuatSanPham_CTs)
                {
                    Phieu_XuatSanPham_CT phieu_XuatSanPham_CT = (Phieu_XuatSanPham_CT)item;
                    if (phieu_XuatSanPham_CT.IsLoaded && phieu_XuatSanPham_CT.MTEntityState != Enummation.MTEntityState.Add)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = "DELETE FROM Phieu_XuatSanPham_CT_PhuKien WHERE sPhieu_XuatSanPham_CT_Id=@sPhieu_XuatSanPham_CT_Id";

                        _unitOfWork.Execute(query, new { sPhieu_XuatSanPham_CT_Id = phieu_XuatSanPham_CT.Id });
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
            string query = $@"SELECT sMa from [dbo].[Phieu_NhapSanPham] where sPhieu_XuatSanPham_Id_CanCu='{id}' ORDER BY sSo";
            return _unitOfWork.Query<string>(query);
        }

        // 14.6
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<Phieu_XuatSanPham> ph_XuatSanPham, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.Phieu_XuatSanPham SET
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", ph_XuatSanPham.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in ph_XuatSanPham)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "Phieu_XuatSanPham");
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
            string query = $@"UPDATE  dbo.Phieu_XuatSanPham SET rThanhTien=(SELECT sum(rThanhTien) FROM dbo.Phieu_XuatSanPham_CT WHERE sPhieu_XuatSanPham_Id=@Id)
                            WHERE Id=@Id";

            _unitOfWork.Execute(query, new { Id = entity.GetIdentity() });
        }

        protected override void AfterCommitSave(BaseEntity entity)
        {
            base.AfterCommitSave(entity);
            /*Phieu_XuatSanPham phieu_XuatSanPham = (Phieu_XuatSanPham)entity;

            if (phieu_XuatSanPham.phieu_XuatSanPham_CTs != null)
            {
                foreach (var item in phieu_XuatSanPham.phieu_XuatSanPham_CTs)
                {
                    Phieu_XuatSanPham_CT phieu_XuatSanPham_CT = (Phieu_XuatSanPham_CT)item;
                    if (phieu_XuatSanPham_CT.IsLoaded)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = $@"With temp AS(select dNgayHieuLuc, mll.sDM_ThamSoMatMa_Id AS tsmmID from DM_ThamSoMatMa tsmm, DM_MangLienLac mll where tsmm.Id= mll.sDM_ThamSoMatMa_Id and mll.Id=@sMangLLId)
                                    update tsmm
                                        set dNgayHieuLuc =
                                        (
                                            select
	                                        case
                                                when c.dNgayHieuLuc IS NULL THEN GETDATE()
                                                else c.dNgayHieuLuc
                                            end
                                          from temp c
                                        )
                                        from DM_ThamSoMatMa tsmm
                                        inner join temp on tsmm.Id = temp.tsmmID";
                        _unitOfWork.Execute(query, new { sMangLLId = phieu_XuatSanPham_CT.sDM_MangLienLac_Id });
                    }
                }
            }*/
        }
    }
}