using FastEndpoints;

namespace GLFoundation.Identity.Api.Features.CreateUser
{
    public class CreateUserSummary : Summary<CreateUserEndpoint>
    {
        public CreateUserSummary()
        {
            Summary = "Summary";
            Description = "Description";
            //lot more options can be set here, look at fastendpoints documentation
            //this describes the api on swagger doc
        }
    }
}
