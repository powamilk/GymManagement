using System;
using System.Collections.Generic;

namespace GymManagementAPI.Entities;

public partial class Member
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? MembershipType { get; set; }

    public DateTime JoinDate { get; set; }

    public virtual ICollection<ClassRegistration> ClassRegistrations { get; set; } = new List<ClassRegistration>();
}
