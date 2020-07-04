using Clock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;
using System.Threading;

namespace Clock
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        DigitalClock digital;
        /// <summary>
        /// Открытие(закрытие) окна с цифровыми часами
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (digital != null)
                {
                    digital.Close();
                    digital = null;
                    digitalClock.Content = "Digital Clock";
                    digitalClock.FontSize = 30;
                }
                else
                {
                    digital = new DigitalClock();
                    digital.Show();
                    digitalClock.Content = "Close digital clock";
                    digitalClock.FontSize = 22;
                }
            }
      
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //digital.IsOpened = OpenCloseWindow(digital, digitalClock, "Digital Clock", "Close digital clock", digital.IsOpened);
        }
        DialClock dial;
        /// <summary>
        /// Открытие(закрытие) окна с циферблатом
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dial != null)
                {
                    dial.Close();
                    dial = null;
                    dialClock.Content = "Dial Clock";
                    dialClock.FontSize = 30;
                }
                else
                {
                    dial = new DialClock();
                    dial.Show();
                    dialClock.Content = "Close dial clock";
                    dialClock.FontSize = 22;
                    //dial.IsOpened = OpenCloseWindow(dial, dialClock, "Dial Clock", "Close dial clock", digital.IsOpened); 
                }
            }
          catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //static bool OpenCloseWindow(Window clock, Button but, string first, string second,bool flag)
        //{
        //    if (flag)
        //    {
        //        clock.Visibility = Visibility.Hidden;
        //        but.Content = first;
        //        but.FontSize = 30;
        //        return false;
        //    }
        //    else
        //    {
        //        clock.Visibility = Visibility.Visible;
        //        but.Content = second;
        //        but.FontSize = 22;
        //        return true;
        //    }
        //}
        /// <summary>
        /// При закрытии главного окна закрывает все дочерние окна
        /// </summary>
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                foreach (Window item in Application.Current.Windows)
                {
                    item.Close();
                }
            }
          catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        List<AlarmInfo> alarms = new List<AlarmInfo>();
        DispatcherTimer alarmTimer = new DispatcherTimer();
        /// <summary>
        /// Добавления будильника
        /// </summary>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Alarm alarm = new Alarm();
                alarm.ShowDialog();
                string alarmString = alarm.GetResult();
                if (alarmString != "")
                {
                    string[] strs = alarmString.Split(';'); 
                    int count = alarms.Count(a => a.Hour == int.Parse(strs[0]) && a.Minute == Convert.ToInt32(strs[1]));
                    if (count < 1)
                    {
                        alarms.Add(new AlarmInfo { AlarmName = strs[2], Hour = int.Parse(strs[0]), Minute = Convert.ToInt32(strs[1]), MusicName = strs[3] });
                        alarmTimer.Interval = new TimeSpan(0, 0, 1);
                        alarmTimer.Tick += AlarmTimer_Tick;
                        alarmTimer.Start();
                    }
                    else
                    {
                        MessageBox.Show($"У вас уже стоит будильник на {strs[0]}:{strs[1]}!");
                    }
                }
            }
           catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Проверка времени для будильника
        /// </summary>
        private void AlarmTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                foreach (AlarmInfo item in alarms.ToArray())
                {
                    if (DateTime.Now.Minute == item.Minute && DateTime.Now.Hour == item.Hour)
                    {
                        AlarmMessage alarm = new AlarmMessage(item);
                        alarm.Show();
                        alarms.Remove(item);
                    }
                }
            }
           catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnAlarm.Click += Button_Click_2;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

    }
}
