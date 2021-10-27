using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using PU011_CSharp;

namespace GoToCSharp.Bank
{
    public class MainBank
    {
        public void Show(IEnumerable<Bank> banks)
        {
            int count = 1;
            foreach (var bank in banks)
            {
                Console.WriteLine(count.ToString() + bank);
                count++;
            }
        }

        public void mainBank()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "Task Bank Parser";

            XmlDocument doc = new XmlDocument();
            doc.Load(@"https://bank.gov.ua/NBU_BankInfo/get_data_branch?typ=0");


            XmlNodeList n_NAME = doc.GetElementsByTagName("N_GOL");
            XmlNodeList n_CITY = doc.GetElementsByTagName("N_OBL");
            XmlNodeList n_ADDRESS = doc.GetElementsByTagName("ADRESS");
            XmlNodeList nGLOBAL_STAN = doc.GetElementsByTagName("NSTAN_GOL");
            XmlNodeList nD_STAN = doc.GetElementsByTagName("D_STAN");

            List<Bank> banks = new List<Bank>();

            for (int i = 0; i < n_NAME.Count; i++)
            {
                Bank bank = new Bank
                {
                    Name = n_NAME[i].InnerText,
                    City = n_CITY[i].InnerText,
                    Adress = n_ADDRESS[i].InnerText,
                    Stan = nGLOBAL_STAN[i].InnerText,
                };

                if (nD_STAN[i].InnerText != "")
                {
                    bank.DateStane =
                        DateTime.ParseExact(nD_STAN[i].InnerText, "dd.MM.yyyy", CultureInfo.CurrentCulture);
                }

                banks.Add(bank);
            }


            var liquidationBanks = from b in banks
                                   where b.Stan == "Режим ліквідації"
                                   select b;


            var liquidationBanksThisYear = from b in banks
                                           where b.Stan == "Режим ліквідації" && b.DateStane.Year == DateTime.Now.Year
                                           select b;

            int pos = 0;
            string[] menu = { "Все банки", "В ликвидации", "В ликвидации этого года", "Выход" };
            while (pos != 3)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("БАНКИ!");
                pos = Menu.VerticalMenu(menu);

                if (pos == 0) Show(banks);
                else if (pos == 1) Show(liquidationBanks);
                else if (pos == 2) Show(liquidationBanksThisYear);

                Console.ReadKey();
            }

            Console.Read();
        }
    }
}