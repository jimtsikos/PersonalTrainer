using Base.Specification;
using DomainModel.Students;
using DomainModel.StudentsImpl;
using Infrastructure.Base;
using System;
using System.Collections.Generic;

namespace Infrastructure.Trainers
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Repository<Student> _repository;

        public StudentRepository(Repository<Student> repository)
        {
            _repository = repository;
        }

        public Student FindById(Guid id)
        {
            return _repository.FindById(id);
        }

        public Student FindOne(ISpecification<Student> spec)
        {
            return _repository.FindOne(spec);
        }

        public IEnumerable<Student> Find(ISpecification<Student> spec)
        {
            return _repository.Find(spec);
        }

        public void Create(Student entity)
        {
            _repository.Create(entity);
        }

        public void Update(Student entity)
        {
            _repository.Update(entity);
        }

        public void Delete(Student entity)
        {
            _repository.Delete(entity);
        }
    }
}