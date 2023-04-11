using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lab.Contracts;
using lab.Data;
using lab.Models.Order;
using Microsoft.AspNetCore.Mvc;

namespace lab.Controllers;

[ApiController]
[Route("api/[controller]")]

public class OrdersController : BaseController<ZamovlenyaProductcii, OrderDto, UpdateOrderDto>
{
    public OrdersController(IGenericRepository<ZamovlenyaProductcii> repo, IMapper mapper) : base(repo, mapper)
    {
    }

    [HttpGet("header")]
    public ActionResult< Dictionary<string, string>> GetTableHeader()
    {
        Dictionary<string, string> header = new Dictionary<string, string>()
        {
            { "Номер Замовлення", "nz" },
            { "Код Клієнта", "kodkl" },
            { "Дата Замовлення", "datez"},
            { "Дата Сплати", "datesp" },
            { "Код Доставки", "koddos"}
        };
        return Ok(header);
    }


    [HttpGet("tablekeys")]
    public ActionResult<List<string>> GetKeys()
    {
        List<string> keys = new List<string>() { "nz", "kodkl", "koddos"};
        return Ok(keys);
    }
}