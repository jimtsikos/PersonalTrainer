using DomainModel.LessonImpl.Enum;
using DomainModel.StudentsImpl;
using DomainModel.TrainersImpl;
using System;

namespace DomainModel.Lesson
{
    public interface ILesson
    {
        Guid Id { get; }
        Guid StudentId { get; }
        Student Student { get; }
        Guid TrainerId { get; }
        Trainer Trainer { get; }
        DateTime DateTime { get; }
        Hour Hour { get; }
        Minutes Minutes { get; }
        bool IsCompleted { get; }
        DateTime CreatedAt { get; }
        DateTime UpdatedAt { get; }

        LessonImpl.Lesson Create(Student student, Trainer trainer, DateTime dateTime, int hour, int minutes, bool isCompleted);
        LessonImpl.Lesson Update(LessonImpl.Lesson lesson, Student student, Trainer trainer, DateTime dateTime, int hour, int minutes, bool isCompleted);
        bool HasDublicateLesson(LessonImpl.Lesson lesson, Student student, DateTime dateTime, int hour, int minutes);
        LessonImpl.Lesson MarkAsCompleted(LessonImpl.Lesson lesson);
    }
}
