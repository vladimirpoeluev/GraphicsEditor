using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    internal class Layer : ILayers
    {
        public string Name { get; set; }
        public Bitmap DrawLayer { get; set; }

        public Layer() 
        {
            DrawLayer = new Bitmap(800, 540);
        }
        public Layer(string name)
        {
            DrawLayer = new Bitmap(name);
        }

        public Layer(int  width, int height)
        {
            DrawLayer = new Bitmap(width, height);
        }
    }
}
