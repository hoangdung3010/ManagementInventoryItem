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
    public partial class frmDM_NoiDungSuaChuaDetail : FormUI.MFormDictionnaryDetail
    {
        public frmDM_NoiDungSuaChuaDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<DM_NoiDungSuaChuaRepository>(),
                    EntityName = "DM_NoiDungSuaChua",
                    Title = "Nội dung sửa chữa"
                };
            }
        }

        #region"Sub/Func"
     
        #endregion
        #region"Event"
        private void frmDM_NoiDungSuaChuaDetail_Load(object sender, EventArgs e)
        {
        }

        #endregion

    }
}
