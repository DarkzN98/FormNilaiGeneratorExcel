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
    public partial class KritAdd : Form
    {
        public DatabasePrak parent;

        public KritAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                parent.addKriteria(textBox1.Text);
            }
        }
    }
}
