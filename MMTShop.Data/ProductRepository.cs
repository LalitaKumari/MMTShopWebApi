using Microsoft.EntityFrameworkCore;
using MMTShop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShop.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly MMTShopDbContext _dbcontext;
        public ProductRepository(MMTShopDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        /// <summary>
        /// Get All Category Name from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Category>> GetCategoryName()
        {
            //return await _dbcontext.Category
            //         .Select(s => new Category { CategoryName = s.CategoryName })
            //         .ToListAsync();

            return await _dbcontext.Category.FromSqlRaw("EXEC SelectCategoryName").ToListAsync();
        }

        /// <summary>
        /// Get product details based on category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProductForCategory(int categoryId)
        {
            //return await _dbcontext.Product
            //    .Where(x => x.CategoryId == categoryId)
            //    .ToListAsync();

            return await _dbcontext.Product.FromSqlRaw("EXEC SelectProductByCategory @CategoryId = "+categoryId+" ")
                .ToListAsync();
        }

        /// <summary>
        /// Get featured prooduct in range 1xxxx, 2xxxx, 3xxxx
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetFeaturedProducts()
        {
            List<string> skuList = new List<string>() { "1", "2", "3" };

            //return await _dbcontext.Product
            //    //.Where(x => x.SKU.StartsWith("1",StringComparison.OrdinalIgnoreCase)).AsEnumerable()
            //    .Where(x => skuList.Contains(x.SKU.Substring(0,1))).ToListAsync();
            ////.Select(s => new Product { 
            ////    ProductName = s.ProductName,
            ////    Description = s.Description,
            ////    SKU = s.SKU,
            ////    Price = s.Price
            ////    });

            return await _dbcontext.Product.FromSqlRaw("EXEC SelectFeaturedProducts")
                .ToListAsync();
        }
    }
}


