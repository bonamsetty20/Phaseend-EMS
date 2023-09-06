using System;
using System.Collections.Generic;

namespace project1.Models;

public partial class Employee
{
    public int EmpCode { get; set; }

    public string EmpName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public int? DepartmentCode { get; set; }

    public virtual Department? DepartmentCodeNavigation { get; set; }
}
