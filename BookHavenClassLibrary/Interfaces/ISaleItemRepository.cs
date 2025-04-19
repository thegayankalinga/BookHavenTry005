using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHavenClassLibrary.Dtos.Sales;

namespace BookHavenClassLibrary.Interfaces
{
    public interface ISaleItemRepository
    {
        Task<List<SaleItemResponseDto?>> GetAllBySaleIdAsync(int saleId);
        Task<SaleItemResponseDto?> GetByIdAsync(int id);
        Task<bool> AddAsync(SaleItemRequestDto request);
        Task<bool> UpdateAsync(int id, SaleItemRequestDto request);
        Task<bool> DeleteAsync(int id);
    }
}
