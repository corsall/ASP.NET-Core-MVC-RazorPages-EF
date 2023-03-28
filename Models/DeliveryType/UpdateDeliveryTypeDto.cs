using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab.Models.DeliveryType
{
    public class UpdateDeliveryTypeDto
    {
        [Required]
        public string Tupdos { get; set; }
    }
}