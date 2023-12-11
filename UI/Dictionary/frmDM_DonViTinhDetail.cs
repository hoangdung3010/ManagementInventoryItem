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
    public partial class frmDM_DonViTinhDetail : FormUI.MFormDictionnaryDetail
    {
        public frmDM_DonViTinhDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<DM_DonViTinhRepository>(),
                    EntityName = "DM_DonViTinh",
                    Title = "Đơn vị tính"
                };
            }
        }

        #region"Sub/Func"
     
        #endregion
        #region"Event"
        private void frmDM_DonViTinhDetail_Load(object sender, EventArgs e)
        {
        }

        #endregion
    }
}
