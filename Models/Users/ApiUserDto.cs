using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab.Models.Users;

public class ApiUserDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}
