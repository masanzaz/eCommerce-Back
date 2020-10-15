using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Core;

namespace eCommerce.Models
{
    [Table("orders_details")]
    public class OrdersDetails : EntityEf<int>
    {
        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Orders Order { get; set;}

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Products Product { get; set;}
        
        [Required]
        public int Quantity {get; set;} 

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price {get; set;} 
    }
} 