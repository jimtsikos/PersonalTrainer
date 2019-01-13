using DomainModel.StudentWeightsImpl;
using System;

namespace DomainModel.StudentWeights
{
    public interface IStudentWeight
    {
        Guid Id { get; }
        Guid StudentId { get; }
        double Weight { get; }
        DateTime CreatedAt { get; }
        DateTime UpdatedAt { get; }

        StudentWeight Create(Guid studentId, double weight);
    }
}