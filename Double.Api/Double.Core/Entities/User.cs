using System;
using System.Collections.Generic;

namespace Double.Core.Entities;

public partial class User
{
    public int Identifier { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public DateTime? DateCreation { get; set; }
}
