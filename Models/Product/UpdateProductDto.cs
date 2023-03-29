using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab.Models.Product
{
    public class UpdateProductDto
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Kodpr { get; set; }
        [Required]
        public string Namepr { get; set; }
        [Required]
        public decimal Cina { get; set; }
    }
}