using Application.Extensions.Paging;
using Application.Handlers;
using Application.Students.Dtos;
using System;

namespace Application.Students.Service
{
    public interface IStudentService
    {
        /// <summary>
        /// Get the total number of students
        /// </summary>
        /// <returns>The number of students</returns>
        int Count();

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
        ResultHandler<PaginatedList<StudentDto>> GetList(Pageable pageable = null);

        /// <summary>
        /// Get studnets list based on their name
        /// </summary>
        /// <param name="name">The student name</param>
        /// <returns>The result handler object with a list of studnet DTO based on their name</returns>
        ResultHandler<PaginatedList<StudentDto>> GetList(string name, Pageable pageable = null);

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

        /// <summary>
        /// Pay student's lesson
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>The result handler object with the student DTO</returns>
        ResultHandler<StudentDto> PayLesson(Guid studentId);
    }
}
