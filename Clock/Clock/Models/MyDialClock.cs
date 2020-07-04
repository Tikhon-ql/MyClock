using Clock.Interfaces;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Clock.Models
{
    class MyDialClock : _Clock, IDial
    {
        public Path p1 { get ; set ; }
        public Path p2 { get ; set ; }
        public Path p3 { get ; set ; }

        public void ArrowMove()
        {
            RotateTransform rotateSeconds = new RotateTransform(DateTime.Now.Second * 6);
            p1.RenderTransform = rotateSeconds;
            double mintAngle = 6 * DateTime.Now.Minute + rotateSeconds.Angle / 60;
            RotateTransform rotateMinutes = new RotateTransform(mintAngle);
            p2.RenderTransform = rotateMinutes;
            double hourAngle = 30 * DateTime.Now.Hour + 5 * (DateTime.Now.Minute / 10);
            RotateTransform rotateHours = new RotateTransform(hourAngle);
            p3.RenderTransform = rotateHours;
        }
        public override void Timer_Tick(object sender, EventArgs eventArgs)
        {
            ArrowMove();
        }
    }
}
