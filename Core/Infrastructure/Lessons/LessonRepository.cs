﻿using DAL.DAL;
using DomainModel.Lesson;
using DomainModel.LessonImpl;
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
            return _context.Lessons.Find(id);
        }

        public IEnumerable<Lesson> FindByDate(DateTime dateTime)
        {
            return _context.Lessons.Select(x => x).Where(x => x.DateTime.Date.Day == dateTime.Date.Day);
        }

        public IEnumerable<Lesson> FindAll()
        {
            return _context.Lessons;
        }

        public void Create(Lesson entity)
        {
            _context.Lessons.Add(entity);
        }

        public void Update(Lesson entity)
        {
            _context.Lessons.Update(entity);
        }

        public void Delete(Lesson entity)
        {
            _context.Lessons.Remove(entity);
        }
    }
}