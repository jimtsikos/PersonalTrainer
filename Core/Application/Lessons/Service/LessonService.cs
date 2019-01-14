using System;
using Application.Lessons.Dtos;
using DomainModel.Lesson;
using DomainModel.LessonImpl;
using DomainModel.Students;
using DomainModel.StudentsImpl;
using DomainModel.Trainers;
using DomainModel.TrainersImpl;

namespace Application.Lessons.Service
{
    public class LessonService : ILessonService
    {
        private readonly ILesson _lesson;
        private readonly ILessonRepository _lessonRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITrainerRepository _trainerRepository;

        public LessonService(ILesson lesson, ILessonRepository lessonRepository, 
                             IStudentRepository studentRepository, ITrainerRepository trainerRepository)
        {
            _lesson = lesson;
            _lessonRepository = lessonRepository;
            _studentRepository = studentRepository;
            _trainerRepository = trainerRepository;
        }

        public LessonDto Get(Guid lessonId)
        {
            Lesson lesson = _lessonRepository.FindById(lessonId);

            return AutoMapper.Mapper.Map<Lesson, LessonDto>(lesson);
        }

        public LessonDto Create(LessonDto lessonDto)
        {
            Student student = _studentRepository.FindById(lessonDto.StudentId);
            Trainer trainer = _trainerRepository.FindById(lessonDto.TrainerId);

            Lesson lesson = null;
            if (!_lesson.HasDublicateLesson(student, lessonDto.DateTime, lessonDto.Hour, lessonDto.Minutes))
            {
                lesson = _lesson.Create(student, trainer, lessonDto.DateTime, lessonDto.Hour, lessonDto.Minutes, lessonDto.IsActive, lessonDto.IsPaid);
            }
            else
            {
                throw new Exception("There is a dublicate lesson");
            }

            _lessonRepository.Create(lesson);

            return AutoMapper.Mapper.Map<Lesson, LessonDto>(lesson);
        }

        public void Update(LessonDto lessonDto)
        {
            if (lessonDto.Id == Guid.Empty)
            {
                throw new Exception("Id can't be empty");
            }

            Lesson lesson = _lessonRepository.FindById(lessonDto.Id);

            if (lesson == null)
            {
                throw new Exception("No such lesson exists");
            }

            _lessonRepository.Update(lesson);
        }

        public void Delete(Guid lessonId)
        {
            Lesson lesson = _lessonRepository.FindById(lessonId);

            if (lesson == null)
                throw new Exception("No such lesson exists");

            _lessonRepository.Delete(lesson);
        }
    }
}
