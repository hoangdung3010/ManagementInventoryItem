using System.Windows.Forms;
using System.Drawing;

namespace MTControl
{
    public class CustomToolStripRender : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.Red; }
        }

        public override Color MenuBorder
        {
            get { return Color.Green; }
        }
        public override Color MenuItemBorder
        {
            get { return Color.Red; }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.Red; }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.Red; }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.Red; }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.Red; }
        }

    }
}
