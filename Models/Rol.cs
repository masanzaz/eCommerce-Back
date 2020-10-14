using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using eCommerce.Core;
using Microsoft.AspNetCore.Identity;

namespace eCommerce.Models
{
    [Table("roles")]
    public class Rol : IdentityRole, IAuditable
    {
		public Rol() : base()
		{
			Active = true;
		}

        public bool IsAdmin { get; set; }

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