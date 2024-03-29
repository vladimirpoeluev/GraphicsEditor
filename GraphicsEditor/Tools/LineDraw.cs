using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    internal class LineDraw : IViewDrawingTool
    {
        Point? point;
        private void DrawLine(Bitmap bmp, Point p1)
        {
            using(Graphics g = Graphics.FromImage(bmp))
            {
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.DrawLine(new Pen(DrawingOptions.Color, DrawingOptions.Width), (Point)point, p1);
            }
            
        }
        public void Draw(Bitmap bmp, Point p, TypeClick type)
        {
            if (type != TypeClick.UpLeft)
                return;
            if(point == null)
            {
                point = p;
            }
            else
            {
                DrawLine(bmp, p);
                point = null;
            }
           
        }

        public Bitmap GetView(Bitmap bitmap, Point p)
        {
            if (point == null)
                return bitmap;
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.DrawLine(new Pen(DrawingOptions.Color, DrawingOptions.Width), (Point)point, p);
            }
            return bitmap;
        }
    }
}
