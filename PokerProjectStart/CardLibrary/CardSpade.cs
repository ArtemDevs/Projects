using System;

namespace CardLibrary
{
    public class CardSpade : SuperCard
    {
        private Suit _cardSuit = Suit.Spade;

        public override Suit CardSuit
        {
            get => _cardSuit;
            set => _cardSuit = value;
        }

        public CardSpade(Rank rank)
        {
            CardRank = rank;
        }

        public override void Display()
        {
            // Code to Display a Spade card...
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"♠ {CardRank, -5} of {_cardSuit, 0}s   ♠");
            Console.ResetColor();
        }
    }
}
