using System;
using System.Collections.Generic;

namespace lab.Data
{
    public partial class DovidnykDostavki
    {
        public DovidnykDostavki()
        {
            ZamovlenyaProductciis = new HashSet<ZamovlenyaProductcii>();
        }

        public int Koddos { get; set; }
        public string Tupdos { get; set; } = null!;

        public virtual ICollection<ZamovlenyaProductcii> ZamovlenyaProductciis { get; set; }
    }
}
