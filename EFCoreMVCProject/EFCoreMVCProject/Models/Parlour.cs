using System;
using System.Collections.Generic;

namespace EFCoreMVCProject.Models;

public partial class Parlour
{
    public int ParlourId { get; set; }

    public string? ParlourName { get; set; }

    public string? City { get; set; }

    public string? Phone { get; set; }

    public int? Rating { get; set; }

    public string? Image { get; set; }
}
