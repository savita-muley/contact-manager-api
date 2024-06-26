namespace ContactManagement.API.DataAccess.Repositories
{
    public interface IJsonDataRespository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> AsEnumerable();
        List<TEntity> AsList();
        TEntity Add(TEntity entity);
        bool Delete(Func<TEntity, bool> condition);
        void SaveChanges();
    }
}
