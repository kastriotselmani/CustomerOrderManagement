using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Commands
{
    public class CreateOrderCommand
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<CreateOrderItemCommand> Items { get; set; }
    }
}
