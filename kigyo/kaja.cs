using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    class Food : Button
    {
        public Food()
        {
            this.Width = 20;
            this.Height = 20;
            this.BackColor = Color.Yellow; 
        }
    }
}
