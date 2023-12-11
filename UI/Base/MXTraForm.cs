using DevExpress.XtraEditors;
using MT.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI.Base
{
    public partial class MXTraForm : XtraForm
    {
        protected readonly DBContext DBContext = new DBContext();
        public MXTraForm()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (DBContext != null)
            {
                DBContext.Dispose();
            }
        }

    }
}
