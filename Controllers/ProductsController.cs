using System;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Models;
using eCommerce.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using eCommerce.Dtos;
using AutoMapper;
using System.Threading.Tasks;

namespace eCommerce.Conttrollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController: ControllerBase
    {
        private ILogger _logger;
        private IProductService _service;
        private readonly IMapper _mapper;

        public ProductsController(ILogger<ProductsController> logger, IProductService service, IMapper mapper)
        {
            this. _logger = logger;
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _service.GetProducts();
                if (products == null) return NotFound();

                return Ok(_mapper.Map<IEnumerable<ProductsDto>>(products));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var command = await _service.GetProductById(id);
            if(command != null)
            {
                return Ok(_mapper.Map<ProductsDto>(command));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductsDto productoDto)
        {
            if (productoDto == null) return BadRequest();
            try
            {
                var producto = _mapper.Map<Products>(productoDto);
                var result = await _service.AddProduct(producto);
                if (result != null) 
                    return Ok(_mapper.Map<ProductsDto>(result));
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductsDto productoDto)
        {
            if (productoDto == null) return NotFound();
            try
            {
                var producto = _mapper.Map<Products>(productoDto);
                var result = await _service.UpdateProduct(id, producto);
                if (result != null) 
                    return Ok(_mapper.Map<ProductsDto>(result));
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var result = await _service.DeleteProduct(id);
                if(result ==0) return BadRequest();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NoContent();
            }
        }
    }
}
