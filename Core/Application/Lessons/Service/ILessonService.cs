using Application.Lessons.Dtos;
using System;

namespace Application.Lessons.Service
{
    public interface ILessonService
    {
        /// <summary>
        /// Get a lesson by its id
        /// </summary>
        /// <param name="lessonId">The lesson id</param>
        /// <returns>The lesson DTO</returns>
        LessonDto Get(Guid lessonId);

        /// <summary>
        /// Create a lesson
        /// </summary>
        /// <param name="LessonDto">The lesson DTO to be created</param>
        /// <returns>The lesson DTO</returns>
        LessonDto Create(LessonDto lessonDto);

        /// <summary>
        /// Updates a lesson
        /// </summary>
        /// <param name="LessonDto">The lesson DTO to be updated</param>
        void Update(LessonDto lessonDto);

        /// <summary>
        /// Deletes a lesson
        /// </summary>
        /// <param name="lessonId">The lesson id to be deleted</param>
        void Delete(Guid lessonId);
    }
}
