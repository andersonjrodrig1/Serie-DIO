using Dio.Series.Classes;
using Dio.Series.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Dio.Series.Repositories
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> Series = new List<Serie>();

        public void Add(Serie entity) => Series.Add(entity);

        public void Delete(int id) => Series.Find(s => s.Id == id).Exclude();

        public IEnumerable<Serie> GetAll() => Series;

        public Serie GetById(int id) => Series.Find(s => s.Id == id);

        public int NextId() => Series.Count();

        public void Update(int id, Serie entity) => Series[id] = entity;
    }
}
