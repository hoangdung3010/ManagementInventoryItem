using MT.Data.BO;
using MT.Data.ExchangeData;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.BO;
using MT.Library.UW;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MT.Data.Rep
{
    public class Phieu_NhapCaiDatSanPhamRepository : MT.Data.Rep.BaseRepository<Phieu_NhapCaiDatSanPham>
    {
        #region "Constructor"
        public Phieu_NhapCaiDatSanPhamRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
            string query = $@"dbo.View_Phieu_NhapCaiDatSanPham";
            return query;
        }

        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<Phieu_NhapCaiDatSanPham> phieuNhapSanPhamMois, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.Phieu_NhapCaiDatSanPham SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", phieuNhapSanPhamMois.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in phieuNhapSanPhamMois)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "Phieu_NhapCaiDatSanPham");
            }

            return result;
        }

        #endregion

        #region"Overrides"
        /// <summary>
        /// Thêm dữ liệu trước khi lưu
        /// </summary>
        /// <param name="entity"></param>
        protected override void PreSaveData(BaseEntity entity)
        {
            base.PreSaveData(entity);
            Phieu_NhapCaiDatSanPham phieu_NhapCaiDatSanPham = (Phieu_NhapCaiDatSanPham)entity;

            phieu_NhapCaiDatSanPham.sMa = $"{phieu_NhapCaiDatSanPham.sSo}/{phieu_NhapCaiDatSanPham.sChu}";

            if (phieu_NhapCaiDatSanPham.sPhieu_XuatSanPham_Id_CanCu.HasValue)
            {
                Phieu_XuatCaiDatSanPham phieu_XuatCaiDatSanPham = GetDataByID<Phieu_XuatCaiDatSanPham>("Phieu_XuatCaiDatSanPham",
                    phieu_NhapCaiDatSanPham.sPhieu_XuatSanPham_Id_CanCu, "sMa,sSo,sChu");

                if (phieu_XuatCaiDatSanPham != null)
                {
                    phieu_NhapCaiDatSanPham.sMa_PX = phieu_XuatCaiDatSanPham.sMa;
                    phieu_NhapCaiDatSanPham.sSo_PX = phieu_XuatCaiDatSanPham.sSo;
                    phieu_NhapCaiDatSanPham.sChu_PX = phieu_XuatCaiDatSanPham.sChu;
                }
            }

        }
        /// <summary>
        /// Thực hiện cập nhật cột tổng tiền trên master
        /// </summary>
        /// <param name="entity"></param>
        protected override void AfterSave(BaseEntity entity)
        {
            base.AfterSave(entity);

            string query = $@"UPDATE  dbo.Phieu_NhapCaiDatSanPham SET rThanhTien=(SELECT sum(rThanhTien) FROM dbo.Phieu_NhapCaiDatSanPham_CT WHERE sPhieu_NhapCaiDatSanPham_Id=@Id)
                            WHERE Id=@Id";

            _unitOfWork.Execute(query, new { Id = entity.GetIdentity() });


        }

        #endregion
    }
}
