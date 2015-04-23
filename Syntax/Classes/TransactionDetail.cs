namespace Classes
{
    public partial class TransactionDetail
    {
        public decimal? Amount;
        internal decimal? Tax;
        internal int? Currency;
        public bool? IsValid;
        const string Type = "Transaction";

        public override string ToString()
        {
            /*
             * In assignment, left side must be a variable, not constant.
             * this.type = "Payment";
             */
            var currentCurrency = (CurrencyEnum)this.Currency;

            return string.Format("{0}: {1}, Tax(%): {2}, Coin: {3}, Valid: {4}", Type,
                this.Amount, this.Tax, currentCurrency, this.IsValid.HasValue && (bool)this.IsValid ? string.Format("Yes") : string.Format("No"));

        }
    }

    public partial class TransactionDetail
    {
        public void exe()
        {
            System.Console.WriteLine("Hello");
        }
    }
}
