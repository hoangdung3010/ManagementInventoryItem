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
    public partial class frmRP_KH_XuatBaoDam_PhuLuc3 : MXTraForm
    {
        #region"Declare"
        #endregion
        #region"Contructor"
        public frmRP_KH_XuatBaoDam_PhuLuc3()
        {
            InitializeComponent();
            mUserControlParamRP.RootControl = groupBoxInput;
            mUserControlParamRP.ConfigReport = new MT.Data.BO.ConfigReport
            {
                RepName= "KH_XuatBaoDam_PhuLuc3Repository",
                DictionaryKey= MT.Data.ReportDictionaryKey.RP_KH_XuatBaoDam_PhuLuc3,
                ShowColumnsOrder=new HashSet<string>
                {
                    "sSTT","sDanhMucTB","sTenDonViTinh","KhoMB#QD#TK_TTMD","KhoMB#QD#TK_TTHL",
                    "KhoMB#QD#NC_TTMD","KhoMB#QD#LE","KhoMB#QD#TongCong","KhoMB#CA#TK_TTMD","KhoMB#CA#TK_TTHL",
                    "KhoMB#CA#NC_TTMD","KhoMB#CA#LE","KhoMB#CA#TongCong",
                    "KhoMBNG","KhoMBDC","KhoMBHV","KhoMBCUCQLKT","KhoMBTongCong","MN#QD#TTHL",
                    "QD","CA","NG","DC",
                    "HV","CUQLKT","DP","TongCong"
                }
            };

            mUserControlParamRP.MySetCustomConfigExcel=(ConfigExcel  configExcel)=>{
                //Lấy tên cơ cấu tổ chức
                configExcel.ParametersExcel.AddOrUpdate("iNam",new MTParameter {  Value = cboNam.Text });
            };
        }
        #endregion

        #region"Sub/Func"
        private void Init()
        {
            var dM_DonViRepository = (DM_DonViRepository)DBContext.GetRep<MT.Data.Rep.DM_DonViRepository>();
            var donviXayDungKH = dM_DonViRepository.GetEmployeeAccessLevel(MT.Library.SessionData.UserId);

            cboDonVi.Properties.DisplayMember = "sTenDonvi";
            cboDonVi.Properties.ValueMember = "Id";
            var treeListDonVi = cboDonVi.Properties.TreeList;
            treeListDonVi.KeyFieldName = "Id";
            treeListDonVi.ParentFieldName = "sParentId";
            cboDonVi.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            cboDonVi.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            cboDonVi.Properties.DataSource = donviXayDungKH;

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
        private void frmRP_KH_XuatBaoDam_PhuLuc3_Load(object sender, EventArgs e)
        {
            Init();
        }
        #endregion

    }
}
