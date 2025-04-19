using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Models;
using BookHavenClassLibrary.Repositories;
using BookHavenClassLibrary.Services;
using BookHavenWinFormUi.PanelForms;
using BookHavenWinFormUi.PanelForms.Customer;
using BookHavenWinFormUi.PanelForms.Reports;
using BookHavenWinFormUi.PanelForms.Supplier;
using BookHavenWinFormUi.PanelForms.User;
using BookHavenWinFormUi.Utilz;
using Microsoft.AspNetCore.Identity;
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
        public static ServiceProvider ServiceProvider { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
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

                    //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
                    services.AddDbContextFactory<AppDbContext>(options => options.UseSqlServer(connectionString));

                    services.AddIdentity<AppUser, IdentityRole>()
                        .AddEntityFrameworkStores<AppDbContext>()
                        .AddDefaultTokenProviders();


                    //Register Repositories
                    //services.AddSingleton<IRepository, Repository>();


                    services.AddSingleton<IUserSessionService, UserSessionService>();
                    services.AddScoped<IUserRepository, UserRepository>();
                    services.AddScoped<ISupplierRepository, SupplierRepository>();
                    services.AddScoped<IBookRepository, BookRepository>();
                    services.AddScoped<ISupplierOrderRepository, SupplierOrderRepository>();
                    services.AddScoped<IUnitOfWork, UnitOfWork>();
                    services.AddScoped<ICustomerRepository, CustomerRepository>();
                    services.AddScoped<ISaleItemRepository, SaleItemRepository>();
                    services.AddScoped<ISalesRepository, SalesRepository>();


                    //Register Forms
                    services.AddTransient<LoginForm>();
                    services.AddTransient<MainForm>();
                    services.AddTransient<SupplierForm>();
                    services.AddTransient<BookForm>();
                    services.AddTransient<CustomerForm>();
                    services.AddTransient<OrderForm>();
                    services.AddTransient<Report>();
                    services.AddTransient<UserForm>();
                    services.AddTransient<SalesForm>();
                    services.AddTransient<Dashboard>();
                    

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