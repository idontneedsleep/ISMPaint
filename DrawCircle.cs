using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOPDraw1
{
    public class DrawCircle : DrawPoint
    {
        protected int rad;
        public DrawCircle(Color color, int x1, int y1, int rad) : base(color, x1, y1)
        {
            this.rad = rad;
        }
        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(color, 2);
            g.DrawEllipse(pen, x1 - 1, y1 - 1, rad, rad);
        }
    }
}
