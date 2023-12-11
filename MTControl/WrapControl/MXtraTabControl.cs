using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraTab;

namespace MTControl
{
    public class MXtraTabControl : DevExpress.XtraTab.XtraTabControl
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
            DevExpress.XtraTab.XtraTabPageCollection lstTab = this.TabPages;
            if (lstTab != null)
            {
                //Chỉnh lại style cho tab Header
                foreach (XtraTabPage tabPage in lstTab)
                {
                    tabPage.Appearance.Header.BorderColor = MColor.ForeColorSubMenuStrip;
                    tabPage.Appearance.Header.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);
                    tabPage.Appearance.Header.ForeColor = MColor.ForeColorTabPage;
                    tabPage.Appearance.Header.Options.UseFont = true;
                    tabPage.Appearance.Header.Options.UseForeColor = true;
                    tabPage.Appearance.Header.Options.UseBorderColor = true;
                }
            }
        }
        #endregion
        #region"Implement"
        #endregion
    }
}
