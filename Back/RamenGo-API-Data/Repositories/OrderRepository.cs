using RamenGo_API_Data.Context;
using RamenGo_API_Domain.Entities;
using RamenGo_API_Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo_API_Data.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RamenContext context) : base(context) { }

    }
}
