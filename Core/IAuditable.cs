using System;

namespace eCommerce.Core
{
	public interface IAuditable
	{
		bool Active { get; set; }

		string CreatedBy { get; set; }
		string ModifiedBy { get; set; }

		string CreatedIp { get; set; }
		string ModifiedIp { get; set; }

		DateTime CreatedDate { get; set; }
		DateTime? ModifiedDate { get; set; }
	}
}
