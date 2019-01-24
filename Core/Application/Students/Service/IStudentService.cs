using Application.Handlers;
using Application.Students.Dtos;
using System;
using System.Collections.Generic;

namespace Application.Students.Service
{
    public interface IStudentService
    {
        /// <summary>
        /// Get a student by its id
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>The result handler object with the student DTO</returns>
        ResultHandler<StudentDto> Get(Guid studentId);

        /// <summary>
        /// Get studnets list
        /// </summary>
        /// <returns>The result handler object with the list of students DTO</returns>
        ResultHandler<IEnumerable<StudentDto>> GetList();

        /// <summary>
        /// Create a student
        /// </summary>
        /// <param name="studentDto">The student DTO to be created</param>
        /// <returns>The result handler object with the student DTO</returns>
        ResultHandler<StudentDto> Create(StudentDto studentDto);

        /// <summary>
        /// Updates a stundent
        /// </summary>
        /// <param name="studentDto">The student DTO to be updated</param>
        /// <returns>The result handler object with the student DTO</returns>
        ResultHandler<StudentDto> Update(StudentDto studentDto);

        /// <summary>
        /// Deletes a stundent
        /// </summary>
        /// <param name="studentId">The student id to be deleted</param>
        /// <returns>The result handler object with the student DTO</returns>
        ResultHandler<StudentDto> Delete(Guid studentId);
    }
}
