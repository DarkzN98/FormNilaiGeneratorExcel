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
    public partial class NrpAdd : Form
    {
        public DatabasePrak parent;
        public NrpAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int nrp = Convert.ToInt32(textBox1.Text);
                parent.updateListBoxPraktikan(nrp,nrp);
            }
        }
    }
}
