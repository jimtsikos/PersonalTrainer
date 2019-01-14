using Application.Trainers.Dtos;
using DomainModel.TrainersImpl;
using DomainModel.Trainers;
using System;

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
            Trainer trainer = _trainerRepository.FindById(trainerId);

            return AutoMapper.Mapper.Map<Trainer, TrainerDto>(trainer);
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

            Trainer trainer = _trainerRepository.FindById(trainerDto.Id);

            if (trainer == null)
            {
                throw new Exception("No such trainer exists");
            }

            _trainerRepository.Update(trainer);
        }

        public void Delete(Guid trainerId)
        {
            Trainer trainer = _trainerRepository.FindById(trainerId);

            if (trainer == null)
                throw new Exception("No such trainer exists");

            _trainerRepository.Delete(trainer);
        }
    }
}
