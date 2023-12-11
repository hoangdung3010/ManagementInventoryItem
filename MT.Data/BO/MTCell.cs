using FlexCel.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    public class MTCell
    {
        /// <summary>
        /// Dữ liệu của dòng chứa cell
        /// </summary>
        public DataRow Row { get; set; }

        /// <summary>
        /// Dữ liệu của dòng chứa column
        /// </summary>
        public DataColumn Column { get; set; }

        /// <summary>
        /// Vì trí của dòng chứa cell
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// Vị trí của cell
        /// </summary>
        public int ColIndex { get; set; }
        /// <summary>
        /// Giá trị gốc
        /// </summary>
        public object OriginValue { get; set; }

        /// <summary>
        /// Giá trị sau khi convert theo định dạng
        /// </summary>
        public string StringValue { get; set; }

        /// <summary>
        /// Cho phép bind html vào cell, mặc định không
        /// </summary>
        public bool AllowHtml { get; set; }

        /// <summary>
        /// Mặc định cho phép wrap text
        /// </summary>
        public bool WrapText { get; set; } = true;

        /// <summary>
        /// Font chữ của cell
        /// </summary>
        public int FontSize { get; set; }

        /// <summary>
        /// Style chữ của cell
        /// </summary>
        public TFlxFontStyles FontStyle { get; set; } = TFlxFontStyles.None;

        /// <summary>
        /// Chỉ định cell chính là cột header
        /// </summary>
        public bool IsHeaderText { get; set; }
    }
}
