using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHavenClassLibrary.Enumz;

namespace BookHavenClassLibrary.Dtos.User
{
    public class UpdateRequestDto
    {
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public UserRoleType Role { get; set; }
    }
}
