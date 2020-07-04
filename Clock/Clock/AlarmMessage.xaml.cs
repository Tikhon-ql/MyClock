using Clock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Clock
{
    /// <summary>
    /// Логика взаимодействия для AlarmMessage.xaml
    /// </summary>
    public partial class AlarmMessage : Window
    {
        public AlarmMessage()
        {
            InitializeComponent();
          
        }
        AlarmInfo alarm;
        public AlarmMessage(AlarmInfo alarmInfo)
        {
            InitializeComponent();
            alarm = alarmInfo;
            if(alarm.AlarmName == "")
            {
                alarmsName.Content = "Alarm";
            }
            else
                alarmsName.Content = alarmInfo.AlarmName;
        }
        SoundPlayer sp = new SoundPlayer();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Tick += Timer_Tick;
                timer.Interval = new TimeSpan(0, 0, 0, 1);
                timer.Start();
                var primaryMonitorArea = SystemParameters.WorkArea;
                this.Left = primaryMonitorArea.Right - Width - 10;
                this.Top = primaryMonitorArea.Bottom - Height - 10;
                switch (alarm.MusicName)
                {
                    case "Blows":
                        sp.Stream = Properties.Resources.blows;
                        break;
                    case "Ding":
                        sp.Stream = Properties.Resources.ding;
                        break;
                    case "Fluttering":
                        sp.Stream = Properties.Resources.fluttering;
                        break;
                    case "Wind":
                        sp.Stream = Properties.Resources.Wind;
                        break;
                }
                sp.Play();
            }
          catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        int ticks = 0;

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(ticks != 6)
            {
                ticks++;
                Thread.Sleep(1000);
            }
            else
            {
                sp.Stop();
                Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sp.Stop();
            Close();
        }
    }
}
