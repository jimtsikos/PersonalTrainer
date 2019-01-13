using Base.Domain;
using Base.DomainImpl;
using DomainModel.StudentWeights;
using System;

namespace DomainModel.StudentWeightsImpl
{
    public class StudentWeight : IAggregateRoot, IStudentWeight
    {
        public Guid Id { get; protected set; }

        public Guid StudentId { get; protected set; }

        public double Weight { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        public DateTime UpdatedAt { get; protected set; }

        public StudentWeight Create(Guid studentId, double weight)
        {
            if (studentId != Guid.Empty)
            {
                throw new ArgumentNullException("studentId cannot be empty");
            }

            if (weight < 0)
            {
                throw new Exception("weight cannot be negative");
            }

            StudentWeight studentWeight = new StudentWeight()
            {
                Id = Guid.NewGuid(),
                StudentId = studentId,
                Weight = weight,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            DomainEvents.Raise<StudentWeightCreated>(new StudentWeightCreated() { StudentWeight = studentWeight });

            return studentWeight;
        }
    }
}
