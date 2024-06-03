using Microsoft.EntityFrameworkCore;
using AuthSysWithHashFunc.Models;
using System.Reflection.Metadata;

namespace AuthSysWithHashFunc.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
        public DbSet<User> Users { get; set; } = default!;
    }
}
