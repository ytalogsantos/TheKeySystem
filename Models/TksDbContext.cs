using Microsoft.EntityFrameworkCore;

namespace TheKeySystem.Models;

public class TksDbContext : DbContext
{
    public TksDbContext(DbContextOptions<TksDbContext> options) : base(options)
    {
    }

    public DbSet<Key> Keys { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Collaborator> Collaborators { get; set; }
}
