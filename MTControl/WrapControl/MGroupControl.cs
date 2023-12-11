using System.ComponentModel;
using System.Drawing;

namespace MTControl
{
    public class MGroupControl : DevExpress.XtraEditors.GroupControl, IControl
        
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
            SetFont();
        }
        #endregion
        #region"Implement"
        [Description("Control nhập liệu dạng text")]
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
            this.ForeColor = MColor.ColorLabel;
            this.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);
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

        public Ctype Mtype
        {
            get { return Ctype.MGroupControl; }
        }
        #endregion


       
    }
}
