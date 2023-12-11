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
    public partial class frmDM_TinhTrangHongHocDetail : FormUI.MFormDictionnaryDetail
    {
        public frmDM_TinhTrangHongHocDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<DM_TinhTrangHongHocRepository>(),
                    EntityName = "DM_TinhTrangHongHoc",
                    Title = "Tình trạng hỏng hóc"
                };
            }
        }

        #region"Sub/Func"
     
        #endregion
        #region"Event"

        #endregion

    }
}
