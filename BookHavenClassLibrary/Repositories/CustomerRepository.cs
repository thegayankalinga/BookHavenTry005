using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Dtos.Customer;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public CustomerRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<bool> AddAsync(CustomerRequestDto request)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var customer = CustomerMapper.MaptoModel(request);
            try
            {
                await dbContext.Customers.AddAsync(customer).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex) { 
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var customer = await dbContext.Customers.FindAsync(id).ConfigureAwait(false);
            if (customer == null)
            {
                return false;
            }

            try
            {
                dbContext.Customers.Remove(customer);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            return await dbContext.Customers.AnyAsync(c => c.CustomerId == id).ConfigureAwait(false);
        }

        public async Task<List<CustomerResponseDto?>> GetAllAsync()
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var customers = await dbContext.Customers.AsNoTracking().ToListAsync().ConfigureAwait(false);
            return customers.Select(CustomerMapper.MapToResponseDto).ToList();  
        }

        public async Task<CustomerResponseDto?> GetByIdAsync(int id)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var customer = await dbContext.Customers.FindAsync(id).ConfigureAwait(false);
            return customer == null ? null : CustomerMapper.MapToResponseDto(customer);
        }

        public async Task<bool> UpdateAsync(int id, CustomerRequestDto request)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var customer = await dbContext.Customers.FindAsync(id).ConfigureAwait(false);

            if (customer == null) { return false; }

            customer.FullName = request.FullName;
            customer.PhoneNumber = request.PhoneNumber;
            customer.AddressLineOne = request.AddressLineOne;
            customer.AddressLineTwo = request.AddressLineTwo;
            customer.City = request.City;

            try
            {
                dbContext.Customers.Update(customer);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
