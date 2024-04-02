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
            UpdateTranslete();
        }
        void UpdateTranslete()
        {
            
            label1.Text = LangNames.GetTranslete("lbl.width");
            label2.Text = LangNames.GetTranslete("lbl.height");
            Text = LangNames.GetTranslete("title.create");
            button1.Text = LangNames.GetTranslete("btn.create");
               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SizeCanvas = new Size((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
