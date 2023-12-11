using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTControl
{
    /// <summary>
    /// Các control nhập liệu
    /// </summary>
    /// Create by: dvthang:25.10.2017
    public interface IEditControl
    {
        bool IsRequired { get; set; }
        /// <summary>
        /// Tên column trong database
        /// </summary>
        /// Create by: dvthang:25.10.2017
        string SetField { get; set; }

        /// <summary>
        /// Kiểu của control
        /// </summary>
        /// Create by: dvthang:04.10.2017
        Ctype Mtype { get; }

        /// <summary>
        /// Thiết lập giá trị cho control
        /// </summary>
        /// Create by: dvthang:25.10.2017
        void SetValue(object value);

        /// <summary>
        /// Lấy giá trị của control
        /// </summary>
        /// <returns>Trả về giá trị của control</returns>
        /// Create by: dvthang:25.10.2017
        object GetValue();

        /// <summary>
        /// Thiết lập chế độ readonly cho các control trên form
        /// </summary>
        /// <param name="bEnable">=true là reaonly, ngược lại thì không</param>
        /// Create by: dvthang:25.10.2017
        void SetReadOnly(bool bEnable);
    }
}
