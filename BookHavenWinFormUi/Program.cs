using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Repositories;
using BookHavenWinFormUi.Utilz;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;

namespace BookHavenWinFormUi
{
    internal static class Program
    {
        public static IHost Host { get; private set; } = null!;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
            //var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    config.AddEnvironmentVariables();

                    
                }).ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IConfiguration>(context.Configuration);

                    //DB if no EF COre
                    //services.AddSingleton<DatabaseService>();


                    //EF Core
                    string? connectionString = Environment.GetEnvironmentVariable("DefaultConnection")
                          ?? context.Configuration.GetConnectionString("DefaultConnection");



                    if (string.IsNullOrEmpty(connectionString))
                    {
                        throw new InvalidOperationException("DefaultConnection is missing from appsettings.json");
                    }

                    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));



                    //Register Repositories
                    //services.AddSingleton<IRepository, Repository>();
                    


                    services.AddScoped<IUserRepository, UserRepository>();


                    //Register Forms
                    services.AddTransient<LoginForm>();
                    services.AddTransient<MainForm>();

                    services.AddSingleton<NavigationService>();

                }).Build();

            

            using var scope = Host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var loginForm = services.GetRequiredService<LoginForm>();
                Application.Run(loginForm);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }
    }
}