using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormUI
{
    public partial class WaitFormCustom : DevExpress.XtraWaitForm.WaitForm
    {
        public WaitFormCustom()
        {
            InitializeComponent();
        }

        public override void SetDescription(string description)
        {
            base.SetDescription(description);
        }

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
        }
    }
}
