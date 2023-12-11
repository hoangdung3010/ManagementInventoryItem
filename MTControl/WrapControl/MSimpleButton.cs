using System.ComponentModel;
using System.Drawing;

namespace MTControl
{
    public class MSimpleButton : DevExpress.XtraEditors.SimpleButton, IControl
        
    {
        #region"Declare"
        private string decription;

        #endregion
        #region"Sub/Func"
        #endregion
        #region"Ovrrides"
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.AutoSize = false;
            this.Height = MHeight.mscButtonHeight;
            SetFont();

        }
        #endregion
        #region"Implement"
        [Description("Control nhập liệu dạng button")]
        [Category("CustomControl")]
        public string Description
        {
            get
            {
                return decription;
            }
            set
            {
                decription=value;
            }
        }
        public void SetFont()
        {
            this.BackColor = MColor.BackColorButtonDefault;
            this.ForeColor = MColor.ColorLabel;
            this.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular,GraphicsUnit.Pixel);
        }

        public Ctype Mtype
        {
            get { return Ctype.MSimpleButton; }
        }

        public string ColumnName
        {
            get
            {
                return "";
            }
            set
            {
               
            }
        }
        #endregion


       
    }
}
