using BookHavenClassLibrary.Enumz;
using BookHavenClassLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System.Security.Cryptography;
using System.Text;


namespace BookHavenClassLibrary.Connections
{
    public class AppDbContext:  IdentityDbContext<AppUser>
    {
        //private readonly IConfiguration _configuration;

        public AppDbContext( DbContextOptions<AppDbContext> options) : base(options)
        {

        }

       

        //Add my entity models here
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<SupplierOrder> SupplierOrders { get; set; }
        public DbSet<SupplierOrderItem> SupplierOrderItems { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sales> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }

        public DbSet<Payment> Payments { get; set; }

        //dotnet ef migrations add InitialCreate
        //dotnet ef database update


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }

       
    }
}

