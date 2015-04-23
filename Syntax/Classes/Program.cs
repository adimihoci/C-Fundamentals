namespace Classes
{
    using System;

    public partial class Transaction {
        
        public decimal GetAmountWithoutTaxIfIsValid()
        {
            return this.Detail.IsValid == true ? this.AmountWithoutTax : 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Class, Object, Access modifiers,
            var t1 = new Transaction("T0001", DateTime.Now, 1000, (decimal)4.2, (int)CurrencyEnum.GBP, false);
            var t2 = new Transaction("T0002", DateTime.Now, 2000, (decimal)3.8, (int)CurrencyEnum.EURO, true);
            t1.ShowTransaction();
            Console.WriteLine("Amount without taxes for t1: {0}", t1.GetAmountWithoutTaxIfIsValid());
            Console.ReadKey();
            t2.ShowTransaction();
            Console.WriteLine("Amount without taxes for t2: {0}", t2.GetAmountWithoutTaxIfIsValid());
            Console.ReadKey();

            /* 
             * You can assign a value to a ReadOnly variable only in its declaration or in the constructor of a class or structure in which it is defined.
             * t1.amountWithoutTax = 10;
             */

            // deep copy:
            var t3 = (Transaction)t1.Clone();
            t3.TransactionCode = "T0003";
            t3.ShowTransaction();
            Console.ReadKey();

            // shallow copy:
            var t4 = t2;
            t4.TransactionCode = "T0004";
            t4.ShowTransaction();
            Console.ReadKey();

            t1.Detail.Amount = 6000;
            t2.Detail.Amount = 8000;
            Console.WriteLine("\n\n--==Deep Copy (t1 / t3)==--");
            t1.ShowTransaction();
            Console.ReadKey();
            t3.ShowTransaction();
            Console.ReadKey();
            Console.WriteLine("\n\n--==Shallow Copy (t2 / t4)==--");
            t2.ShowTransaction();
            Console.ReadKey();
            t4.ShowTransaction();            
            Console.ReadKey();
        }
    }
}
