using System;

namespace GoToCSharp
{
    public class Tank
    {

        //РЕЗУЛЬТАТ КОМПИЛЯЦИИ (ДЕМОНСТРАЦИЯ) В //resources//TaskTanks

        //static void Main(string[] args)
        //{
        //    Console.Title = "TANKS";

        //    int NumberOfTanks = 5;

        //    for (int i = 0; i < NumberOfTanks; i++)
        //    {
        //        Tank tank1 = new Tank(" Т-34  ");
        //        Tank tank2 = new Tank("Pantera");

        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine($"\n -{tank1.Name} VS   {tank2.Name}");

        //        Console.ForegroundColor = ConsoleColor.Yellow;
        //        Console.WriteLine($" {tank1} \n { tank2}");

        //        Console.ForegroundColor = ConsoleColor.Green;
        //        if (tank1 * tank2 == 1)
        //            Console.WriteLine($" -ПОБЕДА = {tank1.Name} ");

        //        else if (tank1 * tank2 == 2)
        //            Console.WriteLine($" -ПОБЕДА = {tank2.Name} ");

        //        else
        //            Console.WriteLine(" -НИЧЬЯ ");
        //    }
        //    Console.Read();
        //}

        private static Random rnd = new Random();
        public string Name;
        public int Ammunition; //Боекомплекты
        public int Armor;      //Броня
        public int Agility;    //Маневренности

        public Tank(string name)
        {
            Name = name;
            Ammunition = rnd.Next(100);
            Armor = rnd.Next(100);
            Agility = rnd.Next(100);
        }

        public static int operator *(Tank t1, Tank t2)
        {
            int t1Count = 0, t2Count = 0;

            if (t1.Ammunition > t2.Ammunition) t1Count++;
            else if (t1.Ammunition < t2.Ammunition) t2Count++;

            if (t1.Armor > t2.Armor) t1Count++;
            else if (t1.Armor < t2.Armor) t2Count++;

            if (t1.Agility > t2.Agility) t1Count++;
            else if (t1.Agility < t2.Agility) t2Count++;


            if (t1Count > t2Count) //Победил 1 танк
                return 1;
            else if (t1Count == t2Count) //Ничья!
                return 0;
            else return 2; //Победил 2 танк
        }

        public override string ToString()
        {
            return $" TANK [{Name}] | Ammunition [{Ammunition}] | Armor [{Armor}] | Agility [{Agility}]";
        }
    }
}