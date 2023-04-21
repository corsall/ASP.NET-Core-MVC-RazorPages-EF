using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using lab.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lab.Controllers;

//TODO: fix
[ApiController]
[Route("[controller]")]
public class IDsController : Controller
{
    private readonly restaurantsContext _context;

    public IDsController(restaurantsContext context)
    {
        _context = context;
    }

    [HttpGet("ids")]
    public async Task<Dictionary<string, List<string>>> GetIDs()
    {
        var ids = await _context.GetAllIdsAsync();
        return ids;
    }
}
