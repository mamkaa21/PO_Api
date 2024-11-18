using System;
using System.Collections.Generic;

namespace PO_Api;

public partial class Student
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public int? Age { get; set; }

    public int? Debts { get; set; }

    public virtual ICollection<Resignationletter> Resignationletters { get; set; } = new List<Resignationletter>();
}
public partial class StudentModel
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public int? Age { get; set; }

    public int? Debts { get; set; }

}
