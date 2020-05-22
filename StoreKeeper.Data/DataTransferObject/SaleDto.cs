using System;

namespace StoreKeeper.Data.DataTransferObject
{
    public class SaleDto
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
    }
}