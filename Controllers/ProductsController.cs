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

namespace lab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepo;
        private readonly IMapper _mapper;
        public ProductsController(IProductsRepository productsRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productsRepo =  productsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productsRepo.GetAllAsync();
            var records = _mapper.Map<List<ProductDto>>(products);
            return Ok(records);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _productsRepo.GetAsync(id);

            if(product == null)
            {
                throw new NotFoundException(nameof(GetProduct), id);
            }

            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> UpdateProducts(int id, UpdateProductDto updateProducts)
        {
            var product = await _productsRepo.GetAsync(id);
            if(product == null)
            {
                throw new NotFoundException(nameof(UpdateProducts), id);
            }
            _mapper.Map(updateProducts, product);

            await _productsRepo.UpdateAsync(product);

            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(ProductDto createProduct)
        {
            var product = _mapper.Map<DovidnykProdukcii>(createProduct);
            
            await _productsRepo.AddAsync(product);


            var productDto = _mapper.Map<ProductDto>(product);
            return CreatedAtAction(nameof(PostProduct), new {Kodpr = product.Kodpr}, productDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productsRepo.GetAsync(id);
            if(product == null)
            {
                throw new NotFoundException(nameof(DeleteProduct), id);
            }

            await _productsRepo.DeleteAsync(id);

            return NoContent();
        }
    }
}