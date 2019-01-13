using Application.StudentWeights.Dtos;
using System;

namespace Application.StudentWeights.Service
{
    public interface IStudentWeightsService
    {
        /// <summary>
        /// Get a student weight by its id
        /// </summary>
        /// <param name="studentWeightId">The weight id</param>
        /// <returns>The weight DTO</returns>
        StudentWeightDto Get(Guid studentWeightId);

        /// <summary>
        /// Create a student weight
        /// </summary>
        /// <param name="studentWeightDto">The student weight DTO to be created</param>
        /// <returns>The student weight DTO</returns>
        StudentWeightDto Create(StudentWeightDto studentWeightDto);

        /// <summary>
        /// Updates a stundent weight
        /// </summary>
        /// <param name="studentWeightDto">The student weight DTO to be updated</param>
        void Update(StudentWeightDto studentWeightDto);

        /// <summary>
        /// Deletes a stundent weight
        /// </summary>
        /// <param name="studentWeightId">The student weight id to be deleted</param>
        void Delete(Guid studentWeightId);
    }
}
