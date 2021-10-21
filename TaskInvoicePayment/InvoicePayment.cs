using System;
using System.Runtime.Serialization;


namespace GoToCSharp.TaskInvoicePayment
{
    [Serializable]
    class InvoicePayment : ISerializable
    {
        public static bool IsAll;

        public int PaymentDay = 5; 
        public int PenaltyDay = 10;
        public int CountDay { get; set; }
        public int CountDelayPaymentDay { get; set; }

        private int payment;
        public int Payment
        {
            get => PaymentDay * PenaltyDay;
            set => payment = value; 
        }

        private int penalty;
        public int Penalty
        {
            get => CountDelayPaymentDay * PenaltyDay;
            set => penalty = value;
        }

        private int allPayment;
        public int AllPayment
        {
            get => Payment + Penalty;
            set => payment = value;
        }

        
        public InvoicePayment() { }

        public override string ToString()
        {
            string str = $"Оплата за день: {PaymentDay} | Количество дней {CountDay} | Штраф за день: {PenaltyDay} | Колв дней задержки {CountDelayPaymentDay}\n";

            if(IsAll)
                str += $"К оплате без штрафа {Payment} | Штраф {Penalty} | К оплате {AllPayment} ";

            return str;
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
