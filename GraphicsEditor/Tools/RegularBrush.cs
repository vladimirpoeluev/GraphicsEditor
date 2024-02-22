using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Markup;

namespace GraphicsEditor.Tools
{
    internal class RegularBrush : ITool
    {
        Point? point;
        private void DrawLine(Bitmap bmp, Point p1)
        {
            lock(bmp)
            using (Graphics g = Graphics.FromImage(bmp))
            {
                    g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                int width = DrawingOptions.Width;
                Pen pen = new Pen(DrawingOptions.Color, width);
                g.DrawLine(pen, (Point)point, p1);
                p1.X -= width / 2;
                p1.Y -= width / 2;
                Brush brush = new SolidBrush(DrawingOptions.Color);
                g.FillEllipse(brush, new RectangleF(p1, new Size(width, width)));
            }

        }
        public void Draw(Bitmap bmp, Point p, TypeClick type)
        {
            
                
                    if (type == TypeClick.UpLeft)
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
