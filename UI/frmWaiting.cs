using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class frmWaiting : WaitForm
    {
        public frmWaiting()
        {
            InitializeComponent();
            lblTitle.BackColor = System.Drawing.Color.FromArgb(33, 37, 41);
            gunaProgressBar.BackColor = System.Drawing.Color.FromArgb(33, 37, 41);
        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }
        private void frmWaiting_Load(object sender, EventArgs e)
        {

        }
    }
}
