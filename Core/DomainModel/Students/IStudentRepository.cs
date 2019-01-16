using DomainModel.Base;
using DomainModel.StudentsImpl;
using System;

namespace DomainModel.Students
{
    public interface IStudentRepository : IRepository<Student, Guid>
    {
        
    }
}
