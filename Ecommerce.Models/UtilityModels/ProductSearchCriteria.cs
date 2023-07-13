using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.UtilityModels
{
    public class ProductSearchCriteria
    {
    
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Price { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
