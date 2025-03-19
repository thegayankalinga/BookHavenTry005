using BookHavenClassLibrary.Dtos.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Interfaces
{
    public interface ISupplierRepository
    {
        Task<bool> AddSupplierAsync(SupplierRequestDto supplierRequestDto);
        Task<List<SupplierResponseDto?>> GetAllSuppliersAsync();

        Task<SupplierResponseDto?> GetSupplierByIdAsync(int supplierId);

        Task<bool> UpdateSupplierAsync(int supplierId, SupplierRequestDto supplierRequestDto);

        Task<bool> DeleteSupplierAsync(int supplierId);

        Task<bool> SupplierExist(int supplierId);
    }
}
