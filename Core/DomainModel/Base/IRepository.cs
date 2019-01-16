using System.Collections.Generic;

namespace DomainModel.Base
{
    public interface IRepository<T, TId> where T : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Returns the number of entities available.
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Retrieves an entity by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T FindOne(TId id);

        /// <summary>
        /// Return all instances of the type
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();

        /// <summary>
        /// Saves a given entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Create(T entity);

        /// <summary>
        /// Updates the given entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Update(T entity);

        /// <summary>
        /// Returns whether an entity with the given id exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Exists(TId id);

        /// <summary>
        /// Deletes the given entity.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Deletes the entity with the given id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(TId id);
    }
}
