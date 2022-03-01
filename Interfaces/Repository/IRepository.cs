using System.Collections.Generic;

namespace Dio.Series.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Delete(int id);
        void Update(int id, TEntity entity);
        int NextId();
    }
}
