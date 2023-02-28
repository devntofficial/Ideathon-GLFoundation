using FastEndpoints;
using GLFoundation.Identity.Api.Domain;
using MediatR;

namespace GLFoundation.Identity.Api.Features.CreateUser
{
    public class CreateUserEndpoint : Endpoint<CreateUserRequest, CreateUserResponse>
    {
        private readonly IMediator mediator;
        private readonly IUserService userService;

        public CreateUserEndpoint(IMediator mediator, IUserService userService)
        {
            this.mediator = mediator;
            this.userService = userService;
        }

        public override void Configure()
        {
            Post("user/create");
            AllowAnonymous();
            Version(1, deprecateAt: 2);
        }

        public override async Task<CreateUserResponse> ExecuteAsync(CreateUserRequest req, CancellationToken ct)
        {
            if (await userService.ExistsByEmailId(req.EmailId, ct))
                ThrowError("User already exists");

            return await mediator.Send(req, ct);
        }
    }
}
