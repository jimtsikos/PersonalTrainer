using DomainModel.StudentsImpl;
using DomainModel.StudentWeightsImpl;
using System;
using System.Collections.Generic;

namespace DomainModel.Students
{
    public interface IStudent
    {
        Guid Id { get; }
        string FirstName { get; }
        string LastName { get; }
        string Description { get; }
        double Height { get; }
        double PayRate { get; }
        double PrepaidMoney { get; }
        DateTime CreatedAt { get; }
        DateTime UpdatedAt { get; }
        bool IsActive { get; }
        ICollection<StudentWeight> StudentWeights { get; }
        ICollection<LessonImpl.Lesson> Lessons { get; }

        Student Create(string firstname, string lastname, string description, double height, double payRate, double prepaidMoney, bool isActive);
    }
}