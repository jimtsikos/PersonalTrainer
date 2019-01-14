using Base.Domain;
using Base.Repository;
using Base.Specification;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
    {
        protected static List<TEntity> entities = new List<TEntity>();

        public TEntity FindById(Guid id)
        {
            return entities.Where(x => x.Id == id).FirstOrDefault();
        }

        public TEntity FindOne(ISpecification<TEntity> spec)
        {
            return entities.Where(spec.IsSatisfiedBy).FirstOrDefault();
        }

        public IEnumerable<TEntity> Find(ISpecification<TEntity> spec)
        {
            return entities.Where(spec.IsSatisfiedBy);
        }

        public void Create(TEntity entity)
        {
            entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            TEntity entityFound = FindById(entity.Id);
            entities.Remove(entityFound);
            entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            entities.Remove(entity);
        }
    }
}
