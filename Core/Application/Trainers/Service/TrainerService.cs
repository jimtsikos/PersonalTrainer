using Application.Trainers.Dtos;
using DomainModel.TrainersImpl;
using DomainModel.Trainers;
using System;
using System.Collections;
using System.Collections.Generic;
using Application.Handlers;
using Application.Extensions.Paging;
using System.Linq;

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

        public int Count()
        {
            return _trainerRepository.Count();
        }

        public ResultHandler<TrainerDto> Get(Guid trainerId)
        {
            ResultHandler<TrainerDto> resultHandler = new ResultHandler<TrainerDto>();

            try
            {
                Trainer trainer = _trainerRepository.FindOne(trainerId);
                resultHandler.Data = AutoMapper.Mapper.Map<Trainer, TrainerDto>(trainer);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<PaginatedList<TrainerDto>> GetList(Pageable pageable = null)
        {
            ResultHandler<PaginatedList<TrainerDto>> resultHandler = new ResultHandler<PaginatedList<TrainerDto>>();

            try
            {
                IEnumerable<Trainer> trainers = _trainerRepository.FindAll();
                var trainersPaged = AutoMapper.Mapper.Map<IEnumerable<Trainer>, PaginatedList<TrainerDto>>(trainers);
                resultHandler.Data = PaginatedList<TrainerDto>.Create(trainersPaged.AsQueryable(), pageable);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<PaginatedList<TrainerDto>> GetList(string name, Pageable pageable = null)
        {
            ResultHandler<PaginatedList<TrainerDto>> resultHandler = new ResultHandler<PaginatedList<TrainerDto>>();

            try
            {
                IEnumerable<Trainer> trainers = _trainerRepository.FindByName(name);
                var trainersPaged = AutoMapper.Mapper.Map<IEnumerable<Trainer>, PaginatedList<TrainerDto>>(trainers);
                resultHandler.Data = PaginatedList<TrainerDto>.Create(trainersPaged.AsQueryable(), pageable);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<TrainerDto> Create(TrainerDto trainerDto)
        {
            ResultHandler<TrainerDto> resultHandler = new ResultHandler<TrainerDto>();

            try
            {
                Trainer trainer = _trainer.Create(trainerDto.FirstName, trainerDto.LastName, trainerDto.Description, trainerDto.PayRate, trainerDto.IsActive);
                _trainerRepository.Create(trainer);
                resultHandler.Data = AutoMapper.Mapper.Map<Trainer, TrainerDto>(trainer);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<TrainerDto> Update(TrainerDto trainerDto)
        {
            ResultHandler<TrainerDto> resultHandler = new ResultHandler<TrainerDto>();

            if (trainerDto.Id == Guid.Empty)
            {
                resultHandler.Errors.Add("Trainer id can't be empty");
                return resultHandler;
            }

            try
            {
                Trainer trainer = _trainerRepository.FindOne(trainerDto.Id);
                if (trainer == null)
                {
                    resultHandler.Errors.Add("No such trainer exists");
                    return resultHandler;
                }

                trainer = _trainer.Update(trainer, trainerDto.FirstName, trainerDto.LastName, trainerDto.Description, trainerDto.PayRate, trainerDto.IsActive);
                _trainerRepository.Update(trainer);
                resultHandler.Data = AutoMapper.Mapper.Map<Trainer, TrainerDto>(trainer);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<TrainerDto> Delete(Guid trainerId)
        {
            ResultHandler<TrainerDto> resultHandler = new ResultHandler<TrainerDto>();

            try
            {
                Trainer trainer = _trainerRepository.FindOne(trainerId);
                if (trainer == null)
                {
                    resultHandler.Errors.Add("No such trainer exists");
                    return resultHandler;
                }

                _trainerRepository.Delete(trainer);
                resultHandler.Data = AutoMapper.Mapper.Map<Trainer, TrainerDto>(trainer);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }
    }
}
