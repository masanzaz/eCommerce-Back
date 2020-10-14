
using System;

namespace eCommerce.Core
{
	public abstract class EntityEf<TId> : Entity<TId>, IAuditable
	{

		// EF requiete un constructor vacio
		protected EntityEf()
		{
			Active = true;
		}

		protected EntityEf(TId id) : base(id)
		{
			Active = true;
		}

		/* Propiedades para auditar*/
		public bool Active { get; set; }

		public string CreatedBy { get; set; }

		public string ModifiedBy { get; set; }

		public string CreatedIp { get; set; }

		public string ModifiedIp { get; set; }

		public DateTime CreatedDate { get; set; }

		public System.DateTime? ModifiedDate { get; set; }
	}
}
