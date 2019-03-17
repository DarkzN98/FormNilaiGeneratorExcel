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
    public partial class DatabasePrak : Form
    {
        public MainForm parent;
        NrpGenerator ngen;
        NrpAdd nadd;
        KritAdd kadd;
        LoadPraktikum lprak;

        public DatabasePrak()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //generate Praktikan
            ngen = new NrpGenerator();
            ngen.parent = this;
            ngen.Show();
        }

        private void DatabasePrak_Load(object sender, EventArgs e)
        {
            parent = (MainForm)this.MdiParent;
        }

        private void updateCount()
        {
            label1.Text = "Count : " + listBox1.Items.Count;
        }

        public void updateListBoxPraktikan(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (!listBox1.Items.Contains(i))
                {
                    listBox1.Items.Add(i);
                }
            }
            updateCount();
        }

        public void loadPraktikum(int index)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            if (index >= 0 && index < parent.praktikums.Count)
            {
                Praktikum item = parent.praktikums[index];
                foreach (String praktikan in item.Praktikan)
                {
                    listBox1.Items.Add(praktikan);
                }
                foreach (String kriteria in item.Kriteria)
                {
                    listBox2.Items.Add(kriteria);
                }
            }
            MessageBox.Show("Load Praktikum Success!");
        }

        public void addKriteria(String kriteria)
        {
            listBox2.Items.Add(kriteria);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            updateCount();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nadd = new NrpAdd();
            nadd.parent = this;
            nadd.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            updateCount();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            kadd = new KritAdd();
            kadd.parent = this;
            kadd.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //save praktikum
            List<String> praktikans = new List<String>();
            List<String> kriterias = new List<String>();

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                praktikans.Add(listBox1.Items[i].ToString());
            }

            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                kriterias.Add(listBox2.Items[i].ToString());
            }

            parent.praktikums.Add(new Praktikum(textBox1.Text, praktikans,kriterias));
            MessageBox.Show("Praktikum Successfully Added!");
            parent.praktikums.Sort();
            parent.savePraktikum();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lprak = new LoadPraktikum();
            lprak.mf = parent;
            lprak.parent = this;
            lprak.Show();
        }
    }
}
