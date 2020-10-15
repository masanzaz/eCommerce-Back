using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Core;

namespace eCommerce.Models
{
    [Table("categories")]
    public class Categories : EntityEf<int>
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
    }
} 