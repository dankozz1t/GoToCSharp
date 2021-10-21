using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace GoToCSharp.TaskInvoicePayment
{
    public class MainInvoicePayment
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "Task Invoice for payment";

            InvoicePayment p = new InvoicePayment { CountDay = 2, CountDelayPaymentDay = 1, };
            p.IsAll = true;

            Console.WriteLine(p);

            SoapFormatter soap = new SoapFormatter();
            //using (Stream stream = File.Create("payment.soap"))
            //{
            //    soap.Serialize(stream, p);
            //}

            InvoicePayment p2 = null;
            using (Stream stream = File.OpenRead("payment.soap"))
            {
                p2 = (InvoicePayment)soap.Deserialize(stream);
            }
            Console.WriteLine(p2);

            Console.ReadKey();
        }
    }
}