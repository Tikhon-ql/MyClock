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
using System.Windows.Forms;
using System.Media;
using Clock.Properties;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Clock
{
    /// <summary>
    /// Логика взаимодействия для Alarm.xaml
    /// </summary>
    public partial class Alarm : Window
    {
        public Alarm()
        {
            InitializeComponent();
        }
        bool flag = false;
        SoundPlayer sp = new SoundPlayer();
        /// <summary>
        /// Прослушивание мелодии для будильника
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listen.Content.ToString() != "Stop")
                {
                    switch (cmbBox.Text)
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
                    listen.Content = "Stop";
                }
                else
                {
                    sp.Stop();
                    listen.Content = "Listen";
                }
            }
          catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void cmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listen.Content = "Listen";
            sp.Stop();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbBox.SelectionChanged += CmbBox_SelectionChanged;
        }

        private void CmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listen.Content = "Listen";
            sp.Stop();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            flag = true;
            Close();
        }
        public string GetResult()
        {
            if (flag)
            {
                return hour.Value + ";" + minutes.Value + ";" + alarmsName.Text + ";" + cmbBox.Text;
            }
            return "";
        }
    }
}
