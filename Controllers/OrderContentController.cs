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

    public class OrderContentController : ControllerBase
    {
        private readonly IOrderContentsRepository _orderContentsRepo;
        private readonly IMapper _mapper;
        public OrderContentController(IOrderContentsRepository orderContentsRepo, IMapper mapper)
        {
            _mapper = mapper;
            _orderContentsRepo =  orderContentsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrderContents()
        {
            var orders = await _orderContentsRepo.GetAllAsync();
            var records = _mapper.Map<List<OrderDto>>(orders);
            return Ok(records);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> GetOrderContent(int id)
        {
            var order = await _orderContentsRepo.GetAsync(id);

            if(order == null)
            {
                throw new NotFoundException(nameof(GetOrderContent), id);
            }

            var orderDto = _mapper.Map<OrderDto>(order);
            return Ok(orderDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> UpdateOrderContent(int id, UpdateOrderDto updateOrder)
        {
            var order = await _orderContentsRepo.GetAsync(id);
            if(order == null)
            {
                throw new NotFoundException(nameof(UpdateOrderContent), id);
            }
            _mapper.Map(updateOrder, order);

            await _orderContentsRepo.UpdateAsync(order);

            var orderDto = _mapper.Map<OrderDto>(order);
            return Ok(orderDto);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> PostOrderContent(OrderDto createorder)
        {
            var order = _mapper.Map<VmistZamovleny>(createorder);
            
            await _orderContentsRepo.AddAsync(order);

            var orderDto = _mapper.Map<OrderDto>(order);

            return CreatedAtAction(nameof(PostOrderContent), new {Id = order.Id}, orderDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOrderContent(int id)
        {
            var order = await _orderContentsRepo.GetAsync(id);
            if(order == null)
            {
                throw new NotFoundException(nameof(DeleteOrderContent), id);
            }

            await _orderContentsRepo.DeleteAsync(id);

            return NoContent();
        }
    }
}