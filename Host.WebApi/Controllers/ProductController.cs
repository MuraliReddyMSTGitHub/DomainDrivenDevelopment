using DDD.Domain.Dtos;
using DDD.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await this._productRepository.GetItems();
                var productCategoreis = await this._productRepository.GetProductCategories();

                if (products == null || productCategoreis == null)
                    return NotFound();
                else
                    return Ok(products.ConvertToDto(productCategoreis));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " Error retrieving data from the database.");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            try
            {
                var product = await this._productRepository.GetProduct(id);
                var productCategory = await this._productRepository.GetProductCategory(product.CategoryId);

                if (product == null)
                    return BadRequest();
                else
                    return Ok(product.ConvertToDto(productCategory));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " Error retrieving data from the database.");
            }
        }
    }
}
