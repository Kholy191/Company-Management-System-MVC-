using Kholy.IKEA.DAL.Common.Entites;
using Kholy.IKEA.DAL.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Kholy.IKEA.DAL.Persistence.Repositories._Generic
{
    public class GenericRepository<T, K> : IGenericRepository<T, K> where T : BaseEntity<K> where K : IEquatable<K>
    {
        private protected ApplicationDbContext _DbContext;

        public GenericRepository(ApplicationDbContext context)
        {
            _DbContext = context;
        }
        public T? Get(K id, bool withTracking = false)
        {
            if (withTracking)
            {
                var Entity = _DbContext.Set<T>().Find(id);
                return Entity;
            }
            else
            {
                var Entity = _DbContext.Set<T>().AsNoTracking().FirstOrDefault(E => E.ID.Equals(id));
                return Entity;
            }

            //var Entity = _DbContext.departments.Local.FirstOrDefault(D => D.ID == id);
            //if (Entity == null)
            //{
            //    Entity = _DbContext.departments.Local.FirstOrDefault(D => D.ID == id);
            //}
        }

        public IEnumerable<T> GetAll(bool withTracking = false)
        {
            if (!withTracking)
            {
                return _DbContext.Set<T>().AsNoTracking();
            }
            return _DbContext.Set<T>().AsTracking();
        }

        public void Add(T entity)
        {
            _DbContext.Set<T>().Add(entity);
        }

        public void Delete(K? id)
        {
            var _entity = Get(id!);
            if (_entity != null)
            {
                _DbContext.Set<T>().Remove(_entity);
            }
        }

        public void Update(T entity)
        {
            _DbContext.Set<T>().Update(entity);
        }
    }
}
