using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoToCSharp
{
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

        public override string ToString()
        {
            return $"Name : {LastName} {FirstName}\nBirthDay : {BirthDay.ToShortDateString()}\n{StudentCard}\n\n";
        }

    }

    class Group : IEnumerable
    {
        Student[] students;

        public Group()
        {
            students = new Student[]
            {
                new Student {
                    FirstName = "Fedot",
                    LastName = "Frolov",
                    BirthDay = new DateTime (1990, 10, 5),
                    StudentCard = new StudentCard
                    {
                        Series = "AB",
                        Number = 923456
                    }
                },
                new Student
                {
                    FirstName = "Irina",
                    LastName = "Nikanorova",
                    BirthDay = new DateTime(1991, 10, 12),
                    StudentCard = new StudentCard
                    {
                        Series = "AB",
                        Number = 223456
                    }
                },
                new Student
                {
                    FirstName = "Igor",
                    LastName = "Nikolaev",
                    BirthDay = new DateTime(1989, 8, 10),
                    StudentCard = new StudentCard
                    {
                        Series = "AC",
                        Number = 123454
                    }
                },
                new Student
                {
                    FirstName = "Olga",
                    LastName = "Dubinkina",
                    BirthDay = new DateTime(1988, 4, 13),
                    StudentCard = new StudentCard
                    {
                        Series = "AC",
                        Number = 123450
                    }
                }
            };
        }

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