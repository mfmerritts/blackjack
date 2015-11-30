using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3450
{
    public class Card
    {
        public int score;
        public char rank;
        public string suit;

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
        }

        //returns score
        public int get_Score()
        {
            return score;
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
