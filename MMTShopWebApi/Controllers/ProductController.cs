using Microsoft.AspNetCore.Mvc;
using MMTShop.Core;
using MMTShop.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTShopWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IEnumerable<Category>> GetcategoryName()
        {
            return await productRepository.GetCategoryName();
        }

        // GET: api/Product/2
        [HttpGet("{categoryId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(int categoryId)
        {
            if (categoryId == 0)
                return BadRequest("Value must be passed!");
            var products = await productRepository.GetProductForCategory(categoryId);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products); 
        }

    }
}
