using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreKeeper.Common.Repository
{
    public class SimpleRepository<TEntity> : ISimpleRepository<TEntity> where TEntity : class
    {
        internal DbContext _context;
        internal DbSet<TEntity> _entity;
        private bool isBatch;

        public int ChangeCount;

        public SimpleRepository(DbContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }

        public void BeginTransaction()
        {
            isBatch = true;
            _context.Database.BeginTransaction();
        }

        public bool CommitTransaction()
        {
            return Commit(false).Result;
        }

        public async Task<bool> CommitTransactionAsync()
        {
            return await Commit(true);
        }

        async Task<bool> Commit(bool isAsync)
        {
            try
            {
                if (!isBatch) return false;
                if (isAsync)
                    await SaveAsync();
                else
                    Save();
                _context.Database.CommitTransaction();
                isBatch = false;
                return true;
            }
            catch (Exception)
            {
                this.RollbackTransaction();
                return false;
            }
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public int Count()
        {
            return _entity.Count();
        }

        public async Task<int> CountAsync()
        {
            return await _entity.CountAsync();
        }

        public int Count(Expression<Func<TEntity, bool>> filter)
        {
            return _entity.Count(filter);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _entity.CountAsync(filter);
        }

        public TEntity GetById(object id)
        {
            return _entity.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _entity.FindAsync(id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _entity.FirstOrDefault(filter);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _entity;

            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return await query.FirstOrDefaultAsync(filter);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entity.AsQueryable<TEntity>();
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(_entity.AsQueryable<TEntity>());
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return _entity.Where(filter).AsQueryable();
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Task.FromResult(_entity.Where(filter).AsQueryable());
        }

        public async Task<bool> SaveAsync()
        {
            ChangeCount = await _context.SaveChangesAsync();
            return ChangeCount > 0;
        }

        public bool Save()
        {
            ChangeCount = _context.SaveChanges();
            return ChangeCount > 0;
        }

        public bool Remove(TEntity entity)
        {
            UpdateEntityState(entity, EntityState.Detached);
            _context.Remove(entity);
            return Save();
        }

        public bool Remove(object id)
        {
            var entity = _entity.Find(id);
            if (entity == null) return false;

            UpdateEntityState(entity, EntityState.Detached);
            _context.Remove(entity);
            return Save();
        }

        public bool AddRange(IEnumerable<TEntity> entity)
        {
            _entity.AddRange(entity);
            if (isBatch) return true;
            return Save();
        }

        public async Task<bool> AddRangeAsync(IEnumerable<TEntity> entity)
        {
            await _entity.AddRangeAsync(entity);
            if (isBatch) return true;
            return await SaveAsync();
        }

        public bool Add(TEntity entity)
        {
            _entity.Add(entity);
            if (isBatch) return true;
            return Save();
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);
            if (isBatch) return true;
            return await SaveAsync();
        }

        public bool Update(TEntity entity)
        {
            UpdateEntityState(entity, EntityState.Modified);
            return Save();
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            UpdateEntityState(entity, EntityState.Modified);
            return await SaveAsync();
        }

        public bool Delete(TEntity entity)
        {
            if (entity == null) return false;

            UpdateEntityState(entity, EntityState.Deleted);
            return Save();
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            UpdateEntityState(entity, EntityState.Deleted);
            if (isBatch) return true;
            return await SaveAsync();
        }

        public bool Delete(object id)
        {
            var entity = _entity.Find(id);
            if (entity == null) return false;

            UpdateEntityState(entity, EntityState.Deleted);
            if (isBatch) return true;
            return Save();
        }

        public async Task<bool> DeleteAsync(object id)
        {
            var entity = _entity.Find(id);
            if (entity == null) return false;

            UpdateEntityState(entity, EntityState.Deleted);
            if (isBatch) return true;
            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entity = _entity.FirstOrDefault(filter);
            if (entity == null) return false;

            UpdateEntityState(entity, EntityState.Deleted);
            if (isBatch) return true;
            return await SaveAsync();
        }

        public bool Delete(Expression<Func<TEntity, bool>> filter)
        {
            var entity = _entity.FirstOrDefault(filter);
            if (entity == null) return false;

            UpdateEntityState(entity, EntityState.Deleted);
            if (isBatch) return true;
            return Save();
        }

        public void UpdateEntityState(TEntity entity, EntityState entityState)
        {
            var dbEntityEntry = GetDbEntityEntry(entity);
            dbEntityEntry.State = entityState;
        }

        public EntityEntry GetDbEntityEntry(TEntity entity)
        {
            var dbEntityEntry = _context.Entry<TEntity>(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                _context.Set<TEntity>().Attach(entity);
            }
            return dbEntityEntry;
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
                return _entity.FirstOrDefault();
            else
                return _entity.FirstOrDefault(filter);
        }

        public TEntity LastOrDefault(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
                return _entity.LastOrDefault();
            else
                return _entity.LastOrDefault(filter);
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}
