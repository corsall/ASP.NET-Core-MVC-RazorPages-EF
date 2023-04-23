using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using lab.Contracts;
using lab.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lab.Controllers;

[ApiController]
[Route("[controller]")]
public class IDsController : Controller
{
    private readonly IidsManager _id;

    public IDsController(IidsManager id)
    {
        _id = id;
    }

    [HttpGet("ids")]
    public async Task<Dictionary<string, List<string>>> GetIDs()
    {
        var ids = await _id.GetAllIds();
        return ids;
    }
}
