using MTControl;
using System;
using System.Windows.Forms;

namespace FormUI
{
    public partial class MFormHelp : FormUI.FormUIBase
    {
        #region"Declare"
        public string sFormName { get; set; }
        #endregion

        #region"Contructor"
        public MFormHelp()
        {
            InitializeComponent();

        }

        #endregion

        #region"Ovrrides"

        #endregion

        #region"Sub/func"

        #endregion
        #region"Overrides"

        /// <summary>
        /// Hiển thị form help
        /// </summary>
        /// Create by: dvthang:19.11.2017
        public void LoadFile(string sFormName)
        {
           
        }
        #endregion
        #region"Event"
        private void MFormHelp_Load(object sender, EventArgs e)
        {
            LoadFile(sFormName);
        }

        #endregion

    }
}
