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

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClientDto>> UpdateClient(int id, UpdateClientDto updateClient)
    {
        var client = await _clientsRepo.GetAsync(id);
        if(client == null)
        {
            throw new NotFoundException(nameof(UpdateClient), id);
        }
        _mapper.Map(updateClient, client);

        await _clientsRepo.UpdateAsync(client);

        var clientDto = _mapper.Map<ClientDto>(client);
        return Ok(clientDto);
    }

    [HttpPost]
    public async Task<ActionResult<ClientDto>> PostClient(ClientDto createClient)
    {
        var client = _mapper.Map<DovidnykClientiv>(createClient);
        
        await _clientsRepo.AddAsync(client);


        var clientDto = _mapper.Map<ClientDto>(client);
        return CreatedAtAction(nameof(PostClient), new {Kodkl = client.Kodkl}, clientDto);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var client = await _clientsRepo.GetAsync(id);
        if(client == null)
        {
            throw new NotFoundException(nameof(DeleteClient), id);
        }

        await _clientsRepo.DeleteAsync(id);

        return NoContent();
    }
}
