using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraLayout;

namespace MTControl
{
    public class MLayoutControl : DevExpress.XtraLayout.LayoutControl
    {
        #region"Declare"
        #endregion
        #region"Sub/Func"
        public void SetFont()
        {
            float sizeFont = MSize.mscSysFontSize;
            //this.Root.AppearanceItemCaption.BackColor = Color.White;
            this.Root.AppearanceItemCaption.ForeColor = MColor.ColorLabel;
            this.Root.AppearanceItemCaption.Font = new Font(MFont.mscSysFontName, sizeFont, FontStyle.Bold, GraphicsUnit.Pixel);
            this.ProcessLayoutControlGroup(this.Root);
        }

        /// <summary>
        /// Xử lý style cho các group control
        /// </summary>
        /// <param name="group"></param>
        private void ProcessLayoutControlGroup(LayoutControlGroup group)
        {
            foreach (var item in group.Items)
            {
                if (item is LayoutControlGroup)
                {
                    LayoutControlGroup layoutGroup = item as LayoutControlGroup;
                    layoutGroup.AppearanceGroup.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);
                    layoutGroup.AppearanceGroup.ForeColor = MColor.ForeColorTabPage;
                    layoutGroup.AppearanceGroup.BorderColor = MColor.ForeColorSubMenuStrip;
                    layoutGroup.AppearanceGroup.Options.UseFont = true;
                    layoutGroup.AppearanceGroup.Options.UseForeColor = true;
                    layoutGroup.AppearanceGroup.Options.UseBorderColor = true;

                    layoutGroup.AppearanceTabPage.Header.BorderColor = MColor.ForeColorSubMenuStrip;
                    layoutGroup.AppearanceTabPage.Header.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);
                    layoutGroup.AppearanceTabPage.Header.ForeColor = MColor.ForeColorTabPage;
                    layoutGroup.AppearanceTabPage.Header.Options.UseFont = true;
                    layoutGroup.AppearanceTabPage.Header.Options.UseForeColor = true;
                    layoutGroup.AppearanceTabPage.Header.Options.UseBorderColor = true;
                    ProcessLayoutControlGroup(layoutGroup);
                }
                if (item is TabbedControlGroup)
                {
                    ProcessTabbedGroup((TabbedControlGroup)item);
                }
                if (item is LayoutControlItem)
                {
                    ProcessLayoutControlItem(((LayoutControlItem)item));
                }
            }
        }

        /// <summary>
        /// Xử lý style cho các tabgroup control
        /// </summary>
        /// <param name="group"></param>
        private void ProcessTabbedGroup(TabbedControlGroup group)
        {
            foreach (LayoutControlGroup page in group.TabPages)
            {
                ProcessLayoutControlGroup(page);
            }
        }

        /// <summary>
        /// Xử lý style cho LayoutControlItem
        /// </summary>
        /// <param name="item"></param>
        private void ProcessLayoutControlItem(LayoutControlItem item)
        {
            // your code here
        }
        #endregion
        #region"Ovrrides"
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            SetFont();
        }
        #endregion
        #region"Implement"
        #endregion
    }
}
