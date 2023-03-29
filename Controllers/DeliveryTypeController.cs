using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lab.Contracts;
using lab.Data;
using lab.Exceptions;
using lab.Middleware;
using lab.Models.DeliveryType;
using Microsoft.AspNetCore.Mvc;

namespace lab.Controllers;

[ApiController]
[Route("api/[controller]")]

public class DeliveryTypeController : BaseController<DovidnykDostavki, DeliveryTypeDto, UpdateDeliveryTypeDto>
{
    public DeliveryTypeController(IGenericRepository<DovidnykDostavki> repo, IMapper mapper) : base(repo, mapper)
    {
    }

    [HttpGet("header")]
    public ActionResult<List<string>> GetTableHeader()
    {
        List<string> header = new List<string>() { "Код Доставки", "Тип Доставки"};
        return Ok(header);
    }

    [HttpGet("tablekeys")]
    public ActionResult<List<string>> GetKeys()
    {
        List<string> keys = new List<string>() { "koddos"};
        return Ok(keys);
    }
}
