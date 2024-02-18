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

        private ITool _tool;
        
        public ImageForDrawing(ICanvas canvas, ITool tool) 
        { 
            SetTool(tool);
            CanvasD = canvas;
        }

        public Bitmap GetView(Point p)
        {
            return new Bitmap(CanvasD.ActiveLayer.DrawLayer);
        }

        public void AddPoint(Point p, TypeClick type)
        {
            _tool.Draw(CanvasD.ActiveLayer.DrawLayer, p, type);
        }
        public void ViewPoint(Point p)
        {
            if(_tool is IViewDrawingTool)
            {
                ((IViewDrawingTool)_tool).GetView(GetView(new Point(0, 0)), p);
            }
        }

        public void SetTool(ITool tool)
        {
            _tool = tool;
        }
        
    }
}
