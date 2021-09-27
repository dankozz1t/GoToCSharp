﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoToCSharp
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "Start learning CSharp";

            DzWeek1_1 dz = new DzWeek1_1();
            dz.startMenu();


            //Main22_09();

        }

        static bool greter3(int a)
        {
            return a > 30;
        }
        static void Main22_09()
        {
            Console.WriteLine("New Main 22 09 20021");

            const int sizeArr = 5;

            int[] arr = new int[sizeArr] { 1, 2, 3, 4, 5 };

            int[] arr2 = new int[sizeArr];

            arr.CopyTo(arr2, 0); //Копирование ар1 в ар2 

            Console.WriteLine(arr2.GetValue(3));

            Console.WriteLine(Array.FindAll(arr2, greter3).ToArray());

            for (int i = 0; i < sizeArr; i++)
            {
                Console.WriteLine();
                Console.Write(arr[i] + " ");

                Console.Write(arr2[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine(" ========= ");

            int[,] array2D = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } }; //Двухмерный массив, инц, вывод
            Console.WriteLine(array2D.Rank);
            Console.WriteLine(array2D.Length);


            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    Console.Write("{0,3}", array2D[i, j]);
                }
                Console.WriteLine();
            }

            int[][] arrArr = new int[2][] { new int[5] { 1, 2, 3, 4, 5 }, new int[3] { 1, 3, 4 } }; //Зубчатый массив, инц, вывод

            for (int i = 0; i < arrArr.GetLength(0); i++)
            {
                foreach (var item in arrArr[i])
                {
                    Console.WriteLine(item + " ");
                }

                Console.WriteLine();
            }


            string st = " jejeje.jejedje";
            string st1 = new string('$', 10);


            Console.WriteLine("Строка {st} Заканчиавается на е: " + st.EndsWith("e"));
            Console.WriteLine("Строка {st} Начинается на е:" + st.StartsWith("e"));

            Console.WriteLine("Форматирование влево на 20 (setw(20)): " + st.PadLeft(20));

            string[] str2 = st.Split('d', '.').ToArray(); //Разделяет строку от ''

            foreach (var item in str2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Удаляет все начальные и конечные символы " + st.Trim(" ".ToCharArray()));


            StringBuilder sb = new StringBuilder();
            sb.Append(" hello");

            Console.WriteLine(sb);



            Console.Read();
        }

        static void Main21_09()
        {
            //Console.WindowHeight = 25;
            //Console.WindowWidth = 80;


            //Console.Clear();
            //Console.Beep(1000, 1000);


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


            //int d = 5 > 4 ? 2 : 6; //Условный оператор


            //int[] arr = new int[10];
            //Random rns = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    arr[i] = rns.Next(10,80);
            //    Console.Write(arr[i] + " ");
            //}
            //Console.WriteLine();

            //int count = 0;

            //foreach (var item in arr)
            //{
            //    if (item % 2 == 0)
            //        count++;
            //}

            //Console.WriteLine($"Count = {count}");


            //double number2 = double.Parse("34.42"); // Зависит от настроек операционной системы

            ////Следующий вызов не зависит от настроек и всегда ожидает точку в качестве разделителя:
            //number2 = double.Parse("34.42", CultureInfo.InvariantCulture);



            //Console.Read();
        }

    }
}
