using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab.Models.Client
{
    public class UpdateClientDto
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Kodkl { get; set; }
        [Required]
        public string Namekl { get; set; }
    }
}