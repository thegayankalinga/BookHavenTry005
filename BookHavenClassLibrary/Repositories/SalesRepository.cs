using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Dtos.Sales;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Mappers;
using BookHavenClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookHavenClassLibrary.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public SalesRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<bool> AddAsync(SalesRequestDto request)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            try
            {
                var sales = new Sales
                {
                    CustomerId = (int)request.CustomerId,
                    UserId = request.UserId,
                    DeliveryMethod = request.DeliveryMethod
                };

                await dbContext.Sales.AddAsync(sales).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);

                // Now add the sale items
                foreach (var item in request.SaleItems)
                {
                    var saleItem = new SaleItem
                    {
                        SaleId = sales.SalesId,
                        BookId = item.BookId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        Discount = item.Discount,
                        Subtotal = item.Quantity * item.UnitPrice - item.Discount
                    };

                    await dbContext.SaleItems.AddAsync(saleItem).ConfigureAwait(false);

                    // Update book stock
                    var book = await dbContext.Books.FindAsync(item.BookId).ConfigureAwait(false);
                    if (book != null)
                    {
                        book.StockQuantity -= item.Quantity;
                        book.QuantitySold += item.Quantity;
                        dbContext.Books.Update(book);
                    }
                }

                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding sale: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            try
            {
                var sale = await dbContext.Sales.FindAsync(id).ConfigureAwait(false);
                if (sale == null)
                    return false;

                // First delete related sale items
                var saleItems = await dbContext.SaleItems.Where(si => si.SaleId == id).ToListAsync().ConfigureAwait(false);
                foreach (var item in saleItems)
                {
                    // Restore book stock
                    var book = await dbContext.Books.FindAsync(item.BookId).ConfigureAwait(false);
                    if (book != null)
                    {
                        book.StockQuantity += item.Quantity;
                        book.QuantitySold -= item.Quantity;
                        dbContext.Books.Update(book);
                    }

                    dbContext.SaleItems.Remove(item);
                }

                // Then delete the sale
                dbContext.Sales.Remove(sale);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting sale {id}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            return await dbContext.Sales.AnyAsync(s => s.SalesId == id).ConfigureAwait(false);
        }

        public async Task<List<SalesResponseDto?>> GetAllAsync()
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var sales = await dbContext.Sales
                .Include(s => s.Customer)
                .Include(s => s.User)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);

            var result = new List<SalesResponseDto?>();

            foreach (var sale in sales)
            {
                var saleDto = SaleMapper.MapToResponseDto(sale);
                if (saleDto != null)
                {
                    // Get all sale items for this sale
                    var saleItems = await dbContext.SaleItems
                        .Include(si => si.Book)
                        .Where(si => si.SaleId == sale.SalesId)
                        .AsNoTracking()
                        .ToListAsync()
                        .ConfigureAwait(false);

                    // Calculate total amount
                    decimal totalAmount = 0;
                    foreach (var item in saleItems)
                    {
                        var saleItemDto = SalesItemMapper.MapToResponseDto(item);
                        if (saleItemDto != null)
                        {
                            saleDto.SaleItems.Add(saleItemDto);
                            totalAmount += item.Subtotal;
                        }
                    }

                    saleDto.TotalAmount = totalAmount;
                    result.Add(saleDto);
                }
            }

            return result;
        }

        public async Task<SalesResponseDto?> GetByIdAsync(int id)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var sale = await dbContext.Sales
                .Include(s => s.Customer)
                .Include(s => s.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.SalesId == id)
                .ConfigureAwait(false);

            if (sale == null)
                return null;

            var saleDto = SaleMapper.MapToResponseDto(sale);
            if (saleDto != null)
            {
                // Get all sale items for this sale
                var saleItems = await dbContext.SaleItems
                    .Include(si => si.Book)
                    .Where(si => si.SaleId == sale.SalesId)
                    .AsNoTracking()
                    .ToListAsync()
                    .ConfigureAwait(false);

                // Calculate total amount
                decimal totalAmount = 0;
                foreach (var item in saleItems)
                {
                    var saleItemDto = SalesItemMapper.MapToResponseDto(item);
                    if (saleItemDto != null)
                    {
                        saleDto.SaleItems.Add(saleItemDto);
                        totalAmount += item.Subtotal;
                    }
                }

                saleDto.TotalAmount = totalAmount;
            }

            return saleDto;
        }

        public async Task<bool> UpdateAsync(int id, SalesRequestDto request)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            try
            {
                var sale = await dbContext.Sales.FindAsync(id).ConfigureAwait(false);
                if (sale == null)
                    return false;

                // Update sale properties
                sale.CustomerId = (int)request.CustomerId;
                sale.DeliveryMethod = request.DeliveryMethod;
                // Don't update UserId since it shouldn't change

                // First handle the existing sale items
                var existingItems = await dbContext.SaleItems
                    .Where(si => si.SaleId == id)
                    .ToListAsync()
                    .ConfigureAwait(false);

                foreach (var item in existingItems)
                {
                    // Restore book stock
                    var book = await dbContext.Books.FindAsync(item.BookId).ConfigureAwait(false);
                    if (book != null)
                    {
                        book.StockQuantity += item.Quantity;
                        book.QuantitySold -= item.Quantity;
                        dbContext.Books.Update(book);
                    }

                    dbContext.SaleItems.Remove(item);
                }

                // Then add the updated sale items
                foreach (var item in request.SaleItems)
                {
                    var saleItem = new SaleItem
                    {
                        SaleId = id,
                        BookId = item.BookId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        Discount = item.Discount,
                        Subtotal = item.Quantity * item.UnitPrice - item.Discount
                    };

                    await dbContext.SaleItems.AddAsync(saleItem).ConfigureAwait(false);

                    // Update book stock
                    var book = await dbContext.Books.FindAsync(item.BookId).ConfigureAwait(false);
                    if (book != null)
                    {
                        book.StockQuantity -= item.Quantity;
                        book.QuantitySold += item.Quantity;
                        dbContext.Books.Update(book);
                    }
                }

                dbContext.Sales.Update(sale);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating sale {id}: {ex.Message}");
                return false;
            }
        }
    }
}
