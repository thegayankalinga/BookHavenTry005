using BookHavenClassLibrary.Dtos.Customer;
using BookHavenClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Mappers
{
    public class CustomerMapper
    {
        public static CustomerResponseDto? MapToResponseDto(Customer customer)
        {
            if (customer == null)
            {
                return null;
            }
            return new CustomerResponseDto
            {
                Id = customer.CustomerId,
                FullName = customer.FullName,
                PhoneNumber = customer.PhoneNumber,
                AddressLineOne = customer.AddressLineOne,
                AddressLineTwo = customer.AddressLineTwo,
                City = customer.City
            };
        }

        public static Customer MaptoModel(CustomerRequestDto request)
        {
            return new Customer
            {
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                AddressLineOne = request.AddressLineOne,
                AddressLineTwo = request.AddressLineTwo,
                City = request.City
            };
        }
    }
}
