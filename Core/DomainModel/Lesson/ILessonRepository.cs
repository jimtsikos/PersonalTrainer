using System;
using System.Collections.Generic;
using DomainModel.LessonImpl;

namespace DomainModel.Lesson
{
    public interface ILessonRepository
    {
        void Create(LessonImpl.Lesson entity);
        void Delete(LessonImpl.Lesson entity);
        IEnumerable<LessonImpl.Lesson> FindAll();
        IEnumerable<LessonImpl.Lesson> FindByDate(DateTime dateTime);
        LessonImpl.Lesson FindById(Guid id);
        void Update(LessonImpl.Lesson entity);
    }
}
