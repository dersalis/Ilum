using System;
using Ilum.Api.Models;

namespace Ilum.Api.Dtos
{
	public class GetDepartmentDto
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LeaderId { get; set; }
        public string LeaderName { get; set; }
    }
}

