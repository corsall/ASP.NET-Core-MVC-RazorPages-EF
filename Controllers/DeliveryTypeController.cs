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

public class DeliveryTypeController : ControllerBase
{
    private readonly IDeliveryTypeRepository _deliveryTypeRepo;
    private readonly IMapper _mapper;
    public DeliveryTypeController(IDeliveryTypeRepository deliveryTypeRepo, IMapper mapper)
    {
        _mapper = mapper;
        _deliveryTypeRepo = deliveryTypeRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DeliveryTypeDto>>> GetDeliveryTypes()
    {
        var delivery = await _deliveryTypeRepo.GetAllAsync();
        var records = _mapper.Map<List<DeliveryTypeDto>>(delivery);
        return Ok(records);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DeliveryTypeDto>> GetDeliveryType(int id)
    {
        var delivery = await _deliveryTypeRepo.GetAsync(id);

        if(delivery == null)
        {
            throw new NotFoundException(nameof(GetDeliveryType), id);
        }

        var deliveryTypeDto = _mapper.Map<DeliveryTypeDto>(delivery);
        return Ok(deliveryTypeDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DeliveryTypeDto>> UpdateDeliveryType(int id, UpdateDeliveryTypeDto updateDelivery)
    {
        var delivery = await _deliveryTypeRepo.GetAsync(id);
        if(delivery == null)
        {
            throw new NotFoundException(nameof(UpdateDeliveryType), id);
        }
        _mapper.Map(updateDelivery, delivery);

        await _deliveryTypeRepo.UpdateAsync(delivery);

        var deliveryTypeDto = _mapper.Map<DeliveryTypeDto>(delivery);
        return Ok(deliveryTypeDto);
    }

    [HttpPost]
    public async Task<ActionResult<DeliveryTypeDto>> PostDeliveryType(DeliveryTypeDto createDelivery)
    {
        var delivery = _mapper.Map<DovidnykDostavki>(createDelivery);
        
        await _deliveryTypeRepo.AddAsync(delivery);


        var deliveryTypeDto = _mapper.Map<DeliveryTypeDto>(delivery);
        return CreatedAtAction(nameof(PostDeliveryType), new {Koddos = delivery.Koddos}, deliveryTypeDto);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDeliveryTypeDto(int id)
    {
        var delivery = await _deliveryTypeRepo.GetAsync(id);
        if(delivery == null)
        {
            throw new NotFoundException(nameof(DeleteDeliveryTypeDto), id);
        }

        await _deliveryTypeRepo.DeleteAsync(id);

        return NoContent();
    }
}
