using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    internal interface IViewDrawingTool : ITool
    {
        Bitmap GetView(Bitmap bitmap, Point p);
    }
}
