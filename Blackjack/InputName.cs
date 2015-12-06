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
        private MainForm mainForm;

        public InputName(MainForm _mainForm)
        {
            this.mainForm = _mainForm;
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

            // Fixed the errors here by passing a reference to the MainForm class when this class is created.
            // the variable 'mainForm' is the handle to the MainForm and everything inside it.
            // -Ethan
            mainForm.textBox1.Text = one.get_Name();
            mainForm.textBox1.Visible = true;
            mainForm.textBox2.Visible = true;
            mainForm.textBox3.Visible = true;
            mainForm.textBox4.Visible = true;
            mainForm.textBox5.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
