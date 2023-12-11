using MT.Library.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class frmOrverview : Form
    {
        public frmOrverview()
        {
            InitializeComponent();

            Init();
        }

        #region"Sub/Func"
        /// <summary>
        /// Khởi tạo form
        /// </summary>
        private void Init()
        {
            //1. Báo cáo tổng quan
            ucHeaderOverview.DictionaryKey = (int)MT.Data.DashBoardDictionaryKey.RP_BaoCaoTongQuan;
            ucHeaderOverview.WhenLoadDataSuccess = baoCaoTongQuan_WhenLoadDataSuccess;
            var tuple = MT.Library.Utility.GetDateRangeByPeriod((int)MT.Library.Enummation.Period.ThangNay);
            ucHeaderOverview.Params = new Dictionary<string, object>
            {
                {"OrganizationUnitId",MT.Library.SessionData.OrganizationUnitId },
                {"OrganizationUnitIdText",MT.Library.SessionData.OrganizationUnitName },
                {"Period",(int)MT.Library.Enummation.Period.ThangNay },
                {"FromDate",tuple.Item1},
                {"ToDate",tuple.Item2}
            };
            ucHeaderOverview.BuildSubTitle = (Dictionary<string, object> dicParam) =>
            {
                string sfromDateAndToDate = $"Thời gian: từ ngày {dicParam.GetValueOfDictionary<DateTime>("FromDate").ToString("dd/MM/yyyy")} đến ngày { dicParam.GetValueOfDictionary<DateTime>("ToDate").ToString("dd/MM/yyyy")}";
                string title = $@"Đơn vị: {dicParam.GetValueOfDictionary<string>("OrganizationUnitIdText")}; {sfromDateAndToDate}";
                return title;
            };

            //2. Cảnh báo tham số mật mã hết hạn
            ucHeaderDashboardCanhBaoThamSoMatMaHetHan.DictionaryKey = (int)MT.Data.DashBoardDictionaryKey.RP_CanhBaoThamSoMatMaHetHan;
            ucHeaderDashboardCanhBaoThamSoMatMaHetHan.Params = new Dictionary<string, object>
            {
                {"BeforeDays",10}
            };

            ucHeaderDashboardCanhBaoThamSoMatMaHetHan.BuildSubTitle = (Dictionary<string, object> dicParam) =>
            {
                string strBeforeDays = $@"Cảnh báo trước {dicParam.GetValueOfDictionary<int>("BeforeDays")} ngày";
                string title = $@"{strBeforeDays}";
                return title;
            };
            ucHeaderDashboardCanhBaoThamSoMatMaHetHan.WhenLoadDataSuccess = canhBaoThamSoMMHetHan_WhenLoadDataSuccess;
            var grd = this.gridThamSoMatMa;
            this.gridThamSoMatMa.KeyName = "Id";
            var col = this.gridThamSoMatMa.AddColumnText("sMaThamSoMatMa", "Mã TSMM","Mã tham số mật mã", 100, isFixWidth: true);
            this.gridThamSoMatMa.AddColumnText("sTenThamSoMatMa", "Tên TSMM","Tên tham số mật mã", 200);
            this.gridThamSoMatMa.AddColumnText("iThoiHanSuDung", "Thời hạn SD","Thời hạn sử dụng", 100);
            col = this.gridThamSoMatMa.AddColumnText("iDonViThoiGianHieuLuc", "Đơn vị t.gian", 80);
            col.EnumName = "iDonViThoiGianHieuLuc";
            this.gridThamSoMatMa.AddColumnText("dNgayHieuLuc", "Ngày hiệu lực", 100);
            this.gridThamSoMatMa.AddColumnText("dNgayHetHan", "Ngày hết hạn", 100);
            this.gridThamSoMatMa.AddColumnText("sGhiChu", "Ghi chú", 300);

            //3. Cảnh báo chứng thư số hết hạn
            ucHeaderDashboardChungThuSoHetHan.DictionaryKey = (int)MT.Data.DashBoardDictionaryKey.RP_CanhBaoChungThuSoHetHan;
            ucHeaderDashboardChungThuSoHetHan.Params = new Dictionary<string, object>
            {
                {"BeforeDays",10}
            };

            ucHeaderDashboardChungThuSoHetHan.BuildSubTitle = (Dictionary<string, object> dicParam) =>
            {
                string strBeforeDays = $@"Cảnh báo trước {dicParam.GetValueOfDictionary<int>("BeforeDays")} ngày";
                string title = $@"{strBeforeDays}";
                return title;
            };
            ucHeaderDashboardChungThuSoHetHan.WhenLoadDataSuccess = canhBaoChungThuSoHetHan_WhenLoadDataSuccess;
            this.grdChungThuSoHetHan.KeyName = "Id";
            this.grdChungThuSoHetHan.AddColumnText("sMaCTS", "Mã CTS", "Mã chứng thư số", 120);
            this.grdChungThuSoHetHan.AddColumnText("sHoSo", "Hồ sơ", 180);
            this.grdChungThuSoHetHan.AddColumnText("sMaVach", "Mã vạch", 100);
            this.grdChungThuSoHetHan.AddColumnText("sSerialNumber", "Serial number", 100);
            this.grdChungThuSoHetHan.AddColumnText("sPassword", "Mật khẩu", 100);
            this.grdChungThuSoHetHan.AddColumnText("sMasterCode", "MasterCode", 150);
            this.grdChungThuSoHetHan.AddColumnText("sChuNhan", "Chủ nhân", 200);
            this.grdChungThuSoHetHan.AddColumnText("sEmail", "Email", 100);
            this.grdChungThuSoHetHan.AddColumnText("sTenToChucCap1", "Tổ chức cấp 1", 200);
            this.grdChungThuSoHetHan.AddColumnText("sTenToChucCap2", "Tổ chức cấp 2", 200);
            this.grdChungThuSoHetHan.AddColumnText("sTenToChucCap3", "Tổ chức cấp 3", 200);
            this.grdChungThuSoHetHan.AddColumnText("sTenToChucCap4", "Tổ chức cấp 4", 200);
            this.grdChungThuSoHetHan.AddColumnText("sDiaChi", "Địa chỉ", 200);
            this.grdChungThuSoHetHan.AddColumnText("sTenNguoi", "Người thực hiện", 200);
            this.grdChungThuSoHetHan.AddColumnText("dNgayBatDau", "Ngày thực hiện", 100);
            this.grdChungThuSoHetHan.AddColumnText("dNgayKetThuc", "Ngày kết thúc", 100);
            this.grdChungThuSoHetHan.AddColumnText("sGhiChu", "Ghi chú", 250);
        }
        #endregion
        #region"Event"
        /// <summary>
        /// Báo cáo tổng quan khi load dữ liệu thành công - chứng thư số hết hạn
        /// </summary>
        /// <param name="result">Dữ liệu trả về</param>
        /// <param name="param">Danh sách tham số</param>
        private void canhBaoChungThuSoHetHan_WhenLoadDataSuccess(object result, Dictionary<string, object> param)
        {
            DataTable dtResult = result as DataTable;
            this.grdChungThuSoHetHan.DataSource = dtResult;
        }


        /// <summary>
        /// Báo cáo tổng quan khi load dữ liệu thành công
        /// </summary>
        /// <param name="result">Dữ liệu trả về</param>
        /// <param name="param">Danh sách tham số</param>
        private void canhBaoThamSoMMHetHan_WhenLoadDataSuccess(object result, Dictionary<string, object> param)
        {
            DataTable dtResult = result as DataTable;
            this.gridThamSoMatMa.DataSource = dtResult;
        }

        /// <summary>
        /// Báo cáo tổng quan khi load dữ liệu thành công
        /// </summary>
        /// <param name="result">Dữ liệu trả về</param>
        /// <param name="param">Danh sách tham số</param>
        private void baoCaoTongQuan_WhenLoadDataSuccess(object result,Dictionary<string,object> param)
        {
            DataTable dtResult = result as DataTable;
            if (dtResult != null)
            {
                List<Label> labelsChoDuyet = new List<Label>();
                CommonFnUI.GetAllControls<Label>(pnlChoDuyet, ref labelsChoDuyet);
                foreach (var item in labelsChoDuyet)
                {
                    if (item.Tag == null)
                    {
                        continue;
                    }
                    DataRow dataRow= dtResult.AsEnumerable()
                                   .SingleOrDefault(r => r.Field<int>("Id") ==Convert.ToInt32(item.Tag));
                                        item.Text = dataRow?.Field<int>("Quantity").ToString();
                }

                List<Label> labelsDaDuyet = new List<Label>();
                CommonFnUI.GetAllControls<Label>(pnlDaduyet, ref labelsDaDuyet);
                foreach (var item in labelsDaDuyet)
                {
                    if (item.Tag == null)
                    {
                        continue;
                    }
                    DataRow dataRow = dtResult.AsEnumerable()
                                   .SingleOrDefault(r => r.Field<int>("Id") == Convert.ToInt32(item.Tag));
                    item.Text = dataRow?.Field<int>("Quantity").ToString();
                }

                List<Label> labelsTuChoi = new List<Label>();
                CommonFnUI.GetAllControls<Label>(pnlTuChoi, ref labelsTuChoi);
                foreach (var item in labelsTuChoi)
                {
                    if (item.Tag == null)
                    {
                        continue;
                    }
                    DataRow dataRow = dtResult.AsEnumerable()
                                   .SingleOrDefault(r => r.Field<int>("Id") == Convert.ToInt32(item.Tag));
                    item.Text = dataRow?.Field<int>("Quantity").ToString();
                }

                List<Label> labelsHoanThanh= new List<Label>();
                CommonFnUI.GetAllControls<Label>(pnlHoanThanh, ref labelsHoanThanh);
                foreach (var item in labelsHoanThanh)
                {
                    if (item.Tag == null)
                    {
                        continue;
                    }
                    DataRow dataRow = dtResult.AsEnumerable()
                                   .SingleOrDefault(r => r.Field<int>("Id") == Convert.ToInt32(item.Tag));
                    item.Text = dataRow?.Field<int>("Quantity").ToString();
                }
            }
        }
        #endregion
    }
}
