using System;

namespace StoreKeeper.Data.ViewModels
{
    public class SaleViewModel
    {
        public string SerialNumber { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
    }
}