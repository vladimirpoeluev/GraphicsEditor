using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.Tools
{
    internal class RectangleDraw : IViewDrawingTool
    {
        private Point? point1;
        private Point? point2;
        private void DrawRectangle(Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                int xMax = point2.Value.X;
                int yMax = point2.Value.Y;
                int xMin = point1.Value.X;
                int yMin = point1.Value.Y;
                if (point1.Value.X >= point2.Value.X)
                {
                    xMax = point1.Value.X;
                    xMin = point2.Value.X;
                }
                if (point1.Value.Y >= point2.Value.Y)
                {
                    yMax = point1.Value.Y;
                    yMin = point2.Value.Y;
                }
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;

                Pen p = new Pen(DrawingOptions.Color, DrawingOptions.Width);
                System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(new Point(xMin, yMin),
                    new Size(xMax - xMin, yMax - yMin));
                g.DrawRectangle(p, rectangle);
            }
        }
        public void Draw(Bitmap bmp, Point p, TypeClick type)
        {
            if (type == TypeClick.UpLeft)
            {
                if (point1 == null)
                {
                    point1 = p;
                }
                else
                {
                    point2 = p;
                }


            }
            else if (type == TypeClick.UpRight)
            {
                point1 = null;
                point2 = null;
            }

            if (point1 != null && point2 != null)
            {
                DrawRectangle(bmp);
                point1 = null;
                point2 = null;
            }

        }

        public Bitmap GetView(Bitmap bmp, Point p)
        {
            if(point1 == null)
            {
                return bmp;
            }
            using (Graphics g = Graphics.FromImage(bmp))
            {
                int xMax = p.X;
                int yMax = p.Y;
                int xMin = point1.Value.X;
                int yMin = point1.Value.Y;
                if (point1.Value.X >= p.X)
                {
                    xMax = point1.Value.X;
                    xMin = p.X;
                }
                if (point1.Value.Y >= p.Y)
                {
                    yMax = point1.Value.Y;
                    yMin = p.Y;
                }
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                Pen pen = new Pen(DrawingOptions.Color, DrawingOptions.Width);
                System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(new Point(xMin, yMin),
                    new Size(xMax - xMin, yMax - yMin));
                g.DrawRectangle(pen, rectangle);
            }
            return bmp;
        }
    }
}
