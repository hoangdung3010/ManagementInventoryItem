using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MTControl
{
    public class MXtraUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        #region"Declare"
        #endregion
        #region"Contructor"
        public MXtraUserControl()
        {
            InitializeComponent();
            MCommon.SetSkins();
        }
        #endregion
        #region"Sub/Func"
        #endregion
        #region"Ovrrides"
       
        /// <summary>
        /// ovrides lại hàm render control
        /// </summary>
        /// dvthang-17.07.2016
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);

        }
        #endregion
        #region"Implement"

        #endregion
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MXtraUserControl
            // 
            this.AllowDrop = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "MXtraUserControl";
            this.Size = new System.Drawing.Size(473, 375);
            this.ResumeLayout(false);

        }       
    }


   
}
