using System;
using System.Collections.Generic;

namespace PO_Api;

public partial class Resignationletter
{
    public int Id { get; set; }

    public string? Reason { get; set; }

    public DateTime? Date { get; set; }

    public int? IdStudent { get; set; }

    public virtual Student? IdStudentNavigation { get; set; }
}
public partial class ResignationletterModel
{
    public int Id { get; set; }

    public string? Reason { get; set; }

    public DateTime? Date { get; set; }

    public int? IdStudent { get; set; }

   
}
