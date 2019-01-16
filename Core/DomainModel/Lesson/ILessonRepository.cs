using System;
using System.Collections.Generic;
using DomainModel.Base;
using DomainModel.LessonImpl.Enum;

namespace DomainModel.Lesson
{
    public interface ILessonRepository : IRepository<LessonImpl.Lesson, Guid>
    {
        IEnumerable<LessonImpl.Lesson> FindByDate(DateTime dateTime);
        IEnumerable<LessonImpl.Lesson> FindByDateAndTime(DateTime dateTime, Hour hour);
    }
}
