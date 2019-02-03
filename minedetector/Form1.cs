using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aknakereso2
{
    public partial class Form1 : Form
    {
        int width, height;
        Cell[,] field;


        public Form1()
        {
            InitializeComponent();
            fieldgenerator(10, 10);
            bombplacer(10);
        }

        void bombplacer(int aknaszam)
        {
            Random rnd = new Random();
            for (int i = 0; i < aknaszam; i++)
            {
                int row = rnd.Next(height - 1);
                int column = rnd.Next(width - 1);
                field[row, column].bomb = true;
                if (fieldunlock(row - 1, column - 1)) field[row - 1, column - 1].neighbours++;
                if (fieldunlock(row - 1, column - 0)) field[row - 1, column - 0].neighbours++;
                if (fieldunlock(row - 1, column + 1)) field[row - 1, column + 1].neighbours++;
                if (fieldunlock(row - 0, column - 1)) field[row - 0, column - 1].neighbours++;
                if (fieldunlock(row - 0, column + 1)) field[row - 0, column + 1].neighbours++;
                if (fieldunlock(row + 1, column - 1)) field[row + 1, column - 1].neighbours++;
                if (fieldunlock(row + 1, column - 1)) field[row + 1, column - 1].neighbours++;
                if (fieldunlock(row + 1, column + 1)) field[row + 1, column + 1].neighbours++;
            }
        }

        void fieldgenerator(int width, int height)
        {
            this.width = width;
            this.height = height;

            field = new Cell[width, height];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Cell m = new Cell(i, j);
                    this.Controls.Add(m);
                    field[i, j] = m;
                    m.Click += M_Click;
                }
            }
        }

        bool fieldunlock(int row, int column)
        {
            if (row < 0 || column < 0) return false;
            if (row >= height || column >= width) return false;
            return true;
        }

        private void M_Click(object sender, EventArgs e)
        {
            Cell field = (Cell)sender;
            Felfed(field.row, field.column);
            field.click();
        }

        void Felfed(int row, int column)
        {
            Cell field = this.field[row, column];
            if (field.neighbours == 0 && !field.bomb && !field.clicked)
            {
                field.click();
                if (fieldunlock(row - 1, column - 1)) Felfed(row - 1, column - 1);
                if (fieldunlock(row - 1, column - 0)) Felfed(row - 1, column - 0);
                if (fieldunlock(row - 1, column + 1)) Felfed(row - 1, column + 1);
                if (fieldunlock(row - 0, column - 1)) Felfed(row - 0, column - 1);
                if (fieldunlock(row - 0, column + 1)) Felfed(row - 0, column + 1);
                if (fieldunlock(row + 1, column - 1)) Felfed(row + 1, column - 1);
                if (fieldunlock(row + 1, column - 0)) Felfed(row + 1, column - 0);
                if (fieldunlock(row + 1, column + 1)) Felfed(row + 1, column + 1);

            }
        }
    }
}
