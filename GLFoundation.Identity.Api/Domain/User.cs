using GLFoundation.Shared.Library.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLFoundation.Identity.Api.Domain
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string EmailId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = UserRoles.Member;
        public string Password { get; set; } = string.Empty;
        public bool IsBlocked { get; set; } = false;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
