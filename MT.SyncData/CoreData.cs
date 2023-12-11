using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.SyncData
{
    public class CoreData
    {
        protected bool? _isDonViLaBanCoYeu = null;

        /// <summary>
        /// Định nghĩa danh sách bảng liên quan sẽ export cùng phiếu xuất
        /// </summary>
        protected Dictionary<string, List<string>> _dicRelatedTable = new Dictionary<string, List<string>>
        {
            {"Phieu_XuatSanPham", new List<string>
                {
                    "Phieu_NhapSanPham;Phieu_XuatSanPham;KH_XuatSanPham;KH_XuatBaoDam",
                    "KH_XuatSanPham;KH_XuatBaoDam"
                }
            },
            {"Phieu_XuatMuonTra", new List<string>
                {
                    "Phieu_NhapMuonTra;Phieu_XuatMuonTra;KH_XuatMuonTra",
                    "KH_XuatMuonTra"
                }
            },
            {"Phieu_XuatSuaChuaSanPham", new List<string>
                {
                    "Phieu_NhapSuaChuaSanPham;Phieu_XuatSuaChuaSanPham;KH_SuaChuaSanPham",
                    "KH_SuaChuaSanPham"
                }
            },
            {"Phieu_XuatCaiDatSanPham", new List<string>
                {
                    "Phieu_NhapCaiDatSanPham;Phieu_XuatCaiDatSanPham;KH_CaiDatSanPham",
                    "KH_CaiDatSanPham"
                }
            },
            {"Phieu_XuatBaoHanhSanPham", new List<string>
                {
                    "Phieu_NhapBaoHanhSanPham;Phieu_XuatBaoHanhSanPham;KH_BaoHanhSanPham",
                    "KH_BaoHanhSanPham"
                }
            },
            {"Phieu_XuatTHTH", new List<string>
                {
                    "Phieu_NhapTHTH;Phieu_XuatTHTH;KH_XuatTHTH",
                    "KH_XuatTHTH"
                }
            }
        };
        /// <summary>
        /// Kiểm tra đơn vị có phải ban cơ yếu không
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="orgId">Đơn vị export</param>
        protected bool KiemTraDonViLaBanCoYeu(IUnitOfWork unitOfWork, Guid orgId)
        {
            string query = $"IF EXISTS(SELECT * FROM ConfigExportData WHERE sDM_DonVi_Id_DonViXuat='{orgId}' AND iType=0) SELECT 1 ELSE SELECT 0";

            var isDonViLaBanCoYeu = unitOfWork.QueryFirstOrDefault<bool>(query);

            MT.Library.Log.LogHelper.Debug($"KiemTraDonViLaBanCoYeu: {isDonViLaBanCoYeu}");

            return isDonViLaBanCoYeu;
        }
    }
}
