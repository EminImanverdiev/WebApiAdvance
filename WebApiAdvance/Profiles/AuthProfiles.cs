using AutoMapper;
using WebApiAdvance.Entities.Auth;
using WebApiAdvance.Entities.DTOs.Auth;

namespace WebApiAdvance.Profiles
{
    public class AuthProfiles:Profile
    {
        public AuthProfiles()
        {
            CreateMap<RegisterDto, AppUser<Guid>>();
        }
    }
}
