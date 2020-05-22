using StoreKeeper.Data.ViewModels;
using System.Threading.Tasks;

namespace StoreKeeper.Domain.Contract
{
    public interface IUserManager<T> where T : class
    {
        Task<T> Login(LoginViewModel loginViewModel);
    }
}