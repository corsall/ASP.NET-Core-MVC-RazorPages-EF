using System;
using System.Collections.Generic;

namespace lab.Data
{
    public partial class DovidnykClientiv
    {
        public DovidnykClientiv()
        {
            ZamovlenyaProductciis = new HashSet<ZamovlenyaProductcii>();
        }

        public int Kodkl { get; set; }
        public string Namekl { get; set; } = null!;

        public virtual ICollection<ZamovlenyaProductcii> ZamovlenyaProductciis { get; set; }
    }
}
