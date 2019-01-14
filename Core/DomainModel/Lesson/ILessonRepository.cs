using System;
using System.Collections.Generic;
using DomainModel.LessonImpl.Enum;

namespace DomainModel.Lesson
{
    public interface ILessonRepository
    {
        void Create(LessonImpl.Lesson entity);
        void Delete(LessonImpl.Lesson entity);
        IEnumerable<LessonImpl.Lesson> FindAll();
        IEnumerable<LessonImpl.Lesson> FindByDate(DateTime dateTime);
        IEnumerable<LessonImpl.Lesson> FindByDateAndTime(DateTime dateTime, Hour hour);
        LessonImpl.Lesson FindById(Guid id);
        void Update(LessonImpl.Lesson entity);
    }
}
