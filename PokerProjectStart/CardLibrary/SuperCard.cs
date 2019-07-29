using System;

namespace CardLibrary
{
    public enum Suit
    {
        Club = 1,
        Diamond,
        Heart,
        Spade
    }

    public enum Rank
    {
        Deuce = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    public abstract class SuperCard : IComparable<SuperCard> , IEquatable<SuperCard>
    {
        public Rank CardRank { get; set; }

        public abstract Suit CardSuit { get; set; }

        public bool Inplay { get; set; }

        public abstract void Display();

        public int CompareTo(SuperCard other)
        {
            if (CardSuit < other.CardSuit) return -1;                                // checks if the suit is lower, and follows if so
            if (CardSuit > other.CardSuit) return 1;                                 // checks if the suit is higher, and precedes if so
            if (CardSuit == other.CardSuit && CardRank >= other.CardRank) return -1; // checks if the suit is the same, and if the rank is lowew, and follows if so
            return 1;                                                                // final case is if suit is the same and the rank is higher, than precede
        }

        public bool Equals(SuperCard other)
        {
            if (CardSuit == other?.CardSuit) return true;
            return false;
        }
    }
}
