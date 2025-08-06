using System;
using System.Collections.Generic;

namespace EFcoreConsoleApp.Models;

public partial class ParlourList
{
    public int ParlourId { get; set; }

    public string? ParlourName { get; set; }

    public string? City { get; set; }

    public string? Phone { get; set; }

    public double? Rating { get; set; }

    public byte[]? Image { get; set; }

    public virtual ICollection<ParlourService> ParlourServices { get; set; } = new List<ParlourService>();
}
