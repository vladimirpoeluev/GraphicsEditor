using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    internal interface ITool
    {
        void Draw(Bitmap bmp, Point p1);
    }
}
