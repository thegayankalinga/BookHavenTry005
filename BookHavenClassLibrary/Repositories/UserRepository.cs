using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Dtos.User;
using BookHavenClassLibrary.Enumz;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Mappers;
using BookHavenClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

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

        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public UserResponseDto? Login(LoginRequestDto loginRequest)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == loginRequest.Email);
            if (user == null)
                return null;

            //Verify the password
            string passwordHash = ComputeHash(loginRequest.Password, user.Salt);
            if (passwordHash != user.PasswordHash)
            {
                return null;
                //TODO: Throw an exception
            }

            user.LastLoginAt = DateTime.Now;
            _context.SaveChanges();
            return UserMapper.MapToUserResponseDto(user);
        }

        public UserResponseDto? Register(RegistrationRequestDto registrationRequest)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == registrationRequest.Email);
            if (existingUser != null)
                return null;
            //TODO: Return a custom exception here

            string salt = GenerateSalt();
            string passwordHash = ComputeHash(registrationRequest.Password, salt);
            var user = UserMapper.MapToUser(registrationRequest);
            user.Salt = salt;
            user.PasswordHash = passwordHash;

            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

            return UserMapper.MapToUserResponseDto(user);
        }

        public void SeedUsers()
        {
            if (!_context.Users.Any()) // Ensure we only seed if the database is empty
            {
                var users = new List<User>
        {
            new User
            {
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@bookhaven.com",
                Role = UserRoleType.Admin,
                CreatedAt = DateTime.Now,
                LastLoginAt = DateTime.Now
            },
            new User
            {
                FirstName = "John",
                LastName = "Sales 001",
                Email = "sales001@bookhaven.com",
                Role = UserRoleType.Sales,
                CreatedAt = DateTime.Now,
                LastLoginAt = DateTime.Now
            },
            new User
            {
                FirstName = "John",
                LastName = "Clerk 001",
                Email = "clerk001@bookhaven.com",
                Role = UserRoleType.Clerk,
                CreatedAt = DateTime.Now,
                LastLoginAt = DateTime.Now
            }
        };

                foreach (var user in users)
                {
                    string salt = GenerateSalt();
                    string passwordHash = ComputeHash("test123!", salt);

                    user.Salt = salt;
                    user.PasswordHash = passwordHash;

                    _context.Users.Add(user);
                }

                _context.SaveChanges();
                Console.WriteLine("✅ Users seeded successfully.");
            }
            else
            {
                Console.WriteLine("ℹ️ Users already exist in the database. No seeding performed.");
            }
        }

    }
}
