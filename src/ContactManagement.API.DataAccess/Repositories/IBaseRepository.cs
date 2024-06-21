namespace ContactManagement.API.DataAccess.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        
        TEntity Update(TEntity entity);
        
        Task<bool> Delete<TKey>(TKey id);
        
        Task<TEntity> GetById<TKey>(TKey id);
        
        IQueryable<TEntity> AllAsQueryable();
        
        void SaveChanges();
    }
}