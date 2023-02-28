using AutoMapper;
using GLFoundation.Identity.Api.Domain;
using GLFoundation.Identity.Api.Features.CreateUser;
using GLFoundation.Identity.Api.Features.GetUser;

namespace GLFoundation.Identity.Api
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<User, CreateUserResponse>();
            CreateMap<User, GetUserResponse>();
        }
    }
}
