namespace Classes
{
    using System;

    public partial class Transaction : ITransaction, ICloneable
    {
        internal string TransactionCode { get; set; }
        internal DateTime? Date;
        internal TransactionDetail Detail { get; set; }
        internal readonly decimal AmountWithoutTax; 

        public Transaction()
        {
            TransactionCode = null;
            Date = null;
            AmountWithoutTax = 0;
            Detail = new TransactionDetail
            {
                Amount = null,
                Tax = null,
                Currency = null,
                IsValid = null
            };
        }

        public Transaction(string tCode, DateTime date, decimal sum, decimal tax, int currency, bool isValid)
        {
            this.TransactionCode = tCode;
            this.Date = date;
            Detail = new TransactionDetail
            {
                Amount = sum,
                Tax = tax,
                Currency = currency,
                IsValid = isValid
            };
            AmountWithoutTax = this.Detail.Amount != null && this.Detail.Tax != null ? (decimal)(this.Detail.Amount * (1 - this.Detail.Tax / 100)) : 0; 
        }

        public Transaction(string tCode, DateTime date, TransactionDetail td)
        {
            this.TransactionCode = tCode;
            this.Date = date;
            Detail = new TransactionDetail
            {
                Amount = td.Amount,
                Tax = td.Tax,
                Currency = td.Currency,
                IsValid = td.IsValid
            };
            AmountWithoutTax = this.Detail.Amount != null && this.Detail.Tax != null ? (decimal)(this.Detail.Amount * (1 - this.Detail.Tax / 100)) : 0; 
        }

        public Transaction(Transaction t)
        {
            this.TransactionCode = t.TransactionCode;
            this.Date = t.Date;
            Detail = new TransactionDetail
            {
                Amount = t.Detail.Amount,
                Tax = t.Detail.Tax,
                Currency = t.Detail.Currency,
                IsValid = t.Detail.IsValid
            };
            AmountWithoutTax = this.Detail.Amount != null && this.Detail.Tax != null ? (decimal)(this.Detail.Amount * (1 - this.Detail.Tax / 100)) : 0; 
        }

        /*
         * ICloneable implementation
         */

        public object Clone()
        {
            #region shallow copy
            /*
             * The MemberwiseClone method creates a shallow copy by creating a new object, 
             * and then copying the nonstatic fields of the current object to the new object. 
             * If a field is a value type, a bit-by-bit copy of the field is performed. 
             * If a field is a reference type, the reference is copied but the referred object is not; therefore, 
             * the original object and its clone refer to the same object.
             */
            // return this.MemberwiseClone();
            #endregion

            #region deep copy
            var t = new Transaction
            {
                TransactionCode = this.TransactionCode,
                /* 
                 * You can assign a value to a ReadOnly variable only in its declaration or in the constructor of a class or structure in which it is defined.
                 */
                //date = this.date,
                Detail = new TransactionDetail
                {
                    Amount = this.Detail.Amount,
                    Tax = this.Detail.Tax,
                    Currency = this.Detail.Currency,
                    IsValid = this.Detail.IsValid
                }
            };
            return t;
            #endregion
        }




        /*
         * ITransaction implementation:
         */

        public decimal GetAmount()
        {
            return this.Detail.Amount ?? 0;
        }

        public void ShowTransaction()
        {
            Console.WriteLine("\nTransaction: {0}", TransactionCode);
            Console.WriteLine("Date: {0}", Date);
            Console.WriteLine("Amount: {0}", GetAmount());
            Console.WriteLine("Transaction detail: {0}", Detail.exe());
        }

    }
}
