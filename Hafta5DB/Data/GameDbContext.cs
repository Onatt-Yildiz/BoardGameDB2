using BoardGameDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardGameDB.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<RolePage> RolePages { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
    }
}