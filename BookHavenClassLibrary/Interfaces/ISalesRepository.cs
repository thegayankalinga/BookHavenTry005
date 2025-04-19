using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHavenClassLibrary.Dtos.Sales;

namespace BookHavenClassLibrary.Interfaces
{
    public interface ISalesRepository
    {
        Task<List<SalesResponseDto?>> GetAllAsync();
        Task<SalesResponseDto?> GetByIdAsync(int id);
        Task<bool> AddAsync(SalesRequestDto request);
        Task<bool> UpdateAsync(int id, SalesRequestDto request);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
