using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTControl
{
   public class MButtonName
    {
        /// <summary>
        /// Tên command
        /// </summary>
        public MCommandName CommandName { get; set; }

        /// <summary>
        /// Nội dung hiển thị
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Độ rộng
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Icon đại diện
        /// </summary>
        public Image Icon { get; set; }

        /// <summary>
        /// Loại command
        /// </summary>
        public string XType { get; set; }

        /// <summary>
        /// Hiển thị dấu ngăn cách các button
        /// </summary>
        public bool BeginGroup { get; set; }

    }
}
