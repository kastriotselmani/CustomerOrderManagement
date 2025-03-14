using CustomerOrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);  
        Task UpdateAsync(Product product); 
        Task DeleteAsync(Product product);  
        Task<Product> GetByIdAsync(Guid id);  
        Task<IEnumerable<Product>> GetAllAsync(); 
    }
}
