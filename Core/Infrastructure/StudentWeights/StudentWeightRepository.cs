using DAL.DAL;
using DomainModel.StudentsImpl;
using DomainModel.StudentWeights;
using DomainModel.StudentWeightsImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Trainers
{
    public class StudentWeightRepository : IStudentWeightRepository
    {
        private readonly ITrainersContext _context;

        public StudentWeightRepository(ITrainersContext context)
        {
            _context = context;
        }

        public StudentWeight FindById(Guid id)
        {
            return _context.StudentWeights
                           .Include(x => x.Student)
                           .Where(x => x.Id == id)
                           .FirstOrDefault();
        }

        public IEnumerable<StudentWeight> FindAll(Student student)
        {
            return _context.StudentWeights.Select(x => x).Where(x => x.Student == student).Include(x => x.Student);
        }

        public void Create(StudentWeight entity)
        {
            _context.StudentWeights.Add(entity).Context.SaveChanges();
        }

        public void Update(StudentWeight entity)
        {
            _context.StudentWeights.Update(entity).Context.SaveChanges();
        }

        public void Delete(StudentWeight entity)
        {
            _context.StudentWeights.Remove(entity).Context.SaveChanges();
        }
    }
}