using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pro5_auth.DTO;
using pro5_auth.Services.IServices;

namespace pro5_auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/product
        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }

        // GET: api/product/1
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            return Ok(product);
        }

        // POST: api/product
        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ProductCreateDto dto)
        {
            var result = await _productService.Create(dto);
            return Ok(result);
        }

        // PUT: api/product
        [HttpPut("Update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(ProductUpdateDto dto)
        {
            var result = await _productService.Update(dto);

            if (result == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            return Ok(result);
        }

        // DELETE: api/product/1
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.Delete(id);

            if (result == "product not found")
            {
                return NotFound(new { message = result });
            }

            return Ok(new { message = result });
        }
    }
}