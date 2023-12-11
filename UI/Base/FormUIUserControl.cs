using MT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace FormUI.Base
{
   public class FormUIUserControl: System.Windows.Forms.UserControl
    {
        protected readonly DBContext DBContext = new DBContext();

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
