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

        public IEnumerable<StudentWeight> FindAll(Student student)
        {
            return _trainersContext.StudentWeights
                                   .Select(x => x)
                                   .Where(x => x.Student == student)
                                   .Include(x => x.Student);
        }
    }
}