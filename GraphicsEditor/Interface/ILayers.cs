using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    internal interface ILayers
    {
        string Name { get; set; }
        Bitmap DrawLayer { get; set; }
    }
}
