using FastEndpoints;

namespace GLFoundation.Identity.Api.Features.CreateUser
{
    public class CreateUserSummary : Summary<CreateUserEndpoint>
    {
        public CreateUserSummary()
        {
            Summary = "Summary";
            Description = "Description";
        }
    }
}
