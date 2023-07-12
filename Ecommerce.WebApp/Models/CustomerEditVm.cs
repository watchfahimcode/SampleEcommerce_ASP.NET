using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApp.Models
{
    public class CustomerEditVm
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
