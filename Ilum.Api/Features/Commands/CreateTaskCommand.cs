using System;
using Ilum.Api.Models;

namespace Ilum.Api.Features.Commands;

public class CreateTaskCommand
{
    public string Name { get; set; }
    public string Description { get; set; }
    //public int Progress { get; set; }
    public string Comment { get; set; }
    public Enums.TaskStatus Status { get; set; }
    public Enums.TaskPriority Priority { get; set; }
    public int ResponsibleUserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime PlannedFinishDate { get; set; }
    //public DateTime FinishDate { get; set; }
}

