using Base.Domain;
using Base.DomainImpl;
using DomainModel.Lesson;
using DomainModel.LessonImpl.Enum;
using DomainModel.StudentsImpl;
using DomainModel.TrainersImpl;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DomainModel.LessonImpl
{
    [Table("Lesson")]
    public class Lesson : IAggregateRoot, ILesson
    {
        public Guid Id { get; protected set; }

        public Student Student { get; protected set; }

        public Trainer Trainer { get; protected set; }

        public DateTime DateTime { get; protected set; }

        public Hour Hour { get; protected set; }

        public Minutes Minutes { get; protected set; }

        public bool IsActive { get; protected set; }

        public bool IsPaid { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        public DateTime UpdatedAt { get; protected set; }

        public Lesson Create(Student student, Trainer trainer, DateTime dateTime, string hour, string minutes, bool isActive, bool isPaid)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
            }

            if (trainer == null)
            {
                throw new ArgumentNullException("trainer");
            }

            if (!System.Enum.TryParse(hour, out Hour hourParsed))
            {
                throw new Exception("hour is not regognised");
            }

            if (!System.Enum.TryParse(minutes, out Minutes minutesParsed))
            {
                throw new Exception("minutes is not regognised");
            }

            Lesson lesson = new Lesson()
            {
                Id = Guid.NewGuid(),
                Student = student,
                Trainer = trainer,
                DateTime = dateTime,
                Hour = hourParsed,
                Minutes = minutesParsed,
                IsActive = isActive,
                IsPaid = isPaid,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            DomainEvents.Raise<LessonCreated>(new LessonCreated() { Lesson = lesson });

            return lesson;
        }

        public Lesson Update(Lesson lesson, Student student, Trainer trainer, DateTime dateTime, string hour, string minutes, bool isActive, bool isPaid)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
            }

            if (trainer == null)
            {
                throw new ArgumentNullException("trainer");
            }

            if (!System.Enum.TryParse(hour, out Hour hourParsed))
            {
                throw new Exception("hour is not regognised");
            }

            if (!System.Enum.TryParse(minutes, out Minutes minutesParsed))
            {
                throw new Exception("minutes is not regognised");
            }

            lesson.Student = student;
            lesson.Trainer = trainer;
            lesson.DateTime = dateTime;
            lesson.Hour = hourParsed;
            lesson.Minutes = minutesParsed;
            lesson.IsActive = isActive;
            lesson.IsPaid = isPaid;
            lesson.UpdatedAt = DateTime.UtcNow;

            DomainEvents.Raise<LessonUpdated>(new LessonUpdated() { Lesson = lesson });

            return lesson;
        }

        public bool HasDublicateLesson(Student student, DateTime dateTime, string hour, string minutes)
        {
            bool hasDublicateLesson = false;

            if (!System.Enum.TryParse(hour, out Hour hourParsed))
            {
                throw new Exception("hour is not regognised");
            }

            Lesson lesson = student.Lessons
                                   .Select(x => x)
                                   .Where(x => x.DateTime.Date.Day == dateTime.Date.Day && x.Hour == hourParsed)
                                   .FirstOrDefault();

            if (lesson != null)
            {
                hasDublicateLesson = true;
            }

            return hasDublicateLesson;
        }
    }
}
