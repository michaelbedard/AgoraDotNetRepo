using AgoraDotNet.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgoraDotNet.Infrastructure.Persistence.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
    }
    
    // public class DbUser
    // {
    //     public string Username { get; set; }
    //     public string PasswordHash { get; set; }
    // }
}