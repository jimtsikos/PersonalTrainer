using DAL.DAL;
using DomainModel.Students;
using DomainModel.StudentsImpl;
using Infrastructure.Base;
using System;

namespace Infrastructure.Trainers
{
    public class StudentRepository : Repository<Student, Guid>, IStudentRepository
    {
        public StudentRepository(TrainersContext context)
            : base(context)
        {
        }
    }
}