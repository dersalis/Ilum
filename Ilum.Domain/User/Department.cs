using System;
using Ilum.Domain.Common;

namespace Ilum.Domain.User;

public class Department : ModelBase
{
    public string Name { get; set; }
    public string Description { get; set; }
}

