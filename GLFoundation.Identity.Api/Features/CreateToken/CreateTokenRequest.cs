using MediatR;

namespace GLFoundation.Identity.Api.Features.CreateToken
{
    public class CreateTokenRequest : IRequest<CreateTokenResponse>
    {
        public string EmailId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
