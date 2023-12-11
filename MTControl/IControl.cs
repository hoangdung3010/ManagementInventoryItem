using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTControl
{
    public interface IControl
    {
        string Description{get;set;}
        void SetFont();
    }
}
