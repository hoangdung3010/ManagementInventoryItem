using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTControl.Models
{
    public class FilterObject
    {
        public string FieldName { get; set; }

        public object Value { get; set; }

        public DevExpress.XtraEditors.ColumnAutoFilterCondition Condition { get; set; }
    }

}
