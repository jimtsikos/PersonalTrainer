using DomainModel.TrainersImpl;
using System;
using System.Collections.Generic;

namespace DomainModel.Trainers
{
    public interface ITrainer
    {
        Guid Id { get; }
        string FirstName { get; }
        string LastName { get; }
        string Description { get; }
        double PayRate { get; }
        DateTime CreatedAt { get; }
        DateTime UpdatedAt { get; }
        bool IsActive { get; }
        ICollection<LessonImpl.Lesson> Lessons { get; }

        Trainer Create(string firstname, string lastname, string description, double payRate, bool isActive);
    }
}