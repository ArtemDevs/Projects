using System;

namespace CardLibrary
{
    public class CardDiamond : SuperCard
    {
        private Suit _cardSuit = Suit.Diamond;

        public override Suit CardSuit
        {
            get => _cardSuit;
            set => _cardSuit = value;
        }

        public CardDiamond(Rank rank)
        {
            CardRank = rank;
        }

        public override void Display()
        {
            // Code to Display a diamond card...
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"♦ {CardRank, -5} of {_cardSuit, 0}s ♦");
            Console.ResetColor();
        }
    }
}
