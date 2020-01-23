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
    public partial class MainForm : Form
    {
        void TableSync()
        {
            dataGridView1.Rows.Clear();
            foreach (string row in data)
            {
                dataGridView1.Rows.Add(row);
            }
        }
        int selectedcell = 0;
        void LoadData()
        {
            try
            {
                data = File.ReadAllLines("base.txt").ToList();
            }
            catch
            {
                data = new List<string>();
            }
        }
        void SaveData()
        {
            File.WriteAllLines("base.txt", data);
        }

        void EditByIndex(int index)
        {
            EditData editData = new EditData(index, this);
            editData.ShowDialog();
            SaveData();
            TableSync();
        }

        public List<string> data;
        public MainForm()
        {
            InitializeComponent();
            LoadData();
            TableSync();
        }

        void DeleteData()
        {
            try
            {
                data.Remove(data[selectedcell]);
            }
            catch
            {
            }
            SaveData();
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
            EditByIndex(e.RowIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddData form = new AddData(this);
            form.ShowDialog();
            SaveData();
            TableSync();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try 
            {
                EditByIndex(selectedcell);
            }
            catch 
            {
                MessageBox.Show("Error!", "Laba4 - UCIT");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedcell = e.RowIndex;
        }
    }
}
