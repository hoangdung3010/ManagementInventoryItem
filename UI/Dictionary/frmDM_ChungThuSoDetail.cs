using MT.Data;
using MT.Data.BO;
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
    public partial class frmDM_ChungThuSoDetail : FormUI.MFormDictionnaryDetail
    {
        public frmDM_ChungThuSoDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<DM_ChungThuSoRepository>(),
                    EntityName = "DM_ChungThuSo",
                    Title = "Chứng thư số"
                };
            }

            Init();
        }

        #region"Sub/Func"
    
        /// <summary>
        /// Khởi tạo các giá trị của lookup
        /// </summary>
        private void Init()
        {
        }
        #endregion
        #region"Event"

        #endregion

        #region"Overrides"

        protected override BaseEntity PrepareDataBeforeBindDataForm()
        {
            var currentData = (DM_ChungThuSo)base.PrepareDataBeforeBindDataForm();
            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:
                    var now = SysDateTime.Instance.Now();
                    currentData.dNgayBatDau = now;
                    currentData.dNgayKetThuc = now;
                    break;
            }
            return currentData;
        }
        #endregion
    }
}
