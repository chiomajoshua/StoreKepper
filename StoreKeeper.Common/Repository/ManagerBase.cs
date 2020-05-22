using Microsoft.EntityFrameworkCore;

namespace StoreKeeper.Common.Repository
{
    public class ManagerBase<TEntity> : SimpleRepository<TEntity> where TEntity : class
    {
        public ManagerBase(DbContext context) : base(context)
        {

        }
    }
}