using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using lab.Contracts;
using lab.Exceptions;
using lab.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace lab.Controllers
{
    public class BaseController<T, TReadDto, TUpdateDto> : ControllerBase where T : class
    {
        private readonly IGenericRepository<T> _repo;
        private readonly IMapper _mapper;

        public BaseController(IGenericRepository<T> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TReadDto>>> GetEntities()
        {
            var entities = await _repo.GetAllAsync();
            var records = _mapper.Map<List<TReadDto>>(entities);
            return Ok(records);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TReadDto>> GetEntity(int id)
        {
            var entity = await _repo.GetAsync(id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(GetEntity), id);
            }

            var entityDto = _mapper.Map<TReadDto>(entity);
            return Ok(entityDto );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TReadDto>> UpdateEntity(int id, TUpdateDto updateEntity)
        {
            var entity = await _repo.GetAsync(id);
            if(entity == null)
            {
                throw new NotFoundException(nameof(UpdateEntity), id);
            }
            _mapper.Map(updateEntity, entity);

            await _repo.UpdateAsync(entity);

            var entityDto = _mapper.Map<TReadDto>(entity);
            return Ok(entityDto);
        }

        [HttpPost]
        public async Task<ActionResult<TReadDto>> PostEntity(TReadDto createEntity)
        {
            var entity = _mapper.Map<T>(createEntity);
            
            await _repo.AddAsync(entity);


            var entityDto = _mapper.Map<TReadDto>(entity);
            return Ok(entityDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            var entity = await _repo.GetAsync(id);
            if(entity == null)
            {
                throw new NotFoundException(nameof(DeleteEntity), id);
            }

            await _repo.DeleteAsync(id);

            return NoContent();
        }
    }
}