using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using GoToCSharp.Bank;
using GoToCSharpStud;
using System.Text.RegularExpressions;
using System.Windows.Forms;


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


    public partial class StudentB
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
            set { age = value > 1 && value < 100 ? value : 0; }
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
        static void Main(string[] args)
        {
            //Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "Recording learning CSharp";

            Main28_10();



            Console.Read();
        }


        static void Main28_10()
        {
            //DLLImportLibary.MessageBoxA(IntPtr.Zero, "Нажми ок если ок", "Лучшая в мире программа", 0);
        

            //string note = "notepad.exe";
            //string text = Console.ReadLine();
            //Process process = Process.Start(note);
            //process.WaitForInputIdle();
            //IntPtr h = process.MainWindowHandle;
            //DLLImportLibary.SetForegroundWindow(h);
            //SendKeys.SendWait(text);

            Vector v = new Vector();


        }

        static void Main27_10()
        {
            string TelPatt = @"^\+38\(0\d{2}\)\d{3}-\d{2}-\d{2}"; //Шаблон номера телефона +38(093)662-52-65
            string NamePatt = @"^[A-ZА-Я][a-zа-я]+(\-[A-ZА-Я][a-zа-я]+)*$"; //Шаблон имени Имя \ Имя-Имя / Имя-Имя-Имя..
            //string SurnamePatt = @"^[A-ZА-Я][a-zа-я]+*$"; //Шаблон фамилии

            string Pattern = NamePatt;//Шаблон

            string input = "";
            Regex regex = regex = new Regex(Pattern);

            while (input != "q")
            {
                input = Console.ReadLine();
                Console.WriteLine(regex.IsMatch(input) ? "Правильный ввод" : "Неправильный ввод");
            }



        }

        static void PrintNode(XmlNode node)
        {
            Console.WriteLine($"Type: {node.NodeType} | Name: {node.Name} | Value: {node.Value}");


            if (node.Attributes != null)
            {
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    Console.WriteLine($"Type: {attribute.NodeType} | Name: {attribute.Name} | Value: {attribute.Value}");
                }
            }

            if (node.HasChildNodes)
            {
                foreach (XmlNode xmlElement in node.ChildNodes)
                {
                    PrintNode(xmlElement);
                }
            }

            Console.WriteLine("------------");
        }

        static void Main26_10()
        {
            //-------------------------------------------------------------------------------ЗАПИСЬ СТУДЕНТОВ
            //List<GoToCSharpStud.Student> students = new List<GoToCSharpStud.Student>
            //{
            //    new    GoToCSharpStud.Student {
            //        FirstName = "Fedot",
            //        LastName = "Frolov",
            //        BirthDay = new DateTime (1990, 10, 5),
            //        StudentCard = new GoToCSharpStud.StudentCard
            //        {
            //            Series = "AB",
            //            Number = 923456
            //        }
            //    },
            //    new    GoToCSharpStud.Student
            //    {
            //        FirstName = "Irina",
            //        LastName = "Nikanorova",
            //        BirthDay = new DateTime(1991, 10, 12),
            //        StudentCard = new GoToCSharpStud.StudentCard
            //        {
            //            Series = "AB",
            //            Number = 223456
            //        }
            //    },
            //    new    GoToCSharpStud.Student
            //    {
            //        FirstName = "Igor",
            //        LastName = "Nikolaev",
            //        BirthDay = new DateTime(1989, 8, 10),
            //        StudentCard = new GoToCSharpStud.StudentCard
            //        {
            //            Series = "AC",
            //            Number = 123454
            //        }
            //    },
            //    new    GoToCSharpStud.Student
            //    {
            //        FirstName = "Olga",
            //        LastName = "Dubinkina",
            //        BirthDay = new DateTime(1988, 4, 13),
            //        StudentCard = new GoToCSharpStud.StudentCard
            //        {
            //            Series = "BC",
            //            Number = 123450
            //        }
            //    }
            //};

            //XmlDocument doc = new XmlDocument();

            //XmlNode root = doc.CreateElement("Students");
            //doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-16", null));
            //foreach (var student in students)
            //{
            //    XmlNode st = doc.CreateElement("Student");

            //    XmlNode FirstName = doc.CreateElement("FirstName");
            //    XmlNode LastName = doc.CreateElement("LastName");
            //    XmlNode BirthDay = doc.CreateElement("BirthDay");

            //    XmlNode StudentCard = doc.CreateElement("StudentCard");
            //    XmlNode Series = doc.CreateElement("Series");
            //    XmlNode Number = doc.CreateElement("Number");

            //    XmlNode textFirstName = doc.CreateTextNode(student.FirstName);
            //    XmlNode textLastName = doc.CreateTextNode(student.LastName);
            //    XmlNode textBirthDay = doc.CreateTextNode(student.BirthDay.ToShortDateString());

            //    XmlNode textSeries = doc.CreateTextNode(student.StudentCard.Series);
            //    XmlNode textNumber = doc.CreateTextNode(student.StudentCard.Number.ToString());

            //    FirstName.AppendChild(textFirstName);
            //    LastName.AppendChild(textLastName);
            //    BirthDay.AppendChild(textBirthDay);
            //    StudentCard.AppendChild(textSeries);
            //    Series.AppendChild(textSeries);
            //    Number.AppendChild(textNumber);

            //    StudentCard.AppendChild(Series);
            //    StudentCard.AppendChild(Number);

            //    st.AppendChild(FirstName);
            //    st.AppendChild(LastName);
            //    st.AppendChild(BirthDay);
            //    st.AppendChild(StudentCard);

            //    root.AppendChild(st);
            //}

            //doc.AppendChild(root);
            //doc.Save("../../SavingDocuments/Student.xml");

            //PrintNode(doc);
            //-------------------------------------------------------------------------------ЗАПИСЬ СТУДЕНТОВ ^

            //-------------------------------------------------------------------------------СЧИТЫВАНИЕ СТУДЕНТОВ
            //List<GoToCSharpStud.Student> students = new List<GoToCSharpStud.Student>();

            //XmlTextReader reader = new XmlTextReader("../../SavingDocuments/Student.xml");
            //reader.WhitespaceHandling = WhitespaceHandling.None; //НЕУЧИТЫВАЕМ ПРОБЕЛЫ, ОТСТУПЫ 

            //while (reader.Read()) //Пока читает
            //{
            //    Console.WriteLine($"Type: {reader.NodeType} | Name: {reader.Name} | Value: {reader.Value}");
            //    if (reader.AttributeCount >= 0)
            //    {
            //        while (reader.MoveToNextAttribute())
            //        {
            //            Console.WriteLine($"Type: {reader.NodeType} | Name: {reader.Name} | Value: {reader.Value}");
            //        }
            //    }
            //}
            //reader.Close();
            //-------------------------------------------------------------------------------СЧИТЫВАНИЕ СТУДЕНТОВ ^
            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange");

            //XmlNodeList l1 = doc.GetElementsByTagName("cc");
            //XmlNodeList l2 = doc.GetElementsByTagName("txt");
            //XmlNodeList l3 = doc.GetElementsByTagName("rate");

            //List<Currency> currency = new List<Currency>();
            //for (int i = 0; i < l1.Count; i++)
            //{
            //    currency.Add(new Currency { CodeNBU = l1[i].InnerText, Name = l2[i].InnerText, Rate = float.Parse(l3[i].InnerText.Replace('.', ',')) });
            //    //Console.WriteLine(currency[i]);
            //}

            //currency.Sort((c1, c2) => c1.Name.CompareTo(c2.Name));
            //Console.WriteLine("--------------------------------------------------------------------");
            //foreach (var currency1 in currency)
            //{
            //    Console.WriteLine(currency1);
            //}


            //List<Currency> currencyMax = currency.Where(c => c.Rate > 10).ToList();
            //Console.WriteLine("--------------------------------------------------------------------");
            //foreach (var currency1 in currencyMax)
            //{
            //    Console.WriteLine(currency1);
            //}

            //XmlDocument doc = new XmlDocument();
            //doc.Load("../../SavingDocuments/Comp.xml");
            //PrintNode(doc.DocumentElement);

            //XmlNode root = doc.DocumentElement;
            //root.RemoveChild(root.LastChild);

            //XmlNode comp = doc.CreateElement("Laptop");

            //XmlNode proc = doc.CreateElement("Processor");
            //XmlNode ram = doc.CreateElement("RAM");
            //XmlNode hdd = doc.CreateElement("HDD");
            //XmlNode motBo = doc.CreateElement("MotherBoard");
            //XmlNode ViCard = doc.CreateElement("VideoCard");

            //XmlNode text1 = doc.CreateTextNode("amd new tyrbo");
            //XmlNode text2 = doc.CreateTextNode("100GB");
            //XmlNode text3 = doc.CreateTextNode("200gb");
            //XmlNode text4 = doc.CreateTextNode("amd3043");
            //XmlNode text5 = doc.CreateTextNode("FDfd");

            //proc.AppendChild(text1);
            //ram.AppendChild(text2);
            //hdd.AppendChild(text3);
            //motBo.AppendChild(text4);
            //ViCard.AppendChild(text5);

            //comp.AppendChild(proc);
            //comp.AppendChild(ram);
            //comp.AppendChild(hdd);
            //comp.AppendChild(motBo);
            //comp.AppendChild(ViCard);

            //root.AppendChild(comp);

            //doc.Save("../../SavingDocuments/Comp1.xml");

            //XmlTextWriter writer = new XmlTextWriter("../../SavingDocuments/Comp.xml", Encoding.Unicode);
            //writer.Formatting = Formatting.Indented;
            //writer.WriteStartDocument();
            //writer.WriteStartElement("Computers");
            //writer.WriteStartElement("Computer");
            //writer.WriteAttributeString("Type","Game");
            //writer.WriteElementString("Proccessor", "Intel Core I10");
            //writer.WriteElementString("RAM", "16Gb");
            //writer.WriteElementString("HDD", "1Tb");
            //writer.WriteElementString("MotherBoard", "MSIB460");
            //writer.WriteElementString("VideoCard", "GTX 3060");
            //writer.WriteEndElement();
            //writer.WriteEndElement();
            //writer.Close();
        }

        static void Main21_10()
        {
            //foreach (var item in typeof(GoToCSharpStud.Student).GetCustomAttributes(false))
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var item in typeof(GoToCSharpStud.Student).GetMethods())
            //{
            //    Console.WriteLine();
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine("--------");
            //    foreach (var attr in item.GetCustomAttributes(false))
            //    {
            //        Console.WriteLine(attr);
            //    }
            //}

            GoToCSharpStud.Student st = new GoToCSharpStud.Student()
            {
                FirstName = "Olga",
                LastName = "Dubinkina",
                BirthDay = new DateTime(1988, 4, 13),
                StudentCard = new GoToCSharpStud.StudentCard
                {
                    Series = "BC",
                    Number = 123450
                }
            };

            //BinaryFormatter bin = new BinaryFormatter();
            //using (Stream stream = File.Create("../../SavingDocuments/stud.bin"))
            //{
            //    bin.Serialize(stream, st);
            //}


            //Student st1 = null;
            //using (Stream stream = File.OpenRead("../../SavingDocuments/stud.bin"))
            //{
            //    st1 = (Student)bin.Deserialize(stream);
            //}
            //Console.WriteLine(st1);

            //SoapFormatter soap = new SoapFormatter();
            //using (Stream stream = File.Create("../../SavingDocuments/stud.soap"))
            //{
            //    soap.Serialize(stream, st);
            //}

            //XmlSerializer xml = new XmlSerializer(typeof(Student));
            //using (Stream stream = File.Create("../../SavingDocuments/stud.xml"))
            //{
            //    xml.Serialize(stream, st);
            //}

            ////Student st1 = null;
            ////using (Stream stream = File.OpenRead("../../SavingDocuments/stud.xml"))
            ////{
            ////    st1 = (Student)xml.Deserialize(stream);
            ////}
            ////Console.WriteLine(st1);


            List<GoToCSharpStud.Student> students = new List<GoToCSharpStud.Student>
            {
                new    GoToCSharpStud.Student {
                    FirstName = "Fedot",
                    LastName = "Frolov",
                    BirthDay = new DateTime (1990, 10, 5),
                    StudentCard = new GoToCSharpStud.StudentCard
                    {
                        Series = "AB",
                        Number = 923456
                    }
                },
                new    GoToCSharpStud.Student
                {
                    FirstName = "Irina",
                    LastName = "Nikanorova",
                    BirthDay = new DateTime(1991, 10, 12),
                    StudentCard = new GoToCSharpStud.StudentCard
                    {
                        Series = "AB",
                        Number = 223456
                    }
                },
                new    GoToCSharpStud.Student
                {
                    FirstName = "Igor",
                    LastName = "Nikolaev",
                    BirthDay = new DateTime(1989, 8, 10),
                    StudentCard = new GoToCSharpStud.StudentCard
                    {
                        Series = "AC",
                        Number = 123454
                    }
                },
                new    GoToCSharpStud.Student
                {
                    FirstName = "Olga",
                    LastName = "Dubinkina",
                    BirthDay = new DateTime(1988, 4, 13),
                    StudentCard = new GoToCSharpStud.StudentCard
                    {
                        Series = "BC",
                        Number = 123450
                    }
                }
            };

            SoapFormatter soap = new SoapFormatter();
            using (Stream stream = File.Create("../../SavingDocuments/stud2.soap"))
            {
                soap.Serialize(stream, students);
            }

            //List<Student> st1 = null;
            //using (Stream stream = File.OpenRead("../../SavingDocuments/stud2.soap"))
            //{
            //    st1 = (List<Student>)soap.Deserialize(stream);
            //}

            //foreach (var item in st1)
            //{
            //    Console.WriteLine(item);
            //}

        }


        static void Main19_10()
        {
            string str = "ДОБрыЙ денЬ";
            //str.PrintColor(ConsoleColor.Cyan);
        }

        static void Main15_10()
        {
            List<GoToCSharpStud.Student> students = new List<GoToCSharpStud.Student>
            {
                new    GoToCSharpStud.Student {
                    FirstName = "Fedot",
                    LastName = "Frolov",
                    BirthDay = new DateTime (1990, 10, 5),
                    StudentCard = new GoToCSharpStud.StudentCard
                    {
                        Series = "AB",
                        Number = 923456
                    }
                },
                new    GoToCSharpStud.Student
                {
                    FirstName = "Irina",
                    LastName = "Nikanorova",
                    BirthDay = new DateTime(1991, 10, 12),
                    StudentCard = new GoToCSharpStud.StudentCard
                    {
                        Series = "AB",
                        Number = 223456
                    }
                },
                new    GoToCSharpStud.Student
                {
                    FirstName = "Igor",
                    LastName = "Nikolaev",
                    BirthDay = new DateTime(1989, 8, 10),
                    StudentCard = new GoToCSharpStud.StudentCard
                    {
                        Series = "AC",
                        Number = 123454
                    }
                },
                new    GoToCSharpStud.Student
                {
                    FirstName = "Olga",
                    LastName = "Dubinkina",
                    BirthDay = new DateTime(1988, 4, 13),
                    StudentCard = new GoToCSharpStud.StudentCard
                    {
                        Series = "BC",
                        Number = 123450
                    }
                }
            };

            GoToCSharpStud.Teacher teacher = new GoToCSharpStud.Teacher();

            foreach (var item in students)
            {
                teacher.ExamEvent += item.Exam;
            }

            //ExamDelegate exam = null;
            //exam += students[0].Exam;

            //exam(new DateTime(2021, 9, 18));


            teacher.SetExam(new DateTime(2021, 10, 15));

        }

        static void Main14_10()
        {
            //Point2D<int> p1 = new Point2D<int>();
            //Console.WriteLine(typeof(Point2D<int>));
            //MaxElem(p1);

            Calc calc = new Calc();

            string temp = Console.ReadLine();
            char oper = ' ';
            foreach (var i in temp)
            {
                if (i == '+' || i == '-' || i == '*')
                {
                    oper = i;
                    break;
                }
            }

            string[] numberms = temp.Split(oper);

            CalcDelegate del = null;

            switch (oper)
            {
                case '+':
                    del = new CalcDelegate(calc.Add);
                    break;
                case '-':
                    del = new CalcDelegate(Calc.Diff);
                    break;
                case '*':
                    del = new CalcDelegate(calc.Mult);
                    break;
                default: break;
            }

            Console.WriteLine(del(int.Parse(numberms[0]), int.Parse(numberms[1])));

        }

        static T MaxElem<T>(T[] arr) where T : IComparable
        {
            T max = arr[0];
            foreach (T item in arr)
            {
                if (item.CompareTo(max) > 0)
                    max = item;
            }
            return max;
        }


        static void Main12_10()
        {
            try
            {
                int a, b, res;
                a = int.Parse(Console.ReadLine());
                b = int.Parse(Console.ReadLine());
                res = a / b;
                Console.WriteLine(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }
            finally
            {
                Console.WriteLine("закрыли файл");
            }

        }

        static void Main07_10()
        {
            try
            {
                int a, b, res;
                a = int.Parse(Console.ReadLine());
                b = int.Parse(Console.ReadLine());
                res = a / b;
                Console.WriteLine(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }
            finally
            {
                Console.WriteLine("закрыли файл");
            }

        }

        static void Main05_10()
        {
            Manager manager = new Manager("Виктория", "Степанова", new DateTime(1973, 08, 1), 1500, 7);
            manager.Workers = new List<IWorker>
            {
                new Specialist("Семен", "Аниме", new DateTime(2007, 03, 8), 100, "Мидл пайтон"),
                new Marketer("Марк", "Маркович", new DateTime(1998, 06, 24), 5000, 19188)
            };
            manager.Planing();
            foreach (var item in manager.Workers)
            {
                Console.WriteLine(item.ToString());
                (item as Human).Think();
                item.Work();
            }
            manager.Control();
        }

        static void Main30_09()
        {
            //Employee emp1 = new Employee("Алекс", "Данько", new DateTime(2000, 02, 12), 800);
            //emp1.Print();
            //Console.WriteLine(" ");

            //Manager man1 = new Manager("Виктория", "Степанова", new DateTime(1973, 08, 1), 1500, 7);
            //man1.PrintManager();
            //Console.WriteLine(" ");

            //Specialist specialist1 = new Specialist("Семен", "Аниме", new DateTime(2007, 03, 8), 100, "Мидл пайтон");
            //specialist1.PrintSpecialist();
            //Console.WriteLine(" ");

            //Marketer marketer1 = new Marketer("Марк", "Маркович", new DateTime(1998, 06, 24), 5000, 19188);
            //marketer1.PrintMarketer();

            Employee[] employees = {
                new Specialist("Семен", "Аниме", new DateTime(2007, 03, 8), 100, "Мидл пайтон"),
                new Manager("Виктория", "Степанова", new DateTime(1973, 08, 1), 1500, 7),
                new Marketer("Марк", "Маркович", new DateTime(1998, 06, 24), 5000, 19188)
            };

            foreach (var item in employees)
            {
                item.Print();
                //-----------------------------
                //try
                //{
                //    ((Specialist)item).PrintSpecialist();
                //}
                //catch { }

                ////---------------------------
                //Manager manager = item as Manager;
                //if (manager != null)
                //    manager.PrintManager();


                ////---------------------------
                //if (item is Marketer)
                //    (item as Marketer).PrintMarketer();

                Console.WriteLine(" ");

            }


        }


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
            Console.Title = "Recording learning CSharp";

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


            StudentB student = new StudentB
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
            //StudentC student2 = new StudentC("Alex", 18);
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
