using DomainModel.Base;
using DomainModel.StudentsImpl;
using System;
using System.Collections.Generic;

namespace DomainModel.Students
{
    public interface IStudentRepository : IRepository<Student, Guid>
    {
        /// <summary>
        /// Return all students based on their name
        /// </summary>
        /// <param name="searchString">The name of students</param>
        /// <returns>Students based on their name</returns>
        IEnumerable<Student> FindByName(string name);
    }
}
