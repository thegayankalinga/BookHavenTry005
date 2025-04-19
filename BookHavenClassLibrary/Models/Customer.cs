using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        public required string FullName { get; set; }
        

        public required string PhoneNumber { get; set; }

        public required string AddressLineOne { get; set; }

        public string? AddressLineTwo { get; set; }

        public required string City { get; set; }

        //One to many relationship (one side of the relationship)
        [InverseProperty("Customer")]
        public List<Sales> Sales { get; set; } = new List<Sales>();

    }
}
