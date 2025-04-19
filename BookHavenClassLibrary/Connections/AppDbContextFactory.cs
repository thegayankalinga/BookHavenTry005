using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace BookHavenClassLibrary.Connections
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();
            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                //var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "BookHavenClassLibrary"); -> if the appsettings.json is in the class library

                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) //remember in the ui project csproj file this should be set to output like below
                /*
                  <ItemGroup>
                        <None Update="appsettings.json">
                            <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                        </None>
                </ItemGroup>
                 */
                .AddEnvironmentVariables()
                .Build();

            // Prioritize the environment variable, fallback to appsettings.json
            string? connectionString = Environment.GetEnvironmentVariable("DefaultConnection")
                                      ?? config.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("❌ No database connection string found.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
