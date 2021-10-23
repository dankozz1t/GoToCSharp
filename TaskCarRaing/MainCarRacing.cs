using System;


namespace GoToCSharp.TaskCarRacing
{
    public class MainCarRacing
    {
        static void MainCar(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "Task Car Racing";

            Game race = new Game();
            race.StartMenu();

            Console.Read();
        }
    }
}