namespace Ilum.Api.Models
{
    public class User : ModelBase
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Login { get; set; }
		public string CurrentPassword { get; set; }
		public string LastPassword { get; set; }

		public int? DepartmentId { get; set; }
		public Department? Department { get; set; }
	}
}