using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Dtos.User;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Mappers;
using BookHavenClassLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace BookHavenClassLibrary.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;


        public UserRepository(IDbContextFactory<AppDbContext> contextFactory, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _contextFactory = contextFactory;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<UserResponseDto?> LoginAsync(LoginRequestDto loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null)
                return null;

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, false);
            if (!result.Succeeded)
                return null;

            user.LastLoginAt = DateTime.UtcNow;
            await _userManager.UpdateAsync(user); // Persist LastLoginAt

            return UserMapper.MapToUserResponseDto(user);
        }

        public async Task<UserResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequest)
        {
            var existingUser = await _userManager.FindByEmailAsync(registrationRequest.Email);
            if (existingUser != null)
                return null; // Email already exists

            var user = UserMapper.MapToUser(registrationRequest);
            user.UserName = registrationRequest.Email; // Required by Identity
            user.CreatedAt = DateTime.UtcNow;
            user.LastLoginAt = DateTime.UtcNow;

            var result = await _userManager.CreateAsync(user, registrationRequest.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"❌ Identity error: {error.Code} - {error.Description}");
                }
                return null;
            }
            await _userManager.AddToRoleAsync(user, registrationRequest.Role.ToString());


            return UserMapper.MapToUserResponseDto(user);
        }
  
        public async Task<bool> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return false;

            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"❌ Password change failed: {error.Code} - {error.Description}");
                }
                return false;
            }

            return true;
        }

        public async Task<List<UserResponseDto?>> GetAllAsync()
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var users = await dbContext.Users.AsNoTracking().ToListAsync().ConfigureAwait(false);
            return users.Select(UserMapper.MapToUserResponseDto).ToList();
        }

        public async Task<UserResponseDto?> GetByIdAsync(string id)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var user = await dbContext.Users.FindAsync(id).ConfigureAwait(false);

            if (user == null)
                return null;

            return UserMapper.MapToUserResponseDto(user);
        }


        public async Task<bool> UpdateAsync(string id, RegistrationRequestDto request)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var user = await dbContext.Users.FindAsync(id).ConfigureAwait(false);

            if (user == null)
                return false;

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.UserName = request.Email;
            user.Role = request.Role;

            try
            {
                dbContext.Users.Update(user);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public async Task<bool> DeleteAsync(string id)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var user = await dbContext.Users.FindAsync(id).ConfigureAwait(false);

            if (user == null)
                return false;

            try
            {
                dbContext.Users.Remove(user);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }



        public async Task<bool> ExistsAsync(string id)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            return await dbContext.Users.AnyAsync(u => u.Id == id).ConfigureAwait(false);
        }



    }
}
