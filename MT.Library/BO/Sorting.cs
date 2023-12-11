﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Library
{
    public class Sorting
    {
        public string ColumnName { get; set; }
        public Direction Direction { get; set; }
    }

    /// <summary>
    /// Hướng sắp xếp
    /// </summary>
    /// Create by: dvthang:25.02.2018
    public enum Direction
    {
        ASC,
        DESC
    }
}
