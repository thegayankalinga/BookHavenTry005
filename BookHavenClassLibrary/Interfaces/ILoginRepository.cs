using BookHavenClassLibrary.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Interfaces
{
    public interface ILoginRepository
    {
        UserResponseDto? Login(LoginRequestDto loginRequest);
        UserResponseDto? Register(RegistrationRequestDto registrationRequest);
    }
}
