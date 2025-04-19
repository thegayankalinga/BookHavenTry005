using BookHavenClassLibrary.Dtos.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Interfaces
{
    public interface ISupplierOrderRepository
    {
        
        Task<bool> AddSupplierOrderAsync(SupplierOrderRequestDto supplierOrderRequestDto);
        Task<List<SupplierOrderResponseDto?>> GetAllSupplierOrdersAsync();
        Task<SupplierOrderResponseDto?> GetSupplierOrderByIdAsync(int supplierOrderId);
        Task<bool> UpdateSupplierOrderAsync(int supplierOrderId, SupplierOrderRequestDto supplierOrderRequestDto);
        Task<bool> DeleteSupplierOrderAsync(int supplierOrderId);

        // **🚀 New Method for Adding Order Items Separately**
        Task<bool> AddSupplierOrderItemAsync(int supplierOrderId, SupplierOrderItemRequestDto orderItemDto);
    }
}
