using MT.Data.BO;
using MT.Data.ExchangeData;
using MT.Data.Rep;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data
{
    public class GhiSoKho
    {
        private static string[] _bangGhiSos = new string[]
        {
           "Phieu_NhapSanPhamMoi",
           "Phieu_NhapSanPham", "Phieu_XuatSanPham",
           "Phieu_NhapSuaChuaSanPham", "Phieu_XuatSuaChuaSanPham",
           "Phieu_NhapMuonTra", "Phieu_XuatMuonTra",
           "Phieu_NhapCaiDatSanPham","Phieu_XuatCaiDatSanPham",
           "Phieu_NhapBaoHanhSanPham", "Phieu_XuatBaoHanhSanPham",
           "Phieu_NhapBaoHanhSanPham","Phieu_XuatBaoHanhSanPham",
           "Phieu_XuatTHTH","Phieu_NhapTHTH"
        };



        /// <summary>
        /// Hàm thực hiện lưu phiếu nhập xuất vào khổ kho
        /// </summary>
        /// <param name="tableName">Tên bảng phiếu nhập/xuất</param>
        /// <param name="id">Id của phiếu</param>
        /// <param name="state">Trạng thái của phiếu</param>
        /// Lưu ý: Không ai được viết thêm code vào đây chỉ viết tại Hàm CreateQuery
        public static void LuuSo(IUnitOfWork _unitOfWork, BaseEntity baseEntity)
        {
            try
            {
                string tableName = baseEntity.TableName;
                if (!_bangGhiSos.Contains(tableName))
                {
                    return;
                }
                string query = string.Empty;

                object id = baseEntity.GetIdentity();
                //Luôn luôn xóa sổ đi ghi lại
                query = $"SELECT Id FROM dbo.SoKho WHERE sPhieu_Id='{id}'";

                var ids = _unitOfWork.Query<Guid>(query);

                if (ids?.Count > 0)
                {
                    query = $"DELETE FROM dbo.SoKho WHERE Id IN({string.Join(",",ids.Select(m=>$"'{m}'"))})";
                    _unitOfWork.Execute(query);
                    foreach (var item in ids)
                    {
                        ManagementData.Instance.SaveDeleteObject(item, "SoKho");
                    }
                }

                List<MT.Data.BO.SoKhoViewModel> soKhos = new List<BO.SoKhoViewModel>();

                if (baseEntity.MTEntityState != Enummation.MTEntityState.None && baseEntity.MTEntityState != Library.Enummation.MTEntityState.Delete)
                {
                    query = CreateQuery(_unitOfWork, baseEntity);
                    if (!string.IsNullOrEmpty(query))
                    {
                        soKhos = _unitOfWork.Query<MT.Data.BO.SoKhoViewModel>(query);
                    }

                    if (soKhos != null)
                    {
                        var now = SysDateTime.Instance.Now();
                        foreach (var item in soKhos)
                        {
                            item.Id = Guid.NewGuid();
                            item.dCreatedDate = now;
                            item.dModifiedDate =now;
                            item.sModifiedBy = MT.Library.SessionData.UserName;
                            item.sCreatedBy = MT.Library.SessionData.UserName;
                            item.sMd5Id = Guid.Parse($"{item.sDM_DonVi_Id.Value}{item.sDM_SanPham_Id.Value}{item.sDM_DonViTinh_Id.Value}".CreateMD5());

                            ManagementData.Instance.SaveChangedData(item.Id, "SoKho");
                        }

                        
                        _unitOfWork.BulkInsert<MT.Data.BO.SoKhoViewModel>(soKhos, "dbo.SoKho");
                    }
                }
            }
            catch (Exception ex)
            {
                MT.Library.Log.LogHelper.AddError(ex);
            }
        }

        /// <summary>
        /// Tạo query lấy dữ liệu insert vào sổ kho
        /// </summary>
        /// <param name="_unitOfWork">Đối tượng thao tác DB</param>
        /// <param name="baseEntity">Đối tượng ghi sổ</param>
        /// <returns>Query trả về dữ liệu sổ</returns>
        private static string CreateQuery(IUnitOfWork _unitOfWork, BaseEntity baseEntity)
        {
            string query = string.Empty;
            switch (baseEntity.TableName)
            {
                case "Phieu_NhapSanPhamMoi":
                    query = $@"SELECT M.sMa,M.sSo,M.sChu,M.iNhapVeKho,M.Id as sPhieu_Id,M.sDM_DonVi_Id_Nhap as sDM_DonVi_Id,DV.sTenDonvi AS sDM_DonVi_Id_Ten
                                    ,12 as iLoaiPhieu,M.dNgayPhieu_NhapSanPhamMoi as dNgayPhieu
                                    ,CT.Id as sPhieu_Detail_Id,CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten,SP.sMaSanPham AS sDM_SanPham_Ma
                                    ,CT.sMaVach,CT.sDM_DonViTinh_Id,DVT.sTenDonViTinh as sDM_DonViTinh_Id_Ten 
                                    ,CT.rSoLuong as rSoLuong_Nhap,CT.rDonGia as rDonGia_Nhap,CT.rThanhTien as rThanhTien_Nhap
                                    ,CT.sCauHinhKyThuat,CT.sXuatXu,CT.iNamSX,CT.iThoiGianBaoHanh
                                    ,CT.iDonViThoiGianBaoHanh,CT.dHanBaoHanhDen,CT.SortOrder
                                    ,CT.sGhiChu,NULL as sDM_ChungThuSo_Id,'' as sDM_ChungThuSo_Id_Ten,CT.sSerial,CT.sSTTSP
                                    ,0 as bPhieuXuat
                                    ,NCC.Id as sDM_DonVi_Id_Nguon
                                    ,NCC.sTenNCC as sDM_DonVi_Id_Nguon_Ten
                                    FROM dbo.Phieu_NhapSanPhamMoi M
                                    JOIN Phieu_NhapSanPhamMoi_CT CT ON M.Id=CT.sPhieu_NhapSanPhamMoi_Id
                                    LEFT JOIN DM_SanPham SP ON SP.Id=CT.sDM_SanPham_Id
                                    LEFT JOIN DM_DonViTinh DVT ON DVT.Id=CT.sDM_DonViTinh_Id
                                    LEFT JOIN DM_DonVi DV ON DV.Id=M.sDM_DonVi_Id_Nhap
                                    LEFT JOIN DM_NhaCC NCC ON NCC.Id=M.sDM_NhaCC_Id
                                    WHERE M.Id='{baseEntity.GetIdentity()}'";
                    break;
                case "Phieu_NhapSanPham":
                    query = $@"SELECT M.sMa,M.sSo,M.sChu,M.iNhapVeKho,M.Id as sPhieu_Id,M.sDM_DonVi_Id_Nhap as sDM_DonVi_Id,DV.sTenDonvi AS sDM_DonVi_Id_Ten
                                    ,23 iLoaiPhieu,M.dNgayPhieu_Nhap as dNgayPhieu
                                    ,CT.Id as sPhieu_Detail_Id,CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten,SP.sMaSanPham AS sDM_SanPham_Ma
                                    ,CT.sMaVach,CT.sDM_DonViTinh_Id,DVT.sTenDonViTinh as sDM_DonViTinh_Id_Ten 
                                    ,CT.rSoLuong as rSoLuong_Nhap,CT.rDonGia as rDonGia_Nhap,CT.rThanhTien as rThanhTien_Nhap
                                    ,CT.sCauHinhKyThuat,CT.sXuatXu,CT.iNamSX,CT.iThoiGianBaoHanh
                                    ,CT.iDonViThoiGianBaoHanh,CT.dHanBaoHanhDen,CT.SortOrder
                                    ,CT.sGhiChu,CT.sDM_ChungThuSo_Id as sDM_ChungThuSo_Id,CTS.sMaCTS AS sDM_ChungThuSo_Id_Ten,CT.sSerial,CT.sSTTSP
                                    ,CT.sDM_MangLienLac_Id,MLL.sTenMangLienLac AS sDM_MangLienLac_Id_Ten 
                                    ,0 as bPhieuXuat
                                    ,M.sDM_DonVi_Id_Xuat as sDM_DonVi_Id_Nguon
                                    ,DVX.sTenDonvi as sDM_DonVi_Id_Nguon_Ten
                                    FROM dbo.Phieu_NhapSanPham M
                                    JOIN Phieu_NhapSanPham_CT CT ON M.Id=CT.sPhieu_NhapSanPham_Id
                                    LEFT JOIN DM_SanPham SP ON SP.Id=CT.sDM_SanPham_Id
                                    LEFT JOIN DM_DonViTinh DVT ON DVT.Id=CT.sDM_DonViTinh_Id
                                    LEFT JOIN DM_MangLienLac MLL ON MLL.Id=CT.sDM_MangLienLac_Id
                                    LEFT JOIN DM_DonVi DV ON DV.Id=M.sDM_DonVi_Id_Nhap
                                    LEFT JOIN DM_DonVi DVX ON DVX.Id=M.sDM_DonVi_Id_Xuat
                                    LEFT JOIN DM_ChungThuSo CTS ON CTS.Id=CT.sDM_ChungThuSo_Id
                                    WHERE M.Id='{baseEntity.GetIdentity()}'";
                    break;
                case "Phieu_XuatSanPham":
                    query = $@"SELECT M.sMa,M.sSo,M.sChu,0 as iNhapVeKho,M.Id as sPhieu_Id,M.sDM_DonVi_Id_Xuat as sDM_DonVi_Id,DV.sTenDonvi AS sDM_DonVi_Id_Ten
                                    ,22 iLoaiPhieu,M.dNgayPhieu_Xuat as dNgayPhieu
                                    ,CT.Id as sPhieu_Detail_Id,CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten,SP.sMaSanPham AS sDM_SanPham_Ma
                                    ,CT.sMaVach,CT.sDM_DonViTinh_Id,DVT.sTenDonViTinh as sDM_DonViTinh_Id_Ten 
                                    ,CT.rSoLuong as rSoLuong_Xuat,CT.rDonGia as rDonGia_Xuat,CT.rThanhTien as rThanhTien_Xuat
                                    ,CT.sCauHinhKyThuat,CT.sXuatXu,CT.iNamSX,CT.iThoiGianBaoHanh
                                    ,CT.iDonViThoiGianBaoHanh,CT.dHanBaoHanhDen,CT.SortOrder
                                    ,CT.sGhiChu,CT.sDM_ChungThuSo_Id as sDM_ChungThuSo_Id,CTS.sMaCTS as sDM_ChungThuSo_Id_Ten,CT.sSerial,CT.sSTTSP
                                    ,CT.sDM_MangLienLac_Id,MLL.sTenMangLienLac AS sDM_MangLienLac_Id_Ten 
                                    ,1 as bPhieuXuat
                                    ,sDM_DonVi_Id_Nhap as sDM_DonVi_Id_Nguon
                                    ,DVN.sTenDonvi as sDM_DonVi_Id_Nguon_Ten
                                    FROM dbo.Phieu_XuatSanPham M
                                    JOIN Phieu_XuatSanPham_CT CT ON M.Id=CT.sPhieu_XuatSanPham_Id
                                    LEFT JOIN DM_SanPham SP ON SP.Id=CT.sDM_SanPham_Id
                                    LEFT JOIN DM_DonViTinh DVT ON DVT.Id=CT.sDM_DonViTinh_Id
                                    LEFT JOIN DM_MangLienLac MLL ON MLL.Id=CT.sDM_MangLienLac_Id
                                    LEFT JOIN DM_DonVi DV ON DV.Id=M.sDM_DonVi_Id_Xuat
                                    LEFT JOIN DM_DonVi DVN ON DVN.Id=M.sDM_DonVi_Id_Nhap
                                    LEFT JOIN DM_ChungThuSo CTS ON CTS.Id=CT.sDM_ChungThuSo_Id
                                    WHERE M.Id='{baseEntity.GetIdentity()}'";
                    break;
                case "Phieu_NhapMuonTra":
                    query = $@"SELECT M.sMa,M.sSo,M.sChu,M.iNhapVeKho,M.Id as sPhieu_Id,M.sDM_DonVi_Id_Nhap as sDM_DonVi_Id,DV.sTenDonvi AS sDM_DonVi_Id_Ten
                                    ,iTCNhap as iLoaiPhieu,M.dNgayPhieu_Nhap as dNgayPhieu
                                    ,CT.Id as sPhieu_Detail_Id,CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten,SP.sMaSanPham AS sDM_SanPham_Ma
                                    ,CT.sMaVach,CT.sDM_DonViTinh_Id,DVT.sTenDonViTinh as sDM_DonViTinh_Id_Ten 
                                    ,CT.rSoLuong as rSoLuong_Nhap,CT.rDonGia as rDonGia_Nhap,CT.rThanhTien as rThanhTien_Nhap
                                    ,CT.sCauHinhKyThuat,CT.sXuatXu,CT.iNamSX,CT.iThoiGianBaoHanh
                                    ,CT.iDonViThoiGianBaoHanh,CT.dHanBaoHanhDen,CT.SortOrder
                                    ,CT.sGhiChu,CT.sDM_ChungThuSo_Id as sDM_ChungThuSo_Id,CTS.sMaCTS as sDM_ChungThuSo_Id_Ten,CT.sSerial,CT.sSTTSP
                                    ,CT.sDM_MangLienLac_Id,MLL.sTenMangLienLac AS sDM_MangLienLac_Id_Ten 
                                    ,0 as bPhieuXuat
                                    ,M.sDM_DonVi_Id_Xuat as sDM_DonVi_Id_Nguon
                                    ,DVX.sTenDonvi as sDM_DonVi_Id_Nguon_Ten
                                    FROM dbo.Phieu_NhapMuonTra M
                                    JOIN Phieu_NhapMuonTra_CT CT ON M.Id=CT.sPhieu_NhapMuonTra_Id
                                    LEFT JOIN DM_SanPham SP ON SP.Id=CT.sDM_SanPham_Id
                                    LEFT JOIN DM_DonViTinh DVT ON DVT.Id=CT.sDM_DonViTinh_Id
                                    LEFT JOIN DM_MangLienLac MLL ON MLL.Id=CT.sDM_MangLienLac_Id
                                    LEFT JOIN DM_DonVi DV ON DV.Id=M.sDM_DonVi_Id_Nhap
                                    LEFT JOIN DM_DonVi DVX ON DVX.Id=M.sDM_DonVi_Id_Xuat
                                    LEFT JOIN DM_ChungThuSo CTS ON CTS.Id=CT.sDM_ChungThuSo_Id
                                    WHERE M.Id='{baseEntity.GetIdentity()}'";
                    break;
                case "Phieu_XuatMuonTra":
                    query = $@"SELECT M.sMa,M.sSo,M.sChu,0 as iNhapVeKho,M.Id as sPhieu_Id,M.sDM_DonVi_Id_Xuat as sDM_DonVi_Id,DV.sTenDonvi AS sDM_DonVi_Id_Ten
                                ,iTCXuat  as iLoaiPhieu,M.dNgayPhieu_Xuat as dNgayPhieu
                                ,CT.Id as sPhieu_Detail_Id,CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten,SP.sMaSanPham AS sDM_SanPham_Ma
                                ,CT.sMaVach,CT.sDM_DonViTinh_Id,DVT.sTenDonViTinh as sDM_DonViTinh_Id_Ten 
                                ,CT.rSoLuong as rSoLuong_Xuat,CT.rDonGia as rDonGia_Xuat,CT.rThanhTien as rThanhTien_Xuat
                                ,CT.sCauHinhKyThuat,CT.sXuatXu,CT.iNamSX,CT.iThoiGianBaoHanh
                                ,CT.iDonViThoiGianBaoHanh,CT.dHanBaoHanhDen,CT.SortOrder
                                ,CT.sGhiChu,CT.sDM_ChungThuSo_Id as sDM_ChungThuSo_Id,CTS.sMaCTS as sDM_ChungThuSo_Id_Ten,CT.sSerial,CT.sSTTSP
                                ,CT.sDM_MangLienLac_Id,MLL.sTenMangLienLac AS sDM_MangLienLac_Id_Ten 
                                ,1 as bPhieuXuat  
                                ,sDM_DonVi_Id_Nhap as sDM_DonVi_Id_Nguon
                                ,DVN.sTenDonvi as sDM_DonVi_Id_Nguon_Ten
                                FROM dbo.Phieu_XuatMuonTra M
                                JOIN Phieu_XuatMuonTra_CT CT ON M.Id=CT.sPhieu_XuatMuonTra_Id
                                LEFT JOIN DM_SanPham SP ON SP.Id=CT.sDM_SanPham_Id
                                LEFT JOIN DM_DonViTinh DVT ON DVT.Id=CT.sDM_DonViTinh_Id
                                LEFT JOIN DM_MangLienLac MLL ON MLL.Id=CT.sDM_MangLienLac_Id
                                LEFT JOIN DM_DonVi DV ON DV.Id=M.sDM_DonVi_Id_Xuat
                                LEFT JOIN DM_DonVi DVN ON DVN.Id=M.sDM_DonVi_Id_Nhap
                                LEFT JOIN DM_ChungThuSo CTS ON CTS.Id=CT.sDM_ChungThuSo_Id
                                WHERE M.Id='{baseEntity.GetIdentity()}'";
                    break;
                case "Phieu_XuatSuaChuaSanPham":
                    query = $@"SELECT M.sMa,M.sSo,M.sChu , 0 as iNhapVeKho,M.Id as sPhieu_Id,M.sDM_DonVi_Id_Xuat as sDM_DonVi_Id,DV.sTenDonvi AS sDM_DonVi_Id_Ten
                                ,iLoai  as iLoaiPhieu,M.dNgayPhieu_Xuat as dNgayPhieu
                                ,CT.Id as sPhieu_Detail_Id,CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten,SP.sMaSanPham AS sDM_SanPham_Ma
                                ,CT.sMaVach,CT.sDM_DonViTinh_Id,DVT.sTenDonViTinh as sDM_DonViTinh_Id_Ten 
                                ,CT.rSoLuong as rSoLuong_Xuat,CT.rDonGia as rDonGia_Xuat,CT.rThanhTien as rThanhTien_Xuat
                                ,CT.sCauHinhKyThuat,CT.sXuatXu,CT.iNamSX,CT.iThoiGianBaoHanh
                                ,CT.iDonViThoiGianBaoHanh,CT.dHanBaoHanhDen,CT.SortOrder
                                ,CT.sGhiChu,CT.sDM_ChungThuSo_Id as sDM_ChungThuSo_Id,CTS.sMaCTS as sDM_ChungThuSo_Id_Ten,CT.sSerial,CT.sSTTSP
                                ,CT.sDM_MangLienLac_Id,MLL.sTenMangLienLac AS sDM_MangLienLac_Id_Ten 
                                ,1 as bPhieuXuat 
                                ,M.sDM_DonVi_Id_Nhap as sDM_DonVi_Id_Nguon
                                ,DVN.sTenDonvi as sDM_DonVi_Id_Nguon_Ten
                                FROM dbo.Phieu_XuatSuaChuaSanPham M
                                JOIN Phieu_XuatSuaChuaSanPham_CT CT ON M.Id=CT.sPhieu_XuatSuaChuaSanPham_Id
                                LEFT JOIN DM_SanPham SP ON SP.Id=CT.sDM_SanPham_Id
                                LEFT JOIN DM_DonViTinh DVT ON DVT.Id=CT.sDM_DonViTinh_Id
                                LEFT JOIN DM_MangLienLac MLL ON MLL.Id=CT.sDM_MangLienLac_Id
                                LEFT JOIN DM_DonVi DV ON DV.Id=M.sDM_DonVi_Id_Xuat
                                LEFT JOIN DM_DonVi DVN ON DVN.Id=M.sDM_DonVi_Id_Nhap
                                LEFT JOIN DM_ChungThuSo CTS ON CTS.Id=CT.sDM_ChungThuSo_Id
                                WHERE M.Id='{baseEntity.GetIdentity()}'";
                    break;
                case "Phieu_NhapSuaChuaSanPham":
                    query = $@"SELECT M.sMa,M.sSo,M.sChu,M.iNhapVeKho,M.Id as sPhieu_Id,M.sDM_DonVi_Id_Nhap as sDM_DonVi_Id,DV.sTenDonvi AS sDM_DonVi_Id_Ten
                                    ,M.iLoai as iLoaiPhieu,M.dNgayPhieu_Nhap as dNgayPhieu
                                    ,CT.Id as sPhieu_Detail_Id,CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten,SP.sMaSanPham AS sDM_SanPham_Ma
                                    ,CT.sMaVach,CT.sDM_DonViTinh_Id,DVT.sTenDonViTinh as sDM_DonViTinh_Id_Ten 
                                    ,CT.rSoLuong as rSoLuong_Nhap,CT.rDonGia as rDonGia_Nhap,CT.rThanhTien as rThanhTien_Nhap
                                    ,CT.sCauHinhKyThuat,CT.sXuatXu,CT.iNamSX,CT.iThoiGianBaoHanh
                                    ,CT.iDonViThoiGianBaoHanh,CT.dHanBaoHanhDen,CT.SortOrder
                                    ,CT.sGhiChu,CT.sDM_ChungThuSo_Id as sDM_ChungThuSo_Id,CTS.sMaCTS as sDM_ChungThuSo_Id_Ten,CT.sSerial,CT.sSTTSP
                                    ,CT.sDM_MangLienLac_Id,MLL.sTenMangLienLac AS sDM_MangLienLac_Id_Ten 
                                    ,0 as bPhieuXuat     
                                    ,M.sDM_DonVi_Id_Xuat as sDM_DonVi_Id_Nguon
                                    ,DVX.sTenDonvi as sDM_DonVi_Id_Nguon_Ten
                                    FROM dbo.Phieu_NhapSuaChuaSanPham M
                                    JOIN Phieu_NhapSuaChuaSanPham_CT CT ON M.Id=CT.sPhieu_NhapSuaChuaSanPham_Id
                                    LEFT JOIN DM_SanPham SP ON SP.Id=CT.sDM_SanPham_Id
                                    LEFT JOIN DM_DonViTinh DVT ON DVT.Id=CT.sDM_DonViTinh_Id
                                    LEFT JOIN DM_MangLienLac MLL ON MLL.Id=CT.sDM_MangLienLac_Id
                                    LEFT JOIN DM_DonVi DV ON DV.Id=M.sDM_DonVi_Id_Nhap
                                    LEFT JOIN DM_DonVi DVX ON DVX.Id=M.sDM_DonVi_Id_Xuat
                                    LEFT JOIN DM_ChungThuSo CTS ON CTS.Id=CT.sDM_ChungThuSo_Id
                                    WHERE M.Id='{baseEntity.GetIdentity()}'";
                    break;

                case "Phieu_NhapCaiDatSanPham":
                    query = $@"SELECT M.sMa,M.sSo,M.sChu,M.iNhapVeKho,M.Id as sPhieu_Id,M.sDM_DonVi_Id_Nhap as sDM_DonVi_Id,DV.sTenDonvi AS sDM_DonVi_Id_Ten
                                    ,M.iLoai as iLoaiPhieu,M.dNgayPhieu_Nhap as dNgayPhieu
                                    ,CT.Id as sPhieu_Detail_Id,CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten,SP.sMaSanPham AS sDM_SanPham_Ma
                                    ,CT.sMaVach,CT.sDM_DonViTinh_Id,DVT.sTenDonViTinh as sDM_DonViTinh_Id_Ten 
                                    ,CT.rSoLuong as rSoLuong_Nhap,CT.rDonGia as rDonGia_Nhap,CT.rThanhTien as rThanhTien_Nhap
                                    ,CT.sCauHinhKyThuat,CT.sXuatXu,CT.iNamSX,CT.iThoiGianBaoHanh
                                    ,CT.iDonViThoiGianBaoHanh,CT.dHanBaoHanhDen,CT.SortOrder
                                    ,CT.sGhiChu,CT.sDM_ChungThuSo_Id as sDM_ChungThuSo_Id,CTS.sMaCTS as sDM_ChungThuSo_Id_Ten,CT.sSerial,CT.sSTTSP
                                    ,CT.sDM_MangLienLac_Id,MLL.sTenMangLienLac AS sDM_MangLienLac_Id_Ten 
                                    ,0 as bPhieuXuat 
                                    ,M.sDM_DonVi_Id_Xuat as sDM_DonVi_Id_Nguon
                                    ,DVX.sTenDonvi as sDM_DonVi_Id_Nguon_Ten
                                    FROM dbo.Phieu_NhapCaiDatSanPham M
                                    JOIN Phieu_NhapCaiDatSanPham_CT CT ON M.Id=CT.sPhieu_NhapCaiDatSanPham_Id
                                    LEFT JOIN DM_SanPham SP ON SP.Id=CT.sDM_SanPham_Id
                                    LEFT JOIN DM_DonViTinh DVT ON DVT.Id=CT.sDM_DonViTinh_Id
                                    LEFT JOIN DM_MangLienLac MLL ON MLL.Id=CT.sDM_MangLienLac_Id
                                    LEFT JOIN DM_DonVi DV ON DV.Id=M.sDM_DonVi_Id_Nhap                                   
                                    LEFT JOIN DM_DonVi DVX ON DVX.Id=M.sDM_DonVi_Id_Xuat
                                    LEFT JOIN DM_ChungThuSo CTS ON CTS.Id=CT.sDM_ChungThuSo_Id
                                    WHERE M.Id='{baseEntity.GetIdentity()}'";
                    break;

                case "Phieu_XuatCaiDatSanPham":
                    query = $@"SELECT M.sMa,M.sSo,M.sChu,0 as iNhapVeKho,M.Id as sPhieu_Id,M.sDM_DonVi_Id_Xuat as sDM_DonVi_Id,DV.sTenDonvi AS sDM_DonVi_Id_Ten
                                ,iLoai  as iLoaiPhieu,M.dNgayPhieu_Xuat as dNgayPhieu
                                ,CT.Id as sPhieu_Detail_Id,CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten,SP.sMaSanPham AS sDM_SanPham_Ma
                                ,CT.sMaVach,CT.sDM_DonViTinh_Id,DVT.sTenDonViTinh as sDM_DonViTinh_Id_Ten 
                                ,CT.rSoLuong as rSoLuong_Xuat,CT.rDonGia as rDonGia_Xuat,CT.rThanhTien as rThanhTien_Xuat
                                ,CT.sCauHinhKyThuat,CT.sXuatXu,CT.iNamSX,CT.iThoiGianBaoHanh
                                ,CT.iDonViThoiGianBaoHanh,CT.dHanBaoHanhDen,CT.SortOrder
                                ,CT.sGhiChu,CT.sDM_ChungThuSo_Id as sDM_ChungThuSo_Id,CTS.sMaCTS as sDM_ChungThuSo_Id_Ten,CT.sSerial,CT.sSTTSP
                                ,CT.sDM_MangLienLac_Id,MLL.sTenMangLienLac AS sDM_MangLienLac_Id_Ten 
                                ,1 as bPhieuXuat    
                                ,M.sDM_DonVi_Id_Nhap as sDM_DonVi_Id_Nguon
                                ,DVN.sTenDonvi as sDM_DonVi_Id_Nguon_Ten
                                FROM dbo.Phieu_XuatCaiDatSanPham M
                                JOIN Phieu_XuatCaiDatSanPham_CT CT ON M.Id=CT.sPhieu_XuatCaiDatSanPham_Id
                                LEFT JOIN DM_SanPham SP ON SP.Id=CT.sDM_SanPham_Id
                                LEFT JOIN DM_DonViTinh DVT ON DVT.Id=CT.sDM_DonViTinh_Id
                                LEFT JOIN DM_MangLienLac MLL ON MLL.Id=CT.sDM_MangLienLac_Id
                                LEFT JOIN DM_DonVi DV ON DV.Id=M.sDM_DonVi_Id_Xuat
                                LEFT JOIN DM_DonVi DVN ON DVN.Id=M.sDM_DonVi_Id_Nhap
                                LEFT JOIN DM_ChungThuSo CTS ON CTS.Id=CT.sDM_ChungThuSo_Id
                                WHERE M.Id='{baseEntity.GetIdentity()}'";
                    break;
                case "Phieu_XuatBaoHanhSanPham":
                    query = $@"SELECT M.sMa,M.sSo,M.sChu,0 as iNhapVeKho,M.Id as sPhieu_Id,M.sDM_DonVi_Id_Xuat as sDM_DonVi_Id,DV.sTenDonvi AS sDM_DonVi_Id_Ten
                                ,iLoai  as iLoaiPhieu,M.dNgayPhieu_Xuat as dNgayPhieu
                                ,CT.Id as sPhieu_Detail_Id,CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten,SP.sMaSanPham AS sDM_SanPham_Ma
                                ,CT.sMaVach,CT.sDM_DonViTinh_Id,DVT.sTenDonViTinh as sDM_DonViTinh_Id_Ten 
                                ,CT.rSoLuong as rSoLuong_Xuat,CT.rDonGia as rDonGia_Xuat,CT.rThanhTien as rThanhTien_Xuat
                                ,CT.sCauHinhKyThuat,CT.sXuatXu,CT.iNamSX,CT.iThoiGianBaoHanh
                                ,CT.iDonViThoiGianBaoHanh,CT.dHanBaoHanhDen,CT.SortOrder
                                ,CT.sGhiChu,CT.sDM_ChungThuSo_Id as sDM_ChungThuSo_Id,CTS.sMaCTS as sDM_ChungThuSo_Id_Ten,CT.sSerial,CT.sSTTSP
                                ,CT.sDM_MangLienLac_Id,MLL.sTenMangLienLac AS sDM_MangLienLac_Id_Ten 
                                ,1 as bPhieuXuat 
                                ,M.sDM_DonVi_Id_Nhap as sDM_DonVi_Id_Nguon
                                ,ISNULL(DVN.sTenDonvi,NCC.sTenNCC) as sDM_DonVi_Id_Nguon_Ten
                                FROM dbo.Phieu_XuatBaoHanhSanPham M
                                JOIN Phieu_XuatBaoHanhSanPham_CT CT ON M.Id=CT.sPhieu_XuatBaoHanhSanPham_Id
                                LEFT JOIN DM_SanPham SP ON SP.Id=CT.sDM_SanPham_Id
                                LEFT JOIN DM_DonViTinh DVT ON DVT.Id=CT.sDM_DonViTinh_Id
                                LEFT JOIN DM_MangLienLac MLL ON MLL.Id=CT.sDM_MangLienLac_Id
                                LEFT JOIN DM_DonVi DV ON DV.Id=M.sDM_DonVi_Id_Xuat
                                LEFT JOIN DM_DonVi DVN ON DVN.Id=M.sDM_DonVi_Id_Nhap
                                LEFT JOIN DM_NhaCC NCC ON NCC.Id=M.sDM_DonVi_Id_Nhap
                                LEFT JOIN DM_ChungThuSo CTS ON CTS.Id=CT.sDM_ChungThuSo_Id
                                WHERE M.Id='{baseEntity.GetIdentity()}'";
                    break;
                case "Phieu_NhapBaoHanhSanPham":
                    query = $@"SELECT M.sMa,M.sSo,M.sChu,M.iNhapVeKho,M.Id as sPhieu_Id,M.sDM_DonVi_Id_Nhap as sDM_DonVi_Id,DV.sTenDonvi AS sDM_DonVi_Id_Ten
                                    ,M.iLoai as iLoaiPhieu,M.dNgayPhieu_Nhap as dNgayPhieu
                                    ,CT.Id as sPhieu_Detail_Id,CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten,SP.sMaSanPham AS sDM_SanPham_Ma
                                    ,CT.sMaVach,CT.sDM_DonViTinh_Id,DVT.sTenDonViTinh as sDM_DonViTinh_Id_Ten 
                                    ,CT.rSoLuong as rSoLuong_Nhap,CT.rDonGia as rDonGia_Nhap,CT.rThanhTien as rThanhTien_Nhap
                                    ,CT.sCauHinhKyThuat,CT.sXuatXu,CT.iNamSX,CT.iThoiGianBaoHanh
                                    ,CT.iDonViThoiGianBaoHanh,CT.dHanBaoHanhDen,CT.SortOrder
                                    ,CT.sGhiChu,CT.sDM_ChungThuSo_Id as sDM_ChungThuSo_Id,CTS.sMaCTS as sDM_ChungThuSo_Id_Ten,CT.sSerial,CT.sSTTSP
                                    ,CT.sDM_MangLienLac_Id,MLL.sTenMangLienLac AS sDM_MangLienLac_Id_Ten 
                                    ,0 as bPhieuXuat     
                                    ,M.sDM_DonVi_Id_Xuat as sDM_DonVi_Id_Nguon
                                    ,ISNULL(DVX.sTenDonvi,NCC.sTenNCC) as sDM_DonVi_Id_Nguon_Ten
                                    FROM dbo.Phieu_NhapBaoHanhSanPham M
                                    JOIN Phieu_NhapBaoHanhSanPham_CT CT ON M.Id=CT.sPhieu_NhapBaoHanhSanPham_Id
                                    LEFT JOIN DM_SanPham SP ON SP.Id=CT.sDM_SanPham_Id
                                    LEFT JOIN DM_DonViTinh DVT ON DVT.Id=CT.sDM_DonViTinh_Id
                                    LEFT JOIN DM_MangLienLac MLL ON MLL.Id=CT.sDM_MangLienLac_Id
                                    LEFT JOIN DM_DonVi DV ON DV.Id=M.sDM_DonVi_Id_Nhap                                  
                                    LEFT JOIN DM_DonVi DVX ON DVX.Id=M.sDM_DonVi_Id_Xuat
                                    LEFT JOIN DM_NhaCC NCC ON NCC.Id=M.sDM_DonVi_Id_Xuat
                                    LEFT JOIN DM_ChungThuSo CTS ON CTS.Id=CT.sDM_ChungThuSo_Id
                                    WHERE M.Id='{baseEntity.GetIdentity()}'";
                    break;
                case "Phieu_NhapTHTH":
                    query = $@"SELECT M.sMa,M.sSo,M.sChu,M.iNhapVeKho,M.Id as sPhieu_Id,M.sDM_DonVi_Id_Nhap as sDM_DonVi_Id,DV.sTenDonvi AS sDM_DonVi_Id_Ten
                                    ,M.iTCNhap as iLoaiPhieu,M.dNgayPhieu_Nhap as dNgayPhieu
                                    ,CT.Id as sPhieu_Detail_Id,CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten,SP.sMaSanPham AS sDM_SanPham_Ma
                                    ,CT.sMaVach,CT.sDM_DonViTinh_Id,DVT.sTenDonViTinh as sDM_DonViTinh_Id_Ten 
                                    ,CT.rSoLuong as rSoLuong_Nhap,CT.rDonGia as rDonGia_Nhap,CT.rThanhTien as rThanhTien_Nhap
                                    ,CT.sCauHinhKyThuat,CT.sXuatXu,CT.iNamSX,CT.iThoiGianBaoHanh
                                    ,CT.iDonViThoiGianBaoHanh,CT.dHanBaoHanhDen,CT.SortOrder
                                    ,CT.sGhiChu,CT.sDM_ChungThuSo_Id as sDM_ChungThuSo_Id,CTS.sMaCTS as sDM_ChungThuSo_Id_Ten,CT.sSerial,CT.sSTTSP
                                    ,CT.sDM_MangLienLac_Id,MLL.sTenMangLienLac AS sDM_MangLienLac_Id_Ten 
                                    ,0 as bPhieuXuat     
                                    ,M.sDM_DonVi_Id_Xuat as sDM_DonVi_Id_Nguon
                                    ,DVX.sTenDonvi as sDM_DonVi_Id_Nguon_Ten
                                    FROM dbo.Phieu_NhapTHTH M
                                    JOIN Phieu_NhapTHTH_CT CT ON M.Id=CT.sPhieu_NhapTHTH_Id
                                    LEFT JOIN DM_SanPham SP ON SP.Id=CT.sDM_SanPham_Id
                                    LEFT JOIN DM_DonViTinh DVT ON DVT.Id=CT.sDM_DonViTinh_Id
                                    LEFT JOIN DM_MangLienLac MLL ON MLL.Id=CT.sDM_MangLienLac_Id
                                    LEFT JOIN DM_DonVi DV ON DV.Id=M.sDM_DonVi_Id_Nhap                                  
                                    LEFT JOIN DM_DonVi DVX ON DVX.Id=M.sDM_DonVi_Id_Xuat
                                    LEFT JOIN DM_ChungThuSo CTS ON CTS.Id=CT.sDM_ChungThuSo_Id
                                    WHERE M.Id='{baseEntity.GetIdentity()}'";
                    break;
                case "Phieu_XuatTHTH":
                    query = $@"SELECT M.sMa,M.sSo,M.sChu,0 as iNhapVeKho,M.Id as sPhieu_Id,M.sDM_DonVi_Id_Xuat as sDM_DonVi_Id,DV.sTenDonvi AS sDM_DonVi_Id_Ten
                                ,iTCXuat  as iLoaiPhieu,M.dNgayPhieu_Xuat as dNgayPhieu
                                ,CT.Id as sPhieu_Detail_Id,CT.sDM_SanPham_Id,SP.sTenSanPham as sDM_SanPham_Id_Ten,SP.sMaSanPham AS sDM_SanPham_Ma
                                ,CT.sMaVach,CT.sDM_DonViTinh_Id,DVT.sTenDonViTinh as sDM_DonViTinh_Id_Ten 
                                ,CT.rSoLuong as rSoLuong_Xuat,CT.rDonGia as rDonGia_Xuat,CT.rThanhTien as rThanhTien_Xuat
                                ,CT.sCauHinhKyThuat,CT.sXuatXu,CT.iNamSX,CT.iThoiGianBaoHanh
                                ,CT.iDonViThoiGianBaoHanh,CT.dHanBaoHanhDen,CT.SortOrder
                                ,CT.sGhiChu,CT.sDM_ChungThuSo_Id as sDM_ChungThuSo_Id,CTS.sMaCTS as sDM_ChungThuSo_Id_Ten,CT.sSerial,CT.sSTTSP
                                ,CT.sDM_MangLienLac_Id,MLL.sTenMangLienLac AS sDM_MangLienLac_Id_Ten 
                                ,1 as bPhieuXuat 
                                ,M.sDM_DonVi_Id_Nhap as sDM_DonVi_Id_Nguon
                                ,DVN.sTenDonvi as sDM_DonVi_Id_Nguon_Ten
                                FROM dbo.Phieu_XuatTHTH M
                                JOIN Phieu_XuatTHTH_CT CT ON M.Id=CT.sPhieu_XuatTHTH_Id
                                LEFT JOIN DM_SanPham SP ON SP.Id=CT.sDM_SanPham_Id
                                LEFT JOIN DM_DonViTinh DVT ON DVT.Id=CT.sDM_DonViTinh_Id
                                LEFT JOIN DM_MangLienLac MLL ON MLL.Id=CT.sDM_MangLienLac_Id
                                LEFT JOIN DM_DonVi DV ON DV.Id=M.sDM_DonVi_Id_Xuat
                                LEFT JOIN DM_DonVi DVN ON DVN.Id=M.sDM_DonVi_Id_Nhap
                                LEFT JOIN DM_ChungThuSo CTS ON CTS.Id=CT.sDM_ChungThuSo_Id
                                WHERE M.Id='{baseEntity.GetIdentity()}'";
                    break;
            }
            return query;
        }


        /// <summary>
        /// Lấy số tồn kho của sản phẩm theo id sản phẩm, đơn vị tính
        /// </summary>
        /// <param name="sDM_DonVi_Id">Đơn vị check số tồn</param>
        /// <param name="sDM_SanPham_Id">Id sản phẩm</param>
        /// <param name="sDM_DonViTinh_Id">Đơn vị tính</param>
        /// <returns>Trả về thông tin số tồn của sản phẩm</returns>
        public static TonKhoViewModel GetTonKho(Guid sDM_DonVi_Id, Guid sDM_SanPham_Id, Guid sDM_DonViTinh_Id)
        {
            string md5Id = $"{sDM_DonVi_Id}{sDM_SanPham_Id}{sDM_DonViTinh_Id}".CreateMD5();
            string query = $@"select sDM_SanPham_Id,sDM_SanPham_Ma,sDM_SanPham_Id_Ten,
                            sDM_DonViTinh_Id,sDM_DonViTinh_Id_Ten,
                            sum(ISNULL(rSoLuong_Nhap,0)) - sum(ISNULL(rSoLuong_Xuat,0)) rSoLuongTon  from [dbo].[SoKho]
                            where sMd5Id='{md5Id}'                            
                            group by sDM_SanPham_Id,sDM_SanPham_Ma,sDM_SanPham_Id_Ten,
                            sDM_DonViTinh_Id,sDM_DonViTinh_Id_Ten";

            using (IUnitOfWork unitOfWork = new UnitOfWork(MT.Library.SessionData.ConnectString))
            {
                return unitOfWork.QueryFirstOrDefault<TonKhoViewModel>(query);
            }
        }

        /// <summary>
        /// Lấy số tồn kho theo mã vạch của sản phẩm
        /// </summary>
        /// <param name="sMaVach">Đơn vị check số tồn</param>
        /// <returns>Trả về thông tin số tồn của sản phẩm</returns>
        public static TonKhoViewModel GetTonKho(string sMaVach)
        {
            string query = $@"select sDM_SanPham_Id,sDM_SanPham_Ma,sDM_SanPham_Id_Ten,
                            sDM_DonViTinh_Id,sDM_DonViTinh_Id_Ten,
                            sum(ISNULL(rSoLuong_Nhap,0)) - sum(ISNULL(rSoLuong_Xuat,0)) rSoLuongTon  from [dbo].[SoKho]
                            where sMaVach=@sMaVach                                  
                            group by sDM_SanPham_Id,sDM_SanPham_Ma,sDM_SanPham_Id_Ten,
                            sDM_DonViTinh_Id,sDM_DonViTinh_Id_Ten";

            using (IUnitOfWork unitOfWork = new UnitOfWork(MT.Library.SessionData.ConnectString))
            {
                return unitOfWork.QueryFirstOrDefault<TonKhoViewModel>(query, new { sMaVach = sMaVach });
            }
        }
        /// <summary>
        /// Lấy số tồn kho theo mã vạch của sản phẩm
        /// </summary>
        /// <param name="sMaVach">Đơn vị check số tồn</param>
        /// <returns>Trả về thông tin số tồn của sản phẩm</returns>
        public static TonKhoViewModel GetTonKho(string sMaVach, Guid dvID, int soLuongXoa = 0)
        {
            string query = $@"select sDM_SanPham_Id,sDM_SanPham_Ma,sDM_SanPham_Id_Ten,
                            sDM_DonViTinh_Id,sDM_DonViTinh_Id_Ten,
                            sum(ISNULL(rSoLuong_Nhap,0)) 
                                - sum(ISNULL(rSoLuong_Xuat,0)) rSoLuongTon  
                            from [dbo].[SoKho]
                            where sMaVach=@sMaVach and sDM_DonVi_Id ='{dvID}'                                   
                            group by sDM_SanPham_Id,sDM_SanPham_Ma,sDM_SanPham_Id_Ten,
                            sDM_DonViTinh_Id,sDM_DonViTinh_Id_Ten";

            using (IUnitOfWork unitOfWork = new UnitOfWork(MT.Library.SessionData.ConnectString))
            {
                var tonKhoViewModel = unitOfWork.QueryFirstOrDefault<TonKhoViewModel>(query, new { sMaVach = sMaVach });
                if (tonKhoViewModel == null) tonKhoViewModel = new TonKhoViewModel() { rSoLuongTon = soLuongXoa };
                else tonKhoViewModel.rSoLuongTon += soLuongXoa;
                return tonKhoViewModel;
            }
        }


        /// <summary>
        /// Lấy số tồn kho theo mã vạch của sản phẩm
        /// </summary>
        /// <param name="sMaVach">Đơn vị check số tồn</param>
        /// <returns>Trả về thông tin số tồn của sản phẩm</returns>
        public static List<TonKhoViewModel> GetChiTietTonKho(string sMaVach, Guid? sDM_DonVi_Id, 
            List<Guid> sDM_SanPham_Ids, bool isExistssMaVachPositive, bool isExistsAtStock,bool isExistsRealInStock)
        {
            string where = string.Empty;
            if (sDM_SanPham_Ids?.Count > 0)
            {
                where = $" WHERE SP.Id IN({string.Join(",",sDM_SanPham_Ids.Select(sp=>$"'{sp}'"))}) ";
            }
            if (!string.IsNullOrWhiteSpace(sMaVach))
            {
                if (!string.IsNullOrWhiteSpace(where))
                {
                    where += $" AND sMaVach LIKE '%{sMaVach.Trim()}%'";
                }
                else
                {
                    where += $" WHERE sMaVach LIKE '%{sMaVach.Trim()}%'";
                }
            }
          
            string appendWhere = string.Empty;

            string expressionQuantity = $@"sum(ISNULL(S.rSoLuong_Nhap,0)-ISNULL(S.rSoLuong_Xuat, 0))";

            //Chỉ hiển thị số tồn tại kho
            if (isExistsAtStock)
            {
                expressionQuantity = $@"sum(
                                case 
                                    WHEN S.iNhapVeKho = 1 then ISNULL(S.rSoLuong_Nhap,0)
                                    else 0
                                end -ISNULL(S.rSoLuong_Xuat, 0))";
            }

            if (isExistssMaVachPositive || isExistsRealInStock)
            {
                appendWhere = $@"WHERE rSoLuongTon>0";
            }

            List<Guid> sDM_DonVi_Ids = new List<Guid>();
            using (IUnitOfWork unitOfWork = new UnitOfWork(MT.Library.SessionData.ConnectString))
            {
                if (sDM_DonVi_Id.HasValue && !"00000000-0000-0000-0000-000000000000".Equals(sDM_DonVi_Id.Value))
                {
                    sDM_DonVi_Ids.Add(sDM_DonVi_Id.Value);
                    //Nếu là đơn vị cha và có con theo cơ cấu tổ chức thì cộng tồn kho cho cả cha và con theo cơ cấu tổ chức
                    string queryDonVi = $@"select ID from DM_DonVi where sParentId='{sDM_DonVi_Id.Value}'
                                         AND iType = 1";

                    var donviIds = unitOfWork.Query<Guid>(queryDonVi);

                    if (donviIds?.Count > 0)
                    {
                        sDM_DonVi_Ids.AddRange(donviIds);
                    }

                }

                string joinSoKho = string.Empty;


                if (sDM_DonVi_Ids.Count > 0)
                {
                    joinSoKho = $" AND S.sDM_DonVi_Id IN({string.Join(",", sDM_DonVi_Ids.Select(m => "'" + m + "'"))})";
                }

                if (!isExistsRealInStock)
                {
                    joinSoKho += " AND S.iLoaiPhieu IN(1,12, 23, 73,22,72,82)";
                }

                string query = $@"SELECT T.*,SUM(rSoLuongTon) OVER(PARTITION BY sDM_SanPham_Ma,sDM_DonVi_Id_Ten) AS rSoLuongTongTon
                            FROM(SELECT DISTINCT * FROM(SELECT SP.sTenSanPham as sDM_SanPham_Id_Ten, SP.sMaSanPham AS sDM_SanPham_Ma,
                            ISNULL(S.sDM_DonViTinh_Id_Ten,DVT.sTenDonViTinh) AS sDM_DonViTinh_Id_Ten,sDM_DonVi_Id_Ten,sMaVach,
                            {expressionQuantity} OVER(PARTITION BY sMaVach,sDM_DonVi_Id_Ten) AS rSoLuongTon
                            from dbo.DM_SanPham SP 
                            LEFT JOIN DM_DonViTinh DVT ON SP.sDM_DonViTinh_Id_Cap1=DVT.Id
                            LEFT JOIN [dbo].[SoKho] S ON SP.ID=S.sDM_SanPham_Id
                            {joinSoKho}
                            {where}) AS T1) AS T  {appendWhere}
                            ORDER BY sDM_SanPham_Ma,sDM_DonViTinh_Id_Ten,sDM_DonVi_Id_Ten,sMaVach";

           
                var tonKhoViewModels = unitOfWork.Query<TonKhoViewModel>(query);
                return tonKhoViewModels;
            }
        }

        /// <summary>
        /// Lấy sản phẩm đang tồn trong kho
        /// </summary>
        /// <param name="dvID">Mã đơn vị check số tồn</param>
        /// <returns>Trả về danh sách sản phẩm tồn trong kho</returns> 
        public static List<DM_SanPham> GetSanPhamTonTrongKho(Guid dvID)
        {
            string query = $@"select 
		                            sk.sDM_SanPham_Id AS Id,
		                            sk.sDM_SanPham_Ma AS sMaSanPham,
		                            sk.sDM_SanPham_Id_Ten AS sTenSanPham,
                                    sk.sDM_DonViTinh_Id,
		                            sk.sDM_DonViTinh_Id_Ten,
		                            vdmsp.sDM_NhomSanPham_Id_Ten
                            from [dbo].[SoKho] sk
		                    LEFT JOIN View_DM_SanPham vdmsp ON sk.sDM_SanPham_Id = vdmsp.Id
                            where sk.sDM_DonVi_Id ='{dvID}'                                   
                            group by sk.sDM_SanPham_Id, sk.sDM_SanPham_Ma, sk.sDM_SanPham_Id_Ten,
                            sk.sDM_DonViTinh_Id,sk.sDM_DonViTinh_Id_Ten,vdmsp.sDM_NhomSanPham_Id_Ten
                            having(sum(ISNULL(sk.rSoLuong_Nhap, 0)) -sum(ISNULL(sk.rSoLuong_Xuat, 0)) > 0 ) 
		                    ORDER BY vdmsp.sDM_NhomSanPham_Id_Ten,sMaSanPham";

            using (IUnitOfWork unitOfWork = new UnitOfWork(MT.Library.SessionData.ConnectString))
            {
                return unitOfWork.Query<DM_SanPham>(query);
            }
        }
    }
}
