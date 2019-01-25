using Application.Extensions.Paging;
using Application.Handlers;
using Application.Trainers.Dtos;
using System;

namespace Application.Trainers.Service
{
    public interface ITrainerService
    {
        /// <summary>
        /// Get the total number of trainers
        /// </summary>
        /// <returns>The number of trainers</returns>
        int Count();

        /// <summary>
        /// Get a trainer by its id
        /// </summary>
        /// <param name="trainerId">The trainer id</param>
        /// <returns>The result handler object with the trainer DTO</returns>
        ResultHandler<TrainerDto> Get(Guid trainerId);

        /// <summary>
        /// Get a list of trainers
        /// </summary>
        /// <returns>A list of trainer DTO</returns>
        ResultHandler<PaginatedList<TrainerDto>> GetList(Pageable pageable = null);

        /// <summary>
        /// Get a list of trainers based on their name
        /// </summary>
        /// <param name="name">The trainer name</param>
        /// <returns>The result handler object with a list of trainer DTO based on their name</returns>
        ResultHandler<PaginatedList<TrainerDto>> GetList(string name, Pageable pageable = null);

        /// <summary>
        /// Create a trainer
        /// </summary>
        /// <param name="trainerDto">The trainer DTO to be created</param>
        /// <returns>The result handler object with the trainer DTO</returns>
        ResultHandler<TrainerDto> Create(TrainerDto trainerDto);

        /// <summary>
        /// Updates a trainer
        /// </summary>
        /// <param name="trainerDto">The trainer DTO to be updated</param>
        /// <returns>The result handler object with the trainer DTO</returns>
        ResultHandler<TrainerDto> Update(TrainerDto trainerDto);

        /// <summary>
        /// Deletes a trainer
        /// </summary>
        /// <param name="trainerId">The trainer id to be deleted</param>
        /// <returns>The result handler object with the trainer DTO</returns>
        ResultHandler<TrainerDto> Delete(Guid trainerId);
    }
}
