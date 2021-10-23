using System;
using System.Collections.Generic;
using System.Threading;
using PU011_CSharp;

namespace GoToCSharp.TaskCarRacing
{
    public delegate void Finish();
    public delegate void Recording(int distance);

    public class Game
    {
        List<Car> Cars = new List<Car>();
        event Recording Recording;
        event Finish Finish;


        private void Start()
        {
            Console.Write("Введите дистанцию: ");
            int distance = Convert.ToInt32(Console.ReadLine());

            Recording(distance); //Выдать всем машинам дистанцию

            Console.WriteLine("Нажмите чтобы продолжить..."); Console.ReadKey();
            Console.Clear();
            while (Finish == null)
            {
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(300);

                foreach (var item in Cars)
                {
                    Console.WriteLine(item.Drive());

                    if (item.DistanceTraveled == 0 && Finish == null) //Если осталось пройти 0 км
                        Finish += item.Finish;
                }
            }
            Finish();
            Console.ReadKey();
        }

        private void PrintColor()
        {
            for (int i = 1; i < 15; i++)
            {
                Console.ForegroundColor = (ConsoleColor)i;
                Console.Write($" {i}, ");
            }
            Console.WriteLine(); Console.ResetColor();
        }

        public void StartMenu()
        {
            int pos = 0;
            string[] menu = { "Создать Машину", "Начать гонку", "Выход" };
            string[] menuCars = { "Спорткар", "Легковая", "Грузовик" };

            while (pos != 4)
            {
                Console.Clear(); Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ГОНКИ!");
                pos = Menu.VerticalMenu(menu);

                Car car = null;
                if (pos == 0)
                {
                    Console.Clear();
                    Console.Write("Введите номера машины: ");
                    string carNumber = Console.ReadLine();

                    PrintColor();
                    Console.Write("Выберите цвет: ");
                    int color = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Выберите тип");
                    int posCars = Menu.VerticalMenu(menuCars);

                    if (posCars == 0) car = new Sport(carNumber, (ConsoleColor)color);
                    else if (posCars == 1) car = new Passenger(carNumber, (ConsoleColor)color);
                    else if (posCars == 2) car = new Truck(carNumber, (ConsoleColor)color);

                    Recording += car.ToRace;
                    Cars.Add(car);
                }
                else if (pos == 1)
                {
                    Start();
                    Finish = null;
                }

                Console.ResetColor();
            }
        }

    }
}