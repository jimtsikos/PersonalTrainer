﻿using DomainModel.Base;
using DomainModel.StudentsImpl;
using DomainModel.StudentWeights;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.StudentWeightsImpl
{
    [Table("StudentWeights")]
    public class StudentWeight : IAggregateRoot<Guid>, IStudentWeight
    {
        public virtual Guid Id { get; protected set; }
        public virtual Guid StudentId { get; protected set; }
        public virtual Student Student { get; protected set; }
        public virtual double Weight { get; protected set; }
        public virtual DateTime CreatedAt { get; protected set; }
        public virtual DateTime UpdatedAt { get; protected set; }

        public StudentWeight Create(Student student, double weight)
        {
            if (student == null)
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
                Student = student,
                Weight = weight,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return studentWeight;
        }
        
        public StudentWeight Update(StudentWeight studentWeight, Student student, double weight)
        {
            if (studentWeight == null)
            {
                throw new ArgumentNullException("studentId cannot be empty");
            }

            if (weight < 0)
            {
                throw new Exception("weight cannot be negative");
            }

            studentWeight.Student = student;
            studentWeight.Weight = weight;
            studentWeight.UpdatedAt = DateTime.UtcNow;

            return studentWeight;
        }
    }
}
