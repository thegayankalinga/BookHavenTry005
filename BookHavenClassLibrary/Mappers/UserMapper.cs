using BookHavenClassLibrary.Dtos.User;
using BookHavenClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Mappers
{
    public class UserMapper
    {
        public static UserResponseDto? MapToUserResponseDto(User user)
        {
            if (user == null)
                return null;

            return new UserResponseDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
                CreatedAt = user.CreatedAt,
                LastLoginAt = user.LastLoginAt
            };
        }

        public static User MapToUser(RegistrationRequestDto registrationRequest)
        {
            return new User
            {

                FirstName = registrationRequest.FirstName,
                LastName = registrationRequest.LastName,
                Email = registrationRequest.Email,
                Role = registrationRequest.Role,
                CreatedAt = DateTime.Now,

            };
        }
    }
}
