using System;
using System.Collections.Generic;

namespace EFCoreMVCProject.Models;

public partial class Product
{
    public int ProdId { get; set; }

    public string? ProName { get; set; }

    public double Price { get; set; }
}
