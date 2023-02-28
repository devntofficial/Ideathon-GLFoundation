using FastEndpoints;
using MediatR;

namespace GLFoundation.Identity.Api.Features.GetUser
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        [FromClaim("UserId")]
        public string UserId { get; set; } = string.Empty;
    }
}
