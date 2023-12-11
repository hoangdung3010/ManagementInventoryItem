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
    public class Phieu_NhapSanPhamMoiRepository : MT.Data.Rep.BaseRepository<Phieu_NhapSanPhamMoi>
    {
        #region "Constructor"
        public Phieu_NhapSanPhamMoiRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
            string query = $@"dbo.View_Phieu_NhapSanPhamMoi";
            return query;
        }

        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<Phieu_NhapSanPhamMoi> phieuNhapSanPhamMois, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.Phieu_NhapSanPhamMoi SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", phieuNhapSanPhamMois.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in phieuNhapSanPhamMois)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "Phieu_NhapSanPhamMoi");
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
            Phieu_NhapSanPhamMoi phieu_NhapSanPhamMoi = (Phieu_NhapSanPhamMoi)entity;

            phieu_NhapSanPhamMoi.sMa = phieu_NhapSanPhamMoi.sSo + "/" + phieu_NhapSanPhamMoi.sChu;

            if (phieu_NhapSanPhamMoi.sKH_NhapSanPhamMoi_Id_CanCu.HasValue)
            {
                KH_NhapSanPhamMoi kH_NhapSanPhamMoi = GetDataByID<KH_NhapSanPhamMoi>("KH_NhapSanPhamMoi",
                    phieu_NhapSanPhamMoi.sKH_NhapSanPhamMoi_Id_CanCu, "sMa,sSo,sChu");

                if (kH_NhapSanPhamMoi != null)
                {
                    phieu_NhapSanPhamMoi.sMa_KH = kH_NhapSanPhamMoi.sMa;
                    phieu_NhapSanPhamMoi.sSo_KH = kH_NhapSanPhamMoi.sSo;
                    phieu_NhapSanPhamMoi.sChu_KH = kH_NhapSanPhamMoi.sChu;
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

            string query = $@"UPDATE  dbo.Phieu_NhapSanPhamMoi SET rThanhTien=(SELECT sum(rThanhTien) FROM dbo.Phieu_NhapSanPhamMoi_CT WHERE sPhieu_NhapSanPhamMoi_Id=@Id)
                            WHERE Id=@Id";

            _unitOfWork.Execute(query, new { Id = entity.GetIdentity() });

            
        }

        /// <summary>
        /// Thực hiện validate dữ liệu trước khi lưu
        /// </summary>
        /// <param name="entity">Đối tượng phiếu</param>
        /// <param name="resultData"></param>
        protected override void ValidateBeforeSave(BaseEntity entity, ResultData resultData)
        {
            base.ValidateBeforeSave(entity, resultData);
            Phieu_NhapSanPhamMoi phieu_NhapSanPhamMoi = (Phieu_NhapSanPhamMoi)entity;
            if (phieu_NhapSanPhamMoi.phieu_NhapSanPhamMoi_CT!=null && phieu_NhapSanPhamMoi.phieu_NhapSanPhamMoi_CT.Count > 0)
            {
                //Check mã vạch không được nhập trùng
                List<string> addsMaVachs = new List<string>();
                List<Phieu_NhapSanPhamMoi_CT> editNhapMoiSanPhamCTs = new List<Phieu_NhapSanPhamMoi_CT>();
                foreach (var item in phieu_NhapSanPhamMoi.phieu_NhapSanPhamMoi_CT)
                {
                    Phieu_NhapSanPhamMoi_CT phieu_NhapSanPhamMoi_CT = (Phieu_NhapSanPhamMoi_CT)item;
                    switch (phieu_NhapSanPhamMoi_CT.MTEntityState)
                    {
                        case Enummation.MTEntityState.Add:
                            addsMaVachs.Add(phieu_NhapSanPhamMoi_CT.sMaVach);
                            break;
                        case Enummation.MTEntityState.Edit:
                            editNhapMoiSanPhamCTs.Add(phieu_NhapSanPhamMoi_CT);
                            break;
                    }
                }

                if (addsMaVachs.Count > 0 && phieu_NhapSanPhamMoi.MTEntityState==Enummation.MTEntityState.Add)
                {
                    //Không check ở trong phiếu hiện tại
                    string query = $@"SELECT Id,sMaVach FROM dbo.Phieu_NhapSanPhamMoi_CT 
                                  WHERE sMaVach IN({string.Join(",", addsMaVachs.Select(m => $"'{m}'"))})";

                    List<Phieu_NhapSanPhamMoi_CT> phieu_NhapSanPhamMoi_CTs = _unitOfWork.Query<Phieu_NhapSanPhamMoi_CT>(query);

                    if (phieu_NhapSanPhamMoi_CTs != null && phieu_NhapSanPhamMoi_CTs.Count > 0)
                    {
                        //Mã vạch đã tồn tại
                        resultData.Success = false;
                        resultData.UserMsg = $"Các Mã vạch <{string.Join("; ", phieu_NhapSanPhamMoi_CTs.Select(m=>m.sMaVach))}> đã tồn tại trong hệ thống.";
                        return;
                    }
                }

                if (editNhapMoiSanPhamCTs.Count > 0 && phieu_NhapSanPhamMoi.MTEntityState == Enummation.MTEntityState.Edit)
                {
                    foreach (var item in editNhapMoiSanPhamCTs)
                    {
                        string query = $@"IF EXISTS(SELECT 1 FROM dbo.Phieu_NhapSanPhamMoi_CT 
                                  WHERE sMaVach=@sMaVach AND Id<>'{item.Id}') SELECT 1 ELSE SELECT 0";

                        bool exists = _unitOfWork.ExecuteScalar<bool>(query, new { sMaVach= item.sMaVach});

                        if (exists)
                        {
                            //Mã vạch đã tồn tại
                            resultData.Success = false;
                            resultData.UserMsg = $"Mã vạch <{item.sMaVach}> đã tồn tại trong hệ thống.";
                            return;
                        }
                    }
                   
                }
                
            }

        }
        #endregion
    }
}
