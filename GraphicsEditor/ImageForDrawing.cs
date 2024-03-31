using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Converters;

namespace GraphicsEditor
{
    internal class ImageForDrawing
    {
        public ICanvas CanvasD { get; private set; }
        private double _scale = 1;
        public double Scale { get 
            {
                return _scale;
            } 
            set 
            {
                _scale = value / 100;
            } 
        }
        public Size SizeWindow { get; set; }
        Point positionView = new Point(0, 0);
        private ITool _tool;
        private Bitmap _bitmapView;

        public ImageForDrawing(ICanvas canvas, IViewDrawingTool tool, Size size) 
        { 
            SetTool(tool);
            SizeWindow = size;
            CanvasD = canvas;
            _bitmapView = new Bitmap(CanvasD.GetBitmap());
        }
        int xPositionDraw = 0;
        int yPositionDraw = 0;
        public Bitmap GetView(Point p)
        {
            var result = new Bitmap(SizeWindow.Width, SizeWindow.Height);
            //_bitmapView = new Bitmap(CanvasD.ActiveLayer.DrawLayer);
            using (Graphics g = Graphics.FromImage(result)) {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;
                xPositionDraw = 0;

                yPositionDraw = 0;
                Rectangle destRectangle2 = new Rectangle(p.X, p.Y, (int)(_bitmapView.Width), (int)(_bitmapView.Height));

                
                
               
                
                Rectangle sourceRectangle = new Rectangle(xPositionDraw, yPositionDraw, (int)(_bitmapView.Width), (int)(_bitmapView.Height));
                g.DrawImage(_bitmapView, destRectangle2, sourceRectangle, GraphicsUnit.Pixel);
                //g.DrawImage(_bitmapView, p);
            }
            positionView = p;
            return result;
            
            
        }

        public void AddPoint(Point p, TypeClick type)
        {
            Point pointClick = p;
            p.X = (int)((p.X - positionView.X + xPositionDraw) / Scale);
            p.Y = (int)((p.Y - positionView.Y + yPositionDraw) / Scale);
            _tool.Draw(CanvasD.ActiveLayer.DrawLayer, p, type);
            _bitmapView.Dispose();
            ViewPoint(pointClick);
            
           
        }
        private Bitmap TransparentBackground(Bitmap bitmap)
        {
            Bitmap fonBitmap = (new Bitmap(bitmap.Width, bitmap.Height));
            using (Graphics g = Graphics.FromImage(fonBitmap))
            {
                g.Clear(Color.White);
                for (int i = 0; i * 10 < bitmap.Width; i++)
                {
                    for (int j = 0; j * 10 < bitmap.Height; j++)
                    {
                        if((i + j) % 2 != 0)
                        {
                            g.FillRectangle(Brushes.LightGray, i * 10, j * 10, 10, 10);
                        }
                    }
                }
                g.DrawImage(bitmap, 0, 0);
                bitmap = new Bitmap(fonBitmap);
                bitmap.Dispose();
            }
            return fonBitmap;
        }
        public void ViewPoint(Point p)
        {
            p.X = (int)((p.X - positionView.X + xPositionDraw) / Scale);
            p.Y = (int)((p.Y - positionView.Y + yPositionDraw) / Scale);

            _bitmapView.Dispose();
            Bitmap bm = CanvasD.GetBitmap();
            bm = TransparentBackground(bm);
            if (_tool is IViewDrawingTool)
            {
                _bitmapView = ((IViewDrawingTool)_tool).GetView(bm, p);
            }
            _bitmapView = new Bitmap(bm, new Size((int)(bm.Width * Scale), (int)(bm.Height * Scale)));
                
            bm.Dispose();
            
            
        }

        public void SetTool(ITool tool)
        {
            _tool = tool;
        }
        
    }
}
