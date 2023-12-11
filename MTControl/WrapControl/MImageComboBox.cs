using System.ComponentModel;
using System.Drawing;

namespace MTControl
{
    public class MImageComboBox:DevExpress.XtraEditors.ImageComboBoxEdit,IControl
        
    {
        #region"Declare"
        private string decription;
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
            get { return Ctype.MImageComboBox; }
        }
        #endregion


       
        
    }
}
