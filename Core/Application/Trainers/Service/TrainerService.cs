using Application.Trainers.Dtos;
using Base.Repository;
using Base.Specification;
using DomainModel.TrainersImpl;
using DomainModel.Trainers;
using System;

namespace Application.Trainers.Service
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainer _trainer;
        private readonly ITrainerRepository _trainerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TrainerService(ITrainer trainer, ITrainerRepository trainerRepository, IUnitOfWork unitOfWork)
        {
            _trainer = trainer;
            _trainerRepository = trainerRepository;
            _unitOfWork = unitOfWork;
        }

        public TrainerDto Get(Guid trainerId)
        {
            ISpecification<Trainer> registeredSpec = new TrainerRegisteredSpec(trainerId);

            Trainer trainer = _trainerRepository.FindOne(registeredSpec);

            return AutoMapper.Mapper.Map<Trainer, TrainerDto>(trainer);
        }

        public TrainerDto Create(TrainerDto trainerDto)
        {
            Trainer trainer = _trainer.Create(trainerDto.FirstName, trainerDto.LastName, trainerDto.Description, trainerDto.PayRate, trainerDto.IsActive);

            _trainerRepository.Create(trainer);
            _unitOfWork.Commit();

            return AutoMapper.Mapper.Map<Trainer, TrainerDto>(trainer);
        }

        public void Update(TrainerDto trainerDto)
        {
            if (trainerDto.Id == Guid.Empty)
            {
                throw new Exception("Id can't be empty");
            }

            ISpecification<Trainer> registeredSpec = new TrainerRegisteredSpec(trainerDto.Id);

            Trainer trainer = _trainerRepository.FindOne(registeredSpec);

            if (trainer == null)
            {
                throw new Exception("No such trainer exists");
            }

            _trainerRepository.Update(trainer);
            _unitOfWork.Commit();
        }

        public void Delete(Guid trainerId)
        {
            ISpecification<Trainer> registeredSpec = new TrainerRegisteredSpec(trainerId);

            Trainer trainer = _trainerRepository.FindOne(registeredSpec);

            if (trainer == null)
                throw new Exception("No such trainer exists");

            _trainerRepository.Delete(trainer);
            _unitOfWork.Commit();
        }
    }
}
