﻿using MT.Data.Rep;
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
    public partial class frmDM_NoiDungCaiDatDetail : FormUI.MFormDictionnaryDetail
    {
        public frmDM_NoiDungCaiDatDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<DM_NoiDungCaiDatRepository>(),
                    EntityName = "DM_NoiDungCaiDat",
                    Title = "Nội dung cài đặt"
                };
            }
        }

        #region"Sub/Func"

        #endregion
        #region"Event"
        private void frmDM_NoiDungCaiDatDetail_Load(object sender, EventArgs e)
        {
        }

        #endregion

    }
}
