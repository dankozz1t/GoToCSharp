using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoToCSharp
{
    public abstract class Human
    {
        protected string Name;
        protected string Surname;
        protected DateTime Bd;

        public Human(string name, string surname, DateTime bd)
        {
            Name = name;
            Surname = surname;
            Bd = bd;
        }

        public abstract void Think();

        public virtual void Print()
        {
            Console.WriteLine($" |ЧЕЛОВЕК| = {Name} {Surname} | Дата рождения {Bd.ToShortDateString()}");
        }

    }

    public class Employee : Human
    {
        private int Salary;

        public Employee(string name, string surname, DateTime bd, int salary) : base(name, surname, bd)
        {
            Salary = salary;
        }

        public override void Think()
        {
            Console.WriteLine($" |СОТРУДНИК| ");
        }


        public override void Print()
        {
            base.Print();
            Console.WriteLine($" |СОТРУДНИК| Зарплата - {Salary}$");
        }
    }


    public class Manager : Employee, IManager
    {
        private int CountEmployee;

        public Manager(string name, string surname, DateTime bd, int salary, int countEmployee) : base(name, surname, bd, salary)
        {
            CountEmployee = countEmployee;
        }

        public List<IWorker> Workers { get; set; }

        public void Control()
        {
            Console.WriteLine("+ Я контролирую");
        }

        public void Planing()
        {
            Console.WriteLine("+ Я планирую");
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($" |МЕНЕДЖЕР| Количество сотрудников - {CountEmployee} ");
        }
    }

    public class Specialist : Employee, IWorker
    {
        private string Qualification;

        public Specialist(string name, string surname, DateTime bd, int salary, string qualification) : base(name, surname, bd, salary)
        {
            Qualification = qualification;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($" |СПЕЦИАЛИСТ| Квалификация - {Qualification} ");
        }

        public void Work()
        {
            Console.WriteLine("+Я работаю! (специалист)");
        }
    }

    public class Marketer : Employee, IWorker
    {
        private int CountSuccessfulDeals;

        public Marketer(string name, string surname, DateTime bd, int salary, int countSuccessfulDeals) : base(name, surname, bd, salary)
        {
            CountSuccessfulDeals = countSuccessfulDeals;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($" |МАРКЕТОЛОГ| Количество удачных сделок - {CountSuccessfulDeals} ");
        }

        public void Work()
        {
            Console.WriteLine("+Я работаю! (маркетолог)");
        }
    }


    /// <summary>
    /// Этот метод выводит строку в заданом цвете.
    /// </summary>
    /// <param name="color">В каком цвете выводит строку</param>
    /// <returns>Строка в нужном цвете и возращает ст</returns>
    static class MyString
    {
        public static void PrintColor(this string str, ConsoleColor color)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ForegroundColor = oldColor;
        }
    }


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ProgrammerAttribute : Attribute
    {
        private string name = "Alex";
        DateTime date = DateTime.Now;


        public ProgrammerAttribute(){}

        public ProgrammerAttribute(string n, string d)
        {
            name = n;
            date = Convert.ToDateTime(d);
        }

        public override string ToString()
        {
            return $"Програмист: {name} | дата: {date.ToShortDateString()}";
        }
    }

    public class People :ISerializable
    {
        protected string Name { get; set; }
        protected int Age { get; set; }
        protected int date { get { return Age * 365;} }

        public People(){}

        private People(SerializationInfo info, StreamingContext contes)
        {
            Name = info.GetString("MyName");
            Age = info.GetInt32("MyAge");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MyName", Name);
            info.AddValue("MyAge", Age);
        }
    }


}