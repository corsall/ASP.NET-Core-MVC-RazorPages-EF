using System;
using System.Collections.Generic;

namespace lab.Data
{
    public partial class ZamovlenyaProductcii
    {
        public ZamovlenyaProductcii()
        {
            VmistZamovlenies = new HashSet<VmistZamovleny>();
        }

        public int Nz { get; set; }
        public int Kodkl { get; set; }
        public DateOnly Datez { get; set; }
        public DateOnly? Datesp { get; set; }
        public int Koddos { get; set; }

        public virtual DovidnykDostavki KoddosNavigation { get; set; } = null!;
        public virtual DovidnykClientiv KodklNavigation { get; set; } = null!;
        public virtual ICollection<VmistZamovleny> VmistZamovlenies { get; set; }
    }
}
