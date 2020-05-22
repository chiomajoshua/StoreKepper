using StoreKeeper.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreKeeper.Domain.Contract
{
    public interface IProductManager<T> where T : class
    {
        Task<bool> AddProduct(ProductViewModel productViewModel);
        //Task<bool> SubtractItem(string serialNumber, int quantity);
        Task<IEnumerable<T>> GetAllProducts();
    }
}