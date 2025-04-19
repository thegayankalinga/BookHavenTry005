using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHavenClassLibrary.Dtos.Sales;
using BookHavenClassLibrary.Models;

namespace BookHavenClassLibrary.Mappers
{
    public class SalesItemMapper
    {
        public static SaleItemResponseDto? MapToResponseDto(SaleItem saleItem)
        {
            if (saleItem == null)
            {
                return null;
            }

            return new SaleItemResponseDto
            {
                SaleItemId = saleItem.SaleItemId,
                SaleId = saleItem.SaleId,
                BookId = saleItem.BookId,
                Book = saleItem.Book != null ? BookMapper.MapToBookResponseDto(saleItem.Book) : null,
                Quantity = saleItem.Quantity,
                UnitPrice = saleItem.UnitPrice,
                Subtotal = saleItem.Subtotal,
                Discount = saleItem.Discount
            };
        }

        public static SaleItem MapToModel(SaleItemRequestDto request)
        {
            return new SaleItem
            {
                SaleId = request.SalesId,
                BookId = request.BookId,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
                Discount = request.Discount,
                Subtotal = request.Quantity * request.UnitPrice - request.Discount
            };
        }
    }
}
