using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GoToCSharp.TaskInvoicePayment
{
    [Serializable]
    class InvoicePayment : ISerializable
    {
        public int PaymentDay = 5; 
        public int PenaltyDay = 10;
        public int CountDay { get; set; }
        public int CountDelayPaymentDay { get; set; }

        private int payment;
        public int Payment
        {
            get { return  PaymentDay * PenaltyDay; }
            set { payment = value; }
        }

        private int penalty;
        public int Penalty
        {
            get { return CountDelayPaymentDay * PenaltyDay; }
            set { penalty = value; }
        }

        private int allPayment;
        public int AllPayment
        {
            get { return Payment + Penalty; }
            set { payment = value; }
        }

        //public static bool IsAll(bool ef)
        //{
        //    return true;
        //}

        private static bool isAll;
        public  bool IsAll
        {
            get { return isAll; }

            set { isAll = value; }
        }

        public InvoicePayment() { }

        public override string ToString()
        {
            return $"Оплата за день: {PaymentDay} | Количество дней {CountDay} | Штраф за день: {PenaltyDay} | Колв дней задержки {CountDelayPaymentDay}\n" +
                   $"К оплате без штрафа {Payment} | Штраф {Penalty} | К оплате {AllPayment} ";
        }

        private InvoicePayment(SerializationInfo info, StreamingContext contes)
        {
            PaymentDay = info.GetInt32("PaymentDay");
            CountDay = info.GetInt32("CountDay");
            PenaltyDay = info.GetInt32("PenaltyDay");
            CountDelayPaymentDay = info.GetInt32("CountDelayPaymentDay");

            if (IsAll)
            {
                Payment = info.GetInt32("Payment");
                Penalty = info.GetInt32("Penalty");
                AllPayment = info.GetInt32("AllPayment");
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PaymentDay", PaymentDay);
            info.AddValue("CountDay",CountDay);
            info.AddValue("PenaltyDay", PenaltyDay);
            info.AddValue("CountDelayPaymentDay", CountDelayPaymentDay);

            if (IsAll)
            {
                info.AddValue("Payment", Payment);
                info.AddValue("Penalty", Penalty);
                info.AddValue("AllPayment", AllPayment);
            }
        }
    }
}
