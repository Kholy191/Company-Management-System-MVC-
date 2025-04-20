using Kholy.IKEA.DAL.Common.Entites;
using Microsoft.EntityFrameworkCore;

namespace Kholy.IKEA.DAL.Persistence.Repositories._Generic
{
    public interface IGenericRepository<T, K> where T : BaseEntity<K> where K : IEquatable<K>
    {
        public IEnumerable<T> GetAll(bool withTracking = false);
        public T? Get(K? id, bool withTracking = false);
        public void Add(T entity);
        void Update(T entity);
        public void Delete(K id);
        public IEnumerable<T> GetEnumerable();
        public IQueryable<T> GetQueryable();
    }
}
