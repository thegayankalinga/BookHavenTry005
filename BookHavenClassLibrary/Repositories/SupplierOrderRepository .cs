using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Dtos.Supplier;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Mappers;
using BookHavenClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Repositories
{
    public class SupplierOrderRepository : ISupplierOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IBookRepository _bookRepository;
        private readonly ISupplierRepository _supplierRepository;

        public SupplierOrderRepository(AppDbContext context, IBookRepository bookRepository, ISupplierRepository supplierRepository)
        {
            _appDbContext = context;
            _bookRepository = bookRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task<bool> AddSupplierOrderAsync(SupplierOrderRequestDto supplierOrderRequestDto)
        {

            if (!await _supplierRepository.SupplierExist(supplierOrderRequestDto.SupplierId)){
                return false;
            }

            var order = SupplierOrderMapper.MapToSupplierOrder(supplierOrderRequestDto);
            try
            {
                await _appDbContext.SupplierOrders.AddAsync(order);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<bool> AddSupplierOrderItemAsync(int supplierOrderId, SupplierOrderItemRequestDto orderItemDto)
        {
            var order = await _appDbContext.SupplierOrders.FindAsync(supplierOrderId);

            if (order == null)
                throw new KeyNotFoundException($"Supplier Order with ID {supplierOrderId} not found.");

            var orderItem = new SupplierOrderItem
            {
                SupplierOrderId = supplierOrderId,
                BookId = orderItemDto.BookId,
                Quantity = orderItemDto.Quantity,
                UnitPrice = orderItemDto.UnitPrice
            };

            await _appDbContext.SupplierOrderItems.AddAsync(orderItem);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<SupplierOrderResponseDto?>> GetAllSupplierOrdersAsync()
        {
            var orders = await _appDbContext.SupplierOrders
                .Include(o => o.SupplierOrderItems)
                .ToListAsync();
            return orders.Select(SupplierOrderMapper.MapToSupplierOrderResponseDto).ToList();
        }

        public async Task<SupplierOrderResponseDto?> GetSupplierOrderByIdAsync(int supplierOrderId)
        {
            var order = await _appDbContext.SupplierOrders
                .Include(o => o.SupplierOrderItems)
                .FirstOrDefaultAsync(o => o.SupplierOrderId == supplierOrderId);

            return order == null ? null : SupplierOrderMapper.MapToSupplierOrderResponseDto(order);
        }

        public async Task<bool> UpdateSupplierOrderAsync(int supplierOrderId, SupplierOrderRequestDto supplierOrderRequestDto)
        {
            var order = await _appDbContext.SupplierOrders.FindAsync(supplierOrderId);

            if (order == null)
                return false;

            order.OrderStatuses = supplierOrderRequestDto.OrderStatuses;
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteSupplierOrderAsync(int supplierOrderId)
        {
            var order = await _appDbContext.SupplierOrders.FindAsync(supplierOrderId);

            if (order == null)
                return false;

            _appDbContext.SupplierOrders.Remove(order);
            await _appDbContext.SaveChangesAsync();

            return true;
        }
    }
}
