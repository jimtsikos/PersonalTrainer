using Application.Extensions.Paging;
using Application.Handlers;
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
        /// <returns>The result handler object with the weight DTO</returns>
        ResultHandler<StudentWeightDto> Get(Guid studentWeightId);

        /// <summary>
        /// Get students weights
        /// </summary>
        /// <returns>The result handler object with the list of weight DTO</returns>
        ResultHandler<PaginatedList<StudentWeightDto>> GetList(Pageable pageable = null);

        /// <summary>
        /// Get a student weights by its id
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>The result handler object with the list of student weight DTO</returns>
        ResultHandler<PaginatedList<StudentWeightDto>> GetList(Guid studentId, Pageable pageable = null);

        /// <summary>
        /// Create a student weight
        /// </summary>
        /// <param name="studentWeightDto">The student weight DTO to be created</param>
        /// <returns>The result handler object with the weight DTO</returns>
        ResultHandler<StudentWeightDto> Create(StudentWeightDto studentWeightDto);

        /// <summary>
        /// Updates a stundent weight
        /// </summary>
        /// <param name="studentWeightDto">The student weight DTO to be updated</param>
        /// <returns>The result handler object with the weight DTO</returns>
        ResultHandler<StudentWeightDto> Update(StudentWeightDto studentWeightDto);

        /// <summary>
        /// Deletes a stundent weight
        /// </summary>
        /// <param name="studentWeightId">The student weight id to be deleted</param>
        /// <returns>The result handler object with the weight DTO</returns>
        ResultHandler<StudentWeightDto> Delete(Guid studentWeightId);
    }
}
