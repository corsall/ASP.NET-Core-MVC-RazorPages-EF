using System;
using System.Collections.Generic;

namespace lab.Data
{
    public partial class VmistZamovleny
    {
        public int Id { get; set; }
        public int Nz { get; set; }
        public int Kodpr { get; set; }
        public int Kil { get; set; }

        public virtual DovidnykProdukcii KodprNavigation { get; set; } = null!;
        public virtual ZamovlenyaProductcii NzNavigation { get; set; } = null!;
    }
}
