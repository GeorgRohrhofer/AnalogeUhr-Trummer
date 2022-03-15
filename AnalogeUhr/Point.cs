using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalogeUhr
{
    class Point
    {
        public int x { get; set; }
        public int y { get; set; }

        private int angle;

        public static readonly int SIZE = 10;
        public Point(int x, int y, int angle)
        {
            this.x = x;
            this.y = y;
            this.angle = angle;
        }

        public void Paint(Graphics g)
        {
            int dx = (int)Math.Round(SIZE * Math.Cos(angle * (Math.PI / 180)));
            int dy = (int)Math.Round(SIZE * Math.Sin(angle * (Math.PI / 180)));
            Pen p;

            if (angle == 0 || angle == 90 || angle == 180 || angle == 270)
            {
                p = new Pen(Brushes.Black, 1);
                if (angle == 0)
                    dx += 15;
                else if (angle == 90)
                    dy += 15;
                else if (angle == 180)
                    dx -= 15;
                else if (angle == 270)
                    dy -= 15;

            }
                
            else
                p = Pens.Black;
            g.DrawLine(p, this.x, this.y, this.x + dx, this.y - dy);
        }
    }
}
