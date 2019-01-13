using Application.Students.Dtos;
using System;

namespace Application.Students.Service
{
    public interface IStudentService
    {
        /// <summary>
        /// Get a student by its id
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>The student DTO</returns>
        StudentDto Get(Guid studentId);

        /// <summary>
        /// Create a student
        /// </summary>
        /// <param name="studentDto">The student DTO to be created</param>
        /// <returns>The student DTO</returns>
        StudentDto Create(StudentDto studentDto);

        /// <summary>
        /// Updates a stundent
        /// </summary>
        /// <param name="studentDto">The student DTO to be updated</param>
        void Update(StudentDto studentDto);

        /// <summary>
        /// Deletes a stundent
        /// </summary>
        /// <param name="studentId">The student id to be deleted</param>
        void Delete(Guid studentId);
    }
}
