﻿using GLFoundation.Identity.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace GLFoundation.Identity.Api.Persistence
{
    public class UserService : IUserService
    {
        private readonly IdentityDbContext db;

        public UserService(IdentityDbContext db)
        {
            this.db = db;
        }

        public async Task<User> Create(User user, CancellationToken token = default)
        {
            await db.Users.AddAsync(user, token);
            await db.SaveChangesAsync(token);
            return user;
        }

        public async Task<bool> ExistsByEmailId(string emailId, CancellationToken token = default)
        {
            return await db.Users.AsNoTracking().AnyAsync(x => x.EmailId.Equals(emailId), token);
        }
    }
}
