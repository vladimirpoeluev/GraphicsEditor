using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    internal class OrdinaryCanvas : ICanvas
    {
        public ILayers ActiveLayer { get; set; }

        public List<ILayers> layers = new List<ILayers>()
        {
            new Layer()
        };
        public OrdinaryCanvas()
        {
            ActiveLayer = layers[0];
        }
        public ILayers[] Layers 
        {
            get
            {
                return layers.ToArray();
            }
        }

        public void AddLayer(ILayers layer)
        {
            layers.Add(layer);
        }

        public Bitmap GetBitmap()
        {
            Bitmap bitmap = new Bitmap(400, 500);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                foreach (var layer in layers)
                {
                    g.DrawImage(layer.DrawLayer, 0, 0);
                }

            }
            return bitmap;
        }

        public void RemoveLayer(int layer)
        {
            layers.RemoveAt(layer);
        }

        public void SetActiveLayer(int layer)
        {
            ActiveLayer = layers[layer];
        }
    }
}
