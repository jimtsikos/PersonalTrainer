using Application.Handlers;
using Application.Lessons.Dtos;
using System;
using System.Collections.Generic;

namespace Application.Lessons.Service
{
    public interface ILessonService
    {
        /// <summary>
        /// Get a lesson by its id
        /// </summary>
        /// <param name="lessonId">The lesson id</param>
        /// <returns>The lesson DTO</returns>
        ResultHandler<LessonDto> Get(Guid lessonId);

        /// <summary>
        /// Get a list of all lessons
        /// </summary>
        /// <returns>The list of lessons</returns>
        ResultHandler<IEnumerable<LessonDto>> GetList();

        /// <summary>
        /// Get a list of lessons by date
        /// </summary>
        /// <param name="dateTime">The datetime to search for</param>
        /// <returns>The list of lessons for a specific date</returns>
        ResultHandler<IEnumerable<LessonDto>> GetByDate(DateTime dateTime);

        /// <summary>
        /// Get a list of lessons by date and time
        /// </summary>
        /// <param name="dateTime">The datetime to search for</param>
        /// <param name="hour">The hour to search for</param>
        /// <returns>The list of lessons for a specific date and time</returns>
        ResultHandler<IEnumerable<LessonDto>> GetByDateAndTime(DateTime dateTime, string hour);

        /// <summary>
        /// Create a lesson
        /// </summary>
        /// <param name="LessonDto">The lesson DTO to be created</param>
        /// <returns>The lesson DTO</returns>
        ResultHandler<LessonDto> Create(LessonDto lessonDto);

        /// <summary>
        /// Updates a lesson
        /// </summary>
        /// <param name="LessonDto">The lesson DTO to be updated</param>
        ResultHandler<LessonDto> Update(LessonDto lessonDto);

        /// <summary>
        /// Deletes a lesson
        /// </summary>
        /// <param name="lessonId">The lesson id to be deleted</param>
        ResultHandler<LessonDto> Delete(Guid lessonId);
    }
}
