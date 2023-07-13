using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApp.Models.ProductList
{
    public class ProductListItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Price { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
