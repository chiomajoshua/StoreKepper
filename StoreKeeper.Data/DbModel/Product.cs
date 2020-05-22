using System;

namespace StoreKeeper.Data.DbModel
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SupplyMeasurement { get; set; }
        public int Quantity { get; set; }
        public string SuppliedBy { get; set; }
        public string SerialNumber { get; set; }
        public DateTime DateSupplied { get; set; }
        public DateTime ExpiryDate { get; set; }
        public double PricePerUnit { get; set; }
    }
}