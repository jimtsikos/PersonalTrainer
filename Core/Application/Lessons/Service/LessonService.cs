using System;
using System.Collections.Generic;
using Application.Handlers;
using Application.Lessons.Dtos;
using DomainModel.Lesson;
using DomainModel.LessonImpl;
using DomainModel.LessonImpl.Enum;
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

        public ResultHandler<LessonDto> Get(Guid lessonId)
        {
            ResultHandler<LessonDto> resultHandler = new ResultHandler<LessonDto>();

            try
            {
                Lesson lesson = _lessonRepository.FindOne(lessonId);
                resultHandler.Data = AutoMapper.Mapper.Map<Lesson, LessonDto>(lesson);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<IEnumerable<LessonDto>> GetList()
        {
            ResultHandler<IEnumerable<LessonDto>> resultHandler = new ResultHandler<IEnumerable<LessonDto>>();

            try
            {
                IEnumerable<Lesson> lessons = _lessonRepository.FindAll();
                resultHandler.Data = AutoMapper.Mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDto>>(lessons);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<IEnumerable<LessonDto>> GetByDate(DateTime dateTime)
        {
            ResultHandler<IEnumerable<LessonDto>> resultHandler = new ResultHandler<IEnumerable<LessonDto>>();

            try
            {
                IEnumerable<Lesson> lessons = _lessonRepository.FindByDate(dateTime);
                resultHandler.Data = AutoMapper.Mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDto>>(lessons);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<IEnumerable<LessonDto>> GetByDateAndTime(DateTime dateTime, string hour)
        {
            ResultHandler<IEnumerable<LessonDto>> resultHandler = new ResultHandler<IEnumerable<LessonDto>>();

            if (!Enum.TryParse(hour, out Hour hourParsed))
            {
                resultHandler.Errors.Add("Hour is not regognised");
                return resultHandler;
            }

            try
            {
                IEnumerable<Lesson> lessons = _lessonRepository.FindByDateAndTime(dateTime, hourParsed);
                resultHandler.Data = AutoMapper.Mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDto>>(lessons);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<LessonDto> Create(LessonDto lessonDto)
        {
            ResultHandler<LessonDto> resultHandler = new ResultHandler<LessonDto>();

            try
            {
                Student student = _studentRepository.FindOne(lessonDto.StudentId);
                if (student == null)
                {
                    resultHandler.Errors.Add("Student could not be found");
                    return resultHandler;
                }

                Trainer trainer = _trainerRepository.FindOne(lessonDto.TrainerId);
                if (trainer == null)
                {
                    resultHandler.Errors.Add("Trainer could not be found");
                    return resultHandler;
                }

                Lesson lesson = null;
                if (!_lesson.HasDublicateLesson(lesson, student, lessonDto.DateTime, lessonDto.Hour, lessonDto.Minutes))
                {
                    lesson = _lesson.Create(student, trainer, lessonDto.DateTime, lessonDto.Hour, lessonDto.Minutes, lessonDto.IsActive, lessonDto.IsPaid);
                }
                else
                {
                    resultHandler.Errors.Add("There is a dublicate lesson");
                    return resultHandler;
                }

                _lessonRepository.Create(lesson);
                resultHandler.Data = AutoMapper.Mapper.Map<Lesson, LessonDto>(lesson);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<LessonDto> Update(LessonDto lessonDto)
        {
            ResultHandler<LessonDto> resultHandler = new ResultHandler<LessonDto>();

            if (lessonDto.Id == Guid.Empty)
            {
                resultHandler.Errors.Add("Id can't be empty");
                return resultHandler;
            }

            try
            {
                Lesson lesson = _lessonRepository.FindOne(lessonDto.Id);
                if (lesson == null)
                {
                    resultHandler.Errors.Add("No such lesson exists");
                    return resultHandler;
                }

                Student student = _studentRepository.FindOne(lessonDto.StudentId);
                if (student == null)
                {
                    resultHandler.Errors.Add("Student could not be found");
                    return resultHandler;
                }

                Trainer trainer = _trainerRepository.FindOne(lessonDto.TrainerId);
                if (trainer == null)
                {
                    resultHandler.Errors.Add("Trainer could not be found");
                    return resultHandler;
                }

                if (!_lesson.HasDublicateLesson(lesson, student, lessonDto.DateTime, lessonDto.Hour, lessonDto.Minutes))
                {
                    lesson = _lesson.Update(lesson, student, trainer, lessonDto.DateTime, lessonDto.Hour, lessonDto.Minutes, lessonDto.IsActive, lessonDto.IsPaid);
                }
                else
                {
                    resultHandler.Errors.Add("There is a dublicate lesson");
                    return resultHandler;
                }

                _lessonRepository.Update(lesson);
                resultHandler.Data = AutoMapper.Mapper.Map<Lesson, LessonDto>(lesson);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }

        public ResultHandler<LessonDto> Delete(Guid lessonId)
        {
            ResultHandler<LessonDto> resultHandler = new ResultHandler<LessonDto>();

            try
            {
                Lesson lesson = _lessonRepository.FindOne(lessonId);
                if (lesson == null)
                {
                    resultHandler.Errors.Add("No such lesson exists");
                    return resultHandler;
                }


                _lessonRepository.Delete(lesson);
                resultHandler.Data = AutoMapper.Mapper.Map<Lesson, LessonDto>(lesson);
            }
            catch (Exception ex)
            {
                resultHandler.Errors.Add(ex.Message);
            }

            return resultHandler;
        }
    }
}
