using BookHavenClassLibrary.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookHavenWinFormUi
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = Host.CreateDefaultBuilder()
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
                    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                        Environment.GetEnvironmentVariable("DefaultConnection") ?? 
                        context.Configuration.GetConnectionString("DefaultConnection"))
                    );
                
                      

                    //Register Repositories
                    //services.AddSingleton<IRepository, Repository>();
                    //services.AddScoped<IRepository, Repository>();


                    //Register Forms
                    services.AddTransient<LoginForm>();
                }).Build();

            var loginForm = host.Services.GetRequiredService<LoginForm>();
            Application.Run(loginForm);
        }
    }
}