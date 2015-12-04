using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack
{
    public partial class InputName : Form
    {
        public InputName()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tempName;
            tempName = textBox1.Text;
            this.Close();
            MessageBox.Show("To start select the bet amount by clicking the Chips and then click Bet!");
            Player one = new Player(tempName, 1);
            MainForm.gameTable1.add_Player(one);
            MainForm.textBox1.Text = one.get_Name();
            MainForm.textBox1.Visible = true;
            MainForm.textBox2.Visible = true;
            MainForm.textBox3.Visible = true;
            MainForm.textBox4.Visible = true;
            MainForm.textBox5.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
