using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lab.Contracts;
using lab.Data;
using lab.Exceptions;
using lab.Middleware;
using lab.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace lab.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductsController : BaseController<DovidnykProdukcii, ProductDto, UpdateProductDto>
{
    public ProductsController(IGenericRepository<DovidnykProdukcii> repo, IMapper mapper) : base(repo, mapper)
    {
    }

    [HttpGet("header")]
    public ActionResult< Dictionary<string, string>> GetTableHeader()
    {
        Dictionary<string, string> header = new Dictionary<string, string>()
        {
            { "Код Продукції", "kodpr" },
            { "Назва Продукції", "namepr"},
            { "Ціна", "cina"}
        };
        return Ok(header);
    }

    [HttpGet("tablekeys")]
    public ActionResult<List<string>> GetKeys()
    {
        List<string> keys = new List<string>() { "kodpr"};
        return Ok(keys);
    }
}