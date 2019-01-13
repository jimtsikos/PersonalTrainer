using Application.Trainers.Dtos;
using AutoMapper;
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
            });
        }
    }
}
