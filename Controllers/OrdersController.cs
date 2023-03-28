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
}