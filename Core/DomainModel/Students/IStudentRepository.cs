using DomainModel.StudentsImpl;
using System;
using System.Collections.Generic;

namespace DomainModel.Students
{
    public interface IStudentRepository
    {
        void Create(Student entity);
        void Delete(Student entity);
        IEnumerable<Student> FindAll();
        Student FindById(Guid id);
        void Update(Student entity);
    }
}
