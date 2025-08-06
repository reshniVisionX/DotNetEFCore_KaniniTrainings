using System;
using System.Collections.Generic;

namespace EFCoreMVCProject.Models;

public partial class ParlourService
{
    public int ParlourId { get; set; }

    public int ServiceId { get; set; }

    public decimal? Price { get; set; }

    public int Duration { get; set; }

    public virtual ParlourList Parlour { get; set; } = null!;

    public virtual Service1 Service { get; set; } = null!;
}
