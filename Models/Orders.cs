using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Core;

namespace eCommerce.Models
{
    [Table("orders")]
    public class Orders : EntityEf<int>
    {
        [Required]
        public int UserId { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }
        public virtual ICollection<OrdersDetails> Registros { get; set; }
    }
} 