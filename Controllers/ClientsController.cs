using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lab.Contracts;
using lab.Exceptions;
using lab.Middleware;
using lab.Models.Client;
using Microsoft.AspNetCore.Mvc;

namespace lab.Controllers;

[ApiController]
[Route("api/controller")]

public class ClientsController : ControllerBase
{
    private readonly IClientsRepository _clientsRepo;
    private readonly IMapper _mapper;

    public ClientsController(IClientsRepository clientsRepo, IMapper mapper)
    {
        _clientsRepo = clientsRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDto>>> GetClients()
    {
        var clients = await _clientsRepo.GetAllAsync();
        var records = _mapper.Map<List<ClientDto>>(clients);
        return Ok(records);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClientDto>> GetClient(int id)
    {
        var client = await _clientsRepo.GetAsync(id);

        if(client == null)
        {
            throw new NotFoundException(nameof(GetClient), id);
        }

        var clientDto = _mapper.Map<ClientDto>(client);
        return Ok(clientDto);
    }
}
