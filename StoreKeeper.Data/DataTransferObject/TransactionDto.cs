using System;
using System.Collections.Generic;
using System.Text;

namespace StoreKeeper.Data.DataTransferObject
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public string TransactionType { get; set; }
        public string Item { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}