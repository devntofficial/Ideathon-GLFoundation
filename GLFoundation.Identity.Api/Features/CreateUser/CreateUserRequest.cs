using MediatR;

namespace GLFoundation.Identity.Api.Features.CreateUser
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string FullName { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
