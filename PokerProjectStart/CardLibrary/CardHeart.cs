using System;

namespace CardLibrary
{
    public class CardHeart : SuperCard
    {
        private Suit _cardSuit = Suit.Heart;

        public override Suit CardSuit
        {
            get => _cardSuit;
            set => _cardSuit = value;
        }

        public CardHeart(Rank rank)
        {
            CardRank = rank;
        }

        public override void Display()
        {
            // Code to Display a heart card...
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"♥ {CardRank, -5} of {_cardSuit, 0}s   ♥");
            Console.ResetColor();
        }
    }
}
