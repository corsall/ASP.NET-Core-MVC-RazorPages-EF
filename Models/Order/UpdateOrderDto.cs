using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab.Models.Order
{
    public class UpdateOrderDto
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Nz { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Kodkl { get; set; }
        [Required]
        public DateOnly Datez { get; set; }
        [Required]
        public DateOnly? Datesp { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Koddos { get; set; }
    }
}