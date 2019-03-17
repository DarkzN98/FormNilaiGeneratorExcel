using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using xlsxGenerator.Classes;

namespace xlsxGenerator
{
    public partial class MainForm : Form
    {

        Generator fg;
        DatabasePrak db_prak;
        public List<Praktikum> praktikums;

        public MainForm()
        {
            InitializeComponent();
        }

        private void kelasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //load form praktikum
            db_prak = new DatabasePrak();
            db_prak.MdiParent = this;
            db_prak.parent = this;
            db_prak.Show();
        }

        public void savePraktikum()
        {
            //serialize prak
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("DB_PRAKS.bin", FileMode.Create);
            try
            {
                using (fs)
                {
                    bf.Serialize(fs,praktikums);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void loadPraktikum()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("DB_PRAKS.bin", FileMode.Open);
            try
            {
                using (fs)
                {
                    praktikums = (List<Praktikum>) bf.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            praktikums = new List<Praktikum>();
            loadPraktikum();
        }

        private void excelGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fg = new Generator();
            fg.MdiParent = this;
            fg.parent = this;
            fg.Show();
        }
    }
}
