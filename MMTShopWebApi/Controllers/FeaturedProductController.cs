using Microsoft.AspNetCore.Mvc;
using MMTShop.Core;
using MMTShop.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTShopWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeaturedProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public FeaturedProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET: api/FeaturedProduct
        [HttpGet]
        public async Task<IEnumerable<Product>> GetFeaturedProduct()
        {
            return await productRepository.GetFeaturedProducts();
        }
    }
}
