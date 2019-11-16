using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOPDraw1
{
    public class DrawElipse : DrawCircle
    {
        protected int rad1;
        protected int rad2;
        public DrawElipse(Color color, int x1, int y1, int rad1, int rad2) : base(color, x1, y1, rad1)
        {
            this.rad1 = rad1;
            this.rad2 = rad2;
        }
        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(color, 2);
            g.DrawEllipse(pen, x1 - 1, y1 - 1, rad1, rad2);
        }
    }
}
