using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.Tools
{
    internal class RegularBrush : ITool
    {
        Point? point;
        private void DrawLine(Bitmap bmp, Point p1)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawLine(Pens.Blue, (Point)point, p1);
            }

        }
        public void Draw(Bitmap bmp, Point p, TypeClick type)
        {
            if(type == TypeClick.UpLeft)
            {
                point = null;
                return;
            }
            if (type != TypeClick.LongPress)
                return;
            if (point == null)
            {
                point = p;
            }
            else
            {
                DrawLine(bmp, p);
                point = p;
            }

        }
    }
}
