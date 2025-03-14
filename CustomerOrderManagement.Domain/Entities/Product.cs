using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }  
        public string Name { get; set; } 
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }
        public void UpdateProduct(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
