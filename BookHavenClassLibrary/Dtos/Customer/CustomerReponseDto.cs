using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Dtos.Customer
{
    public class CustomerReponseDto
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string AddressLineOne { get; set; }
        public string? AddressLineTwo { get; set; }
        public required string City { get; set; }

        //TODO: add mapping properties for foreign key relationships
    }
}
