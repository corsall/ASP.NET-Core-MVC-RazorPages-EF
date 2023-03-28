using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab.Contracts;
using lab.Data;

namespace lab.Repository
{
    public class OrdersRepository : GenericRepository<VmistZamovleny>, IOrdersRepository
    {
        private readonly restaurantsContext _context;

        public OrdersRepository(restaurantsContext context) : base(context)
        {
            _context = context;
        }
    }
}