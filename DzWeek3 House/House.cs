using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PU011_CSharp;

namespace GoToCSharp.DzWeek3_House
{
    public static class GoToStart
    {
        static void MainHouse(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "DZ_Week1_3_Building_House";

            Console.WriteLine("СТРОИТЕЛЬСТВО ДОМА");
            Console.WriteLine();

            string[] menu = { "Создать стандартный дом( Фундамент, Стены, Дверь, 4 Окна, Крыша", "Спроектировать свой дом" };
            int pos = Menu.VerticalMenu(menu);
            string[] modeling = null;

            if (pos == 0)
            {
                modeling = new[] { "Фундамент", "Стены", "Дверь", "Окно", "Окно", "Окно", "Окно", "Крыша" };
            }
            else
            {
                string[] menuPart = { "Фундамент", "Стены", "Дверь", "Окно", "Крыша", "ПОСТРОИТЬ!" };
                List<string> mod = new List<string>();
                int posPart = 0;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                while ((posPart = Menu.VerticalMenu(menuPart)) != 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("-------------");
                    mod.Add(menuPart[posPart]);
                }
                modeling = mod.ToArray();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            House house = new House(modeling);
            Team team = new Team(3);
            team.Build(house);
            house.Print();

            Console.ReadKey();
        }
    }

    public interface IPart
    {
        string Print();
    }

    public class Wall : IPart { public string Print() => "  +Стены"; }
    public class Door : IPart { public string Print() => "  +Дверь"; }
    public class Roof : IPart { public string Print() => "  +Крыша"; }
    public class Window : IPart { public string Print() => "  +Окнo"; }
    public class Basement : IPart { public string Print() => "  +Фундамент"; }

    public class House
    {
        public List<string> Plan = new List<string>();
        public List<IPart> Parts;

        public House(params string[] arr)
        {
            Parts = new List<IPart>();
            foreach (var item in arr)
            {
                Plan.Add(item);
            }
        }

        public void AddPart(IPart p)
        {
            Parts.Add(p);
        }

        public bool End()
        {
            return Plan.Count == 0;
        }

        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------ДОМ------");
            foreach (var part in Parts)
            {
                Console.WriteLine(part.Print());
            }

            Console.WriteLine("------------");
        }
    }


    public interface IWorker
    {
        void Work(House house);
    }

    public class Team
    {
        public List<IWorker> Workers;

        public Team(int number)
        {
            Workers = new List<IWorker>();
            Workers.Add((new TeamLeader()));
            for (int i = 0; i < number; i++)
            {
                Workers.Add((new Worker()));
            }
        }

        public void Build(House house)
        {
            while (!house.End())
            {
                Workers[new Random().Next() % Workers.Count].Work(house);
                Thread.Sleep(500);
            }

            Console.WriteLine("--------Дом построен!");
        }
    }


    public class Worker : IWorker
    {
        public void Work(House house)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Строитель: Строю: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (house.Plan.First() == "Фундамент")
            {
                IPart ip = new Basement();
                Console.WriteLine(ip.Print());
                house.AddPart(ip);
                house.Plan.Remove("Фундамент");
            }
            else if (house.Plan.First() == "Стены")
            {
                IPart ip = new Wall();
                Console.WriteLine(ip.Print());
                house.AddPart(ip);
                house.Plan.Remove("Стены");
            }
            else if (house.Plan.First() == "Дверь")
            {
                IPart ip = new Door();
                Console.WriteLine(ip.Print());
                house.AddPart(ip);
                house.Plan.Remove("Дверь");
            }
            else if (house.Plan.First() == "Окно")
            {
                IPart ip = new Window();
                Console.WriteLine(ip.Print());
                house.AddPart(ip);
                house.Plan.Remove("Окно");
            }
            else if (house.Plan.First() == "Крыша")
            {
                IPart ip = new Roof();
                Console.WriteLine(ip.Print());
                house.AddPart(ip);
                house.Plan.Remove("Крыша");
            }
        }
    }

    public class TeamLeader : IWorker
    {
        public void Work(House house)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Бригадир: Уже построенно: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in house.Parts)
            {
                Console.WriteLine(item.Print());
            }
        }
    }

}