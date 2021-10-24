using System;
using System.Collections.Generic;

namespace GoToCSharp.TaskCardGame
{
    public class Deck
    {
        private static Random random = new Random();
        public List<Card> cards = new List<Card>();

        public void CreateDeck()
        {
            string suit = "";
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                    suit = "Пика";
                else if (i == 1)
                    suit = "Крести";
                else if (i == 2)
                    suit = "Бубна";
                else if (i == 3)
                    suit = "Черви";
                List<Card> collectionCards = new List<Card>
                {
                    new Card(6, suit),
                    new Card(7, suit),
                    new Card(8, suit),
                    new Card(9, suit),
                    new Card(10, suit),
                    new Card(11, suit),
                    new Card(12, suit),
                    new Card(13, suit),
                    new Card(14, suit)
                };
                cards.AddRange(collectionCards);
            }
        }

        public void Shuffle()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                int rnd = random.Next(i + 1);
                Card temp = cards[i];
                cards[i] = cards[rnd];
                cards[rnd] = temp;
            }
        }

    }
}