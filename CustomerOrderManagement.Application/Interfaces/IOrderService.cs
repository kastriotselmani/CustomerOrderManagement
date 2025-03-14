using CustomerOrderManagement.Application.Commands;
using CustomerOrderManagement.Application.Dtos;
using CustomerOrderManagement.Domain.Entities;


namespace CustomerOrderManagement.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId);
        Task<Order> CreateOrderAsync(Order order);
    }
}
