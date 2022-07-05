using AutoMapper;
using HL.Model;

namespace HL.Service.Mapper
{
    internal class ClassMapper : Profile
    {
        public ClassMapper()
        {
            CreateMap<Game, GameRequest>().ReverseMap();
            CreateMap<Player, PlayerRequest>().ReverseMap();
            CreateMap<PlayerGame, PlayerGameRequest>().ReverseMap();
            CreateMap<Step, StepRequest>().ReverseMap();
            CreateMap<StepAnswer, StepAnswerRequest>().ReverseMap();
        }
    }
}
