using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        Snake snake;

        public Form1()
        {
            InitializeComponent();
            LinkedList<Rectangle> body = new LinkedList<Rectangle>();

            body.AddFirst(new Rectangle(4, 5, 1, 1));
            body.AddFirst(new Rectangle(5, 5, 1, 1));
            body.AddFirst(new Rectangle(6, 5, 1, 1));
            snake = new Snake(body);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            snake.DrawYourself(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            snake.Move();
            Refresh();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'a': 
                    snake.GoLeft();
                    break;
                case 'd':
                    snake.GoRight();
                    break;
                case 'w':
                    snake.GoTop();
                    break;
                case 's':
                    snake.GoBottom();
                    break;
            }
        }
    }
}
