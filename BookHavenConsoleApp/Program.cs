using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Enumz;
using BookHavenClassLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;




namespace SeedDataConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true)
    .AddEnvironmentVariables()
    .Build();
            Console.WriteLine("Starting data seeding...");

            // Create service collection
            var services = new ServiceCollection();

            // Add DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Add Identity
            services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

            // Build service provider
            var serviceProvider = services.BuildServiceProvider();

            // Call our own seed method
            await SeedUsersAndRolesAsync(serviceProvider);

            Console.WriteLine("Data seeding completed successfully!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // New seed method that doesn't depend on IApplicationBuilder
        private static async Task SeedUsersAndRolesAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var scopedProvider = scope.ServiceProvider;
            var context = scopedProvider.GetRequiredService<AppDbContext>();

            // Roles
            var roleManager = scopedProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = { "Admin", "Sales", "Clerk" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Users
            var userManager = scopedProvider.GetRequiredService<UserManager<AppUser>>();

            // Admins
            var adminEmails = new[]
            {
                "gayan@bookhaven.com",
                "admin@bookhaven.com"
            };

            foreach (var email in adminEmails)
            {
                var adminUser = await userManager.FindByEmailAsync(email);
                if (adminUser == null)
                {
                    var firstName = email.StartsWith("gayan") ? "Gayan" : "Admin";
                    var newAdminUser = new AppUser
                    {
                        UserName = email,
                        Email = email,
                        EmailConfirmed = true,
                        FirstName = firstName,
                        LastName = "Admin",
                        Role = UserRoleType.Admin,
                        CreatedAt = DateTime.Now,
                        LastLoginAt = DateTime.Now
                    };
                    await userManager.CreateAsync(newAdminUser, "test123");
                    await userManager.AddToRoleAsync(newAdminUser, "Admin");
                }
            }

            // Sales
            for (int i = 1; i <= 4; i++)
            {
                string salesEmail = $"sales{i:000}@bookhaven.com";
                var salesUser = await userManager.FindByEmailAsync(salesEmail);
                if (salesUser == null)
                {
                    salesUser = new AppUser
                    {
                        UserName = salesEmail,
                        Email = salesEmail,
                        EmailConfirmed = true,
                        FirstName = $"Sales",
                        LastName = $"#{i}",
                        Role = UserRoleType.Sales,
                        CreatedAt = DateTime.Now,
                        LastLoginAt = DateTime.Now
                    };
                    await userManager.CreateAsync(salesUser, "test123");
                    await userManager.AddToRoleAsync(salesUser, "Sales");
                }
            }

            // Clerks
            for (int i = 1; i <= 4; i++)
            {
                string clerkEmail = $"clerk{i:000}@bookhaven.com";
                var clerkUser = await userManager.FindByEmailAsync(clerkEmail);
                if (clerkUser == null)
                {
                    clerkUser = new AppUser
                    {
                        UserName = clerkEmail,
                        Email = clerkEmail,
                        EmailConfirmed = true,
                        FirstName = $"Clerk",
                        LastName = $"#{i}",
                        Role = UserRoleType.Clerk,
                        CreatedAt = DateTime.Now,
                        LastLoginAt = DateTime.Now
                    };
                    await userManager.CreateAsync(clerkUser, "test123");
                    await userManager.AddToRoleAsync(clerkUser, "Clerk");
                }
            }

            await context.SaveChangesAsync();
        }
    }
}