using DomainModel.StudentsImpl;
using DomainModel.StudentWeightsImpl;
using System;
using System.Collections.Generic;

namespace DomainModel.StudentWeights
{
    public interface IStudentWeightRepository
    {
        void Create(StudentWeight entity);
        void Delete(StudentWeight entity);
        IEnumerable<StudentWeight> FindAll(Student student);
        StudentWeight FindById(Guid id);
        void Update(StudentWeight entity);
    }
}
