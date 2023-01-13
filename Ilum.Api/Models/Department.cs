using System;
namespace Ilum.Api.Models
{
	public class Department : ModelBase
	{
		public string Name { get; set; }

		public ICollection<User> Users { get; set; }
	}
}

