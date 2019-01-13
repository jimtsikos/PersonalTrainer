using DomainModel.StudentsImpl;
using System;

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
        //TODO: ICollection<StudentWeight> StudentWeights { get; set; }
        //TODO: ICollection<Lesson> Lessons { get; set; }

        Student Create(string firstname, string lastname, string description, double height, double payRate, double prepaidMoney, bool isActive);
    }
}