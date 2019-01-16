using DomainModel.Base;
using DomainModel.TrainersImpl;
using System;

namespace DomainModel.Trainers
{
    public interface ITrainerRepository : IRepository<Trainer, Guid>
    {
    }
}
