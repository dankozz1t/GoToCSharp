using System;
using System.Linq; //task1

namespace GoToCSharp
{
    public class DzWeek1_1
    {
        //static void Main(string[] args)
        //{
        //    Console.BackgroundColor = ConsoleColor.DarkGray;
        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    Console.Title = "DZ CSharp Week 1_1";

        //    DzWeek1_1 dz = new DzWeek1_1();
        //    dz.startMenu();
        //}
        public void startMenu()
        {
            Console.WriteLine("№1 - Задание считывание пробелов");
            Console.WriteLine("№2 - Счастливый трамвайный билетик");
            Console.WriteLine("№3 - Перевод в другой регистр");
            Console.WriteLine("№4 - Вывод целых чисел от A до B");
            Console.WriteLine("№5 - Перевернуть число");
            Console.WriteLine("№6 - Выход");

            int task = 0;
            while (task != 6)
            {
                Console.Write("\nВведите задание: № ");

                task = Int32.Parse(Console.ReadLine());

                switch (task)
                {
                    case 1: task1(); break;
                    case 2: task2(); break;
                    case 3: task3(); break;
                    case 4: task4(); break;
                    case 5: task5(); break;
                    default: break;
                }
            }
        }

        public void task1()
        {
            Console.WriteLine("ЗАДАНИЕ №1 ПОСЧИТАТЬ ПРОБЕЛЫ ДО ТОЧКИ");

            Console.Write("Введите предложение ( точка = конец ): ");


            //int space = 0, point = 0;
            //Console.Write("Введите предложение ( точка = конец ): ");
            //while (point != 32)
            //{
            //    point = Console.Read();
            //    if (point == 46)
            //        space++;
            //}
            //Console.WriteLine($"Всего {space} пробелов");

            //------------------Я сделал так ^ , но потом познал всю мощь C#, лямб, келлбаков

            Console.WriteLine("Пробелов: " + Console.ReadLine().TakeWhile(ch => ch != '.').Count(ch => ch == ' '));
        }


        public void task2()
        {
            Console.WriteLine("ЗАДАНИЕ №2 ТРАМВАЙНЫЙ СЧАСТЛИВЫЙ БИЛЕТ");

            int first = 0, last = 0;
            Console.Write("Введите 6-ти значный трамвайный билет: ");
            string ticketStr = Console.ReadLine();
            int ticket = Convert.ToInt32(ticketStr);
            for (int i = 0; i < 6; i++)
            {
                if (i < 3)
                    first += ticket % 10;
                else
                    last += ticket % 10;
                ticket /= 10;
            }
            Console.Write($"Ваш билетик <{ticketStr}> ");

            if (first == last)
                Console.WriteLine("является счастливым!");
            else
                Console.WriteLine("является НЕ счастливым!");
        }


        public void task3()
        {
            Console.WriteLine("ЗАДАНИЕ №3 ПЕРЕВОД ИЗ НИЖНЕГО РЕГИСТРА В ВЕРХНИЙ И НАОБОРОТ");

            //int key= 0;
            //while (key != 46)
            //{
            //    key = Console.Read();
            //    if (key > 96 && key < 123)
            //        key -= 32;
            //    else if (key > 64 && key < 91)
            //        key += 32;
            //    Console.Write((char)key);
            //}
            //------------Вот это ^ по идеи, должно работать, но нижний вариант (не мой) c ToLower и ToUpper мне нравится больше и работает лучше :))

            string str = Console.ReadLine();
            if (str.Length != 0)
            {
                char[] res = new char[str.Length];

                for (int i = 0; i < str.Length; i++)
                {
                    char c = str[i];
                    if (char.IsLetter(c))
                    {
                        c = char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c);
                    }
                    res[i] = c;
                }
                Console.WriteLine(res);
            }
        }


        public void task4()
        {
            Console.WriteLine("ЗАДАНИЕ №4 ВЫВОД ЦЕЛЫХ ЧИСЕЛ ОТ А ДО В");

            Console.Write("А = ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("B = ");
            int b = Convert.ToInt32(Console.ReadLine());

            for (int i = a; i <= b; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
            }
        }

        public void task5()
        {
            Console.WriteLine("ЗАДАНИЕ №5 ПЕРЕВЕРНУТЬ ЧИСЛО");
            int n = Convert.ToInt32(Console.ReadLine());

            int suma = 0;
            while (n > 0)
            {
                suma = suma * 10 + n % 10;
                n /= 10;
            }

            Console.WriteLine(suma);

        }
    }
}

