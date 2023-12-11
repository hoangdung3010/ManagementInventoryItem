using DevExpress.Utils;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MTControl
{
    public class MButtonEdit:DevExpress.XtraEditors.ButtonEdit,IControl
        
    {
        #region"Declare"
        private string decription;

        public MRepositoryItemButtonEdit RepositoryItem { get; set; }
        public MGridControl Grid { get; set; }
        #endregion
        #region"Sub/Func"
        static MButtonEdit()
        {
            MRepositoryItemButtonEdit.RegisterMButtonEdit();
        }
        #endregion
        #region"Ovrrides"
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            RepositoryItem = (this.Tag as MRepositoryItemButtonEdit);
            if (RepositoryItem != null)
            {
                //todo
                this.Grid = RepositoryItem.GridMaster;
                this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            }
            else
            {
                this.Properties.AutoHeight = false;
                this.Height = MHeight.mscEditControlHeight;
            }

            SetFont();
        }
        /// <summary>
        /// Thực hiện nhảy Tab khi nhấn Enter
        /// </summary>
        /// <param name="e"></param>
        /// CreatebBy-laipv.19.08.2017
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
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
            get { return Ctype.MButtonEdit; }
        }
        #endregion
    }
}
