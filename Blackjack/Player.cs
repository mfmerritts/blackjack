using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack
{
    public class Player : Person
    {
        public int money;
        public int bet;
        public int tempBet;
        public int split_bet;
        public Boolean active;
        public Boolean active_split;
        public List<Card> second_Hand;

        public Player (string name, int id) : base(name, id)
        {
            money = 1000;
            active = false;
            active_split = false;
            second_Hand = new List<Card>();
            bet = 0;
            tempBet = 0;
            split_bet = 0;
        }

        //returns money
        public int get_Money()
        {
            return money;
        }

        //addd to player's money
        public void give_Money(int more)
        {
            money += more;
            MessageBox.Show(this.get_Name() + " was given " + more + " dollars and now has " + this.get_Money());
        }

        //takes money from player. This function may not be used and could possibly be removed.
        public void take_Money(int take)
        {
            if (take > money)
            {
                Console.WriteLine(this.get_Name() + " does not have " + take + " dollars");
            }
            else
            {
                money -= take;
                Console.WriteLine(this.get_Name() + " lost " + take + " dollars and now has " + this.get_Money());
            }
        }

        //returns active
        public Boolean get_Active()
        {
            return active;
        }

        //returns active split
        public Boolean get_Active_Split()
        {
            return active_split;
        }

        //activates player main hand
        public void activate()
        {
            active = true;
        }

        //activates player split hand
        public void activate_Split()
        {
            active_split = true;
        }

        //deactivates player's main hand
        public void deactivate()
        {
            active = false;
        }

        //deactivates player's split hand
        public void deactivate_Split()
        {
            active_split = false;
        }

        //check for split will ensure the player has the money and correct cards to split.
        //If so adds one of the cards from main hand to second hand
        //At the end of the function the player will still need to be dealt a card to main hand and a card to split
        public void check_Split_Hand()
        {
            //checks to see if the player has cards
            if (this.hand.Count() > 0)
            {
                //makes sure player has enough money
                if(this.get_Bet() > money)
                {
                    Console.WriteLine("Sorry " + this.get_Name() + ", you do not have enough money to split.");
                    return;
                }
                else if (hand[0].get_Rank() == hand[1].get_Rank()) //This is where the player actually splits. Creates a new bet and activates split hand.
                {
                    second_Hand.Add(hand[1]);
                    hand.RemoveAt(1);
                    set_Split_Bet(bet);
                    this.activate_Split();
                }
                else
                {
                    Console.WriteLine("You cannot split this hand");
                }
            }
            else
            {
                Console.WriteLine(this.get_Name() + " does not have any cards to split");
            }
        }  
        
        public void set_tempBet(int x)
        {
            tempBet += x;
        }

        public int get_tempBet()
        {
            return tempBet;
        }

        public void reset_tempBet()
        {
            tempBet = 0;
        }
         
        //sets bet. This will take the amount form the money variable and put it into the bet variable             
        public void set_Bet(int x)
        {
            if (x > money)
            {
                Console.WriteLine(this.get_Name() + " does not have enough money to bet");
            }
            else
            {
                money = money - x;
                bet = x;
            }
        }

        //functions sames as set bet, but puts money into the split_bet variable.
        public void set_Split_Bet(int x)
        {
            if (x > money)
            {
                Console.WriteLine(this.get_Name() + " does not have enough money to bet");
            }
            else
            {
                money = money - x;
                split_bet = x;
            }
        }

        //checks to make sure player can double down, than it takes from money varible and doubles the bet amount
        public void double_Down()
        {
            if (bet <= money)
            {
                Console.WriteLine(this.get_Name() + " has doubled the bet from " + bet + " to " + (bet * 2));
                money = money - bet;
                bet = bet * 2;              
            }
            else
            {
                Console.WriteLine("Sorry " + this.get_Name() + ", you do not haven enough to doubledown.");
            }
        }

        //does the same as double down, but adds to the split_vet variable.
        public void double_Down_Split()
        {
            if (split_bet <= money)
            {
                Console.WriteLine(this.get_Name() + " has doubled the split bet from " + split_bet + " to " + (split_bet * 2));
                money = money - split_bet;
                split_bet = split_bet * 2;
            }
            else
            {
                Console.WriteLine("Sorry " + this.get_Name() + ", you do not haven enough to doubledown.");
            }
        }

        //returns bet
        public int get_Bet()
        {
            return bet;
        }

        //returns split bet
        public int get_Split_Bet()
        {
            return split_bet;
        }

        //takes card from deck and puts it into the player's second hand.
        public void deal_To_Split(BlackjackTable bjt)
        {
            if (bjt.deck.Count() > 0)
            {
                Card tmp = bjt.deck[bjt.deck.Count() - 1];
                this.second_Hand.Add(tmp);
                bjt.deck.RemoveAt(bjt.deck.Count() - 1);
            }
        }

        //outputs the players second hand to the console.
        public void print_Split_Hand()
        {
            if (this.second_Hand.Count() > 0)
            {
                for (int i = 0; i < this.second_Hand.Count(); i++)
                {
                    Console.WriteLine(second_Hand[i].get_Rank() + " : " + second_Hand[i].get_Suit());
                }
            }
            else
            {
                Console.WriteLine(this.get_Name() + " has no cards in split hand");
            }
        }

        //sum of scores for player's second hand.
        public int sum_Split()
        {
            int sum = 0;
            if(second_Hand.Count() > 0)
            {
                for(int i = 0; i < second_Hand.Count(); i++)
                {
                    sum = second_Hand[i].get_Score(false) + sum;
                }
            }
            return sum;
        }

        //removes careds from second hand
        public void take_Split_Cards()
        {
            //code to be done once hand class is made.
            second_Hand.Clear();
        }
    }
}
