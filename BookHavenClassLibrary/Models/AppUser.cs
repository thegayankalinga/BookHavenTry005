using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHavenClassLibrary.Enumz;
using Microsoft.AspNetCore.Identity;

namespace BookHavenClassLibrary.Models
{
    public class AppUser:IdentityUser
    {
  
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required]
        public UserRoleType Role { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastLoginAt { get; set; }

        //One to many relationship (one side of the relationship)
        public List<Sales> Sales { get; set; } = new List<Sales>();
    }
}
