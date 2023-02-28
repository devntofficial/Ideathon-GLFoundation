using AutoMapper;
using GLFoundation.Identity.Api.Domain;
using GLFoundation.Identity.Api.Features.CreateUser;

namespace GLFoundation.Identity.Api
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<User, CreateUserResponse>();
        }
    }
}
