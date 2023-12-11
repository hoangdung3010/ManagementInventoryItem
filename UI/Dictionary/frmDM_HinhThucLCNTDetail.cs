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
    public partial class frmDM_HinhThucLCNTDetail : FormUI.MFormDictionnaryDetail
    {
        public frmDM_HinhThucLCNTDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<DM_HinhThucLCNTRepository>(),
                    EntityName = "DM_HinhThucLCNT",
                    Title = "Hình thức lập chit định thầu"
                };
            }
        }

        #region"Sub/Func"
     
        #endregion
        #region"Event"
        private void frmDM_HinhThucLCNTDetail_Load(object sender, EventArgs e)
        {
        }

        #endregion
    }
}
