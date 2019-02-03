using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public partial class Form1 : Form
    {
        int headX = 100;
        int headY = 100;

        int directionX = 1;
        int directionY = 0;

        int maxfood = 1;
        int length = 7;

        Timer t = new Timer();
        Timer eat = new Timer();
            

        List<KigyoElem> snake = new List<KigyoElem>();
        List<Food> food = new List<Food>();

        Keys previous = Keys.D ;

        public Form1()
        {
            InitializeComponent();
            t.Start();
            t.Interval = 75;
            t.Tick += T_Tick;

            eat.Start();
            eat.Interval = 2000;
            eat.Tick += Eat_Tick;
        }

        private void Eat_Tick(object sender, EventArgs e)
        {
            if (food.Count < maxfood)
            {
                Food f = new Food();
                Random rnd = new Random();
                f.Top = rnd.Next(this.Height/20)*20;
                f.Left = rnd.Next(this.Width/20)*20;
                this.Controls.Add(f);
                this.food.Add(f);
            }
        }

        private void T_Tick(object sender, EventArgs e)
        {
            headX += directionX * 20;
            headY += directionY * 20;

            foreach (KigyoElem item in snake)
            {
                if (item.Top == headY && item.Left == headX) Application.Exit();
            }

            KigyoElem k = new KigyoElem();
            k.Left = headX;
            k.Top = headY;
            this.Controls.Add(k);
            this.snake.Add(k);

            var f = GetFood(k.Top, k.Left);

            if (f != null)
            {
                food.Remove(f);
                Controls.Remove(f);
            }

            if (snake.Count > length)
            {
                var part = snake.ElementAt(0);
                snake.Remove(part);
                this.Controls.Remove(part);
            }
        }

        private Food GetFood(int top, int left)
        {
            foreach (var f in food)
            {
                if (top == f.Top && left == f.Left)
                {
                    length+= 2;
                    return f;
                }
            }

            return null;
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (previous != Keys.S && e.KeyCode == Keys.W) { directionX = 0; directionY = -1; previous = Keys.W; } 
            if (previous != Keys.D && e.KeyCode == Keys.A) { directionX = -1; directionY = 0; previous = Keys.A; }
            if (previous != Keys.W && e.KeyCode == Keys.S) { directionX = 0; directionY = 1; previous = Keys.S; }
            if (previous != Keys.A && e.KeyCode == Keys.D) { directionX = 1; directionY = -0; previous = Keys.D; }
        }




    }
}
