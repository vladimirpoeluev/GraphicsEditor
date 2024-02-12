using GraphicsEditor.Tools;
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
        bool longPress = false;
        int numberBitmap = 0;
        string path;
        ColorDialog colorDialog;
        public Form1()
        {
            InitializeComponent();
            ImageFor = new ImageForDrawing(new OrdinaryCanvas(), new LineDraw());
            path = "image.png";
            colorDialog = new ColorDialog();
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
            pictureBox1.Image = ImageFor.CanvasD.GetBitmap();
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            ImageFor.AddPoint(e.Location, TypeClick.Click);
            Draw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImageFor.CanvasD.GetBitmap().Save("img.png", System.Drawing.Imaging.ImageFormat.Png);
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

        private void обычнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageFor.SetTool(new LineDraw());
        }

        private void обычнаяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ImageFor.SetTool(new RegularBrush());
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            longPress = true;
            ImageFor.AddPoint(e.Location, TypeClick.DownLeft);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            longPress = false;
            ImageFor.AddPoint(e.Location, TypeClick.UpLeft);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (longPress)
                ImageFor.AddPoint(e.Location, TypeClick.LongPress);
            Draw();
        }

        private void квадратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageFor.SetTool(new RectangleDraw());
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.ShowDialog();
            ImageFor.CanvasD.GetBitmap().Save(saveFile.FileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
            path = saveFile.FileName;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            if (fileDialog.FileName == null)
                return;
            ILayers l = new Layer()
            {
                DrawLayer = new Bitmap(fileDialog.FileName)
            };
            ICanvas canvas = new OrdinaryCanvas();
            canvas.AddLayer(l);
            canvas.SetActiveLayer(1);
            ImageFor = new ImageForDrawing(canvas, new LineDraw());
            path = fileDialog.FileName;
            Draw();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            colorDialog.ShowDialog(this);
            if (colorDialog.Color == null)
                return;
            DrawingOptions.Color = colorDialog.Color;
            button1.BackColor = colorDialog.Color;
        }

       

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            DrawingOptions.Width = (int)numericUpDown1.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numericUpDown1.Value = trackBar1.Value;
            DrawingOptions.Width = (int)numericUpDown1.Value;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool IsExpandedWindow = false;
        private void button3_Click(object sender, EventArgs e)
        {
            if (!IsExpandedWindow)
            {
                this.TopMost = true;
                this.WindowState = FormWindowState.Maximized;
                IsExpandedWindow = true;
            }
            else
            {
                this.TopMost = true;
                this.WindowState = FormWindowState.Normal;
                IsExpandedWindow = false;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.WindowState = FormWindowState.Minimized;
        }
        bool IsDown = false;
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            IsDown = true;
            Location = e.Location;
        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            IsDown = false;
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDown)
            {
                Location = e.Location;
            }
        }
    }
}
