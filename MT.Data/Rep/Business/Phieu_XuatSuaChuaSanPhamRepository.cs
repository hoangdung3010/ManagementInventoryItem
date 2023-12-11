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
    public class Phieu_XuatSuaChuaSanPhamRepository : MT.Data.Rep.BaseRepository<Phieu_XuatSuaChuaSanPham>
    {
        #region "Constructor"
        public Phieu_XuatSuaChuaSanPhamRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
            string query = $@"dbo.View_Phieu_XuatSuaChuaSanPham";
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

            Phieu_XuatSuaChuaSanPham phieu_XuatSuaChuaSanPham = (Phieu_XuatSuaChuaSanPham)entity;

            phieu_XuatSuaChuaSanPham.sMa = $"{phieu_XuatSuaChuaSanPham.sSo}/{phieu_XuatSuaChuaSanPham.sChu}";

            if (phieu_XuatSuaChuaSanPham.sKH_SuaChuaSanPham_Id_CanCu.HasValue)
            {
                if (phieu_XuatSuaChuaSanPham.iLoai == (int)iLoaiXuatSuaChua.XuatSCĐi)
                {
                    KH_SuaChuaSanPham kH_SuaChuaSanPham = GetDataByID<KH_SuaChuaSanPham>("KH_SuaChuaSanPham",
                    phieu_XuatSuaChuaSanPham.sKH_SuaChuaSanPham_Id_CanCu, "sMa,sSo,sChu");

                    if (kH_SuaChuaSanPham != null)
                    {
                        phieu_XuatSuaChuaSanPham.sMa_KH = kH_SuaChuaSanPham.sMa;
                        phieu_XuatSuaChuaSanPham.sSo_KH = kH_SuaChuaSanPham.sSo;
                        phieu_XuatSuaChuaSanPham.sChu_KH = kH_SuaChuaSanPham.sChu;
                    }
                }
                if (phieu_XuatSuaChuaSanPham.iLoai == (int)iLoaiXuatSuaChua.XuatSCTraVeSauSC)
                {
                    Phieu_NhapSuaChuaSanPham phieu_NhapSuaChuaSanPham = GetDataByID<Phieu_NhapSuaChuaSanPham>("Phieu_NhapSuaChuaSanPham",
                            phieu_XuatSuaChuaSanPham.sKH_SuaChuaSanPham_Id_CanCu, "sMa,sSo,sChu");

                    if (phieu_NhapSuaChuaSanPham != null)
                    {
                        phieu_XuatSuaChuaSanPham.sMa_KH = phieu_NhapSuaChuaSanPham.sMa;
                        phieu_XuatSuaChuaSanPham.sSo_KH = phieu_NhapSuaChuaSanPham.sSo;
                        phieu_XuatSuaChuaSanPham.sChu_KH = phieu_NhapSuaChuaSanPham.sChu;
                    }
                }
            }
            if (phieu_XuatSuaChuaSanPham.phieu_XuatSuaChuaSanPham_CTs != null)
            {
                foreach (var item in phieu_XuatSuaChuaSanPham.phieu_XuatSuaChuaSanPham_CTs)
                {
                    Phieu_XuatSuaChuaSanPham_CT phieu_XuatSuaChuaSanPham_CT = (Phieu_XuatSuaChuaSanPham_CT)item;
                    if (phieu_XuatSuaChuaSanPham_CT.IsLoaded && phieu_XuatSuaChuaSanPham_CT.MTEntityState != Enummation.MTEntityState.Add)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = "DELETE FROM Phieu_XuatSuaChuaSanPham_CT_PhuKien WHERE sPhieu_XuatSuaChuaSanPham_CT_Id=@sPhieu_XuatSuaChuaSanPham_CT_Id";

                        _unitOfWork.Execute(query, new { sPhieu_XuatSuaChuaSanPham_CT_Id = phieu_XuatSuaChuaSanPham_CT.Id });
                    }
                }
            }
        }

        protected override void AfterSave(BaseEntity entity)
        {
            base.AfterSave(entity);
            string query = $@"UPDATE dbo.Phieu_XuatSuaChuaSanPham
                                SET rThanhTien=(SELECT SUM(rThanhTien) 
                                                FROM dbo.Phieu_XuatSuaChuaSanPham_CT
                                                WHERE sPhieu_XuatSuaChuaSanPham_Id=@Id)
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
            string query = $@"SELECT sMa from [dbo].[Phieu_NhapSuaChuaSanPham] where sPhieu_XuatSuaChuaSanPham_Id_CanCu='{id}' ORDER BY sSo";
            return _unitOfWork.Query<string>(query);
        }

        // 14.6
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<Phieu_XuatSuaChuaSanPham> ph_XuatSuaChuaSanPham, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.Phieu_XuatSuaChuaSanPham SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", ph_XuatSuaChuaSanPham.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in ph_XuatSuaChuaSanPham)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "Phieu_XuatSuaChuaSanPham");
            }

            return result;
        }


        #endregion
    }
}
