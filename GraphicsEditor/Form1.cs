using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditor
{
    public partial class Form1 : Form
    {
        List<Bitmap> bitmaps = new List<Bitmap>();
        int numberBitmap = 0;
        public Form1()
        {
            InitializeComponent();
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
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            

            Point newPoint = new Point(e.X, e.Y);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                if(point == null)
                {
                    point = newPoint;
                }
                else
                {
                    
                    g.DrawLine(Pens.Blue, (Point)point, newPoint);
                    point = null;
                }
                bitmaps.Insert(numberBitmap, bmp);
            }
            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bmp.Save("img.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if(numberBitmap >= (bitmaps.Count - 1))
            {

            }
        }
    }
}
