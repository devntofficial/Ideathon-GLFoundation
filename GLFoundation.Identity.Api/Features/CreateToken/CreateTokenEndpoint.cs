using FastEndpoints;
using FastEndpoints.Security;
using GLFoundation.Identity.Api.Domain;

namespace GLFoundation.Identity.Api.Features.CreateToken
{
    public class CreateTokenEndpoint : Endpoint<CreateTokenRequest, CreateTokenResponse>
    {
        private readonly IUserService userService;

        public CreateTokenEndpoint(IUserService userService)
        {
            this.userService = userService;
        }

        public override void Configure()
        {
            Post("user/token/create");
            AllowAnonymous();
            Version(1, deprecateAt: 2);
        }

        public override async Task<CreateTokenResponse> ExecuteAsync(CreateTokenRequest req, CancellationToken ct)
        {
            var user = await userService.GetByCredentials(req.EmailId, req.Password, ct);
            if (user is null)
                ThrowError("Invalid credentials");

            var expiresAt = DateTime.UtcNow.AddDays(1);
            return new CreateTokenResponse
            {
                Token = JWTBearer.CreateToken(
                signingKey: "TokenSigningKey",
                expireAt: expiresAt,
                priviledges: u =>
                {
                    u.Roles.Add(user.Role);
                    u.Claims.Add(new("Id", user.Id));
                }),
                ExpiresAt = expiresAt
            };
        }
    }
}
