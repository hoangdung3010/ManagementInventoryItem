using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data
{
    public enum iDonViThoiGianHieuLuc
    {
        Ngay = 1,
        Thang = 2,
        Quy = 3,
        Nam = 4
    }

    public enum iDonViThoiGianBaoHanh
    {
        Ngay = 1,
        Thang = 2,
        Quy = 3,
        Nam = 4
    }

    public enum iLoaiKH
    {
        ct = 1,
        tx = 2,
        tlmm = 3,
        khac = 4
    }

    public enum iNhapVeKho
    {
        Sudung = 0,
        LuuKho = 1
    }

    /// <summary>
    /// Enum loại phiếu nhập xuất
    /// 0: Đầu kỳ,12: Nhập mới(Về kho),13: Nhập mới(Sử dụng), 22: Xuất, 23: Nhập,32-Xuất mượn; 33-Nhập mượn; 34-Xuất trả; 35-Nhập nhận về,
    /// 42-Xuất SC; 43-Nhập SC; 44-Xuất SC; 45-Nhập nhận về,52-Xuất đi cài đặt; 53-Nhập về cài đặt; 54-Xuất trả về; 55-Nhập trả về,
    /// 62-Xuất bảo hành; 63-Nhập bảo hành; 64-Xuất trả; 65-Nhập nhận về;72-Xuất thu hồi; 73-Nhập thu hồi;82-Xuất huỷ
    /// </summary>
    public enum iLoaiPhieu
    {
        DauKy = 0,
        NhapMoi = 12,
        XuatSP = 22,
        NhapSP = 23,
        XuatMuon = 32,
        NhapMuon = 33,
        XuatTra = 34,
        NhapNhanVe = 35,
        XuatSCĐi = 42,
        NhapVaoSC = 43,
        XuatSCTraVeSauSC = 44,
        NhapSCNhanVeSauSC = 45,
        XuatĐiCĐ = 52,
        NhapVaoCĐ = 53,
        XuatTraSauCĐ = 54,
        NhapNhanVeSauCĐ = 55,
        XuatBH = 62,
        NhapBH = 63,
        XuatTraSauBH = 64,
        NhapNhanVeSauBH = 65,
        XuatThuHoi = 72,
        NhapThuHoi = 73,
        XuatHuy = 82
    }

    public enum iTCXuat
    {
        [Description("Xuất mượn")]
        XuatMuon = 32,
        [Description("Xuất trả")]
        XuatTra = 34
    }
    public enum iTCNhap
    {
        [Description("Nhập mượn")]
        NhapMuon = 33,
        [Description("Nhập trả về")]
        NhapTra = 35
    }

    public enum iTCXuatTH
    {
        [Description("Xuất thu hồi")]
        XuatThuHoi = 72,
        [Description("Xuất tiêu hủy")]
        XuatHuy = 82
    }
    public enum iTCNhapTH
    {
        [Description("Nhập thu hồi")]
        NhapThuHoi = 73,
    }
    /// <summary>
    /// Enum chức vụ
    /// </summary>
    public enum iChucVu
    {
        CucTruong = 1,
        PhoCucTruong = 2,
        PhoGiamDoc = 3,
        TruongPhong = 4,
        PhoTruongPhong = 5,
        TroLy = 6,
        ThuKho = 7,
        KeToanKho = 8,
        Khac = 9
    }

    /// <summary>
    /// Trạng thái duyệt kế hoạch nhập mới
    /// </summary>
    public enum iTrangThaiDuyetKHNM
    {
        ChoDuyet = 0,
        DongYDuyet = 1,
        TuChoiDuyet = 2
    }

    /// <summary>
    /// Trạng thái thực hiện kế hoạch nhập mới
    /// </summary>
    public enum iTrangThaiThucHienKHNM
    {
        ChuaThucHien = 0,
        DangThucHien = 1,
        DaHoanThanh = 2,
    }

    /// <summary>
    /// Trạng thái thực hiện kế hoạch cài đặt sp
    /// </summary>
    public enum iTrangThaiThucHienKHCDSP
    {
        ChuaThucHien = 0,
        DangThucHien = 1,
        DaHoanThanh = 2,
    }

    /// <summary>
    /// Trạng thái thực hiện kế hoạch sửa chữa
    /// </summary>
    public enum iTrangThaiThucHienKHSC
    {
        ChuaThucHien = 0,
        DangThucHien = 1,
        DaHoanThanh = 2,
    }


    /// <summary>
    /// Trạng thái duyệt phiếu nhập mới
    /// </summary>
    public enum iTrangThaiDuyetPNM
    {
        ChoDuyet = 0,
        DongYDuyet = 1,
        TuChoiDuyet = 2
    }

    /// <summary>
    /// Trạng thái duyệt kế hoạch cài đặt sản phẩm
    /// </summary>
    public enum iTrangThaiDuyetKHCĐSP
    {
        ChoDuyet = 0,
        DongYDuyet = 1,
        TuChoiDuyet = 2
    }

    /// <summary>
    /// Trạng thái duyệt phiếu xuất CĐ
    /// </summary>
    public enum iTrangThaiDuyetPXCĐSP
    {
        ChoDuyet = 0,
        DongYDuyet = 1,
        TuChoiDuyet = 2
    }

    public enum iTCXuatCĐ
    {
        XuatCĐĐi = 52,
        XuatCĐTraVeSauCĐ = 54
    }
    public enum iTCNhapCĐ
    {
        NhapCĐ = 53,
        NhapLaiSauCĐ = 55
    }

    /// <summary>
    /// Trạng thái duyệt phiếu xuất SC
    /// </summary>
    public enum iTrangThaiDuyetPXSC
    {
        ChoDuyet = 0,
        DongYDuyet = 1,
        TuChoiDuyet = 2
    }

    /// <summary>
    /// Trạng thái duyệt phiếu nhập SC
    /// </summary>
    public enum iTrangThaiDuyetPNSC
    {
        ChoDuyet = 0,
        DongYDuyet = 1,
        TuChoiDuyet = 2
    }

    public enum iLoaiXuatSuaChua
    {
        XuatSCĐi = 42,
        XuatSCTraVeSauSC = 44,
    }

    public enum iLoaiNhapSuaChua
    {
        NhapVaoSC = 43,
        NhapSCNhanVeSauSC = 45,
    }



    /// <summary>
    /// Trạng thái duyệt phiếu xuất BH
    /// </summary>
    public enum iTrangThaiDuyetPXBH
    {
        ChoDuyet = 0,
        DongYDuyet = 1,
        TuChoiDuyet = 2
    }

    /// <summary>
    /// Trạng thái duyệt phiếu nhập BH
    /// </summary>
    public enum iTrangThaiDuyetPNBH
    {
        ChoDuyet = 0,
        DongYDuyet = 1,
        TuChoiDuyet = 2
    }

    public enum iLoaiXuatBaoHanh
    {
        XuatBH = 62,
        XuatTraSauBH = 64
    }

    public enum iLoaiNhapBaoHanh
    {
        NhapBH = 63,
        NhapNhanVeSauBH = 65
    }

    /// <summary>
    /// Enum báo cáo
    /// </summary>
    public enum ReportDictionaryKey
    {
        /// <summary>
        /// Tổng hợp Nhập-Xuất-Tồn kho (Mẫu 10/13/BCY-QLKT)
        /// </summary>
        RP_NhapXuatTon_Mau10_13 = 1,
        /// <summary>
        /// Báo cáo quyết toán máy mã và T.B.N.V(Mẫu 21/13/QLKT-BCY)
        /// </summary>
        RP_QuyetToanMayMaAndTBNV_Mau21_13 = 2,
        /// <summary>
        /// Báo cáo quyết toán các tài liệu KTMM (Mẫu 20/13/QLKT-BCY)
        /// </summary>
        RP_QuyetToanTLKTMM_Mau20_13_QLKT_BCY = 3,

        /// <summary>
        /// PHỤ LỤC 1
        /// </summary>
        RP_KH_XuatBaoDam_PhuLuc1 = 4,

        RP_TangGiam_Mau04_2009 = 5,

        /// <summary>
        /// PHỤ LỤC 2
        /// </summary>
        RP_KH_XuatBaoDam_PhuLuc2 = 6,

        /// <summary>
        /// Mẫu kiểm kê
        /// </summary>
        RP_TinhHinhTaiSan0h_Mau03_2009 = 7,

        /// <summary>
        /// Mẫu in kế hoạch nhập mới
        /// </summary>
        RP_Print_KHNhapSPMM_Detail = 8,

        /// <summary>
        /// Mẫu in phiếu nhập mới
        /// </summary>
        RP_Print_Phieu_NhapSanPhamMoi = 9,

        /// <summary>
        /// Mẫu in Kế hoạch sửa chữa SP
        /// </summary>
        RP_Print_KH_SuaChuaSanPhamDetail = 10,
        /// <summary>
        /// Mẫu in Phiếu xuất sửa chữa SP
        /// </summary>
        RP_Print_Phieu_XuatSuaChuaSanPhamDetail = 11,
        /// <summary>
        /// Mẫu in Phiếu nhập sửa chữa SP
        /// </summary>
        RP_Print_Phieu_NhapSuaChuaSanPhamDetail = 12,

        /// <summary>
        /// Mẫu phụ lục 03
        /// </summary>
        RP_KH_XuatBaoDam_PhuLuc3 = 33,

        /// <summary>
        /// Mẫu in Kế hoạch cài đặt SP
        /// </summary>
        RP_Print_KH_CaiDatSanPhamDetail = 34,
        /// <summary>
        /// Mẫu in Phiếu xuất cài đặt SP
        /// </summary>
        RP_Print_Phieu_XuatCaiDatSanPhamDetail = 35,
        /// <summary>
        /// Mẫu in Phiếu nhập cài đặt SP
        /// </summary>
        RP_Print_Phieu_NhapCaiDatSanPhamDetail = 36,
        /// <summary>
        /// Mẫu in Kế hoạch bảo hành SP
        /// </summary>
        RP_Print_KH_BaoHanhSanPhamDetail = 37,
        /// <summary>
        /// Mẫu in Phiếu xuất bảo hành SP
        /// </summary>
        RP_Print_Phieu_XuatBaoHanhSanPhamDetail = 38,
        /// <summary>
        /// Mẫu in Phiếu nhập bảo hành SP
        /// </summary>
        RP_Print_Phieu_NhapBaoHanhSanPhamDetail = 39,
        /// <summary>
        /// Mẫu in kế hoạch bảo đảm
        /// </summary>
        RP_Print_KH_XuatBaoDamDetail = 20,
        /// <summary>
        /// Mẫu in Phiếu nhập  SP
        /// </summary>
        RP_Print_KH_XuatSanPhamDetail = 21,
        /// <summary>
        /// Mẫu in Phiếu xuất SP
        /// </summary>
        RP_Print_Phieu_XuatSanPhamDetail = 22,
        /// <summary>
        /// Mẫu in Phiếu nhập  SP
        /// </summary>
        RP_Print_Phieu_NhapSanPhamDetail = 23,
        /// <summary>
        /// Mẫu in Phiếu nhập  SP
        /// </summary>
        RP_Print_KH_XuatMuonTraDetail = 24,
        /// <summary>
        /// Mẫu in Phiếu nhập  SP
        /// </summary>
        RP_Print_Phieu_XuatMuonTraDetail = 25,
        /// <summary>
        /// Mẫu in Phiếu nhập  SP
        /// </summary>
        RP_Print_Phieu_NhapMuonTraDetail = 26,
        /// <summary>
        /// Mẫu in Phiếu nhập  SP
        /// </summary>
        RP_Print_Phieu_XuatTHTHDetail = 27,
        /// <summary>
        /// Mẫu in Phiếu nhập  SP
        /// </summary>
        RP_Print_Phieu_NhapTHTHDetail = 28,
        /// <summary>
        /// Mẫu in Phiếu nhập  SP
        /// </summary>
        RP_Print_KHXuatTHTH_Detail = 40,

    }


    /// <summary>
    /// Enum dashboard
    /// </summary>
    public enum DashBoardDictionaryKey
    {
        None = 0,
        /// <summary>
        /// Báo cáo tổng quan
        /// </summary>
        RP_BaoCaoTongQuan = 1,
        /// <summary>
        /// Cảnh báo tham số mật mã hết hạn
        /// </summary>
        RP_CanhBaoThamSoMatMaHetHan = 2,
        /// <summary>
        /// Cảnh báo chứng thư số hết hạn
        /// </summary>
        RP_CanhBaoChungThuSoHetHan = 3
    }

    public enum bKepChi
    {
        Co = 1,
        Khong = 0
    }

    public enum ImportDataType
    {
        DM_SanPham=0,
        DM_ThamSoMatMa=1,
        DM_ChungThuSo=2,
        SoKho=3
    }

    /// <summary>
    /// Các hệ dùng phần mềm
    /// </summary>
    public enum OrganizationUnitType
    {
        BCY=1,
        QĐ=2,
        CA=3,
        ĐCQ=4
    }

    public enum DM_DonVi_iType
    {
        None=0,
        CCTC=1,
        NghiepVu=2
    }

    public enum TrangThaiTimKiemSanPham
    {
        DangSuaChua = 1,
        DangBaoHanh = 2,
        DaThuHoiThanhLy = 3,
        DaTieuHuy = 4,
        DangChoMuon = 5,
        ChuaSuDung =6,
        DangSuDung=7      
        
    }
}