using System;
using System.Collections.Generic;

namespace GymManagementAPI.Entities;

public partial class Class
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TrainerId { get; set; }

    public string Schedule { get; set; } = null!;

    public int MaxMembers { get; set; }

    public int? CurrentMembers { get; set; }

    public virtual ICollection<ClassRegistration> ClassRegistrations { get; set; } = new List<ClassRegistration>();

    public virtual Trainer Trainer { get; set; } = null!;
}
