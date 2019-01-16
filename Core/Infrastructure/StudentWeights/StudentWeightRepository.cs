using DAL.DAL;
using DomainModel.StudentWeights;
using DomainModel.StudentWeightsImpl;
using System;
using Infrastructure.Base;
using DomainModel.StudentsImpl;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Trainers
{
    public class StudentWeightRepository : Repository<StudentWeight,Guid>, IStudentWeightRepository
    {
        public StudentWeightRepository(TrainersContext context)
            : base(context)
        {
        }

        public override StudentWeight FindOne(Guid id)
        {
            return _trainersContext.StudentWeights
                                   .Include(x => x.Student)
                                   .Select(x => x)
                                   .Where(x => x.Id == id)
                                   .FirstOrDefault();
        }

        public override IEnumerable<StudentWeight> FindAll()
        {
            return _trainersContext.StudentWeights
                                   .Include(x => x.Student)
                                   .Select(x => x);
        }

        public IEnumerable<StudentWeight> FindAll(Student student)
        {
            return _trainersContext.StudentWeights
                                   .Include(x => x.Student)
                                   .Select(x => x)
                                   .Where(x => x.Student == student);
        }
    }
}