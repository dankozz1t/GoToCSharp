using System;

namespace TestWork
{

    interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }

        void output();
        void sing();
    }

    //------------------------------------------------

    class Student : IPerson
    {
        public Student(string firstName, string lastName, DateTime dateOfBirth, int year, string studID)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.year = year;
            this.studID = studID;
        }

        //Properties
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private DateTime dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        private string studID;

        public string StudID
        {
            get { return studID; }
            set { studID = value; }
        }


        public void sing()
        {

        }

        public void output()
        {
            ConsoleMenu.Print($"{this.GetType().Name}: {this.firstName}{this.lastName}" +
                              $"\n {{ \n firstName: {firstName}" +
                              $"\n lastName: {lastName}" +
                              $"\n dateOfBirth: {dateOfBirth.ToShortDateString()}" +
                              $"\n year: {year}" +
                              $"\n studID: {studID} \n }}");
        }

    }

    //------------------------------------------------
    public static class ConsoleMenu
    {
        public static void Print(params string[] args)
        {
            foreach (string item in args)
                Console.Write(item);
        }

        public static void PrintLine(params string[] args)
        {
            foreach (string item in args)
                Console.WriteLine(item);
        }

        public static string ReadString()
        {
            return Console.ReadLine();

        }

        public static int ReadInt()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        public static DateTime ReadDateTime()
        {
            return Convert.ToDateTime(Console.ReadLine());
        }

    }
}