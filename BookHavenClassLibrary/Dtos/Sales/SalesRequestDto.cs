using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHavenClassLibrary.Enumz;

namespace BookHavenClassLibrary.Dtos.Sales
{
    public class SalesRequestDto
    {
        public int? CustomerId { get; set; }
        public required string UserId { get; set; } // ID of the user making the sale
        public DeliveryMethods DeliveryMethod { get; set; }
        public List<SaleItemRequestDto> SaleItems { get; set; } = new List<SaleItemRequestDto>();
    }
}
