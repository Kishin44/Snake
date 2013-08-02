using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : LinkedList<Rectangle>
    {
        Point Head = new Point(0, 1);
        Point Right = new Point(1, 0);
        Point Left = new Point(-1, 0);
        Point Top = new Point(0, -1);
        Point Bottom = new Point(0, 1);

        public Snake(LinkedList<Rectangle> body)
            :base(body)
        {
        }
        
        public void DrawYourself(Graphics graphics)
        {
            Matrix matrix = new Matrix();
            matrix.Scale(20.0F, 20.0F);
            graphics.Transform = matrix;

            graphics.FillRectangles(new SolidBrush(Color.Blue), this.ToArray());
        }

        public void Move()
        {
            Rectangle last = Last.Value;
            Rectangle first = First.Value;

            last.X = first.X + Head.X;
            last.Y = first.Y + Head.Y;

            AddFirst(last);
            RemoveLast();
        }

        public void GoLeft()
        {
            if(!Head.Equals(Right))
                Head = Left;
        }

        public void GoRight()
        {
            if(!Head.Equals(Left))
                Head = Right;
        }

        public void GoTop()
        {
            if(!Head.Equals(Bottom))
                Head = Top;
        }

        public void GoBottom()
        {
            if(!Head.Equals(Top))
                Head = Bottom;
        }
    }
}
