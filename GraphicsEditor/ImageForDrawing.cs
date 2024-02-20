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
        private int _scale = 100;
        public int Scale { get 
            {
                return _scale;
            } set 
            {
                _scale = value;
            } 
        }

        private ITool _tool;
        private Bitmap _bitmapView;
        public ImageForDrawing(ICanvas canvas, IViewDrawingTool tool) 
        { 
            SetTool(tool);
            
            CanvasD = canvas;
            _bitmapView = new Bitmap(CanvasD.ActiveLayer.DrawLayer);
        }

        public Bitmap GetView(Point p)
        {
            
            var result = new Bitmap(_bitmapView);
            return result;
        }

        public void AddPoint(Point p, TypeClick type)
        {
            _tool.Draw(CanvasD.ActiveLayer.DrawLayer, p, type);
            _bitmapView.Dispose();
            _bitmapView = new Bitmap(CanvasD.ActiveLayer.DrawLayer);
        }
        public void ViewPoint(Point p)
        { 
            _bitmapView.Dispose();
            _bitmapView = new Bitmap(CanvasD.ActiveLayer.DrawLayer);
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
