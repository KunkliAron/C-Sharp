using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    class KigyoElem : Button
    {
        public static int size = 20;

        public KigyoElem()
        {
            this.Height = size;
            this.Width = size;
            this.BackColor = Color.Magenta;
        }
    }
}
