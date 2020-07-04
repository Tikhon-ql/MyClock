using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Clock.Models
{
    class Clock
    {
        public TextBox textBox { get; set; }
        public virtual void Timer_Tick(object sender, EventArgs eventArgs)
        {
            textBox.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
