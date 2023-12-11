using System;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors.Controls;

namespace MTControl
{
    /// <summary>
    /// Custom lại event thay đổi giá trị của control
    /// </summary>
    /// Create by: dvthang:15.11.2017
    public class CustomChangingEventArgs  
    {
     
        public decimal Value { get; set; }
    }
}
