using System.Text.Json;
using System.Text.Json.Nodes;

namespace ContactManagement.API.DataAccess.Repositories
{
    public class JsonDataRespository<TEntity> : IJsonDataRespository<TEntity> where TEntity : class
    {
        internal List<TEntity>? dbSet = new List<TEntity>();
        private string _fileName = "mock.json";
        public JsonDataRespository()
        {
            var data = JsonNode.Parse(File.ReadAllText(_fileName));

            if (data != null)
            {
                dbSet = JsonSerializer.Deserialize<List<TEntity>>(data);
            }
        }

        public virtual TEntity Add(TEntity entity)
        {
            dbSet.Add(entity);

            return entity;
        }

        public virtual IEnumerable<TEntity> AsEnumerable()
        {
            return dbSet.AsEnumerable();
        }

        public virtual List<TEntity> AsList()
        {
            return dbSet;
        }

        public virtual bool Delete(Func<TEntity, bool> condition)
        {
            var entity = AsEnumerable().Where(condition).FirstOrDefault();

            if (entity != null)
            {
                dbSet.Remove(entity);

                return (true);
            }

            return false;
        }

        public void SaveChanges()
        {
            var newNode = JsonNode.Parse(JsonSerializer.Serialize(AsEnumerable()));


            File.WriteAllText(_fileName, newNode?.ToJsonString());
        }
    }
}
