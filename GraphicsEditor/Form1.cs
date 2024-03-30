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
using System.Windows.Markup.Localizer;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Drawing.Printing;
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
        Point cursorPositiun;
        public Form1()
        {
            InitializeComponent();
            button1.BackColor = DrawingOptions.Color;
            ImageFor = new ImageForDrawing(new OrdinaryCanvas(), new LineDraw(), pictureBox1.Size);
            path = "image.png";
            colorDialog = new ColorDialog();
            timer1.Start();
            bitmap = ImageFor.GetView(new Point(0, 0));
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            cursorPositiun = new Point(0, 0);
            positionView = new Point(pictureBox1.Size.Width / 2, pictureBox1.Height / 2);
            
            pictureBox1.MouseWheel += (ob, e) =>
            {
                if (isControl)
                {
                    try
                    {
                        trackBar2.Value += e.Delta / 10;
                        ImageFor.Scale = trackBar2.Value;
                        label2.Text = (ImageFor.Scale * 100).ToString() + "%";
                        ImageFor.ViewPoint(e.Location);
                        Draw();
                    }
                    catch (Exception)
                    {

                    }
                    
                }
            };
            foreach (string nameLang in LangNames.GetLanguages())
                toolStripComboBox1.Items.Add(nameLang);
            SetLang();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Bitmap bmp = new Bitmap(500, 400);
           
            
            //using(Graphics g = Graphics.FromImage(bmp))
            //{
            //    g.Clear(Color.Black);
                
            //}
            
        }

        void SetLang()
        {
            новыйToolStripMenuItem.Text = LangNames.GetTranslete("buttn.newfile");
            сохранитьToolStripMenuItem.Text = LangNames.GetTranslete("buttn.save");
            сохранитьКакToolStripMenuItem.Text = LangNames.GetTranslete("buttn.saveas");
            печататьToolStripMenuItem.Text = LangNames.GetTranslete("buttn.print");
            выйтиToolStripMenuItem.Text = LangNames.GetTranslete("buttn.exit");
            открытьToolStripMenuItem.Text = LangNames.GetTranslete("buttn.open");
            инструментыToolStripMenuItem.Text = LangNames.GetTranslete("buttn.tool");
            файлToolStripMenuItem.Text = LangNames.GetTranslete("buttn.file");
            видToolStripMenuItem.Text = LangNames.GetTranslete("buttn.view");
            настройкиToolStripMenuItem.Text = LangNames.GetTranslete("buttn.settings");
            назадToolStripMenuItem.Text = LangNames.GetTranslete("buttn.paneltools");
            свойстваToolStripMenuItem.Text = LangNames.GetTranslete("buttn.propert");
            строкаСостоянияToolStripMenuItem.Text = LangNames.GetTranslete("buttn.linestats");
            впередToolStripMenuItem.Text = LangNames.GetTranslete("buttn.zoom");
            языкToolStripMenuItem.Text = LangNames.GetTranslete("buttn.lang");
            папкаПоУмолчаниюToolStripMenuItem.Text = LangNames.GetTranslete("buttn.dirdefault");
            назадToolStripMenuItem1.Text = LangNames.GetTranslete("buttn.back");
            впередToolStripMenuItem1.Text = LangNames.GetTranslete("buttn.next");
            рисованиеToolStripMenuItem.Text = LangNames.GetTranslete("buttn.draw");
            линииToolStripMenuItem.Text = LangNames.GetTranslete("buttn.draw.line");
            обычнаяToolStripMenuItem.Text = LangNames.GetTranslete("buttn.draw.line.defalt");
            кистиToolStripMenuItem.Text = LangNames.GetTranslete("buttn.draw.brush");
            обычнаяToolStripMenuItem1.Text = LangNames.GetTranslete("buttn.draw.brush.defalt");
            фигурыToolStripMenuItem.Text = LangNames.GetTranslete("buttn.draw.figure");
            квадратToolStripMenuItem.Text = LangNames.GetTranslete("buttn.draw.brush.rectangle");
            button3.Text = LangNames.GetTranslete("buttn.eraser");
            button2.Text = LangNames.GetTranslete("buttn.hidepanel");
        }
       
        Bitmap bitmap;
        public void Draw()
        {
            pictureBox1.Refresh();
            
            
            
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //ImageFor.AddPoint(e.Location, TypeClick.Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImageFor.CanvasD.GetBitmap().Save("img.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
           
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
            
            if (e.Button == MouseButtons.Left)
                longPress = true;
            if (isControl)
                Cursor = Cursors.NoMove2D;
            else
            {
                if(e.Button == MouseButtons.Left)
                {
                    ImageFor.AddPoint(e.Location, TypeClick.DownLeft);
                }
                
            }
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                longPress = false;
            if(!isControl)
                if (e.Button == MouseButtons.Left)
                {
                    ImageFor.AddPoint(e.Location, TypeClick.UpLeft);
                }
                    
        }
        Point? backPoint;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (isControl && longPress)
            {
                if(backPoint != null)
                {
                    positionView = new Point(positionView.X - (backPoint.Value.X - e.X), positionView.Y - (backPoint.Value.Y - e.Y));
                }
                backPoint = e.Location;
            }
            else if (longPress)
            {
                ImageFor.AddPoint(e.Location, TypeClick.LongPress);

            }

            
            ImageFor.ViewPoint(e.Location);
            
            Draw();
            label1.Text = $"\t{ImageFor.CanvasD.ActiveLayer.DrawLayer.Width}\tx\t{ImageFor.CanvasD.ActiveLayer.DrawLayer.Height}\t\t {e.Location}\t";

        }

        private void квадратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageFor.SetTool(new RectangleDraw());
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "picture png (*.png)|*.png";
            if(saveFile.ShowDialog() == DialogResult.OK)
            {
                ImageFor.CanvasD.GetBitmap().Save(saveFile.FileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
                path = saveFile.FileName;
            }

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "picture png (*.png)|*.png";
            
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;
            ILayers l = new Layer(fileDialog.FileName);
            ICanvas canvas = new OrdinaryCanvas();
            canvas.AddLayer(l);
            canvas.SetActiveLayer(1);
            ImageFor = new ImageForDrawing(canvas, new LineDraw(), pictureBox1.Size);
            path = fileDialog.FileName;
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
        



        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
        }
        private void menuStrip1_MouseLeave(object sender, EventArgs e)
        {


            



        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            // Draw();
            cursorPositiun = Cursor.Position;
            
           
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
            назадToolStripMenuItem.Checked = false;

        }

        private void назадToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            flowLayoutPanel1.Visible = !flowLayoutPanel1.Visible;
            назадToolStripMenuItem.Checked = flowLayoutPanel1.Visible;
        }

        private void впередToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
        Point positionView;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            bitmap = ImageFor.GetView(positionView);
            e.Graphics.DrawImage(bitmap, 0, 0);
            bitmap.Dispose();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DrawingOptions.Color = Color.FromArgb(0, 0, 0, 0);
           
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            ImageFor.Scale = trackBar2.Value;
            label2.Text = trackBar2.Value.ToString() + '%';
            ImageFor.ViewPoint(new Point(0, 0));
            Draw();

        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            if(ImageFor != null)
            ImageFor.SizeWindow = pictureBox1.Size;
        }



        bool isControl = false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.ControlKey)
            {
                isControl = true;
                Cursor = Cursors.NoMove2D;
                
            }
                
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                isControl = false;
                Cursor = Cursors.Default;
                backPoint = null;
            }
                
        }

        

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ImageFor.CanvasD.GetBitmap().Save(path, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить файл в папку по умолчанию", "Измените папку по умолчанию");
            }
        }

        private void папкаПоУмолчаниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            
                if (dialog.ShowDialog() == DialogResult.OK)
                    path = dialog.SelectedPath + "\\newFile.png";
           
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ImageFor.Scale = 10;
            label2.Text = "10" + '%';
            ImageFor.ViewPoint(new Point(0, 0));
            Draw();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ImageFor.Scale = 50;
            label2.Text = "50" + '%';
            ImageFor.ViewPoint(new Point(0, 0));
            Draw();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ImageFor.Scale = 100;
            label2.Text = "100" + '%';
            ImageFor.ViewPoint(new Point(0, 0));
            Draw();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ImageFor.Scale = 150;
            label2.Text = "150" + '%';
            ImageFor.ViewPoint(new Point(0, 0));
            Draw();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ImageFor.Scale = 200;
            label2.Text = "200" + '%';
            ImageFor.ViewPoint(new Point(0, 0));
            Draw();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ImageFor.Scale = 250;
            label2.Text = "250" + '%';
            ImageFor.ViewPoint(new Point(0, 0));
            Draw();
        }

        private void строкаСостоянияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
            tableLayoutPanel2.Visible = ((ToolStripMenuItem)sender).Checked;
            
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void языкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            LangNames.SetLanguage(toolStripComboBox1.Text);
            SetLang();
        }
        Bitmap memoryImage;
        private void печататьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
            memoryImage = ImageFor.CanvasD.GetBitmap();
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            printDocument1.Print();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewCanvas addNewCanvas = new AddNewCanvas();
            addNewCanvas.ShowDialog();
            ImageFor = new ImageForDrawing(new OrdinaryCanvas(), new LineDraw(), addNewCanvas.SizeCanvas);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
    }
}
