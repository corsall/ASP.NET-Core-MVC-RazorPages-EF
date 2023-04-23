using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.Contracts
{
    public interface IidsManager
    {
        public Task<Dictionary<string, List<string>>> GetAllIds();
    }
}