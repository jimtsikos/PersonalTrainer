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
    }
}