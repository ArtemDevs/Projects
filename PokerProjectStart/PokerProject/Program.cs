using CardLibrary;
using System;
using System.Threading;
using System.Linq;
using static System.Console;
using SuperCard = CardLibrary.SuperCard;

namespace PokerProject
{
    class Program
    {
        static void Main()
        {
            // Create an instance of your CardSet class, and name it myDeck.
            CardSet myDeck = new CardSet();

            // Amount of cards in a hand and starting money
            int howManyCards    = 2;
            int balance         = 10;
            
            while (balance != 0)
            {
                // Set screen output to be some color set
                ForegroundColor = ConsoleColor.Yellow;

                WriteLine("WELCOME TO BASIC POKER!!\nRULES:\n\t- you have $10\n\t- each turn is a $1 bet");
                WriteLine($"BALANCE:\t{balance}");

                // create the two hands for each player
                SuperCard[] computerHand    = myDeck.GetCards(howManyCards);
                SuperCard[] playerHand      = myDeck.GetCards(howManyCards);

                // shuffle the cards in the deck
                myDeck.ResetUsage(computerHand);
                myDeck.ResetUsage(playerHand);

                // sort the hands by suit and rank
                Array.Sort(computerHand);
                Array.Sort(playerHand);

                // display the two hands visually
                DisplayHands(computerHand, playerHand);

                // let the player choose to mulligan a card
                PlayerMulliganCard(playerHand, myDeck);

                // let the computer choose to mulligan a card
                ComputerMulliganCard(computerHand, myDeck);

                // sort the hands by suit and rank AGAIN
                Array.Sort(computerHand);
                Array.Sort(playerHand);

                // display the two hands visually AGAIN
                DisplayHands(computerHand, playerHand);

                // compare the two hands and distribute winnings
                bool won = CompareHands(computerHand, playerHand);
                balance = won ? balance + 1 : balance - 1;

                // display the current balance and prompt next game
                
                WriteLine("Press 'Enter' to continue...");
                ReadLine();
                Clear();
            }
            WriteLine("\nGuess you lost!");

            // end of program
            ReadLine();
        }

        private static bool Flush(SuperCard[] computerHand)
        {
            SuperCard previousCard = null;

            foreach (SuperCard card in computerHand)
            {
                if (previousCard == null) previousCard = card;
                if (!card.Equals(previousCard)) return false;
                previousCard = card;
            }

            return true;
        }

        private static void ComputerMulliganCard(SuperCard[] computerHand, CardSet myDeck)
        {
            if(!Flush(computerHand)){
                int index = 0;
                int count = 0;
                
                SuperCard currentLowestCard = new CardClub(Rank.Ace);

                foreach (SuperCard card in computerHand)
                {
                    if ((int) card.CardRank < 8 && (int) card.CardRank < (int) currentLowestCard.CardRank)
                    {
                        index = count;
                    }

                    count++;
                }

                computerHand[index] = myDeck.GetOneCard(index);
            }
        }

        private static void PlayerMulliganCard(SuperCard[] playerHand, CardSet myDeck)
        {  
            WriteLine($"\nWhich card out of {playerHand.Length} cards would you like to mulligan?");
            Write("Press 'Enter' or 0 if none: ");

            string input = ReadLine();
            Int32.TryParse(input, out int cardNumber);

            if (cardNumber != 0)
            {
                playerHand[cardNumber - 1] = myDeck.GetOneCard(cardNumber);
            }
        }

        private static bool CompareHands(SuperCard[] computerHand, SuperCard[] playerHand)
        {
            int computerSum   = 0;
            int playerSum     = 0;

            foreach (var nw in computerHand.Zip(playerHand, Tuple.Create))               
            {                                                                             
                computerSum   += (int)nw.Item1.CardRank;                                    
                playerSum     += (int)nw.Item2.CardRank;
            }

            if (Flush(computerHand) && Flush(playerHand))
            {
                WriteLine("Both players got a flush!! (you still lose though...)");
                return false;
            }
            if (Flush(playerHand))
            {
                WriteLine("You got a flush!!");
                return true;
            }
            if (Flush(computerHand))
            {
                WriteLine("The computer got a flush!!");
                return false;
            }
            return computerSum < playerSum;
        }

        private static void DisplayHands(SuperCard[] computerHand, SuperCard[] playerHand)
        {
            ResetColor();

            Write("\nCOMPUTERS HAND\t\t\t\t PLAYERS HAND\n");
            foreach (var nw in computerHand.Zip(playerHand, Tuple.Create))
            {
                nw.Item1.Display();
                Write("\t  |\t");
                nw.Item2.Display();
                Thread.Sleep(100);
                WriteLine();
            }

            ForegroundColor = ConsoleColor.Yellow;
        }
    }
}
