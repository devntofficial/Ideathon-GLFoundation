using AutoMapper;
using GLFoundation.Identity.Api.Domain;
using MediatR;

namespace GLFoundation.Identity.Api.Features.GetUser
{
    public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public GetUserHandler(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = await userService.GetById(request.UserId, cancellationToken);
            return mapper.Map<GetUserResponse>(user);
        }
    }
}
