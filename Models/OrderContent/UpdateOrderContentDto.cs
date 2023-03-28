using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab.Models.Order
{
    public class UpdateOrderContentDto
    {
        [Required]
        public int Nz { get; set; }
        [Required]
        public int Kodpr { get; set; }
        [Required]
        public int Kil { get; set; }
    }
}