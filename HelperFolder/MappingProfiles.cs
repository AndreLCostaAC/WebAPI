using AutoMapper;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.HelperFolder
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<User, UserDto>();
            CreateMap<Client, ClientDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Tickets, TicketsDto>(); 
            CreateMap<CountryDto, Country>();
            CreateMap<TicketsDto, Tickets>();
            CreateMap<UserDto, User>();
        }
    }
}
