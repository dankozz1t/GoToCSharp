using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoToCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 25;
            Console.WindowWidth = 80;

            //Console.BackgroundColor = ConsoleColor.DarkGray;
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.Clear();
            //Console.Beep(1000, 1000);
            Console.Title = "Start learning CSharp";

            //Console.WriteLine("Введите а: ");
            ////int a = Convert.ToInt32(Console.ReadLine()); // 
            //string x = Console.ReadLine();
            //int a = Int32.Parse(x);
            //Console.WriteLine(a);

            //Console.WriteLine("Hello C++++!");
            //Console.Write("Введите ваше имя: ");
            //string name = Console.ReadLine();
            //Console.WriteLine("Ваше имя: "+ name + "!");

            //Console.WriteLine(char.IsDigit('8')); //Является ли цифрой
            //double? d = null; // ? Нулейбыл тип, присваивание нулевого значения
            //d = d ?? 50; //Если д = 0, значит присваивание 50, иначе остается с своим значением

            //int i = (int)d;

            //int a = 8;

            //Console.WriteLine("A = " + a);
            //Console.WriteLine("A = {0}", a);
            //Console.WriteLine($"A = {a}");

            //string a = "wqe";
            //switch (a)
            //{
            //    case "3443f":
            //    case "gg":
            //        Console.WriteLine(9);
            //        break;
            //    default:
            //        break;
            //}


            int d = 5 > 4 ? 2 : 6; //Условный оператор


            int[] arr = new int[10];
            Random rns = new Random();
            for (int i = 0; i < 10; i++)
            {
                arr[i] = rns.Next(10,80);
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            int count = 0;

            foreach (var item in arr)
            {
                if (item % 2 == 0)
                    count++;
            }

            Console.WriteLine($"Count = {count}");

        


            Console.Read();
        }
    }
}
