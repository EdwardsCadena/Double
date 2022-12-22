using System;
using System.Collections.Generic;

namespace Double.Core.Entities;

public partial class Person
{
    public int Identifier { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public int? FkIdTypeIdenti { get; set; }

    public string? NumberIdentification { get; set; }

    public string? Email { get; set; }

    public DateTime? DateCreation { get; set; }

    public string? NmaeLastNameConcat { get; set; }


}
