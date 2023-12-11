using System.ComponentModel;
using System.Drawing;

namespace MTControl
{
    public class MDxValidationProvider: DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
        
    {
        #region"Declare"
        private string decription;
        #endregion
        #region"Sub/Func"
        #endregion
        #region"Ovrrides"
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
        #endregion
    }
}
