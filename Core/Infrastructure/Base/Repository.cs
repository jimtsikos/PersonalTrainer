using DAL.DAL;
using DomainModel.Base;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Base
{
    public class Repository<T, TId> : IRepository<T, TId> where T : class, IAggregateRoot<TId>
    {
        protected TrainersContext _trainersContext;

        public Repository(TrainersContext trainersContext)
        {
            _trainersContext = trainersContext;
        }

        public virtual int Count()
        {
            return _trainersContext.Set<T>().Count();
        }

        public virtual T FindOne(TId id)
        {
            return _trainersContext.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> FindAll()
        {
            return _trainersContext.Set<T>().Select(x => x);
        }

        public virtual bool Exists(TId id)
        {
            var entity = FindOne(id);
            return entity != null;
        }

        public virtual void Create(T entity)
        {
            _trainersContext.Set<T>().Add(entity);
            _trainersContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _trainersContext.Set<T>().Update(entity);
            _trainersContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _trainersContext.Set<T>().Remove(entity);
            _trainersContext.SaveChanges();
        }

        public virtual void Delete(TId id)
        {
            var entity = FindOne(id);
            _trainersContext.Set<T>().Remove(entity);
            _trainersContext.SaveChanges();
        }
    }
}
