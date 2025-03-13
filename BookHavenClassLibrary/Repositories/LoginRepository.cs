using BookHavenClassLibrary.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Repositories
{
    class LoginRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
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
    }
}
