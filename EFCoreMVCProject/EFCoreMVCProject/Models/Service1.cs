using System;
using System.Collections.Generic;

namespace EFCoreMVCProject.Models;

public partial class Service1
{
    public int ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public string? Img { get; set; }

    public virtual ICollection<ParlourService> ParlourServices { get; set; } = new List<ParlourService>();
}
