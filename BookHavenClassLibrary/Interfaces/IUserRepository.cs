using BookHavenClassLibrary.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Interfaces
{
    public interface IUserRepository
    {
        Task<UserResponseDto?> LoginAsync(LoginRequestDto loginRequest);
        Task<UserResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequest);

        Task<bool> ChangePasswordAsync(string id, string currentPassword, string newPassword);
        Task<List<UserResponseDto?>> GetAllAsync();
        Task<UserResponseDto?> GetByIdAsync(string id);
        Task<bool> UpdateAsync(string id, UpdateRequestDto request);
        Task<bool> DeleteAsync(string id);
        Task<bool> ExistsAsync(string id);
    }
}
