using Base.Specification;
using DomainModel.Lesson;
using DomainModel.LessonImpl;
using Infrastructure.Base;
using System;
using System.Collections.Generic;

namespace Infrastructure.Trainers
{
    public class LessonRepository : ILessonRepository
    {
        private readonly Repository<Lesson> _repository;

        public LessonRepository(Repository<Lesson> repository)
        {
            _repository = repository;
        }

        public Lesson FindById(Guid id)
        {
            return _repository.FindById(id);
        }

        public Lesson FindOne(ISpecification<Lesson> spec)
        {
            return _repository.FindOne(spec);
        }

        public IEnumerable<Lesson> Find(ISpecification<Lesson> spec)
        {
            return _repository.Find(spec);
        }

        public void Create(Lesson entity)
        {
            _repository.Create(entity);
        }

        public void Update(Lesson entity)
        {
            _repository.Update(entity);
        }

        public void Delete(Lesson entity)
        {
            _repository.Delete(entity);
        }
    }
}