using DomainModel.Base;
using DomainModel.TrainersImpl;
using System;
using System.Collections.Generic;

namespace DomainModel.Trainers
{
    public interface ITrainerRepository : IRepository<Trainer, Guid>
    {
        /// <summary>
        /// Return all trainers based on their name
        /// </summary>
        /// <param name="searchString">The name of trainers</param>
        /// <returns>Trainers based on their name</returns>
        IEnumerable<Trainer> FindByName(string name);
    }
}
