using DomainModel.Base;
using DomainModel.StudentsImpl;
using DomainModel.StudentWeightsImpl;
using System;
using System.Collections.Generic;

namespace DomainModel.StudentWeights
{
    public interface IStudentWeightRepository : IRepository<StudentWeight, Guid>
    {
        /// <summary>
        /// Return all weights by student
        /// </summary>
        /// <returns></returns>
        IEnumerable<StudentWeight> FindAll(Student student);
    }
}
