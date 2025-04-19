using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Dtos.User;
using BookHavenClassLibrary.Enumz;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Models;
using BookHavenClassLibrary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookHavenClassLibrary.Services
{
    public class UserSessionService: IUserSessionService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly IUserRepository _userRepository;

        // No longer using singleton pattern
        public AppUser? CurrentUser { get; private set; }
        public UserRoleType CurrentUserRole => CurrentUser?.Role ?? UserRoleType.Clerk;
        public bool IsAuthenticated => CurrentUser != null;

        // Regular constructor for dependency injection
        public UserSessionService(IDbContextFactory<AppDbContext> contextFactory, IUserRepository userRepository)
        {
            _contextFactory = contextFactory;
            _userRepository = userRepository;
        }

        public async Task<bool> LoginAsync(LoginRequestDto loginRequest)
        {
            UserResponseDto? userResponse = await _userRepository.LoginAsync(loginRequest);

            if (userResponse != null)
            {
                // Store user details
                CurrentUser = new AppUser
                {
                    Id = userResponse.Id,
                    FirstName = userResponse.FirstName,
                    LastName = userResponse.LastName,
                    UserName = userResponse.Email,
                    Email = userResponse.Email,
                    // Set other properties 
                    Role = userResponse.Role
                };

                return true;
            }

            return false;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public bool HasPermission(params UserRoleType[] allowedRoles)
        {
            if (!IsAuthenticated)
                return false;

            return Array.Exists(allowedRoles, role => role == CurrentUserRole);
        }
    }
}
