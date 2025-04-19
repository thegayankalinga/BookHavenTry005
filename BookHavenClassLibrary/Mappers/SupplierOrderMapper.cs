using BookHavenClassLibrary.Dtos.Supplier;
using BookHavenClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Mappers
{
    public class SupplierOrderMapper
    {
        public static SupplierOrderResponseDto? MapToSupplierOrderResponseDto(SupplierOrder order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            var orderItems = order.SupplierOrderItems.Select(item => new SupplierOrderItemResponseDto
            {
                OrderItemId = item.OrderItemId,
                BookId = item.BookId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            }).ToList();

            return new SupplierOrderResponseDto
            {
                SupplierOrderId = order.SupplierOrderId,
                SupplierId = order.SupplierId,
                OrderDate = order.OrderDate,
                OrderStatuses = order.OrderStatuses,
                OrderItems = orderItems,
                TotalPrice = orderItems.Sum(item => item.Quantity * item.UnitPrice) // Calculate total here
            };
        }

        public static SupplierOrder MapToSupplierOrder(SupplierOrderRequestDto request)
        {
            return new SupplierOrder
            {
                SupplierId = request.SupplierId,
                OrderDate = request.OrderDate,
                OrderStatuses = request.OrderStatuses,

            };
        }
    }
}
