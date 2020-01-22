using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class EditData : Form
    {
        Form1 parent;
        int index;
        public EditData()
        {
            InitializeComponent();
        }
        public EditData(int index, Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.index = index;
            textBox1.Text = parent.data[index];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.data[index] = textBox1.Text; 
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }
    }
}
