using System.ComponentModel.DataAnnotations;

namespace MMTShop.Core
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
