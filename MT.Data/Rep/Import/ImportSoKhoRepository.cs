using MT.Data.BO;
using MT.Library.Extensions;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.Rep
{
    public class ImportSoKhoRepository : ImportBaseRepository
    {
        public ImportSoKhoRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {
        }

        /// <summary>
        /// Danh sách cột tham gia insert
        /// </summary>
        protected override List<string> GetColsInsert()
        {
            var cols= base.GetColsInsert();
            cols.Add("sDM_DonViTinh_Id_Ten");
            cols.Add("sDM_MangLienLac_Id_Ten");
            cols.Add("sDM_ChungThuSo_Id_Ten");
            cols.Add("sDM_DonVi_Id_Ten");
            cols.Add("iLoaiPhieu");
            cols.Add("sMa");
            cols.Add("dNgayPhieu");
            cols.Add("sSerial");
            cols.Add("iNamSX");
            cols.Add("sDM_DonVi_Id");
            cols.Add("sDM_SanPham_Id");
            cols.Add("sDM_SanPham_Id_Ten");
            cols.Add("sDM_SanPham_Ma");
            return cols;
        }

        /// <summary>
        /// Danh sách cột tham gia update
        /// </summary>
        /// <returns></returns>
        protected override List<string> GetColsUpdate()
        {
            var cols = base.GetColsUpdate();
            cols.Add("M.[sDM_DonViTinh_Id_Ten]=T.[sDM_DonViTinh_Id_Ten]");
            cols.Add("M.[sDM_MangLienLac_Id_Ten]=T.[sDM_MangLienLac_Id_Ten]");
            cols.Add("M.[sDM_ChungThuSo_Id_Ten]=T.[sDM_ChungThuSo_Id_Ten]");
            cols.Add("M.[sDM_DonVi_Id_Ten]=T.[sDM_DonVi_Id_Ten]");
            cols.Add("M.[iLoaiPhieu]=T.[iLoaiPhieu]");
            cols.Add("M.[sSerial]=T.[sSerial]");
            cols.Add("M.[iNamSX]=T.[iNamSX]");
            cols.Add("M.[sDM_DonVi_Id]=T.[sDM_DonVi_Id]");
            cols.Add("M.[sDM_SanPham_Id]=T.[sDM_SanPham_Id]");
            cols.Add("M.[sDM_SanPham_Id_Ten]=T.[sDM_SanPham_Id_Ten]");
            cols.Add("M.[sDM_SanPham_Ma]=T.[sDM_SanPham_Ma]");
            return cols;
        }

        /// <summary>
        /// Thực thêm điệu kiện where vào câu lệnh update
        /// </summary>
        protected override string AppendWhereUpdate()
        {
            string sWhere= base.AppendWhereUpdate();
            if (!string.IsNullOrWhiteSpace(sWhere))
            {
                sWhere += " AND M.iLoaiPhieu=1";
            }
            return sWhere;
        }

        /// <summary>
        /// Thực hiện validate dữ liệu đầu kỳ trước khi nhập khẩu
        /// </summary>
        /// <param name="rowData"></param>
        protected override void ValidData(object rowData)
        {
            base.ValidData(rowData);

            var sk = (SoKho)rowData;

            List<string> msgErrors = new List<string>();

            string msg = sk.ImportError;
            if (!string.IsNullOrWhiteSpace(msg))
            {
                msgErrors.Add(msg);
            }
            //Kiểm tra đơn vị có tồn tại trong hệ thống không
            if (!string.IsNullOrWhiteSpace(sk.sDM_DonVi_Id_Ma))
            {
                string query = "SELECT sMaDonVi,sTenDonvi,Id  FROM DM_DonVi WHERE sMaDonVi=@sMaDonVi";

                DM_DonVi dM_DonVi = _unitOfWork.QueryFirstOrDefault<DM_DonVi>(query, new { sMaDonVi = sk.sDM_DonVi_Id_Ma });

                if (dM_DonVi == null)
                {
                    msgErrors.Add(string.Format("Mã đơn vị: <{0}> không tồn tại trong hệ thống", sk.sDM_DonVi_Id_Ma));
                }
                else
                {
                    rowData.SetValue(nameof(sk.sDM_DonVi_Id), dM_DonVi.Id);
                    rowData.SetValue(nameof(sk.sDM_DonVi_Id_Ten), dM_DonVi.sTenDonvi);
                }
            }

            //Kiểm tra mạng liên lạc có tồn tại không

            //if (!string.IsNullOrWhiteSpace(sk.sDM_MangLienLac_Id_Ten))
            //{
            //    string query = "SELECT Id,sTenMangLienLac  FROM DM_MangLienLac WHERE sTenMangLienLac=@sTenMangLienLac";

            //    DM_MangLienLac dM_MangLienLac = _unitOfWork.QueryFirstOrDefault<DM_MangLienLac>(query, new { sTenMangLienLac = sk.sDM_MangLienLac_Id_Ten });

            //    if (dM_MangLienLac == null)
            //    {
            //        msgErrors.Add(string.Format("Mạng liên lạc: <{0}> không tồn tại trong hệ thống", sk.sDM_MangLienLac_Id_Ten));
            //    }
            //    else
            //    {
            //        rowData.SetValue(nameof(sk.sDM_MangLienLac_Id), dM_MangLienLac.Id);
            //        rowData.SetValue(nameof(sk.sDM_MangLienLac_Id_Ten), dM_MangLienLac.sTenMangLienLac);
            //    }
            //}

            //Kiểm tra chứng thư số có tồn tại không
            //if (!string.IsNullOrWhiteSpace(sk.sDM_ChungThuSo_Id_Ten))
            //{
            //    string query = "SELECT Id,sMaCTS  FROM DM_ChungThuSo WHERE sMaCTS=@sMaCTS";

            //    DM_ChungThuSo dM_ChungThuSo = _unitOfWork.QueryFirstOrDefault<DM_ChungThuSo>(query, new { sMaCTS = sk.sDM_ChungThuSo_Id_Ten });

            //    if (dM_ChungThuSo == null)
            //    {
            //        msgErrors.Add(string.Format("Chứng thư số: <{0}> không tồn tại trong hệ thống", sk.sDM_MangLienLac_Id_Ten));
            //    }
            //    else
            //    {
            //        rowData.SetValue(nameof(sk.sDM_ChungThuSo_Id), dM_ChungThuSo.Id);
            //        rowData.SetValue(nameof(sk.sDM_ChungThuSo_Id_Ten), dM_ChungThuSo.sMaCTS);
            //    }
            //}

            //Kiểm tra mã vạch có hợp lệ không
            if (!MT.Library.Utility.ValidsMaVach(sk.sMaVach))
            {
                msgErrors.Add(string.Format("Mã vạch :<{0}> không hợp lệ", sk.sMaVach));
            }
            else
            {
                string sMaSP = string.Empty;
                string sSerial = string.Empty;
                int iNamSX = 0;
                bool isValid = false;
                try
                {
                    sMaSP = sk.sMaVach.Substring(4, 4);
                    sSerial = sk.sMaVach.Substring(8, 5) + "/";
                    sSerial += sk.sMaVach.Substring(13, 2);
                    iNamSX = int.Parse($"20{sk.sMaVach.Substring(13, 2)}");

                    isValid = true;
                }
                catch (Exception)
                {
                    msgErrors.Add(string.Format("Mã vạch: <{0}> không đúng định dạng", sk.sMaVach));
                    isValid = false;
                }
                if (isValid)
                {
                    sk.sSerial = sSerial;
                    sk.iNamSX = iNamSX;

                    string query = "SELECT Id,sTenSanPham,sMaSanPham  FROM DM_SanPham WHERE sMaSanPham=@sMaSanPham";

                    DM_SanPham dM_SanPham = _unitOfWork.QueryFirstOrDefault<DM_SanPham>(query, new { sMaSanPham = sMaSP });

                    if (dM_SanPham == null)
                    {
                        msgErrors.Add(string.Format("Mã vạch: <{0}> với Mã sản phẩm: <{1}> không tồn tại trong hệ thống", sk.sMaVach, sMaSP));
                    }
                    else
                    {
                        rowData.SetValue(nameof(sk.sDM_SanPham_Id), dM_SanPham.Id);
                        rowData.SetValue(nameof(sk.sDM_SanPham_Id_Ten), dM_SanPham.sTenSanPham);
                        rowData.SetValue(nameof(sk.sDM_SanPham_Ma), dM_SanPham.sMaSanPham);
                    }
                }

            }

            //Nếu là nhập khẩu thêm mới thì kiểm tra mã vạch đã tồn tại trong hệ thống chưa
            if (_argumentImport.AddNew && !string.IsNullOrWhiteSpace(sk.sMaVach))
            {
                string query = "SELECT Id  FROM SoKho WHERE sMaVach=@sMaVach";

                SoKho skMV = _unitOfWork.QueryFirstOrDefault<SoKho>(query, new { sMaVach = sk.sMaVach });

                if (skMV != null)
                {
                    msgErrors.Add(string.Format("Mã vạch: <{0}> đã tồn tại trong hệ thống", sk.sMaVach));
                }
            }

            //Nếu là nhập khẩu cập nhật

            if (msgErrors.Count > 0)
            {
                SetDataError(rowData, false, string.Join("; ", msgErrors));
            }
            else
            {
                SetDataError(rowData, true);
            }
        }

        /// <summary>
        /// Gán thêm dữ liệu vào đối tượng
        /// </summary>
        /// <param name="rowData"></param>
        public override void UpdateMoreData(object rowData)
        {
            base.UpdateMoreData(rowData);
            rowData.SetValue("sMa", "TDK");
            rowData.SetValue("iLoaiPhieu", 1);
            rowData.SetValue("dNgayPhieu", new DateTime(1753,1,1));
        }
    }
}
