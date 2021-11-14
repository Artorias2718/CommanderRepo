using AutoMapper;
using Commander.Models;
using Commander.DTO;

namespace Commander.Profiles
{
    public class Commands : Profile
    {
        public Commands()
        {
            // Source => Target
            CreateMap<Command, CommandRead>();
            CreateMap<CommandCreate, Command>();
        }
    }
}