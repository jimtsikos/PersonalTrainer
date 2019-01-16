using DAL.DAL;
using DomainModel.Lesson;
using DomainModel.LessonImpl;
using DomainModel.LessonImpl.Enum;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Trainers
{
    public class LessonRepository : Repository<Lesson, Guid>, ILessonRepository
    {
        public LessonRepository(TrainersContext context) 
            : base(context)
        {
        }

        public override Lesson FindOne(Guid id)
        {
            return _trainersContext.Lessons
                                   .Include(x => x.Student)
                                   .Include(x => x.Trainer)
                                   .Select(x => x)
                                   .Where(x => x.Id == id)
                                   .FirstOrDefault();
        }

        public override IEnumerable<Lesson> FindAll()
        {
            return _trainersContext.Lessons
                                   .Include(x => x.Student)
                                   .Include(x => x.Trainer)
                                   .Select(x => x);
        }

        public IEnumerable<Lesson> FindByDate(DateTime dateTime)
        {
            return _trainersContext.Lessons
                                   .Include(x => x.Student)
                                   .Include(x => x.Trainer)
                                   .Select(x => x)
                                   .Where(x => x.DateTime.Date.Day == dateTime.Date.Day);
        }

        public IEnumerable<Lesson> FindByDateAndTime(DateTime dateTime, Hour hour)
        {
            return _trainersContext.Lessons
                                   .Include(x => x.Student)
                                   .Include(x => x.Trainer)
                                   .Select(x => x)
                                   .Where(x => x.DateTime.Date.Day == dateTime.Date.Day && x.Hour == hour);
        }

        
    }
}