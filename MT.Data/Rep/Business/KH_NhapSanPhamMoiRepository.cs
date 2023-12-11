using MT.Data.BO;
using MT.Data.ExchangeData;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.BO;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace MT.Data.Rep
{
    public class KH_NhapSanPhamMoiRepository : MT.Data.Rep.BaseRepository<KH_NhapSanPhamMoi>
    {
        #region "Constructor"
        public KH_NhapSanPhamMoiRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
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

            KH_NhapSanPhamMoi kH_NhapSanPhamMoi =(KH_NhapSanPhamMoi) entity;

            if (kH_NhapSanPhamMoi.MTEntityState == Enummation.MTEntityState.Add
                && kH_NhapSanPhamMoi.iTrangThaiDuyet==(int)MT.Data.iTrangThaiDuyetPNM.DongYDuyet)
            {
                //Trường hợp thêm mới và duyệt luôn
                kH_NhapSanPhamMoi.dNgayDuyet = SysDateTime.Instance.Now();
            }

            kH_NhapSanPhamMoi.sMa = $"{kH_NhapSanPhamMoi.sSo}/{kH_NhapSanPhamMoi.sChu}";

            if (kH_NhapSanPhamMoi.kH_NhapSanPhamMoi_CTs != null)
            {
                foreach (var item in kH_NhapSanPhamMoi.kH_NhapSanPhamMoi_CTs)
                {
                    KH_NhapSanPhamMoi_CT kH_NhapSanPhamMoi_CT = (KH_NhapSanPhamMoi_CT)item;
                    if (kH_NhapSanPhamMoi_CT.IsLoaded && kH_NhapSanPhamMoi_CT.MTEntityState!=Enummation.MTEntityState.Add)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = "DELETE FROM KH_NhapSanPhamMoi_CT_PhuKien WHERE sKH_NhapSanPhamMoi_CT_Id=@sKH_NhapSanPhamMoi_CT_Id";

                        _unitOfWork.Execute(query, new { sKH_NhapSanPhamMoi_CT_Id = kH_NhapSanPhamMoi_CT.Id });
                    }
                }

            }
        }

        /// <summary>
        /// Cập nhật dư thừa thành tiền lên master
        /// </summary>
        /// <param name="entity"></param>
        protected override void AfterSave(BaseEntity entity)
        {
            base.AfterSave(entity);
            string query = $@"UPDATE  dbo.KH_NhapSanPhamMoi SET rThanhTien=(SELECT sum(rThanhTien) FROM dbo.KH_NhapSanPhamMoi_CT WHERE sKH_NhapSanPhamMoi_Id=@Id)
                            WHERE Id=@Id";

            _unitOfWork.Execute(query, new { Id = entity.GetIdentity() });
        }
        #endregion

        #region"Sub/Func"
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<KH_NhapSanPhamMoi> kH_NhapSanPhamMois,int iTrangThaiDuyet,string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.KH_NhapSanPhamMoi SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", kH_NhapSanPhamMois.Select(m=>$"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in kH_NhapSanPhamMois)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "KH_NhapSanPhamMoi");
            }

            return result;
        }

        /// <summary>
        /// Kiểm tra đã tồn tại phiếu nhập mới từ kế hoạch nhập mới 
        /// </summary>
        /// <returns>=true Tồn tại, ngược lại chưa tồn tại</returns>
        public List<string> GetPhieuNhapMoisByKHNM(Guid id)
        {
            string query = $@"SELECT sMa from [dbo].[Phieu_NhapSanPhamMoi] where sKH_NhapSanPhamMoi_Id_CanCu='{id}' ORDER BY sSo";
            return _unitOfWork.Query<string>(query);
        }
        #endregion
    }
}
