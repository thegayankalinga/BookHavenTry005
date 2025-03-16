using BookHavenClassLibrary.Enumz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenWinFormUi.Utilz
{
    public static class UserSession
    {
        public static int? UserId { get; private set; }
        public static string? UserName { get; private set; }
        public static UserRoleType? Role { get; private set; }
        public static string? Email { get; private set; }

        public static bool IsLoggedIn => UserId != null;

        public static void SetUser(int userId, string email, string userName, UserRoleType role)
        {
            UserId = userId;
            Email = email;
            UserName = userName;
            Role = role;
        }

        public static void Logout()
        {
            UserId = null;
            Email = null;
            UserName = null;
            Role = null;
        }
    }
}
