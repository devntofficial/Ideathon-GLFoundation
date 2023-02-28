namespace GLFoundation.Identity.Api.Features.GetUser
{
    public class GetUserResponse
    {
        public string Id { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsBlocked { get; set; } = false;
    }
}
