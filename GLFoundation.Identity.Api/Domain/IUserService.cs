namespace GLFoundation.Identity.Api.Domain
{
    public interface IUserService
    {
        Task<User> Create(User user, CancellationToken token = default);
        Task<bool> ExistsByEmailId(string emailId, CancellationToken token = default);
    }
}
