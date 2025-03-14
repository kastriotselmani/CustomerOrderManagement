using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Queries
{
    public class GetOrdersByCustomerIdQuery
    {
        public Guid CustomerId { get; set; }

    }
}
