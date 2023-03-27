using System;
using System.Collections.Generic;

namespace lab.Data
{
    public partial class DovidnykProdukcii
    {
        public DovidnykProdukcii()
        {
            VmistZamovlenies = new HashSet<VmistZamovleny>();
        }

        public int Kodpr { get; set; }
        public string Namepr { get; set; } = null!;
        public decimal Cina { get; set; }

        public virtual ICollection<VmistZamovleny> VmistZamovlenies { get; set; }
    }
}
