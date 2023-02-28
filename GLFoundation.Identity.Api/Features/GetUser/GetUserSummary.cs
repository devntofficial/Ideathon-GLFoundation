using FastEndpoints;

namespace GLFoundation.Identity.Api.Features.GetUser
{
    public class GetUserSummary : Summary<GetUserEndpoint>
    {
        public GetUserSummary()
        {
            Summary = "Gets user details based on Bearer token";
            Description = "This API requires a valid token to be passed in request header implying that the user is logged in.";
        }
    }
}
