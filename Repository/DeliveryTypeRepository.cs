using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab.Contracts;
using lab.Data;

namespace lab.Repository
{
    public class DeliveryTypeRepository : GenericRepository<DovidnykDostavki>, IDeliveryTypeRepository
    {
        private readonly restaurantsContext _context;

        public DeliveryTypeRepository(restaurantsContext context) : base(context)
        {
            _context = context;
        }
    }
}