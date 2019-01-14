using Base.Specification;
using DomainModel.StudentWeights;
using DomainModel.StudentWeightsImpl;
using Infrastructure.Base;
using System;
using System.Collections.Generic;

namespace Infrastructure.Trainers
{
    public class StudentWeightRepository : IStudentWeightRepository
    {
        private readonly Repository<StudentWeight> _repository;

        public StudentWeightRepository(Repository<StudentWeight> repository)
        {
            _repository = repository;
        }

        public StudentWeight FindById(Guid id)
        {
            return _repository.FindById(id);
        }

        public StudentWeight FindOne(ISpecification<StudentWeight> spec)
        {
            return _repository.FindOne(spec);
        }

        public IEnumerable<StudentWeight> Find(ISpecification<StudentWeight> spec)
        {
            return _repository.Find(spec);
        }

        public void Create(StudentWeight entity)
        {
            _repository.Create(entity);
        }

        public void Update(StudentWeight entity)
        {
            _repository.Update(entity);
        }

        public void Delete(StudentWeight entity)
        {
            _repository.Delete(entity);
        }
    }
}