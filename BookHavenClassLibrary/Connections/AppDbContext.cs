using BookHavenClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace BookHavenClassLibrary.Connections
{
    public class AppDbContext: DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration, DbContextOptions<AppDbContext> options) : base(options)
        {
            _configuration = configuration;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = Environment.GetEnvironmentVariable("DefaultConnection") ?? _configuration.GetConnectionString("DefaultConnection");

        //    if (string.IsNullOrEmpty(connectionString))
        //    {
        //        throw new InvalidOperationException("Connection string is null or empty");
        //    }

        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        //Add my entity models here
        public DbSet<User> Users { get; set; }
    }
}
