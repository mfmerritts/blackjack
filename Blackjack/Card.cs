using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Blackjack
{
    public class Card
    {
        public int score;
        public char rank;
        public string suit;
        public Image image;

        //constructor for card. Requires a char for rank and a string for suit. Score is set depending on rank.
        public Card(char y, string z)
        {
            rank = y;
            suit = z;

            if (rank == 'a') { score = 11; }
            if (rank == '1') { score = 10; }
            if (rank == '2') { score = 2; }
            if (rank == '3') { score = 3; }
            if (rank == '4') { score = 4; }
            if (rank == '5') { score = 5; }
            if (rank == '6') { score = 6; }
            if (rank == '7') { score = 7; }
            if (rank == '8') { score = 8; }
            if (rank == '9') { score = 9; }
            if (rank == 'j') { score = 10; }
            if (rank == 'q') { score = 10; }
            if (rank == 'k') { score = 10; }

            //hearts
            if (rank == 'a' && suit == "heart") { image = Blackjack.Properties.Resources.ace_of_hearts;}
            if (rank == '1' && suit == "heart") { image = Blackjack.Properties.Resources._10_of_hearts;}
            if (rank == '2' && suit == "heart") { image = Blackjack.Properties.Resources._2_of_hearts;}
            if (rank == '3' && suit == "heart") { image = Blackjack.Properties.Resources._3_of_hearts;}
            if (rank == '4' && suit == "heart") { image = Blackjack.Properties.Resources._4_of_hearts;}
            if (rank == '5' && suit == "heart") { image = Blackjack.Properties.Resources._5_of_hearts;}
            if (rank == '6' && suit == "heart") { image = Blackjack.Properties.Resources._6_of_hearts;}
            if (rank == '7' && suit == "heart") { image = Blackjack.Properties.Resources._7_of_hearts;}
            if (rank == '8' && suit == "heart") { image = Blackjack.Properties.Resources._8_of_hearts;}
            if (rank == '9' && suit == "heart") { image = Blackjack.Properties.Resources._9_of_hearts;}
            if (rank == 'j' && suit == "heart") { image = Blackjack.Properties.Resources.jack_of_hearts;}
            if (rank == 'q' && suit == "heart") { image = Blackjack.Properties.Resources.queen_of_hearts;}
            if (rank == 'k' && suit == "heart") { image = Blackjack.Properties.Resources.king_of_hearts;}
            //diamonds
            if (rank == 'a' && suit == "diamond") { image = Blackjack.Properties.Resources.ace_of_diamonds; }
            if (rank == '1' && suit == "diamond") { image = Blackjack.Properties.Resources._10_of_diamonds; }
            if (rank == '2' && suit == "diamond") { image = Blackjack.Properties.Resources._2_of_diamonds; }
            if (rank == '3' && suit == "diamond") { image = Blackjack.Properties.Resources._3_of_diamonds; }
            if (rank == '4' && suit == "diamond") { image = Blackjack.Properties.Resources._4_of_diamonds; }
            if (rank == '5' && suit == "diamond") { image = Blackjack.Properties.Resources._5_of_diamonds; }
            if (rank == '6' && suit == "diamond") { image = Blackjack.Properties.Resources._6_of_diamonds; }
            if (rank == '7' && suit == "diamond") { image = Blackjack.Properties.Resources._7_of_diamonds; }
            if (rank == '8' && suit == "diamond") { image = Blackjack.Properties.Resources._8_of_diamonds; }
            if (rank == '9' && suit == "diamond") { image = Blackjack.Properties.Resources._9_of_diamonds; }
            if (rank == 'j' && suit == "diamond") { image = Blackjack.Properties.Resources.jack_of_diamonds; }
            if (rank == 'q' && suit == "diamond") { image = Blackjack.Properties.Resources.queen_of_diamonds; }
            if (rank == 'k' && suit == "diamond") { image = Blackjack.Properties.Resources.king_of_diamonds; }
            //spades
            if (rank == 'a' && suit == "spade") { image = Blackjack.Properties.Resources.ace_of_spades; }
            if (rank == '1' && suit == "spade") { image = Blackjack.Properties.Resources._10_of_spades; }
            if (rank == '2' && suit == "spade") { image = Blackjack.Properties.Resources._2_of_spades; }
            if (rank == '3' && suit == "spade") { image = Blackjack.Properties.Resources._3_of_spades; }
            if (rank == '4' && suit == "spade") { image = Blackjack.Properties.Resources._4_of_spades; }
            if (rank == '5' && suit == "spade") { image = Blackjack.Properties.Resources._5_of_spades; }
            if (rank == '6' && suit == "spade") { image = Blackjack.Properties.Resources._6_of_spades; }
            if (rank == '7' && suit == "spade") { image = Blackjack.Properties.Resources._7_of_spades; }
            if (rank == '8' && suit == "spade") { image = Blackjack.Properties.Resources._8_of_spades; }
            if (rank == '9' && suit == "spade") { image = Blackjack.Properties.Resources._9_of_spades; }
            if (rank == 'j' && suit == "spade") { image = Blackjack.Properties.Resources.jack_of_spades; }
            if (rank == 'q' && suit == "spade") { image = Blackjack.Properties.Resources.queen_of_spades; }
            if (rank == 'k' && suit == "spade") { image = Blackjack.Properties.Resources.king_of_spades; }
            //clubs
            if (rank == 'a' && suit == "club") { image = Blackjack.Properties.Resources.ace_of_clubs; }
            if (rank == '1' && suit == "club") { image = Blackjack.Properties.Resources._10_of_clubs; }
            if (rank == '2' && suit == "club") { image = Blackjack.Properties.Resources._2_of_clubs; }
            if (rank == '3' && suit == "club") { image = Blackjack.Properties.Resources._3_of_clubs; }
            if (rank == '4' && suit == "club") { image = Blackjack.Properties.Resources._4_of_clubs; }
            if (rank == '5' && suit == "club") { image = Blackjack.Properties.Resources._5_of_clubs; }
            if (rank == '6' && suit == "club") { image = Blackjack.Properties.Resources._6_of_clubs; }
            if (rank == '7' && suit == "club") { image = Blackjack.Properties.Resources._7_of_clubs; }
            if (rank == '8' && suit == "club") { image = Blackjack.Properties.Resources._8_of_clubs; }
            if (rank == '9' && suit == "club") { image = Blackjack.Properties.Resources._9_of_clubs; }
            if (rank == 'j' && suit == "club") { image = Blackjack.Properties.Resources.jack_of_clubs; }
            if (rank == 'q' && suit == "club") { image = Blackjack.Properties.Resources.queen_of_clubs; }
            if (rank == 'k' && suit == "club") { image = Blackjack.Properties.Resources.king_of_clubs; }

        }

        //returns score
        public int get_Score(bool zreo)
        {
            if (zreo == false)
            {
                return score;
            }
            else
            {
                score = 0;
                return score;
            }
        }

        //returns rank
        public char get_Rank()
        {
            return rank;
        }

        //returns suit
        public string get_Suit()
        {
            return suit;
        }

        //changes ace score from 11 to 1
        public void change_Ace()
        {
           if(rank == 'a')
            {
                score = 1;
                rank = 'c';
            }
        }
    }
}
