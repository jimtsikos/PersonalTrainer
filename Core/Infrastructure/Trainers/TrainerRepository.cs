using DAL.DAL;
using DomainModel.Trainers;
using DomainModel.TrainersImpl;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Trainers
{
    public class TrainerRepository : Repository<Trainer, Guid>, ITrainerRepository
    {
        public TrainerRepository(TrainersContext context)
            : base(context)
        {
        }

        public override Trainer FindOne(Guid id)
        {
            return _trainersContext.Trainers
                                   .Include(x => x.Lessons)
                                   .Select(x => x)
                                   .Where(x => x.Id == id)
                                   .FirstOrDefault();
        }

        public override IEnumerable<Trainer> FindAll()
        {
            return _trainersContext.Trainers
                                   .Include(x => x.Lessons)
                                   .Select(x => x);
        }
    }
}