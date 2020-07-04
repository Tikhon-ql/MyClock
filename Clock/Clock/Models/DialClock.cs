using Clock.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Clock.Models
{
    class DialClock : MyClock, IDial
    {
        public void ArrowMove(object sec)
        {
            //RotateTransform rotateTransform1 = new RotateTransform(DateTime.Now.Second * 6);
            //((Path)sec).RenderTransform = rotateTransform1;
        }
    }
}
