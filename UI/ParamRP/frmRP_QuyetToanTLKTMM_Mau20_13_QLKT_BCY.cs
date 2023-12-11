using FormUI.Base;
using MT.Data.BO;
using MT.Data.Rep;
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
    public partial class frmRP_QuyetToanTLKTMM_Mau20_13_QLKT_BCY : MXTraForm
    {
        #region"Declare"
        #endregion
        #region"Contructor"
        public frmRP_QuyetToanTLKTMM_Mau20_13_QLKT_BCY()
        {
            InitializeComponent();
            mUserControlParamRP.RootControl = groupBoxInput;
            ucDateRangePeriod.SetField("dtuNgay", "ddenNgay", "period");
            mUserControlParamRP.ConfigReport = new MT.Data.BO.ConfigReport
            {
                RepName= "QuyetToanTLKTMM_Mau20_13_QLKT_BCYRepository",
                DictionaryKey= MT.Data.ReportDictionaryKey.RP_QuyetToanTLKTMM_Mau20_13_QLKT_BCY,
                ShowColumnsOrder=new HashSet<string>
                {
                    "sSTT","sTenTaiLieu","sDonViTinh","rSoluongTonDK","sSohieuTonDK","rSoluongNhap",
                    "sSohieuNhap","rSoLuongTongNhapCongTon","rSoluongXuatSuDung","sSoHieuXuatSuDung","sPhamViLienLac","dNgaySuDung",
                    "dNgayThoiSuDung","rSoluongXuatThuHoiTieuHuy","sSohieuXuatThuHoiTieuHuy","rSoluongConLai","sSohieuConLai"
                }
            };

            mUserControlParamRP.MySetCustomConfigExcel=(ConfigExcel  configExcel)=>{
                configExcel.Title = "Báo cáo quyết toán các loại tài liệu KTMM".ToUpper();
                MTParameter mTParameterFromDate = configExcel.ParametersExcel.GetValueOfDictionary("dtuNgay");
                MTParameter mTParameterToDate = configExcel.ParametersExcel.GetValueOfDictionary("ddenNgay");
                configExcel.SubTitle = $"Từ ngày {mTParameterFromDate?.Value} đến ngày {mTParameterToDate?.Value}";

                //Lấy tên cơ cấu tổ chức
                configExcel.ParametersExcel.AddOrUpdate("sTenDonViGui",new MTParameter { Value = cboDonVi.Text });
                configExcel.ParametersExcel.AddOrUpdate("sTenDonViNhan",new MTParameter { Value = cboDonViNhan.Text });
            };
        }
        #endregion

        #region"Sub/Func"
        private void Init()
        {
            var dM_DonViRepository = (DM_DonViRepository)DBContext.GetRep<MT.Data.Rep.DM_DonViRepository>();
            var donvis = dM_DonViRepository.GetData(typeof(DM_DonVi), "Id,sMaDonvi,sTenDonvi,sParentId", orderBy: "sMaDonvi");

            var donVisTruyCap = dM_DonViRepository.GetEmployeeAccessLevel(MT.Library.SessionData.UserId);

            cboDonVi.Properties.DisplayMember = "sTenDonvi";
            cboDonVi.Properties.ValueMember = "Id";
            var treeListDonVi = cboDonVi.Properties.TreeList;
            treeListDonVi.KeyFieldName = "Id";
            treeListDonVi.ParentFieldName = "sParentId";
            cboDonVi.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            cboDonVi.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            cboDonVi.Properties.DataSource = donVisTruyCap;

            cboDonViNhan.Properties.DisplayMember = "sTenDonvi";
            cboDonViNhan.Properties.ValueMember = "Id";
            var treeListDonViNhan = cboDonViNhan.Properties.TreeList;
            treeListDonViNhan.KeyFieldName = "Id";
            treeListDonViNhan.ParentFieldName = "sParentId";
            cboDonViNhan.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            cboDonViNhan.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            cboDonViNhan.Properties.DataSource = donvis;

            ucDateRangePeriod.BackColor = this.BackColor;

            cboLoaiPhieuNhap.ItemEnum.Add(-1, "Tất cả");
            cboLoaiPhieuNhap.DefaultValueEnum = -1;
            cboLoaiPhieuNhap.EnumData = "iNhapVeKho";
        }
        #endregion

        #region"Event"
        private void frmRP_NhapXuatTon_Mau10_13_Load(object sender, EventArgs e)
        {
            Init();
            ucDateRangePeriod.SetDefaultValue(MT.Library.Enummation.Period.ThangNay);
        }
        #endregion

    }
}
