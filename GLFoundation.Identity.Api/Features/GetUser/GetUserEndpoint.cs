using FastEndpoints;
using GLFoundation.Shared.Library.Constants;
using MediatR;

namespace GLFoundation.Identity.Api.Features.GetUser
{
    public class GetUserEndpoint : Endpoint<GetUserRequest, GetUserResponse>
    {
        private readonly IMediator mediator;

        public GetUserEndpoint(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public override void Configure()
        {
            Get("user");
            Roles(UserRoles.SuperAdmin, UserRoles.FoundationAdmin, UserRoles.SportsAdmin, UserRoles.Member);
            Claims("UserId");
            Version(1, deprecateAt: 2);
        }

        public override async Task<GetUserResponse> ExecuteAsync(GetUserRequest req, CancellationToken ct)
        {
            var user = await mediator.Send(req, ct);

            if (user is null)
                ThrowError("Invalid Id");

            return user;
        }
    }
}
