using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHavenClassLibrary.Dtos.Customer;
using BookHavenClassLibrary.Dtos.User;
using BookHavenClassLibrary.Enumz;

namespace BookHavenClassLibrary.Dtos.Sales
{
    public class SalesResponseDto
    {
        public int SalesId { get; set; }
        public int? CustomerId { get; set; }
        public CustomerResponseDto? Customer { get; set; }
        public string UserId { get; set; }
        public UserResponseDto? User { get; set; }
        public DeliveryMethods DeliveryMethod { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<SaleItemResponseDto> SaleItems { get; set; } = new List<SaleItemResponseDto>();

    }
}
