using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApp.Models.CustomerList
{
    public class CustomerListItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
