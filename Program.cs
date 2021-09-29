using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoToCSharp
{
    public class A
    {
        public void MethodA(B obj)
        {
            obj.MethodB(this);
        }
    }

    public class B
    {
        public void MethodB(A obj)
        {
            Console.WriteLine($"Class - {obj.GetType().Name}");
        }
    }


    public partial class Student
    {
        private int salary;
        public int Salary
        {
            get { return salary; }
            set
            {
                if (salary > 0)
                    salary = value;
                else
                    Console.WriteLine("Исключение, зп меньше 0");
            }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value > 1 && value < 100 ? value : 0;  }
        }
        public int sex { get; set; }
        public string GroupName { get; set; } = "201";
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }

        public void Print()
        {
            Console.WriteLine($" Name: {Name},\n Age: {Age},\n GroupName: {GroupName},\n Sex = {sex},\n BDay = {BirthDay}");
            Console.WriteLine();
        }

    }

    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.BackgroundColor = ConsoleColor.DarkGray;
        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    Console.Title = "Start learning CSharp";

        //    Main29_09();


        //    Console.Read();
        //}

        static void Main29_09()
        {

            //----------------------------------VECTOR 
            //Point p = new Point();
            //p.X = 1;
            //p.Y = 2;
            //p.Y -= p.X;
            //Console.WriteLine(-p);

            //Vector v1 = new Vector(new Point() { X = 2, Y = 4 }, new Point() { X = 5, Y = 8 });
            //Vector v2 = new Vector(new Point() { X = 5, Y = 6 }, new Point() { X = 8, Y = 9 });
            //Console.WriteLine($" V1 = {v1}");
            //Console.WriteLine($" V2 = {v2}");

            //Vector v3 = v1 + v2;
            //Console.WriteLine($" V3 = {v3}");

            //Console.WriteLine($" V3 = {v3 = v2 * 4}");

            //Vector v4 = v3;
            //if(v4 == v3)
            //    Console.WriteLine($" v4 = {v4} |   ==   |v3 = {v3} ");

            //double d = v1;
            //Console.WriteLine($" V1 = {d}");
            //----------------------------------VECTOR ^

            //----------------------------------SHOP
            //Shop shop = new Shop(3);
            //shop[0] = new Product { Name = "TV", Price = 500 };
            //shop[1] = new Product { Name = "Apple", Price = 20 };
            //shop[2] = new Product { Name = "Meme", Price = 100 };

            //try
            //{
            //    for (int i = 0; i < shop.Length; i++)
            //    {
            //        Console.WriteLine(shop[i]);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    throw;
            //}

            //shop["Apple"] = 101;
            //Console.WriteLine($"{shop[1]}");
            //----------------------------------SHOP ^


            //----------------------------------Matrix 
            //Matrix matrix = new Matrix(3, 4);
            //Random rnd = new Random();
            //for (int i = 0; i < matrix.Row; i++, Console.WriteLine())
            //{
            //    for (int j = 0; j < matrix.Col; j++)
            //    {
            //        matrix[i, j] = rnd.Next(10);
            //        Console.Write($"{matrix[i,j]} ");
            //    }
            //}
            //----------------------------------Matrix ^



        }

        static void Main28_09()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "Start learning CSharp";

            //Console.WriteLine(Sum(1, 2, 3));

            //int aA = 0;
            //int b = 0;
            //int[] arr = {1, 2, 3};
            //FuncM(ref arr, ref aA, out b); //ref - меняет как ссылка в плюсах    //out - ТОчно должна изменить
            //    //Разница в том что параметру ref и out. ref =  Не обьязательно существовать

            //Console.WriteLine($"Aa = {aA}, Arr[0] = {arr[0]}, b = {b} ");

            //B b = new B();
            //A a = new A();
            //a.MethodA(b);
            //b.MethodB(a);


            Student student = new Student
            {
                Name = "Name",
                Age = 16,
                GroupName = "2340",
                Salary = 2333,
                sex = 0,
                BirthDay = new DateTime(2000, 5, 20),

            };
            student.Print();

            Console.WriteLine(student.Salary);
            //Student student2 = new Student("Alex", 18);
            //student2.Print();

            //Console.WriteLine(student2.GetAge()); //Из разбивки файла

            //student.Salary = 1000;
            //Console.WriteLine(student.Salary);

            Console.Read();

        }

        static void FuncM(ref int[] arr, ref int a, out int b)
        {
            arr = new int[] { 100, 200, 300 };
            a = 1000;
            b = 9900;
        }

        static int Sum(params int[] arr) //Разное количество параметром //params указывает на массив любого типа ( То есть с ним не нужно создавать обьект, а сразу параметры)
        {
            int suma = 0;
            foreach (var item in arr)
            {
                suma += item;
            }
            return suma;
        }


        //-----------------------------

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
