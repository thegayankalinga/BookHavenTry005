using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Dtos.Supplier;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _appDbContext;

        public SupplierRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task<bool> AddSupplierAsync(SupplierRequestDto supplierRequestDto)
        {
            var supplier = SupplierMapper.MaptoSupplier(supplierRequestDto);
            try
            {
                await _appDbContext.Suppliers.AddAsync(supplier);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<bool> DeleteSupplierAsync(int supplierId)
        {
            var supplier = await _appDbContext.Suppliers.FindAsync(supplierId);

            if (supplier == null)
                return false;

            _appDbContext.Suppliers.Remove(supplier);
            await _appDbContext.SaveChangesAsync();

            return true; 
        }

        public async Task<List<SupplierResponseDto?>> GetAllSuppliersAsync()
        {
            var suppliers = await _appDbContext.Suppliers.ToListAsync(); 
            return suppliers.Select(SupplierMapper.MapToSupplierReponseDto).ToList(); 
        }

        public async Task<SupplierResponseDto?> GetSupplierByIdAsync(int supplierId)
        {
            var supplier = await _appDbContext.Suppliers.FindAsync(supplierId);

            if (supplier == null)
                return null;

            return SupplierMapper.MapToSupplierReponseDto(supplier);
        }

        public async Task<bool> UpdateSupplierAsync(int supplierId, SupplierRequestDto supplierRequestDto)
        {
            var supplier = await _appDbContext.Suppliers.FindAsync(supplierId);

            if (supplier == null)
                return false;

            // Manually update properties
            supplier.SupplierName = supplierRequestDto.SupplierName;
            supplier.ContactPersonName = supplierRequestDto.ContactPersonName;
            supplier.PhoneNumber = supplierRequestDto.PhoneNumber;
            supplier.SupplierType = supplierRequestDto.SupplierType;

            _appDbContext.Suppliers.Update(supplier);
            await _appDbContext.SaveChangesAsync();

            return true;
        }
    }
}
