using AutoMapper;
using PetPal_Model.DTOs;
using PetPal_Model.Models;

namespace PetPal_Business.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>();
            CreateMap<Animal, AnimalDto>();
        }
    }
}
