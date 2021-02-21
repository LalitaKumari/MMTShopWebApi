using System.ComponentModel.DataAnnotations;

namespace MMTShopClient.ViewModel
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
