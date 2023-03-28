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

namespace lab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepo;
        private readonly IMapper _mapper;
        public OrdersController(IOrdersRepository ordersRepo, IMapper mapper)
        {
            _mapper = mapper;
            _ordersRepo =  ordersRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var orders = await _ordersRepo.GetAllAsync();
            var records = _mapper.Map<List<OrderDto>>(orders);
            return Ok(records);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var order = await _ordersRepo.GetAsync(id);

            if(order == null)
            {
                throw new NotFoundException(nameof(GetOrder), id);
            }

            var orderDto = _mapper.Map<OrderDto>(order);
            return Ok(orderDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> UpdateOrder(int id, UpdateOrderDto updateOrder)
        {
            var order = await _ordersRepo.GetAsync(id);
            if(order == null)
            {
                throw new NotFoundException(nameof(UpdateOrder), id);
            }
            _mapper.Map(updateOrder, order);

            await _ordersRepo.UpdateAsync(order);

            var orderDto = _mapper.Map<OrderDto>(order);
            return Ok(orderDto);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> PostOrder(OrderDto createorder)
        {
            var order = _mapper.Map<VmistZamovleny>(createorder);
            
            await _ordersRepo.AddAsync(order);

            var orderDto = _mapper.Map<OrderDto>(order);

            return CreatedAtAction(nameof(PostOrder), new {Id = order.Id}, orderDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _ordersRepo.GetAsync(id);
            if(order == null)
            {
                throw new NotFoundException(nameof(DeleteOrder), id);
            }

            await _ordersRepo.DeleteAsync(id);

            return NoContent();
        }
    }
}