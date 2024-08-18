using AgoraDotNet.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgoraDotNet.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<SuperHero> SuperHeroes { get; set; }
}