using Ecommerce.Models.UtilityModels;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApp.Models.ProductList
{
    public class ProductListViewModel
    {
        public ProductSearchCriteria ProductSearchCriteria { get; set; }
        public ICollection<ProductListItem> ProductList { get; set; }
    }
}
