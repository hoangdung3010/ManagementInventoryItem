using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MTControl
{
    public class MCalculator : DevExpress.XtraEditors.CalcEdit, IControl
        
    {
        #region"Declare"
        private string decription;

        private string columnName;

        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }

        /// <summary>
        /// Tự gán value bằng tay nếu =true
        /// </summary>
        private bool isSetValueManual;

        public bool IsSetValueManual
        {
            get { return isSetValueManual; }
            set { isSetValueManual = value; }
        }
        #endregion
        #region"Sub/Func"
        #endregion
        #region"Ovrrides"
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.Properties.AutoHeight = false;
            this.Height = MHeight.mscEditControlHeight;
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
            
        }

        public Ctype Mtype
        {
            get { return Ctype.MCalculator; }
        }
        #endregion


        
    }
}
