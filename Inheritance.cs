using System;
using System.Collections.Generic;

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








}