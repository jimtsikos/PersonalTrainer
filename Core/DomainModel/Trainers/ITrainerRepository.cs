using DomainModel.TrainersImpl;
using System;
using System.Collections.Generic;

namespace DomainModel.Trainers
{
    public interface ITrainerRepository
    {
        void Create(Trainer entity);
        void Delete(Trainer entity);
        IEnumerable<Trainer> FindAll();
        Trainer FindById(Guid id);
        void Update(Trainer entity);
    }
}
