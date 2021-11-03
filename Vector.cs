using System;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using NLog;

namespace GoToCSharp
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Point operator ++(Point p)
        {
            p.X++;
            p.Y++;
            return p;
        }

        public static Point operator --(Point p)
        {
            p.X--;
            p.Y--;
            return p;
        }

        public static Point operator -(Point p)
        {
            return new Point { X = -p.X, Y = -p.Y };
        }
        public override string ToString()
        {
            return $" X = {X} | Y = {Y} ";
        }

    }


    public class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public Vector() { logger.Warn("Создался вектор"); }

        public Vector(Point p1, Point p2)
        {
            X = p2.X - p1.X;
            Y = p2.Y - p1.Y;
        }
        //public Vector(params int[]a)
        //{
        //    X =a[3] - a[1];
        //    Y = a[2] - a[0];
        //}

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector { X = v1.X + v2.X, Y = v1.Y + v2.Y };
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector { X = v1.X - v2.X, Y = v1.Y - v2.Y };
        }

        public static Vector operator *(Vector v1, int n)
        {
            return new Vector { X = v1.X * n, Y = v1.Y * n };
        }

        public override string ToString()
        {
            return $"Vector: X = {X} | Y = {Y}";
        }

        public static bool operator ==(Vector v1, Vector v2) => v1.X == v2.X && v1.Y == v2.Y;

        public static bool operator !=(Vector v1, Vector v2)
        {
            return v1.X != v2.X || v1.Y != v2.Y;
        }

        public static bool operator true(Vector v1)
        {
            return v1.X != 0 || v1.Y != 0;
        }
        public static bool operator false(Vector v1)
        {
            return v1.X == 0 && v1.Y == 0;
        }

        public static bool operator !(Vector v1)
        {
            return (v1) ? false : true;
        }

        //explicit ЯВНОЕ ПРЕОБРАЗОВАНИЕ ( надо double b = (double)v1; )
        //implicit НЕ ЯВНОЕ Можно без double b = v1;
        public static implicit operator double(Vector v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y);
        }
    }


    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"Product {Name} | Price {Price}";
        }
    }

    public class Shop
    {
        private Product[] products;

        public Shop(int n)
        {
            products = new Product[n];
        }

        public int Length
        {
            get { return products.Length; }
        }

        public Product this[int ind]
        {
            get
            {
                if (ind >= 0 && ind < products.Length)
                    return products[ind];
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (ind >= 0 && ind < products.Length)
                    products[ind] = value;
            }
        }

        public int this[string name]
        {
            get
            {
                for (var i = 0; i < products.Length; i++)
                {
                    if (products[i].Name == name)
                        return products[i].Price;
                }
                return 0;
            }
            set
            {
                for (var i = 0; i < products.Length; i++)
                {
                    if (products[i].Name == name)
                        products[i].Price = value;
                }

            }
        }
    }

    class Matrix
    {
        private int[,] arr;

        public int Row { get; private set; }
        public int Col { get; private set; }

        public Matrix(int row, int col)
        {
            Row = row;
            Col = col;
            arr = new int[row, col];
        }

        public int this[int r, int c]
        {
            get { return arr[r, c]; }
            set { arr[r, c] = value; }
        }
    }


    public class Point2D<T> where T : struct //Ограничение на Т, структуры, классы. Дженерик классы
    {
        public T X { get; set; }
        public T Y { get; set; }

        public Point2D(T x, T y)
        {
            X = x;
            Y = y;
        }

        public Point2D()
        {
            X = default(T);
            Y = default(T);
        }
    }

    public class Point3D : Point2D<int>
    {

    }



}

