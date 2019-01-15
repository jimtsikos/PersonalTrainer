using DAL.DAL;
using DomainModel.Students;
using DomainModel.StudentsImpl;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return _context.Students
                           .Include(x => x.StudentWeights)
                           .Where(x => x.Id == id)
                           .SingleOrDefault();
        }

        public IEnumerable<Student> FindAll()
        {
            return _context.Students.Include(x => x.StudentWeights);
        }

        public void Create(Student entity)
        {
            _context.Students.Add(entity).Context.SaveChanges();
        }

        public void Update(Student entity)
        {
            _context.Students.Update(entity).Context.SaveChanges();
        }

        public void Delete(Student entity)
        {
            _context.Students.Remove(entity).Context.SaveChanges();
        }
    }
}