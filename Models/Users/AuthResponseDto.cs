using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.Models.Users;

public class AuthResponseDto
{
    public string UserName { get; set; }
    public string UserId { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}
