using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aknakereso2
{
    class Cell : Button
    {
        public int row, column;
        static int size = 25;

        public bool bomb = false;
        public bool clicked = false;
        public int neighbours;


        public Cell(int row, int column)
        {
            this.row = row;
            this.column = column;

            this.Left = column * size;
            this.Top = row * size;
            this.Height = this.Width = size;

        }

        public void click()
        {
            if (bomb)
            {
                MessageBox.Show("You lost");
                Application.Exit();
            }
            else
            {
                this.FlatStyle = FlatStyle.Flat;
                if (neighbours > 0)
                {
                    this.Text = neighbours.ToString();
                }
            }
            this.clicked = true;
        }
    }
}
