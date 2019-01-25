using Application.Extensions.Paging;
using Application.Handlers;
using Application.Lessons.Dtos;
using System;
using System.Collections.Generic;

namespace Application.Lessons.Service
{
    public interface ILessonService
    {
        /// <summary>
        /// Get the total number of lessons
        /// </summary>
        /// <returns>The number of lessons</returns>
        int Count();

        /// <summary>
        /// Get a lesson by its id
        /// </summary>
        /// <param name="lessonId">The lesson id</param>
        /// <returns>The result handler object with the lesson DTO</</returns>
        ResultHandler<LessonDto> Get(Guid lessonId);

        /// <summary>
        /// Get a list of all lessons
        /// </summary>
        /// <returns>The result handler object with the list of lesson DTO</</returns>
        ResultHandler<PaginatedList<LessonDto>> GetList(Pageable pageable = null);

        /// <summary>
        /// Get a list of lessons by date
        /// </summary>
        /// <param name="dateTime">The datetime to search for</param>
        /// <returns>The result handler object with the list of lesson DTO for a specific date</</returns>
        ResultHandler<PaginatedList<LessonDto>> GetByDate(DateTime dateTime, Pageable pageable = null);

        /// <summary>
        /// Get a list of lessons by date and time
        /// </summary>
        /// <param name="dateTime">The datetime to search for</param>
        /// <param name="hour">The hour to search for</param>
        /// <returns>The result handler object with the list of lesson DTO for a specific date and time</</returns>
        ResultHandler<PaginatedList<LessonDto>> GetByDateAndTime(DateTime dateTime, string hour, Pageable pageable = null);

        /// <summary>
        /// Create a lesson
        /// </summary>
        /// <param name="LessonDto">The lesson DTO to be created</param>
        /// <returns>The result handler object with the lesson DTO</</returns>
        ResultHandler<LessonDto> Create(LessonDto lessonDto);

        /// <summary>
        /// Updates a lesson
        /// </summary>
        /// <param name="LessonDto">The lesson DTO to be updated</param>
        /// <returns>The result handler object with the lesson DTO</</returns>
        ResultHandler<LessonDto> Update(LessonDto lessonDto);

        /// <summary>
        /// Deletes a lesson
        /// </summary>
        /// <param name="lessonId">The lesson id to be deleted</param>
        /// <returns>The result handler object with the lesson DTO</</returns>
        ResultHandler<LessonDto> Delete(Guid lessonId);

        /// <summary>
        /// Marks a lesson as paid
        /// </summary>
        /// <param name="lessonId">The lesson id to be deleted</param>
        /// <returns>The result handler object with the lesson DTO</</returns>
        ResultHandler<LessonDto> MarkLessonAsPaid(Guid lessonId);
    }
}
