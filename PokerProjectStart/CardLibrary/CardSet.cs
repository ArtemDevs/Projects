using System;

namespace CardLibrary
{
    public class CardSet
    {
        public SuperCard[] CardArray;

        Random rand = new Random();

        public CardSet()
        {
            CardArray = new SuperCard[52];

            int index = 0;

            for(int i = 0; i <= 4; i++)
            {
                for(int j = 2; j <= 14; j++)
                {
                    switch (i)
                    {
                        case 0:
                            CardArray[index] = new CardClub((Rank)(j));
                            break;
                        case 1:
                            CardArray[index] = new CardDiamond((Rank)(j));
                            break;
                        case 2:
                            CardArray[index] = new CardHeart((Rank)(j));
                            break;
                        case 3:
                            CardArray[index] = new CardSpade((Rank)(j));
                            break;
                    }
                    index++;
                }
            }
        }

        public SuperCard[] GetCards(int pnumber)
        {
            SuperCard[] newHand = new SuperCard[pnumber];

            for(int i = 0; i <= pnumber-1; i++)
            {
                newHand[i] = CardArray[rand.Next(0, 52)];

                while (newHand[i].Inplay)
                {
                    newHand[i] = CardArray[rand.Next(0, 52)];
                }

                newHand[i].Inplay = true;
            }
            return newHand;
        }

        public SuperCard GetOneCard(int selectedCard)
        {

            SuperCard newCard = CardArray[rand.Next(0, 52)];

            while (newCard.Inplay)
            {
                newCard = CardArray[rand.Next(0, 52)];
            }

            newCard.Inplay = true;

            return newCard;
        }

        public void ResetUsage(SuperCard[] cardSet)
        {
            foreach(var card in cardSet)
            {
                card.Inplay = false;
            }
        }
    }
}
