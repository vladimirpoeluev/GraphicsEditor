using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace GraphicsEditor
{
    public partial class Form1 : Form
    {
        List<Bitmap> bitmaps = new List<Bitmap>();
        ImageForDrawing ImageFor;

        int numberBitmap = 0;
        public Form1()
        {
            InitializeComponent();
            ImageFor = new ImageForDrawing(new OrdinaryCanvas(), new LineDraw());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Bitmap bmp = new Bitmap(500, 400);
           
            
            //using(Graphics g = Graphics.FromImage(bmp))
            //{
            //    g.Clear(Color.Black);
                
            //}
            
        }

        Point? point;
        Bitmap bmp = new Bitmap(500, 400);
        
        public void Draw()
        {
            pictureBox1.Image = ImageFor.CanvasD.ActiveLayer.DrawLayer;
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            ImageFor.AddPoint(e.Location);
            Draw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImageFor.CanvasD.ActiveLayer.DrawLayer.Save("img.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if(numberBitmap < (bitmaps.Count - 1))
            {
                bmp = bitmaps[++numberBitmap];
            }
            Draw();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (numberBitmap >= 0)
            {
                bmp = bitmaps[--numberBitmap];
            }
            Draw();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void впередToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void печататьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
