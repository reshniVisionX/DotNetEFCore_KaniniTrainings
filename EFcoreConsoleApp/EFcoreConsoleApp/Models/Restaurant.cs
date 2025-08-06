using System;
using System.Collections.Generic;

namespace EFcoreConsoleApp.Models;

public partial class Restaurant
{
    public int RestId { get; set; }

    public string? Name { get; set; }

    public string? City { get; set; }

    public string? Phno { get; set; }
}
