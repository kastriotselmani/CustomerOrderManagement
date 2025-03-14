using CustomerOrderManagement.Application.Commands;
using CustomerOrderManagement.Application.Dtos;
using CustomerOrderManagement.Application.Interfaces;
using CustomerOrderManagement.Domain.Entities;
using CustomerOrderManagement.Domain.Interfaces;
using AutoMapper;
using CustomerOrderManagement.Infrastructure.Interfaces;

namespace CustomerOrderManagement.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly Domain.Interfaces.ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(Domain.Interfaces.ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateCustomerAsync(CreateCustomerCommand command)
        {
            var customer = _mapper.Map<Customer>(command);

            await _customerRepository.AddAsync(customer);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteCustomerAsync(DeleteCustomerCommand command)
        {
            var customer = await _customerRepository.GetByIdAsync(command.CustomerId);
            if (customer != null)
            {
                await _customerRepository.DeleteAsync(customer);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(Guid customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                return null;
            }

            return _mapper.Map<CustomerDto>(customer);
        }

    }
}