using Base.Specification;
using DomainModel.Trainers;
using DomainModel.TrainersImpl;
using Infrastructure.Base;
using System;
using System.Collections.Generic;

namespace Infrastructure.Trainers
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly Repository<Trainer> _repository;

        public TrainerRepository(Repository<Trainer> repository)
        {
            _repository = repository;
        }

        public Trainer FindById(Guid id)
        {
            return _repository.FindById(id);
        }

        public Trainer FindOne(ISpecification<Trainer> spec)
        {
            return _repository.FindOne(spec);
        }

        public IEnumerable<Trainer> Find(ISpecification<Trainer> spec)
        {
            return _repository.Find(spec);
        }

        public void Create(Trainer entity)
        {
            _repository.Create(entity);
        }

        public void Update(Trainer entity)
        {
            _repository.Update(entity);
        }

        public void Delete(Trainer entity)
        {
            _repository.Delete(entity);
        }
    }
}