namespace GLFoundation.Identity.Api.Features.CreateToken
{
    public class CreateTokenResponse
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}
