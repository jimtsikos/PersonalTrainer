using DAL.DAL;
using DomainModel.Lesson;
using DomainModel.LessonImpl;
using DomainModel.LessonImpl.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Trainers
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ITrainersContext _context;

        public LessonRepository(ITrainersContext context)
        {
            _context = context;
        }

        public Lesson FindById(Guid id)
        {
            return _context.Lessons.Include(x => x.Student)
                                   .Include(x => x.Trainer)
                                   .Where(x => x.Id == id)
                                   .FirstOrDefault();
        }

        public IEnumerable<Lesson> FindByDate(DateTime dateTime)
        {
            return _context.Lessons.Include(x => x.Student)
                                   .Include(x => x.Trainer)
                                   .Select(x => x).Where(x => x.DateTime.Date.Day == dateTime.Date.Day);
        }

        public IEnumerable<Lesson> FindByDateAndTime(DateTime dateTime, Hour hour)
        {
            return _context.Lessons.Include(x => x.Student)
                                   .Include(x => x.Trainer)
                                   .Select(x => x)
                                   .Where(x => x.DateTime.Date.Day == dateTime.Date.Day && x.Hour == hour);
        }

        public IEnumerable<Lesson> FindAll()
        {
            return _context.Lessons.Include(x => x.Student).Include(x => x.Trainer);
        }

        public void Create(Lesson entity)
        {
            _context.Lessons.Add(entity).Context.SaveChanges();
        }

        public void Update(Lesson entity)
        {
            _context.Lessons.Update(entity).Context.SaveChanges();
        }

        public void Delete(Lesson entity)
        {
            _context.Lessons.Remove(entity).Context.SaveChanges();
        }
    }
}