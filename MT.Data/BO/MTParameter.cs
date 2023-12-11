using FlexCel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    public class MTParameter
    {
        /// <summary>
        /// Giá trị truyền vào
        /// </summary>
       public string Value { get; set; }

        /// <summary>
        /// Giá trị gốc trước khi sửa
        /// </summary>
       public object OriginValue { get; set; }
    }
}
