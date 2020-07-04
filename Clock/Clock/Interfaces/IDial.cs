using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Clock.Interfaces
{   
    interface IDial
    {
        Path p1 { get; set; }
        Path p2 { get; set; }
        Path p3 { get; set; }
        void ArrowMove();
    }
}
