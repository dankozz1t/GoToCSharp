using System;
using System.Collections.Generic;

namespace GoToCSharp.TaskCardGame
{
    public class Player
    {
        public string Name;
        public List<Card> Cards = new List<Card>();

        public Player(string name) { Name = name; }

        public void Print(int pos)
        {
            Console.SetCursorPosition(pos, 0);
            Console.WriteLine("----------------------------");
            Console.SetCursorPosition(pos, 1);
            Console.WriteLine($" Имя: {Name} ----- Карт: {Cards.Count} ");
            for (int i = 0; i < Cards.Count; i++)
            {
                Console.SetCursorPosition(pos, 2 + i);
                Console.WriteLine($" #{i + 1} : {Cards[i]}");
            }
        }
    }
}