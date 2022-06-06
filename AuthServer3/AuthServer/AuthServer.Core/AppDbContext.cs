using AuthServer.Core.Models;
using Microsoft.EntityFrameworkCore;


namespace AuthServer.Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Tbl_Users> Tbl_Users { get; set; }
        public DbSet<Tbl_UserTokens> Tbl_UserTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-K97E4FR;Initial Catalog=MglCoreDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
