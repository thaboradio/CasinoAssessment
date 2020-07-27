using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    class Program
    {
        public static Player Player = new Player();
        public static Player Dealer = new Player();
        public static ScoreBoard ScoreBoard = new ScoreBoard();
        static void Main(string[] args)
        {
            var Clubs = InitializeClubs();
            var Diamods = InitializeDiamonds();
            var Hearts = InitializeHearts();
            var Spades = InitializeSpades();

            List<Card> CardsOnDeck = new List<Card>();
            int cardsOnDeckCount = CardsOnDeck.Count;
            int input = -2;

            ScoreBoard PlayerData = new ScoreBoard();
            ScoreBoard DealerData = new ScoreBoard();

            List<Card> PlayerCards = new List<Card>();
            List<Card> DealerCards = new List<Card>();
            foreach (var item in Clubs)
            {
                CardsOnDeck.Add(item);
            }
            foreach (var item in Diamods)
            {
                CardsOnDeck.Add(item);
            }
            foreach (var item in Hearts)
            {
                CardsOnDeck.Add(item);
            }
            foreach (var item in Spades)
            {
                CardsOnDeck.Add(item);
            }

         
            GamePlay(CardsOnDeck, ref input, ref PlayerData, ref DealerData, PlayerCards, DealerCards);

            if (DealerData.DealerScore > 21)
            {
                Console.WriteLine("Dealer Score: " + DealerData.DealerScore);
                Console.WriteLine("Player Score: " + PlayerData.PlayerScore);
                Console.WriteLine();
                Console.WriteLine("Player Won");
                Console.WriteLine("Play Again");

            }
            else if (DealerData.DealerScore < 21 && (DealerData.DealerScore > PlayerData.PlayerScore))
            {
                Console.WriteLine("Dealer Score: " + DealerData.DealerScore);
                Console.WriteLine("Player Score: " + PlayerData.PlayerScore);
                Console.WriteLine();
                Console.WriteLine("Dealer Won");
            }
            else if (DealerData.DealerScore == PlayerData.PlayerScore)
            {
                Console.WriteLine("Dealer Score: " + DealerData.DealerScore);
                Console.WriteLine("Player Score: " + PlayerData.PlayerScore);
                Console.WriteLine();
                Console.WriteLine("Tie");
            }
            Console.ReadLine();
        }

        private static void GamePlay(List<Card> CardsOnDeck, ref int input, ref ScoreBoard PlayerData, ref ScoreBoard DealerData, List<Card> PlayerCards, List<Card> DealerCards)
        {
            ConsoleOptions();
            while (input != 0)
            {
                try
                {
                    Console.Write("Please Select Your Option: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input == -2 || input == -1 || input == 0 || input == 1)
                    {
                        if (input == 1)
                        {
                            var pc = DealCards(CardsOnDeck);
                            PlayerCards.Add(pc);
                            Player.PlayerNumber = 1;
                            Player.PlayerType = "Player";
                            Player.Cards = PlayerCards;
                            PlayerData = CalculatePlayerTotal(Player);

                            if (PlayerData.PlayerScore > 21)
                            {
                                input = 0;
                                Console.WriteLine("You Lost");
                            }
                        }
                        else if (input == -1 && PlayerData.PlayerScore < 21)
                        {
                            while (DealerData.DealerScore <= 17)
                            {
                                var dc = DealCards(CardsOnDeck);
                                input = -1;
                                DealerCards.Add(dc);
                                Dealer.PlayerNumber = 0;
                                Dealer.PlayerType = "Dealer";
                                Dealer.Cards = DealerCards;
                                DealerData = CalculatePlayerTotal(Dealer);
                            }
                            input = 0;
                        }
                        else if (input == -2)
                        {
                            Console.WriteLine("Press any key to close the application");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        ConsoleOptions();
                        Console.WriteLine("Please Enter a valid option");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

            }
        }

        /*Options to selects*/
        private static void ConsoleOptions()
        {
            Console.WriteLine("Player Selections");
            Console.WriteLine("===============================");
            Console.WriteLine(" 1." + "|" + "Deal Cards       |");
            Console.WriteLine("-1." + "|" + "Stop Dealing     |");
            Console.WriteLine("-2." + "|" + "Exit Application |");
            Console.WriteLine("===============================");
            Console.WriteLine("");
        }

        /*Deal Cards*/
        public static Card DealCards(List<Card> cards)
        {
            Random randomCard = new Random();
            var dealtCard = randomCard.Next(cards.Count);
            Card card = new Card();
            card = cards[dealtCard];
            RemoveCard(cards, card);
            return card;
        }

        public static ScoreBoard CalculatePlayerTotal(Player Player)
        {
            if (Player.PlayerType == "Player")
            {
                int totalPlayerCards = 0;
                foreach (var item in Player.Cards)
                {
                    totalPlayerCards += item.Value;
                }
                ScoreBoard.PlayerScore = totalPlayerCards;
            }
            else if (Player.PlayerType == "Dealer")
            {
                int totalDealerCards = 0;
                foreach (var item in Player.Cards)
                {
                    totalDealerCards += item.Value;
                }
                ScoreBoard.DealerScore = totalDealerCards;
            }
            return ScoreBoard;
        }


        /* Remove Dealt Card*/
        public static List<Card> RemoveCard(List<Card> cards, Card cardToRemove)
        {
            cards.Remove(cardToRemove);

            return cards;
        }

        /* Add Cards*/
        public static List<Card> InitializeClubs()
        {
            List<Card> cards = new List<Card>();
            Card card = new Card
            {
                Face = "Ace",
                Value = 1,
                Suit = Suit.Clubs
            };
            cards.Add(card);
            card = new Card
            {
                Face = "2",
                Value = 2,
                Suit = Suit.Clubs
            };
            cards.Add(card);
            card = new Card
            {
                Face = "3",
                Value = 3,
                Suit = Suit.Clubs
            };
            cards.Add(card);
            card = new Card
            {
                Face = "4",
                Value = 4,
                Suit = Suit.Clubs
            };
            cards.Add(card);
            card = new Card
            {
                Face = "5",
                Value = 5,
                Suit = Suit.Clubs
            };
            cards.Add(card);
            card = new Card
            {
                Face = "6",
                Value = 6,
                Suit = Suit.Clubs
            };
            cards.Add(card);
            card = new Card
            {
                Face = "7",
                Value = 7,
                Suit = Suit.Clubs
            };
            cards.Add(card);
            card = new Card
            {
                Face = "8",
                Value = 8,
                Suit = Suit.Clubs
            };
            cards.Add(card);
            card = new Card
            {
                Face = "9",
                Value = 9,
                Suit = Suit.Clubs
            };
            cards.Add(card);
            card = new Card
            {
                Face = "10",
                Value = 10,
                Suit = Suit.Clubs
            };
            cards.Add(card);
            card = new Card
            {
                Face = "J",
                Value = 10,
                Suit = Suit.Clubs
            };
            cards.Add(card);
            card = new Card
            {
                Face = "K",
                Value = 10,
                Suit = Suit.Clubs
            };
            cards.Add(card);
            card = new Card
            {
                Face = "Q",
                Value = 10,
                Suit = Suit.Clubs
            };
            cards.Add(card);
            return cards;
        }
        public static List<Card> InitializeSpades()
        {
            List<Card> cards = new List<Card>();
            Card card = new Card
            {
                Face = "Ace",
                Value = 1,
                Suit = Suit.Spades
            };
            cards.Add(card);
            card = new Card
            {
                Face = "2",
                Value = 2,
                Suit = Suit.Spades
            };
            cards.Add(card);
            card = new Card
            {
                Face = "3",
                Value = 3,
                Suit = Suit.Spades
            };
            cards.Add(card);
            card = new Card
            {
                Face = "4",
                Value = 4,
                Suit = Suit.Spades
            };
            cards.Add(card);
            card = new Card
            {
                Face = "5",
                Value = 5,
                Suit = Suit.Spades
            };
            cards.Add(card);
            card = new Card
            {
                Face = "6",
                Value = 6,
                Suit = Suit.Spades
            };
            cards.Add(card);
            card = new Card
            {
                Face = "7",
                Value = 7,
                Suit = Suit.Spades
            };
            cards.Add(card);
            card = new Card
            {
                Face = "8",
                Value = 8,
                Suit = Suit.Spades
            };
            cards.Add(card);
            card = new Card
            {
                Face = "9",
                Value = 9,
                Suit = Suit.Spades
            };
            cards.Add(card);
            card = new Card
            {
                Face = "10",
                Value = 10,
                Suit = Suit.Spades
            };
            cards.Add(card);
            card = new Card
            {
                Face = "J",
                Value = 10,
                Suit = Suit.Spades
            };
            cards.Add(card);
            card = new Card
            {
                Face = "K",
                Value = 10,
                Suit = Suit.Spades
            };
            cards.Add(card);
            card = new Card
            {
                Face = "Q",
                Value = 10,
                Suit = Suit.Spades
            };
            cards.Add(card);
            return cards;
        }
        public static List<Card> InitializeHearts()
        {
            List<Card> cards = new List<Card>();
            Card card = new Card
            {
                Face = "Ace",
                Value = 1,
                Suit = Suit.Hearts
            };
            cards.Add(card);
            card = new Card
            {
                Face = "2",
                Value = 2,
                Suit = Suit.Hearts
            };
            cards.Add(card);
            card = new Card
            {
                Face = "3",
                Value = 3,
                Suit = Suit.Hearts
            };
            cards.Add(card);
            card = new Card
            {
                Face = "4",
                Value = 4,
                Suit = Suit.Hearts
            };
            cards.Add(card);
            card = new Card
            {
                Face = "5",
                Value = 5,
                Suit = Suit.Hearts
            };
            cards.Add(card);
            card = new Card
            {
                Face = "6",
                Value = 6,
                Suit = Suit.Hearts
            };
            cards.Add(card);
            card = new Card
            {
                Face = "7",
                Value = 7,
                Suit = Suit.Hearts
            };
            cards.Add(card);
            card = new Card
            {
                Face = "8",
                Value = 8,
                Suit = Suit.Hearts
            };
            cards.Add(card);
            card = new Card
            {
                Face = "9",
                Value = 9,
                Suit = Suit.Hearts
            };
            cards.Add(card);
            card = new Card
            {
                Face = "10",
                Value = 10,
                Suit = Suit.Hearts
            };
            cards.Add(card);
            card = new Card
            {
                Face = "J",
                Value = 10,
                Suit = Suit.Hearts
            };
            cards.Add(card);
            card = new Card
            {
                Face = "K",
                Value = 10,
                Suit = Suit.Hearts
            };
            cards.Add(card);
            card = new Card
            {
                Face = "Q",
                Value = 10,
                Suit = Suit.Hearts
            };
            cards.Add(card);
            return cards;
        }
        public static List<Card> InitializeDiamonds()
        {
            List<Card> cards = new List<Card>();
            Card card = new Card
            {
                Face = "Ace",
                Value = 1,
                Suit = Suit.Diamonds
            };
            cards.Add(card);
            card = new Card
            {
                Face = "2",
                Value = 2,
                Suit = Suit.Diamonds
            };
            cards.Add(card);
            card = new Card
            {
                Face = "3",
                Value = 3,
                Suit = Suit.Diamonds
            };
            cards.Add(card);
            card = new Card
            {
                Face = "4",
                Value = 4,
                Suit = Suit.Diamonds
            };
            cards.Add(card);
            card = new Card
            {
                Face = "5",
                Value = 5,
                Suit = Suit.Diamonds
            };
            cards.Add(card);
            card = new Card
            {
                Face = "6",
                Value = 6,
                Suit = Suit.Diamonds
            };
            cards.Add(card);
            card = new Card
            {
                Face = "7",
                Value = 7,
                Suit = Suit.Diamonds
            };
            cards.Add(card);
            card = new Card
            {
                Face = "8",
                Value = 8,
                Suit = Suit.Diamonds
            };
            cards.Add(card);
            card = new Card
            {
                Face = "9",
                Value = 9,
                Suit = Suit.Diamonds
            };
            cards.Add(card);
            card = new Card
            {
                Face = "10",
                Value = 10,
                Suit = Suit.Diamonds
            };
            cards.Add(card);
            card = new Card
            {
                Face = "J",
                Value = 10,
                Suit = Suit.Diamonds
            };
            cards.Add(card);
            card = new Card
            {
                Face = "K",
                Value = 10,
                Suit = Suit.Diamonds
            };
            cards.Add(card);
            card = new Card
            {
                Face = "Q",
                Value = 10,
                Suit = Suit.Diamonds
            };
            cards.Add(card);
            return cards;
        }

    }

    /*Hold Scores */
    public class ScoreBoard
    {
        public int PlayerScore { get; set; }
        public int DealerScore { get; set; }
    }
}
