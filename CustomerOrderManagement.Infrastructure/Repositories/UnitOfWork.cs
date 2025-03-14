using CustomerOrderManagement.Infrastructure.Interfaces;

namespace CustomerOrderManagement.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        // Repositories
        private ICustomerRepository _customerRepository;
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;

        // Constructor
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        // Lazy-loaded repositories
        public ICustomerRepository Customers => _customerRepository ??= new CustomerRepository(_context);
        public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_context);
        public IProductRepository Products => _productRepository ??= new ProductRepository(_context);

        // Commit method for saving changes to the database
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // Dispose method for cleaning up resources
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}