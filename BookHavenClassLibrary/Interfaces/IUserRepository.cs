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
        Task<UserResponseDto?> Login(LoginRequestDto loginRequest);
        Task<UserResponseDto?> Register(RegistrationRequestDto registrationRequest);
    }
}
