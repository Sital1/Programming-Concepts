using Microsoft.EntityFrameworkCore;
using UsingChannels.Services.Data;

namespace UsingChannels.Services;

public class Database : DbContext
{
    public Database(DbContextOptions<Database> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}