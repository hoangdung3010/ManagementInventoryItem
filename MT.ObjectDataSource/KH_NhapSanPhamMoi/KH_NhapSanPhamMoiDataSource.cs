using MT.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.ObjectDataSource
{
   public class KH_NhapSanPhamMoiDataSource:ReportDataSource
    {
        #region Instance Properties
        public Guid Id { get; set; }

        public string sMa { get; set; }

        public string sSo { get; set; }

        public string sChu { get; set; }

        public DateTime? dNgayLap { get; set; }
        public string sDM_DonVi_Id_DonViXayDungKH_Ten { get; set; }

        public string sDM_NhaCC_Id_Ten { get; set; }

        public string sDM_HinhThucLCNT_Id_Ten { get; set; }

        public string sDM_NguonVon_Id_Ten { get; set; }

        public string sDM_CanBo_Id_NguoiLapKH_Ten { get; set; }

        public string sDM_CanBo_Id_NguoiDuyet_Ten { get; set; }

        public string sDM_CanBo_Id_ThuTruongDonVi_Ten { get; set; }

        public string sDM_DonVi_Id_DonViNhap_Ten { get; set; }

        public string sSoHopDong { get; set; }

        public DateTime? dNgayHopDong { get; set; }

        public int? iThoiGianHieuLuc { get; set; }

        public int iDonViThoiGianHieuLuc { get; set; }
        public string sGhiChu { get; set; }

        public List<KH_NhapSanPhamMoi_CTDataSource> KH_NhapSanPhamMoiCTDataSources { get; set; }

        public int iTrangThaiDuyet { get; set; }

        public DateTime? dNgayDuyet { get; set; }
        public string sLyDoXetDuyet { get; set; }

        public decimal rThanhTien { get; set; }

        public string sConvertThanhTienToChu
        {
            get
            {
                return MT.Library.Utility.NumberToText(rThanhTien);
            }
        }
        #endregion Instance Properties

        #region"Contructor"
        #endregion

        #region"Sub/Func"
        /// <summary>
        /// Khởi tạo đối tượng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tableName"></param>
        public override void InitData(object id, string tableName)
        {
            base.InitData(id, tableName);

            string query = $"SELECT * FROM dbo.View_KH_NhapSanPhamMoi WHERE Id='{id}'";
            var objData = UnitOfWork.QueryFirstOrDefault<KH_NhapSanPhamMoiDataSource>(query);
            this.CopyObject(objData);
            query = $"select * from View_KH_NhapSanPhamMoi_CT where sKH_NhapSanPhamMoi_Id='{id}' order by SortOrder";
            this.KH_NhapSanPhamMoiCTDataSources = UnitOfWork.Query<KH_NhapSanPhamMoi_CTDataSource>(query);
            if (this.KH_NhapSanPhamMoiCTDataSources != null && this.KH_NhapSanPhamMoiCTDataSources.Count>0)
            {
                this.rThanhTien = this.KH_NhapSanPhamMoiCTDataSources.Sum(m => m.rThanhTien);
                var ids = string.Join(",", this.KH_NhapSanPhamMoiCTDataSources.Select(m => $"'{m.Id}'"));
                query = $@"select * from View_KH_NhapSanPhamMoi_CT_PhuKien 
                           where sKH_NhapSanPhamMoi_CT_Id IN({ids}) 
                           order by sKH_NhapSanPhamMoi_CT_Id,SortOrder;";
                var details= UnitOfWork.Query<KH_NhapSanPhamMoi_CT_PhuKienDataSource>(query);

                foreach (var item in this.KH_NhapSanPhamMoiCTDataSources)
                {
                    var phukiens = details?.FindAll(m => m.sKH_NhapSanPhamMoi_CT_Id == item.Id)
                        .OrderBy(m=>m.SortOrder).ToList();

                    item.PhuKiens = phukiens;
                }
                
            }

        }
        #endregion
    }
}
