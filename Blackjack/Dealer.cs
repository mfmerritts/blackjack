using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Dealer : Person
    {
        public Dealer(string name, int num) : base(name, num)
        {
            Name = name;
            ID = num;
            players_Turn = false;
            hand = new List<Card>();
        }

        public void auto_Deal(BlackjackTable bjt) 
        {
            //Makes sure it is the dealers turn so all players have final hand
            if(this.get_Turn())
            {
                //deals two cards to dealer, this should actually happen before players begin thier turns
               // bjt.deal_Card_To_Person(5);
                //bjt.deal_Card_To_Person(5); //The card dealt below needs to be the face down card

                //Enters loops if dealer has less than 17
                while (sum_Hand(true) < 17)
                {
                    bjt.deal_Card_To_Person(5); //deals a card to the dealer
                    Console.WriteLine("dealer's new hand:\n");
                    this.print_Hand();
                    Console.WriteLine("dealer's total is: " + this.sum_Hand(true) + "\n");

                    //if dealer has over 21, it will change the value of any aces to less than 21
                    if (sum_Hand(true) > 21)
                    {
                        for (int i = 0; i < hand.Count(); i++)
                        {
                            if (hand[i].get_Rank() == 'a' && sum_Hand(true) > 21)
                            {
                                hand[i].change_Ace();
                                //The logic here is that it will find the first ace in the hand and change its value to 1
                                //It will continue to look for more aces if sum is still grerater than 21
                                //If less than 21 it will go back to checking if the value is 17 or more
                                //17 or higher will end the dealers turn
                                //Anything else will be a bust and also end the dealers turn
                            }
                        }
                    }
                }                
            }
        }
    }
}
