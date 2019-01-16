using DAL.DAL;
using DomainModel.Students;
using DomainModel.StudentsImpl;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Trainers
{
    public class StudentRepository : Repository<Student, Guid>, IStudentRepository
    {
        public StudentRepository(TrainersContext context)
            : base(context)
        {
        }

        public override Student FindOne(Guid id)
        {
            return _trainersContext.Students
                                   .Include(x => x.Lessons)
                                   .Include(x => x.StudentWeights)
                                   .Select(x => x)
                                   .Where(x => x.Id == id)
                                   .FirstOrDefault();
        }

        public override IEnumerable<Student> FindAll()
        {
            return _trainersContext.Students
                                   .Include(x => x.Lessons)
                                   .Include(x => x.StudentWeights)
                                   .Select(x => x);
        }
    }
}