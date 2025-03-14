using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal TotalPrice { get; private set; }
        public Guid CustomerId { get; set; }
        public List<OrderItem> Items { get; private set; } = new List<OrderItem>();

        public Order(DateTime orderDate)
        {
            Id = Guid.NewGuid();
            OrderDate = DateTime.UtcNow;
            TotalPrice = 0;
        }

        public void AddItem(Product product, int quantity)
        {
            var orderItem = new OrderItem(product, quantity);
            Items.Add(orderItem);
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            TotalPrice = Items.Sum(item => item.Quantity * item.Product.Price);
        }

        public void SetOrderDate(DateTime orderDate)
        {
            OrderDate = orderDate;
        }
    }
}