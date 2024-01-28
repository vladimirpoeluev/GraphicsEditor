using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor
{
    internal interface ICanvas
    {
        ILayers ActiveLayer { get; set; }
        ILayers[] Layers { get; }

        void AddLayer(ILayers layers);
        void RemoveLayer(int layer);
        void SetActiveLayer(int layer);
        Bitmap GetBitmap();
    }
}
