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
                SaleDate = sales.SaleDate,
                SaleItems = sales.SaleItems.Select(SalesItemMapper.MapToResponseDto).ToList(),
                TotalAmount = sales.SaleItems.Sum(i => i.Subtotal)
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
