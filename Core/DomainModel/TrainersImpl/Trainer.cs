using Base.Domain;
using Base.DomainImpl;
using DomainModel.Trainers;
using System;

namespace DomainModel.TrainersImpl
{
    public class Trainer : IAggregateRoot, ITrainer
    {
        public virtual Guid Id { get; protected set; }
        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual double PayRate { get; protected set; }
        public virtual DateTime CreatedAt { get; protected set; }
        public virtual DateTime UpdatedAt { get; protected set; }
        public virtual bool IsActive { get; protected set; }

        public Trainer Create(string firstname, string lastname, string description, double payRate, bool isActive)
        {
            if (string.IsNullOrEmpty(firstname))
            {
                throw new ArgumentNullException("firstname");
            }

            if (string.IsNullOrEmpty(lastname))
            {
                throw new ArgumentNullException("lastname");
            }

            if (payRate < 0)
            {
                throw new Exception("payRate cannot be negative");
            }

            Trainer trainer = new Trainer()
            {
                Id = Guid.NewGuid(),
                FirstName = firstname,
                LastName = lastname,
                Description = description,
                PayRate = payRate,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = isActive
            };

            DomainEvents.Raise<TrainerCreated>(new TrainerCreated() { Trainer = trainer });

            return trainer;
        }
    }
}
