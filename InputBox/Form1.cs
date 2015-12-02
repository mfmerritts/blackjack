using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string personName = textInput.Text;
            this.Close();
            MessageBox.Show("To start select the bet amount by clicking the Chips and then click Bet!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
