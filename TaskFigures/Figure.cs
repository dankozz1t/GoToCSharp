using System;
using System.Collections.Generic;
using PU011_CSharp;

namespace GoToCSharp.TaskFigure
{
    public static class GoToStart
    {
        static void MainFigures(string[] args)
        {
            Console.Title = "Task_Drow_Fugures";

            Figure geometric = new Figure();
            int posMenu = 0;
            string[] menuFigure = { "Прямоугольник", "Треугольник", "Ромб", "Трапеция" };
            string[] menu = { "Создать фигуру", "Вывести все фигуры", "Выход" };

            while (posMenu != 2)
            {
                Console.Clear(); Console.ResetColor();
                posMenu = Menu.VerticalMenu(menu);
                Console.WriteLine("-----------");
                if (posMenu == 0)
                {
                    Console.WriteLine("Какую фигуру вы хотите создать?");
                    geometric.CreateFigure(Menu.VerticalMenu(menuFigure));
                }
                else if (posMenu == 1)
                {
                    geometric.ShowAllShapes();
                    Console.ReadKey();
                }
            }
        }


        public interface IPoint
        {
            int X { get; set; }
            int Y { get; set; }
        }

        public interface IDrow
        {
            ConsoleColor Color { get; set; }
            void Draw();
        }

        public interface IQuadrangular : IPoint
        {
            int Height { get; set; }
            int Width { get; set; }
        }

        public interface ITriangular : IPoint
        {
            int A { get; set; }
            int B { get; set; }
            int C { get; set; }
        }

        public class Rectangle : Figure, IQuadrangular, IDrow
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }
            public ConsoleColor Color { get; set; }

            public Rectangle(int x, int y, int height, int width, ConsoleColor color)
            {
                X = x;
                Y = y;
                Height = height;
                Width = width;
                Color = color;
            }

            public void Draw()
            {
                Console.ResetColor();
                Console.ForegroundColor = Color;
                Console.SetCursorPosition(X, Y);
                Console.WriteLine("Прямоугольник");
                Console.SetCursorPosition(X, Y += 1);
                Console.WriteLine($"Высота = {Height} ");
                Console.SetCursorPosition(X, Y += 1);
                Console.WriteLine($"Ширина = {Width} ");
            }
        }

        public class Rhombus : Figure, IQuadrangular, IDrow
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }
            public ConsoleColor Color { get; set; }

            public Rhombus(int x, int y, int height, int width, ConsoleColor color)
            {
                X = x;
                Y = y;
                Height = height;
                Width = width;
                Color = color;
            }

            public void Draw()
            {
                Console.ResetColor();
                Console.ForegroundColor = Color;
                Console.SetCursorPosition(X, Y);
                Console.WriteLine("   Ромб");
                Console.SetCursorPosition(X, Y += 1);
                Console.WriteLine($"Высота = {Height} ");
                Console.SetCursorPosition(X, Y += 1);
                Console.WriteLine($"Ширина = {Width} ");
            }
        }

        public class Trapezoid : Figure, IQuadrangular, IDrow
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }
            public ConsoleColor Color { get; set; }

            public Trapezoid(int x, int y, int height, int width, ConsoleColor color)
            {
                X = x;
                Y = y;
                Height = height;
                Width = width;
                Color = color;
            }

            public void Draw()
            {
                Console.ResetColor();
                Console.ForegroundColor = Color;
                Console.SetCursorPosition(X, Y);
                Console.WriteLine("  Трапеция");
                Console.SetCursorPosition(X, Y += 1);
                Console.WriteLine($"Высота = {Height} ");
                Console.SetCursorPosition(X, Y += 1);
                Console.WriteLine($"Ширина = {Width} ");
            }
        }


        public class Triangle : Figure, ITriangular, IDrow
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }
            public ConsoleColor Color { get; set; }

            public Triangle(int x, int y, int a, int b, int c, ConsoleColor color)
            {
                X = x;
                Y = y;
                A = a;
                B = b;
                C = c;
                Color = color;
            }

            public void Draw()
            {
                Console.ForegroundColor = Color;
                Console.SetCursorPosition(X, Y);
                Console.WriteLine("Треугольник");
                Console.SetCursorPosition(X, Y += 1);
                Console.WriteLine($"   А = {A}");
                Console.SetCursorPosition(X, Y += 1);
                Console.WriteLine($"   B = {B} ");
                Console.SetCursorPosition(X, Y += 1);
                Console.WriteLine($"   C = {C} ");
            }
        }

        public class Figure
        {
            private List<Figure> Figures = new List<Figure>();

            private void PrintColor()
            {
                for (int i = 1; i < 15; i++)
                {
                    Console.ForegroundColor = (ConsoleColor)i;
                    Console.Write($" {i}, ");
                }
                Console.WriteLine();
                Console.ResetColor();
            }

            public void CreateFigure(int pos)
            {
                Console.WriteLine();
                Console.WriteLine("-----------");

                Console.Write("Введите кординату Х: ");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите кординату Y: ");
                int y = Convert.ToInt32(Console.ReadLine());

                PrintColor();
                Console.Write("Выберите цвет: ");
                int color = Convert.ToInt32(Console.ReadLine());

                int height = 0, width = 0, a = 0, b = 0, c = 0;
                switch (pos)
                {
                    case 0:                                         //ПРЯМОУГОЛЬНИК
                        Console.Write("Введите Высоту: ");
                        height = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите Ширину: ");
                        width = Convert.ToInt32(Console.ReadLine());

                        Figure rectangle = new Rectangle(x, y, height, width, (ConsoleColor)color);

                        Figures.Add(rectangle);

                        break;
                    case 1:                                         //ТРЕУГОЛЬНИК
                        Console.Write("Введите А: ");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите B: ");
                        b = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите C: ");
                        c = Convert.ToInt32(Console.ReadLine());

                        Figure triangle = new Triangle(x, y, a, b, c, (ConsoleColor)color);

                        Figures.Add(triangle);
                        break;
                    case 2:                                         //РОМБ
                        Console.Write("Введите Высоту: ");
                        height = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите Ширину: ");
                        width = Convert.ToInt32(Console.ReadLine()); ;

                        Figure rhombus = new Rhombus(x, y, height, width, (ConsoleColor)color);
                        Figures.Add(rhombus);
                        break;
                    case 3:                                         //ТРАПЕЦИЯ
                        Console.Write("Введите Высоту: ");
                        height = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите Ширину: ");
                        width = Convert.ToInt32(Console.ReadLine()); ;

                        Figure trapezoid = new Trapezoid(x, y, height, width, (ConsoleColor)color);
                        Figures.Add(trapezoid);
                        break;
                }
            }

            public void ShowAllShapes()
            {
                foreach (var item in Figures)
                {
                    if (item is Triangle)
                        (item as Triangle).Draw();

                    else if (item is Rhombus)
                        (item as Rhombus).Draw();

                    else if (item is Rectangle)
                        (item as Rectangle).Draw();


                    else if (item is Trapezoid)
                        (item as Trapezoid).Draw();
                }
            }
        }
    }
}