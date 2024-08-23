using AgoraDotNet.Core.Entities;
using AgoraDotNet.Core.Interfaces;
using AgoraDotNet.Infrastructure.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace AgoraDotNet.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<User?> GetUserById(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == username);
        }
        
        public async Task UpdateUser(User user)
        {
            var dbUser = await GetByUsername(user.Username);

            if (dbUser != null)
            {
                dbUser.Username = user.Username;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}