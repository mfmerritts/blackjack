using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack
{
    public class BlackjackTable
    {
        public int game_Id;
        public int round_Count;
        public List<Card> deck;
        public Player[] table;
        public Dealer dealer;
        public int min_Bet;
        public Form test;

        public BlackjackTable()
        {
            game_Id = 666;
            round_Count = 0;
            deck = new List<Card>();
            table = new Player[5];
            dealer = new Dealer("Dealer", 888);
            min_Bet = 1;
            test = new Form();
        }

        public void create_Deck(int x)
        {
            //int[] scores = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            char[] ranks = { 'a', '2', '3', '4', '5', '6', '7', '8', '9', '1', 'j', 'q', 'k' };
            string[] suits = { "heart", "diamond", "club", "spade" };

            //The first loops is iterated x times, the number of 52 decks to be in the shoe
            for (int j = 0; j < x; j++)
            {
                //The second loop is done four times, once for each suit
                for (int i = 0; i < 4; i++)
                {
                    //The last loop is for all 13 cards, ace thorugh king
                    for (int y = 0; y < 13; y++)
                    {
                        Card card_To_Add = new Card(ranks[y], suits[i]);
                        deck.Add(card_To_Add);
                    }
                }
            }
        }

        //Loops through the deck and prints out each card
        public void print_Deck()
        {
            for (int x = 0; x < deck.Count(); x++)
            {
                Console.WriteLine(deck[x].get_Rank() + ":" + deck[x].get_Suit());
            }
        }

        //Adds player to table
        public void add_Player(Player player)
        {
            Boolean found = false;

            //loops through the table for the first open spot
            for(int i = 0; i < 5; i++)
            {
                if (table[i] == null && found == false) // Spot found and inserts player into table at the current iterration
                {
                    table[i] = player;
                    found = true;                   
                }
            }

            //Once the search for open spot is done, if a spot isn't found lets the user know the table is full
            if (found == false)
            {
                Console.WriteLine("Sorry " + player.get_Name() + ", this table is full.");
            }
        }

        public void remove_Player(Player player)
        {
            Boolean found_Player = false;
            //scans the table for a specific player
            for(int i = 0; i < 5; i++)
            {
                if (table[i] != null) //checks first is spot is not empty, if not then moves the next spot
                {
                    //here the player is found and removes player
                    if (table[i].get_Name() == player.get_Name())
                    {
                        table[i] = null;
                        found_Player = true;
                    }
                }                            
            }
            //Output is player is not found
            if (!found_Player) { Console.WriteLine(player.get_Name() + " was not found in the table."); }
        }

        public void print_Table()
        {
            for(int i = 0; i < table.Count(); i++)
            {
                if (table[i] != null)
                {
                    Console.WriteLine(table[i].get_Name() + " is sitting at seat " + (i + 1));
                }
                
                if(table[i] == null)
                {
                    Console.WriteLine("empty");
                }                
            }
        }

        //Uses Fisher-Yeates Alogrithm to shuffle deck
        public void shuffle_Deck()
        {
            Random rng = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }

        //Deals a card to person in table[x]
        public void deal_Card_To_Person(int x)
        {
            //The dealer always sits in table[5], so this case handles dealing cards to the dealer
            if (x == 5)
            {
                if (deck.Count() > 0)
                {
                    Card tmp = deck[deck.Count() - 1];
                    dealer.hand.Add(tmp);
                    deck.RemoveAt(deck.Count() - 1);
                }
            }
            else if (x < 5 && x >= 0) // case where player is dealt cards
            {
                if (deck.Count() > 0 && table[x] != null)
                {
                    Card tmp = deck[deck.Count() - 1];
                    table[x].hand.Add(tmp);
                    deck.RemoveAt(deck.Count() - 1);
                }
            }
            else// case where a number not within the table is entered
            {
                Console.WriteLine("Invalid arguments for function deal_Card_To_Player");
            }
        }

        //returns round count
        public int get_Round_Count()
        {
            return round_Count;
        }

        //increment round count
        public void increment_Count()
        {
            round_Count++;
        }

        //set round count to zero
        public void reset_Count()
        {
            round_Count = 0;
        }

        //returns game id
        public int get_Game_Id()
        {
            return game_Id;
        }

        //sets game id
        public void set_Game_Id(int x)
        {
            game_Id = x;
        }

        //This function begins the round. Once it begins it continues until everyone is dealt cards and is content with their hand.
        //It handles splits, doubling down, pays automatic winners(blackjacks), surrenders and player busts.
        //This function does not handle the final check where players are tested against the dealer
        public void start_Round()
        {
            increment_Count();

            for(int i = 0; i < table.Count(); i++)
            {
                if (table[i] != null)
                {
                    if (table[i].get_Bet() >= min_Bet) // this is for testing purpose only. Min bet will be changed in final version
                    {
                        //Sets player to active, deals cards and prints the intial hand.
                        table[i].activate();
                        deal_Card_To_Person(i);
                        deal_Card_To_Person(i);
                        table[i].print_Hand();
                        Console.WriteLine("total is " + table[i].sum_Hand(true));

                        //if player has blackjack award money and deactivate
                        Boolean has_blackjack = false;
                        if(table[i].sum_Hand(true) == 21)
                        {
                            MessageBox.Show("Congrats you have a Blackjack!");
                            Console.WriteLine("Congrats " + table[i].get_Name() + ", you have a blackjack.");
                            table[i].give_Money(Convert.ToInt32(table[i].get_Bet() * 2.5));
                            table[i].deactivate();
                            has_blackjack = true;
                        }

                        //Asks the player if they wish to surrender
                        string ans1;
                        Boolean surrendered = false;

                        if (!has_blackjack)
                        {
                            Console.WriteLine("Would you like to surrender?");
                            ans1 = Console.ReadLine();

                            switch (ans1)
                            {
                                case "yes":
                                    table[i].deactivate();
                                    table[i].give_Money(table[i].get_Bet() / 2);
                                    surrendered = true;
                                    break;
                                case "no":
                                    break;
                            }
                        }                                  

                        //Continues here if player did not surrender
                        if (!surrendered && !has_blackjack)
                        {

                            //Asks player if they want to split hand
                            Boolean has_split = false;
                            if (table[i].hand[0].get_Rank() == table[i].hand[1].get_Rank())
                            {                                
                                Console.WriteLine("Would you like to split");
                                string ans3 = Console.ReadLine();
                                if(ans3 == "yes")
                                {
                                    has_split = true;
                                    table[i].check_Split_Hand();
                                    table[i].deal_To_Split(this);
                                    this.deal_Card_To_Person(i);
                                    Console.WriteLine("New Hand:");
                                    table[i].print_Hand();
                                    Console.WriteLine("total is " + table[i].sum_Hand(true));
                                    Console.WriteLine("Split Hand:");
                                    table[i].print_Split_Hand();
                                    Console.WriteLine("total is " + table[i].sum_Split());
                                    Console.WriteLine("The following questions are regaurding the main hand:");
                                }
                            }

                            //Asks player to double down
                            string ans2;
                            Console.WriteLine("Would you like to doubledown?");
                            ans2 = Console.ReadLine();

                            switch (ans2)
                            {
                                case "yes":
                                    table[i].double_Down();                                    
                                    break;
                                case "no":
                                    break;
                            }

                            //Here is where the player can choose to hit or stay
                            Console.WriteLine("Ok " + table[i].get_Name() + ", what would you like to do?(hit or stay)");
                            string ans;
                            Boolean finish_Turn = false;

                            while (!finish_Turn)
                            {
                                ans = Console.ReadLine();
                                Console.WriteLine(table[i].get_Name() + " has entered " + ans);

                                switch (ans)
                                {
                                    case "hit":
                                        deal_Card_To_Person(i);
                                        if (table[i].sum_Hand(true) > 21)
                                        {
                                            for (int y = 0; y < table[i].hand.Count(); y++)
                                            {
                                                if (table[i].hand[y].get_Rank() == 'a' && table[i].sum_Hand(true) > 21)
                                                {
                                                    table[i].hand[y].change_Ace();
                                                }
                                            }
                                        }
                                        if (table[i].sum_Hand(true) > 21)
                                        {
                                            finish_Turn = true;
                                            table[i].deactivate();
                                            Console.WriteLine("Sorry " + table[i].get_Name() + ", you have bust");
                                        }
                                        table[i].print_Hand();
                                        Console.WriteLine("total is " + table[i].sum_Hand(true));
                                        break;
                                    case "stay":
                                        finish_Turn = true;
                                        break;
                                    default:
                                        Console.WriteLine("Please try again");
                                        break;
                                }
                            }

                            //Here is where the player makes choices for split hand
                            //Asks player to double down
                            if (has_split)
                            {
                                string ans4;
                                Console.WriteLine("Would you like to doubledown the split hand?");
                                ans4 = Console.ReadLine();

                                switch (ans4)
                                {
                                    case "yes":
                                        table[i].double_Down_Split();
                                        break;
                                    case "no":
                                        break;
                                }

                                //Here is where the player can choose to hit or stay
                                Console.WriteLine("Ok " + table[i].get_Name() + ", what would you like to do with split hand?(hit or stay)");
                                string ans5;
                                Boolean finish_Turn_Split = false;
                                while (!finish_Turn_Split)
                                {
                                    ans5 = Console.ReadLine();
                                    Console.WriteLine(table[i].get_Name() + " has entered " + ans5);

                                    switch (ans5)
                                    {
                                        case "hit":
                                            table[i].deal_To_Split(this);
                                            if (table[i].sum_Split() > 21)
                                            {
                                                for (int y = 0; y < table[i].second_Hand.Count(); y++)
                                                {
                                                    if (table[i].second_Hand[y].get_Rank() == 'a' && table[i].sum_Split() > 21)
                                                    {
                                                        table[i].second_Hand[y].change_Ace();
                                                    }
                                                }
                                            }
                                            if (table[i].sum_Split() > 21)
                                            {
                                                finish_Turn_Split = true;
                                                table[i].deactivate_Split();
                                                Console.WriteLine("Sorry " + table[i].get_Name() + ", your split had has bust");
                                            }
                                            table[i].print_Split_Hand();
                                            Console.WriteLine("total is " + table[i].sum_Split());
                                            break;
                                        case "stay":
                                            finish_Turn_Split = true;
                                            break;
                                        default:
                                            Console.WriteLine("Please try again");
                                            break;
                                    }
                                }
                            }
                            //end of split hand
                        }                       
                    }
                    else
                    {
                        Console.WriteLine("Sorry " + table[i].get_Name() + ", you have not put up a large enough bet.");
                    }
                }
            }

            this.dealer.start_Turn(); // sets dealers turn to ture since all players have finshed thier turns.
        }

        //this is the funciton that takes all players who did not get blackjack, bust or surrender and checks thier hands 
        //to see if they won, lost or tied against the dealers hand
        public void check_Players_Vs_Dealer()
        {
            for(int i = 0; i < table.Count(); i++)
            {
                if (table[i] != null)
                {
                    if (table[i].get_Active() == true)
                    {        
                        //check the players hand vs dealer                
                        if (table[i].sum_Hand(true) > dealer.sum_Hand(true) || dealer.sum_Hand(true) > 21)
                        {
                            MessageBox.Show(table[i].get_Name() + " has won!");
                            table[i].give_Money(table[i].get_Bet() * 2);
                        }
                        else if (table[i].sum_Hand(true) < dealer.sum_Hand(true))
                        {
                            MessageBox.Show(table[i].get_Name() + " has lost!");
                        }
                        else
                        {
                            MessageBox.Show(table[i].get_Name() + " tied with dealer");
                            table[i].give_Money(table[i].get_Bet());
                        }
                    }

                    //checks each players split hand against the dealer
                    if (table[i].get_Active_Split() == true)
                    {
                        if (table[i].sum_Split() > dealer.sum_Hand(true) || dealer.sum_Hand(true) > 21)
                        {
                            MessageBox.Show(table[i].get_Name() + "'s split hand has won!");
                            table[i].give_Money(table[i].get_Split_Bet() * 2);
                        }
                        else if (table[i].sum_Split() < dealer.sum_Hand(true))
                        {
                            MessageBox.Show(table[i].get_Name() + "'s split hand has lost!");
                        }
                        else
                        {
                            MessageBox.Show(table[i].get_Name() + "'s split tied with dealer");
                            table[i].give_Money(table[i].get_Split_Bet());
                        }
                    }
                }
            }
        }

        //cleans up the table by removing all cards used by the players and dealer, sets all bets to zero and deactivates all players.
        public void clean_Up()
        {
            //loops through all players at table and cleans up hands, split hands, deactivates and sets bets to zero
            for(int i = 0; i < table.Count(); i++)
            {
                if(table[i] != null)
                {
                    table[i].take_Cards();
                    table[i].take_Split_Cards();
                    table[i].set_Bet(0);
                    table[i].set_Split_Bet(0);
                    table[i].deactivate();
                    table[i].deactivate_Split();                   
                }
            }

            //checks round count. If round count is 5 or more the deck is reset
            if (round_Count >= 5)
            {
                deck.Clear();
                this.create_Deck(1);
                this.shuffle_Deck();
            }

            //ends dealers turn
            dealer.end_Turn();
        }

        public void test_Round()
        {
            if (table[0].get_Bet() > min_Bet)
            {
                
                //deals one card to person
                deal_Card_To_Person(0);

                //deals one card faceup to dealer
                deal_Card_To_Person(5);

                //deals second card to person
                deal_Card_To_Person(0);

                //deals second card facedown to dealer
                deal_Card_To_Person(5);

                //output player's hand
                Console.WriteLine("This is Player's opending hand:\n");
                table[0].print_Hand();

                //output dealer's hand
                Console.WriteLine("\nThis is the dealers opening hand:\n");
                dealer.print_Hand(); 
            }
        }
    }
}
