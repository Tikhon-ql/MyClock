using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Clock.Models
{
    class _Clock
    {
        public Label label { get; set; }
        public virtual void Timer_Tick(object sender, EventArgs eventArgs)
        {
            label.Content = DateTime.Now.ToLongTimeString();
        }
    }
}
