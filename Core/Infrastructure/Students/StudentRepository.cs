using DAL.DAL;
using DomainModel.Students;
using DomainModel.StudentsImpl;
using System;
using System.Collections.Generic;

namespace Infrastructure.Trainers
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ITrainersContext _context;

        public StudentRepository(ITrainersContext context)
        {
            _context = context;
        }

        public Student FindById(Guid id)
        {
            return _context.Students.Find(id);
        }

        public IEnumerable<Student> FindAll()
        {
            return _context.Students;
        }

        public void Create(Student entity)
        {
            _context.Students.Add(entity);
        }

        public void Update(Student entity)
        {
            _context.Students.Update(entity);
        }

        public void Delete(Student entity)
        {
            _context.Students.Remove(entity);
        }
    }
}