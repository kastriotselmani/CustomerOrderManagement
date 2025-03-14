
namespace CustomerOrderManagement.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; private set; } 
        public Product Product { get; private set; }  
        public int Quantity { get; private set; }

        public OrderItem(Product product, int quantity)
        {
            Id = Guid.NewGuid();
            Product = product;
            Quantity = quantity;
        }
        public OrderItem() { }
    }
}
