using BookHavenClassLibrary.Enumz;
using BookHavenClassLibrary.Migrations;
using BookHavenClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;


namespace BookHavenClassLibrary.Connections
{
    public class AppDbContext: DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext( DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Add my entity models here
        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<SupplierOrder> SupplierOrders { get; set; }
        public DbSet<SupplierOrderItem> SupplierOrderItems { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Generate password salt and hash for default users
            //string adminSalt = GenerateSalt();
            //string adminPasswordHash = ComputeHash("admin123", adminSalt);

            //string salesSalt = GenerateSalt();
            //string salesPasswordHash = ComputeHash("test123", salesSalt);

            //string clerkSalt = GenerateSalt();
            //string clerkPasswordHash = ComputeHash("test123", clerkSalt);

            DateTime staticDate = new DateTime(2024, 3, 12, 12, 0, 0);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@bookhaven.com",
                    Role = UserRoleType.Admin,
                    CreatedAt = staticDate,
                    LastLoginAt = staticDate,
                    Salt = "1oX2+HLYhpIImDRzMYlu+g==",
                    PasswordHash = "QpLkF1G7uy0L1+VyiQKduG0qK6JZbbTtFqeRzGcy3Vs="
                },
                new User
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Sales001",
                    Email = "sales001@bookhaven.com",
                    Role = UserRoleType.Sales,
                    CreatedAt = staticDate,
                    LastLoginAt = staticDate,
                    Salt = "cQQxDnVvUg6iSC3qcaVj4Q==",
                    PasswordHash = "rCPxaz0+DAoNSKkvruJH3PxjfDMeIyTYlMFrYl1BmPU="
                },
                new User
                {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Clerk001",
                    Email = "clerk001@bookhaven.com",
                    Role = UserRoleType.Clerk,
                    CreatedAt = staticDate,
                    LastLoginAt = staticDate,
                    Salt = "qf0effYCz9WKVKXCc2A7Zw==",
                    PasswordHash = "Qo2lVpmulOfrFvTYWCP0XlgFQ0q2q+KjQGhhGgNGvd8="
                }
            );
        }

        // 🔹 Helper method to generate a salt
        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // 🔹 Helper method to hash passwords with salt
        private string ComputeHash(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                string passwordWithSalt = password + salt;
                byte[] bytes = Encoding.UTF8.GetBytes(passwordWithSalt);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}

