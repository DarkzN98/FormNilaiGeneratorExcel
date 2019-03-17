using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using xlsxGenerator.Classes;

namespace xlsxGenerator
{
    public partial class Generator : Form
    {
        public MainForm parent;

        public Generator()
        {
            InitializeComponent();
        }

        public void updateComboBox()
        {
            comboBox1.Items.Clear();
            foreach (Praktikum item in parent.praktikums)
            {
                comboBox1.Items.Add(item.PraktikumName);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                previewExcel(comboBox1.SelectedIndex);
            }
        }

        private void Generator_Load(object sender, EventArgs e)
        {
            updateComboBox();
        }

        private void previewExcel(int index)
        {
            Praktikum preview = parent.praktikums[index];
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = preview.Kriteria.Count + 3;
            dataGridView1.Rows.Add("NRP","Total");
            for (int i = 1; i <= preview.Kriteria.Count; i++)
            {
                dataGridView1.Rows[0].Cells[i+1].Value = preview.Kriteria[i-1];
            }
            dataGridView1.Rows[0].Cells[dataGridView1.ColumnCount-1].Value = "Keterangan";

            foreach (String praktikan in preview.Praktikan)
            {
                dataGridView1.Rows.Add(praktikan);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Application app = new Microsoft.Office.Interop.Excel.Application();
            _Workbook book = app.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;
            sheet = book.Sheets["Sheet1"];
            sheet = book.ActiveSheet;
            sheet.Name = "FormNilai";
            
            char[] chara = new char[25];

            for (int i = 0; i < 25; i++)
            {
                chara[i] = (char)(i+65);
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                {
                    sheet.Cells[i+1, j+1] = dataGridView1.Rows[i].Cells[j].Value;
                }
                sheet.Cells[i + 1, 2].Formula = "=SUM(C" + (i+1) + ":" + chara[dataGridView1.Rows[0].Cells.Count - 2] + (i+1)+")";
            }
            sheet.Cells[1, 2] = "Total";

            //show save dialog
            var SaveDialog = new SaveFileDialog();
            SaveDialog.FileName = "Form_Nilai";
            SaveDialog.DefaultExt = ".xlsx";
            SaveDialog.AddExtension = true;
            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                book.SaveAs(SaveDialog.FileName, Type.Missing);
            }
            app.Quit();
            MessageBox.Show("Generate Excel Success!");
        }
    }
}
