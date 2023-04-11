using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using lab.Contracts;
using lab.Data;
using lab.Exceptions;
using lab.Middleware;
using lab.Models.Order;
using Microsoft.AspNetCore.Mvc;

namespace lab.Controllers;

[ApiController]
[Route("api/[controller]")]

public class OrderContentController : BaseController<VmistZamovleny, OrderContentDto, UpdateOrderContentDto>
{
    public OrderContentController(IGenericRepository<VmistZamovleny> repo, IMapper mapper) : base(repo, mapper)
    {
    }

    [HttpGet("header")]
    public ActionResult< Dictionary<string, string>> GetTableHeader()
    {
        Dictionary<string, string> header = new Dictionary<string, string>()
        {
            { "Id", "id" },
            { "Номер Замовлення", "nz" },
            { "Код Продукції", "kodpr"},
            { "Кількість", "kil" },
        };
        return Ok(header);
    }

    [HttpGet("tablekeys")]
    public ActionResult<List<string>> GetKeys()
    {
        List<string> keys = new List<string>() {"id","nz", "kodpr"};
        return Ok(keys);
    }
}
