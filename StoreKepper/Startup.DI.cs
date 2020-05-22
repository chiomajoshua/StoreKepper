using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreKeeper.Common.Repository;
using StoreKeeper.Data.DataTransferObject;
using StoreKeeper.Data.Persistence;
using StoreKeeper.Domain.Contract;
using StoreKeeper.Domain.Repository;

namespace StoreKepper
{
    public partial class Startup
    {
        public IServiceCollection ConfigureDIServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserManager<UserDto>, UserManager>();
            serviceCollection.AddTransient<IProductManager<ProductDto>, ProductManager>();
            serviceCollection.AddTransient<DbContext, StoreKeeperDbContext>();           
            serviceCollection.AddScoped(typeof(ISimpleRepository<>), typeof(SimpleRepository<>));

            return serviceCollection;
        }
    }
}