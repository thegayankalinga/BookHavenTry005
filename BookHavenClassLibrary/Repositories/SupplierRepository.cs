using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Dtos.Supplier;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public SupplierRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<bool> SupplierExist(int supplierId)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            return await dbContext.Suppliers.AnyAsync(s => s.SupplierId == supplierId).ConfigureAwait(false);
        }

        public async Task<bool> AddSupplierAsync(SupplierRequestDto supplierRequestDto)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var supplier = SupplierMapper.MaptoSupplier(supplierRequestDto);
            try
            {
                await dbContext.Suppliers.AddAsync(supplier).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding supplier: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteSupplierAsync(int supplierId)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var supplier = await dbContext.Suppliers.FindAsync(supplierId).ConfigureAwait(false);

            if (supplier == null)
                return false;

            dbContext.Suppliers.Remove(supplier);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<List<SupplierResponseDto?>> GetAllSuppliersAsync()
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var suppliers = await dbContext.Suppliers.ToListAsync().ConfigureAwait(false);
            return suppliers.Select(SupplierMapper.MapToSupplierReponseDto).ToList();
        }

        public async Task<SupplierResponseDto?> GetSupplierByIdAsync(int supplierId)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var supplier = await dbContext.Suppliers.FindAsync(supplierId).ConfigureAwait(false);
            return supplier == null ? null : SupplierMapper.MapToSupplierReponseDto(supplier);
        }

        public async Task<bool> UpdateSupplierAsync(int supplierId, SupplierRequestDto supplierRequestDto)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var supplier = await dbContext.Suppliers.FindAsync(supplierId).ConfigureAwait(false);

            if (supplier == null)
                return false;

            supplier.SupplierName = supplierRequestDto.SupplierName;
            supplier.ContactPersonName = supplierRequestDto.ContactPersonName;
            supplier.PhoneNumber = supplierRequestDto.PhoneNumber;
            supplier.SupplierType = supplierRequestDto.SupplierType;

            dbContext.Suppliers.Update(supplier);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
    }
}
