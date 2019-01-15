using Base.Domain;
using Base.DomainImpl;
using DomainModel.Students;
using DomainModel.StudentWeightsImpl;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.StudentsImpl
{
    [Table("Students")]
    public class Student : IAggregateRoot, IStudent
    {
        public virtual Guid Id { get; protected set; }
        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual double Height { get; protected set; }
        public virtual double PayRate { get; protected set; }
        public virtual double PrepaidMoney { get; protected set; }
        public virtual DateTime CreatedAt { get; protected set; }
        public virtual DateTime UpdatedAt { get; protected set; }
        public virtual bool IsActive { get; protected set; }
        
        public virtual ICollection<StudentWeight> StudentWeights { get; set; }
        public virtual ICollection<LessonImpl.Lesson> Lessons { get; protected set; }

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

        public Student Update(Student student, string firstname, string lastname, string description, double height, double payRate, double prepaidMoney, bool isActive)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
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

            if (prepaidMoney < 0)
            {
                throw new Exception("prepaidMoney cannot be negative");
            }
            
            student.FirstName = firstname;
            student.LastName = lastname;
            student.Description = description;
            student.Height = height;
            student.PayRate = payRate;
            student.PrepaidMoney = prepaidMoney;
            student.UpdatedAt = DateTime.UtcNow;
            student.IsActive = isActive;

            DomainEvents.Raise<StudentUpdated>(new StudentUpdated() { Student = student });

            return student;
        }
    }
}
