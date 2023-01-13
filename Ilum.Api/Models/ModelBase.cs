using System;
namespace Ilum.Api.Models;

public class ModelBase
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreateDate { get; set; }
    public int CreateUserId { get; set; }
    public User CreateUser { get; set; }
    public DateTime ModifiedDate { get; set; }
    public int ModifiedUserId { get; set; }
    public User ModifiedUser { get; set; }
}