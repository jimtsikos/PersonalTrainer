using Application.Handlers;
using Application.Lessons.Dtos;
using Application.Students.Dtos;
using Application.StudentWeights.Dtos;
using Application.Trainers.Dtos;
using AutoMapper;
using PersonalTrainer.WebApp.Core.Models;
using System.Collections.Generic;

namespace PersonalTrainer.WebApp.Core.Areas.Mapping
{
    public class ViewModelMap : Profile
    {
        public ViewModelMap()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<ResultHandler<TrainerDto>, ResultViewModel<TrainerDto>>()
                    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                    .ForMember(dest => dest.SuccessMessage, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors))
                    .ForMember(dest => dest.HasErrors, opt => opt.MapFrom(src => src.HasErrors));

                x.CreateMap<ResultHandler<IEnumerable<TrainerDto>>, ResultViewModel<IEnumerable<TrainerDto>>>()
                    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                    .ForMember(dest => dest.SuccessMessage, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors))
                    .ForMember(dest => dest.HasErrors, opt => opt.MapFrom(src => src.HasErrors));

                x.CreateMap<ResultHandler<StudentDto>, ResultViewModel<StudentDto>>()
                    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                    .ForMember(dest => dest.SuccessMessage, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors))
                    .ForMember(dest => dest.HasErrors, opt => opt.MapFrom(src => src.HasErrors));

                x.CreateMap<ResultHandler<IEnumerable<StudentDto>>, ResultViewModel<IEnumerable<StudentDto>>>()
                    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                    .ForMember(dest => dest.SuccessMessage, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors))
                    .ForMember(dest => dest.HasErrors, opt => opt.MapFrom(src => src.HasErrors));

                x.CreateMap<ResultHandler<StudentWeightDto>, ResultViewModel<StudentWeightDto>>()
                    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                    .ForMember(dest => dest.SuccessMessage, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors))
                    .ForMember(dest => dest.HasErrors, opt => opt.MapFrom(src => src.HasErrors));

                x.CreateMap<ResultHandler<IEnumerable<StudentWeightDto>>, ResultViewModel<IEnumerable<StudentWeightDto>>>()
                    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                    .ForMember(dest => dest.SuccessMessage, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors))
                    .ForMember(dest => dest.HasErrors, opt => opt.MapFrom(src => src.HasErrors));

                x.CreateMap<ResultHandler<LessonDto>, ResultViewModel<LessonDto>>()
                    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                    .ForMember(dest => dest.SuccessMessage, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors))
                    .ForMember(dest => dest.HasErrors, opt => opt.MapFrom(src => src.HasErrors));

                x.CreateMap<ResultHandler<IEnumerable<LessonDto>>, ResultViewModel<IEnumerable<LessonDto>>>()
                    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                    .ForMember(dest => dest.SuccessMessage, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors))
                    .ForMember(dest => dest.HasErrors, opt => opt.MapFrom(src => src.HasErrors));
            });
        }
    }
}
