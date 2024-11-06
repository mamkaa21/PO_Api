using System;
using System.Collections.Generic;

namespace PO_Api;

public partial class User
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }
}
