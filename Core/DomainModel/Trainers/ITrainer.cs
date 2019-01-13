using DomainModel.TrainersImpl;
using System;

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
        //TODO: ICollection<Lesson> Lessons { get; set; }

        Trainer Create(string firstname, string lastname, string description, double payRate, bool isActive);
    }
}