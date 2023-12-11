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
    public class Phieu_XuatCaiDatSanPhamRepository : MT.Data.Rep.BaseRepository<Phieu_XuatCaiDatSanPham>
    {
        #region "Constructor"
        public Phieu_XuatCaiDatSanPhamRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
            string query = $@"dbo.View_Phieu_XuatCaiDatSanPham";
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

            Phieu_XuatCaiDatSanPham phieu_XuatCaiDatSanPham = (Phieu_XuatCaiDatSanPham)entity;

            phieu_XuatCaiDatSanPham.sMa = $"{phieu_XuatCaiDatSanPham.sSo}/{phieu_XuatCaiDatSanPham.sChu}";

            if (phieu_XuatCaiDatSanPham.sKH_CaiDatSanPham_Id_CanCu.HasValue)
            {
                if (phieu_XuatCaiDatSanPham.iLoai == (int)iLoaiPhieu.XuatĐiCĐ)
                {
                    KH_CaiDatSanPham kH_CaiDatSanPham = GetDataByID<KH_CaiDatSanPham>("KH_CaiDatSanPham",
                    phieu_XuatCaiDatSanPham.sKH_CaiDatSanPham_Id_CanCu, "sMa,sSo,sChu");

                    if (kH_CaiDatSanPham != null)
                    {
                        phieu_XuatCaiDatSanPham.sMa_KH = kH_CaiDatSanPham.sMa;
                        phieu_XuatCaiDatSanPham.sSo_KH = kH_CaiDatSanPham.sSo;
                        phieu_XuatCaiDatSanPham.sChu_KH = kH_CaiDatSanPham.sChu;
                    }
                }
                if (phieu_XuatCaiDatSanPham.iLoai == (int)iLoaiPhieu.XuatTraSauCĐ)
                {
                    Phieu_NhapCaiDatSanPham phieu_NhapCaiDatSanPham = GetDataByID<Phieu_NhapCaiDatSanPham>("Phieu_NhapCaiDatSanPham",
                            phieu_XuatCaiDatSanPham.sKH_CaiDatSanPham_Id_CanCu, "sMa,sSo,sChu");

                    if (phieu_NhapCaiDatSanPham != null)
                    {
                        phieu_XuatCaiDatSanPham.sMa_KH = phieu_NhapCaiDatSanPham.sMa;
                        phieu_XuatCaiDatSanPham.sSo_KH = phieu_NhapCaiDatSanPham.sSo;
                        phieu_XuatCaiDatSanPham.sChu_KH = phieu_NhapCaiDatSanPham.sChu;
                    }
                }

            }

            if (phieu_XuatCaiDatSanPham.phieu_XuatCaiDatSanPham_CTs != null)
            {
                foreach (var item in phieu_XuatCaiDatSanPham.phieu_XuatCaiDatSanPham_CTs)
                {
                    Phieu_XuatCaiDatSanPham_CT phieu_XuatCaiDatSanPham_CT = (Phieu_XuatCaiDatSanPham_CT)item;
                    if (phieu_XuatCaiDatSanPham_CT.IsLoaded && phieu_XuatCaiDatSanPham_CT.MTEntityState != Enummation.MTEntityState.Add)
                    {
                        //thực hiện xóa hết phụ kiện của sản phẩm đi
                        string query = "DELETE FROM Phieu_XuatCaiDatSanPham_CT_PhuKien WHERE sPhieu_XuatCaiDatSanPham_CT_Id=@sPhieu_XuatCaiDatSanPham_CT_Id";

                        _unitOfWork.Execute(query, new { sPhieu_XuatCaiDatSanPham_CT_Id = phieu_XuatCaiDatSanPham_CT.Id });
                    }
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

            string query = $@"UPDATE  dbo.Phieu_XuatCaiDatSanPham SET rThanhTien=(SELECT sum(rThanhTien) FROM dbo.Phieu_XuatCaiDatSanPham_CT WHERE sPhieu_XuatCaiDatSanPham_Id=@Id)
                            WHERE Id=@Id";

            _unitOfWork.Execute(query, new { Id = entity.GetIdentity() });


        }

        /// <summary>
        /// Thực hiện xử lý sau khi lưu xong thông tin master
        /// </summary>
        /// <param name="entity"></param>
        protected override void AfterCommitSave(BaseEntity entity)
        {
            base.AfterCommitSave(entity);

            var phieu_XuatCaiDatSanPham = (Phieu_XuatCaiDatSanPham)entity;

            //Nếu đơn vị xuất là đơn vị đại diện của ban cơ yếu: Phòng nghiệp vụ/Cục QLNVKTMM
            if (phieu_XuatCaiDatSanPham.iLoai == (int)MT.Data.iTCXuatCĐ.XuatCĐTraVeSauCĐ 
                &&this.KiemTraXuatChoDonViLaBanCoYeu(phieu_XuatCaiDatSanPham.sDM_DonVi_Id_Nhap))
            {
                string query = $@"SELECT sMaVach,sDM_ChungThuSo_Id FROM Phieu_XuatCaiDatSanPham_CT 
                              WHERE sPhieu_XuatCaiDatSanPham_Id='{entity.GetIdentity()}' 
                              AND (sDM_ChungThuSo_Id IS NOT NULL AND sDM_ChungThuSo_Id<>'{Guid.Empty}')";

                var lstLKMaVachCTS = _unitOfWork.Query<LK_MaVach_CTS>(query);

                if (lstLKMaVachCTS?.Count > 0)
                {
                    query = $"DELETE FROM LK_MaVach_CTS WHERE sMaVach IN({string.Join(",", lstLKMaVachCTS.Select(m => $"'{m.sMaVach}'"))})";
                    _unitOfWork.Execute(query);
                    var now = SysDateTime.Instance.Now();
                    foreach (var item in lstLKMaVachCTS)
                    {
                        item.Id = Guid.NewGuid();
                        item.CreatedDate =now;
                        item.CreatedBy = MT.Library.SessionData.FullName;
                        _unitOfWork.SaveEntity(item, "LK_MaVach_CTS", Enummation.MTEntityState.Add);
                    }
                }

                // Truong added:
                // 1. Viết tách riêng cho MLL để đỡ bị ảnh hưởng lẫn nhau giữa MLL và CTS
                query = $@"SELECT sMaVach,sDM_MangLienLac_Id FROM Phieu_XuatCaiDatSanPham_CT 
                              WHERE sPhieu_XuatCaiDatSanPham_Id='{entity.GetIdentity()}' 
                              AND (sDM_MangLienLac_Id IS NOT NULL AND sDM_MangLienLac_Id<>'{Guid.Empty}')";

                var lstLKMaVachMLL = _unitOfWork.Query<LK_MaVach_MLL>(query);

                if (lstLKMaVachMLL?.Count > 0)
                {
                    query = $"DELETE FROM LK_MaVach_MLL WHERE sMaVach IN({string.Join(",", lstLKMaVachMLL.Select(m => $"'{m.sMaVach}'"))})";
                    _unitOfWork.Execute(query);
                    var now = SysDateTime.Instance.Now();
                    foreach (var item in lstLKMaVachMLL)
                    {
                        item.Id = Guid.NewGuid();
                        item.CreatedDate = now;
                        item.CreatedBy = MT.Library.SessionData.FullName;
                        _unitOfWork.SaveEntity(item, "LK_MaVach_MLL", Enummation.MTEntityState.Add);
                    }
                }
                // 2. Update TSMM
                if (phieu_XuatCaiDatSanPham.phieu_XuatCaiDatSanPham_CTs != null)
                {
                    foreach (var item in phieu_XuatCaiDatSanPham.phieu_XuatCaiDatSanPham_CTs)
                    {
                        Phieu_XuatCaiDatSanPham_CT phieu_XuatCaiDatSanPham_CT = (Phieu_XuatCaiDatSanPham_CT)item;
                        if (phieu_XuatCaiDatSanPham_CT.IsLoaded)
                        {
                            query = $@"With temp AS(select dNgayHieuLuc, mll.sDM_ThamSoMatMa_Id AS tsmmID from DM_ThamSoMatMa tsmm, DM_MangLienLac mll where tsmm.Id= mll.sDM_ThamSoMatMa_Id and mll.Id=@sMangLLId)
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
                            _unitOfWork.Execute(query, new { sMangLLId = phieu_XuatCaiDatSanPham_CT.sDM_MangLienLac_Id });
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Kiểm tra đơn vị có phải ban cơ yếu không
        /// </summary>
        /// <param name="orgId">Đơn vị xuất</param>
        protected bool KiemTraXuatChoDonViLaBanCoYeu(Guid orgId)
        {
            string query = $"IF EXISTS(SELECT * FROM ConfigExportData WHERE sDM_DonVi_Id_DonViNhap='{orgId}' AND iType=1) SELECT 1 ELSE SELECT 0";
            var isDonViLaBanCoYeu = _unitOfWork.QueryFirstOrDefault<bool>(query);
            return isDonViLaBanCoYeu;
        }

        /// <summary>
        /// Thực hiện xử lý trước khi xóa bản ghi
        /// </summary>
        /// <param name="oEntity"></param>
        protected override void BeforeDeleteRecord(Phieu_XuatCaiDatSanPham oEntity)
        {
            base.BeforeDeleteRecord(oEntity);

            string query = $@"SELECT CT.sMaVach,CT.sDM_ChungThuSo_Id FROM Phieu_XuatCaiDatSanPham_CT CT
                              JOIN Phieu_XuatCaiDatSanPham P ON CT.sPhieu_XuatCaiDatSanPham_Id=P.Id
                              WHERE P.Id='{oEntity.GetIdentity()}' AND P.iLoai={(int)MT.Data.iTCXuatCĐ.XuatCĐTraVeSauCĐ}
                              AND (CT.sDM_ChungThuSo_Id IS NOT NULL AND CT.sDM_ChungThuSo_Id<>'{Guid.Empty}')";

            var lstLKMaVachCTS = _unitOfWork.Query<LK_MaVach_CTS>(query);
            if (lstLKMaVachCTS?.Count > 0)
            {
                query = $"DELETE FROM LK_MaVach_CTS WHERE sMaVach IN({string.Join(",", lstLKMaVachCTS.Select(m => $"'{m.sMaVach}'"))})";
                _unitOfWork.Execute(query);
            }

            // Truong Added for MLL
            query = $@"SELECT CT.sMaVach,CT.sDM_MangLienLac_Id FROM Phieu_XuatCaiDatSanPham_CT CT
                              JOIN Phieu_XuatCaiDatSanPham P ON CT.sPhieu_XuatCaiDatSanPham_Id=P.Id
                              WHERE P.Id='{oEntity.GetIdentity()}' AND P.iLoai={(int)MT.Data.iTCXuatCĐ.XuatCĐTraVeSauCĐ}
                              AND (CT.sDM_MangLienLac_Id IS NOT NULL AND CT.sDM_MangLienLac_Id<>'{Guid.Empty}')";

            var lstLKMaVachMLL = _unitOfWork.Query<LK_MaVach_MLL>(query);
            if (lstLKMaVachMLL?.Count > 0)
            {
                query = $"DELETE FROM LK_MaVach_MLL WHERE sMaVach IN({string.Join(",", lstLKMaVachMLL.Select(m => $"'{m.sMaVach}'"))})";
                _unitOfWork.Execute(query);
            }
        }
        
        // Note 14.6
        /// <summary>
        /// Kiểm tra đã tồn tại phiếu xuất từ kế hoạch xuất 
        /// </summary>
        /// <returns>=true Tồn tại, ngược lại chưa tồn tại</returns>
        public List<string> GetPhieuNhapsByPhX(Guid id)
        {
            string query = $@"SELECT sMa from [dbo].[Phieu_NhapMuonTra] where sPhieu_XuatCaiDatSanPham_Id_CanCu='{id}' ORDER BY sSo";
            return _unitOfWork.Query<string>(query);
        }

        // 14.6
        /// <summary>
        /// Lưu thông tin phê duyệt
        /// </summary>
        /// <returns>=true thành công, ngược lại thất bại</returns>
        public bool SaveApproveOrReject(List<Phieu_XuatCaiDatSanPham> ph_XuatMuonTra, int iTrangThaiDuyet, string sLyDoXetDuyet)
        {
            string query = $@"UPDATE dbo.Phieu_XuatCaiDatSanPham SET 
                             iTrangThaiDuyet={iTrangThaiDuyet}
                            ,dNgayDuyet=getDate()
                            ,sLyDoXetDuyet=@sLyDoXetDuyet
                            WHERE Id IN({string.Join(",", ph_XuatMuonTra.Select(m => $"'{m.Id}'"))})";

            var result = _unitOfWork.Execute(query, new { sLyDoXetDuyet = sLyDoXetDuyet });
            foreach (var item in ph_XuatMuonTra)
            {
                ManagementData.Instance.SaveChangedData(item.Id, "Phieu_XuatCaiDatSanPham");
            }

            return result;
        }
    }
}
