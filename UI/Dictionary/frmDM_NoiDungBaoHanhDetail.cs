using MT.Data.Rep;
using MT.Library;
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
    public partial class frmDM_NoiDungBaoHanhDetail : FormUI.MFormDictionnaryDetail
    {
        public frmDM_NoiDungBaoHanhDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<DM_NoiDungBaoHanhRepository>(),
                    EntityName = "DM_NoiDungBaoHanh",
                    Title = "Nội dung bảo hành"
                };
            }
        }

        #region"Sub/Func"
     
        #endregion
        #region"Event"
        private void frmDM_NoiDungBaoHanhDetail_Load(object sender, EventArgs e)
        {
        }

        #endregion

    }
}
