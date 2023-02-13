using System;
using Ilum.Api.Models;

namespace Ilum.Api.Dtos
{
	public class GetUserDto
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}

