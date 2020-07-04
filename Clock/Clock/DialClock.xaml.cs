using Clock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Clock
{
    /// <summary>
    /// Логика взаимодействия для DialClock.xaml
    /// </summary>
    public partial class DialClock : Window
    {
        public bool IsOpened { get; set; } = false;
        public DialClock()
        {
            InitializeComponent();
          
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            MyDialClock dial = new MyDialClock();
            dial.p1 = seconds;
            dial.p2 = minutes;
            dial.p3 = hours;
            dial.ArrowMove();
            timer.Tick += dial.Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Start();
        }

        //private void Timer_Tick(object sender, EventArgs e)
        //{
        //    RotateTransform rotateSeconds = new RotateTransform(DateTime.Now.Second * 6);
        //    seconds.RenderTransform = rotateSeconds;
        //    double mintAngle = 6 * DateTime.Now.Minute + rotateSeconds.Angle / 60;
        //    RotateTransform rotateMinutes = new RotateTransform(mintAngle);
        //    minutes.RenderTransform = rotateMinutes;
        //    double hourAngle = 30 * DateTime.Now.Hour + 5 * (DateTime.Now.Minute / 10);
        //    RotateTransform rotateHours = new RotateTransform(hourAngle);
        //    hours.RenderTransform = rotateHours;
        //}

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        

    }
}
