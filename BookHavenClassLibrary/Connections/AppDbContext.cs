using BookHavenClassLibrary.Enumz;
using BookHavenClassLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

using System.Security.Cryptography;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


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
        /* -> dotnet ef migrations add InitialMigration --project ../BookHavenClassLibrary --startup-project . --output-dir Connections/Migrations


        dotnet ef migrations add InitialMigration \
            --project BookHavenClassLibrary \
            --startup-project BookHavenWinFormUi \
            --output-dir Connections/Migrations

       
        //dotnet ef database update
        dotnet ef database update --project ../BookHavenClassLibrary --startup-project .

        dotnet ef database update --project BookHavenClassLibrary --startup-project BookHavenWinFormUi

        dotnet ef database update \
            --project BookHavenClassLibrary \
            --startup-project BookHavenWinFormUi
         */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
                .Property(b => b.SellingPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<SaleItem>()
                .Property(s => s.UnitPrice)
                .HasPrecision(18, 2);

        }

       
    }
}

