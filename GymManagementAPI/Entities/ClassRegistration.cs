using System;
using System.Collections.Generic;

namespace GymManagementAPI.Entities;

public partial class ClassRegistration
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public int ClassId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
