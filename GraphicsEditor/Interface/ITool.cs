using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    enum TypeClick
    {
        Click,
        LongPress
    }
    internal interface ITool
    {
        void Draw(Bitmap bmp, Point p, TypeClick type);
    }
}
