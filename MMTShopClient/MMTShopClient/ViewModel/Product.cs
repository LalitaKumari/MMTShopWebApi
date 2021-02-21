using System.ComponentModel.DataAnnotations;

namespace MMTShopClient.ViewModel
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
