using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xlsxGenerator.Classes;

namespace xlsxGenerator
{
    public partial class LoadPraktikum : Form
    {
        public MainForm mf;
        public DatabasePrak parent;

        public LoadPraktikum()
        {
            InitializeComponent();
        }

        private void LoadPraktikum_Load(object sender, EventArgs e)
        {
            foreach (Praktikum item in mf.praktikums)
            {
                comboBox1.Items.Add(item.PraktikumName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.loadPraktikum(comboBox1.SelectedIndex);
            this.Close();
        }
    }
}
