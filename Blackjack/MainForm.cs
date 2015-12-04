using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using InputBox;

namespace Blackjack
{
    public partial class MainForm : Form
    {
        
        
        InputName tempName = new InputName();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1580, 960);
            pictureBox2.BackColor = Color.Transparent;

            // Change parent for overlay PictureBox...
            pictureBox2.Parent = pictureBox1;

        }

        private void menuItem5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Blackjack Game Rules! \n 1. Dealer deals the cards \n 2. Dealer deals the cards \n 3. Dealer deals the cards \n 4. Dealer deals the cards \n 5. Dealer deals the cards \n 6. Dealer deals the cards \n 7. Dealer deals the cards Dealer deals the cards");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button3.Visible = true;
            this.button4.Visible = true;
            this.button1.Visible = false;
            this.button2.Visible = false;

            this.button3.BringToFront();
            this.button4.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //create Blackjack table/cards
            gameTable1.create_Deck(1);
            gameTable1.shuffle_Deck();

            this.menuItem5.Enabled = true;
            this.button5.Visible = true;
            this.button6.Visible = true;
            this.button7.Visible = true;
            this.button8.Visible = true;
            this.button9.Visible = true;

            this.button3.Visible = false;
            this.button4.Visible = false;

            this.richTextBox1.Visible = true;
            this.richTextBox2.Visible = true;

            tempName.Show();

            this.pictureBox2.Enabled = true;
            this.pictureBox3.Enabled = true;
            this.pictureBox4.Enabled = true;
            this.pictureBox5.Enabled = true;

        }

        // Join active game
        private void button4_Click(object sender, EventArgs e)
        {
            this.button5.Visible = true;
            this.button6.Visible = true;
            this.button7.Visible = true;
            this.button8.Visible = true;
            this.button9.Visible = true;

            this.button3.Visible = false;
            this.button4.Visible = false;

            this.richTextBox1.Visible = true;
            this.richTextBox2.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //if (tempName.gotName == true)
            //{
            //    if (textBox1.Text == "")
            //    {
            //        textBox1.Text = tempName.personName;
            //    }
            //    else if (textBox2.Text == "")
            //    {
            //        textBox2.Text = tempName.personName;
            //    }
            //    else if (textBox3.Text == "")
            //    {
            //        textBox3.Text = tempName.personName;
            //    }
            //    else if (textBox4.Text == "")
            //    {
            //        textBox4.Text = tempName.personName;
            //    }
            //    else if (textBox5.Text == "")
            //    {
            //        textBox5.Text = tempName.personName;
            //    }
            //    else {
            //        MessageBox.Show("Game is full!!");
            //    }
            //}

            this.textBox6.Visible = true;
            this.button6.Enabled = true;
            this.button7.Enabled = true;
            this.button8.Enabled = true;
            this.button9.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            gameTable1.print_Table();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            playAudio();
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            stopAudio();
        }

        private void playAudio() // defining the function
        {
            SoundPlayer audio = new SoundPlayer(Blackjack.Properties.Resources.backgroundMusic); // here WindowsFormsApplication1 is the namespace and Connect is the audio file name
            audio.PlayLooping();
        }

        private void stopAudio() // defining the function
        {
            SoundPlayer audio = new SoundPlayer(Blackjack.Properties.Resources.backgroundMusic);
            audio.Stop();
        }

        private void menuItem5_Click_1(object sender, EventArgs e)
        {
            this.button5.Visible = true;
            this.button6.Visible = true;
            this.button7.Visible = true;
            this.button8.Visible = true;
            this.button9.Visible = true;

            this.button5.Enabled = false;
            this.button6.Enabled = false;
            this.button7.Enabled = false;
            this.button8.Enabled = false;
            this.button9.Enabled = false;

            this.button3.Visible = false;
            this.button4.Visible = false;

            this.richTextBox1.Visible = true;
            this.richTextBox2.Visible = true;

            this.button10.Visible = false;

            MessageBox.Show("To start select the bet amount by clicking the Chips and then click Bet!");

            this.pictureBox2.Enabled = true;
            this.pictureBox3.Enabled = true;
            this.pictureBox4.Enabled = true;
            this.pictureBox5.Enabled = true;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("100 clickd");
            this.button5.Enabled = true;
            this.button10.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("25 clickd");
            this.button5.Enabled = true;
            this.button10.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("5 clickd");
            this.button5.Enabled = true;
            this.button10.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 clickd");
            this.button5.Enabled = true;
            this.button10.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
}