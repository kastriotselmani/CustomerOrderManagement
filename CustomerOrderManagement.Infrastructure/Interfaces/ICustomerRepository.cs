using CustomerOrderManagement.Domain.Entities;


namespace CustomerOrderManagement.Infrastructure.Interfaces
{
    public interface ICustomerRepository
    {
        public Task AddAsync(Customer customer);
        public Task UpdateAsync(Customer customer);
        public Task DeleteAsync(Customer customer);
        public Task<Customer> GetByIdAsync(Guid id);
        public Task<IEnumerable<Customer>> GetAllAsync();
        public Task<IEnumerable<Order>> GetOrdersByCustomerAsync(Guid customerId);
    }
}