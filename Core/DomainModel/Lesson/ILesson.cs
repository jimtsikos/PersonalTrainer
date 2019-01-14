using DomainModel.LessonImpl.Enum;
using DomainModel.StudentsImpl;
using DomainModel.TrainersImpl;
using System;

namespace DomainModel.Lesson
{
    public interface ILesson
    {
        Guid Id { get; }
        Student Student { get; }
        Trainer Trainer { get; }
        DateTime DateTime { get; }
        Hour Hour { get; }
        Minutes Minutes { get; }
        bool IsActive { get; }
        bool IsPaid { get; }
        DateTime CreatedAt { get; }
        DateTime UpdatedAt { get; }

        LessonImpl.Lesson Create(Student student, Trainer trainer, DateTime dateTime, string hour, string minutes, bool isActive, bool isPaid);
        LessonImpl.Lesson Update(LessonImpl.Lesson lesson, Student student, Trainer trainer, DateTime dateTime, string hour, string minutes, bool isActive, bool isPaid);
        bool HasDublicateLesson(Student student, DateTime dateTime, string hour, string minutes);
    }
}
