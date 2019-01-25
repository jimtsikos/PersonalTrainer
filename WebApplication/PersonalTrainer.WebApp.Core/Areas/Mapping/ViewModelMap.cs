using Application.Extensions.Paging;
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

                x.CreateMap<ResultHandler<PaginatedList<TrainerDto>>, ResultViewModel<PaginatedList<TrainerDto>>>()
                    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                    .ForMember(dest => dest.SuccessMessage, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors))
                    .ForMember(dest => dest.HasErrors, opt => opt.MapFrom(src => src.HasErrors));

                x.CreateMap<ResultHandler<StudentDto>, ResultViewModel<StudentDto>>()
                    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                    .ForMember(dest => dest.SuccessMessage, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors))
                    .ForMember(dest => dest.HasErrors, opt => opt.MapFrom(src => src.HasErrors));

                x.CreateMap<ResultHandler<PaginatedList<StudentDto>>, ResultViewModel<PaginatedList<StudentDto>>>()
                    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                    .ForMember(dest => dest.SuccessMessage, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors))
                    .ForMember(dest => dest.HasErrors, opt => opt.MapFrom(src => src.HasErrors));

                x.CreateMap<ResultHandler<StudentWeightDto>, ResultViewModel<StudentWeightDto>>()
                    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                    .ForMember(dest => dest.SuccessMessage, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors))
                    .ForMember(dest => dest.HasErrors, opt => opt.MapFrom(src => src.HasErrors));

                x.CreateMap<ResultHandler<PaginatedList<StudentWeightDto>>, ResultViewModel<PaginatedList<StudentWeightDto>>>()
                    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                    .ForMember(dest => dest.SuccessMessage, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors))
                    .ForMember(dest => dest.HasErrors, opt => opt.MapFrom(src => src.HasErrors));

                x.CreateMap<ResultHandler<LessonDto>, ResultViewModel<LessonDto>>()
                    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                    .ForMember(dest => dest.SuccessMessage, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors))
                    .ForMember(dest => dest.HasErrors, opt => opt.MapFrom(src => src.HasErrors));

                x.CreateMap<ResultHandler<PaginatedList<LessonDto>>, ResultViewModel<PaginatedList<LessonDto>>>()
                    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                    .ForMember(dest => dest.SuccessMessage, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors))
                    .ForMember(dest => dest.HasErrors, opt => opt.MapFrom(src => src.HasErrors));
            });
        }
    }
}
