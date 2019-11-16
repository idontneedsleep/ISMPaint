using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOPDraw1
{
    public class DrawPoint : ShapePoint
    {
        public DrawPoint(Color color, int x, int y) : base(color, x, y)
        {

        }
        public override void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(color);
            g.FillEllipse(brush, x1 - 1, y1 - 1, 2, 2);
        }
    }
}
