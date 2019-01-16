using Application.StudentWeights.Dtos;
using System;
using System.Collections.Generic;

namespace Application.StudentWeights.Service
{
    public interface IStudentWeightsService
    {
        /// <summary>
        /// Get a student's weight by id
        /// </summary>
        /// <param name="studentWeightId">The weight id</param>
        /// <returns>The weight DTO</returns>
        StudentWeightDto Get(Guid studentWeightId);

        /// <summary>
        /// Get students weights
        /// </summary>
        /// <returns>List of students weights</returns>
        IEnumerable<StudentWeightDto> GetList();

        /// <summary>
        /// Get a student weights by its id
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>List of student weights</returns>
        IEnumerable<StudentWeightDto> GetList(Guid studentId);

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
