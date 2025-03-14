using CustomerOrderManagement.Domain.Entities;


namespace CustomerOrderManagement.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer); 
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Customer customer);
        Task<Customer> GetByIdAsync(Guid id); 
        Task<IEnumerable<Customer>> GetAllAsync();  
        Task<IEnumerable<Order>> GetOrdersByCustomerAsync(Guid customerId);
    }
}
