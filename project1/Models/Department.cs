using System;
using System.Collections.Generic;

namespace project1.Models;

public partial class Department
{
    public int DeptCode { get; set; }

    public string DeptName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
