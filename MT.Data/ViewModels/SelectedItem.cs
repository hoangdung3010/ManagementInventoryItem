﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.ViewModels
{
    public class SelectedItem
    {
        public int Id { get; set; }

        public Guid GuidId { get; set; }

        public string Value { get; set; }

        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
