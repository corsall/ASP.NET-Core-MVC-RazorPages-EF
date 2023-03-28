using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab.Contracts;
using lab.Data;

namespace lab.Repository
{
    public class ProductsRepository : GenericRepository<DovidnykProdukcii>, IProductsRepository
    {
        private readonly restaurantsContext _context;

        public ProductsRepository(restaurantsContext context) : base(context)
        {
            _context = context;
        }
    }
}