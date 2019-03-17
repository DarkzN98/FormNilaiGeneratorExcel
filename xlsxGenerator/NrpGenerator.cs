using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xlsxGenerator
{
    public partial class NrpGenerator : Form
    {
        public DatabasePrak parent;
        public NrpGenerator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int start = Convert.ToInt32(textBox1.Text);
                int end = Convert.ToInt32(textBox2.Text);
                parent.updateListBoxPraktikan(start, end);
                MessageBox.Show("Generate Success!");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
