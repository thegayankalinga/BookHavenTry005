using BookHavenClassLibrary.Dtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<CustomerResponseDto?>> GetAllAsync();
        Task<CustomerResponseDto?> GetByIdAsync(int id);
        Task<bool> AddAsync(CustomerRequestDto request);

        Task<bool> UpdateAsync(int id, CustomerRequestDto request);

        Task<bool> DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}
