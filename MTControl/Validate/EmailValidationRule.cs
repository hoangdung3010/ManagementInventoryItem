using System;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MTControl
{
    /// <summary>
    /// Validate thông tin email nhập có hợp lệ không
    /// </summary>
    public class EmailValidationRule : ValidationRule 
    {
        public override bool Validate(Control control, object value)
        {
            string str = Convert.ToString(value);
            bool res = true;
            Regex rg = new Regex(@"^[\w\.\-]+@([\w\-]+\.)*[\w\-]{2,63}\.[a-zA-Z]{2,4}$");
            if (control is MTextEdit && !string.IsNullOrEmpty(str))
            {
                MTextEdit txt = control as MTextEdit;
                if (txt.IsMail)
                {
                    res = rg.IsMatch(str);
                }
            }
            return res;
        }
    }
}
