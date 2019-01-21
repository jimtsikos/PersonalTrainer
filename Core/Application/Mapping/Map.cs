using Application.Lessons.Dtos;
using Application.Students.Dtos;
using Application.StudentWeights.Dtos;
using Application.Trainers.Dtos;
using AutoMapper;
using DomainModel.LessonImpl;
using DomainModel.StudentsImpl;
using DomainModel.StudentWeightsImpl;
using DomainModel.TrainersImpl;

namespace Application.Mapping
{
    public class Map : Profile
    {
        public Map()
        {
            Mapper.Initialize(x => 
            {
                x.CreateMap<Trainer, TrainerDto>();

                x.CreateMap<Student, StudentDto>().ForMember(
                    dest => dest.StudentWeights,
                    opt => opt.MapFrom(src => src.StudentWeights));

                x.CreateMap<StudentWeight, StudentWeightDto>().ForMember(
                    dest => dest.StudentId,
                    opt => opt.MapFrom(src => src.StudentId));

                x.CreateMap<Lesson, LessonDto>();
            });
        }
    }
}
