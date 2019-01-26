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

            base.CreateMap<Trainer, TrainerDto>();

            base.CreateMap<Student, StudentDto>().ForMember(
                    dest => dest.StudentWeights,
                    opt => opt.MapFrom(src => src.StudentWeights));

            base.CreateMap<StudentWeight, StudentWeightDto>()
                    .ForMember(
                        dest => dest.StudentId,
                        opt => opt.MapFrom(src => src.StudentId))
                    .ForMember(
                        dest => dest.StudentName,
                        opt => opt.MapFrom(src => string.Format("{0} {1}", src.Student.FirstName, src.Student.LastName)));

            base.CreateMap<Lesson, LessonDto>()
                    .ForMember(
                        dest => dest.StudentName,
                        opt => opt.MapFrom(src => string.Format("{0} {1}", src.Student.FirstName, src.Student.LastName)))
                    .ForMember(
                        dest => dest.TrainerName,
                        opt => opt.MapFrom(src => string.Format("{0} {1}", src.Trainer.FirstName, src.Trainer.LastName)))
                    .ForMember(
                        dest => dest.Money,
                        opt => opt.MapFrom(src => src.Student.PrepaidMoney));
        }
    }
}
