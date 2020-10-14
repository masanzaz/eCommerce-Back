using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core
{
	public abstract class Entity<TId> : IEquatable<Entity<TId>>
	{
		public TId Id { get; set; }

		protected Entity(TId id)
		{
			Id = id;
		}

		// EF requiete un constructor vacio
		protected Entity() { }

		// For simple entities, this may suffice
		// As Evans notes earlier in the course, equality of Entities is frequently not a simple operation
		public override bool Equals(object otherObject)
		{
			if (otherObject is Entity<TId> entity)
			{
				return Equals(entity);
			}
			return base.Equals(otherObject);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public bool Equals(Entity<TId> other)
		{
			if (other == null)
			{
				return false;
			}
			return this.Id.Equals(other.Id);
		}
	}
}
