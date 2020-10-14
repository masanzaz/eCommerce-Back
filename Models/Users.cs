using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Core;
using Microsoft.AspNetCore.Identity;

namespace eCommerce.Models
{
    [Table("users")]
    public class Users : IdentityUser, IAuditable
    {
        [Required]
        [MaxLength(250)]
        [ScaffoldColumn(false)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        [ScaffoldColumn(false)]
        public string LasName { get; set; }

    #region auditable
        [ScaffoldColumn(false)]
        public bool Active { get; set; }
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }
        [ScaffoldColumn(false)]
        public string ModifiedBy { get; set; }
        [ScaffoldColumn(false)]
        public string CreatedIp { get; set; }
        [ScaffoldColumn(false)]
        public string ModifiedIp { get; set; }
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? ModifiedDate { get; set; }
    #endregion
    
    }
} 