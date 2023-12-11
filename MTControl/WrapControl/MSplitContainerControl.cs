using System.ComponentModel;
using System.Drawing;

namespace MTControl
{
    public class MSplitContainerControl : DevExpress.XtraEditors.SplitContainerControl
        
    {
        #region"Declare"
        #endregion
        #region"Sub/Func"
        #endregion
        #region"Ovrrides"
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.Padding = new System.Windows.Forms.Padding(0);
        }
        #endregion
        #region"Implement"
        #endregion
    }
}
