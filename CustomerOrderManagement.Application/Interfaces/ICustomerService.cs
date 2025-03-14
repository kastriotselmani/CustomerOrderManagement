using CustomerOrderManagement.Application.Commands;
using CustomerOrderManagement.Application.Dtos;

namespace CustomerOrderManagement.Application.Interfaces
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(CreateCustomerCommand command);
        Task DeleteCustomerAsync(DeleteCustomerCommand command);
        Task<CustomerDto> GetCustomerByIdAsync(Guid customerId);
    }
}
