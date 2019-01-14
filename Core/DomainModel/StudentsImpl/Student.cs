using Base.Domain;
using Base.DomainImpl;
using DomainModel.Students;
using DomainModel.StudentWeightsImpl;
using System;
using System.Collections.Generic;

namespace DomainModel.StudentsImpl
{
    public class Student : IAggregateRoot, IStudent
    {
        public Guid Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Description { get; protected set; }
        public double Height { get; protected set; }
        public double PayRate { get; protected set; }
        public double PrepaidMoney { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public bool IsActive { get; protected set; }
        public ICollection<StudentWeight> StudentWeights { get; protected set; }

        public Student Create(string firstname, string lastname, string description, double height, double payRate, double prepaidMoney, bool isActive)
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

            if (prepaidMoney < 0)
            {
                throw new Exception("prepaidMoney cannot be negative");
            }

            Student student = new Student()
            {
                Id = Guid.NewGuid(),
                FirstName = firstname,
                LastName = lastname,
                Description = description,
                Height = height,
                PayRate = payRate,
                PrepaidMoney = prepaidMoney,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = isActive
            };

            DomainEvents.Raise<StudentCreated>(new StudentCreated() { Student = student });

            return student;
        }
    }
}
