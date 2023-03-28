using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lab.Contracts;
using lab.Data;
using lab.Exceptions;
using lab.Middleware;
using lab.Models.Client;
using Microsoft.AspNetCore.Mvc;

namespace lab.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ClientsController : BaseController<DovidnykClientiv, ClientDto, UpdateClientDto>
{
    public ClientsController(IGenericRepository<DovidnykClientiv> repo, IMapper mapper) : base(repo, mapper)
    {
    }
}
