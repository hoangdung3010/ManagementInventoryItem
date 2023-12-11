using MT.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.ObjectDataSource
{
   public class Phieu_NhapSanPhamMoiDataSource : ReportDataSource
    {
        #region Instance Properties
        public Guid Id { get; set; }

        public string sSo { get; set; }

        public string sChu { get; set; }
        public string sMa { get; set; }

        public string sSo_KH { get; set; }

        public string sChu_KH { get; set; }
        public string sMa_KH { get; set; }

        public DateTime? dNgayPhieu_NhapSanPhamMoi { get; set; }

        public string sKH_NhapSanPhamMoi_Id_CanCu_Ten { get; set; }

        public string sDM_NhaCC_Id_Ten { get; set; }

        public string sNguoiGiao { get; set; }

        public string sDM_DonVi_Id_Nhap_Ten { get; set; }

        public string sDM_CanBo_Id_NguoiNhap_Ten { get; set; }

        public string sDM_CanBo_Id_NguoiLapPhieu_Ten { get; set; }
        public string sDM_CanBo_Id_NguoiDuyet_Ten { get; set; }

        public decimal rThanhTien { get; set; }

        public string sGhiChu { get; set; }

        public List<Phieu_NhapSanPhamMoi_CTDataSource> Phieu_NhapSanPhamMoi_CTs { get; set; }

        public bool iNhapVeKho { get; set; }

        public int iTrangThaiDuyet { get; set; }

        public DateTime? dNgayDuyet { get; set; }
        public string sLyDoXetDuyet { get; set; }
        public string sConvertThanhTienToChu
        {
            get
            {
                return MT.Library.Utility.NumberToText(rThanhTien);
            }
        }
        #endregion Instance Properties

        #region"Contructors"
        public Phieu_NhapSanPhamMoiDataSource()
        {
        }
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

            string query = $"SELECT * FROM dbo.View_Phieu_NhapSanPhamMoi WHERE Id='{id}'";
            var objData = UnitOfWork.QueryFirstOrDefault<Phieu_NhapSanPhamMoiDataSource>(query);
            this.CopyObject(objData);
            query = $"select * from View_Phieu_NhapSanPhamMoi_CT where sPhieu_NhapSanPhamMoi_Id='{id}' order by SortOrder";
            this.Phieu_NhapSanPhamMoi_CTs = UnitOfWork.Query<Phieu_NhapSanPhamMoi_CTDataSource>(query);
            if (this.Phieu_NhapSanPhamMoi_CTs != null && this.Phieu_NhapSanPhamMoi_CTs.Count > 0)
            {
                this.rThanhTien = this.Phieu_NhapSanPhamMoi_CTs.Sum(m => m.rThanhTien);
                var ids = string.Join(",", this.Phieu_NhapSanPhamMoi_CTs.Select(m => $"'{m.Id}'"));
                query = $@"select * from View_Phieu_NhapSanPhamMoi_CT_PhuKien 
                           where sPhieu_NhapSanPhamMoi_CT_Id IN({ids}) 
                           order by sPhieu_NhapSanPhamMoi_CT_Id,SortOrder;";
                var details = UnitOfWork.Query<Phieu_NhapSanPhamMoi_CT_PhuKienDataSource>(query);

                foreach (var item in this.Phieu_NhapSanPhamMoi_CTs)
                {
                    var phukiens = details?.FindAll(m => m.sPhieu_NhapSanPhamMoi_CT_Id == item.Id)
                        .OrderBy(m => m.SortOrder).ToList();
                    item.Phieu_NhapSanPhamMoi_CT_PhuKiens = phukiens;
                }

            }

        }
        #endregion
    }
}
