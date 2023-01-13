using System;
namespace Ilum.Api.Models;

public class Task : ModelBase
{
	public string Name { get; set; }
	public string Description { get; set; }
	public int Progress { get; set; }
	public string Comment { get; set; }
	public TaskStatus Status { get; set; }
	public int Priority { get; set; }
	public int UserId { get; set; }
	//public User User { get; set; }
	public int LeaderId { get; set; }
	//public User Leader { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime PlannedFinishDate { get; set; }
	public DateTime FinishDate { get; set; }
}