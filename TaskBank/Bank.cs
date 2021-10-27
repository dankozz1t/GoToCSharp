using System;

namespace GoToCSharp.Bank
{
    public class Bank
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Stan { get; set; }
        public DateTime DateStane { get; set; }

        public override string ToString()
        {
            string tbank = $" {Name.PadRight(26)} \n| {City.PadRight(5)} | {Adress.PadRight(5)} \n";
            tbank += $"| Статус: {Stan.ToString().PadRight(10)} =>";
            if (DateStane.Year == 0001)
                tbank += $" даты немає\n";
            else
                tbank += $" {DateStane.ToShortDateString().PadRight(26)} \n";

            return tbank;
        }
    }

}