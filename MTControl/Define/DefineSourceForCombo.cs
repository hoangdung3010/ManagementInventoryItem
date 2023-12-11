using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTControl
{
    public static class DefineSourceForCombo
    {
        public static Dictionary<string, string> DefineSource = new Dictionary<string, string>()
        {
            {"DM_NhomKhachHang","{\"Primarykey\":\"iID_MaNhomKhachHang\", \"DisplayMember\":\"sTen\",\"ValueMember\":\"sMaNhomKhachHang\",\"Columns\":\"sMaNhomKhachHang|100;sTen|150\"}" },
            {"DM_TacGia","{\"Primarykey\":\"iID_MaTacGia\",\"DisplayMember\":\"sTen\",\"ValueMember\":\"sMaTacGia\",\"Columns\":\"sMaTacGia|100;sTen|150\"}" },
            {"DM_NhomHangHoa","{\"Primarykey\":\"iID_MaNhomHangHoa\",\"DisplayMember\":\"sTen\",\"ValueMember\":\"sMaNhomHangHoa\",\"Columns\":\"sMaNhomHangHoa|100;sTen|150\"}" },
            {"DM_NV","{\"Primarykey\":\"sMaNV\",\"DisplayMember\":\"sTen\",\"ValueMember\":\"sMaNV\",\"Columns\":\"sMaNV|100;sTen|150\"}" },
            {"DM_NhomNCC","{\"Primarykey\":\"iID_MaNhomNCC\",\"DisplayMember\":\"sTen\",\"ValueMember\":\"sMaNhomNCC\",\"Columns\":\"sMaNhomNCC|100;sTen|150\"}" },
            {"DM_ToChuc","{\"Primarykey\":\"iID_MaToChuc\",\"DisplayMember\":\"sTen\",\"ValueMember\":\"sMaToChuc\",\"Columns\":\"sMaToChuc|100;sTen|150\"}" },
            {"DM_LoaiBoPhan","{\"Primarykey\":\"iID_MaLoaiBoPhan\",\"DisplayMember\":\"sTen\",\"ValueMember\":\"sMaLoaiBoPhan\",\"Columns\":\"sMaLoaiBoPhan|100;sTen|150\"}" },
            {"NS_BaoHang","{\"Primarykey\":\"iID_MaBaoHang\",\"DisplayMember\":\"sSoPhieu\",\"ValueMember\":\"iID_MaBaoHang\",\"Columns\":\"sSoPhieu|150\"}" },
            {"DM_DVT","{\"Primarykey\":\"iID_MaDVT\",\"DisplayMember\":\"sTen\",\"ValueMember\":\"iID_MaDVT\",\"Columns\":\"sTen|150\"}" },
            {"DM_NhaXuatBan","{\"Primarykey\":\"iID_MaNhaXuatBan\",\"DisplayMember\":\"sTen\",\"ValueMember\":\"iID_MaNhaXuatBan\",\"Columns\":\"sTen|150\"}" }
        };

        /// <summary>
        /// Config cho RepositoryComboLookup
        /// </summary>
        public static Dictionary<string, string> DefineRepositoryColumn = new Dictionary<string, string>()
        {
            
            {"iID_MaHangHoa","{\"KeyStore\":\"DM_HangHoa\",\"IsShowQuickSearch\":true,\"IsShowAddDictionnary\":true,\"TableName\":\"DM_HangHoa\",\"Primarykey\":\"iID_MaHangHoa\", \"DisplayMember\":\"sMaHangHoa\",\"ValueMember\":\"sMaHangHoa\",\"Columns\":\"sMaHangHoa|100;sTen|150\"}" },
        };
    }
}
