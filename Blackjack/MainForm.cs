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
using EasyNetwork;

namespace Blackjack
{
    public partial class MainForm : Form
    {
        Client client = new Client("tcp://localhost:3000");
        InputName tempName;

        public MainForm()
        {
            tempName = new InputName(this);
            InitializeComponent();

            client.DataReceived += Client_DataReceived;
            client.Start();
        }

        private void Client_DataReceived(object receivedObject)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1580, 960);
            pictureBox2.BackColor = Color.Transparent;

            // Change parent for overlay PictureBox...
            pictureBox2.Parent = pictureBox1;

        }
  
        private void MainForm_FormClosing(object sender, EventArgs e)
        {
            client.Stop();
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
            this.button11.Visible = true;

            this.button3.Visible = false;
            this.button4.Visible = false;

            this.richTextBox1.Visible = true;
            this.richTextBox2.Visible = true;

            if (tempName.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("To start select the bet amount by clicking the Chips and then click Bet!");
                Player one = new Player(tempName.InputResult, 1);
                MainForm.gameTable1.add_Player(one);

                textBox1.Text = one.get_Name();
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
            }


            this.pictureBox2.Enabled = true;
            this.pictureBox3.Enabled = true;
            this.pictureBox4.Enabled = true;
            this.pictureBox5.Enabled = true;

        }

        // Join active game
        private void button4_Click(object sender, EventArgs e)
        {
            this.button3.Visible = false;
            this.button4.Visible = false;

            InputName input = new InputName(this);
            if (input.ShowDialog() == DialogResult.OK)
            {
                this.labelJoiningGame.Visible = true;
                NetworkObjects.JoinGame joinGameMsg = new NetworkObjects.JoinGame();
                joinGameMsg.Name = input.InputResult;
                client.Send(joinGameMsg);
            }

            /*
            this.button5.Visible = true;
            this.button6.Visible = true;
            this.button7.Visible = true;
            this.button8.Visible = true;
            this.button9.Visible = true;

            this.richTextBox1.Visible = true;
            this.richTextBox2.Visible = true;
            */
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox6.Visible = true;
            this.button6.Enabled = true;
            this.button7.Enabled = true;
            this.button8.Enabled = true;
            this.button9.Enabled = true;

            gameTable1.table[0].set_Bet(gameTable1.table[0].get_tempBet());
            this.richTextBox2.Text = "Pot: $" + gameTable1.table[0].get_Money().ToString();
            gameTable1.test_Round();
            this.pictureBox6.Image = Blackjack.Properties.Resources.ace_of_clubs;
            this.button5.Enabled = false;

            //enable surrender
            this.button11.Enabled = true;

            //activates player
            gameTable1.table[0].activate();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i = 0;
            //disables surrender
            this.button11.Enabled = false;

            //start turn if hit
                     
                gameTable1.deal_Card_To_Person(i);
                if (gameTable1.table[i].sum_Hand() > 21)
                {
                    for (int y = 0; y < gameTable1.table[i].hand.Count(); y++)
                    {
                        if (gameTable1.table[i].hand[y].get_Rank() == 'a' && gameTable1.table[i].sum_Hand() > 21)
                        {
                            gameTable1.table[i].hand[y].change_Ace();
                        }
                    }
                }
                MessageBox.Show("total is " + gameTable1.table[i].sum_Hand());
                if (gameTable1.table[i].sum_Hand() > 21)
                {
                    gameTable1.table[i].deactivate();
                    MessageBox.Show("Sorry " + gameTable1.table[i].get_Name() + ", you have bust");
                }             
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //disable surrender
            this.button11.Enabled = false;
            this.button6.Enabled = false;
            gameTable1.dealer.start_Turn();
            gameTable1.dealer.auto_Deal(gameTable1);
            gameTable1.check_Players_Vs_Dealer();
            this.richTextBox2.Text = "Pot: $" + gameTable1.table[0].get_Money().ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //disable surrender
            this.button11.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            gameTable1.print_Table();
            this.button11.Enabled = false;
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
            SoundPlayer audio = new SoundPlayer(global::Blackjack.Properties.Resources.backgroundMusic); // here WindowsFormsApplication1 is the namespace and Connect is the audio file name
            audio.PlayLooping();
        }

        private void stopAudio() // defining the function
        {
            SoundPlayer audio = new SoundPlayer(global::Blackjack.Properties.Resources.backgroundMusic);
            audio.Stop();
        }

        private void menuItem5_Click_1(object sender, EventArgs e)
        {
            this.button5.Visible = true;
            this.button6.Visible = true;
            this.button7.Visible = true;
            this.button8.Visible = true;
            this.button9.Visible = true;
            this.button11.Visible = true;

            this.button5.Enabled = false;
            this.button6.Enabled = false;
            this.button7.Enabled = false;
            this.button8.Enabled = false;
            this.button9.Enabled = false;
            this.button11.Enabled = false;

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
            //MessageBox.Show("100 clickd");
            this.button5.Enabled = true;
            this.button10.Visible = true;
            gameTable1.table[0].set_tempBet(100);
            this.richTextBox1.Text = "Bet: $" + gameTable1.table[0].get_tempBet().ToString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("25 clickd");
            this.button5.Enabled = true;
            this.button10.Visible = true;
            gameTable1.table[0].set_tempBet(25);
            this.richTextBox1.Text = "Bet: $" + gameTable1.table[0].get_tempBet().ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("5 clickd");
            this.button5.Enabled = true;
            this.button10.Visible = true;
            gameTable1.table[0].set_tempBet(5);
            this.richTextBox1.Text = "Bet: $" + gameTable1.table[0].get_tempBet().ToString();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("1 clickd");
            this.button5.Enabled = true;
            this.button10.Visible = true;
            gameTable1.table[0].set_tempBet(1);
            this.richTextBox1.Text = "Bet: $" + gameTable1.table[0].get_tempBet().ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            gameTable1.table[0].reset_tempBet();
            this.richTextBox1.Text = "Bet: $" + gameTable1.table[0].get_tempBet().ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}