using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Dtos.Supplier;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Mappers;
using BookHavenClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Repositories
{
    public class SupplierOrderRepository : ISupplierOrderRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly IBookRepository _bookRepository;
        private readonly ISupplierRepository _supplierRepository;

        public SupplierOrderRepository(IDbContextFactory<AppDbContext> contextFactory, IBookRepository bookRepository, ISupplierRepository supplierRepository)
        {
            _contextFactory = contextFactory;
            _bookRepository = bookRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task<bool> AddSupplierOrderAsync(SupplierOrderRequestDto supplierOrderRequestDto)
        {
            if (!await _supplierRepository.SupplierExist(supplierOrderRequestDto.SupplierId).ConfigureAwait(false))
                return false;

            using var dbContext = _contextFactory.CreateDbContext();
            var order = SupplierOrderMapper.MapToSupplierOrder(supplierOrderRequestDto);
            try
            {
                await dbContext.SupplierOrders.AddAsync(order).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding supplier order: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> AddSupplierOrderItemAsync(int supplierOrderId, SupplierOrderItemRequestDto orderItemDto)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var order = await dbContext.SupplierOrders.FindAsync(supplierOrderId).ConfigureAwait(false);

            if (order == null)
                throw new KeyNotFoundException($"Supplier Order with ID {supplierOrderId} not found.");

            var orderItem = new SupplierOrderItem
            {
                SupplierOrderId = supplierOrderId,
                BookId = orderItemDto.BookId,
                Quantity = orderItemDto.Quantity,
                UnitPrice = orderItemDto.UnitPrice
            };

            await dbContext.SupplierOrderItems.AddAsync(orderItem).ConfigureAwait(false);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<List<SupplierOrderResponseDto?>> GetAllSupplierOrdersAsync()
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var orders = await dbContext.SupplierOrders
                .Include(o => o.SupplierOrderItems)
                .ToListAsync()
                .ConfigureAwait(false);
            return orders.Select(SupplierOrderMapper.MapToSupplierOrderResponseDto).ToList();
        }

        public async Task<SupplierOrderResponseDto?> GetSupplierOrderByIdAsync(int supplierOrderId)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var order = await dbContext.SupplierOrders
                .Include(o => o.SupplierOrderItems)
                .FirstOrDefaultAsync(o => o.SupplierOrderId == supplierOrderId)
                .ConfigureAwait(false);

            return order == null ? null : SupplierOrderMapper.MapToSupplierOrderResponseDto(order);
        }

        public async Task<bool> UpdateSupplierOrderAsync(int supplierOrderId, SupplierOrderRequestDto supplierOrderRequestDto)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var order = await dbContext.SupplierOrders.FindAsync(supplierOrderId).ConfigureAwait(false);

            if (order == null)
                return false;

            order.OrderStatuses = supplierOrderRequestDto.OrderStatuses;
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteSupplierOrderAsync(int supplierOrderId)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var order = await dbContext.SupplierOrders.FindAsync(supplierOrderId).ConfigureAwait(false);

            if (order == null)
                return false;

            dbContext.SupplierOrders.Remove(order);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
    }
}
