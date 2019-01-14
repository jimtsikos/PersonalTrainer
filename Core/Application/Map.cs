using Application.Lessons.Dtos;
using Application.Students.Dtos;
using Application.StudentWeights.Dtos;
using Application.Trainers.Dtos;
using AutoMapper;
using DomainModel.LessonImpl;
using DomainModel.StudentsImpl;
using DomainModel.StudentWeightsImpl;
using DomainModel.TrainersImpl;

namespace Application
{
    public class Map : Profile
    {
        public Map()
        {
            Mapper.Initialize(x => 
            {
                x.CreateMap<Trainer, TrainerDto>();
                x.CreateMap<Student, StudentDto>();
                x.CreateMap<StudentWeight, StudentWeightDto>();
                x.CreateMap<Lesson, LessonDto>();
            });
        }
    }
}
