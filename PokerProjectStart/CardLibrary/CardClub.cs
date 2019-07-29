using System;

namespace CardLibrary
{
    public class CardClub : SuperCard
    {
        private Suit _cardSuit = Suit.Club;

        public override Suit CardSuit
        {
            get => _cardSuit;
            set => _cardSuit = value;
        }

        public CardClub(Rank rank)
        {
            CardRank = rank;
        }

        public override void Display()
        {
            // Code to Display a club card...
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"♣ {CardRank, -5} of {_cardSuit, 0}s    ♣");
            Console.ResetColor();
        }
    }
}
