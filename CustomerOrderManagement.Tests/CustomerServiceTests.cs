using Moq;
using Microsoft.EntityFrameworkCore;
using CustomerOrderManagement.Infrastructure.Repositories;


namespace CustomerOrderManagement.Tests
{
    public class UnitOfWorkTests
    {
        private UnitOfWork _unitOfWork;
        private Mock<AppDbContext> _mockDbContext;

        [SetUp]
        public void Setup()
        {
            // Mock the DbContext
            _mockDbContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());

            // Initialize the UnitOfWork with the mocked DbContext
            _unitOfWork = new UnitOfWork(_mockDbContext.Object);
        }

        [Test]
        public void UnitOfWork_ShouldInstantiate_WithRepositories()
        {
            // Act
            var customerRepo = _unitOfWork.Customers;
            var orderRepo = _unitOfWork.Orders;
            var productRepo = _unitOfWork.Products;

            // Assert that the repositories are not null
            Assert.notnull(customerRepo);
            Assert.NotNull(orderRepo);
            Assert.NotNull(productRepo);
        }

        [Test]
        public void UnitOfWork_ShouldReturnSameInstanceOfRepository_WhenAccessedMultipleTimes()
        {
            // Act
            var customerRepo1 = _unitOfWork.Customers;
            var customerRepo2 = _unitOfWork.Customers;

            // Assert that the same instance is returned
            Assert.AreSame(customerRepo1, customerRepo2);
        }

        [Test]
        public async Task CompleteAsync_ShouldNotThrowException()
        {
            // Act & Assert
            Assert.DoesNotThrowAsync(async () => await _unitOfWork.CompleteAsync());
        }
    }
}