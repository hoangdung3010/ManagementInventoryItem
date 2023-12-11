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
    public partial class frmDM_ThamSoMatMaDetail : FormUI.MFormDictionnaryDetail
    {
        public frmDM_ThamSoMatMaDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<DM_ThamSoMatMaRepository>(),
                    EntityName = "DM_ThamSoMatMa",
                    Title = "Tham số mật mã"
                };
            }
        }

        #region"Sub/Func"
     
        /// <summary>
        /// Khởi tạo các giá trị của lookup
        /// </summary>
        private void InitLookup()
        {
            cboEnumiDonViThoiGianHieuLuc.EnumData = "iDonViThoiGianHieuLuc";
        }
        #endregion
        #region"Event"
        private void frmDM_DonViDetail_Load(object sender, EventArgs e)
        {
            InitLookup();
        }

        /// <summary>
        /// Xử lý dữ liệu trước khi binding vào form
        /// </summary>
        /// <returns></returns>
        protected override BaseEntity PrepareDataBeforeBindDataForm()
        {
            var currentData= base.PrepareDataBeforeBindDataForm();
            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:

                    break;
            }
            return currentData;
        }

        #endregion
    }
}
