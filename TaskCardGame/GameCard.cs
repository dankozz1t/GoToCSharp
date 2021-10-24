using System;
using System.Collections.Generic;
using System.Threading;

namespace GoToCSharp.TaskCardGame
{
    public class GameCard
    {
        private Deck deck = new Deck();
        private List<Player> players = new List<Player>();

        private List<Card> prize = new List<Card>();

        private void DealOfCards()
        {
            for (int i = deck.cards.Count - 1; i >= 0; i--)
            {
                if (i % 2 == 0)
                {
                    players[0].Cards.Add(deck.cards[i]);
                    deck.cards.RemoveAt(i);
                }
                else
                {
                    players[1].Cards.Add(deck.cards[i]);
                    deck.cards.RemoveAt(i);
                }
            }
        }

        private void Duel(Player player1, Player player2)
        {
            Console.SetCursorPosition(40, 5);

            Console.WriteLine($" {player1.Name} VS {player2.Name}");

            Console.SetCursorPosition(32, 6);
            Console.Write(player1.Cards[player1.Cards.Count - 1]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  VS  ");
            Console.WriteLine(player2.Cards[player2.Cards.Count - 1]);

            Console.SetCursorPosition(40, 7);
            if (player1.Cards[player1.Cards.Count - 1] > player2.Cards[player2.Cards.Count - 1] == 1)
            {
                player1.Cards.Insert(0, player1.Cards[player1.Cards.Count - 1]);
                player1.Cards.Insert(0, player2.Cards[player2.Cards.Count - 1]);
                player2.Cards.RemoveAt(player2.Cards.Count - 1);
                player1.Cards.RemoveAt(player1.Cards.Count - 1);

                if (prize.Count > 0) //Есть ли приз, если да, то забираю!
                {
                    foreach (var pri in prize)
                    {
                        player1.Cards.Insert(0, pri);
                    }
                    prize.Clear();
                }

                Console.WriteLine($" ВЫИГРАЛ {player1.Name}");
            }
            else if (player1.Cards[player1.Cards.Count - 1] < player2.Cards[player2.Cards.Count - 1] == 2)
            {
                player2.Cards.Insert(0, player2.Cards[player2.Cards.Count - 1]);
                player2.Cards.Insert(0, player1.Cards[player1.Cards.Count - 1]);
                player2.Cards.RemoveAt(player2.Cards.Count - 1);
                player1.Cards.RemoveAt(player1.Cards.Count - 1);

                if (prize.Count > 0) 
                {
                    foreach (var pri in prize)
                    {
                        player2.Cards.Insert(0, pri);
                    }
                    prize.Clear();
                }

                Console.WriteLine($" ВЫИГРАЛ {player2.Name}");
            }
            else if (player1.Cards[player1.Cards.Count - 1] < player2.Cards[player2.Cards.Count - 1] == 0)
            {
                Console.SetCursorPosition(28, 7);
                Console.WriteLine($" НИЧЬЯ! СКИДЫВАЕМСЯ НА ПРИЗ И ПОВТОРЯЕМ!");
                //Если ничья, то спорные карты кладутся в лист Приза + следующая
                // карта игроков, Заберет их тот, кто выиграет в следующем ходе

                prize.Add(player1.Cards[player1.Cards.Count - 1]);
                prize.Add(player2.Cards[player2.Cards.Count - 1]);

                if (player1.Cards.Count -2 >= 2)
                    prize.Add(player1.Cards[player1.Cards.Count - 2]);
                if (player2.Cards.Count -2 >= 2)
                    prize.Add(player2.Cards[player2.Cards.Count - 2]);

                player1.Cards.RemoveAt(player1.Cards.Count - 1);
                player2.Cards.RemoveAt(player2.Cards.Count - 1);

                if (player1.Cards.Count -2 >= 1)
                    player1.Cards.RemoveAt(player1.Cards.Count - 1);
                if (player2.Cards.Count -2 >= 1)
                    player2.Cards.RemoveAt(player2.Cards.Count - 1);

                Console.SetCursorPosition(42, 10);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Накопленный приз: ");
                for (int i = 0; i < prize.Count; i++)
                {
                    Console.SetCursorPosition(42, 11 + i);
                    Console.WriteLine("  " + prize[i]);
                }
            }
        }

        public void StartMenu()
        {
            Console.WriteLine("ПЬЯНИЦА!!");

            Console.WriteLine("Создаю колоду...");
            deck.CreateDeck();
            Console.WriteLine("Тасую...");
            deck.Shuffle();

            Console.WriteLine("Создаю двух игроков..");
            Console.Write("Введите имя первого игрока: ");
            Player player1 = new Player(Console.ReadLine());
            Console.Write("Введите имя первого игрока: ");
            Player player2 = new Player(Console.ReadLine());

            players.Add(player1);
            players.Add(player2);

            Console.WriteLine("Раздаю игрокам карты...");
            DealOfCards();
            Thread.Sleep(500);

            bool game = true;
            while (game)
            {
                Console.Clear();

                Duel(players[0], players[1]);

                players[0].Print(1);
                players[1].Print(80);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(28, 20);
                Console.WriteLine("Нажмите любую клавишу что бы сделать ход...");
                Console.ReadKey();

                if (players[0].Cards.Count == 0 || players[1].Cards.Count == 0) 
                    game = false;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(28, 20);
            Console.WriteLine("КОНЕЦ нажмите любую клавишу что бы ВЫЙТИ...");
            Console.ReadKey();
        }
    }
}