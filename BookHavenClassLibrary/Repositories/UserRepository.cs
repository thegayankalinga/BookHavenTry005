using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Dtos.User;
using BookHavenClassLibrary.Enumz;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Mappers;
using BookHavenClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public UserRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        private string ComputeHash(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            string passwordWithSalt = password + salt;
            byte[] bytes = Encoding.UTF8.GetBytes(passwordWithSalt);
            byte[] hash = sha256.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }

        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        public async Task<UserResponseDto?> LoginAsync(LoginRequestDto loginRequest)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == loginRequest.Email).ConfigureAwait(false);

            if (user == null)
                return null;

            // Verify password
            string passwordHash = ComputeHash(loginRequest.Password, user.Salt);
            if (passwordHash != user.PasswordHash)
                return null;

            user.LastLoginAt = DateTime.UtcNow;
            await dbContext.SaveChangesAsync().ConfigureAwait(false);

            return UserMapper.MapToUserResponseDto(user);
        }

        public async Task<UserResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequest)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == registrationRequest.Email).ConfigureAwait(false);

            if (existingUser != null)
                return null; // Email already registered

            string salt = GenerateSalt();
            string passwordHash = ComputeHash(registrationRequest.Password, salt);
            var user = UserMapper.MapToUser(registrationRequest);
            user.Salt = salt;
            user.PasswordHash = passwordHash;

            try
            {
                await dbContext.Users.AddAsync(user).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return UserMapper.MapToUserResponseDto(user);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error registering user: {e.Message}");
                return null;
            }
        }

        public async Task SeedUsersAsync()
        {
            using var dbContext = _contextFactory.CreateDbContext();
            if (!await dbContext.Users.AnyAsync().ConfigureAwait(false)) // Seed only if database is empty
            {
                var users = new List<User>
                {
                    new User
                    {
                        FirstName = "Admin",
                        LastName = "User",
                        Email = "admin@bookhaven.com",
                        Role = UserRoleType.Admin,
                        CreatedAt = DateTime.UtcNow,
                        LastLoginAt = DateTime.UtcNow
                    },
                    new User
                    {
                        FirstName = "John",
                        LastName = "Sales",
                        Email = "sales001@bookhaven.com",
                        Role = UserRoleType.Sales,
                        CreatedAt = DateTime.UtcNow,
                        LastLoginAt = DateTime.UtcNow
                    },
                    new User
                    {
                        FirstName = "Jane",
                        LastName = "Clerk",
                        Email = "clerk001@bookhaven.com",
                        Role = UserRoleType.Clerk,
                        CreatedAt = DateTime.UtcNow,
                        LastLoginAt = DateTime.UtcNow
                    }
                };

                foreach (var user in users)
                {
                    string salt = GenerateSalt();
                    string passwordHash = ComputeHash("test123!", salt);

                    user.Salt = salt;
                    user.PasswordHash = passwordHash;

                    await dbContext.Users.AddAsync(user).ConfigureAwait(false);
                }

                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                Console.WriteLine("✅ Users seeded successfully.");
            }
            else
            {
                Console.WriteLine("ℹ️ Users already exist in the database. No seeding performed.");
            }
        }
    }
}
