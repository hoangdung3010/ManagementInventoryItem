using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;

namespace MTControl
{
    public class SpinEditValidationRule : ConditionValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            string str = Convert.ToString(value);
            bool res = true;
            if (control is MSpinEdit)
            {
               if(string.IsNullOrWhiteSpace(str) || string.IsNullOrWhiteSpace((control as MSpinEdit).Text))
                {
                    return false;
                }
            }
            return res;
        }
    }
}
