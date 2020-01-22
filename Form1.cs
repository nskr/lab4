using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        void TableSync()
        {
            dataGridView1.Rows.Clear();
            foreach (string row in data)
            {
                dataGridView1.Rows.Add(row);
            }
        }
        
        void LoadData()
        {
            try
            {
                data = File.ReadAllLines("base.txt");
            }
            catch
            {
                data = new string[0];
            }
        }
        void SaveData()
        {
            File.WriteAllLines("base.txt", data);
        }



        public string[] data;
        public Form1()
        {
            InitializeComponent();
            LoadData();
            TableSync();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             MessageBox.Show("It is worked!!", "Laba4 - UCIT");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // e.RowIndex;
            EditData editData = new EditData(e.RowIndex, this);
            editData.ShowDialog();
            SaveData();
            TableSync();
        }
    }
}
