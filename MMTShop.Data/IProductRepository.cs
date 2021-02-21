using MMTShop.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MMTShop.Data
{
    public interface IProductRepository
    {
        Task<IEnumerable<Category>> GetCategoryName();
        Task<IEnumerable<Product>> GetProductForCategory(int categoryId);
        Task<IEnumerable<Product>> GetFeaturedProducts();
    }
}
