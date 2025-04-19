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
    public class SaleItemRepository : ISaleItemRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public SaleItemRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<bool> AddAsync(SaleItemRequestDto request)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            try
            {
                var saleItem = new SaleItem
                {
                    SaleId = request.SalesId,
                    BookId = request.BookId,
                    Quantity = request.Quantity,
                    UnitPrice = request.UnitPrice,
                    Discount = request.Discount,
                    Subtotal = request.Quantity * request.UnitPrice - request.Discount
                };

                await dbContext.SaleItems.AddAsync(saleItem).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);

                // Update book stock
                var book = await dbContext.Books.FindAsync(request.BookId).ConfigureAwait(false);
                if (book != null)
                {
                    book.StockQuantity -= request.Quantity;
                    book.QuantitySold += request.Quantity;
                    dbContext.Books.Update(book);
                    await dbContext.SaveChangesAsync().ConfigureAwait(false);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding sale item: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            try
            {
                var saleItem = await dbContext.SaleItems.FindAsync(id).ConfigureAwait(false);
                if (saleItem == null)
                    return false;

                // Restore book stock
                var book = await dbContext.Books.FindAsync(saleItem.BookId).ConfigureAwait(false);
                if (book != null)
                {
                    book.StockQuantity += saleItem.Quantity;
                    book.QuantitySold -= saleItem.Quantity;
                    dbContext.Books.Update(book);
                }

                dbContext.SaleItems.Remove(saleItem);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting sale item {id}: {ex.Message}");
                return false;
            }
        }

        public async Task<List<SaleItemResponseDto?>> GetAllBySaleIdAsync(int saleId)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var saleItems = await dbContext.SaleItems
                .Include(si => si.Book)
                .Where(si => si.SaleId == saleId)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);

            return saleItems.Select(si => SalesItemMapper.MapToResponseDto(si)).ToList();
        }

        public async Task<SaleItemResponseDto?> GetByIdAsync(int id)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var saleItem = await dbContext.SaleItems
                .Include(si => si.Book)
                .AsNoTracking()
                .FirstOrDefaultAsync(si => si.SaleItemId == id)
                .ConfigureAwait(false);

            return SalesItemMapper.MapToResponseDto(saleItem);
        }

        public async Task<bool> UpdateAsync(int id, SaleItemRequestDto request)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            try
            {
                var saleItem = await dbContext.SaleItems.FindAsync(id).ConfigureAwait(false);
                if (saleItem == null)
                    return false;

                // Restore old book stock
                var oldBook = await dbContext.Books.FindAsync(saleItem.BookId).ConfigureAwait(false);
                if (oldBook != null)
                {
                    oldBook.StockQuantity += saleItem.Quantity;
                    oldBook.QuantitySold -= saleItem.Quantity;
                    dbContext.Books.Update(oldBook);
                }

                // Update sale item
                saleItem.BookId = request.BookId;
                saleItem.Quantity = request.Quantity;
                saleItem.UnitPrice = request.UnitPrice;
                saleItem.Discount = request.Discount;
                saleItem.Subtotal = request.Quantity * request.UnitPrice - request.Discount;
                dbContext.SaleItems.Update(saleItem);

                // Update new book stock
                var newBook = await dbContext.Books.FindAsync(request.BookId).ConfigureAwait(false);
                if (newBook != null)
                {
                    newBook.StockQuantity -= request.Quantity;
                    newBook.QuantitySold += request.Quantity;
                    dbContext.Books.Update(newBook);
                }

                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating sale item {id}: {ex.Message}");
                return false;
            }
        }
    }
}
