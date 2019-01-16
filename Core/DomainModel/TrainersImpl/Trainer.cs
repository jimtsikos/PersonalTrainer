using DomainModel.Base;
using DomainModel.Trainers;
using System;
using System.Collections.Generic;

namespace DomainModel.TrainersImpl
{
    public class Trainer : IAggregateRoot<Guid>, ITrainer
    {
        public virtual Guid Id { get; protected set; }
        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual double PayRate { get; protected set; }
        public virtual DateTime CreatedAt { get; protected set; }
        public virtual DateTime UpdatedAt { get; protected set; }
        public virtual bool IsActive { get; protected set; }

        public virtual ICollection<LessonImpl.Lesson> Lessons { get; protected set; }

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

            return trainer;
        }

        public Trainer Update(Trainer trainer, string firstname, string lastname, string description, double payRate, bool isActive)
        {
            if (trainer == null)
            {
                throw new ArgumentNullException("trainer");
            }

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

            trainer.FirstName = firstname;
            trainer.LastName = lastname;
            trainer.Description = description;
            trainer.PayRate = payRate;
            trainer.IsActive = isActive;
            trainer.UpdatedAt = DateTime.UtcNow;

            return trainer;
        }
    }
}
