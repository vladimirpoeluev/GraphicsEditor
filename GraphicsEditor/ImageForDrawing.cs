﻿using System;
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

        public Bitmap GetView(Point p)
        {
            var result = new Bitmap(SizeWindow.Width, SizeWindow.Height);
            //_bitmapView = new Bitmap(CanvasD.ActiveLayer.DrawLayer);
            using (Graphics g = Graphics.FromImage(result)) {
                g.DrawImage(_bitmapView, p);
            }
            positionView = p;
            return result;
            
            
        }

        public void AddPoint(Point p, TypeClick type)
        {
            p.X = (int)((p.X - positionView.X) * Scale);
            p.Y = (int)((p.Y - positionView.Y) * Scale);
            _tool.Draw(CanvasD.ActiveLayer.DrawLayer, p, type);
            _bitmapView.Dispose();
            _bitmapView = new Bitmap(CanvasD.GetBitmap());
            
           
        }
        public void ViewPoint(Point p)
        {
            p.X = (int)((p.X - positionView.X));
            p.Y = (int)((p.Y - positionView.Y));

            _bitmapView.Dispose();
            Bitmap bm = CanvasD.GetBitmap();
            _bitmapView = new Bitmap(bm, new Size((int)(bm.Width * Scale), (int)(bm.Height * Scale)));
                if (_tool is IViewDrawingTool)
                {
                    _bitmapView = ((IViewDrawingTool)_tool).GetView(_bitmapView, p);
                }
            
            
            
        }

        public void SetTool(ITool tool)
        {
            _tool = tool;
        }
        
    }
}
