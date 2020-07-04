using Clock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для DigitalClock.xaml
    /// </summary>
    public partial class DigitalClock : Window
    {
        public bool IsOpened { get; set; } = false;
        public DigitalClock()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            label.Content = DateTime.Now.ToLongTimeString();
            DispatcherTimer timer = new DispatcherTimer();
            Models.DigitalClock clock = new Models.DigitalClock();
            clock.label = label;
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += clock.Timer_Tick;
            timer.Start();

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
