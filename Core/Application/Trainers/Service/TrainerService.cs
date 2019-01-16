using Application.Trainers.Dtos;
using DomainModel.TrainersImpl;
using DomainModel.Trainers;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Application.Trainers.Service
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainer _trainer;
        private readonly ITrainerRepository _trainerRepository;

        public TrainerService(ITrainer trainer, ITrainerRepository trainerRepository)
        {
            _trainer = trainer;
            _trainerRepository = trainerRepository;
        }

        public TrainerDto Get(Guid trainerId)
        {
            Trainer trainer = _trainerRepository.FindOne(trainerId);

            return AutoMapper.Mapper.Map<Trainer, TrainerDto>(trainer);
        }

        public IEnumerable<TrainerDto> GetList()
        {
            IEnumerable<Trainer> trainers = _trainerRepository.FindAll();

            return AutoMapper.Mapper.Map<IEnumerable<Trainer>, IEnumerable<TrainerDto>>(trainers);
        }

        public TrainerDto Create(TrainerDto trainerDto)
        {
            Trainer trainer = _trainer.Create(trainerDto.FirstName, trainerDto.LastName, trainerDto.Description, trainerDto.PayRate, trainerDto.IsActive);

            _trainerRepository.Create(trainer);

            return AutoMapper.Mapper.Map<Trainer, TrainerDto>(trainer);
        }

        public void Update(TrainerDto trainerDto)
        {
            if (trainerDto.Id == Guid.Empty)
            {
                throw new Exception("Id can't be empty");
            }

            Trainer trainer = _trainerRepository.FindOne(trainerDto.Id);

            if (trainer == null)
            {
                throw new Exception("No such trainer exists");
            }

            trainer = _trainer.Update(trainer, trainerDto.FirstName, trainerDto.LastName, trainerDto.Description, trainerDto.PayRate, trainerDto.IsActive);

            _trainerRepository.Update(trainer);
        }

        public void Delete(Guid trainerId)
        {
            Trainer trainer = _trainerRepository.FindOne(trainerId);

            if (trainer == null)
                throw new Exception("No such trainer exists");

            _trainerRepository.Delete(trainer);
        }
    }
}
