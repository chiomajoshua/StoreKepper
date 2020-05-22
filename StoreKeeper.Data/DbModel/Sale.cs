using System;

namespace StoreKeeper.Data.DbModel
{
    public class Sale
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
    }
}