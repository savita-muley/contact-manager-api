using Microsoft.EntityFrameworkCore;

namespace ContactManagement.API.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(DataContext context)
        {
            _context = context;
            dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            await dbSet.AddAsync(entity);

            return entity;
        }

        public virtual async Task<bool> Delete<TKey>(TKey id)
        {
            var entity = await GetById<TKey>(id);

            if (entity != null)
            {
                dbSet.Remove(entity);

                return (true);
            }
            return false;
        }

        public virtual TEntity Update(TEntity entity)
        {
            dbSet.Update(entity);

            return entity;
        }

        public virtual async Task<TEntity> GetById<TKey>(TKey id)
        {
            return await dbSet.FindAsync(id);
        }

        public IQueryable<TEntity> AllAsQueryable()
        {
            return dbSet.AsQueryable();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
