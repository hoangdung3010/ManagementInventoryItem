using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;

namespace MTControl
{
    public class MLookUpEditConditionValidationRule : ConditionValidationRule 
    {
        public override bool Validate(Control control, object value)
        {
            string str = Convert.ToString(value);
            bool res = true;
            if (control.Text.Length < 1)
            {
                res = false;
            }
            else if (control.GetType() == typeof(MLookUpEdit))
            {
                if (((MLookUpEdit)control).EditValue == null)
                {
                    res = false;
                }
            }
            return res;
        }
    }
}
