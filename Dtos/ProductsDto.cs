using System;
using System.ComponentModel.DataAnnotations;
using eCommerce.Models;

namespace eCommerce.Dtos {
    public class ProductsDto
    {
        public int id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Image { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ShortDesc { get; set; }
        public int? CategoryId { get; set; }
        public virtual Categories Category { get; set;}
    }
}