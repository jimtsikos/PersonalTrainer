using DAL.DAL;
using DomainModel.Trainers;
using DomainModel.TrainersImpl;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Trainers
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly ITrainersContext _context;

        public TrainerRepository(ITrainersContext context)
        {
            _context = context;
        }

        public Trainer FindById(Guid id)
        {
            return _context.Trainers.Include(x => x.Lessons)
                                    .Where(x => x.Id == id)
                                    .FirstOrDefault();
        }

        public IEnumerable<Trainer> FindAll()
        {
            return _context.Trainers.Include(x => x.Lessons);
        }

        public void Create(Trainer entity)
        {
            _context.Trainers.Add(entity).Context.SaveChanges();
        }

        public void Update(Trainer entity)
        {
            _context.Trainers.Update(entity).Context.SaveChanges();
        }

        public void Delete(Trainer entity)
        {
            _context.Trainers.Remove(entity).Context.SaveChanges();
        }
    }
}