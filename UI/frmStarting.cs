using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using MT.Data;
using MT.Data.Rep;
using MTControl;
using VGCACrypto;

namespace FormUI
{
    public partial class frmStarting : SplashScreen
    {
        public frmStarting()
        {
            InitializeComponent();
            
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void peImage_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frmStarting_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);

            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // this.Close();
        }

        private void frmStarting_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }
        private void frmStarting_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (frmLogin frm = new frmLogin())
            {
                frm.ShowDialog();
            }
        }
    }
}