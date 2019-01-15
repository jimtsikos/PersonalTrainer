using DAL.DAL;
using DomainModel.Trainers;
using DomainModel.TrainersImpl;
using System;
using System.Collections.Generic;

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
            return _context.Trainers.Find(id);
        }

        public IEnumerable<Trainer> FindAll()
        {
            return _context.Trainers;
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