using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab.Contracts;
using lab.Data;

namespace lab.Repository
{
    public class ClientsRepository : GenericRepository<DovidnykClientiv>, IClientsRepository
    {
        private readonly restaurantsContext _context;

        public ClientsRepository(restaurantsContext context) : base(context)
        {
            _context = context;
        }
    }
}