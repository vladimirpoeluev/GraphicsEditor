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
    public partial class AddNewCanvas : Form
    {
        public Size SizeCanvas { get; private set; }
        public AddNewCanvas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SizeCanvas = new Size((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            this.Close();
        }
    }
}
