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
    public partial class frmRP_TinhHinhTaiSan0h_Mau03_2009 : MXTraForm
    {
        #region"Declare"
        #endregion
        #region"Contructor"
        public frmRP_TinhHinhTaiSan0h_Mau03_2009()
        {
            InitializeComponent();
            mUserControlParamRP.RootControl = groupBoxInput;
            mUserControlParamRP.ConfigReport = new MT.Data.BO.ConfigReport
            {
                RepName= "TinhHinhTaiSan0h_Mau03_2009Repository",
                DictionaryKey= MT.Data.ReportDictionaryKey.RP_TinhHinhTaiSan0h_Mau03_2009,
                ShowColumnsOrder=new HashSet<string>
                {
                    "sSTT","sTenLoaiTaiSan","sDM_DonViTinh_Id_Ten","iNamDuaVaoSuDung","rSoLuong1","rDongia","rGiaTri1",
                    "rPhanTramConLai","rSoLuong2","rGiaTri2","sGhiChu"
                }
            };

            mUserControlParamRP.MySetCustomConfigExcel=(ConfigExcel  configExcel)=>{
                configExcel.Title = $"Báo cáo tình hình tài sản 0h ngày 01/01/{cboNam.Text}";
                configExcel.SubTitle = string.Empty;
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

            cboLoaiPhieuNhap.ItemEnum.Add(-1, "Tất cả");
            cboLoaiPhieuNhap.DefaultValueEnum = -1;
            cboLoaiPhieuNhap.EnumData = "iNhapVeKho";

            int currentYear = SysDateTime.Instance.Now().Year;

            List<int> years = new List<int>();

            for (int i = currentYear + 10; i>=2000; i--)
            {
                years.Add(i);
            }

            cboNam.Properties.DataSource = years;

            cboNam.EditValue = currentYear;
        }
        #endregion

        #region"Event"
        private void frmRP_TinhHinhTaiSan0h_Mau03_2009_Load(object sender, EventArgs e)
        {
            Init();
        }
        #endregion

    }
}
