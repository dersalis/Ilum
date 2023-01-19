using System;
using Ilum.Api.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ilum.Api.Models;

public class Task : ModelBase
{
	public string Name { get; set; }
	public string Description { get; set; }
	public int Progress { get; set; }
	public string Comment { get; set; }
	public Enums.TaskStatus Status { get; set; }
	public Enums.TaskPriority Priority { get; set; }
	public User ResponsibleUser { get; set; }
    public int ResponsibleUserId { get; set; }
    public DateTime StartDate { get; set; }
	public DateTime PlannedFinishDate { get; set; }
	public DateTime FinishDate { get; set; }
}