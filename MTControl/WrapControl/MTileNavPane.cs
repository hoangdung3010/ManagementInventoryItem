using System.ComponentModel;
using System.Drawing;

namespace MTControl
{
    public class MTileNavPane : DevExpress.XtraBars.Navigation.TileNavPane, IControl
        
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
            this.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        public string ColumnName
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public Ctype Mtype
        {
            get { return Ctype.MTileNavPane; }
        }
        #endregion
        
    }
}
