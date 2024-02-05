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
                int width = 7;
                Pen pen = new Pen(Color.Blue, width);
                g.DrawLine(pen, (Point)point, p1);
                p1.X -= width / 2;
                p1.Y -= width / 2;
                g.FillEllipse(Brushes.Blue, new RectangleF(p1, new Size(width, width)));
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
