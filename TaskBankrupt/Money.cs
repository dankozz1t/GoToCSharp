using System;
using System.Data;
using System.Runtime.Serialization;
using PU011_CSharp;

namespace GoToCSharp.TaskBankrupt
{
    public static class GoToStart
    {
        public static void Main(string[] args)
        {
            Console.Title = "Task_Banktor";

            try
            {
                Money moneyBase = new Money(50, 10);
                Money moneyNull = new Money();
                Money money = new Money();

                Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("---ОПЕРАЦИЯ МИНУСА---"); Console.WriteLine($"Базовая сумма: {moneyBase}");
                Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(" [-] Введите Доллары: ");
                money.Dollars = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(" [-] Введите Центы: ");
                money.Cents = Convert.ToInt32(Console.ReadLine());
                moneyNull = moneyBase - money;
                Console.WriteLine($" [=] {moneyBase} - {money}  = {moneyNull} ");

                Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\n---ОПЕРАЦИЯ ПЛЮСА---"); Console.WriteLine($"Базовая сумма: {moneyBase}");
                Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(" [+] Введите Доллары: ");
                money.Dollars = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(" [+] Введите Центы: ");
                money.Cents = Convert.ToInt32(Console.ReadLine());
                moneyNull = moneyBase + money;
                Console.WriteLine($" [=] {moneyBase} + {money}  = {moneyNull} ");

                int n = 0;
                Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\n---ОПЕРАЦИЯ ДЕЛЕНИЕ---"); Console.WriteLine($"Базовая сумма: {moneyBase}");
                Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(" [/] Введите Целое Число: ");
                n = Convert.ToInt32(Console.ReadLine());
                moneyNull = moneyBase / n;
                Console.WriteLine($" [=] {moneyBase} / {n}  = {moneyNull} ");


                Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\n---ОПЕРАЦИЯ УМНОЖЕНИЯ---"); Console.WriteLine($"Базовая сумма: {moneyBase}");
                Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(" [*] Введите Целое Число: ");
                n = Convert.ToInt32(Console.ReadLine());
                moneyNull = moneyBase * n;
                Console.WriteLine($" [=] {moneyBase} * {n}  = {moneyNull} ");


                Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\n---ОПЕРАЦИЯ МИНУСА---"); Console.WriteLine($"Базовая сумма: {moneyBase}");
                Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(" [-] Введите Доллары: ");
                money.Dollars = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(" [-] Введите Центы: ");
                money.Cents = Convert.ToInt32(Console.ReadLine());
                moneyNull = moneyBase - money;
                Console.WriteLine($" [=] {moneyBase} - {money}  = {moneyNull} ");
            }
            catch (BunkrutException e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }
            Console.ReadKey();
        }
    }

    public class Money
    {
        private int dollars;
        public int Dollars
        {
            get { return dollars; }
            set { dollars = value; }
        }

        private int cents;
        public int Cents
        {
            get { return cents; }
            set
            {
                cents = value;

                if ((dollars < 0 && cents < 0) || (dollars == 0 && cents == 0))
                    throw new BunkrutException();

                if (cents >= 100)
                {
                    for (int i = 0; cents >= 100; i++)
                    {
                        cents -= 100;
                        dollars++;
                    }
                }
            }
        }

        public Money()
        {
            dollars = 0;
            cents = 0;
        }

        public Money(int dollars, int cents)
        {
            Dollars = dollars;
            Cents = cents;
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return $"{Dollars},{Cents}$";
        }

        public static Money operator ++(Money money)
        {
            money.Dollars++;
            money.Cents++;
            return money;
        }

        public static Money operator --(Money money)
        {
            money.Dollars--;
            money.Cents--;
            return money;
        }

        public static Money operator -(Money money) => new Money(-money.Dollars, -money.Cents);

        public static Money operator +(Money m1, Money m2)=> new Money((m1.Dollars + m2.Dollars), (m1.Cents + m2.Cents));
        public static Money operator -(Money m1, Money m2) => new Money((m1.Dollars - m2.Dollars), (m1.Cents - m2.Cents));

        public static Money operator /(Money m1, int n) => new Money(m1.Dollars / n, m1.Cents / n);
        public static Money operator *(Money m1, int n) => new Money(m1.Dollars * n, m1.Cents * n);

        public static bool operator true(Money money) => money.dollars != 0 || money.cents != 0;
        public static bool operator false(Money money) => money.dollars == 0 && money.cents == 0;
     
        public static bool operator ==(Money money1, Money money2) => money1.Dollars == money2.Dollars && money1.Cents == money2.Cents;
        public static bool operator !=(Money money1, Money money2) => money1.Dollars != money2.Dollars && money1.Cents != money2.Cents;

        public static bool operator >(Money money1, Money money2) => money1.Dollars > money2.Dollars && money1.Cents > money2.Cents;
        public static bool operator <(Money money1, Money money2) => money1.Dollars < money2.Dollars && money1.Cents < money2.Cents;
    }

    [Serializable]
    public class BunkrutException : Exception
    {
        public BunkrutException() { }
        public BunkrutException(string message) : base(message) { }
        public BunkrutException(string message, Exception inner) : base(message, inner) { }
        protected BunkrutException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }

        public override string Message
        {
            get
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return " [!] ВЫ БАНКРОТ!";
            }
        }
    }
}