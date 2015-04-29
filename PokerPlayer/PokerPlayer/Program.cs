using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlayer
{
    class Program
    {

        static void Main(string[] args)
        {
            Deck currentDeck = new Deck();
            currentDeck.Shuffle();
            while (true)
            {
                PokerPlayer player1 = new PokerPlayer();
                player1.DrawHand(currentDeck.Deal5Cards());
                PokerPlayer player2 = new PokerPlayer();
                player2.DrawHand(currentDeck.Deal5Cards());
                
                if (player1.CompareTo(player2) < 0)
                {
                    Console.WriteLine("Player 1 Won with a {0}!", player1.HandRank);

                }
                else
                {
                    Console.WriteLine("Player 2 Won with a {0}!", player2.HandRank);
                }
                Console.Write("Player 1:");
                player1.ShowHand();
                Console.WriteLine();
                Console.Write("Player 2:");
                player2.ShowHand();
                Console.WriteLine();
                currentDeck.Discard(player1.Hand);
                currentDeck.Discard(player2.Hand);
                Console.ReadKey();
                Console.Clear();
            }

            //int count = 0;
            //while (true)
            //{
            //    count++;
            //    PokerPlayer player1 = new PokerPlayer();
            //    player1.DrawHand(currentDeck.Deal5Cards());
            //    if (player1.HandRank == PokerPlayer.HandType.RoyalFlush)
            //    {
            //        Console.Write("Player 1:");
            //        player1.ShowHand();
            //        Console.WriteLine();
            //        Console.WriteLine("Count: {0}", count);
            //        Console.ReadKey();
            //        count = 0;
            //        Console.Clear();
            //    }
            //    currentDeck.Discard(player1.Hand);
               
            //}
            
            
        }
    }
    class PokerPlayer : IComparable<PokerPlayer>
    {
        public List<Card> Hand { get; set; }
        public enum HandType
        {
            HighCard, OnePair, TwoPair, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush, RoyalFlush
        }
        public HandType HandRank
        {
            get
            {
                if (HasRoyalFlush()) { return HandType.RoyalFlush; }
                if (HasStraightFlush()) { return HandType.StraightFlush; }
                if (HasFourOfAKind()) { return HandType.FourOfAKind; }
                if (HasFullHouse()) { return HandType.FullHouse; }
                if (HasFlush()) { return HandType.Flush; }
                if (HasStraight()) { return HandType.Straight; }
                if (HasThreeOfAKind()) { return HandType.ThreeOfAKind; }
                if (HasTwoPair()) { return HandType.TwoPair; }
                if (HasPair()) { return HandType.OnePair; }
                return HandType.HighCard;
            }
        }

        public PokerPlayer() { }
        public void DrawHand(List<Card> cards)
        {
            this.Hand = cards;
        }
        public void ShowHand()
        {
            if (this.HandRank > HandType.TwoPair)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            switch (this.HandRank)
            {
                case HandType.HighCard: Console.WriteLine("You have a highcard");
                    break;
                case HandType.OnePair: Console.WriteLine("You have one pair");
                    break;
                case HandType.TwoPair: Console.WriteLine("You have two pair");
                    break;
                case HandType.ThreeOfAKind: Console.WriteLine("You have three of a kind");
                    break;
                case HandType.Straight: Console.WriteLine("You have a straight");
                    break;
                case HandType.Flush: Console.WriteLine("You have a Flush");
                    break;
                case HandType.FullHouse: Console.WriteLine("You have a Full House");
                    break;
                case HandType.FourOfAKind: Console.WriteLine("You have Four of a Kind");
                    break;
                case HandType.StraightFlush: Console.WriteLine("You have a straight flush");
                    break;
                case HandType.RoyalFlush: Console.WriteLine("You have a Royal Flush");
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            // Print out each card in a hand
            foreach (Card aCard in Hand.OrderByDescending(x=> x.Rank))
            {
                Console.WriteLine(string.Join(" ", aCard.ToString()));
            }
        }
        /// <summary>
        /// A function to look for a certain number of cards with the same rank
        /// </summary>
        /// <param name="numberOfCards">certain number of cards needed exactly</param>
        /// <returns>true if the exact number is found</returns>
        private bool HasCertainNumOfCards(int numberOfCards)
        {
            return this.Hand.GroupBy(x => x.Rank).Where(grouping => grouping.Count() == numberOfCards).Any();
        }
        public bool HasPair()
        {
            // Only one pair exactly
            return this.Hand.GroupBy(x => x.Rank).Where(grouping => grouping.Count() == 2).Count() == 1;
        }
        public bool HasTwoPair()
        {
            return this.Hand.GroupBy(x => x.Rank).Where(grouping => grouping.Count() == 2).Count() == 2;
        }
        public bool HasThreeOfAKind()
        {
            return this.Hand.GroupBy(x => x.Rank).Any(grouping => grouping.Count() == 3);
        }
        public bool HasStraight()
        {
            // Make sure all of the cards are distinct
            if (!HasPair())
            {
                // Ace is used as the low card (has Ace and 2), check for straight
                if (this.Hand.OrderBy(x => x.Rank).Last().Rank == Rank.Ace)
                {
                    List<Card> tempHand = Hand.OrderBy(x => x.Rank).ToList();
                    // Remove the Ace
                    tempHand.RemoveAt(tempHand.Count - 1);
                    // Then check for the straight with 2,3,4,5
                    return (tempHand.OrderBy(x => x.Rank).Last().Rank - tempHand.OrderBy(x => x.Rank).First().Rank) == 3;
                }
                else
                {
                    // Check for normal straight
                    return (this.Hand.OrderBy(x => x.Rank).Last().Rank - this.Hand.OrderBy(x => x.Rank).First().Rank) == 4;
                }
            } // If there are any duplicate cards, then it can't be a straight
            else { return false; }
        }
        public bool HasFlush()
        {
            return this.Hand.GroupBy(x => x.Suit).Count() == 1;
            //return this.Hand.Select(x => x.Suit).Distinct().Count() == 1;
        }

        public bool HasFullHouse()
        {
            return HasThreeOfAKind() && HasPair();
        }
        public bool HasFourOfAKind()
        {
            return this.Hand.GroupBy(x => x.Rank).Where(grouping => grouping.Count() == 4).Count() == 1 &&
                this.Hand.GroupBy(x => x.Rank).OrderBy(x => x.Count()).Last().Select(x => x.Suit).Distinct().Count() == 4;
            //after the &&, we are selecting the cards in the 4 of a kind, and then ensuring that they have different suits.
        }
        public bool HasStraightFlush()
        {
            return HasStraight() && HasFlush();
        }
        public bool HasRoyalFlush()
        {
            // Check that there is a Ten and an Ace
            if ((this.Hand.Where(x => x.Rank == Rank.Ten).Count() == 1) && (this.Hand.Where(x => x.Rank == Rank.Ace).Count() == 1))
            {
                return HasStraightFlush();
            } // if those cards aren't in the hand it can't be a royal flush
            else { return false; }
        }

        //highest card
        public Card HighCard
        {
            get { return this.Hand.OrderByDescending(x => x.Rank).First(); }
        }

        public Rank HighestPairRank
        {
            get
            {
                //group the cards by rank, order them by the highest number of cards in a group (1 pair, 3 of a kind, 4 of a kind) and return the rank of that group
                var r = this.Hand.GroupBy(x => x.Rank).OrderByDescending(x => x.Count()).First().Key;
                return r;
            }
        }



        public int CompareTo(PokerPlayer other)
        {
            if (this.HandRank > other.HandRank)
            {
                return -1;
            }
            else if (this.HandRank < other.HandRank)
            {
                return 1;
            }
            else
            {
                switch (this.HandRank)
                {
                    case HandType.HighCard:
                    case HandType.Straight:
                    case HandType.Flush:
                    case HandType.StraightFlush:
                        if (this.HighCard.Rank > other.HighCard.Rank) return -1;
                        else if (this.HighCard.Rank < other.HighCard.Rank) return 1;
                        else return 0;
                    case HandType.OnePair:
                    case HandType.TwoPair:
                    case HandType.ThreeOfAKind:
                    case HandType.FourOfAKind:
                    case HandType.FullHouse:
                        //compare the highest pair
                        //return this.HighestPairRank.CompareTo(other.HighestPairRank);
                        if (this.HighestPairRank > other.HighestPairRank) return -1;
                        else if (this.HighestPairRank < other.HighestPairRank) return 1;
                        else return 0;
                    case HandType.RoyalFlush:
                        return this.Hand.First().Suit.CompareTo(other.Hand.First().Suit);
                    default:
                        break;
                }
                return 0;
            }
        }
    }
    /// <summary>
    /// A class that holds Cards and features a few helper methods
    /// </summary>
    class Deck
    {
        private List<Card> unusedCards = new List<Card>();
        private List<Card> dealtCards = new List<Card>();
        private Random rng = new Random();

        /// <summary>
        /// Constructor that initializes the deck of cards
        /// </summary>
        public Deck()
        {
            // Fill the unusedCards with a set of cards

            // Suits first
            for (int i = 0; i < 4; i++)
            {
                // Cards, which start with 2 and go till Ace (14)
                for (int j = 2; j < 15; j++)
                {
                    // Add this new card to the deck
                    unusedCards.Add(new Card(j, i));
                }
            }
        }
        /// <summary>
        /// Returns a list of 5 cards to make up a hand for the PokerPlayer
        /// </summary>
        /// <returns>list of 5 cards</returns>
        public List<Card> Deal5Cards()
        {
            // Return 5 cards to the PokerPlayer
            List<Card> tempHand = new List<Card>();
            for (int i = 0; i < 5; i++)
            {
                tempHand.Add(this.Deal(5));
            }
            return tempHand;
        }
        /// <summary>
        /// Picks a random card then removes it from the unused list and adds it to the dealt list
        /// </summary>
        /// <returns>the random card to a player/hand</returns>
        public Card Deal(int numberOfCards)
        {
            if (numberOfCards > this.unusedCards.Count)
            {
                this.Shuffle();
            }
            // Get a random card from the unused deck
            int randomIndex = rng.Next(GetNumOfCards());
            Card tempCard = unusedCards.ElementAt(randomIndex);
            
            // Remove card from the unused deck
            unusedCards.RemoveAt(randomIndex);

            // Return that card to the player/hand
            return tempCard;
        }

        public void Discard(List<Card> discardCards)
        {
            this.dealtCards.AddRange(discardCards);
        }

        /// <summary>
        /// Uses in list shuffling to reorder the existing cards
        /// </summary>
        public void Shuffle()
        {
            this.unusedCards.AddRange(this.dealtCards);
            this.dealtCards.Clear();
            // When there is more then 1 card to shuffle
            if (unusedCards.Count > 1)
            {
                // Go through each index of the list
                for (int i = unusedCards.Count - 1; i >= 0; i--)
                {
                    // Pick a random card to swap with this index
                    Card tmp = unusedCards[i];
                    int randomIndex = rng.Next(i + 1);

                    //Swap elements
                    unusedCards[i] = unusedCards[randomIndex];
                    unusedCards[randomIndex] = tmp;
                }
            }
        }
        /// <summary>
        /// Returns the number of unused cards in the deck
        /// </summary>
        /// <returns>number of unused cards in the deck</returns>
        public int GetNumOfCards()
        {
            return unusedCards.Count();
        }
    }

    public enum Rank
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
    public enum Suit
    {
        Spade, Diamond, Heart, Club
    }
    class Card
    {

        public Rank Rank { get; set; }
        public Suit Suit { get; set; }
        /// <summary>
        /// Constructor creates a card with a certain Rank and Suit
        /// </summary>
        /// <param name="myRank">Rank based on enum value</param>
        /// <param name="mySuit">Suit based on enum value</param>
        public Card(int myRank, int mySuit)
        {
            this.Rank = (Rank)myRank;
            this.Suit = (Suit)mySuit;
        }
        /// <summary>
        /// Override the ToString()
        /// </summary>
        /// <returns>Card rank of it's suit</returns>
        override public string ToString()
        {
            return this.Rank + " of " + this.Suit.ToString();
        }
    }
    public enum Priority 
    {
        Critical = 1,
        NotSoCritical,
        Whatever,
        YouCanTotallyBlowThisOff
    }
}
