using System;
using System.Collections.Generic;

namespace GymManagementAPI.Entities;

public partial class Trainer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Specialty { get; set; } = null!;

    public int ExperienceYears { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
