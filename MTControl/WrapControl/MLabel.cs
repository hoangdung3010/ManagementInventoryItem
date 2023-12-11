using System.ComponentModel;
using System.Drawing;

namespace MTControl
{
    public class MLabel : DevExpress.XtraEditors.LabelControl, IControl
        
    {
        #region"Declare"
        private string decription;

        private bool isTitleForm;

        [DefaultValue(false)]
        public bool IsTitleForm
        {
            get { return isTitleForm; }
            set { isTitleForm = value; SetFont(); }
        }

        public bool IsRequired
        {
            get; set;
        } = false;

        private string oldText;
        #endregion
        #region"Sub/Func"
        #endregion
        #region"Ovrrides"
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetFont();
            if (!string.IsNullOrWhiteSpace(this.Text) && !this.Text.Contains("*") && this.IsRequired)
            {
                oldText = this.Text;
                this.Text = $"{oldText}<color=255, 0, 0><size=13>*</size></color>";
            }
            this.AllowHtmlString = true;
            this.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.Appearance.Options.UseTextOptions = true;
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
            float sizeFont = MSize.mscSysFontSize;
            this.ForeColor = MColor.ColorLabel;
            if (this.isTitleForm)
            {
                sizeFont = MSize.mscTitleFormFontSize;
            }
            this.Font = new Font(MFont.mscSysFontName, sizeFont, FontStyle.Regular, GraphicsUnit.Pixel);
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
            get { return Ctype.MLabel; }
        }
        #endregion


      
    }
}
