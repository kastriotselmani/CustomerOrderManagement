using CustomerOrderManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CustomerOrderManagement.Infrastructure.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Order order);
        Task<Order> GetByIdAsync(Guid id);
        Task<IEnumerable<Order>> GetAllAsync();
    }
}

