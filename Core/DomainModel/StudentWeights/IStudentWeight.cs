using DomainModel.StudentsImpl;
using DomainModel.StudentWeightsImpl;
using System;

namespace DomainModel.StudentWeights
{
    public interface IStudentWeight
    {
        Guid Id { get; }
        Guid StudentId { get; }
        Student Student { get; }
        double Weight { get; }
        DateTime CreatedAt { get; }
        DateTime UpdatedAt { get; }

        StudentWeight Create(Student student, double weight);
        StudentWeight Update(StudentWeight studentWeight, Student student, double weight);
    }
}