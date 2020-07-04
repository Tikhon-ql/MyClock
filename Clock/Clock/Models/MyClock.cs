using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Clock.Models
{
    class MyClock
    {
        //public int Seconds { get; set; } = DateTime.Now.Second + DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60;
        public EventHandler Timer_Tick(TextBox textBox)
        {
            textBox.Text = DateTime.Now.ToLongTimeString();
            return null;
        }
    }
}
