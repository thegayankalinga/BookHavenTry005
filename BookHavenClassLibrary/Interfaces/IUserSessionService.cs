using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHavenClassLibrary.Dtos.User;
using BookHavenClassLibrary.Enumz;
using BookHavenClassLibrary.Models;

namespace BookHavenClassLibrary.Interfaces
{
    public interface IUserSessionService
    {
        AppUser? CurrentUser { get; }
        UserRoleType CurrentUserRole { get; }
        bool IsAuthenticated { get; }

        Task<bool> LoginAsync(LoginRequestDto loginRequest);
        void Logout();
        bool HasPermission(params UserRoleType[] allowedRoles);
    }
}
