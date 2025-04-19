using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHavenClassLibrary.Dtos.Sales;
using BookHavenClassLibrary.Models;

namespace BookHavenClassLibrary.Mappers
{
    public static class SaleMapper
    {
        public static SalesResponseDto? MapToResponseDto(Sales sales)
        {
            if (sales == null)
            {
                return null;
            }

            return new SalesResponseDto
            {
                SalesId = sales.SalesId,
                CustomerId = sales.CustomerId,
                Customer = sales.Customer != null ? CustomerMapper.MapToResponseDto(sales.Customer) : null,
                UserId = sales.UserId,
                User = sales.User != null ? UserMapper.MapToUserResponseDto(sales.User) : null,
                DeliveryMethod = sales.DeliveryMethod,
                SaleDate = DateTime.Now, // This should come from the database if available
                TotalAmount = 0, // This would be calculated from SaleItems
                SaleItems = new List<SaleItemResponseDto>() // This would be populated separately
            };
        }

        public static Sales MapToModel(SalesRequestDto request)
        {
            return new Sales
            {
                CustomerId = (int)request.CustomerId,
                UserId = request.UserId,
                DeliveryMethod = request.DeliveryMethod
                // SaleItems would be created separately
            };
        }
    }
}
