﻿using Lil.Sales.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lil.Sales.DAL
{
    public interface ISalesProvider
    {
        Task<ICollection<Order>> GetAsync(string customerId);
    }
}
