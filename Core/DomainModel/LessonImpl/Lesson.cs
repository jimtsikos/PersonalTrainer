using DomainModel.Base;
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
    public class Lesson : IAggregateRoot<Guid>, ILesson
    {
        public virtual Guid Id { get; protected set; }
        public virtual Guid StudentId { get; protected set; }
        public virtual Student Student { get; protected set; }
        public virtual Guid TrainerId { get; protected set; }
        public virtual Trainer Trainer { get; protected set; }
        public virtual DateTime DateTime { get; protected set; }
        public virtual Hour Hour { get; protected set; }
        public virtual Minutes Minutes { get; protected set; }
        public virtual bool IsCompleted { get; protected set; }
        public virtual DateTime CreatedAt { get; protected set; }
        public virtual DateTime UpdatedAt { get; protected set; }

        public Lesson Create(Student student, Trainer trainer, DateTime dateTime, int hour, int minutes, bool isCompleted)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
            }

            if (trainer == null)
            {
                throw new ArgumentNullException("trainer");
            }

            Hour hourParsed;
            Minutes minutesParsed;
            try
            {
                hourParsed = (Hour)hour;
                minutesParsed = (Minutes)minutes;
            }
            catch (Exception)
            {
                throw new Exception("hour/minutes is not regognised");
            }

            Lesson lesson = new Lesson()
            {
                Id = Guid.NewGuid(),
                Student = student,
                Trainer = trainer,
                DateTime = dateTime,
                Hour = hourParsed,
                Minutes = minutesParsed,
                IsCompleted = isCompleted,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return lesson;
        }

        public Lesson Update(Lesson lesson, Student student, Trainer trainer, DateTime dateTime, int hour, int minutes, bool isCompleted)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
            }

            if (trainer == null)
            {
                throw new ArgumentNullException("trainer");
            }

            Hour hourParsed;
            Minutes minutesParsed;
            try
            {
                hourParsed = (Hour)hour;
                minutesParsed = (Minutes)minutes;
            }
            catch (Exception)
            {
                throw new Exception("hour/minutes is not regognised");
            }

            lesson.Student = student;
            lesson.Trainer = trainer;
            lesson.DateTime = dateTime;
            lesson.Hour = hourParsed;
            lesson.Minutes = minutesParsed;
            lesson.IsCompleted = isCompleted;
            lesson.UpdatedAt = DateTime.UtcNow;

            return lesson;
        }

        public bool HasDublicateLesson(Lesson lesson, Student student, DateTime dateTime, int hour, int minutes)
        {
            bool hasDublicateLesson = false;

            Hour hourParsed;
            Minutes minutesParsed;
            try
            {
                hourParsed = (Hour)hour;
                minutesParsed = (Minutes)minutes;
            }
            catch (Exception)
            {
                throw new Exception("hour/minutes is not regognised");
            }

            if (lesson == null)
            {
                lesson = student.Lessons
                                .Select(x => x)
                                .Where(x => x.DateTime.Date.Day == dateTime.Date.Day && x.Hour == hourParsed)
                                .FirstOrDefault();
            }
            else
            {
                lesson = student.Lessons
                                .Select(x => x)
                                .Where(x => x.DateTime.Date.Day == dateTime.Date.Day && x.Hour == hourParsed && x.Id != lesson.Id)
                                .FirstOrDefault();
            }

            if (lesson != null)
            {
                hasDublicateLesson = true;
            }

            return hasDublicateLesson;
        }

        public Lesson MarkAsCompleted(Lesson lesson)
        {
            if (lesson == null)
            {
                throw new ArgumentNullException("lesson");
            }

            lesson.IsCompleted = true;

            return lesson;
        }
    }
}
