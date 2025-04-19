using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Enumz;
using BookHavenClassLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;




namespace SeedDataConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "BookHavenWinFormUi")) // 👈 Load config from WinForm UI
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            Console.WriteLine("Starting data seeding...");

            // Create service collection
            var services = new ServiceCollection();

            // ✅ Logging (required for RoleManager/UserManager)
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Information);
            });

            var connStr = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connStr))
            {
                Console.WriteLine("❌ Connection string not found. Check appsettings.json path or content.");
                return;
            }

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connStr));

            // Add DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Add Identity
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Build service provider
            var serviceProvider = services.BuildServiceProvider();
            Console.WriteLine("Connection: " + configuration.GetConnectionString("DefaultConnection"));
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
                    await userManager.CreateAsync(newAdminUser, "Test@123");
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
                    await userManager.CreateAsync(salesUser, "Test@123");
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
                    await userManager.CreateAsync(clerkUser, "Test@123");
                    await userManager.AddToRoleAsync(clerkUser, "Clerk");
                }
            }

            await context.SaveChangesAsync();
        }
    }
}