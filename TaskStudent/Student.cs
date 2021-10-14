using System;
using System.Collections;
using PU011_CSharp;

namespace GoToCSharp.TaskStudent
{
    class GoToStart
    {
        static void MainStudentMark(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "Task Student Mark";

            Hashtable group = new Hashtable();

            group.Add(new Student
            {
                FirstName = "Вика",
                LastName = "Крысенко",
                BirthDay = new DateTime(2000, 10, 12),
                StudentCard = new StudentCard
                {
                    Series = "AB",
                    Number = 223456
                }
            }, new ArrayList());
            group.Add(new Student
            {
                FirstName = "Семен",
                LastName = "Маркович",
                BirthDay = new DateTime(2005, 8, 10),
                StudentCard = new StudentCard
                {
                    Series = "AC",
                    Number = 123456
                }
            }, new ArrayList());

            string[] menu = { "Добавить студента", "Выставить оценки студенту", "Показать группу", "Выход" };
            int pos = 0;

            while (pos != 3)
            {
                pos = Menu.VerticalMenu(menu);

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                switch (pos)
                {
                    case 0:
                        Console.Write("Введите имя: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Введите фамилию: ");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Введите Дату рождения студента");
                        Console.Write("Год: ");
                        int year = int.Parse(Console.ReadLine());
                        Console.Write("Месяц: ");
                        int month = int.Parse(Console.ReadLine());
                        Console.Write("День: ");
                        int day = int.Parse(Console.ReadLine());

                        Console.WriteLine("Заполните студенческую карточку");
                        Console.Write("Серия: ");
                        string seriesCard = Console.ReadLine();
                        Console.Write("Номер: ");
                        int numberCard = int.Parse(Console.ReadLine());

                        group.Add(new Student
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            BirthDay = new DateTime(year, month, day),
                            StudentCard = new StudentCard
                            {
                                Series = seriesCard,
                                Number = numberCard
                            }

                        }, new ArrayList());

                        break;
                    case 1:
                        Console.Write("Введите фамилию студента: ");
                        string lName = Console.ReadLine();
                        Console.Write("Введите оценку: ");
                        int mark = int.Parse(Console.ReadLine());
                        foreach (Student item in group.Keys)
                        {
                            if (item.LastName == lName)
                            {
                                (group[item] as ArrayList).Add(mark);
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("------------------------------------------");
                        foreach (Student student in group.Keys)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(student);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("Успеваемость: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            foreach (int imark in group[student] as ArrayList)
                            {
                                if(imark > 5)
                                    Console.ForegroundColor = ConsoleColor.Green;
                                else
                                    Console.ForegroundColor = ConsoleColor.Red;
                                
                                Console.Write(imark + ", ");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            Console.WriteLine("\n------------------------------------------");
                        }
                        Console.ReadKey();
                        break;
                }
            }
            Console.Read();
        }
    }



    class StudentCard
    {
        public string Series { get; set; }
        public int Number { get; set; }

        public override string ToString()
        {
            return $"Студенческий билет: {Series} - {Number}";
        }
    }
    class Student : IComparable, ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public StudentCard StudentCard { get; set; }

        public static IComparer SortByDate
        {
            get { return (IComparer)new DateComparer(); }
        }
        public object Clone()
        {
            Student temp = (Student)this.MemberwiseClone();
            temp.StudentCard = new StudentCard
            {
                Series = this.StudentCard.Series,
                Number = this.StudentCard.Number
            };
            return temp;
        }

        public int CompareTo(object obj)
        {
            if (obj is Student)
            {
                return LastName.CompareTo((obj as Student).LastName);
            }
            throw new NotImplementedException();
        }

        public string ShortName()
        {
            return $"{LastName} {FirstName}";
        }

        public override string ToString()
        {
            return $"ФИО : {LastName} {FirstName}\nДата рождения : {BirthDay.ToShortDateString()}\n{StudentCard}\n";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }

    class Group : IEnumerable
    {
        Student[] students;

        public IEnumerator GetEnumerator()
        {
            return students.GetEnumerator();
        }

        public void Sort()
        {
            Array.Sort(students);
        }

        public void Sort(IComparer comparer)
        {
            Array.Sort(students, comparer);
        }
    }


    class DateComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return DateTime.Compare((x as Student).BirthDay, (y as Student).BirthDay);
            }

            throw new NotImplementedException();
        }
    }

    class StudCardComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                if ((x as Student).StudentCard.Series != (y as Student).StudentCard.Series)
                {
                    return (x as Student).StudentCard.Series.CompareTo((y as Student).StudentCard.Series);
                }
                else
                {
                    return (x as Student).StudentCard.Number.CompareTo((y as Student).StudentCard.Number);
                }
            }
            throw new NotImplementedException();
        }
    }
}