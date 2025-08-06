using System;
using System.Collections.Generic;

namespace EFCoreMVCProject.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? CustomerName { get; set; }

    public int Quantity { get; set; }

    public DateTime? OrderDate { get; set; }

    public int TotalAmount { get; set; }
}
