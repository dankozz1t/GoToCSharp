using System;

namespace GoToCSharp.TaskCardGame
{
    public class Card
    {
        private int Numbering;
        private string Suit;

        public Card(int numbering, string suit)
        {
            Numbering = numbering;
            Suit = suit;
        }

        private void SetColorCard()
        {
            if (Suit == "Бубна")
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            else if (Suit == "Черви")
                Console.ForegroundColor = ConsoleColor.DarkRed;
            else if (Suit == "Пика")
                Console.ForegroundColor = ConsoleColor.DarkGray;
            else if (Suit == "Крести")
                Console.ForegroundColor = ConsoleColor.Gray;
        }

        public override string ToString()
        {
            SetColorCard();

            string NumberingSt = "";
            switch (Numbering)
            {
                case 6: NumberingSt = "Шесть"; break;
                case 7: NumberingSt = "Семь"; break;
                case 8: NumberingSt = "Восемь"; break;
                case 9: NumberingSt = "Девять"; break;
                case 10: NumberingSt = "Десять"; break;
                case 11: NumberingSt = "Валет"; break;
                case 12: NumberingSt = "Дама"; break;
                case 13: NumberingSt = "Король"; break;
                case 14: NumberingSt = "Туз"; break;
            }

            return $"{NumberingSt} {Suit}";
        }

        public static int operator >(Card c1, Card c2)
        {
            if (c1.Numbering > c2.Numbering)
                return 1;
            else if (c1.Numbering < c2.Numbering)
                return 2;
            else
                return 0;
        }

        public static int operator <(Card c1, Card c2)
        {
            if (c1.Numbering < c2.Numbering)
                return 2;
            else if (c1.Numbering < c2.Numbering)
                return 1;
            else
                return 0;
        }
    }
}