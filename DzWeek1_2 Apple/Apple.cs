//Задание 1.
//1.1.Разработать один из классов, в соответствии с полученным вариантом.
//1.2. Реализовать не менее пяти закрытых полей (различных
//     типов), представляющих основные характеристики рассматриваемого класса.
//1.3. Создать не менее трех методов управления классом
//     и методы доступа к его закрытым полям.
//1.4. Создать метод, в который передаются аргументы по ссылке.
//1.5. Создать не менее двух статических полей (различных типов), представляющих общие характеристики
//     объектов данного класса.
//1.6. Обязательным требованием является реализация нескольких перегруженных конструкторов, аргументы 
//    которых определяются студентом, исходя из специфики реализуемого класса, а так же реализация
//    конструктора по умолчанию.
//1.7. Создать статический конструктор.
//1.8. Создать массив (не менее 5 элементов) объектов
//    созданного класса.
//1.9. Создать дополнительный метод для данного класса
//    в другом файле, используя ключевое слово partial.



//Вместо методов управления закрытыми полями (1.3) я сделал свойства, а то как-то по не по шарповскому :) 

using System;

namespace GoToCSharp
{
    class GoToStart
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "DZ_Week1_2";

            Apple[] apples = {
                new Apple("Красный принц", "Красный", "Горький", 8, 10),
                new Apple("Райское", "Зеленый", "Кислый", 6, 10),
                new Apple("Домашнее", "Красно-Желтое", "Сладкий", 10, 8),
                new Apple(),
                new Apple()
            };

            foreach (var item in apples)
            {
                item.Print();
            }
            Console.WriteLine("\n ДОБАВЛЕНИЕ САХАРА ");
            apples[0].AddSugar();

            Console.WriteLine("\n ОТКУСЫВАНИЕ ЯБЛОКА ");
            apples[1].Eat();

            Console.WriteLine("\n ЗАБЫТЬ ЯБЛОКО ");
            apples[2].Forget();

            Console.WriteLine("\n ПЕРЕКРАСИТЬ ЯБЛОКО ");
            apples[3].Repaint();

            Console.WriteLine($"\nВСЕГО КОЛИЧЕСТВО ЯБЛОК: {Apple.Count}");

            Console.WriteLine("\n ПРИНТ ВСЕХ ЯБЛОК");

            foreach (var item in apples)
            {
                item.Print();
            }

            Console.Read();
        }
    }

    public partial class Apple
    {
        private string grade; //сорт
        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        private string color;
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        private string taste; //Вкус
        public string Taste
        {
            get { return taste; }
            set { taste = value; }
        }

        private int freshness; //свежесть
        public int Freshness
        {
            get { return freshness; }
            set { freshness = value; }
        }

        private int whole; //Целостность яблока (его можно есть)
        public int Whole
        {
            get
            {
                return whole;
            }
            set
            {
                if (whole < 0) whole = 0;
                else if (whole > 10) whole = 10;
                else whole = value;
            }
        }

        private int Number;
        static public int Count { get; private set; } 

        static Apple()
        {
            Console.WriteLine("Вы создали первое яблоко!");
        }

        public Apple()
        {
            Grade = "GOLDEN";
            Color = "ЖЕЛТОЕ";
            Taste = "ОБЫЧНОЕ";
            Freshness = 9;
            Whole = 10;
            Number = Count;
            Count++;
        }

        public Apple(string grade, string color, string taste, int freshness, int whole)
        {
            Grade = grade;
            Color = color;
            Taste = taste;
            Freshness = freshness;
            Whole = whole;
            Number = Count;
            Count++;
        }

        public void Print()
        {
            Console.WriteLine($" ЯБЛОКО №{Number} = | Сорт: {Grade} | Цвет: {Color} | Вкус: {Taste} | Свежесть: {Freshness}/10 | Целостность: {Whole}/10 | ");
        }

        public void Eat()
        {
            Console.Write($" ЯБЛОКО №{Number} | ");
            Console.WriteLine($" ЦЕЛОСТНОСТЬ №{Whole} ");

            Console.Write("Введите сколько раз вы укусите: ");
            int bite = Int32.Parse(Console.ReadLine());

            Console.WriteLine($" Вы укусили {bite} раза | Целостность яблока: {Whole} ");

            Whole -= bite;
        }

        public void Forget()
        {
            Console.Write($" ЯБЛОКО №{Number} | ");
            Console.WriteLine(" Вы закатили яблоко под холодильник и забыли про него");
            Freshness = 0;
            Console.WriteLine($" Свежесть: {Freshness}/10 ");
        }

        public void Repaint()
        {
            Console.Write($" ЯБЛОКО №{Number} | ");
            Console.WriteLine($"Цвет яблока: {Color}");
            Console.Write("Введите в какой цвет хотите перекрасить: ");
            string newColor = Console.ReadLine();
            Color = newColor;
        }


    }
}