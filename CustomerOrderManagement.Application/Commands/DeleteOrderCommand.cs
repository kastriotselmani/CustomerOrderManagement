﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Commands
{
    public class DeleteOrderCommand
    {
        public Guid OrderId { get; set; }

    }
}
