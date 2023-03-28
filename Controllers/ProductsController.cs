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
}