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
    public class Phieu_XuatBaoHanhSanPhamRepository : MT.Data.Rep.BaseRepository<Phieu_XuatBaoHanhSanPham>
    {
        #region "Constructor"
        public Phieu_XuatBaoHanhSanPhamRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
            string query = $@"dbo.View_Phieu_XuatBaoHanhSanPham";
            return query;
        }
        #endregion


        #region "Overrides"
        /// <summary>
        /// trước khi lưu thực hiện 
        /// </summary>
        /// <param name="entity"></param>
        protected override void PreSaveData(BaseEntity entity)
        {
            base.PreSaveData(entity);

            Phieu_XuatBaoHanhSanPham phieu_XuatBaoHanhSanPham = (Phieu_XuatBaoHanhSanPham)entity;

            phieu_XuatBaoHanhSanPham.sMa = $"{phieu_XuatBaoHanhSanPham.sSo}/{phieu_XuatBaoHanhSanPham.sChu}";

            if (phieu_XuatBaoHanhSanPham.sKH_BaoHanhSanPham_Id_CanCu.HasValue)
            {
                if (phieu_XuatBaoHanhSanPham.iLoai == (int)iLoaiXuatBaoHanh.XuatBH)
                {
                    KH_BaoHanhSanPham kH_BaoHanhSanPham = GetDataByID<KH_BaoHanhSanPham>("KH_BaoHanhSanPham",
                    phieu_XuatBaoHanhSanPham.sKH_BaoHanhSanPham_Id_CanCu, "sMa,sSo,sChu");

                    if (kH_BaoHanhSanPham != null)
                    {
                        phieu_XuatBaoHanhSanPham.sMa_KH = kH_BaoHanhSanPham.sMa;
                        phieu_XuatBaoHanhSanPham.sSo_KH = kH_BaoHanhSanPham.sSo;
                        phieu_XuatBaoHanhSanPham.sChu_KH = kH_BaoHanhSanPham.sChu;
                    }
                }
                if (phieu_XuatBaoHanhSanPham.iLoai == (int)iLoaiXuatBaoHanh.XuatTraSauBH)
                {
                    Phieu_NhapBaoHanhSanPham phieu_NhapBaoHanhSanPham = GetDataByID<Phieu_NhapBaoHanhSanPham>("Phieu_NhapBaoHanhSanPham",
                            phieu_XuatBaoHanhSanPham.sKH_BaoHanhSanPham_Id_CanCu, "sMa,sSo,sChu");

                    if (phieu_NhapBaoHanhSanPham != null)
                    {
                        phieu_XuatBaoHanhSanPham.sMa_KH = phieu_NhapBaoHanhSanPham.sMa;
                        phieu_XuatBaoHanhSanPham.sSo_KH = phieu_NhapBaoHanhSanPham.sSo;
                        phieu_XuatBaoHanhSanPham.sChu_KH = phieu_NhapBaoHanhSanPham.sChu;
                    }
                }
            }

            if (phieu_XuatBaoHanhSanPham.phieu_XuatBaoHanhSanPham_CTs != null)
            {
                foreach (var item in phieu_XuatBaoHanhSanPham.phieu_XuatBaoHanhSanPham_CTs)
                {
                    Phieu_XuatBaoHanhSanPham_CT phieu_XuatBaoHanhSanPham_CT = (Phieu_XuatBaoHanhSanPham_CT)item;
                    if (phieu_XuatBaoHanhSanPham_CT.IsLoaded && phieu_XuatBaoHanhSanPham_CT.MTEntityState != Enummation.MTEntityState.Add)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = "DELETE FROM Phieu_XuatBaoHanhSanPham_CT_PhuKien WHERE sPhieu_XuatBaoHanhSanPham_CT_Id=@sPhieu_XuatBaoHanhSanPham_CT_Id";

                        _unitOfWork.Execute(query, new { sPhieu_XuatBaoHanhSanPham_CT_Id = phieu_XuatBaoHanhSanPham_CT.Id });
                    }
                }
            }
        }

        protected override void AfterSave(BaseEntity entity)
        {
            base.AfterSave(entity);
            string query = $@"UPDATE dbo.Phieu_XuatBaoHanhSanPham
                                SET rThanhTien=(SELECT SUM(rThanhTien) 
                                                FROM dbo.Phieu_XuatBaoHanhSanPham_CT
                                                WHERE sPhieu_XuatBaoHanhSanPham_Id=@Id)
                                WHERE Id=@Id";

            _unitOfWork.Execute(query, new { Id = entity.GetIdentity() });
        }
        #endregion


        #region Sub/Func
        // Note 14.6
        /// <summary>
        /// Kiểm tra đã tồn tại phiếu xuất từ kế hoạch xuất 
        /// </summary>
        /// <returns>=true Tồn tại, ngược lại chưa tồn tại</returns>
        public List<string> GetPhieuNhapsByPhX(Guid id)
        {
            string query = $@"SELECT sMa from [dbo].[Phieu_NhapBaoHanhSanPham] where sPhieu_XuatBaoHanhSanPham_Id_CanCu='{id}' ORDER BY sSo";
            return _unitOfWork.Query<string>(query);
        }

        // 14.6
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<Phieu_XuatBaoHanhSanPham> ph_XuatBaoHanhSanPham, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.Phieu_XuatBaoHanhSanPham SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", ph_XuatBaoHanhSanPham.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in ph_XuatBaoHanhSanPham)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "Phieu_XuatBaoHanhSanPham");
            }

            return result;
        }
        #endregion
    }
}
