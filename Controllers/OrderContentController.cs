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
    public ActionResult<List<string>> GetTableHeader()
    {
        List<string> header = new List<string>() { "Id", "Номер Замовлення", "Код Продукції", "Кількість"};
        return Ok(header);
    }
}
