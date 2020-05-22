using System;

namespace StoreKeeper.Data.DbModel
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public string TransactionType { get; set; }
        public string Item { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}