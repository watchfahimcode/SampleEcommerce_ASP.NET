using Ecommerce.Models.UtilityModels;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApp.Models.CustomerList
{
    public class CustomerListViewModel
    {
        public CustomerSearchCriteria CustomerSearchCriteria { get; set; }
        public ICollection<CustomerListItem> CustomerList { get; set; }
    }
}
