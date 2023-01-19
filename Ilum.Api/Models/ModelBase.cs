using System;
namespace Ilum.Api.Models;

public class ModelBase
{
    public int Id { get; set; }
    public bool IsActive { get; set; }

    public DateTime? CreateDate { get; set; }
    public int? CreateByUserId { get; set; }
    public User? CreateByUser { get; set; }

    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedByUserId { get; set; }
    public User? ModifiedByUser { get; set; }
}