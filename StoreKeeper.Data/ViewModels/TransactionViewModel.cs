using System;

namespace StoreKeeper.Data.ViewModels
{
    public class TransactionViewModel
    {
        public double Amount { get; set; }
        public string TransactionType { get; set; }
        public string Item { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}