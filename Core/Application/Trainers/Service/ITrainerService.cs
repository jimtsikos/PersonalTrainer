﻿using Application.Trainers.Dtos;
using System;
using System.Collections.Generic;

namespace Application.Trainers.Service
{
    public interface ITrainerService
    {
        /// <summary>
        /// Get a trainer by its id
        /// </summary>
        /// <param name="trainerId">The trainer id</param>
        /// <returns>The trainer DTO</returns>
        TrainerDto Get(Guid trainerId);

        /// <summary>
        /// Get a list of trainers
        /// </summary>
        /// <returns>A list of trainer DTO</returns>
        IEnumerable<TrainerDto> GetList();

        /// <summary>
        /// Create a trainer
        /// </summary>
        /// <param name="trainerDto">The trainer DTO to be created</param>
        /// <returns>The trainer DTO</returns>
        TrainerDto Create(TrainerDto trainerDto);

        /// <summary>
        /// Updates a trainer
        /// </summary>
        /// <param name="trainerDto">The trainer DTO to be updated</param>
        void Update(TrainerDto trainerDto);

        /// <summary>
        /// Deletes a trainer
        /// </summary>
        /// <param name="trainerId">The trainer id to be deleted</param>
        void Delete(Guid trainerId);
    }
}
