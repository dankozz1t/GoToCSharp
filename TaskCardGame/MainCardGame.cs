using System;

namespace GoToCSharp.TaskCardGame
{
    public class MainCardGame
    {
        static void MainCard(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "Task Card Game";

            GameCard game = new GameCard();
            game.StartMenu();

            Console.Read();
        }
    }
}