using System;

namespace GoToCSharp.TaskBankrupt
{
    public static class GoToStart
    {
        public static void Main(string[] args)
        {
            Console.Title = "Task_Banktor";
            Console.WriteLine();


            Console.ReadKey();
        }
    }

    public class Money
    {
        private int dollar;

        public int Dollar
        {
            get { return dollar; }
            set { dollar = value; }
        }

        private int cents;
        public int Cents
        {
            get { return cents; }
            set { cents = value; }
        }

        public static Money operator ++(Money money)
        {
            money.Dollar++;
            return money;
        }

        public static Money operator --(Money money)
        {
            money.Dollar--;
            return money;
        }

        public static Money operator -(Money money)
        {
            return new Money { Dollar = -money.Dollar, Cents = -money.Cents };
        }

        public static Money operator +(Money m1, Money m2)
        {
            return new Money { Dollar = m1.Dollar + m2.Dollar, Cents = m1.Cents + m2.Cents };
        }

        public static Money operator -(Money m1, Money m2)
        {
            return new Money { Dollar = m1.Dollar - m2.Dollar, Cents = m1.Cents - m2.Cents };
        }

        public static Money operator /(Money m1, int n)
        {
            return new Money { Dollar = m1.Dollar / n, Cents = m1.Cents / n };
        }

        public static Money operator *(Money m1, int n)
        {
            return new Money { Dollar = m1.Dollar * n, Cents = m1.Cents * n };
        }
    }
}